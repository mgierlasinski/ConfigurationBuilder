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

        public Stream OpenStream(string environment = null)
        {
            var streamPath = environment != null
                ? _options.FileNameHandler.GetFilePathForEnvironment(_path, environment)
                : _path;

            return _options.Assembly.GetManifestResourceStream(streamPath);
        }

        public string ReadContent(string environment = null)
        {
            string content;

            using (var stream = OpenStream(environment))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"Cannot read file, make sure you entered full namespace and file has Build Action set to Embedded Resource");
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
