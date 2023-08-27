
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Country.Command;

public record DeleteCountry(int Id) : IRequest<VmCountry>;
public class DeleteCountryHandler : IRequestHandler<DeleteCountry, VmCountry>
{
    public readonly ICountryRepository _countryRepository;

    public DeleteCountryHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<VmCountry> Handle(DeleteCountry request, CancellationToken cancellationToken)
    {
        return await _countryRepository.Delete(request.Id);
    }



}


