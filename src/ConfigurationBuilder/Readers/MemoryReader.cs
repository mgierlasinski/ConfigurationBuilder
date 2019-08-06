namespace ConfigurationBuilder.Readers
{
    public class MemoryReader : IContentReader
    {
        private readonly string _content;

        public MemoryReader(string content)
        {
            _content = content;
        }

        public string ReadContent()
        {
            return _content;
        }

        public string ReadContentForEnvironment(string environment)
        {
            return _content;
        }
    }
}
