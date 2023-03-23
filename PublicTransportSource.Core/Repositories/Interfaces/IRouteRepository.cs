using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.RepositoryModels;

namespace PublicTransportSource.Core.Repositories.Interfaces;

public interface IRouteRepository
{
    Task<RepositoryDto<List<RouteInfo>>> GetRoutesAsync();
}