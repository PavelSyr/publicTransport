using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Models.ServiceModels;

namespace PublicTransportSource.Services.Interfaces;

public interface ISchemeStopsService
{
    Task<ServiceDto<IEnumerable<StopModel>>> GetStopsAsync(string route);
}
