using PublicTransportSource.Models.RepositoryModels;

namespace PublicTransportSource.Repositories.Interfaces;
public interface ISchemeStopsRepository
{
    Task<RepositoryDto<List<Stop>>> GetStopsAsync(string route);
}