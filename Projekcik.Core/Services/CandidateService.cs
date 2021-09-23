using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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

    }
}
