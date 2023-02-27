using PublicTransportSource.Clinets;
using PublicTransportSource.Clinets.Components;
using PublicTransportSource.Models;
using PublicTransportSource.Models.RepositoryModels;
using PublicTransportSource.Repositories.Interfaces;

namespace PublicTransportSource.Repositories;

public class TbilisiRouteScheduleRepository : XmlBaseClient, IRouteScheduleRepository
{
    private static class Api
    {
        //https://transfer.msplus.ge:2443/otp/routers/ttc/routeSchedule?routeNumber=101&forward=0&type=3
        public const string GET_ROUTE_SCHEDULE = "/otp/routers/ttc/routeSchedule?routeNumber={0}&forward={1}&type=3";
    }

    private readonly ApiConfig _apiConfig;
    private readonly IXmlDeserializer<Schedule> _xmlDeserializer;

    private string BaseUrl => _apiConfig.BaseUrl;

    public TbilisiRouteScheduleRepository(
        HttpClient httpClient,
        ApiConfig apiConfig,
        IXmlDeserializer<Schedule> xmlDeserializer) : base(httpClient)
    {
        _apiConfig = apiConfig;
        _xmlDeserializer = xmlDeserializer;
    }

    public async Task<RepositoryDto<Schedule>> GetRouteScheduleAsync(string routeNumber, bool isForward)
    {
        var url = BaseUrl + string.Format(Api.GET_ROUTE_SCHEDULE, routeNumber, Convert.ToInt32(isForward));
        var request = new ApiRequest(url);
        request.Headers.Add("Accept", "application/xml");

        var resp = await SendAsync<Schedule>(request, _xmlDeserializer);

        return new RepositoryDto<Schedule>()
        {
            Data = resp.Data,
            IsSuccess = resp.IsSuccess,
            ErrorMessages = resp.ErrorMessages,
        };
    }
}