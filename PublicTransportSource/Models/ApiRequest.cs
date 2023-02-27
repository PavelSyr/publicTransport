using PublicTransportSource.Models;
public class ApiRequest
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string Url { get; set; }
    public object? Data { get; set; }
    public string? AccessToken { get; set; }
    public Dictionary<string, string> Headers = new ();

    public ApiRequest(string url)
    {
        Url = url;
    }
}