using PublicTransportSource.Clinets;
using PublicTransportSource.Clinets.Components;
using PublicTransportSource.Models;
using PublicTransportSource.Models.RepositoryModels;
using PublicTransportSource.Repositories.Interfaces;

public class TbilisiArrivalTimeRepository : XmlBaseClient, IArrivalTimeRepository
{
    private readonly ApiConfig _apiConfig;
    private readonly IXmlDeserializer<ArrivalTimes> _xmlDeserializer;

    private string BaseUrl => _apiConfig.BaseUrl;

    private static class Api
    {
        //https://transfer.msplus.ge:2443/otp/routers/ttc/stopArrivalTimes?stopId=1857
        public const string GET_STOP_ARRIVAL_TIMES = "/otp/routers/ttc/stopArrivalTimes?stopId={0}";
    }

    public TbilisiArrivalTimeRepository(
        HttpClient httpClient,
        ApiConfig apiConfig,
        IXmlDeserializer<ArrivalTimes> xmlDeserializer) : base(httpClient)
    {
        _apiConfig = apiConfig;
        _xmlDeserializer = xmlDeserializer;
    }

    public async Task<RepositoryDto<IEnumerable<ArrivalTime>>> GetArrivalTimeAsync(string stopId)
    {
        var url = BaseUrl + string.Format(Api.GET_STOP_ARRIVAL_TIMES, stopId);
        var request = new ApiRequest(url);
        request.Headers.Add("Accept", "application/xml");

        var resp = await SendAsync<ArrivalTimes>(request, _xmlDeserializer);

        return new RepositoryDto<IEnumerable<ArrivalTime>>(){
            Data = resp.Data?.Times,
            IsSuccess = resp.IsSuccess,
            ErrorMessages = resp.ErrorMessages,
        };
    }
}