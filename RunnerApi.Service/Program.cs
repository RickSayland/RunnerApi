using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RunnerApi.Domain.Database;
using RunnerApi.Service.Services;

namespace RunnerApi.Service;

class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var key = "IReallyLikeToRunReallyFarAndReallyFast!";

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

        builder.Services.AddSingleton<IJwtAuthManager>(new JwtAuthManager(key));

        builder.Services.AddControllers();
        builder.Services.AddLogging();

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

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter 'Bearer' [space] and then your token"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
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