using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Department.Command;

public record UpdateDepartment(int Id, VmDepartment VmDepartment) : IRequest<VmDepartment>;

public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartment, VmDepartment>
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public UpdateDepartmentHandler(IDepartmentRepository DepartmentRepository, IMapper mapper)
    {
        _departmentRepository = DepartmentRepository;
        _mapper = mapper;

    }

    public async Task<VmDepartment> Handle(UpdateDepartment request, CancellationToken cancellation)
    {
        var data = _mapper.Map<Model.Department>(request.VmDepartment);
        return await _departmentRepository.Update(request.Id, data);
    }
}



