using Employment.Shared.Common;

namespace Employment.Services.Model;
public class VmEmployee : IVm
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Gender { get; set; }
    public int DepartmentId { get; set; }
    public VmDepartment? VmSDepartment { get; set; }
    public DateTime JoiningDate { get; set; }
    public Boolean Ssc { get; set; }
    public Boolean? Hsc { get; set; }
    public Boolean? Bsc { get; set; }
    public Boolean? Msc { get; set; }
    public string Picture { get; set; } = string.Empty;


    public int CountryId { get; set; }
    public VmCountry? VmCountry { get; set; }
    public int StateId { get; set; }
    public VmState? VmState { get; set; }
    public int CityId { get; set; }
    public VmCity? VmCity { get; set; }


}
