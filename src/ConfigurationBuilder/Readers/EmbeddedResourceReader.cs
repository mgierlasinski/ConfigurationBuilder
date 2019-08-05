using System;
using System.IO;
using System.Reflection;

namespace ConfigurationBuilder.Readers
{
    public class EmbeddedResourceReader : IContentReader
    {
        private readonly Assembly _assembly;
        private readonly string _filePath;

        public EmbeddedResourceReader(string filePath, Assembly assembly)
        {
            _filePath = filePath;
            _assembly = assembly;
        }

        public string ReadContent()
        {
            string file;

            using (var stream = _assembly.GetManifestResourceStream(_filePath))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"Cannot read file at {_filePath}. Make sure you entered full namespace and file has Build Action set to Embedded Resource");
                }

                using (var reader = new StreamReader(stream))
                {
                    file = reader.ReadToEnd();
                }
            }

            return file;
        }

        public string ReadContentForEnvironment(string environment)
        {
            throw new NotImplementedException();
        }
    }
}
