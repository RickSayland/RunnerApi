using RunnerApi.Domain.DTOs;

namespace RunnerApi.ApiClient;

public interface IRunnerApiClient
{
    public Task<bool> Authorize(string username, string password);

    #region Runners

    public Task<Runner> CreateRunner(Runner runner);
    public Task<Runner?> GetRunner(int id);
    public Task<IEnumerable<Runner>> GetRunners();
    public Task<Runner> UpdateRunner(int id, Runner updatedRunner);
    public Task<bool?> DeleteRunner(int id);

    #endregion

    #region Activities

    public Task<Activity> CreateActivity(Activity activity);
    public Task<Activity?> GetActivity(int id);
    public Task<IEnumerable<Activity>> GetActivities();
    public Task<IEnumerable<Activity>> GetActivitiesByRunnerId(int runnerId);
    public Task<Activity> UpdateActivity(int id, Activity updatedActivity);
    public Task<bool?> DeleteActivity(int id);

    #endregion
}