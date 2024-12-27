using System.ComponentModel.DataAnnotations;
using System.Data;
using RunnerApi.Domain.Entities;
using RunnerApi.Domain.Enums;

namespace RunnerApi.Domain.DTOs;

public class Runner
{
    public string Username { get; set; }
    [EmailAddress] public string EmailAddress { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }

    public RunnerEntity Map()
    {
        return new RunnerEntity
        {
            Username = Username,
            EmailAddress = EmailAddress,
            Name = Name,
            Age = Age,
            Gender = Gender
        };
    }
}