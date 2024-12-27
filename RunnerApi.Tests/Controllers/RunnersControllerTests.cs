using Microsoft.AspNetCore.Mvc;
using Moq;
using RunnerApi.Domain.DTOs;
using RunnerApi.Domain.Enums;
using RunnerApi.Service.Controllers;
using RunnerApi.Service.Services;
using Xunit;

namespace RunnerApi.Tests.Controllers;

public class RunnersControllerTests
{
    private readonly Mock<IRepository> _mockRepo;
    private readonly RunnersController _controller;

    public RunnersControllerTests()
    {
        _mockRepo = new Mock<IRepository>();
        _controller = new RunnersController(_mockRepo.Object);
    }

    [Fact]
    public async Task GetRunners_ReturnsOkResult_WithListOfRunners()
    {
        var runners = new List<Runner>
        {
            new Runner
            {
                Username = "user1", EmailAddress = "user1@aol.com", Name = "Runner1", Age = 10, Gender = Gender.Male
            },
            new Runner
            {
                Username = "user2", EmailAddress = "user2@aol.com", Name = "Runner2", Age = 20, Gender = Gender.Female
            },
        };
        _mockRepo.Setup(repo => repo.GetRunners()).ReturnsAsync(runners);

        var result = await _controller.GetRunners();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Runner>>(okResult.Value);
        Assert.Contains(runners[0], returnValue);
        Assert.Contains(runners[1], returnValue);
    }

    [Fact]
    public async Task GetRunnerById_ReturnsOkResult_WithRunner()
    {
        var runner = new Runner
        {
            Username = "user1", EmailAddress = "user1@aol.com", Name = "Runner1", Age = 10, Gender = Gender.Male
        };
        _mockRepo.Setup(repo => repo.GetRunner(1)).ReturnsAsync(runner);

        var result = await _controller.GetRunner(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Runner>(okResult.Value);
        Assert.Equal(runner.Username, returnValue.Username);
        Assert.Equal(runner.EmailAddress, returnValue.EmailAddress);
        Assert.Equal(runner.Name, returnValue.Name);
        Assert.Equal(runner.Age, returnValue.Age);
        Assert.Equal(runner.Gender, returnValue.Gender);
    }

    [Fact]
    public async Task GetRunnerById_ReturnsNotFound_WhenRunnerDoesNotExist()
    {
        _mockRepo.Setup(repo => repo.GetRunner(1)).ReturnsAsync((Runner?)null);

        var result = await _controller.GetRunner(1);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateRunnerById_ReturnsOkResult_WithUpdatedRunner()
    {
        var originalRunner = new Runner
        {
            Username = "user1", EmailAddress = "user1@aol.com", Name = "Runner1", Age = 10, Gender = Gender.Male
        };
        var updatedRunner = new Runner
        {
            Username = "updatedUsername", EmailAddress = "updatedEmail@aol.com", Name = "UpdatedName", Age = 10,
            Gender = Gender.Male
        };

        _mockRepo.Setup(repo => repo.UpdateRunner(1, updatedRunner)).ReturnsAsync(updatedRunner);

        var result = await _controller.UpdateRunner(1, updatedRunner);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Runner>(okResult.Value);
        Assert.Equal(updatedRunner.Username, returnValue.Username);
        Assert.Equal(updatedRunner.EmailAddress, returnValue.EmailAddress);
        Assert.Equal(updatedRunner.Name, returnValue.Name);
        Assert.Equal(updatedRunner.Age, returnValue.Age);
        Assert.Equal(updatedRunner.Gender, returnValue.Gender);
    }

    [Fact]
    public async Task CreateRunner_ReturnsOkResult_WithNewRunner()
    {
        var newRunner = new Runner
        {
            Username = "user1", EmailAddress = "user1@aol.com", Name = "Runner1", Age = 10, Gender = Gender.Male
        };

        _mockRepo.Setup(repo => repo.CreateRunner(newRunner)).ReturnsAsync(newRunner);

        var result = await _controller.CreateRunner(newRunner);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Runner>(okResult.Value);
        Assert.Equal(newRunner.Username, returnValue.Username);
        Assert.Equal(newRunner.EmailAddress, returnValue.EmailAddress);
        Assert.Equal(newRunner.Name, returnValue.Name);
        Assert.Equal(newRunner.Age, returnValue.Age);
        Assert.Equal(newRunner.Gender, returnValue.Gender);
    }
}