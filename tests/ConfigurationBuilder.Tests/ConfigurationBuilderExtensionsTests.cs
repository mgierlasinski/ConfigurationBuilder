using ConfigurationBuilder.Tests.Config;
using FluentAssertions;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public class ConfigurationBuilderExtensionsTests
    {
        [Fact]
        public void FromResourceAsJson_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromResource("ConfigurationBuilder.Tests.Config.ResourceConfig.json")
                .AsJsonFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }

        [Fact]
        public void FromFileAsJson_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromFile("Config\\CopyConfig.json")
                .AsJsonFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }

        [Fact]
        public void FromStringAsJson_FileExists_CorrectConfiguration()
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

        private void AssertHasCorrectValues(Configuration configuration)
        {
            configuration.Should().NotBeNull();
            configuration.Authority.Should().Be("https://test.domain.com");
            configuration.ClientId.Should().Be("api_client");
            configuration.ClientSecret.Should().Be("zdFpegWRoCac2dPQpPn1");
        }
    }
}
