using Refit;
using System.Threading.Tasks;
using Weather.Api.Models.Contracts;

namespace Weather.Api.Clients
{
    public interface IWeatherClient
    {
        [Get("/{version}/weather?q={cityName}&units=metric&APPID={appId}")]
        Task<WeatherData> GetCurrentByCityName(string cityName, string version, string appId);
    }
}
