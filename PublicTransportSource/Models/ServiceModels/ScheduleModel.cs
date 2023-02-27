namespace PublicTransportSource.Models.ServiceModels;

public class ScheduleModel
{
    public string? DirectionDescription { get; set; }
    public bool Forward { get; set; }
    public string? RouteNumber { get; set; }
    public List<StopScheduleModel> Stops { get; set; } = new();
}