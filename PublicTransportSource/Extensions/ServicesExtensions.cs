using PublicTransportSource.Clinets.Components;
using PublicTransportSource.Models.RepositoryModels;
using PublicTransportSource.Repositories;
using PublicTransportSource.Repositories.Interfaces;
using PublicTransportSource.Services;
using PublicTransportSource.Services.Interfaces;

namespace PublicTransportSource.Extensions;

public static class ServicesExtensions
{
    public static void RegisterTbilisiServices(this IServiceCollection services)
    {
        services.AddHttpClient<IRouteRepository, TbilisiRouteRepository>();
        services.AddHttpClient<ISchemeStopsRepository, TbilisiSchemeStopsRepository>();
        services.AddHttpClient<IRealtimeBusRepository, TbilisiRealtimeBusRepository>();
        services.AddHttpClient<IRouteScheduleRepository, TbilisiRouteScheduleRepository>();
        services.AddHttpClient<IArrivalTimeRepository, TbilisiArrivalTimeRepository>();

        services.AddScoped<IRouteRepository, TbilisiRouteRepository>();
        services.AddScoped<IRouteService, TbilisiRouteService>();

        services.AddScoped<ISchemeStopsRepository, TbilisiSchemeStopsRepository>();
        services.AddScoped<ISchemeStopsService, TbilisiSchemeStopsServices>();
        services.AddScoped<IXmlDeserializer<RouteStops>, DefaultXmlDeserilizer<RouteStops>>();

        services.AddScoped<IRealtimeBusRepository, TbilisiRealtimeBusRepository>();
        services.AddScoped<IRealtimeBusService, TbilisiRealtimeBusService>();
        services.AddScoped<IXmlDeserializer<BusList>, DefaultXmlDeserilizer<BusList>>();

        services.AddScoped<IRouteScheduleRepository, TbilisiRouteScheduleRepository>();
        services.AddScoped<IRouteScheduleService, TbilisiRouteScheduleService>();
        services.AddScoped<IXmlDeserializer<Schedule>, DefaultXmlDeserilizer<Schedule>>();

        services.AddScoped<IArrivalTimeRepository, TbilisiArrivalTimeRepository>();
        services.AddScoped<IArrivalTimeService, TbilisiArrivalTimeService>();
        services.AddScoped<IXmlDeserializer<ArrivalTimes>, DefaultXmlDeserilizer<ArrivalTimes>>();
    }
}