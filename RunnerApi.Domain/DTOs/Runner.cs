using System.ComponentModel.DataAnnotations;
using RunnerApi.Domain.Enums;

namespace RunnerApi.Domain.DTOs;

public class Runner
{
    string Username { get; set; }
    [EmailAddress]
    string EmailAddress { get; set; }
    string Name { get; set; }
    int Age { get; set; }
    Gender Gender { get; set; }
}