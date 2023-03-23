namespace PublicTransportSource.Core.Models.Dtos;

public class ServiceDto<TData>
{
    public TData? Data { get; set; }
    public bool IsSuccess {get; set;} = true;
    public List<string>? ErrorMessages { get; set; }
}