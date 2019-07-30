namespace ConfigurationBuilder.Tests.Config.Yaml
{
    public class ConfigurationYaml : IConfiguration
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
