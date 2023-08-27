using Employment.Model;
using Employment.Services.Model;
using Employment.Shared.CommonRepository;

namespace Employment.Repositories.Interface;
public interface IDepartmentRepository : IRepository<Department, VmDepartment, int>
{
}
