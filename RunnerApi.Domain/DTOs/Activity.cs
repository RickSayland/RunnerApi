using RunnerApi.Domain.Enums;

namespace RunnerApi.Domain.DTOs;

public class Activity
{
    public ActivityType Type { get; set; }
    public double Distance { get; set; }
    public double Duration { get; set; }
    public DateTime Date { get; set; }
}