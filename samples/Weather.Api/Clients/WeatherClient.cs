using Refit;
using System.Threading.Tasks;
using Weather.Api.Models.Contracts;

namespace Weather.Api.Clients
{
    public class WeatherClient : IWeatherClient
    {
        private readonly IWeatherClient _internalClient;

        public WeatherClient(string url)
        {
            _internalClient = RestService.For<IWeatherClient>(url);
        }

        public Task<WeatherData> GetCurrentByCityName(string cityName, string version, string appId)
        {
            return _internalClient.GetCurrentByCityName(cityName, version, appId);
        }
    }
}
