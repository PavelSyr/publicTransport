using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublicTransportSource.Extensions;
using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Services.Interfaces;

namespace PublicTransportSource.Controllers;

[ApiController]
[Route("[controller]")]
public class RealtimeController : Controller
{
    private readonly IRealtimeBusService _realtimeBusService;
    private readonly IMapper _mapper;
    private readonly ResponseDto<object> _response;

    public RealtimeController(
        IRealtimeBusService realtimeBusService,
        IMapper mapper
        )
    {
        _realtimeBusService = realtimeBusService;
        _mapper = mapper;
        _response = new ResponseDto<object>();
    }

    [HttpGet("route/{routeNumber}")]
    public async Task<object> GetBuses(string routeNumber)
    {
        try
        {
            var serviceDto = await _realtimeBusService.GetBusesAsync(routeNumber);

            var busDtos = _mapper.Map<List<BusDto>>(serviceDto.Data);

            _response.Data = busDtos;
            _response.IsSuccess = serviceDto.IsSuccess;
            _response.ErrorMessages = serviceDto.ErrorMessages;
        }
        catch (System.Exception ex)
        {
            _response.IsSuccess = false;

            _response.DisplayMessage = "Error";

            _response.ErrorMessages = ex.GetAllErrors();
        }

        return TypedResults.Ok(_response);
    }
}