using ConfigurationBuilder.Tests.Config;
using ConfigurationBuilder.Tests.Config.Yaml;
using FluentAssertions;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public class ConfigurationBuilderYamlExtensionsTests
    {
        [Fact]
        public void AsYamlFromResource_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<ConfigurationYaml>()
                .FromResource("ConfigurationBuilder.Tests.Config.Yaml.ResourceConfig.yaml")
                .AsYamlFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }

        [Fact]
        public void AsYamlFromFile_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<ConfigurationYaml>()
                .FromFile("Config\\Yaml\\CopyConfig.yaml")
                .AsYamlFormat()
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
