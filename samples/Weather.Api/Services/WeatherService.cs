using System.Threading.Tasks;
using Weather.Api.Clients;
using Weather.Api.Config;
using Weather.Api.Models;

namespace Weather.Api.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherClient _weatherClient;
        private readonly IClientConfiguration _configuration;

        public WeatherService(
            IWeatherClient weatherClient,
            IClientConfiguration configuration)
        {
            _weatherClient = weatherClient;
            _configuration = configuration;
        }

        public async Task<WeatherModel> GetCurrentByCityName(string cityName)
        {
            var data = await _weatherClient.GetCurrentByCityName(cityName, _configuration.ApiVersion, _configuration.AppId);
            return new WeatherModel
            {
                Name = data.Name,
                Temperature = data.Main?.Temp ?? 0
            };
        }
    }
}
