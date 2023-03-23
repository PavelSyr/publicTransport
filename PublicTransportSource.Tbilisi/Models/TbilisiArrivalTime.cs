using System.Xml.Serialization;

namespace PublicTransportSource.Tbilisi.Models;

public class TbilisiArrivalTime
{
    [XmlElement("ArrivalTime")]
    public int Time { get; set; }
    public string? DestinationStopName { get; set; }
    public string? RouteNumber { get; set; }
}