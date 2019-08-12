using System.IO;
using System.Text;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConfigurationBuilder.Yaml.Processors
{
    public class YamlProcessor<T> : IContentProcessor<T>
    {
        public T ProcessContent(IContentReader reader)
        {
            T result;

            using (var stream = reader.OpenStream())
            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(new CamelCaseNamingConvention())
                    .Build();

                result = deserializer.Deserialize<T>(streamReader);
            }

            return result;
        }

        public T ProcessContentForEnvironment(IContentReader reader, string environment)
        {
            var baseContent = reader.ReadContent();
            var envContent = reader.ReadContent(environment);

            var stringReader = new StringReader(string.Join("", baseContent, envContent));
            var parser = new MergingParser(new Parser(stringReader));

            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .Build();

            return deserializer.Deserialize<T>(parser);
        }
    }
}
