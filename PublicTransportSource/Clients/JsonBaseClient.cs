using Newtonsoft.Json;
using PublicTransportSource.Models.Dtos;

namespace PublicTransportSource.Clinets;

public class JsonBaseClient : BaseClient
{
    public JsonBaseClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<ResponseDto<T>> SendAsync<T>(
        ApiRequest apiRequest)
    {
        return await base.SendAsync<T>(apiRequest, r => JsonConvert.DeserializeObject<T>(r));
    }
}