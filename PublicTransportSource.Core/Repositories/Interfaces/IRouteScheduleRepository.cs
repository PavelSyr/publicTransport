using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.RepositoryModels;

namespace PublicTransportSource.Core.Repositories.Interfaces;

public interface IRouteScheduleRepository
{
    Task<RepositoryDto<Schedule>> GetRouteScheduleAsync(string routeNumber, bool forward);
}