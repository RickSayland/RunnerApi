using Microsoft.AspNetCore.Mvc;

namespace RunnerApi.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class RunnersController : ControllerBase
{
    public RunnersController()
    {
        
    }
    
    /// <summary>
    /// Gets a list of runners
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetRunners()
    {
        return Ok("Runners");
    }
}