using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Employee.Query
{
    public record GetEmployeeById(int Id) : IRequest<VmEmployee>;

    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeById, VmEmployee>
    {
        private readonly IEmployeeRepository _cityRepository;
        public GetEmployeeByIdHandler(IEmployeeRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<VmEmployee> Handle(GetEmployeeById request, CancellationToken cancellationToken)
        {
            return await _cityRepository.GetById(request.Id);
        }


    }

}
