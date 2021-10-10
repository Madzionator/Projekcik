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
    public class KeywordController : MyController
    {
        private readonly IKeywordService _keywordService;

        public KeywordController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(KeywordDto[]), StatusCodes.Status200OK)]
        public IActionResult GetList()
        {
            var keywords = _keywordService.Browse();
            return Ok(keywords);
        }

        [HttpGet("stats")]
        [ProducesResponseType(typeof(KeywordStatsDto[]), StatusCodes.Status200OK)]
        public IActionResult GetListWithStats()
        {
            var keywords = _keywordService.GetStats();
            return Ok(keywords);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult CreateKeyword([FromBody] KeywordEditDto keywordDto)
        {
            _keywordService.Create(keywordDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult EditKeyword([FromRoute] int id, [FromBody] KeywordEditDto keywordDto)
        {
            _keywordService.Edit(id, keywordDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult DeleteKeyword([FromRoute] int id)
        {
            _keywordService.Delete(id);
            return NoContent();
        }
    }
}