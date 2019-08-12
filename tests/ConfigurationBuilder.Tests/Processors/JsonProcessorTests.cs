using ConfigurationBuilder.Json.Processors;
using ConfigurationBuilder.Tests.Config;
using ConfigurationBuilder.Tests.Fixtures;
using FluentAssertions;
using Xunit;

namespace ConfigurationBuilder.Tests.Processors
{
    public class JsonProcessorTests
    {
        [Fact]
        public void ProcessContentForEnvironment_ExistingFiles_LastFileOverrides()
        {
            // Arrange
            var reader = new ReaderFixture().CreateEmbeddedResourceReader("Config.Json.ResourceConfig.json");
            var jsonProcessor = new JsonProcessor<Configuration>();

            // Act
            var merged = jsonProcessor.ProcessContentForEnvironment(reader, "dev");

            // Assert
            merged.ClientId.Should().Be("api_client_dev");
            merged.ClientSecret.Should().Be("client_secret_dev");
        }
    }
}
