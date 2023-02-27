namespace PublicTransportSource.Models.ServiceModels;

public class StopModel
{
    public bool Forward { get; set; }
    public bool HasBoard { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string? Name { get; set; }
    public string? Routes { get; set; }
    public string? StopId { get; set; }
    public string? Type { get; set; }
    public bool Virtual { get; set; }
}