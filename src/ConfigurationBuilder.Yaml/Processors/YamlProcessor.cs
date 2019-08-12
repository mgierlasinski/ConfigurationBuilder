using System.IO;
using YamlDotNet.Core;
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
            var reader = new StringReader(string.Join("", contents));
            var parser = new MergingParser(new Parser(reader));

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            return deserializer.Deserialize<T>(parser);
        }
    }
}
