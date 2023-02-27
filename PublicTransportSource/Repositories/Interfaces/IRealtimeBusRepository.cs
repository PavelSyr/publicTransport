using PublicTransportSource.Models.RepositoryModels;

namespace PublicTransportSource.Repositories.Interfaces;

public interface IRealtimeBusRepository
{
    Task<RepositoryDto<List<Bus>>> GetBusesAsync(string routeNumber);
}