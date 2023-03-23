using System.Collections.Generic;
using AutoMapper;
using PublicTransportSource.Core.Clinets;
using PublicTransportSource.Core.Clinets.Components;
using PublicTransportSource.Core.Models;
using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.RepositoryModels;
using PublicTransportSource.Core.Repositories.Interfaces;
using PublicTransportSource.Tbilisi.Models;

namespace PublicTransportSource.Tbilisi.Repositories;

public class TbilisiArrivalTimeRepository : XmlBaseClient, IArrivalTimeRepository
{
    private readonly ApiConfig _apiConfig;
    private readonly IXmlDeserializer<TbilisiArrivalTimes> _xmlDeserializer;
    private readonly IMapper _mapper;

    private string BaseUrl => _apiConfig.BaseUrl;

    private static class Api
    {
        //https://transfer.msplus.ge:2443/otp/routers/ttc/stopArrivalTimes?stopId=1857
        public const string GET_STOP_ARRIVAL_TIMES = "/otp/routers/ttc/stopArrivalTimes?stopId={0}";
    }

    public TbilisiArrivalTimeRepository(
        HttpClient httpClient,
        ApiConfig apiConfig,
        IXmlDeserializer<TbilisiArrivalTimes> xmlDeserializer,
        IMapper mapper) : base(httpClient)
    {
        _apiConfig = apiConfig;
        _xmlDeserializer = xmlDeserializer;
        _mapper = mapper;
    }

    public async Task<RepositoryDto<IEnumerable<ArrivalTime>>> GetArrivalTimeAsync(string stopId)
    {
        var url = BaseUrl + string.Format(Api.GET_STOP_ARRIVAL_TIMES, stopId);
        var request = new ApiRequest(url);
        request.Headers.Add("Accept", "application/xml");

        var resp = await SendAsync<TbilisiArrivalTimes>(request, _xmlDeserializer);

        var times = _mapper.Map<IEnumerable<ArrivalTime>>(resp.Data?.Times);

        return new RepositoryDto<IEnumerable<ArrivalTime>>(){
            Data = times,
            IsSuccess = resp.IsSuccess,
            ErrorMessages = resp.ErrorMessages,
        };
    }
}