namespace PublicTransportSource.Core.Models.RepositoryModels;

public class WeekdaySchedules
{
    public string? FromDay { get; set; }
    public string? ToDay { get; set; }

    public List<StopSchedule> Stops { get; set; } = new();
}