using System.Xml.Serialization;

namespace PublicTransportSource.Models.RepositoryModels;

[XmlRoot("RouteStops")]
public class RouteStops
{
    [XmlElement("Stops")]
    public List<Stop> Stops { get; set; } = new();
}