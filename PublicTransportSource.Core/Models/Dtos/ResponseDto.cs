namespace PublicTransportSource.Core.Models.Dtos;

public class ResponseDto<T>
{
    public T? Data { get; set; }

    public bool IsSuccess {get; set;} = true;
    public string? DisplayMessage { get; set; }
    public List<string>? ErrorMessages { get; set; }
}