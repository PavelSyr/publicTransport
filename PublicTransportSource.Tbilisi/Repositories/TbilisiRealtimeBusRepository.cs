using AutoMapper;
using PublicTransportSource.Core.Clinets;
using PublicTransportSource.Core.Clinets.Components;
using PublicTransportSource.Core.Models;
using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Models.RepositoryModels;
using PublicTransportSource.Core.Repositories.Interfaces;
using PublicTransportSource.Tbilisi.Models.RepositoryModels;

namespace PublicTransportSource.Tbilisi.Repositories;

public sealed class TbilisiRealtimeBusRepository : XmlBaseClient, IRealtimeBusRepository
{
    private static class Api
    {
        //https://transfer.msplus.ge:2443/otp/routers/ttc/buses?routeNumber=101&forward=1
        public const string GET_BUSES = "/otp/routers/ttc/buses?routeNumber={0}&forward={1}";
    }

    private string BaseUrl => _apiConfig.BaseUrl;

    private readonly ApiConfig _apiConfig;
    private readonly IXmlDeserializer<TbilisiBusList> _xmlDeserializer;
    private readonly IMapper _mapper;

    public TbilisiRealtimeBusRepository(
        HttpClient httpClient,
        ApiConfig apiConfig,
        IXmlDeserializer<TbilisiBusList> xmlDeserializer,
        IMapper mapper) : base(httpClient)
    {
        _apiConfig = apiConfig;
        _xmlDeserializer = xmlDeserializer;
        _mapper = mapper;
    }

    public async Task<RepositoryDto<List<Bus>>> GetBusesAsync(string routeNumber)
    {
        var repoDtoForward = await GetBusesAsync(routeNumber, isForward: true);
        var repoDtoBackward = await GetBusesAsync(routeNumber, isForward: false);

        var buses = new List<Bus>();
        if (repoDtoForward.IsSuccess && repoDtoForward.Data != null && repoDtoForward.Data.Buses != null)
        {
            var busList = _mapper.Map<IEnumerable<Bus>>(repoDtoForward.Data.Buses);
            buses.AddRange(busList);
        }

        if (repoDtoBackward.IsSuccess && repoDtoBackward.Data != null && repoDtoBackward.Data.Buses != null)
        {
            var busList = _mapper.Map<IEnumerable<Bus>>(repoDtoBackward.Data.Buses);
            buses.AddRange(busList);
        }

        var errorMessages = new List<string>();
        if (repoDtoForward.ErrorMessages != null && repoDtoForward.ErrorMessages.Any())
        {
            errorMessages.AddRange(repoDtoForward.ErrorMessages);
        }

        if (repoDtoBackward.ErrorMessages != null && repoDtoBackward.ErrorMessages.Any())
        {
            errorMessages.AddRange(repoDtoBackward.ErrorMessages);
        }

        return new RepositoryDto<List<Bus>>()
        {
            Data = buses,
            IsSuccess = repoDtoForward.IsSuccess || repoDtoBackward.IsSuccess,
            ErrorMessages = errorMessages.Any() ? errorMessages : null,
        };
    }

    private async Task<RepositoryDto<TbilisiBusList>> GetBusesAsync(string routeNumber, bool isForward)
    {
        var url = BaseUrl + string.Format(Api.GET_BUSES, routeNumber, Convert.ToInt32(isForward));
        var request = new ApiRequest(url);
        request.Headers.Add("Accept", "application/xml");

        var resp = await SendAsync<TbilisiBusList>(request, _xmlDeserializer);

        return new RepositoryDto<TbilisiBusList>()
        {
            Data = resp.Data,
            IsSuccess = resp.IsSuccess,
            ErrorMessages = resp.ErrorMessages,
        };
    }
}