using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Employee.Command;

public record CreateEmployee(VmEmployee VmEmployee) : IRequest<VmEmployee>;


public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, VmEmployee>
{



    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public CreateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }


    public async Task<VmEmployee> Handle(CreateEmployee request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Model.Employee>(request.VmEmployee);
        return await _employeeRepository.Add(data);
    }

}

