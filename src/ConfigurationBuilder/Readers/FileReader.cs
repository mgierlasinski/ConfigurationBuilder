using System.IO;
using System.Text;

namespace ConfigurationBuilder.Readers
{
    public class FileReader : IContentReader
    {
        private readonly string _path;
        private readonly FileReaderOptions _options;

        public FileReader(string path, FileReaderOptions options)
        {
            _path = path;
            _options = options;
        }

        public Stream OpenStream(string environment = null)
        {
            var filePath = environment != null
                ? _options.FileNameHandler.GetFilePathForEnvironment(_path, environment)
                : _path;

            return File.Open(filePath, FileMode.Open);
        }

        public string ReadContent(string environment = null)
        {
            string text;
            var stream = OpenStream(environment);

            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }

            return text;
        }
    }
}
