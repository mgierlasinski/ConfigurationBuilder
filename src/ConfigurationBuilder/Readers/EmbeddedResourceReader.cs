using System;
using System.IO;
using System.Reflection;

namespace ConfigurationBuilder.Readers
{
    public class EmbeddedResourceReader : IContentReader
    {
        private readonly string _path;
        private readonly Assembly _assembly;
        private readonly IFileNameHandler _fileNameHandler;

        public EmbeddedResourceReader(string path, Assembly assembly, IFileNameHandler fileNameHandler)
        {
            _path = path;
            _assembly = assembly;
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

        private string ReadTextFromPath(string path)
        {
            string content;

            using (var stream = _assembly.GetManifestResourceStream(path))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"Cannot read file at {path}. Make sure you entered full namespace and file has Build Action set to Embedded Resource");
                }

                using (var reader = new StreamReader(stream))
                {
                    content = reader.ReadToEnd();
                }
            }

            return content;
        }
    }
}
