using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.RepositoryModels;

namespace PublicTransportSource.Core.Repositories.Interfaces;

public interface ISchemeStopsRepository
{
    Task<RepositoryDto<List<Stop>>> GetStopsAsync(string route);
}