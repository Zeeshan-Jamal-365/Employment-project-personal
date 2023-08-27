namespace Employment.Frontend.Models;

public class Country
{
    public int id { get; set; }
    public string? countryName { get; set; }
    public ICollection<State> states { get; set; } = new HashSet<State>();
    public ICollection<Employee> employees { get; set; } = new HashSet<Employee>();
}
