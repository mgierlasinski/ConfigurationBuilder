using Newtonsoft.Json;

namespace Weather.Api.Models.Contracts
{
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}
