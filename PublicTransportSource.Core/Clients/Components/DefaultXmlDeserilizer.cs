using System.Xml.Serialization;

namespace PublicTransportSource.Core.Clinets.Components;

public class DefaultXmlDeserilizer<T> : IXmlDeserializer<T>
{
    public T? Deserialize(string raw)
    {
        var deserializer = new XmlSerializer(typeof(T));
        using var memoryReader = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(raw));

        var obj = deserializer.Deserialize(memoryReader);

        if (obj != null)
        {
            return (T)obj;
        }

        return default;
    }
}