using Microsoft.AspNetCore.Mvc;

namespace RunnerApi.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivitiesController : ControllerBase
{
    public ActivitiesController()
    {
        
    }
    
    /// <summary>
    /// Gets a list of activities
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetActivities()
    {
        return Ok("Activities");
    }
}