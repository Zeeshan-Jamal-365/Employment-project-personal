using System.Text.Json.Serialization;

namespace Employment.Services.Model;
public class VmState
{
    public int Id { get; set; }
    public string StateName { get; set; } = string.Empty;
    public int CountryId { get; set; }
    [JsonIgnore]
    public VmCountry? VmCountry { get; set; }
}
