using ConfigurationBuilder.Readers;
using FluentAssertions;
using System;
using System.IO;
using Xunit;

namespace ConfigurationBuilder.Tests.Readers
{
    public class FileReaderTests
    {
        [Fact]
        public void ReadContent_ExistingFile_NotEmptyResult()
        {
            // Arrange
            var reader = new FileReader("Config\\Json\\CopyConfig.json", new FileNameHandler());

            // Act
            var content = reader.ReadContent();

            // assert
            content.Should().NotBeEmpty();
        }

        [Fact]
        public void ReadContent_NotExistingFile_ThrowsFileNotFoundException()
        {
            // Arrange
            var reader = new FileReader("CopyConfig.json", new FileNameHandler());

            // Act
            Action action = () => reader.ReadContent();

            // assert
            action.Should().Throw<FileNotFoundException>();
        }

        [Fact]
        public void ReadContentForEnvironment_ExistingFile_NotEmptyResult()
        {
            // Arrange
            var reader = new FileReader("Config\\Json\\CopyConfig.json", new FileNameHandler());

            // Act
            var content = reader.ReadContentForEnvironment("dev");

            // assert
            content.Should().NotBeEmpty();
        }

        [Fact]
        public void ReadContentForEnvironment_NotExistingFile_ThrowsFileNotFoundException()
        {
            // Arrange
            var reader = new FileReader("Config\\Json\\CopyConfig.json", new FileNameHandler());

            // Act
            Action action = () => reader.ReadContentForEnvironment("test");

            // assert
            action.Should().Throw<FileNotFoundException>();
        }
    }
}
