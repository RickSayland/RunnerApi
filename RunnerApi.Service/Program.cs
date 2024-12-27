using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RunnerApi.Domain.Database;
using RunnerApi.Service.Services;

namespace RunnerApi.Service;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        using (var client = new DatabaseContext())
        {
            client.Database.EnsureCreated();
        }

        builder.Services.AddEntityFrameworkSqlite().AddDbContext<DatabaseContext>();

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Runner API",
                Description = "An API for managing distance running activities and stats",
            });
        });

        builder.Services.AddTransient<IRepository, Repository>();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Running API v1");
            options.RoutePrefix = string.Empty; // Access Swagger at the root URL
        });
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}