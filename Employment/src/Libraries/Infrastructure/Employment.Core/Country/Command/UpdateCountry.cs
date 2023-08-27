using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Country.Command;

public record UpdateCountry(int Id, VmCountry VmCountry) : IRequest<VmCountry>;

public class UpdateCountryHandler : IRequestHandler<UpdateCountry, VmCountry>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public UpdateCountryHandler(ICountryRepository CountryRepository, IMapper mapper)
    {
        _countryRepository = CountryRepository;
        _mapper = mapper;

    }

    public async Task<VmCountry> Handle(UpdateCountry request, CancellationToken cancellation)
    {
        var data = _mapper.Map<Model.Country>(request.VmCountry);
        return await _countryRepository.Update(request.Id, data);
    }
}



