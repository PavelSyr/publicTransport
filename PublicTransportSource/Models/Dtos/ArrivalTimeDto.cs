namespace PublicTransportSource.Models.Dtos;

public class ArrivalTimeDto
{
    public int Time { get; set; }
    public string? DestinationStopName { get; set; }
    public string? RouteNumber { get; set; }
}