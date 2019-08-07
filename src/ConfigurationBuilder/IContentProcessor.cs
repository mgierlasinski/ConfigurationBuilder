namespace ConfigurationBuilder
{
    public interface IContentProcessor<T>
    {
        T ProcessContent(string content);

        T MergeContents(params string[] contents);
    }
}
