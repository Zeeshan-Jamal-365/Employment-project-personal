
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Employee.Command;

public record DeleteEmployee(int Id) : IRequest<VmEmployee>;
public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, VmEmployee>
{
    public readonly IEmployeeRepository _cityRepository;

    public DeleteEmployeeHandler(IEmployeeRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<VmEmployee> Handle(DeleteEmployee request, CancellationToken cancellationToken)
    {
        return await _cityRepository.Delete(request.Id);
    }



}


