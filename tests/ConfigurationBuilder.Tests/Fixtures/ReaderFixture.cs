using ConfigurationBuilder.Readers;

namespace ConfigurationBuilder.Tests.Fixtures
{
    public class ReaderFixture
    {
        public EmbeddedResourceReader CreateEmbeddedResourceReader(string fileName)
        {
            return new EmbeddedResourceReader($"ConfigurationBuilder.Tests.{fileName}",
                typeof(ReaderFixture).Assembly, new FileNameHandler());
        }
    }
}
