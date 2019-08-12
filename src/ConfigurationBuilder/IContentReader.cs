using System.IO;

namespace ConfigurationBuilder
{
    public interface IContentReader
    {
        Stream OpenStream(string environment = null);

        string ReadContent(string environment = null);
    }
}
