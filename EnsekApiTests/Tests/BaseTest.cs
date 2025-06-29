using EnsekApiTests.Configuration;
using EnsekApiTests.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace EnsekApiTests.Tests
{
    public class BaseTest
    {
        protected IApiClient? _client;
        protected IConfiguration _configuration;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _configuration = ConfigurationHelper.GetConfiguration();

            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(_configuration);
            services.AddSingleton<IApiClient, ApiClient>();

            var serviceProvider = services.BuildServiceProvider();

            _client = serviceProvider.GetService<IApiClient>()!;

            _client.Authenticate();
        }

    }
}
