namespace ConfigurationBuilder
{
    public interface IContentProcessor<T>
    {
        T ProcessContent(string content);

        T ProcessMultipleContents(params string[] contents);
    }
}
