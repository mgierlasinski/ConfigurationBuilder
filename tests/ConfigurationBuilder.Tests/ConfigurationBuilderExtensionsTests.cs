using ConfigurationBuilder.Tests.Config;
using ConfigurationBuilder.Tests.Config.Xml;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public partial class ConfigurationBuilderExtensionsTests
    {
        [Fact]
        public void Setup_CustomFileNameHandler_HandlerConfigured()
        {
            // Arrange
            var handler = Substitute.For<IFileNameHandler>();
            handler.GetFilePathForEnvironment(
                Arg.Any<string>(), Arg.Any<string>()).Returns("Config.dev.ext");

            // Act
            var builder = new ConfigurationBuilder<ConfigurationXml>()
                .Setup(x => x.FileNameHandler = handler);

            // Assert
            builder.FileNameHandler.GetFilePathForEnvironment("Config.ext", "dev")
                .Should().Be("Config.dev.ext");
        }

        private void AssertHasCorrectValues(IConfiguration configuration)
        {
            configuration.Should().NotBeNull();
            configuration.Authority.Should().Be("https://test.domain.com");
            configuration.ClientId.Should().Be("api_client");
            configuration.ClientSecret.Should().Be("zdFpegWRoCac2dPQpPn1");
        }
    }
}
