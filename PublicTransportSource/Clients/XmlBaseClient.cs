using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using PublicTransportSource.Clinets.Components;
using PublicTransportSource.Models.Dtos;

namespace PublicTransportSource.Clinets;

public class XmlBaseClient : BaseClient
{
    public XmlBaseClient(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<ResponseDto<T>> SendAsync<T>(
        ApiRequest apiRequest,
        IXmlDeserializer<T> xmlDeserializer)
    {
        return await base.SendAsync<T>(apiRequest, r => xmlDeserializer.Deserialize(r));
    }
}