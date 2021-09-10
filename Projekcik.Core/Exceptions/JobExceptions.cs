using System;
using Projekcik.Infrastructure.Exceptions;

namespace Projekcik.Core.Exceptions
{
    internal abstract class JobException : ProjekcikException
    {
        protected JobException(string message) : base(message)
        {
        }
    }


    internal class JobNotFoundException : JobException
    {
        public Guid JobId { get; }

        public JobNotFoundException(Guid jobId) : base("Oferta pracy nie istnieje.")
        {
            JobId = jobId;
        }
    }
}
