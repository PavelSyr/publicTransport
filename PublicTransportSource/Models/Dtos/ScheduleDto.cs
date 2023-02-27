namespace PublicTransportSource.Models.Dtos;

public class ScheduleDto
{
    public string? DirectionDescription { get; set; }
    public bool Forward { get; set; }
    public string? RouteNumber { get; set; }
    public List<StopScheduleDto> Stops { get; set; } = new();
}