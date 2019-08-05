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
            var fileNameHandler = Substitute.For<IFileNameHandler>();
            fileNameHandler.GetFilePathForEnvironment(Arg.Any<string>()).Returns("PathToFile");

            // Act
            var builder = new ConfigurationBuilder<ConfigurationXml>()
                .Setup(x => x.FileNameHandler = fileNameHandler);

            // Assert
            builder.FileNameHandler.GetFilePathForEnvironment("dev").Should().Be("PathToFile");
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
