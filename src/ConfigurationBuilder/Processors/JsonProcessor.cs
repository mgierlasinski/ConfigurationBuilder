using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ConfigurationBuilder.Processors
{
    public class JsonProcessor<T> : IContentProcessor<T>
    {
        public T ProcessContent(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public Task<T> ProcessContentAsync(string content)
        {
            return Task.FromResult(ProcessContent(content));
        }
    }
}
