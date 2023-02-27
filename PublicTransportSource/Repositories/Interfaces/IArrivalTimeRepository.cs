using PublicTransportSource.Models.RepositoryModels;

namespace PublicTransportSource.Repositories.Interfaces;

public interface IArrivalTimeRepository
{
    Task<RepositoryDto<IEnumerable<ArrivalTime>>> GetArrivalTimeAsync(string stopId);
}