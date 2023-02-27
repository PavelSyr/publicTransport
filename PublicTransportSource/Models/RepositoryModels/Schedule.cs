using System.Xml.Serialization;

namespace PublicTransportSource.Models.RepositoryModels;

[XmlRoot("Schedule")]
public class Schedule
{
    public string? DirectionDescription { get; set; }
    public bool Forward { get; set; }
    public string? RouteNumber { get; set; }
    public WeekdaySchedules WeekdaySchedules { get; set; } = new();
}