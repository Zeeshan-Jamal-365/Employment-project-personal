using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.City.Command;

public record UpdateCity(int Id, VmCity VmCity) : IRequest<VmCity>;

public class UpdateCityHandler : IRequestHandler<UpdateCity, VmCity>
{
    private readonly ICityRepository _cityRepository;
    private readonly IMapper _mapper;

    public UpdateCityHandler(ICityRepository CityRepository, IMapper mapper)
    {
        _cityRepository = CityRepository;
        _mapper = mapper;

    }

    public async Task<VmCity> Handle(UpdateCity request, CancellationToken cancellation)
    {
        var data = _mapper.Map<Model.City>(request.VmCity);
        return await _cityRepository.Update(request.Id, data);
    }
}



