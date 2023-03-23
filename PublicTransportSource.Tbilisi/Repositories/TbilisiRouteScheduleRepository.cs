using AutoMapper;
using PublicTransportSource.Core.Clinets;
using PublicTransportSource.Core.Clinets.Components;
using PublicTransportSource.Core.Models;
using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.RepositoryModels;
using PublicTransportSource.Core.Repositories.Interfaces;
using PublicTransportSource.Tbilisi.Models.RepositoryModels;

namespace PublicTransportSource.Tbilisi.Repositories;

public class TbilisiRouteScheduleRepository : XmlBaseClient, IRouteScheduleRepository
{
    private static class Api
    {
        //https://transfer.msplus.ge:2443/otp/routers/ttc/routeSchedule?routeNumber=101&forward=0&type=3
        public const string GET_ROUTE_SCHEDULE = "/otp/routers/ttc/routeSchedule?routeNumber={0}&forward={1}&type=3";
    }

    private readonly ApiConfig _apiConfig;
    private readonly IXmlDeserializer<TbilisiSchedule> _xmlDeserializer;
    private readonly IMapper _mapper;

    private string BaseUrl => _apiConfig.BaseUrl;

    public TbilisiRouteScheduleRepository(
        HttpClient httpClient,
        ApiConfig apiConfig,
        IXmlDeserializer<TbilisiSchedule> xmlDeserializer,
        IMapper mapper) : base(httpClient)
    {
        _apiConfig = apiConfig;
        _xmlDeserializer = xmlDeserializer;
        _mapper = mapper;
    }

    public async Task<RepositoryDto<Schedule>> GetRouteScheduleAsync(string routeNumber, bool isForward)
    {
        var url = BaseUrl + string.Format(Api.GET_ROUTE_SCHEDULE, routeNumber, Convert.ToInt32(isForward));
        var request = new ApiRequest(url);
        request.Headers.Add("Accept", "application/xml");

        var resp = await SendAsync<TbilisiSchedule>(request, _xmlDeserializer);

        var schedule = _mapper.Map<Schedule>(resp.Data);

        return new RepositoryDto<Schedule>()
        {
            Data = schedule,
            IsSuccess = resp.IsSuccess,
            ErrorMessages = resp.ErrorMessages,
        };
    }
}