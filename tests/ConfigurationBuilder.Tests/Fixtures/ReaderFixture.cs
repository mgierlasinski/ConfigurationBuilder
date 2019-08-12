using ConfigurationBuilder.Readers;
using ConfigurationBuilder.Tests.Config;

namespace ConfigurationBuilder.Tests.Fixtures
{
    public class ReaderFixture
    {
        public EmbeddedResourceReader CreateEmbeddedResourceReader(string fileName)
        {
            var options = new EmbeddedResourceReaderOptions<Configuration>();
            return new EmbeddedResourceReader($"ConfigurationBuilder.Tests.{fileName}", options);
        }

        public FileReader CreateFileReader(string fileName)
        {
            var options = new FileReaderOptions();
            return new FileReader(fileName, options);
        }
    }
}
