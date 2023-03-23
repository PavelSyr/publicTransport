using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.ServiceModels;

namespace PublicTransportSource.Core.Services.Interfaces;

public interface IRouteService
{
    Task<ServiceDto<IEnumerable<RouteInfoModel>>> GetRoutesAsync();
}