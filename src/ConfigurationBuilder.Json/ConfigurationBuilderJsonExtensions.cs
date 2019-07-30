using ConfigurationBuilder.Json.Processors;

namespace ConfigurationBuilder
{
    public static class ConfigurationBuilderJsonExtensions
    {
        public static ConfigurationBuilder<T> AsJsonFormat<T>(this ConfigurationBuilder<T> builder)
        {
            builder.Processor = new JsonProcessor<T>();
            return builder;
        }
    }
}
