using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PublicTransportSource.Core.Extensions;
using PublicTransportSource.Core.Models.Dtos;
using PublicTransportSource.Core.Services.Interfaces;
using PublicTransportSource.Extensions;
using PublicTransportSource.Models.Dtos;

namespace PublicTransportSource.Controllers;

[ApiController]
[Route("[controller]")]
public class ArrivalTimeController : Controller
{
    private readonly IArrivalTimeService _arrivalTimeService;
    private readonly IMapper _mapper;
    private readonly ResponseDto<object> _response;

    public ArrivalTimeController(
        IArrivalTimeService arrivalTimeService,
        IMapper mapper)
    {
        _arrivalTimeService = arrivalTimeService;
        _mapper = mapper;
        _response = new ResponseDto<object>();
    }

    [HttpGet("stop/{stopId}")]
    public async Task<object> Get(string stopId)
    {
        try
        {
            var serviceDto = await _arrivalTimeService.GetArrivalTimeAsync(stopId);

            var arrivalTimeDto = _mapper.Map<StopArrivalTimeDto>(serviceDto.Data);

            _response.Data = arrivalTimeDto;
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