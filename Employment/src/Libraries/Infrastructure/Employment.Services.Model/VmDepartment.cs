using Employment.Shared.Common;

namespace Employment.Services.Model;
public class VmDepartment : IVm
{
    public int Id { get; set; }
    public string? DepartmentName { get; set; }
}
