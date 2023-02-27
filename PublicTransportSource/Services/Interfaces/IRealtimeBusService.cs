using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Models.ServiceModels;

namespace PublicTransportSource.Services.Interfaces;

public interface IRealtimeBusService
{
    Task<ServiceDto<IEnumerable<BusModel>>> GetBusesAsync(string routeNumber);
}