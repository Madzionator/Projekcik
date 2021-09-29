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
    public class LocationsController : MyController
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(typeof(LocationDto[]), StatusCodes.Status200OK)]
        public IActionResult GetList()
        {
            var locations = _locationService.Browse();
            return Ok(locations);
        }

        [HttpGet("stats")]
        [ProducesResponseType(typeof(LocationStatsDto[]), StatusCodes.Status200OK)]
        public IActionResult GetListWithStats()
        {
            var locations = _locationService.GetStats();
            return Ok(locations);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult CreateLocation([FromBody] LocationEditDto locationDto)
        {
            _locationService.Create(locationDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult EditLocation([FromRoute] int id, [FromBody] LocationEditDto locationDto)
        {
            _locationService.Edit(id, locationDto);
            return NoContent();
        }
    }
}