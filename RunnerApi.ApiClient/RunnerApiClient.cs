using System.Net.Http.Json;
using System.Text.Json;
using RunnerApi.Domain.DTOs;

namespace RunnerApi.ApiClient;

public class RunnerApiClient : IRunnerApiClient
{
    private HttpClient _client;

    public RunnerApiClient()
    {
        _client = new HttpClient();
    }

    #region Runners

    public async Task<Runner> CreateRunner(Runner newRunner)
    {
        try
        {
            var response = await _client.PostAsJsonAsync("https://localhost:5001/Runners/Create", newRunner);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Runner>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error creating runner", ex);
        }
    }

    public async Task<Runner?> GetRunner(int id)
    {
        try
        {
            var response = await _client.GetAsync($"https://localhost:5001/Runners/Read/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Runner>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error getting runner", ex);
        }
    }

    public async Task<IEnumerable<Runner>> GetRunners()
    {
        try
        {
            var response = await _client.GetAsync("https://localhost:5001/Runners/ReadAll");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Runner>>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error getting runners", ex);
        }
    }

    public async Task<Runner> UpdateRunner(int id, Runner updatedRunner)
    {
        try
        {
            var response = await _client.PutAsJsonAsync($"https://localhost:5001/Runners/Update/{id}", updatedRunner);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Runner>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error updating runner", ex);
        }
    }

    public async Task<bool?> DeleteRunner(int id)
    {
        try
        {
            var response = await _client.GetAsync($"https://localhost:5001/Runners/Delete/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool?>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error deleting runner", ex);
        }
    }

    #endregion

    #region Activities

    public async Task<Activity> CreateActivity(Activity newActivity)
    {
        try
        {
            var response = await _client.PostAsJsonAsync("https://localhost:5001/Activities/Create", newActivity);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Activity>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error creating activity", ex);
        }
    }

    public async Task<Activity?> GetActivity(int id)
    {
        try
        {
            var response = await _client.GetAsync($"https://localhost:5001/Activities/Read/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Activity>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error getting activity", ex);
        }
    }

    public async Task<IEnumerable<Activity>> GetActivities()
    {
        try
        {
            var response = await _client.GetAsync("https://localhost:5001/Activities/ReadAll");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Activity>>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error getting activities", ex);
        }
    }

    public async Task<IEnumerable<Activity>> GetActivitiesByRunnerId(int runnerId)
    {
        try
        {
            var response = await _client.GetAsync($"https://localhost:5001/Activities/GetByRunnerId/{runnerId}");
            if (!response.IsSuccessStatusCode) throw new Exception("Error getting activities by runner id");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Activity>>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error getting activities by runner id", ex);
        }
    }

    public async Task<Activity> UpdateActivity(int id, Activity updatedActivity)
    {
        try
        {
            var response =
                await _client.PutAsJsonAsync($"https://localhost:5001/Activities/Update/{id}", updatedActivity);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Activity>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error updating activity", ex);
        }
    }

    public async Task<bool?> DeleteActivity(int id)
    {
        try
        {
            var response = await _client.GetAsync($"https://localhost:5001/Activities/Delete/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<bool?>(content);
        }
        catch (Exception ex)
        {
            // log and rethrow for the consumer to handle
            throw new Exception("Error deleting activity", ex);
        }
    }

    #endregion
}