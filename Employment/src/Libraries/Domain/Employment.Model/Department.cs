using Employment.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Model;
public class Department : BaseEntity, IEntity
{
    public string? DepartmentName { get; set; }

    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
