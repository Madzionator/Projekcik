using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Projekcik.Core.DTO;
using Projekcik.Core.Exceptions;
using Projekcik.Database;
using Projekcik.Database.Models;

namespace Projekcik.Core.Services
{
    public interface ICandidateService
    {
        void CreateForJob(CandidateDto dto);
        CandidateDto GetCandidate(Guid CandidateId);
        IList<CandidateDto> BrowseCandidates();
    }

    public class CandidateService : ICandidateService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CandidateService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateForJob(CandidateDto dto)
        {
            var candidate = _mapper.Map<Candidate>(dto);
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
        }

        public CandidateDto GetCandidate(Guid CandidateId)
        {
            var candidate = _context.Candidates.Find(CandidateId);
            if (candidate is null)
            {
                throw new CandidateNotFoundException(CandidateId);
            }

            var dto = _mapper.Map<CandidateDto>(candidate);
            return dto;
        }

        public IList<CandidateDto> BrowseCandidates()
        {
            var candidates = _context.Candidates.AsNoTracking();
            return _mapper.Map<List<CandidateDto>>(candidates);
        }
    }
}
