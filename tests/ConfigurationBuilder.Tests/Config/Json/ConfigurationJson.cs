namespace ConfigurationBuilder.Tests.Config.Json
{
    public class ConfigurationJson : IConfiguration
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
