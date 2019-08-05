using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace ConfigurationBuilder.Processors
{
    public class XmlProcessor<T> : IContentProcessor<T>
    {
        public T ProcessContent(string content)
        {
            using (var xmlReader = XmlReader.Create(new StringReader(content)))
            {
                var serializer = new DataContractSerializer(typeof(T));
                return (T)serializer.ReadObject(xmlReader);
            }
        }

        public T ProcessMultipleContents(params string[] contents)
        {
            throw new System.NotImplementedException();
        }
    }
}
