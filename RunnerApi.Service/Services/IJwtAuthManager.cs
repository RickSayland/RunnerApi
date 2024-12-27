namespace RunnerApi.Service.Services;

public interface IJwtAuthManager
{
    string GenerateToken(string username);
}