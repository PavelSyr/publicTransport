using AutoMapper;
using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.ServiceModels;
using PublicTransportSource.Core.Repositories.Interfaces;
using PublicTransportSource.Core.Services.Interfaces;

namespace PublicTransportSource.Tbilisi.Services;

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