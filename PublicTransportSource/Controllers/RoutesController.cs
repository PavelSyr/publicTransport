using Microsoft.AspNetCore.Mvc;
using PublicTransportSource.Services.Interfaces;
using PublicTransportSource.Models.Dtos;
using AutoMapper;
using PublicTransportSource.Extensions;

namespace PublicTransportSource.Controllers;

[ApiController]
[Route("[controller]")]
public class RoutesController : Controller
{
    private readonly IRouteService _routeService;
    private readonly IMapper _mapper;
    private readonly ResponseDto<object> _response;

    public RoutesController(
        IRouteService routeService,
        IMapper mapper)
    {
        _routeService = routeService;
        _mapper = mapper;
        _response = new ResponseDto<object>();
    }

    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            var serviceDto = await _routeService.GetRoutesAsync();

            var routeInfoDtos = _mapper.Map<List<RouteInfoDto>>(serviceDto.Data);

            _response.Data = routeInfoDtos;
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