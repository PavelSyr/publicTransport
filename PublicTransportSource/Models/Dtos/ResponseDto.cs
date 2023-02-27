namespace PublicTransportSource.Models.Dtos;
public class ResponseDto<T>
{
    public T? Data { get; set; }

    public bool IsSuccess {get; set;} = true;
    public string? DisplayMessage { get; internal set; }
    public List<string>? ErrorMessages { get; internal set; }
}