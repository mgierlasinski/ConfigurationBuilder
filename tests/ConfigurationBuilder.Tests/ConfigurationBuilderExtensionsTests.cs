using ConfigurationBuilder.Tests.Config;
using ConfigurationBuilder.Tests.TestData;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace ConfigurationBuilder.Tests
{
    public partial class ConfigurationBuilderExtensionsTests
    {
        [Fact]
        public void Setup_CustomReader_ReadContentByCustomImplementation()
        {
            // Arrange
            var reader = Substitute.For<IContentReader>();
            reader.ReadContent().Returns("Mock content");
            reader.ReadContent(Arg.Is<string>(x => !string.IsNullOrEmpty(x))).Returns("Mock content for env");

            // Act
            var builder = new ConfigurationBuilder<Configuration>()
                .Setup(x => x.Reader = reader);

            // Assert
            builder.Reader.ReadContent().Should().Be("Mock content");
            builder.Reader.ReadContent("dev").Should().Be("Mock content for env");
        }

        [Fact]
        public void Setup_CustomProcessor_ProcessContentByCustomImplementation()
        {
            // Arrange
            var expected = ConfigurationTestData.GetExpected(clientId: "mocked_implementation");

            var processor = Substitute.For<IContentProcessor<Configuration>>();
            processor.ProcessContent(Arg.Any<string>()).Returns(expected);

            // Act
            var builder = new ConfigurationBuilder<Configuration>()
                .Setup(x => x.Processor = processor);

            // Assert
            builder.Processor.ProcessContent("test").Should().BeEquivalentTo(expected);
        }
    }
}
