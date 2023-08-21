using Employment.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Model;
public class Employee : BaseEntity, IEntity
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Gender { get; set; }
    public int DepartmentId { get; set; }
    public Department? Department { get; set; }
    public DateTime JoiningDate { get; set; }
    public Boolean Ssc { get; set; }
    public string? Hsc { get; set; }
    public string? Bsc { get; set; }
    public string? Msc { get; set; }


    public string Picture { get; set; } = string.Empty;


    public int CountryId { get; set; }
    public Country? Country { get; set; }
    public int StateId { get; set; }
    public State? State { get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }
    



}
