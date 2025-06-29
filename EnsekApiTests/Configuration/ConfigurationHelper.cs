using Microsoft.Extensions.Configuration;

namespace EnsekApiTests.Configuration
{
    public class ConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\git\\EnsekApiTests\\EnsekApiTests\\appsettings.json", optional: false, reloadOnChange: true);
            return configBuilder.Build();
        }
    }
}
