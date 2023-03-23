using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.ServiceModels;

namespace PublicTransportSource.Core.Services.Interfaces;

public interface IRealtimeBusService
{
    Task<ServiceDto<IEnumerable<BusModel>>> GetBusesAsync(string routeNumber);
}