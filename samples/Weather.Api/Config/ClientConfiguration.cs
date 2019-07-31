namespace Weather.Api.Config
{
    public class ClientConfiguration : IClientConfiguration
    {
        public string ApiUrl { get; set; }
        public string ApiVersion { get; set; }
        public string AppId { get; set; }
    }
}
