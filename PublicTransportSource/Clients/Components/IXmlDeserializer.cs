namespace PublicTransportSource.Clinets.Components;

public interface IXmlDeserializer<T>
{
    T? Deserialize(string raw);
}
