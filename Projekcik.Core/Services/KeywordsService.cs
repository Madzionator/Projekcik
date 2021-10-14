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
    public interface IKeywordService
    {
        void Create(KeywordEditDto dto);
        void Edit(int id, KeywordEditDto dto);
        void Delete(int id);
        IList<KeywordDto> Browse();
        IList<KeywordStatsDto> GetStats();
    }

    internal class KeywordService : IKeywordService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public KeywordService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(KeywordEditDto dto)
        {
            var keyw = _context.Keywords.FirstOrDefault(x => x.Name == dto.Name);
            if (keyw is not null)
            {
                throw new KeywordAlreadyExistsException(dto.Name);
            }

            var keyword = _mapper.Map<Keyword>(dto);
            _context.Keywords.Add(keyword);
            _context.SaveChanges();
        }

        public void Edit(int id, KeywordEditDto dto)
        {
            var keyword = _context.Keywords.Find(id);
            if (keyword is null)
            {
                throw new KeywordNotFoundException(dto.Name);
            }

            keyword = _mapper.Map(dto, keyword);
            _context.Keywords.Update(keyword);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var keyword = _context.Keywords.Find(id);
            if (keyword is null)
            {
                throw new KeywordNotFoundException(id);
            }
            _context.Keywords.Remove(keyword);
            _context.SaveChanges();
        }

        public IList<KeywordDto> Browse()
        {
            var keywords = _context.Keywords.AsNoTracking();
            return _mapper.Map<List<KeywordDto>>(keywords);
        }

        public IList<KeywordStatsDto> GetStats()
        {
            return _context.Keywords
                .Include(x => x.Candidate)
                .AsNoTracking()
                .Select(keyw => _mapper.Map<KeywordStatsDto>(keyw))
                .ToList();
        }
    }
}
