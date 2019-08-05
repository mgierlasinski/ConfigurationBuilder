using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public class FileNameHandlerTests
    {
        public static IEnumerable<object[]> TestData = new[]
        {
            new[] { "Tests.Config.Configuration.json", "dev", "Tests.Config.Configuration.dev.json" },
            new[] { "Tests\\Config\\Configuration.json", "dev", "Tests\\Config\\Configuration.dev.json" },
            new[] { "Tests\\Config\\Configuration", "dev", "Tests\\Config\\Configuration.dev" }
        };

        [Theory]
        [MemberData(nameof(TestData))]
        public void GetFilePathForEnvironment_ValidEnvironment_CorrectPath(string path, string env, string expected)
        {
            // Arrange
            var handler = new FileNameHandler();

            // Act
            var pathWithEnv = handler.GetFilePathForEnvironment(path, env);

            // Assert
            pathWithEnv.Should().Be(expected);
        }
    }
}
