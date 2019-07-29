using System.IO;
using System.Threading.Tasks;

namespace ConfigurationBuilder.Readers
{
    public class FileReader : IContentReader
    {
        private readonly string _path;

        public FileReader(string path)
        {
            _path = path;
        }

        public string ReadContent()
        {
            return File.ReadAllText(_path);
        }

        public Task<string> ReadContentAsync()
        {
            return Task.FromResult(ReadContent());
        }
    }
}
