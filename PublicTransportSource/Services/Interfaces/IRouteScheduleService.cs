using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Models.ServiceModels;

namespace PublicTransportSource.Services.Interfaces;

public interface IRouteScheduleService
{
    Task<ServiceDto<ScheduleModel>> GetStopsAsync(string routeNumver, bool forward);
}