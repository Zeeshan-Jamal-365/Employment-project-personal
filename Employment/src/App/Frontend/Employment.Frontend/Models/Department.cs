using System.ComponentModel;

namespace Employment.Frontend.Models;

public class Department
{
    public int Id { get; set; }
    [DisplayName("Department Name")]
    public string? DepartmentName { get; set; }


}
