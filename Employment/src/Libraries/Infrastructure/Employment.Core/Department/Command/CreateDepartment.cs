using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Department.Command;

public record CreateDepartment(VmDepartment VmDepartment) : IRequest<VmDepartment>;


public class CreateDepartmentHandler : IRequestHandler<CreateDepartment, VmDepartment>
{



    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public CreateDepartmentHandler(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }


    public async Task<VmDepartment> Handle(CreateDepartment request, CancellationToken cancellationToken)
    {
        var data = _mapper.Map<Model.Department>(request.VmDepartment);
        return await _departmentRepository.Add(data);
    }

}

