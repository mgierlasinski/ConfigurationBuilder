using System;
using System.IO;
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

        public T MergeContents(params string[] contents)
        {
            throw new NotImplementedException("Merging multiple configurations is currently not supported by Yaml");
        }
    }
}
