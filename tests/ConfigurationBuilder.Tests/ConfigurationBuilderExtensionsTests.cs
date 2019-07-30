using ConfigurationBuilder.Tests.Config;
using ConfigurationBuilder.Tests.Config.Json;
using ConfigurationBuilder.Tests.Config.Xml;
using FluentAssertions;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public class ConfigurationBuilderExtensionsTests
    {
        [Fact]
        public void FromResourceAsXml_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<ConfigurationXml>()
                .FromResource("ConfigurationBuilder.Tests.Config.Xml.ResourceConfig.xml")
                .AsXmlFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }

        [Fact]
        public void FromResourceAsJson_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<ConfigurationJson>()
                .FromResource("ConfigurationBuilder.Tests.Config.Json.ResourceConfig.json")
                .AsJsonFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }

        [Fact]
        public void FromFileAsJson_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<ConfigurationJson>()
                .FromFile("Config\\Json\\CopyConfig.json")
                .AsJsonFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }

        [Fact]
        public void FromStringAsJson_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<ConfigurationJson>()
                .FromString("{ \"Authority\": \"https://test.domain.com\", \"ClientId\": \"api_client\", " +
                            "\"ClientSecret\": \"zdFpegWRoCac2dPQpPn1\" }")
                .AsJsonFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }

        private void AssertHasCorrectValues(IConfiguration configuration)
        {
            configuration.Should().NotBeNull();
            configuration.Authority.Should().Be("https://test.domain.com");
            configuration.ClientId.Should().Be("api_client");
            configuration.ClientSecret.Should().Be("zdFpegWRoCac2dPQpPn1");
        }
    }
}
