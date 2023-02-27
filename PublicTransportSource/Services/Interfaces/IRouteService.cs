using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Models.ServiceModels;

namespace PublicTransportSource.Services.Interfaces;
public interface IRouteService
{
    Task<ServiceDto<IEnumerable<RouteInfoModel>>> GetRoutesAsync();
}