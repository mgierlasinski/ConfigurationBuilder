using Newtonsoft.Json;

namespace Weather.Api.Models.Contracts
{
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Deg { get; set; }
    }
}
