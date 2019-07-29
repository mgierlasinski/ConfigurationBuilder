using System.Threading.Tasks;

namespace ConfigurationBuilder
{
    public interface IContentProcessor<T>
    {
        T ProcessContent(string content);

        Task<T> ProcessContentAsync(string content);
    }
}
