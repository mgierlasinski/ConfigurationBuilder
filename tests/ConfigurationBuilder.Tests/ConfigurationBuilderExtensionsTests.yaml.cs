using ConfigurationBuilder.Tests.Config;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public partial class ConfigurationBuilderExtensionsTests
    {
        [Fact]
        public void AsYamlFromResource_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
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
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromFile("Config\\Yaml\\CopyConfig.yaml")
                .AsYamlFormat()
                .Build();

            // Assert
            AssertHasCorrectValues(configuration);
        }
    }
}
