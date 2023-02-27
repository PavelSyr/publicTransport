namespace PublicTransportSource.Models.ServiceModels;

public class ArrivalTimeModel
{
    public int Time { get; set; }
    public string? DestinationStopName { get; set; }
    public string? RouteNumber { get; set; }
}