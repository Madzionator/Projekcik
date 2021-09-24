using System;
using Projekcik.Infrastructure.Exceptions;

namespace Projekcik.Core.Exceptions
{
    internal abstract class CandidateException : ProjekcikException
    {
        protected CandidateException(string message) : base(message)
        {
        }
    }

    internal class CandidateNotFoundException : CandidateException
    {
        public Guid CandidateId { get; }

        public CandidateNotFoundException(Guid candidateId) : base("Kandydat nie istnieje.")
        {
            CandidateId = candidateId;
        }
    }
}