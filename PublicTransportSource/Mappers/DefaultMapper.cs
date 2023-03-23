using AutoMapper;
using PublicTransportSource.Core.Mappers;
using PublicTransportSource.Core.Models.ServiceModels;
using PublicTransportSource.Models.Dtos;
using PublicTransportSource.Tbilisi.Mappers;

namespace PublicTransportSource.Mappers;
public static class DefaultMapper {
    public static MapperConfiguration Create()
    {
        var config = new MapperConfiguration(cfg => 
        {
            cfg
                .CreateTbilisiMap()
                .CreateCoreMap()
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
        cfg.CreateMap<RouteInfoModel, RouteInfoDto>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForStops(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<StopModel, StopDto>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForRealtimeBus(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<BusModel, BusDto>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForScheduler(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<ScheduleModel, ScheduleDto>();

        cfg.CreateMap<StopScheduleModel, StopScheduleDto>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForArrivalTime(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<ArrivalTimeModel, ArrivalTimeDto>();

        cfg.CreateMap<StopArrivalTimeModel, StopArrivalTimeDto>();


        return cfg;
    }
}