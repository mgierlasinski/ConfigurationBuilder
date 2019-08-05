using System.IO;

namespace ConfigurationBuilder
{
    public class FileNameHandler : IFileNameHandler
    {
        public string GetFilePathForEnvironment(string path, string environment)
        {
            var directory = Path.GetDirectoryName(path);
            var fileName = Path.GetFileNameWithoutExtension(path);
            var extension = Path.GetExtension(path);

            return Path.Combine(directory, $"{fileName}.{environment}{extension}");
        }
    }
}
