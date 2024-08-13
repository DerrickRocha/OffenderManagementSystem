using Microsoft.AspNetCore.Mvc;

namespace OffenderManagementSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloWorldController : ControllerBase
{
    // GET: /HelloWorld
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World!");
    }
}