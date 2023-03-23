using System;
using AutoMapper;
using PublicTransportSource.Core.Models.RepositoryModels;
using PublicTransportSource.Core.Models.ServiceModels;
using PublicTransportSource.Tbilisi.Models;
using PublicTransportSource.Tbilisi.Models.RepositoryModels;

namespace PublicTransportSource.Tbilisi.Mappers;

public static class TbilisiMapper
{
    public static IMapperConfigurationExpression CreateTbilisiMap(this IMapperConfigurationExpression cfg)
    {
        cfg
            .CreateMapFroRoute()
            .CreateMapForStops()
            .CreateMapForRealtimeBus()
            .CreateMapForScheduler()
            .CreateMapForArrivalTime();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapFroRoute(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<TbilisRouteInfo, RouteInfo>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForStops(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<TbilisiStop, Stop>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForRealtimeBus(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<TbilisiBus, Bus>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForScheduler(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<TbilisiSchedule, Schedule>();
        cfg.CreateMap<TbilisiWeekdaySchedules, WeekdaySchedules>();
        cfg.CreateMap<TbilisiStopSchedule, StopSchedule>();

        return cfg;
    }

    private static IMapperConfigurationExpression CreateMapForArrivalTime(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<TbilisiArrivalTime, ArrivalTime>();
        cfg.CreateMap<TbilisiArrivalTimes, ArrivalTimes>();

        return cfg;
    }
}

