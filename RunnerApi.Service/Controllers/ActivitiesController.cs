using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RunnerApi.Domain.DTOs;
using RunnerApi.Service.Services;

namespace RunnerApi.Service.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly IRepository _repo;
    public ActivitiesController(IRepository repo)
    {
        _repo = repo;
    }
    
    /// <summary>
    /// Creates an activity
    /// </summary>
    /// <returns>the created activity</returns>
    [HttpPost("Create")]
    public async Task<IActionResult> CreateActivity([FromBody] Activity activity)
    {
        try
        {
            var newActivity = await _repo.CreateActivity(activity);
            return Ok(newActivity);
        }
        catch (Exception e)
        {
            // Log the exception
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Gets an activity by id
    /// </summary>
    /// <returns>the activity</returns>
    [HttpGet("Read/{id:int}")]
    public async Task<IActionResult> GetActivity(int id)
    {
        try
        {
            var activity = await _repo.GetActivity(id);
            if (activity == null)
                return NotFound();
            return Ok(activity);
        }
        catch (Exception e)
        {
            // Log the exception
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Gets a list of activities
    /// </summary>
    /// <returns>the list of activities</returns>
    [HttpGet("ReadAll")]
    public async Task<IActionResult> GetActivities()
    {
        try
        {
            var activities = await _repo.GetActivities();
            return Ok(activities);
        }
        catch (Exception e)
        {
            // Log the exception
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Gets a list of activities for a runner
    /// </summary>
    /// <returns>the list of activities</returns>
    [HttpGet("GetByRunnerId/{runnerId:int}")]
    public async Task<IActionResult> GetActivitiesByRunnerId(int runnerId)
    {
        try
        {
            var activities = await _repo.GetActivitiesByRunnerId(runnerId);
            return Ok(activities);
        }
        catch (Exception e)
        {
            // Log the exception
            return BadRequest(e.Message);
        }
    }
    
    
    /// <summary>
    /// Updates an activity
    /// </summary>
    /// <returns>the updated activity</returns>
    [HttpPut("Update/{id:int}")]
    public async Task<IActionResult> UpdateActivity(int id, [FromBody] Activity updatedActivity)
    {
        try
        {
            var activity = await _repo.UpdateActivity(id, updatedActivity);
            return Ok(activity);
        }
        catch (Exception e)
        {
            // Log the exception
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Deletes an activity
    /// </summary>
    /// <returns>the deleted activity</returns>
    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> DeleteRunner(int id)
    {
        try
        {
            var isSuccessful = await _repo.DeleteActivity(id);
            return Ok(isSuccessful);
        }
        catch (Exception e)
        {
            // Log the exception
            return BadRequest(e.Message);
        }
    }
}