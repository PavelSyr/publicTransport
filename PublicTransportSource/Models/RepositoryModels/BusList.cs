using System.Xml.Serialization;

namespace PublicTransportSource.Models.RepositoryModels;

[XmlRoot("busList")]
public class BusList
{
    [XmlElement("bus")]
    public List<Bus> Buses { get; set; } = new();
}