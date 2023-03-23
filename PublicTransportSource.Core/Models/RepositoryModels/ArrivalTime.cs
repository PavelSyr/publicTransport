namespace PublicTransportSource.Core.Models.RepositoryModels;

public class ArrivalTime
{
    public int Time { get; set; }
    public string? DestinationStopName { get; set; }
    public string? RouteNumber { get; set; }
}