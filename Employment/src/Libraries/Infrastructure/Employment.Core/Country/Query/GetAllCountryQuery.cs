using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Services.Model;
using MediatR;


namespace Employment.Core.Country.Query
{

    public record GetAllCountryQuery() : IRequest<IEnumerable<VmCountry>>;

    public class GetAllCountryQueryHandler :
        IRequestHandler<GetAllCountryQuery, IEnumerable<VmCountry>>
    {
        private readonly ICountryRepository _CountryRepository;
        public GetAllCountryQueryHandler(ICountryRepository CountryRepository, IMapper mapper)
        {
            _CountryRepository = CountryRepository;
        }
        public async Task<IEnumerable<VmCountry>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
        {
            var result = await _CountryRepository.GetList();
            return result;
        }
    }
}
