using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ConfigurationBuilder.Json.Processors
{
    public class JsonProcessor<T> : IContentProcessor<T>
    {
        public T ProcessContent(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public T MergeContents(params string[] contents)
        {
            if (contents.Length < 1)
                return default;

            var mergedJson = JObject.Parse(contents.First());

            foreach (var content in contents.Skip(1))
            {
                var json = JObject.Parse(content);

                mergedJson.Merge(json, new JsonMergeSettings
                {
                    MergeArrayHandling = MergeArrayHandling.Union
                });
            }

            return mergedJson.ToObject<T>();
        }
    }
}
