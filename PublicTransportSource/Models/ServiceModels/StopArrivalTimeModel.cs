namespace PublicTransportSource.Models.ServiceModels;

public class StopArrivalTimeModel
{
    public string? StopId { get; set; }
    public List<ArrivalTimeModel> Times { get; set; } = new();
}