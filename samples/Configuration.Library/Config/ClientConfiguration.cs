namespace Configuration.Library.Config
{
    public class ClientConfiguration : IClientConfiguration
    {
        public string Authority { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Description { get; set; }
    }
}
