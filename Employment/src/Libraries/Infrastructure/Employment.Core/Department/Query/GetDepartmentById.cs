using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Department.Query
{
    public record GetDepartmentById(int Id) : IRequest<VmDepartment>;

    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentById, VmDepartment>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public GetDepartmentByIdHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<VmDepartment> Handle(GetDepartmentById request, CancellationToken cancellationToken)
        {
            return await _departmentRepository.GetById(request.Id);
        }


    }

}
