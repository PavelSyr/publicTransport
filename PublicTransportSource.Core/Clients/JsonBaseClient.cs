using Newtonsoft.Json;
using PublicTransportSource.Core.Models.Dtos;

namespace PublicTransportSource.Core.Clinets;

public class JsonBaseClient : BaseClient
{
    public JsonBaseClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<ResponseDto<T>> SendAsync<T>(
        ApiRequest apiRequest
        )
    {
        return await base.SendAsync<T>(apiRequest,
            d => JsonConvert.SerializeObject(d),
            r => JsonConvert.DeserializeObject<T>(r));
    }
}