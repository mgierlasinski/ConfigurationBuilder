namespace Weather.Api.Config
{
    public interface IClientConfiguration
    {
        string ApiUrl { get; }
        string ApiVersion { get; }
        string AppId { get; }
    }
}
