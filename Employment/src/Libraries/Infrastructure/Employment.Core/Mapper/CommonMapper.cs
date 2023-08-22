using AutoMapper;
using Employment.Services.Model;

namespace Employment.Core.Mapper;
public class CommonMapper:Profile
{
    public CommonMapper()
    {
        CreateMap<VmCity, Model.City>().ReverseMap();
        CreateMap<VmEmployee, Model.Employee>().ReverseMap();
        CreateMap<VmDepartment, Model.Department>().ReverseMap();
        CreateMap<VmCountry, Model.Country>().ReverseMap();
        CreateMap<VmState, Model.State>().ReverseMap();
    }
    
}
