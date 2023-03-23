using System.Xml.Serialization;
using AutoMapper;
using PublicTransportSource.Core.Clinets;
using PublicTransportSource.Core.Clinets.Components;
using PublicTransportSource.Core.Models;
using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.RepositoryModels;
using PublicTransportSource.Core.Repositories.Interfaces;
using PublicTransportSource.Tbilisi.Models.RepositoryModels;

namespace PublicTransportSource.Tbilisi.Repositories;

public class TbilisiSchemeStopsRepository : XmlBaseClient, ISchemeStopsRepository
{
    private static class Api {
        //https://transfer.msplus.ge:2443/otp/routers/ttc/schemeStops?routeNumber=476&backward=1
        public const string GET_ROUTE_STOPS = "/otp/routers/ttc/schemeStops?routeNumber={0}";
    }

    private string BaseUrl => _apiConfig.BaseUrl;

    private readonly ApiConfig _apiConfig;
    private readonly IXmlDeserializer<TbilisiRouteStops> _xmlDeserializer;
    private readonly IMapper _mapper;

    public TbilisiSchemeStopsRepository(
        HttpClient httpClient,
        ApiConfig apiConfig,
        IXmlDeserializer<TbilisiRouteStops> xmlDeserializer,
        IMapper mapper) : base(httpClient)
    {
        _apiConfig = apiConfig;
        _xmlDeserializer = xmlDeserializer;
        _mapper = mapper;
    }

    public async Task<RepositoryDto<List<Stop>>> GetStopsAsync(string route)
    {
        var url = BaseUrl + string.Format(Api.GET_ROUTE_STOPS, route);
        var request = new ApiRequest(url);
        request.Headers.Add("Accept", "application/xml");

        var resp = await SendAsync<TbilisiRouteStops>(request, _xmlDeserializer);

        var stops = _mapper.Map<List<Stop>>(resp.Data?.Stops);

        return new RepositoryDto<List<Stop>>(){
            Data = stops,
            IsSuccess = resp.IsSuccess,
            ErrorMessages = resp.ErrorMessages,
        };
    }
}