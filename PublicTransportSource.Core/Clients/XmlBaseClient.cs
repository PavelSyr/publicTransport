using Newtonsoft.Json;
using PublicTransportSource.Core.Clinets.Components;
using PublicTransportSource.Core.Models.Dtos;

namespace PublicTransportSource.Core.Clinets;

public class XmlBaseClient : BaseClient
{
    public XmlBaseClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<ResponseDto<T>> SendAsync<T>(
        ApiRequest apiRequest,
        IXmlDeserializer<T> xmlDeserializer)
    {
        return await base.SendAsync<T>(apiRequest,
            d => JsonConvert.SerializeObject(d),
            r => xmlDeserializer.Deserialize(r));
    }
}