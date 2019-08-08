using ConfigurationBuilder.Tests.Config;
using ConfigurationBuilder.Tests.TestData;
using FluentAssertions;
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
            configuration.Should().BeEquivalentTo(ConfigurationTestData.GetExpected());
        }

        [Theory]
        [MemberData(nameof(ConfigurationTestData.EnvironmentConfiguration), MemberType = typeof(ConfigurationTestData))]
        public void AsYamlFromResourceBuildEnvironment_FileExists_CorrectConfiguration(string env, IConfiguration expected)
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromResource("ConfigurationBuilder.Tests.Config.Yaml.ResourceConfig.yaml")
                .AsYamlFormat()
                .BuildForEnvironment(env);

            // Assert
            configuration.Should().BeEquivalentTo(expected);
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
            configuration.Should().BeEquivalentTo(ConfigurationTestData.GetExpected());
        }
    }
}
