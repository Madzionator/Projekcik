using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekcik.Core.DTO;
using Projekcik.Core.Services;
using Projekcik.Infrastructure.Api;

namespace Projekcik.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class JobController : MyController
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(JobDto[]), StatusCodes.Status200OK)]
        public IActionResult GetJobsList()
        {
            var jobs = _jobService.BrowseJobs();
            return Ok(jobs);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(JobDto), StatusCodes.Status200OK)]
        public IActionResult GetJob([FromRoute] Guid id)
        {
            var job = _jobService.GetJob(id);
            return Ok(job);
        }

        [HttpGet("stats")]
        [ProducesResponseType(typeof(LocationStatsDto[]), StatusCodes.Status200OK)]
        public IActionResult GetListWithStats()
        {
            var jobs = _jobService.GetStats();
            return Ok(jobs);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult CreateJob([FromBody] JobEditDto dto)
        {
            _jobService.CreateJob(dto);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult EditJob([FromBody] JobEditDto dto, [FromRoute] Guid id)
        {
            _jobService.EditJob(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteJob([FromRoute] Guid id)
        {
            _jobService.DeleteJob(id);
            return NoContent();
        }
    }
}