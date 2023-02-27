using AutoMapper;
using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Models.RepositoryModels;
using PublicTransportSource.Models.ServiceModels;

namespace PublicTransportSource.Mappers;
public static class DefaultMapper {
    public static MapperConfiguration Create()
    {
        var config = new MapperConfiguration(cfg => 
        {
            cfg
                .CreateMapFroRoute()
                .CreateMapForStops()
                .CreateMapForRealtimeBus()
                .CreateMapForScheduler()
                .CreateMapForArrivalTime();
        });

        return config;
    }

    private static IMapperConfigurationExpression CreateMapFroRoute(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<RouteInfo, RouteInfoModel>();

        cfg.CreateMap<RouteInfoModel, RouteInfoDto>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForStops(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<Stop, StopModel>();

        cfg.CreateMap<StopModel, StopDto>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForRealtimeBus(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<Bus, BusModel>();

        cfg.CreateMap<BusModel, BusDto>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForScheduler(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<Schedule, ScheduleModel>()
            .ForMember(dest => dest.Stops, opt => opt.MapFrom(src => src.WeekdaySchedules.Stops));

        cfg.CreateMap<StopSchedule, StopScheduleModel>()
            .ForMember(
                dest => dest.ArriveTimes, 
                opt => opt.MapFrom(
                    src => src.ArriveTimes.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()));

        cfg.CreateMap<ScheduleModel, ScheduleDto>();

        cfg.CreateMap<StopScheduleModel, StopScheduleDto>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForArrivalTime(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<ArrivalTime, ArrivalTimeModel>();

        cfg.CreateMap<ArrivalTimeModel, ArrivalTimeDto>();

        cfg.CreateMap<StopArrivalTimeModel, StopArrivalTimeDto>();


        return cfg;
    }
}