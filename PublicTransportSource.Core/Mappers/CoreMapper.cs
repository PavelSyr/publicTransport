
using System;
using AutoMapper;
using PublicTransportSource.Core.Models.RepositoryModels;
using PublicTransportSource.Core.Models.ServiceModels;

namespace PublicTransportSource.Core.Mappers
{
	public static class CoreMapper
	{
        public static IMapperConfigurationExpression CreateCoreMap(this IMapperConfigurationExpression cfg)
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
            cfg.CreateMap<RouteInfo, RouteInfoModel>();

            return cfg;
        }

        private static IMapperConfigurationExpression CreateMapForStops(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Stop, StopModel>();

            return cfg;
        }

        private static IMapperConfigurationExpression CreateMapForRealtimeBus(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Bus, BusModel>();

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

            return cfg;
        }

        private static IMapperConfigurationExpression CreateMapForArrivalTime(this IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ArrivalTime, ArrivalTimeModel>();

            return cfg;
        }
    }
}

