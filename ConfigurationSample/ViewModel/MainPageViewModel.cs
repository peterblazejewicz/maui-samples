using ConfigurationSample.Model;
using Microsoft.Extensions.Configuration;

namespace ConfigurationSample.ViewModel;

public class MainPageViewModel(TransientFaultHandlingOptions transientFaultHandlingOptions, IConfiguration configuration)
{
    public string? SecretKey => configuration["SecretKey"];
    public string? Token => configuration["token"];
    public string? Code => configuration["ConfigurationSampleCode"];
    public bool Enabled => transientFaultHandlingOptions.Enabled;
    public TimeSpan AutoRetryDelay => transientFaultHandlingOptions.AutoRetryDelay;
}