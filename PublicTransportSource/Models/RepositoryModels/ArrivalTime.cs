using System.Xml.Serialization;

namespace PublicTransportSource.Models.RepositoryModels;

public class ArrivalTime
{
    [XmlElement("ArrivalTime")]
    public int Time { get; set; }
    public string? DestinationStopName { get; set; }
    public string? RouteNumber { get; set; }
}