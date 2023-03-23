using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.ServiceModels;

namespace PublicTransportSource.Core.Services.Interfaces;

public interface IRouteScheduleService
{
    Task<ServiceDto<ScheduleModel>> GetStopsAsync(string routeNumver, bool forward);
}