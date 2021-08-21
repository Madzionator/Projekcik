using Microsoft.AspNetCore.Mvc;

namespace Projekcik.Api
{
    public class ErrorMessageResult
    {
        public string Message { get; init; }
    }

    public class MyController : ControllerBase
    {
        public IActionResult Error(string message)
        {
            return BadRequest(new ErrorMessageResult
            {
                Message = message
            });
        }
    }
}