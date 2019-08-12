using ConfigurationBuilder.Readers;
using FluentAssertions;
using System;
using System.IO;
using ConfigurationBuilder.Tests.Fixtures;
using Xunit;

namespace ConfigurationBuilder.Tests.Readers
{
    public class FileReaderTests
    {
        [Fact]
        public void ReadContent_ExistingFile_NotEmptyResult()
        {
            // Arrange
            var reader = new ReaderFixture().CreateFileReader("Config\\Json\\CopyConfig.json");

            // Act
            var content = reader.ReadContent();

            // assert
            content.Should().NotBeEmpty();
        }

        [Fact]
        public void ReadContent_NotExistingFile_ThrowsFileNotFoundException()
        {
            // Arrange
            var reader = new ReaderFixture().CreateFileReader("CopyConfig.json");

            // Act
            Action action = () => reader.ReadContent();

            // assert
            action.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public void ReadContentWithEnvironment_ExistingFile_NotEmptyResult()
        {
            // Arrange
            var reader = new ReaderFixture().CreateFileReader("Config\\Json\\CopyConfig.json");

            // Act
            var content = reader.ReadContent("dev");

            // assert
            content.Should().NotBeEmpty();
        }

        [Fact]
        public void ReadContentWithEnvironment_NotExistingFile_ThrowsFileNotFoundException()
        {
            // Arrange
            var reader = new ReaderFixture().CreateFileReader("Config\\Json\\CopyConfig.json");

            // Act
            Action action = () => reader.ReadContent("test");

            // assert
            action.Should().Throw<FileNotFoundException>();
        }
    }
}
