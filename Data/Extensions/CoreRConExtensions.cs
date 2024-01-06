using ArkMonitor.Data.Configuration;

using CoreRCON;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ArkMonitor.Data.Extensions;

public static class CoreRConExtensions
{
    public static IServiceCollection AddCoreRCon(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<ArkServerConfig>()
            .Bind(configuration.GetSection(ArkServerConfig.SectionName))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddSingleton(sp =>
        {
            var config = sp.GetRequiredService<IOptions<ArkServerConfig>>().Value;

            return new RCON(config.HostIpAddress, config.Port, config.AdminPassword);
        });

        return services;
    }
}