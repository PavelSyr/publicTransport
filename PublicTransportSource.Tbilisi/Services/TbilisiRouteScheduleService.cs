
using AutoMapper;
using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.ServiceModels;
using PublicTransportSource.Core.Repositories.Interfaces;
using PublicTransportSource.Core.Services.Interfaces;

namespace PublicTransportSource.Tbilisi.Services;

public class TbilisiRouteScheduleService : IRouteScheduleService
{
    private readonly IRouteScheduleRepository _routeScheduleRepository;
    private readonly IMapper _mapper;

    public TbilisiRouteScheduleService(
        IRouteScheduleRepository routeScheduleRepository,
        IMapper mapper)
    {
        _routeScheduleRepository = routeScheduleRepository;
        _mapper = mapper;
    }

    public async Task<ServiceDto<ScheduleModel>> GetStopsAsync(string routeNumber, bool forward)
    {
        var repoDto = await _routeScheduleRepository.GetRouteScheduleAsync(routeNumber, forward);

        var scheduleModel = _mapper.Map<ScheduleModel>(repoDto.Data);

        return new ServiceDto<ScheduleModel>(){
            Data = scheduleModel,
            IsSuccess = repoDto.IsSuccess,
            ErrorMessages = repoDto.ErrorMessages,
        };
    }
}