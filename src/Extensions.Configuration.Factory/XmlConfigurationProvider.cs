using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Extensions.Configuration.Factory
{
    public class XmlConfigurationProvider : ConfigurationProvider, IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder) => this;

        public override void Load()
        {
            foreach (ConnectionStringSettings connectionString in ConfigurationManager.ConnectionStrings)
            {
                Data.Add($"ConnectionStrings:{connectionString.Name}", connectionString.ConnectionString);
            }

            foreach (var settingKey in ConfigurationManager.AppSettings.AllKeys)
            {
                if (!Data.ContainsKey(settingKey))
                {
                    Data.Add(settingKey, ConfigurationManager.AppSettings[settingKey]);
                }
            }
        }
    }
}
