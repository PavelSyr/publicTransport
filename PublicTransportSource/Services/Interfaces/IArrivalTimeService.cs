using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Models.ServiceModels;

namespace PublicTransportSource.Services.Interfaces;

public interface IArrivalTimeService
{
    Task<ServiceDto<StopArrivalTimeModel>> GetArrivalTimeAsync(string stopId);
}