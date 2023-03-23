using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.ServiceModels;

namespace PublicTransportSource.Core.Services.Interfaces;

public interface IArrivalTimeService
{
    Task<ServiceDto<StopArrivalTimeModel>> GetArrivalTimeAsync(string stopId);
}