namespace ConfigurationBuilder
{
    public interface IContentProcessor<T>
    {
        T ProcessContent(IContentReader reader);

        T ProcessContentForEnvironment(IContentReader reader, string environment);
    }
}
