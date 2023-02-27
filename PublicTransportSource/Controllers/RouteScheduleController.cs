using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublicTransportSource.Extensions;
using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Services.Interfaces;

namespace PublicTransportSource.Controllers;

[ApiController]
[Route("[controller]")]
public class RouteScheduleController
{
    private readonly IRouteScheduleService _routeScheduleService;
    private readonly IMapper _mapper;
    private readonly ResponseDto<object> _response;


    public RouteScheduleController(
        IRouteScheduleService routeScheduleService,
        IMapper mapper)
    {
        _routeScheduleService = routeScheduleService;
        _mapper = mapper;
        _response = new ResponseDto<object>();
    }

    [HttpGet("route/{routeNumber}")]
    public async Task<object> Get(string routeNumber, bool forward = true)
    {
        try
        {
            var serviceDto = await _routeScheduleService.GetStopsAsync(routeNumber, forward);

            var scheduleDto = _mapper.Map<ScheduleDto>(serviceDto.Data);

            _response.Data = scheduleDto;
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