using System;
using System.IO;
using System.Resources;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
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
        private readonly IValidator<CandidateDto> _candidateValidator;
        private readonly IPdfKeywordExtractor _pdfKeywordExtractor;

        public CandidateController(ICandidateService candidateService, IValidator<CandidateDto> candidateValidator)
        {
            _candidateService = candidateService;
            _candidateValidator = candidateValidator;
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

            var candidateId = Guid.NewGuid();
            var candidateDto = new CandidateDto
            {
                Id = candidateId,
                JobId = jobId,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress,
                Comment = comment,
            };

            var validationResult = (_candidateValidator.Validate(candidateDto));
            validationResult.AddToModelState(ModelState, null);
            if(file is null)
                ModelState.AddModelError("file", "Należy dodać plik");
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            Directory.CreateDirectory($"/candidates");
            var filePath = $"/candidates/{candidateId}.pdf";
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            candidateDto.CvPath = filePath;
            fileStream.Close();

            var candidateKeywords = _candidateService.GetCandidateKeywords(filePath);
            candidateDto.Keywords = candidateKeywords;

            _candidateService.CreateForJob(candidateDto);

            return NoContent();
        }

        [Authorize]
        [HttpGet("download-request/{candidateId}")]
        public IActionResult DownloadRequest([FromRoute] Guid candidateId)
        {
            var candidate = _candidateService.GetCandidate(candidateId);
            if (candidate == null)
                return NotFound();

            var file =
                new FileContentResult(System.IO.File.ReadAllBytes(candidate.CvPath), "application/pdf")
                {
                    FileDownloadName = $"{candidate.FirstName}.{candidate.LastName}.{candidate.Id}.pdf",
                };
            return file;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCandidatesList()
        {
            var candidates = _candidateService.BrowseCandidates();
            return Ok(candidates);
        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteCandidate([FromRoute] Guid id)
        {
            _candidateService.DeleteCandidate(id);
            return NoContent();
        }
    }
}