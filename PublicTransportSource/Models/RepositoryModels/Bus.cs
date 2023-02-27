using System.Xml.Serialization;

namespace PublicTransportSource.Models.RepositoryModels;

public class Bus
{
    [XmlElement("forward")]
    public bool Forward { get; set; }
    [XmlElement("lat")]
    public double Lat { get; set; }
    [XmlElement("lon")]
    public double Lon { get; set; }
    [XmlElement("nextStopId")]
    public string? NextStopId { get; set; }
    [XmlElement("routeNumber")]
    public string? RouteNumber { get; set; }
}