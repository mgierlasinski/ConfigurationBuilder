# Cross platform builder for configuration files

&nbsp; | ConfigurationBuilder | ConfigurationBuilder.Json | ConfigurationBuilder.Yaml
--- | --- | --- | ---
NuGet | [![Nuget](https://img.shields.io/nuget/v/ConfigurationBuilder)](https://www.nuget.org/packages/ConfigurationBuilder) | [![Nuget](https://img.shields.io/nuget/v/ConfigurationBuilder.Json)](https://www.nuget.org/packages/ConfigurationBuilder.Json) | [![Nuget](https://img.shields.io/nuget/v/ConfigurationBuilder.Yaml)](https://www.nuget.org/packages/ConfigurationBuilder.Yaml)

## Sources

### Embedded resource

To process file with `Build Action` set to `Embedded Resource` call `FromResource()` extension. Optionally pass options of type `EmbeddedResourceReaderOptions` as a parameter to customize reading operation.

- Basic usage

``` c#
FromResource("Namespace.Of.Project.Config.Configuration.json")
```

- With options

``` c#
FromResource("Namespace.Of.Project.Config.Configuration.json", options => options
  .FromAssembly(assembly)
  .WithFileNameHandler(handler))
```

Available options:
- `FromAssembly` - pass custom assembly (when configuration file belongs to defferent assembly that it's c# class)
- `WithFileNameHandler` - define custom file handling convention

### File in storage

To process file with selected option `Copy to output` call `FromFile()` extension. Optionally pass options of type `FileReaderOptions` as a parameter to customize reading operation.

- Basic usage

``` c#
FromFile("Path\\To\\Configuration.json")
```

- With options

``` c#
FromFile("Path\\To\\Configuration.json", options => options
  .WithFileNameHandler(handler))
```

Available options:
- `WithFileNameHandler` - define custom file handling convention

### In-Memory content

- Basic usage

``` c#
FromString("{" + 
      "\"ApiUrl\": \"https://test.domain.com\", " +
      "\"ApiVersion\": \"1.0\", " +
      "\"ClientId\": \"api_client\", " + 
      "\"ClientSecret\": \"zdFpegWRoCac2dPQpPn1\" }")
```

## Formats

&nbsp; | xml | json | yaml
--- | --- | ---| ---
Extension | `AsXmlFormat()` | `AsJsonFormat()` | `AsYamlFormat()`
Package | `ConfigurationBuilder` | `ConfigurationBuilder.Json` | `ConfigurationBuilder.Yaml`
Implementation | `XmlSerializer` | `Newtonsoft.Json` | `YamlDotNet`
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

- Configuration.xml

``` xml
<?xml version="1.0" encoding="UTF-8"?>
<Configuration>
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

## Merge multiple configuration files

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