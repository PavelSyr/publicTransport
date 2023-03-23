using AutoMapper;
using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.ServiceModels;
using PublicTransportSource.Core.Repositories.Interfaces;
using PublicTransportSource.Core.Services.Interfaces;

namespace PublicTransportSource.Tbilisi.Services;

public sealed class TbilisiRouteService : IRouteService
{
    private readonly IRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public TbilisiRouteService(
        IRouteRepository routeRepository,
        IMapper mapper)
    {
        _routeRepository = routeRepository;
        _mapper = mapper;
    }

    public async Task<ServiceDto<IEnumerable<RouteInfoModel>>> GetRoutesAsync()
    {
        var repoDto = await _routeRepository.GetRoutesAsync();

        var routeInfoModels = _mapper.Map<List<RouteInfoModel>>(repoDto.Data);

        return new ServiceDto<IEnumerable<RouteInfoModel>>(){
            Data = routeInfoModels,
            IsSuccess = repoDto.IsSuccess,
            ErrorMessages = repoDto.ErrorMessages,
        };
    }
}