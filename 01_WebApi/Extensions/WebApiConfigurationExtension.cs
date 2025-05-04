using Application.Service;
using Application.Service.Interface;
using Core.Entity;
using Core.Repository.Interface;
using Infraestructure.Repository;
using System.Text.Json.Serialization;

namespace WebApi.Extensions;

public static class WebApiConfigurationExtension
{
    public static void ConfigureControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddMemoryCache();
        

        builder.Services
            .AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
            });
    }    

    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IContactService, ContactService>();
        builder.Services.AddScoped<IDirectDistanceDialingService, DirectDistanceDialingService>();

        builder.Services.AddScoped<IContactHttpRepository, ContactHttpRepository>();
        builder.Services.AddScoped<IDirectDistanceDialingHttpRepository, DirectDistanceDialingHttpRepository>();

        builder.Services.AddHttpClient<IContactHttpRepository, ContactHttpRepository>();
        builder.Services.AddHttpClient<IDirectDistanceDialingHttpRepository, DirectDistanceDialingHttpRepository>();
    }    

    public static void ConfigureSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }

    public static void ConfigurePersistanceApiUrls(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<PersistanceApiUrlsOptions>(
            builder.Configuration.GetSection("PersistanceApiUrls"));
    }
}
