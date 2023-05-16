using Exam.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.Repositories;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterRepositories(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ExamDbContext>(c => 
            c.UseSqlServer(configuration.GetConnectionString("Local")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}