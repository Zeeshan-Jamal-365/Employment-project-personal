using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.State.Command;

public record UpdateState(int Id, VmState VmState) : IRequest<VmState>;

public class UpdateStateHandler : IRequestHandler<UpdateState, VmState>
{
    private readonly IStateRepository _stateRepository;
    private readonly IMapper _mapper;

    public UpdateStateHandler(IStateRepository StateRepository, IMapper mapper)
    {
        _stateRepository = StateRepository;
        _mapper = mapper;

    }

    public async Task<VmState> Handle(UpdateState request, CancellationToken cancellation)
    {
        var data = _mapper.Map<Model.State>(request.VmState);
        return await _stateRepository.Update(request.Id, data);
    }
}



