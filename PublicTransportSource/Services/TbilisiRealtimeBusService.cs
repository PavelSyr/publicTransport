using AutoMapper;
using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Models.ServiceModels;
using PublicTransportSource.Repositories.Interfaces;
using PublicTransportSource.Services.Interfaces;

namespace PublicTransportSource.Services;

public class TbilisiRealtimeBusService : IRealtimeBusService
{
    private readonly IRealtimeBusRepository _realtimeBusRepository;
    private readonly IMapper _mapper;

    public TbilisiRealtimeBusService(
        IRealtimeBusRepository realtimeBusRepository,
        IMapper mapper)
    {
        _realtimeBusRepository = realtimeBusRepository;
        _mapper = mapper;
    }

    public async Task<ServiceDto<IEnumerable<BusModel>>> GetBusesAsync(string routeNumber)
    {
        var repoDto = await _realtimeBusRepository.GetBusesAsync(routeNumber);

        var busModels = _mapper.Map<List<BusModel>>(repoDto.Data);

        return new ServiceDto<IEnumerable<BusModel>>(){
            Data = busModels,
            IsSuccess = repoDto.IsSuccess,
            ErrorMessages = repoDto.ErrorMessages,
        };
    }
}