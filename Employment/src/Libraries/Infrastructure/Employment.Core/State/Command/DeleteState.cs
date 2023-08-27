
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.State.Command;

public record DeleteState(int Id) : IRequest<VmState>;
public class DeleteStateHandler : IRequestHandler<DeleteState, VmState>
{
    public readonly IStateRepository _stateRepository;

    public DeleteStateHandler(IStateRepository stateRepository)
    {
        _stateRepository = stateRepository;
    }

    public async Task<VmState> Handle(DeleteState request, CancellationToken cancellationToken)
    {
        return await _stateRepository.Delete(request.Id);
    }



}


