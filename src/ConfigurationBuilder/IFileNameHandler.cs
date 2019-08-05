namespace ConfigurationBuilder
{
    public interface IFileNameHandler
    {
        string GetFilePathForEnvironment(string path, string environment);
    }
}
