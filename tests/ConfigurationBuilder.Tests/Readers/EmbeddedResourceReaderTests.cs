using ConfigurationBuilder.Tests.Fixtures;
using FluentAssertions;
using System;
using Xunit;

namespace ConfigurationBuilder.Tests.Readers
{
    public class EmbeddedResourceReaderTests
    {
        [Fact]
        public void ReadContent_ExistingFile_NotEmptyResult()
        {
            // Arrange
            var reader = new ReaderFixture().CreateEmbeddedResourceReader("Config.Json.ResourceConfig.json");

            // Act
            var content = reader.ReadContent();

            // assert
            content.Should().NotBeEmpty();
        }

        [Fact]
        public void ReadContent_NotExistingFile_ThrowsArgumentException()
        {
            // Arrange
            var reader = new ReaderFixture().CreateEmbeddedResourceReader("ResourceConfig.json");

            // Act
            Action action = () => reader.ReadContent();

            // assert
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ReadContentForEnvironment_ExistingFile_NotEmptyResult()
        {
            // Arrange
            var reader = new ReaderFixture().CreateEmbeddedResourceReader("Config.Json.ResourceConfig.json");

            // Act
            var content = reader.ReadContentForEnvironment("dev");

            // assert
            content.Should().NotBeEmpty();
        }

        [Fact]
        public void ReadContentForEnvironment_NotExistingFile_ThrowsArgumentException()
        {
            // Arrange
            var reader = new ReaderFixture().CreateEmbeddedResourceReader("Config.Json.ResourceConfig.json");

            // Act
            Action action = () => reader.ReadContentForEnvironment("test");

            // assert
            action.Should().Throw<ArgumentException>();
        }
    }
}
