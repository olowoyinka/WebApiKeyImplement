using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiKeyImplement.APIKey;

namespace WebApiKeyImplement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    [ApiKey]
    public IActionResult Get()
    {
        return Ok();
    }

    [HttpGet("all")]
    [Authorize(Policy = "ApiKeyPolicy")]
    public IActionResult GetEmployees()
    {
        return Ok();
    }
}