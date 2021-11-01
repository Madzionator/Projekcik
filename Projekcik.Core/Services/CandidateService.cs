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
        void DeleteCandidate(Guid id);
        List<KeywordDto> GetCandidateKeywords(string filePath);
    }

    public class CandidateService : ICandidateService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPdfKeywordExtractor _pdfKeywordExtractor;
        private readonly IKeywordService _keywordService;

        public CandidateService(DataContext context, IMapper mapper, IPdfKeywordExtractor pdfKeywordExtractor, IKeywordService keywordService)
        {
            _context = context;
            _mapper = mapper;
            _pdfKeywordExtractor = pdfKeywordExtractor;
            _keywordService = keywordService;
        }

        public void CreateForJob(CandidateDto dto)
        {
            var candidate = _mapper.Map<Candidate>(dto);

            candidate.Keywords = _context.Keywords.Where(keyword => dto.Keywords.Select(x=>x.Id).Contains(keyword.Id)).ToList();
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

        public List<KeywordDto> GetCandidateKeywords(string filePath)
        {
            var allKeyWords = _keywordService.Browse();
            return _pdfKeywordExtractor.Find(filePath, allKeyWords);
        }

        public IList<CandidateDto> BrowseCandidates()
        {
            var candidates = _context.Candidates.AsNoTracking();
            return _mapper.Map<List<CandidateDto>>(candidates);
        }

        public void DeleteCandidate(Guid id)
        {
            var candidate = _context.Candidates.Find(id);
            candidate.IsDeleted = true;
            _context.Candidates.Update(candidate);
            _context.SaveChanges();
        }
    }
}
