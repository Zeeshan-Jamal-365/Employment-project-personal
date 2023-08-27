
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.City.Command;

public record DeleteCity(int Id) : IRequest<VmCity>;
public class DeleteCityHandler : IRequestHandler<DeleteCity, VmCity>
{
    public readonly ICityRepository _cityRepository;

    public DeleteCityHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task<VmCity> Handle(DeleteCity request, CancellationToken cancellationToken)
    {
        return await _cityRepository.Delete(request.Id);
    }



}


