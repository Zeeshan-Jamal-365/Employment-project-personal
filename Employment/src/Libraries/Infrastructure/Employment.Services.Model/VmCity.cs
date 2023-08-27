using Employment.Shared.Common;
using System.Text.Json.Serialization;

namespace Employment.Services.Model;
public class VmCity : IVm
{
    public int Id { get; set; }
    public string? CityName { get; set; }
    public int StateId { get; set; }
    [JsonIgnore]
    public VmState? VmState { get; set; }
    [JsonIgnore]
    public ICollection<VmEmployee> VmEmployees { get; set; } = new HashSet<VmEmployee>();
}
