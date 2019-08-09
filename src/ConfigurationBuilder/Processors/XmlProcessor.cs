using System;
using System.IO;
using System.Xml.Serialization;

namespace ConfigurationBuilder.Processors
{
    public class XmlProcessor<T> : IContentProcessor<T>
    {
        public T ProcessContent(string content)
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(new StringReader(content));
        }

        public T MergeContents(params string[] contents)
        {
            throw new NotImplementedException("Merging multiple configurations is currently not supported by XML");
        }
    }
}
