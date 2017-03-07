# ConfigurationManager
Reads the appsettings file and binds the values to any given data transfer object.
## Intention
In json formatted appsetting files a less formatted and flattened structure is more human readable than a complex, specially designed and 	hierarchically build file. As an example compare the excerpt from two files:
```json
"editor":
{
  "Font":
  {
    "Size":"12",
    "Type":"Menlo"
  }
}
```
and simplified:
```json
"editor.Font.Size":"12",
"editor.Font.Type":"Menlo",
```
## Pro and Cons
### Pro
* the simplified format is better readable
* writing the simplified format is much easier

### Cons
* the simplified format is less structured (as intended)
* the properties / data does not have to be ordered
* the needed data size to store the file is bigger

## Initialization
Before using the configuration manager, an initialization to the appsettings file is needed. Two methods provides the needed functionality:
1. 'void Initialize(IConfigurationBuilder builder)' for using within a ASP.Net context with already created configuration builder.
2. 'void Initialize(IHostingEnvironment env, string settingsFile)' for initializing with an environment and a settings file.
3. 'void Initialize(IConfigurationRoot)' for using within an already initialized context.
## Using
The appsettings content reflect the internal data structure of the used configuration objects:
```c#
class Configuration
{
  public int FontSize { get; set; }
  public string FontType { get; set; }
}
```
Reflected to the appsettings file:
```json
"config.FontSize":"12",
"config.FontType":"Menlo"
```
Bind in a startup class:
```c#
Configuration data = new Configuration();
ConfigurationManager.Manager.Bind<Configuration>("config", data);
```
### Complex configuration
The configuration can be bound to a complex configuration structure:
```c#
class Font
{
  public int Size { get; set; }
  public string Type { get; set; }
}

class Configuration
{
  public Font Font { get; set; }
  
  public Configuration()
  {
    Font = new Font();
  }
}
```
Reflected to the appsettings file:
```json
"config.Font.Size":"12",
"config.Font.Type":"Menlo"
```
Bind in a startup class:
```c#
Configuration data = new Configuration();
ConfigurationManager.Manager.Bind<Configuration>("config", data);
```
### Attention
The configuration manager does not create instances of sub class or complex properties.
