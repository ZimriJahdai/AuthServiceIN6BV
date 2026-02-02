using AuthServiceIN6BV.Application.Interfaces;
using AuthServiceIN6BV.Application.Services;
using AuthServiceIN6BV.Domain.Interfaces;
using AuthServiceIN6BV.Persistence.Data;
using AuthServiceIN6BV.Persistence.Repositories;
using AuthServiceIN6BV.Persistence.Repository;
using Microsoft.EntityFrameworkCore;


namespace AuthServiceIN6BV.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<ApplicationDbContext>(options => 
        options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            .UseSnakeCaseNamingConvention());


        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();


        services.AddHealthChecks();

        return services;    

    }

    public static IServiceCollection AddApiDocumentation(this IServiceCollection services)
    {
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

}