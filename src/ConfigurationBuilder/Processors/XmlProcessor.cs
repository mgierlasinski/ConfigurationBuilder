using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ConfigurationBuilder.Processors
{
    public class XmlProcessor<T> : IContentProcessor<T>
    {
        public T ProcessContent(IContentReader reader)
        {
            T result;

            using (var stream = reader.OpenStream())
            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(typeof(T));
                result = (T)serializer.Deserialize(streamReader);
            }

            return result;
        }

        public T ProcessContentForEnvironment(IContentReader reader, string environment)
        {
            throw new NotImplementedException("Merging multiple configurations is currently not supported by XML");
        }
    }
}
