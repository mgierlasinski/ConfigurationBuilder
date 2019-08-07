# Cross platform builder for configuration files

&nbsp; | ConfigurationBuilder | ConfigurationBuilder.Json | ConfigurationBuilder.Yaml
--- | --- | --- | ---
NuGet | [![Nuget](https://img.shields.io/nuget/v/ConfigurationBuilder)](https://www.nuget.org/packages/ConfigurationBuilder) | TODO | TODO

## Supported sources and formats

### Sources

- files copied to output - `FromFile()` extension
- files compiled as embedded resource - `FromResource()` extension
- memory content as string - `FromString()` extension

### Formats

&nbsp; | xml | json | yaml
--- | --- | ---| ---
Extension | `AsXmlFormat()` | `AsJsonFormat()` | `AsYamlFormat()`
Package | `ConfigurationBuilder` | `ConfigurationBuilder.Json` | `ConfigurationBuilder.Yaml`
Implementation | `DataContractSerializer` | `Newtonsoft.Json` | `YamlDotNet`
Environment configuration | ❌ | ✔️ | ❌

## Samples

### Setup builder

```c#
var builder = new ConfigurationBuilder<Configuration>()
    .Setup(x => x.FileNameHandler = new CustomFileNameHandler());
```

### Reading xml configuration

- Configuration.cs (add `DataContractSerializer` attributes for proper serialization)

``` c#
[DataContract(Name = "Configuration", Namespace = "http://www.contoso.com")]
public class Configuration : IConfiguration
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
```

- Configuration.xml

``` xml
<?xml version="1.0" encoding="UTF-8"?>
<Configuration xmlns="http://www.contoso.com">
  <ApiUrl>https://test.domain.com</ApiUrl>
  <ApiVersion>1.0</ApiVersion>
  <ClientId>api_client</ClientId>
  <ClientSecret>zdFpegWRoCac2dPQpPn1</ClientSecret>
</Configuration>
```

- Client.cs

``` c#
 var configuration = new ConfigurationBuilder<Configuration>()
    .FromResource("Full.Namespace.Of.Configuration.xml")
    .AsXmlFormat()
    .Build();
```

### Reading json configuration

- Configuration.json

``` json
{
  "ApiUrl": "https://test.domain.com",
  "ApiVersion": "1.0",
  "ClientId": "api_client",
  "ClientSecret": "zdFpegWRoCac2dPQpPn1"
}
```

- Configuration.dev.json (override for development environment)

``` json
{
  "ClientSecret": "MhYzHEnEUGhuvMRdWcqo"
}
```

- Client.cs 

Read basic configuration, only `Configuration.json` will be processed.

```c#
var configuration = new ConfigurationBuilder<Configuration>()
    .FromFile("Path\\To\\Configuration.json")
    .AsJsonFormat()
    .Build();
```

Process configuration for development enviroment, `Configuration.json` and `Configuration.dev.json` will be merged.

```c#
var configuration = new ConfigurationBuilder<Configuration>()
    .FromFile("Path\\To\\Configuration.json")
    .AsJsonFormat()
    .BuildEnvironment("dev");
```

### Reading yaml configuration

- Configuration.yaml

``` yaml
---
apiUrl: https://test.domain.com
apiVersion: 1.0
clientId: api_client
clientSecret: zdFpegWRoCac2dPQpPn1
```

- Client.cs

```c#
var configuration = new ConfigurationBuilder<Configuration>()
    .FromFile("Path\\To\\Configuration.yaml")
    .AsYamlFormat()
    .Build();
```