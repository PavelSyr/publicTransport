using AutoMapper;
using PublicTransportSource.Core.Clinets;
using PublicTransportSource.Core.Models;
using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.RepositoryModels;
using PublicTransportSource.Core.Repositories.Interfaces;
using PublicTransportSource.Tbilisi.Models.RepositoryModels;

namespace PublicTransportSource.Tbilisi.Repositories;

public sealed class TbilisiRouteRepository : JsonBaseClient, IRouteRepository
{
    private static class Api {
        public const string GET_ROUTES = "/otp/routers/ttc/index/routes";
    }

    private string BaseUrl => _apiConfig.BaseUrl;

    private readonly ApiConfig _apiConfig;
    private readonly IMapper _mapper;

    public TbilisiRouteRepository(
        HttpClient httpClient,
        ApiConfig apiConfig,
        IMapper mapper) : base(httpClient)
    {
        _apiConfig = apiConfig;
        _mapper = mapper;
    }

    public async Task<RepositoryDto<List<RouteInfo>>> GetRoutesAsync()
    {
        var url = BaseUrl + Api.GET_ROUTES;
        var request = new ApiRequest(url);
        request.Headers.Add("Accept", "application/json");

        var resp = await SendAsync<List<TbilisRouteInfo>>(request);

        var routes = _mapper.Map<List<RouteInfo>>(resp.Data);

        return new RepositoryDto<List<RouteInfo>>(){
            Data = routes,
            IsSuccess = resp.IsSuccess,
            ErrorMessages = resp.ErrorMessages,
        };
    }
}