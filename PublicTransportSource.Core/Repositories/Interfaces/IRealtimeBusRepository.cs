using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.RepositoryModels;

namespace PublicTransportSource.Core.Repositories.Interfaces;

public interface IRealtimeBusRepository
{
    Task<RepositoryDto<List<Bus>>> GetBusesAsync(string routeNumber);
}