using RunnerApi.Domain.DTOs;
using RunnerApi.Domain.Enums;

namespace RunnerApi.Domain.Entities;

public class ActivityEntity
{
    public int Id { get; set; }
    public ActivityType Type { get; set; }
    public double Distance { get; set; }
    public double Duration { get; set; }
    public DateTime Date { get; set; }
    public int RunnerId { get; set; }
    
    public Activity Map()
    {
        return new Activity
        {
            Type = Type,
            Distance = Distance,
            Duration = Duration,
            Date = Date,
            RunnerId = RunnerId
        };
    }
}