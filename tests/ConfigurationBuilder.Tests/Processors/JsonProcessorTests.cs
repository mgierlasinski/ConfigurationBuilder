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
        public void MergeContents_NoneFiles_LastFileOverrides()
        {
            // Arrange
            var jsonProcessor = new JsonProcessor<Configuration>();

            // Act
            var merged = jsonProcessor.MergeContents();

            // Assert
            merged.Should().BeNull();
        }

        [Fact]
        public void MergeContents_TwoExistingFiles_LastFileOverrides()
        {
            // Arrange
            var reader = new ReaderFixture().CreateEmbeddedResourceReader("Config.Json.ResourceConfig.json");
            
            var content1 = reader.ReadContent();
            var content2 = reader.ReadContent("dev");

            var jsonProcessor = new JsonProcessor<Configuration>();

            // Act
            var merged = jsonProcessor.MergeContents(content1, content2);

            // Assert
            merged.ClientId.Should().Be("api_client_dev");
            merged.ClientSecret.Should().Be("client_secret_dev");
        }

        [Fact]
        public void MergeContents_ThreeExistingFiles_LastFileOverrides()
        {
            // Arrange
            var reader = new ReaderFixture().CreateEmbeddedResourceReader("Config.Json.ResourceConfig.json");

            var content1 = reader.ReadContent();
            var content2 = reader.ReadContent("dev");
            var content3 = reader.ReadContent("prod");

            var jsonProcessor = new JsonProcessor<Configuration>();

            // Act
            var merged = jsonProcessor.MergeContents(content1, content2, content3);

            // Assert
            merged.ClientId.Should().Be("api_client_prod");
            merged.ClientSecret.Should().Be("client_secret_prod");
        }
    }
}
