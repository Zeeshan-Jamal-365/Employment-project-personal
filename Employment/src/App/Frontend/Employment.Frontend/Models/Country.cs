using System.ComponentModel;

namespace Employment.Frontend.Models;

public class Country
{
    public int Id { get; set; }
    [DisplayName("Country Name")]
    public string? CountryName { get; set; }

}
