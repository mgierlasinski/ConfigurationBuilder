using System.Threading.Tasks;
using Weather.Api.Models;

namespace Weather.Api.Services
{
    public interface IWeatherService
    {
        Task<WeatherModel> GetCurrentByCityName(string cityName);
    }
}
