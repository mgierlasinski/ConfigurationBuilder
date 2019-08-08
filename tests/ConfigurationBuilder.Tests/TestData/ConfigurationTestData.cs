using ConfigurationBuilder.Tests.Config;
using System.Collections.Generic;

namespace ConfigurationBuilder.Tests.TestData
{
    public static class ConfigurationTestData
    {
        public static IEnumerable<object[]> EnvironmentConfiguration => new List<object[]>
        {
            new object[] { "dev", GetExpected(clientId: "api_client_dev", clientSecret: "client_secret_dev") },
            new object[] { "prod", GetExpected(clientId: "api_client_prod", clientSecret: "client_secret_prod") }
        };

        public static IConfiguration GetExpected(string apiUrl = null, string apiVersion = null, string clientId = null,
            string clientSecret = null) => new Configuration
        {
            ApiUrl = apiUrl ?? "https://test.domain.com",
            ApiVersion = apiVersion ?? "1.0",
            ClientId = clientId ?? "api_client",
            ClientSecret = clientSecret ?? "zdFpegWRoCac2dPQpPn1"
        };
    }
}
