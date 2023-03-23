using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.ServiceModels;

namespace PublicTransportSource.Core.Services.Interfaces;

public interface ISchemeStopsService
{
    Task<ServiceDto<IEnumerable<StopModel>>> GetStopsAsync(string route);
}
