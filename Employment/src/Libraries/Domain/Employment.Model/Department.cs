using Employment.Shared.Common;

namespace Employment.Model;
public class Department : BaseEntity, IEntity
{
    public string? DepartmentName { get; set; }

    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
