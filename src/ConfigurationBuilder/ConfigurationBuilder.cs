namespace ConfigurationBuilder
{
    public class ConfigurationBuilder<T>
    {
        public IContentReader Reader { get; set; }
        public IContentProcessor<T> Processor { get; set; }
        public IFileNameHandler FileNameHandler { get; set; } = new FileNameHandler();

        public T Build()
        {
            var content = Reader.ReadContent();
            return Processor.ProcessContent(content);
        }

        public T BuildForEnvironment(string environment)
        {
            var content = Reader.ReadContent();
            var envContent = Reader.ReadContentForEnvironment(environment);

            return Processor.ProcessMultipleContents(content, envContent);
        }
    }
}
