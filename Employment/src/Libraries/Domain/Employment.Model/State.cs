using Employment.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Model;
public class State : BaseEntity, IEntity
{
    public string StateName { get; set; } = string.Empty;
    public int CountryId { get; set; } 
    public Country? Country { get; set; }
    public ICollection<City> Cities { get; set; } = new HashSet<City>();
    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

}
