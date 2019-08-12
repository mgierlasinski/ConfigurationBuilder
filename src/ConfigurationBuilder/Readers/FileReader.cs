using System.IO;

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

        public string ReadContent()
        {
            return ReadTextFromPath(_path);
        }

        public string ReadContentForEnvironment(string environment)
        {
            var envPath = _options.FileNameHandler.GetFilePathForEnvironment(_path, environment);
            return ReadTextFromPath(envPath);
        }

        public string ReadTextFromPath(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
