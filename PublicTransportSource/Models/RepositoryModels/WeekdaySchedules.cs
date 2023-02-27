using System.Xml.Serialization;

namespace PublicTransportSource.Models.RepositoryModels;

public class WeekdaySchedules
{
    public string? FromDay { get; set; }
    public string? ToDay { get; set; }

    [XmlElement("Stops")]
    public List<StopSchedule> Stops { get; set; } = new();
}