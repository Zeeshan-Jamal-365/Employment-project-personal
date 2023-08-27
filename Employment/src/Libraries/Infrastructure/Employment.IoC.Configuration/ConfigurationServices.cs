using Employment.Core;
using Employment.Core.Mapper;
using Employment.Infrastructure;
using Employment.Repositories.Base;
using Employment.Repositories.Interface;
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
        services.AddTransient<ICityRepository, CityRepository>();
        services.AddTransient<ICountryRepository, CountryRepository>();
        services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IStateRepository, StateRepository>();

       

        services.AddMediatR(options=>options.RegisterServicesFromAssemblies(typeof(ICore).Assembly));
        return services;
    }
}
