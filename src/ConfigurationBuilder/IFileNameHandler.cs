namespace ConfigurationBuilder
{
    public interface IFileNameHandler
    {
        string GetFilePathForEnvironment(string filePath);
    }
}
