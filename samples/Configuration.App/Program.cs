using Configuration.Library.Config;
using ConfigurationBuilder;
using System;

namespace Configuration.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder<ClientConfiguration>()
                .FromResource("Configuration.Library.Config.ResourceConfig.json")
                .AsJsonFormat()
                .Build();

            Console.WriteLine($"Authority: {configuration.Authority}");
            Console.WriteLine($"ClientId: {configuration.ClientId}");
            Console.WriteLine($"ClientSecret: {configuration.ClientSecret}");
            Console.WriteLine($"RedirectUri: {configuration.RedirectUri}");

            Console.ReadLine();
        }
    }
}
