# extensions-configuration

Exposes configuration factory including legacy xml files support.

 | Package | NuGet |
 | ------- | ----- |
 | Extensions.Configuration.Factory | [![Nuget](https://img.shields.io/badge/nuget-v2.1.0-blue) ![Nuget](https://img.shields.io/nuget/dt/Extensions.Configuration.Factory)](https://www.nuget.org/packages/Extensions.Configuration.Factory/2.1.0) |

## Installation

It is available on Nuget.

```
Install-Package Extensions.Configuration.Factory -Version 2.1.0
```

## Usage

The following code demonstrates basic usage of configuration factory.

appsettings.json:
```JSON
{ 
 "ParentKey" : {
   "ChildKey" : "xxx"
 }
}
```

App/Web.Config:
```XML
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="ParentKey:ChildKey" value="xxx" />
  </appSettings>
</configuration>
```

```C#
var config = ConfigurationFactory.Instance.GetConfiguration();
var value = config["ParentKey:ChildKey"];
```

## Support / Contributing
If you want to help with the project, feel free to open pull requests and submit issues. 

## Donate

If you would like to show your support for this project, then please feel free to buy me a coffee.

<a href="https://www.buymeacoffee.com/fernandolima" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/white_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a>
