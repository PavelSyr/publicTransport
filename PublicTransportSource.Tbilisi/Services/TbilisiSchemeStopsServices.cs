using AutoMapper;
using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.ServiceModels;
using PublicTransportSource.Core.Services.Interfaces;
using PublicTransportSource.Core.Repositories.Interfaces;

namespace PublicTransportSource.Tbilisi.Services;

public class TbilisiSchemeStopsServices : ISchemeStopsService
{
    private readonly ISchemeStopsRepository _stopsRepository;
    private readonly IMapper _mapper;

    public TbilisiSchemeStopsServices(
        ISchemeStopsRepository stopsRepository,
        IMapper mapper)
    {
        _stopsRepository = stopsRepository;
        _mapper = mapper;
    }

    public async Task<ServiceDto<IEnumerable<StopModel>>> GetStopsAsync(string route)
    {
        var repoDto = await _stopsRepository.GetStopsAsync(route);

        var stopModels = _mapper.Map<List<StopModel>>(repoDto.Data);

        return new ServiceDto<IEnumerable<StopModel>>(){
            Data = stopModels,
            IsSuccess = repoDto.IsSuccess,
            ErrorMessages = repoDto.ErrorMessages,
        };
    }
}