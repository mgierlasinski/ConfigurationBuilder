using ConfigurationBuilder.Tests.Config;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public partial class ConfigurationBuilderExtensionsTests
    {
        [Fact]
        public void AsJsonFromResource_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromResource("ConfigurationBuilder.Tests.Config.Json.ResourceConfig.json")
                .AsJsonFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }

        [Fact]
        public void AsJsonFromFile_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromFile("Config\\Json\\CopyConfig.json")
                .AsJsonFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }

        [Fact]
        public void AsJsonFromString_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromString("{ \"Authority\": \"https://test.domain.com\", \"ClientId\": \"api_client\", " +
                            "\"ClientSecret\": \"zdFpegWRoCac2dPQpPn1\" }")
                .AsJsonFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }
    }
}
