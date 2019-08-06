using ConfigurationBuilder.Tests.Config;

namespace ConfigurationBuilder.Tests.TestData
{
    public static class ConfigurationTestData
    {
        public static IConfiguration GetExpected() => new Configuration
        {
            ApiUrl = "https://test.domain.com",
            ApiVersion = "1.0",
            ClientId = "api_client",
            ClientSecret = "zdFpegWRoCac2dPQpPn1"
        };
    }
}
