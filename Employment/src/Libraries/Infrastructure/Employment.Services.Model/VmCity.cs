using Employment.Shared.Common;
using System.Text.Json.Serialization;

namespace Employment.Services.Model;
public class VmCity : IVm
{
    public int Id { get; set; }
    public string? CityName { get; set; }
    public int StateId { get; set; }
    public VmState State { get; set; } = new VmState();
    
}
