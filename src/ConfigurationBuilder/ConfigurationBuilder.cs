namespace ConfigurationBuilder
{
    public class ConfigurationBuilder<T>
    {
        public IContentReader Reader { get; set; }
        public IContentProcessor<T> Processor { get; set; }

        public T Build()
        {
            return Processor.ProcessContent(Reader);
        }

        public T BuildForEnvironment(string environment)
        {
            return Processor.ProcessContentForEnvironment(Reader, environment);
        }
    }
}
