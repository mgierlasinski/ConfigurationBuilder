using ConfigurationBuilder.Tests.Config;
using ConfigurationBuilder.Tests.TestData;
using FluentAssertions;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public partial class ConfigurationBuilderExtensionsTests
    {
        [Fact]
        public void AsJsonFromResourceBuild_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromResource("ConfigurationBuilder.Tests.Config.Json.ResourceConfig.json")
                .AsJsonFormat()
                .Build();

            // Assert
            configuration.Should().BeEquivalentTo(ConfigurationTestData.GetExpected());
        }

        [Theory]
        [InlineData("dev", "api_client_dev", "client_secret_dev")]
        [InlineData("prod", "api_client_prod", "client_secret_prod")]
        public void AsJsonFromResourceBuildEnvironment_FileExists_CorrectConfiguration(string env, string client, string secret)
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromResource("ConfigurationBuilder.Tests.Config.Json.ResourceConfig.json")
                .AsJsonFormat()
                .BuildForEnvironment(env);

            // Assert
            var expected = ConfigurationTestData.GetExpected();
            expected.ClientId = client;
            expected.ClientSecret = secret;

            configuration.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void AsJsonFromFileBuild_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromFile("Config\\Json\\CopyConfig.json")
                .AsJsonFormat()
                .Build();

            // Assert
            configuration.Should().BeEquivalentTo(ConfigurationTestData.GetExpected());
        }

        [Fact]
        public void AsJsonFromStringBuild_FileExists_CorrectConfiguration()
        {
            // Act
            var configuration = new ConfigurationBuilder<Configuration>()
                .FromString("{" + 
                            "\"ApiUrl\": \"https://test.domain.com\", " +
                            "\"ApiVersion\": \"1.0\", " +
                            "\"ClientId\": \"api_client\", " + 
                            "\"ClientSecret\": \"zdFpegWRoCac2dPQpPn1\" }")
                .AsJsonFormat()
                .Build();

            // Assert
            configuration.Should().BeEquivalentTo(ConfigurationTestData.GetExpected());
        }
    }
}
