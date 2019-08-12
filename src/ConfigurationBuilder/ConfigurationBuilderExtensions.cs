using ConfigurationBuilder.Processors;
using ConfigurationBuilder.Readers;
using System;

namespace ConfigurationBuilder
{
    public static class ConfigurationBuilderExtensions
    {
        public static ConfigurationBuilder<T> Setup<T>(this ConfigurationBuilder<T> builder, Action<ConfigurationBuilder<T>> action)
        {
            action(builder);
            return builder;
        }

        public static ConfigurationBuilder<T> FromResource<T>(this ConfigurationBuilder<T> builder, string path, Action<EmbeddedResourceReaderOptions> setupOptions = null)
        {
            var options = new EmbeddedResourceReaderOptions<T>();
            setupOptions?.Invoke(options);

            builder.Reader = new EmbeddedResourceReader(path, options);
            return builder;
        }

        public static ConfigurationBuilder<T> FromFile<T>(this ConfigurationBuilder<T> builder, string path, Action<FileReaderOptions> setupOptions = null)
        {
            var options = new FileReaderOptions();
            setupOptions?.Invoke(options);

            builder.Reader = new FileReader(path, options);
            return builder;
        }

        public static ConfigurationBuilder<T> FromString<T>(this ConfigurationBuilder<T> builder, string content)
        {
            builder.Reader = new MemoryReader(content);
            return builder;
        }

        public static ConfigurationBuilder<T> AsXmlFormat<T>(this ConfigurationBuilder<T> builder)
        {
            builder.Processor = new XmlProcessor<T>();
            return builder;
        }
    }
}
