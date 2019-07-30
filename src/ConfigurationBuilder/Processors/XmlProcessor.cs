using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
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

        public Task<T> ProcessContentAsync(string content)
        {
            return Task.FromResult(ProcessContent(content));
        }
    }
}
