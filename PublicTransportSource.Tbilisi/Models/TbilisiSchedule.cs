using System.Xml.Serialization;

namespace PublicTransportSource.Tbilisi.Models.RepositoryModels;

[XmlRoot("Schedule")]
public class TbilisiSchedule
{
    public string? DirectionDescription { get; set; }
    public bool Forward { get; set; }
    public string? RouteNumber { get; set; }
    public TbilisiWeekdaySchedules WeekdaySchedules { get; set; } = new();
}