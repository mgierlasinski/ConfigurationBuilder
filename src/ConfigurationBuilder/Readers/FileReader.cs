using System.IO;

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

        public string ReadContentForEnvironment(string environment)
        {
            throw new System.NotImplementedException();
        }
    }
}
