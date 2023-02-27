//https://transfer.msplus.ge:2443/otp/routers/ttc/schemeStops?routeNumber=476&backward=1

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublicTransportSource.Extensions;
using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Services.Interfaces;

namespace PublicTransportSource.Controllers;

[ApiController]
[Route("[controller]")]
public class SchemeStopsController : Controller
{
    private ISchemeStopsService _schemeService;
    private IMapper _mapper;
    private ResponseDto<object> _response;

    public SchemeStopsController(
        ISchemeStopsService schemeService,
        IMapper mapper)
    {
        _schemeService = schemeService;
        _mapper = mapper;
        _response = new ResponseDto<object>();
    }

    [HttpGet("route/{routeNumber}")]
    public async Task<object> Get(string routeNumber)
    {
        try
        {
            var serviceDto = await _schemeService.GetStopsAsync(routeNumber);

            var routeStopDtos = _mapper.Map<List<StopDto>>(serviceDto.Data);

            _response.Data = routeStopDtos;
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