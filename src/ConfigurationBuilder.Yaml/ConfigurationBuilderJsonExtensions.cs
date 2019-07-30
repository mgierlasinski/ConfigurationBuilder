using ConfigurationBuilder.Yaml.Processors;

namespace ConfigurationBuilder
{
    public static class ConfigurationBuilderYamlExtensions
    {
        public static ConfigurationBuilder<T> AsYamlFormat<T>(this ConfigurationBuilder<T> builder)
        {
            builder.Processor = new YamlProcessor<T>();
            return builder;
        }
    }
}
