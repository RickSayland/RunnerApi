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
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Runner>(content);
            }

            return null;
        }
        catch (Exception ex)
        {
            // log
            return null;
        }
    }

    public async Task<Runner?> GetRunner(int id)
    {
        try
        {
            var response = await _client.GetAsync($"https://localhost:5001/Runners/Read/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Runner>(content);
            }

            return null;
        }
        catch (Exception ex)
        {
            // log
            return null;
        }
    }

    public async Task<IEnumerable<Runner>> GetRunners()
    {
        try
        {
            var response = await _client.GetAsync("https://localhost:5001/Runners/ReadAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<Runner>>(content);
            }

            return null;
        }
        catch (Exception ex)
        {
            // log
            return null;
        }
    }

    public async Task<Runner> UpdateRunner(int id, Runner updatedRunner)
    {
        try
        {
            var response = await _client.PutAsJsonAsync($"https://localhost:5001/Runners/Update/{id}", updatedRunner);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Runner>(content);
            }

            return null;
        }
        catch (Exception ex)
        {
            // log
            return null;
        }
    }

    public async Task<bool?> DeleteRunner(int id)
    {
        try
        {
            var response = await _client.GetAsync($"https://localhost:5001/Runners/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<bool?>(content);
            }

            return null;
        }
        catch (Exception ex)
        {
            // log
            return null;
        }
    }

    #endregion

    #region Activities

    public async Task<Activity> CreateActivity(Activity newActivity)
    {
        try
        {
            var response = await _client.PostAsJsonAsync("https://localhost:5001/Activities/Create", newActivity);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Activity>(content);
            }

            return null;
        }
        catch (Exception ex)
        {
            // log
            return null;
        }
    }

    public async Task<Activity?> GetActivity(int id)
    {
        try
        {
            var response = await _client.GetAsync($"https://localhost:5001/Activities/Read/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Activity>(content);
            }

            return null;
        }
        catch (Exception ex)
        {
            // log
            return null;
        }
    }

    public async Task<IEnumerable<Activity>> GetActivities()
    {
        try
        {
            var response = await _client.GetAsync("https://localhost:5001/Activities/ReadAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<Activity>>(content);
            }

            return null;
        }
        catch (Exception ex)
        {
            // log
            return null;
        }
    }

    public Task<IEnumerable<Activity>> GetActivitiesByRunnerId(int runnerId)
    {
        throw new NotImplementedException();
    }

    public async Task<Activity> UpdateActivity(int id, Activity updatedActivity)
    {
        try
        {
            var response =
                await _client.PutAsJsonAsync($"https://localhost:5001/Activities/Update/{id}", updatedActivity);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Activity>(content);
            }

            return null;
        }
        catch (Exception ex)
        {
            // log
            return null;
        }
    }

    public async Task<bool?> DeleteActivity(int id)
    {
        try
        {
            var response = await _client.GetAsync($"https://localhost:5001/Activities/Delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<bool?>(content);
            }

            return null;
        }
        catch (Exception ex)
        {
            // log
            return null;
        }
    }

    #endregion
}