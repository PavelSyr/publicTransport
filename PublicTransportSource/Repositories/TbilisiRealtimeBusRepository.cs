using PublicTransportSource.Clinets;
using PublicTransportSource.Clinets.Components;
using PublicTransportSource.Models;
using PublicTransportSource.Models.RepositoryModels;
using PublicTransportSource.Repositories.Interfaces;

namespace PublicTransportSource.Repositories;

public sealed class TbilisiRealtimeBusRepository : XmlBaseClient, IRealtimeBusRepository
{
    private static class Api
    {
        //https://transfer.msplus.ge:2443/otp/routers/ttc/buses?routeNumber=101&forward=1
        public const string GET_BUSES = "/otp/routers/ttc/buses?routeNumber={0}&forward={1}";
    }

    private string BaseUrl => _apiConfig.BaseUrl;

    private readonly ApiConfig _apiConfig;
    private readonly IXmlDeserializer<BusList> _xmlDeserializer;

    public TbilisiRealtimeBusRepository(
        HttpClient httpClient,
        ApiConfig apiConfig,
        IXmlDeserializer<BusList> xmlDeserializer) : base(httpClient)
    {
        _apiConfig = apiConfig;
        _xmlDeserializer = xmlDeserializer;
    }

    public async Task<RepositoryDto<List<Bus>>> GetBusesAsync(string routeNumber)
    {
        var repoDtoForward = await GetBusesAsync(routeNumber, isForward: true);
        var repoDtoBackward = await GetBusesAsync(routeNumber, isForward: false);

        var buses = new List<Bus>();
        if (repoDtoForward.IsSuccess && repoDtoForward.Data != null && repoDtoForward.Data.Buses != null)
        {
            buses.AddRange(repoDtoForward.Data.Buses);
        }

        if (repoDtoBackward.IsSuccess && repoDtoBackward.Data != null && repoDtoBackward.Data.Buses != null)
        {
            buses.AddRange(repoDtoBackward.Data.Buses);
        }

        var errorMessages = new List<string>();
        if (repoDtoForward.ErrorMessages != null && repoDtoForward.ErrorMessages.Any())
        {
            errorMessages.AddRange(repoDtoForward.ErrorMessages);
        }

        if (repoDtoBackward.ErrorMessages != null && repoDtoBackward.ErrorMessages.Any())
        {
            errorMessages.AddRange(repoDtoBackward.ErrorMessages);
        }

        return new RepositoryDto<List<Bus>>()
        {
            Data = buses,
            IsSuccess = repoDtoForward.IsSuccess || repoDtoBackward.IsSuccess,
            ErrorMessages = errorMessages.Any() ? errorMessages : null,
        };
    }

    private async Task<RepositoryDto<BusList>> GetBusesAsync(string routeNumber, bool isForward)
    {
        var url = BaseUrl + string.Format(Api.GET_BUSES, routeNumber, Convert.ToInt32(isForward));
        var request = new ApiRequest(url);
        request.Headers.Add("Accept", "application/xml");

        var resp = await SendAsync<BusList>(request, _xmlDeserializer);

        return new RepositoryDto<BusList>()
        {
            Data = resp.Data,
            IsSuccess = resp.IsSuccess,
            ErrorMessages = resp.ErrorMessages,
        };
    }
}