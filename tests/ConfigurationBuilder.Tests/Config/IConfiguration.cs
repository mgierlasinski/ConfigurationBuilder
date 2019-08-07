namespace ConfigurationBuilder.Tests.Config
{
    public interface IConfiguration
    {
        string ApiUrl { get; set; }
        string ApiVersion { get; set; }
        string ClientId { get; set; }
        string ClientSecret { get; set; }
    }
}
