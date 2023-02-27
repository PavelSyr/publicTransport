using System.Xml.Serialization;

namespace PublicTransportSource.Models.RepositoryModels;

[XmlRoot("ArrivalTimes")]
public class ArrivalTimes
{
    [XmlElement("ArrivalTime")]
    public List<ArrivalTime> Times { get; set; } = new();
}