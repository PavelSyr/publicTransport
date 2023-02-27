using AutoMapper;
using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Models.ServiceModels;
using PublicTransportSource.Repositories.Interfaces;
using PublicTransportSource.Services.Interfaces;

namespace PublicTransportSource.Services;

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