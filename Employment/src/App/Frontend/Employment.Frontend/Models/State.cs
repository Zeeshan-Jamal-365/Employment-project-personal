using System.ComponentModel;

namespace Employment.Frontend.Models;

public class State
{
    public int Id { get; set; }
    [DisplayName("State Name")]
    public string? StateName { get; set; }

    public int? CountryId { get; set; }
    public Country? Country { get; set; }
}
