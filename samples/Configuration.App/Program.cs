using Configuration.Library.Config;
using ConfigurationBuilder;
using System;

namespace Configuration.App
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadConfigFromResource();
            Console.WriteLine();
            ReadConfigFromFile();
            Console.WriteLine();
            ReadConfigFromMemory();

            Console.ReadLine();
        }

        private static void ReadConfigFromResource()
        {
            var configuration = new ConfigurationBuilder<ClientConfiguration>()
                .FromResource("Configuration.Library.Config.ResourceConfig.json")
                .AsJsonFormat()
                .Build();

            
            DisplayConfiguration(configuration);
        }

        private static void ReadConfigFromFile()
        {
            var configuration = new ConfigurationBuilder<ClientConfiguration>()
                .FromFile("Config\\CopyConfig.json")
                .AsJsonFormat()
                .Build();

            DisplayConfiguration(configuration);
        }

        private static void ReadConfigFromMemory()
        {
            var configuration = new ConfigurationBuilder<ClientConfiguration>()
                .FromString("{ \"Authority\": \"https://test.domain.com\", \"ClientId\": \"mobile_client\", " + 
                            "\"ClientSecret\": \"zdFpegWRoCac2dPQpPn1\", \"Description\": \"Config from string\" }")
                .AsJsonFormat()
                .Build();

            DisplayConfiguration(configuration);
        }

        private static void DisplayConfiguration(IClientConfiguration configuration)
        {
            Console.WriteLine($"Authority: {configuration.Authority}");
            Console.WriteLine($"ClientId: {configuration.ClientId}");
            Console.WriteLine($"ClientSecret: {configuration.ClientSecret}");
            Console.WriteLine($"Description: {configuration.Description}");
        }
    }
}
