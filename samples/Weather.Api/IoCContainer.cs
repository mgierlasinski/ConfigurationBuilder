using ConfigurationBuilder;
using Weather.Api.Clients;
using Weather.Api.Config;
using Weather.Api.Services;

namespace Weather.Api
{
    public class IoCContainer
    {
        public static IWeatherService ResolveWeatherService()
        {
            var configuration = new ConfigurationBuilder<ClientConfiguration>()
                .FromResource("Weather.Api.Config.ClientConfiguration.json")
                .AsJsonFormat()
                .BuildForEnvironment("dev");

            var client = new WeatherClient(configuration.ApiUrl);
            var service = new WeatherService(client, configuration);

            return service;
        }
    }
}
