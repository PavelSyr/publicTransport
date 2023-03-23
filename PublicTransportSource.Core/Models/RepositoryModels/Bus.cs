namespace PublicTransportSource.Core.Models.RepositoryModels;

public class Bus
{
    public bool Forward { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string? NextStopId { get; set; }
    public string? RouteNumber { get; set; }
}