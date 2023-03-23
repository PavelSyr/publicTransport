namespace PublicTransportSource.Core.Models.ServiceModels;

public class StopScheduleModel
{
    public List<string> ArriveTimes { get; set; } = new();
    public bool Forward { get; set; }
    public bool HasBoard { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string? Name { get; set; }
    public int Sequence { get; set; }
    public string? StopId { get; set; }
    public string? Type { get; set; }
    public bool Virtual { get; set; }
}