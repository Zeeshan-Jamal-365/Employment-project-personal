using AutoMapper;
using Employment.Infrastructure;
using Employment.Model;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using Employment.Shared.CommonRepository;

namespace Employment.Repositories.Base;
public class CityRepository : RepositoryBase<City, VmCity, int>, ICityRepository
{
    public CityRepository(IMapper mapper, EmploymentDbContext dbContext) : base(mapper, dbContext)
    {

    }
}
