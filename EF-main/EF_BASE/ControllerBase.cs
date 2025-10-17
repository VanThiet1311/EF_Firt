using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace EF_API.EF_BASE
{
    [ApiController]
    public abstract class BaseController<T> : ControllerBase where T : class
    {
        protected readonly ILogger<T> _logger;

        protected BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }

        protected IActionResult HandleSuccess(object data, string message = "Success")
        {
            return Ok(new
            {
                success = true,
                message,
                data
            });
        }

        protected IActionResult HandleError(string message, int statusCode = 400)
        {
            return StatusCode(statusCode, new
            {
                success = false,
                message
            });
        }
    }
}
