namespace ConfigurationBuilder.Tests.Config
{
    public interface IConfiguration
    {
        string Authority { get; }
        string ClientId { get; }
        string ClientSecret { get; }
    }
}
