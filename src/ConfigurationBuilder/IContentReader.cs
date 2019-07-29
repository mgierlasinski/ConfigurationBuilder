using System.Threading.Tasks;

namespace ConfigurationBuilder
{
    public interface IContentReader
    {
        string ReadContent();

        Task<string> ReadContentAsync();
    }
}
