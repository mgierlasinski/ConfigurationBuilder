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
        public void ReadContentWithEnvironment_ExistingFile_NotEmptyResult()
        {
            // Arrange
            var reader = new ReaderFixture().CreateEmbeddedResourceReader("Config.Json.ResourceConfig.json");

            // Act
            var content = reader.ReadContent("dev");

            // assert
            content.Should().NotBeEmpty();
        }

        [Fact]
        public void ReadContentWithEnvironment_NotExistingFile_ThrowsArgumentException()
        {
            // Arrange
            var reader = new ReaderFixture().CreateEmbeddedResourceReader("Config.Json.ResourceConfig.json");

            // Act
            Action action = () => reader.ReadContent("test");

            // assert
            action.Should().Throw<ArgumentException>();
        }
    }
}
