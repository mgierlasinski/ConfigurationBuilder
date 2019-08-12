namespace ConfigurationBuilder
{
    public class ConfigurationBuilder<T>
    {
        public IContentReader Reader { get; set; }
        public IContentProcessor<T> Processor { get; set; }

        public T Build()
        {
            var content = Reader.ReadContent();
            return Processor.ProcessContent(content);
        }

        public T BuildForEnvironment(string environment)
        {
            var content = Reader.ReadContent();
            var envContent = Reader.ReadContent(environment);

            return Processor.MergeContents(content, envContent);
        }
    }
}
