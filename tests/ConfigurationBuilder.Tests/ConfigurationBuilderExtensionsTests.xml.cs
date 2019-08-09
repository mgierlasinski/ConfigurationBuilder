using ConfigurationBuilder.Tests.Config;
using ConfigurationBuilder.Tests.TestData;
using FluentAssertions;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public partial class ConfigurationBuilderExtensionsTests
    {
        [Fact]
        public void AsXmlFromResource_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromResource("ConfigurationBuilder.Tests.Config.Xml.ResourceConfig.xml")
                .AsXmlFormat()
                .Build();

            // Assert
            configuration.Should().BeEquivalentTo(ConfigurationTestData.GetExpected());
        }

        [Fact]
        public void AsXmlFromFile_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromFile("Config\\Xml\\CopyConfig.xml")
                .AsXmlFormat()
                .Build();

            // Assert
            configuration.Should().BeEquivalentTo(ConfigurationTestData.GetExpected());
        }
    }
}
