using System.Xml.Serialization;
using PublicTransportSource.Clinets;
using PublicTransportSource.Clinets.Components;
using PublicTransportSource.Models;
using PublicTransportSource.Models.RepositoryModels;
using PublicTransportSource.Repositories.Interfaces;

namespace PublicTransportSource.Repositories;

public class TbilisiSchemeStopsRepository : XmlBaseClient, ISchemeStopsRepository
{
    private static class Api {
        //https://transfer.msplus.ge:2443/otp/routers/ttc/schemeStops?routeNumber=476&backward=1
        public const string GET_ROUTE_STOPS = "/otp/routers/ttc/schemeStops?routeNumber={0}";
    }

    private string BaseUrl => _apiConfig.BaseUrl;

    private readonly ApiConfig _apiConfig;
    private readonly IXmlDeserializer<RouteStops> _xmlDeserializer;

    public TbilisiSchemeStopsRepository(
        HttpClient httpClient,
        ApiConfig apiConfig,
        IXmlDeserializer<RouteStops> xmlDeserializer) : base(httpClient)
    {
        _apiConfig = apiConfig;
        _xmlDeserializer = xmlDeserializer;
    }

    public async Task<RepositoryDto<List<Stop>>> GetStopsAsync(string route)
    {
        var url = BaseUrl + string.Format(Api.GET_ROUTE_STOPS, route);
        var request = new ApiRequest(url);
        request.Headers.Add("Accept", "application/xml");

        var resp = await SendAsync<RouteStops>(request, _xmlDeserializer);

        return new RepositoryDto<List<Stop>>(){
            Data = resp.Data?.Stops,
            IsSuccess = resp.IsSuccess,
            ErrorMessages = resp.ErrorMessages,
        };
    }
}