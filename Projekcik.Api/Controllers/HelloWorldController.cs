using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;

namespace Projekcik.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class HelloWorldController : ControllerBase
    {
        public static Dictionary<Guid, string> _texts = new ();

        [HttpPost]
        public IActionResult Post([FromBody] TextDto text)
        {
            if (string.IsNullOrWhiteSpace(text.Text))
            {
                return BadRequest("text cannot be empty");
            }

            var id = Guid.NewGuid();
            _texts.Add(id, text.Text);
            return Ok(id.ToString());
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] TextDto text)
        {
            if (!_texts.ContainsKey(id))
            {
                return NotFound("not found");
            }

            _texts[id] = text.Text;
            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_texts.Select(x => new
            {
                id = x.Key,
                value = x.Value
            }));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            if (!_texts.ContainsKey(id))
            {
                return NotFound("not found");
            }

            _texts.Remove(id);
            return NoContent();
        }

        public record TextDto(string Text);
    }
}
