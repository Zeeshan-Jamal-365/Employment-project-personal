using Employment.Shared.Common;

namespace Employment.Services.Model;
public class VmState : IVm
{
    public int Id { get; set; }
    public string? StateName { get; set; } = string.Empty;
    public int CountryId { get; set; }
    //[JsonIgnore]
    public VmCountry? Country { get; set; }
}
