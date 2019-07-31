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

## Samples

### Reading xml configuration

``` xml
<?xml version="1.0" encoding="UTF-8"?>
<Configuration xmlns="http://www.contoso.com">
  <Authority>https://test.domain.com</Authority>
  <ClientId>api_client</ClientId>
  <ClientSecret>zdFpegWRoCac2dPQpPn1</ClientSecret>
</Configuration>
```

```c#
 var configuration = new ConfigurationBuilder<Configuration>()
    .FromResource("Full.Namespace.Of.Configuration.xml")
    .AsXmlFormat()
    .Build();
```

### Reading json configuration

``` json
{
  "Authority": "https://test.domain.com",
  "ClientId": "api_client",
  "ClientSecret": "zdFpegWRoCac2dPQpPn1"
}
```

```c#
var configuration = new ConfigurationBuilder<Configuration>()
    .FromFile("Path\\To\\Configuration.json")
    .AsJsonFormat()
    .Build();
```

### Reading yaml configuration

``` yaml
---
authority: https://test.domain.com
clientId: api_client
clientSecret: zdFpegWRoCac2dPQpPn1
```

```c#
var configuration = new ConfigurationBuilder<Configuration>()
    .FromFile("Path\\To\\Configuration.yaml")
    .AsYamlFormat()
    .Build();
```