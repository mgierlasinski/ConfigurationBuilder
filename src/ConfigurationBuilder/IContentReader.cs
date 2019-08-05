namespace ConfigurationBuilder
{
    public interface IContentReader
    {
        string ReadContent();

        string ReadContentForEnvironment(string environment);
    }
}
