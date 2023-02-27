using PublicTransportSource.Clinets;
using PublicTransportSource.Models;
using PublicTransportSource.Models.RepositoryModels;
using PublicTransportSource.Repositories.Interfaces;

namespace PublicTransportSource.Repositories;

public sealed class TbilisiRouteRepository : JsonBaseClient, IRouteRepository
{
    private static class Api {
        public const string GET_ROUTES = "/otp/routers/ttc/index/routes";
    }

    private string BaseUrl => _apiConfig.BaseUrl;

    private readonly ApiConfig _apiConfig;

    public TbilisiRouteRepository(HttpClient httpClient, ApiConfig apiConfig) : base(httpClient)
    {
        _apiConfig = apiConfig;
    }

    public async Task<RepositoryDto<List<RouteInfo>>> GetRoutesAsync()
    {
        var url = BaseUrl + Api.GET_ROUTES;
        var request = new ApiRequest(url);
        request.Headers.Add("Accept", "application/json");

        var resp = await SendAsync<List<RouteInfo>>(request);

        return new RepositoryDto<List<RouteInfo>>(){
            Data = resp.Data,
            IsSuccess = resp.IsSuccess,
            ErrorMessages = resp.ErrorMessages,
        };
    }
}