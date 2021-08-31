﻿using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public IActionResult CreateLocation(LocationDto locationDto)
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
                return Error("Nie udało się dodać lokalizacji");
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditLocation(LocationDto locationDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            try
            {
                Location location = _context.Locations.Find(id);
                location = _mapper.Map(locationDto, location);
                _context.Locations.Update(location);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Error("Nie udało się edytować lokalizacji");
            }

            return Ok();
        }
    }
}