namespace PublicTransportSource.Models.Dtos;

public class StopArrivalTimeDto
{
    public string? StopId { get; set; }
    public List<ArrivalTimeDto> Times { get; set; } = new();
}