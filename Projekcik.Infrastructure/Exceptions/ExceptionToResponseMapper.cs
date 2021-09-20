using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;

namespace Projekcik.Infrastructure.Exceptions
{
    public class ExceptionToResponseMapper : IExceptionToResponseMapper
    {
        private static readonly ConcurrentDictionary<Type, string> Codes = new();

        public ExceptionResponse Map(Exception exception)
            => exception switch
            {
                ProjekcikException ex => new ExceptionResponse(new ErrorsResponse(ex.Message, new Error(GetErrorCode(ex), ex.Message)), HttpStatusCode.BadRequest),
                _ => new ExceptionResponse(new ErrorsResponse("There was an error", new Error("error", "There was an error.")), HttpStatusCode.InternalServerError)
            };

        private record Error(string Code, string Message);
        private record ErrorsResponse(string Title, params Error[] Errors);

        private static string GetErrorCode(object exception)
        {
            var type = exception.GetType();
            return Codes.GetOrAdd(type, type.Name.ToLower().Replace(' ', '_').Replace('.','_').Replace("_exception", string.Empty));
        }
    }
}