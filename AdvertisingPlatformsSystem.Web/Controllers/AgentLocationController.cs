using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class AgentLocationController : ControllerBase
{
    [HttpPost]
    public IActionResult GetAgentsByLocation([FromBody] string location)
    {
        return Ok(location);
    }
}