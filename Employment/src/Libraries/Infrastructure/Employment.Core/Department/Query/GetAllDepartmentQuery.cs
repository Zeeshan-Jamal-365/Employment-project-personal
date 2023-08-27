using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;


namespace Employment.Core.Department.Query
{

    public record GetAllDepartmentQuery() : IRequest<IEnumerable<VmDepartment>>;

    public class GetAllDepartmentQueryHandler :
        IRequestHandler<GetAllDepartmentQuery, IEnumerable<VmDepartment>>
    {
        private readonly IDepartmentRepository _DepartmentRepository;
        public GetAllDepartmentQueryHandler(IDepartmentRepository DepartmentRepository, IMapper mapper)
        {
            _DepartmentRepository = DepartmentRepository;
        }
        public async Task<IEnumerable<VmDepartment>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
        {
            var result = await _DepartmentRepository.GetList();
            return result;
        }
    }
}
