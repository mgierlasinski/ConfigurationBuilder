using Newtonsoft.Json;

namespace ConfigurationBuilder.Json.Processors
{
    public class JsonProcessor<T> : IContentProcessor<T>
    {
        public T ProcessContent(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public T ProcessMultipleContents(params string[] contents)
        {
            throw new System.NotImplementedException();
        }
    }
}
