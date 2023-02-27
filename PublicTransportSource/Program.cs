using AutoMapper;
using PublicTransportSource.Extensions;
using PublicTransportSource.Mappers;
using PublicTransportSource.Models;


var builder = WebApplication.CreateBuilder(args);

var envConfigSrc = builder
    .Configuration
    .GetSection("EvnConfigSrc");

EnvConfig env = EnvConfig.CreateDefault(envConfigSrc);

IMapper mapper = DefaultMapper.Create().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

builder.Services.AddScoped<ApiConfig>(_ => new ApiConfig()
{
    BaseUrl = env.ApiBaseUrl,
});

builder.Services.RegisterTbilisiServices();


var app = builder.Build();

app.MapControllers();

app.Run($"http://localhost:{env.ServicePort}");
