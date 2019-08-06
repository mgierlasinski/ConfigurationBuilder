using System.IO;

namespace ConfigurationBuilder.Readers
{
    public class FileReader : IContentReader
    {
        private readonly string _path;
        private readonly IFileNameHandler _fileNameHandler;

        public FileReader(string path, IFileNameHandler fileNameHandler)
        {
            _path = path;
            _fileNameHandler = fileNameHandler;
        }

        public string ReadContent()
        {
            return ReadTextFromPath(_path);
        }

        public string ReadContentForEnvironment(string environment)
        {
            var envPath = _fileNameHandler.GetFilePathForEnvironment(_path, environment);
            return ReadTextFromPath(envPath);
        }

        public string ReadTextFromPath(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
