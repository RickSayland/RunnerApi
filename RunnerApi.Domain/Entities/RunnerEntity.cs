using System.ComponentModel.DataAnnotations;
using RunnerApi.Domain.DTOs;
using RunnerApi.Domain.Enums;

namespace RunnerApi.Domain.Entities;

public class RunnerEntity
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string EmailAddress { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }

    public Runner Map()
    {
        return new Runner
        {
            Username = Username,
            EmailAddress = EmailAddress,
            Name = Name,
            Age = Age,
            Gender = Gender
        };
    }
}