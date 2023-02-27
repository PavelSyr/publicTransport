using PublicTransportSource.Models.RepositoryModels;

namespace PublicTransportSource.Repositories.Interfaces;
public interface IRouteRepository
{
    Task<RepositoryDto<List<RouteInfo>>> GetRoutesAsync();
}