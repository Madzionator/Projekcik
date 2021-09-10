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
    public interface ILocationService
    {
        void Create(LocationEditDto dto);
        void Edit(int id, LocationEditDto dto);
        IList<LocationDto> Browse();
    }

    internal class LocationService : ILocationService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public LocationService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Create(LocationEditDto dto)
        {
            var loc = _context.Locations.FirstOrDefault(x => x.Name == dto.Name);
            if (loc is not null)
            {
                throw new LocationAlreadyExistsException(dto.Name);
            }

            var location = _mapper.Map<Location>(dto);
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void Edit(int id, LocationEditDto dto)
        {
            //protected id
            if (id < 0)
            {
                throw new LocationProtectedException(id);
            }

            var location = _context.Locations.Find(id);
            if (location is null)
            {
                throw new LocationNotFoundException(dto.Name);
            }

            location = _mapper.Map(dto, location);
            _context.Locations.Update(location);
            _context.SaveChanges();
        }

        public IList<LocationDto> Browse()
        {
            var locations = _context.Locations.AsNoTracking();
            return _mapper.Map<List<LocationDto>>(locations);
        }
    }
}
