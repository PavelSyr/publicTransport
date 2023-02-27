using Newtonsoft.Json;
using PublicTransportSource.Extensions;
using PublicTransportSource.Models;
using PublicTransportSource.Models.Dtos;
using System.Net.Http.Headers;
using System.Text;

namespace PublicTransportSource.Clinets;

public delegate T? ResponseDeserializer<T>(string response);

public class BaseClient
{
    protected readonly HttpClient _httpClient;

    public BaseClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseDto<T>> SendAsync<T>(
        ApiRequest apiRequest,
        ResponseDeserializer<T> deserializer)
    {
        var resp = new ResponseDto<T>();
        try
        {
            HttpRequestMessage message = new HttpRequestMessage();

            foreach(var kvp in apiRequest.Headers)
            {
                message.Headers.Add(kvp.Key, kvp.Value);
            }

            message.RequestUri = new Uri(apiRequest.Url);
            _httpClient.DefaultRequestHeaders.Clear();
            if (apiRequest.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                    Encoding.UTF8, "application/json");
            }

            if (!string.IsNullOrEmpty(apiRequest.AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
            }

            HttpResponseMessage apiResponse;
            switch (apiRequest.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }
            apiResponse = await _httpClient.SendAsync(message);

            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            
            resp.Data = deserializer.Invoke(apiContent);
        }
        catch (Exception ex)
        {
            resp.DisplayMessage = "Error";
            resp.ErrorMessages = ex.GetAllErrors();
            resp.IsSuccess = false;
        }

        return resp;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }
}