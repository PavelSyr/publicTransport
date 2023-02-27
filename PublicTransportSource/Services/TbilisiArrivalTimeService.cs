using AutoMapper;
using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Models.ServiceModels;
using PublicTransportSource.Repositories.Interfaces;
using PublicTransportSource.Services.Interfaces;

namespace PublicTransportSource.Services;

public class TbilisiArrivalTimeService : IArrivalTimeService
{
    private readonly IArrivalTimeRepository _arrivalTimeRepository;
    private readonly IMapper _mapper;

    public TbilisiArrivalTimeService(
        IArrivalTimeRepository arrivalTimeRepository,
        IMapper mapper)
    {
        _arrivalTimeRepository = arrivalTimeRepository;
        _mapper = mapper;
    }

    public async Task<ServiceDto<StopArrivalTimeModel>> GetArrivalTimeAsync(string stopId)
    {
        var repoDto = await _arrivalTimeRepository.GetArrivalTimeAsync(stopId);

        var arrivalTimeModels = _mapper.Map<List<ArrivalTimeModel>>(repoDto.Data);

        var stopArrivalTimeModel = new StopArrivalTimeModel()
        {
            StopId = stopId,
            Times = arrivalTimeModels,
        };

        return new ServiceDto<StopArrivalTimeModel>(){
            Data = stopArrivalTimeModel,
            IsSuccess = repoDto.IsSuccess,
            ErrorMessages = repoDto.ErrorMessages,
        };
    }
}