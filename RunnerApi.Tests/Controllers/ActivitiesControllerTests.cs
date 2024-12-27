using Microsoft.AspNetCore.Mvc;
using Moq;
using RunnerApi.Domain.DTOs;
using RunnerApi.Domain.Enums;
using RunnerApi.Service.Controllers;
using RunnerApi.Service.Services;
using Xunit;

namespace RunnerApi.Tests.Controllers;

public class ActivitiesControllerTests
{
    private readonly Mock<IRepository> _mockRepo;
    private readonly ActivitiesController _controller;

    public ActivitiesControllerTests()
    {
        _mockRepo = new Mock<IRepository>();
        _controller = new ActivitiesController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetActivities_ReturnsOkResult_WithListOfActivities()
    {
        var activities = new List<Activity>
        {
            new Activity()
            {
                Type = ActivityType.Run, Distance = 20, Duration = 100, Date = DateTime.Now, RunnerId = 1
            },
            new Activity()
            {
                Type = ActivityType.Walk, Distance = 5, Duration = 10, Date = DateTime.Now, RunnerId = 1
            },
        };
        _mockRepo.Setup(repo => repo.GetActivities()).ReturnsAsync(activities);

        var result = await _controller.GetActivities();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Activity>>(okResult.Value);
        Assert.Contains(activities[0], returnValue);
        Assert.Contains(activities[1], returnValue);
    }

    [Fact]
    public async Task GetActivityById_ReturnsOkResult_WithActivity()
    {
        var activity = new Activity()
        {
            Type = ActivityType.Run, Distance = 20, Duration = 100, Date = DateTime.Now, RunnerId = 1
        };
        _mockRepo.Setup(repo => repo.GetActivity(1)).ReturnsAsync(activity);

        var result = await _controller.GetActivity(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Activity>(okResult.Value);
        Assert.Equal(activity.Type, returnValue.Type);
        Assert.Equal(activity.Distance, returnValue.Distance);
        Assert.Equal(activity.Duration, returnValue.Duration);
        Assert.Equal(activity.Date, returnValue.Date);
        Assert.Equal(activity.RunnerId, returnValue.RunnerId);
    }

    [Fact]
    public async Task GetActivityById_ReturnsNotFound_WhenActivityDoesNotExist()
    {
        _mockRepo.Setup(repo => repo.GetActivity(1)).ReturnsAsync((Activity?)null);

        var result = await _controller.GetActivity(1);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateActivityById_ReturnsOkResult_WithUpdatedActivity()
    {
        var originalActivity = new Activity()
        {
            Type = ActivityType.Run, Distance = 20, Duration = 100, Date = DateTime.Now, RunnerId = 1
        };
        var updatedActivity = new Activity()
        {
            Type = ActivityType.Walk, Distance = 10, Duration = 10, Date = DateTime.Now, RunnerId = 1
        };

        _mockRepo.Setup(repo => repo.UpdateActivity(1, updatedActivity)).ReturnsAsync(updatedActivity);

        var result = await _controller.UpdateActivity(1, updatedActivity);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Activity>(okResult.Value);
        Assert.Equal(updatedActivity.Type, returnValue.Type);
        Assert.Equal(updatedActivity.Distance, returnValue.Distance);
        Assert.Equal(updatedActivity.Duration, returnValue.Duration);
        Assert.Equal(updatedActivity.Date, returnValue.Date);
        Assert.Equal(updatedActivity.RunnerId, returnValue.RunnerId);
    }

    [Fact]
    public async Task CreateActivity_ReturnsOkResult_WithNewActivity()
    {
        var newActivity = new Activity()
        {
            Type = ActivityType.Run, Distance = 20, Duration = 100, Date = DateTime.Now, RunnerId = 1
        };

        _mockRepo.Setup(repo => repo.CreateActivity(newActivity)).ReturnsAsync(newActivity);

        var result = await _controller.CreateActivity(newActivity);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Activity>(okResult.Value);
        Assert.Equal(newActivity.Type, returnValue.Type);
        Assert.Equal(newActivity.Distance, returnValue.Distance);
        Assert.Equal(newActivity.Duration, returnValue.Duration);
        Assert.Equal(newActivity.Date, returnValue.Date);
        Assert.Equal(newActivity.RunnerId, returnValue.RunnerId);
    }
}