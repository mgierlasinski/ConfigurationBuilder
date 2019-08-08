using System;
using System.IO;

namespace ConfigurationBuilder.Readers
{
    public class EmbeddedResourceReader : IContentReader
    {
        private readonly string _path;
        private readonly EmbeddedResourceReaderOptions _options;

        public EmbeddedResourceReader(string path, EmbeddedResourceReaderOptions options)
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

        private string ReadTextFromPath(string path)
        {
            string content;

            using (var stream = _options.Assembly.GetManifestResourceStream(path))
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
