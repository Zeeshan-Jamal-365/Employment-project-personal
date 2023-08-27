using Employment.Shared.Common;

namespace Employment.Model;
public class City : BaseEntity, IEntity
{
    public string? CityName { get; set; }
    public int StateId { get; set; }
    public State? State { get; set; }
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}
