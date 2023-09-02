using Employment.Services.Model;
using System.ComponentModel;

namespace Employment.Frontend.Models;

public class City
{
    public int Id { get; set; }
    [DisplayName("City Name")]
    public string? CityName { get; set; }

    public int StateId { get; set; }

    public State? State { get; set; }

}
