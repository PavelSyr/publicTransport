using PublicTransportSource.Core.Clinets.Components;
using PublicTransportSource.Core.Repositories.Interfaces;
using PublicTransportSource.Core.Services.Interfaces;
using PublicTransportSource.Tbilisi.Models;
using PublicTransportSource.Tbilisi.Models.RepositoryModels;
using PublicTransportSource.Tbilisi.Repositories;
using PublicTransportSource.Tbilisi.Services;

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
        services.AddScoped<IRouteService, TbilisiRouteService>();

        services.AddScoped<ISchemeStopsRepository, TbilisiSchemeStopsRepository>();
        services.AddScoped<ISchemeStopsService, TbilisiSchemeStopsServices>();
        services.AddScoped<IXmlDeserializer<TbilisiRouteStops>, DefaultXmlDeserilizer<TbilisiRouteStops>>();

        services.AddScoped<IRealtimeBusRepository, TbilisiRealtimeBusRepository>();
        services.AddScoped<IRealtimeBusService, TbilisiRealtimeBusService>();
        services.AddScoped<IXmlDeserializer<TbilisiBusList>, DefaultXmlDeserilizer<TbilisiBusList>>();

        services.AddScoped<IRouteScheduleRepository, TbilisiRouteScheduleRepository>();
        services.AddScoped<IRouteScheduleService, TbilisiRouteScheduleService>();
        services.AddScoped<IXmlDeserializer<TbilisiSchedule>, DefaultXmlDeserilizer<TbilisiSchedule>>();

        services.AddScoped<IArrivalTimeRepository, TbilisiArrivalTimeRepository>();
        services.AddScoped<IArrivalTimeService, TbilisiArrivalTimeService>();
        services.AddScoped<IXmlDeserializer<TbilisiArrivalTimes>, DefaultXmlDeserilizer<TbilisiArrivalTimes>>();
    }
}