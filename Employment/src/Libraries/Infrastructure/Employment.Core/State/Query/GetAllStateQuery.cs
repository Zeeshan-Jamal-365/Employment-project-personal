using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;


namespace Employment.Core.State.Query
{

    public record GetAllStateQuery() : IRequest<IEnumerable<VmState>>;

    public class GetAllStateQueryHandler :
        IRequestHandler<GetAllStateQuery, IEnumerable<VmState>>
    {
        private readonly IStateRepository _StateRepository;
        public GetAllStateQueryHandler(IStateRepository StateRepository, IMapper mapper)
        {
            _StateRepository = StateRepository;
        }
        public async Task<IEnumerable<VmState>> Handle(GetAllStateQuery request, CancellationToken cancellationToken)
        {
            var result = await _StateRepository.GetList(x=>x.Country);
            return result;
        }
    }
}
