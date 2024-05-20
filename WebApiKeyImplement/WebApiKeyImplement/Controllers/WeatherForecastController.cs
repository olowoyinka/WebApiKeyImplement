using Microsoft.AspNetCore.Mvc;
using WebApiKeyImplement.DTO;
using WebApiKeyImplement.Utilities;

namespace WebApiKeyImplement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IApiKeyValidation _apiKeyValidation;

        public WeatherForecastController(IApiKeyValidation apiKeyValidation)
        {
            _apiKeyValidation = apiKeyValidation;
        }

        [HttpGet]
        public IActionResult AuthenticateViaQueryParam(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                return BadRequest();

            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);

            if (!isValid)
                return Unauthorized();

            return Ok();
        }

        [HttpPost]
        public IActionResult AuthenticateViaBody([FromBody] RequestModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ApiKey))
                return BadRequest();

            string apiKey = model.ApiKey;

            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);

            if (!isValid)
                return Unauthorized();

            return Ok();
        }

        [HttpGet("header")]
        public IActionResult AuthenticateViaHeader()
        {
            string? apiKey = Request.Headers[Constants.ApiKeyHeaderName];

            if (string.IsNullOrWhiteSpace(apiKey))
                return BadRequest();

            bool isValid = _apiKeyValidation.IsValidApiKey(apiKey);

            if (!isValid)
                return Unauthorized();

            return Ok();
        }
    }
}