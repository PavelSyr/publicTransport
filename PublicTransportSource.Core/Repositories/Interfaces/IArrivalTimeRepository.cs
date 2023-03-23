using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.RepositoryModels;

namespace PublicTransportSource.Core.Repositories.Interfaces;

public interface IArrivalTimeRepository
{
    Task<RepositoryDto<IEnumerable<ArrivalTime>>> GetArrivalTimeAsync(string stopId);
}