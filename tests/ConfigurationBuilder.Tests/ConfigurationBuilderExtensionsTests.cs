using ConfigurationBuilder.Tests.Config;
using ConfigurationBuilder.Tests.Config.Xml;
using FluentAssertions;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public class ConfigurationBuilderExtensionsTests
    {
        [Fact]
        public void AsXmlFromResource_FileExists_CorrectConfiguration()
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
        public void AsXmlFromFile_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<ConfigurationXml>()
                .FromFile("Config\\Xml\\CopyConfig.xml")
                .AsXmlFormat()
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
