namespace ConfigurationBuilder.Tests.Config
{
    public class Configuration : IConfiguration
    {
        public string ApiUrl { get; set; }
        public string ApiVersion { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
