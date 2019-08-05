namespace ConfigurationBuilder.Tests.Config
{
    public class Configuration : IConfiguration
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
