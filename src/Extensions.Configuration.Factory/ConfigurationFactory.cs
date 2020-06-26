using Microsoft.Extensions.Configuration;
using System;

namespace Extensions.Configuration.Factory
{
    public class ConfigurationFactory
    {
        private static readonly Lazy<ConfigurationFactory> Factory = new Lazy<ConfigurationFactory>(() => new ConfigurationFactory(), isThreadSafe: true);

        public static ConfigurationFactory Instance => Factory.Value;

        private IConfiguration _configuration;

        private ConfigurationFactory() => _configuration = null;

        private string EnvironmentVariable(string variable) => Environment.GetEnvironmentVariable(variable);

        public IConfiguration GetConfiguration(bool optional = true, bool reloadOnChange = true)
        {
            if (_configuration == null)
            {
                IConfigurationBuilder builder = new ConfigurationBuilder()
                    .Add(new XmlConfigurationProvider())
                    .AddJsonFile("appsettings.json", optional, reloadOnChange)
                    .AddJsonFile($"appsettings.{EnvironmentVariable("DOTNET_ENVIRONMENT")}.json", optional, reloadOnChange)
                    .AddJsonFile($"appsettings.{EnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional, reloadOnChange)
                    .AddEnvironmentVariables();

                _configuration = builder.Build();
            }

            return _configuration;
        }
    }
}