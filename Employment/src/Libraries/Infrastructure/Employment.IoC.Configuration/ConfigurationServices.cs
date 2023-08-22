using Employment.Core.Mapper;
using Employment.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Employment.IoC.Configuration;
public static class ConfigurationServices
{
    public static IServiceCollection AddExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EmploymentDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("conn")));
        services.AddAutoMapper(typeof(CommonMapper).Assembly);
        return services;
    }
}
