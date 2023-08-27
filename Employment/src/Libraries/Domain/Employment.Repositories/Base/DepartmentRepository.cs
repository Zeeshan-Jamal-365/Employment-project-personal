using AutoMapper;
using Employment.Infrastructure;
using Employment.Model;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using Employment.Shared.CommonRepository;

namespace Employment.Repositories.Base;
public class DepartmentRepository : RepositoryBase<Department, VmDepartment, int>, IDepartmentRepository
{
    public DepartmentRepository(IMapper mapper, EmploymentDbContext dbContext) : base(mapper, dbContext)
    {

    }
}
