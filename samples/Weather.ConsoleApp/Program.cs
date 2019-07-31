using System;
using System.Threading.Tasks;
using Weather.Api;

namespace Weather.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter city name: ");

            var cityName = Console.ReadLine();

            var weatherService = IoCContainer.ResolveWeatherService();
            var weatherData = await weatherService.GetCurrentByCityName(cityName);

            Console.WriteLine("------");
            Console.WriteLine($"Weather for {weatherData.Name}");
            Console.WriteLine($"Temperature: {weatherData.Temperature} °C");
        }
    }
}
