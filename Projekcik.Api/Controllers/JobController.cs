using System;
using System.Collections.Generic;
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
    public class JobController : MyController
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        private const string ErrorMessage_CreateJob = "Nie udało się dodać oferty pracy";
        private const string ErrorMessage_EditJob = "Nie udało się edytować oferty pracy";

        public JobController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetJobsList()
        {
            var jobs = _context.Jobs.ToList();
            var jobdtos = _mapper.Map<List<JobDto>>(jobs);
            return Ok(jobdtos);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetJob([FromRoute] Guid id)
        {
            var job = _context.Jobs.Find(id);
            if (job is null)
                return NotFound();

            var jobdto = _mapper.Map<JobDto>(job);
            return Ok(jobdto);
        }

        [HttpPost]
        public IActionResult CreateJob([FromBody] JobEditDto jobDto)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            try
            {
                var job = _mapper.Map<Job>(jobDto);
                _context.Jobs.Add(job);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Error(ErrorMessage_CreateJob);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditJob([FromBody] JobEditDto jobDto, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            try
            {
                var job = _context.Jobs.Find(id);
                if (job is null)
                    throw new Exception("job not found");

                job = _mapper.Map(jobDto, job);
                _context.Jobs.Update(job);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return Error(ErrorMessage_EditJob);
            }

            return Ok();
        }
    }
}
