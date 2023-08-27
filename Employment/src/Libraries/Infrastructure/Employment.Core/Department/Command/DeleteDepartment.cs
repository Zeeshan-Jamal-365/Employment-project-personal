
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Department.Command;

public record DeleteDepartment(int Id) : IRequest<VmDepartment>;
public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartment, VmDepartment>
{
    public readonly IDepartmentRepository _departmentRepository;

    public DeleteDepartmentHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<VmDepartment> Handle(DeleteDepartment request, CancellationToken cancellationToken)
    {
        return await _departmentRepository.Delete(request.Id);
    }



}


