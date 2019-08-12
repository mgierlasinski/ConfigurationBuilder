using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace ConfigurationBuilder.Json.Processors
{
    public class JsonProcessor<T> : IContentProcessor<T>
    {
        public T ProcessContent(IContentReader reader)
        {
            T result;

            using (var stream = reader.OpenStream())
            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                var serializer = new JsonSerializer();
                result = (T)serializer.Deserialize(streamReader, typeof(T));
            }

            return result;
        }

        public T ProcessContentForEnvironment(IContentReader reader, string environment)
        {
            JObject baseObject;
            JObject envObject;

            using (var stream = reader.OpenStream())
            {
                baseObject = GetJObjectFromStream(stream);
            }

            using (var stream = reader.OpenStream(environment))
            {
                envObject = GetJObjectFromStream(stream);
            }

            baseObject.Merge(envObject, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });

            return baseObject.ToObject<T>();
        }

        private JObject GetJObjectFromStream(Stream stream)
        {
            JObject json;

            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            using (JsonTextReader reader = new JsonTextReader(streamReader))
            {
                json = (JObject)JToken.ReadFrom(reader);
            }

            return json;
        }
    }
}
