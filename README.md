# Cross platform builder for configuration files

&nbsp; | ConfigurationBuilder | ConfigurationBuilder.Json | ConfigurationBuilder.Yaml
--- | --- | --- | ---
NuGet | [![Nuget](https://img.shields.io/nuget/v/ConfigurationBuilder)](https://www.nuget.org/packages/ConfigurationBuilder) | [![Nuget](https://img.shields.io/nuget/v/ConfigurationBuilder.Json)](https://www.nuget.org/packages/ConfigurationBuilder.Json) | [![Nuget](https://img.shields.io/nuget/v/ConfigurationBuilder.Yaml)](https://www.nuget.org/packages/ConfigurationBuilder.Yaml)


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
Merge files | ❌ | ✔️ | ✔️

## Samples

### Setup builder

```c#
var builder = new ConfigurationBuilder<Configuration>()
    .Setup(x =>
    {
        x.Reader = new MyCustomReader();
        x.Processor = new MyCustomProcessor();
    });
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

- Client.cs 

Read basic configuration, only `Configuration.json` will be processed.

```c#
var configuration = new ConfigurationBuilder<Configuration>()
    .FromFile("Path\\To\\Configuration.json")
    .AsJsonFormat()
    .Build();
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

### Merge multiple configuration files

You can create environment specific configuration that will extend or override properties from base file. If you want to make changes for development setup, create file following convetion:

`{BaseFile}.{Environment}.{Format}`

You can provide custom convention by implementing `IFileNameHandler` and passing it as option to `FromResource()` or `FromFile()` extension, depending on reading method.

To override `Clientsecret` from `Configuration.json` on `dev` evironment create file `Configuration.dev.json` with the following content:

``` json
{
  "ClientSecret": "MhYzHEnEUGhuvMRdWcqo"
}
```

Use `BuildForEnvironment()` to build configuration combining files `Configuration.json` and `Configuration.dev.json`.

```c#
var configuration = new ConfigurationBuilder<Configuration>()
    .FromFile("Path\\To\\Configuration.json")
    .AsJsonFormat()
    .BuildForEnvironment("dev");
```

---
Original icon made by [devendra karkar](https://www.iconfinder.com/dev-patel) from [icon-icons.com](https://icon-icons.com/) is licensed by [CC 4.0 BY](https://creativecommons.org/licenses/by/4.0/)