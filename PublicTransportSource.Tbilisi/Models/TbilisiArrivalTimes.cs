using System.Xml.Serialization;

namespace PublicTransportSource.Tbilisi.Models;

[XmlRoot("ArrivalTimes")]
public class TbilisiArrivalTimes
{
    [XmlElement("ArrivalTime")]
    public List<TbilisiArrivalTime> Times { get; set; } = new();
}