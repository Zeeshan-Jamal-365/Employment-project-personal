using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Employee.Command;

public record UpdateEmployee(int Id, VmEmployee VmEmployee) : IRequest<VmEmployee>;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, VmEmployee>
{
    private readonly IEmployeeRepository _cityRepository;
    private readonly IMapper _mapper;

    public UpdateEmployeeHandler(IEmployeeRepository EmployeeRepository, IMapper mapper)
    {
        _cityRepository = EmployeeRepository;
        _mapper = mapper;

    }

    public async Task<VmEmployee> Handle(UpdateEmployee request, CancellationToken cancellation)
    {
        var data = _mapper.Map<Model.Employee>(request.VmEmployee);
        return await _cityRepository.Update(request.Id, data);
    }
}



