namespace PublicTransportSource.Core.Models.RepositoryModels;

public class Schedule
{
    public string? DirectionDescription { get; set; }
    public bool Forward { get; set; }
    public string? RouteNumber { get; set; }
    public WeekdaySchedules WeekdaySchedules { get; set; } = new();
}