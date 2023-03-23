using System.Xml.Serialization;

namespace PublicTransportSource.Tbilisi.Models.RepositoryModels;

public class TbilisiWeekdaySchedules
{
    public string? FromDay { get; set; }
    public string? ToDay { get; set; }

    [XmlElement("Stops")]
    public List<TbilisiStopSchedule> Stops { get; set; } = new();
}