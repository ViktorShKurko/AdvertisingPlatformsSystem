using AdvertisingPlatformsSystem.AgentLocation;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class AgentLocationController : ControllerBase
{
    private IAgentLocationService _agentLocationService;

    public AgentLocationController(IAgentLocationService agentLocationService)
    {
        _agentLocationService = agentLocationService;
    }

    [HttpPost("search")]
    public IActionResult GetAgentsByLocation([FromBody] string location)
    {
        return Ok(_agentLocationService.GetAgentsByLocations(location));
    }

    [HttpPost("load")]
    [Consumes("multipart/form-data")]
    public IActionResult Update(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Файл пустой");

        if (file.ContentType != "text/plain")
            return BadRequest("Неверный формат файла");
        
        byte[] fileBytes;
        using (var ms = new MemoryStream())
        {
            file.CopyTo(ms);
            fileBytes = ms.ToArray();
        }
        
        _agentLocationService.UploadAgentLocationData(fileBytes);
        return Ok("Success");
    }
}