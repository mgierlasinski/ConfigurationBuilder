namespace Configuration.Library.Config
{
    public interface IClientConfiguration
    {
        string Authority { get; }
        string ClientId { get; }
        string ClientSecret { get; }
        string Description { get; }
    }
}
