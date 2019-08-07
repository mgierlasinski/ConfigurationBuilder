using System.Runtime.Serialization;

namespace ConfigurationBuilder.Tests.Config.Xml
{
    [DataContract(Name = "Configuration", Namespace = "http://www.contoso.com")]
    public class ConfigurationXml : IConfiguration
    {
        [DataMember]
        public string ApiUrl { get; set; }

        [DataMember]
        public string ApiVersion { get; set; }

        [DataMember]
        public string ClientId { get; set; }

        [DataMember]
        public string ClientSecret { get; set; }
    }
}
