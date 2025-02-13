using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RunnerApi.Domain.DTOs;
using RunnerApi.Service.Services;

namespace RunnerApi.Service.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class RunnersController : ControllerBase
{
    private readonly IRepository _repo;
    private readonly ILogger<RunnersController> _logger;

    public RunnersController(IRepository repo, ILogger<RunnersController> logger)
    {
        _repo = repo;
        _logger = logger;
    }

    /// <summary>
    /// Creates a runner
    /// </summary>
    /// <returns>the created runner</returns>
    [HttpPost("Create")]
    public async Task<IActionResult> CreateRunner([FromBody] Runner runner)
    {
        try
        {
            var newRunner = await _repo.CreateRunner(runner);
            return Ok(newRunner);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e, "Error creating runner");
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Gets a runner by id
    /// </summary>
    /// <returns>the runner</returns>
    [HttpGet("Read/{id:int}")]
    public async Task<IActionResult> GetRunner(int id)
    {
        try
        {
            var runner = await _repo.GetRunner(id);
            if (runner == null)
                return NotFound();
            return Ok(runner);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e, "Error getting runner");
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Gets a list of runners
    /// </summary>
    /// <returns>the list of runners</returns>
    [HttpGet("ReadAll")]
    public async Task<IActionResult> GetRunners()
    {
        try
        {
            var runners = await _repo.GetRunners();
            return Ok(runners);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e, "Error getting runners");
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Updates a runner
    /// </summary>
    /// <returns>the updated runner</returns>
    [HttpPut("Update/{id:int}")]
    public async Task<IActionResult> UpdateRunner(int id, [FromBody] Runner updatedRunner)
    {
        try
        {
            var runner = await _repo.UpdateRunner(id, updatedRunner);
            return Ok(runner);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e, "Error updating runner");
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Deletes a runner
    /// </summary>
    /// <returns>the deleted runner</returns>
    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> DeleteRunner(int id)
    {
        try
        {
            var isSuccessful = await _repo.DeleteRunner(id);
            return Ok(isSuccessful);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e, "Error deleting runner");
            return BadRequest(e.Message);
        }
    }
}