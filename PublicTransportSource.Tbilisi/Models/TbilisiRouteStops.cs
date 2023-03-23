using System.Xml.Serialization;

namespace PublicTransportSource.Tbilisi.Models.RepositoryModels;

[XmlRoot("RouteStops")]
public class TbilisiRouteStops
{
    [XmlElement("Stops")]
    public List<TbilisiStop> Stops { get; set; } = new();
}