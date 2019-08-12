using System.IO;
using System.Text;

namespace ConfigurationBuilder.Readers
{
    public class MemoryReader : IContentReader
    {
        private readonly string _content;

        public MemoryReader(string content)
        {
            _content = content;
        }

        public Stream OpenStream(string environment = null)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(_content));
        }

        public string ReadContent(string environment = null)
        {
            return _content;
        }
    }
}
