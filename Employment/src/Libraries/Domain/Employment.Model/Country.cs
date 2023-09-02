using Employment.Shared.Common;

namespace Employment.Model;
public class Country : BaseEntity, IEntity
{
    public string? CountryName { get; set; }
    public ICollection<State> States { get; set; } = new HashSet<State>();
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

}
