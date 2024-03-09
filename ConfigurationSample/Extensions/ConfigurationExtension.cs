using Microsoft.Extensions.Configuration;

namespace ConfigurationSample.Extensions;

public static class ConfigurationExtension
{
    public static IServiceCollection Configure<TOptions>(this IServiceCollection services, IConfiguration configuration)
        where TOptions : class, new()
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        var options = new TOptions();
        configuration.Bind(options);
        return services.AddSingleton(options);
    }
}