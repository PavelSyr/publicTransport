using PublicTransportSource.Models.RepositoryModels;

namespace PublicTransportSource.Repositories.Interfaces;
public interface IRouteScheduleRepository
{
    Task<RepositoryDto<Schedule>> GetRouteScheduleAsync(string routeNumber, bool forward);
}