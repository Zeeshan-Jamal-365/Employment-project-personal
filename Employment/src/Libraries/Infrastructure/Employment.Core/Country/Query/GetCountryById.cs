using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;

namespace Employment.Core.Country.Query
{
    public record GetCountryById(int Id) : IRequest<VmCountry>;

    public class GetCountryByIdHandler : IRequestHandler<GetCountryById, VmCountry>
    {
        private readonly ICountryRepository _countryRepository;
        public GetCountryByIdHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<VmCountry> Handle(GetCountryById request, CancellationToken cancellationToken)
        {
            return await _countryRepository.GetById(request.Id);
        }


    }

}
