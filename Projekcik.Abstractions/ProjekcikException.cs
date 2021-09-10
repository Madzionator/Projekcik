using System;
using System.Net;

namespace Projekcik.Abstractions
{
    public abstract class ProjekcikException : Exception
    {
        protected ProjekcikException(string message) : base(message)
        {
        }
    }

    public record ExceptionResponse(object Response, HttpStatusCode StatusCode);

    public interface IExceptionToResponseMapper
    {
        ExceptionResponse Map(Exception exception);
    }

}
