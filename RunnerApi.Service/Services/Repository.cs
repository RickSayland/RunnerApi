using Microsoft.EntityFrameworkCore;
using RunnerApi.Domain.Database;
using RunnerApi.Domain.DTOs;

namespace RunnerApi.Service.Services;

public class Repository : IRepository
{
    private readonly DatabaseContext _db;

    public Repository(DatabaseContext db)
    {
        _db = db;
    }

    #region Runners

    public async Task<Runner> CreateRunner(Runner runner)
    {
        await _db.AddAsync(runner.Map());
        await _db.SaveChangesAsync();
        return runner;
    }

    public async Task<Runner?> GetRunner(int id)
    {
        return await _db.Runners
            .Where(r => r.Id == id)
            .Select(r => r.Map())
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Runner>> GetRunners()
    {
        return await _db.Runners.Select(a => a.Map()).ToListAsync();
    }

    public async Task<Runner> UpdateRunner(int id, Runner updatedRunner)
    {
        var originalRunner = await _db.Runners
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync();

        if (originalRunner == null)
            throw new Exception("Runner not found");

        originalRunner.Username = updatedRunner.Username;
        originalRunner.EmailAddress = updatedRunner.EmailAddress;
        originalRunner.Name = updatedRunner.Name;
        originalRunner.Age = updatedRunner.Age;
        originalRunner.Gender = updatedRunner.Gender;

        await _db.SaveChangesAsync();
        return updatedRunner;
    }

    public async Task<bool> DeleteRunner(int id)
    {
        var count = await _db.Runners
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync();
        return count == 1;
    }

    #endregion


    #region Activities

    public async Task<Activity> CreateActivity(Activity activity)
    {
        //Check if the runner exists
        var runner = await GetRunner(activity.RunnerId);
        if (runner == null)
            throw new Exception("Cannot create activity, runner not found");
        await _db.AddAsync(activity.Map());
        await _db.SaveChangesAsync();
        return activity;
    }

    public async Task<Activity?> GetActivity(int id)
    {
        return await _db.Activities
            .Where(r => r.Id == id)
            .Select(r => r.Map())
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Activity>> GetActivities()
    {
        return await _db.Activities.Select(a => a.Map()).ToListAsync();
    }

    public async Task<IEnumerable<Activity>> GetActivitiesByRunnerId(int runnerId)
    {
        return await _db.Activities
            .Where(a => a.RunnerId == runnerId)
            .Select(a => a.Map())
            .ToListAsync();
    }

    public async Task<Activity> UpdateActivity(int id, Activity updatedActivity)
    {
        var originalActivity = await _db.Activities
            .Where(r => r.Id == id)
            .FirstOrDefaultAsync();

        if (originalActivity == null)
            throw new Exception("Activity not found");

        var runner = await GetRunner(updatedActivity.RunnerId);
        if (runner == null)
            throw new Exception("Cannot update activity, runner not found");

        originalActivity.Type = updatedActivity.Type;
        originalActivity.Distance = updatedActivity.Distance;
        originalActivity.Duration = updatedActivity.Duration;
        originalActivity.Date = updatedActivity.Date;
        originalActivity.RunnerId = updatedActivity.RunnerId;

        await _db.SaveChangesAsync();
        return updatedActivity;
    }

    public async Task<bool> DeleteActivity(int id)
    {
        var count = await _db.Activities
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync();
        return count == 1;
    }

    #endregion
}