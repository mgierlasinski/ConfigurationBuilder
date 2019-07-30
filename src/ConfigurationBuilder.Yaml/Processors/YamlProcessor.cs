using System.IO;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConfigurationBuilder.Yaml.Processors
{
    public class YamlProcessor<T> : IContentProcessor<T>
    {
        public T ProcessContent(string content)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            return deserializer.Deserialize<T>(new StringReader(content));
        }

        public Task<T> ProcessContentAsync(string content)
        {
            return Task.FromResult(ProcessContent(content));
        }
    }
}
