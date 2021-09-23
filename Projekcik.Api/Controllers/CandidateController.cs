using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projekcik.Core.DTO;
using Projekcik.Core.Services;
using Projekcik.Infrastructure.Api;

namespace Projekcik.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : MyController
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }
        

        [HttpPost("{jobId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Consumes("multipart/form-data")]
        public ActionResult ApplyForJob(
            [FromRoute] Guid jobId, [FromForm] IFormFile file, 
            [FromForm] string firstName, [FromForm] string lastName, 
            [FromForm] string phoneNumber, [FromForm] string emailAddress, 
            [FromForm] string comment)
        {
            if (file is null)
                return BadRequest();

            Guid candidateId = Guid.NewGuid();
            var filePath = @"C:\Users\Madzia\Desktop\candidate\" + candidateId + ".pdf";
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);

            var candidateDto = new CandidateDto(candidateId, jobId, firstName, lastName,
                phoneNumber, emailAddress, filePath, comment);
            _candidateService.CreateForJob(candidateDto);
            return NoContent();
        }

    }
}