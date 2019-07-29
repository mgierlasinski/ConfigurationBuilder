using ConfigurationBuilder.Processors;
using ConfigurationBuilder.Readers;
using System.Reflection;

namespace ConfigurationBuilder
{
    public static class ConfigurationBuilderExtensions
    {
        public static ConfigurationBuilder<T> FromResource<T>(this ConfigurationBuilder<T> builder, string path, Assembly assembly = null)
        {
            builder.Reader = new EmbeddedResourceReader(path, assembly ?? typeof(T).Assembly);
            return builder;
        }

        public static ConfigurationBuilder<T> FromFile<T>(this ConfigurationBuilder<T> builder, string path)
        {
            builder.Reader = new FileReader(path);
            return builder;
        }

        public static ConfigurationBuilder<T> FromString<T>(this ConfigurationBuilder<T> builder, string content)
        {
            builder.Reader = new MemoryReader(content);
            return builder;
        }

        public static ConfigurationBuilder<T> AsJsonFormat<T>(this ConfigurationBuilder<T> builder)
        {
            builder.Processor = new JsonProcessor<T>();
            return builder;
        }
    }
}
