using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projekcik.Api.Models;
using Projekcik.Core.Services;
using Projekcik.Database;
using Projekcik.Database.Models;

namespace Projekcik.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : MyController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        private const string ErrorMessage_CreateLoc = "Nie udało się dodać lokalizacji";
        private const string ErrorMessage_EditLoc = "Nie udało się edytować lokalizacji";
        private const string ErrorMessage_ProtectedValue = "Nie można edytować tej lokalizacji";

        public LocationsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetList()
        {
            var locations = _context.Locations.ToList();
            return Ok(locations);
        }

        [HttpPost]
        public IActionResult CreateLocation([FromBody] LocationDto locationDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            try
            {
                var location = _mapper.Map<Location>(locationDto);
                _context.Locations.Add(location);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Error(ErrorMessage_CreateLoc);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditLocation([FromBody] LocationDto locationDto, [FromRoute] int id)
        {
            if (id < 0)
                return Error(ErrorMessage_ProtectedValue);

            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            try
            {
                var location = _context.Locations.Find(id);
                if (location is null)
                    throw new Exception("location not found");

                location = _mapper.Map(locationDto, location);
                _context.Locations.Update(location);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Error(ErrorMessage_EditLoc);
            }

            return Ok();
        }
    }
}
