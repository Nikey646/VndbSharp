# VndbSharp
A C# Vndb API Library. #OriginalNamingScheme

VndbSharp is a C# library for the Visual Novel Database API

  - Supports TLS(Secure Login)
  - Support for most filters and flags at this time
  - Easily Extendible

### Examples
Here's an example of how to use this library's commands:

```csharp
var client = new VndbClient();
var requestFlags = VndbFlags.Basic | VndbFlags.Details | VndbFlags.Anime | VndbFlags.Tags | VndbFlags.Stats | VndbFlags.Screens | VndbFlags.Relations;
var result = await client.GetVisualNovel(requestFlags, new FilterId(17, FilterOperator.Equal));
```


Features that still need to be implemented:
  [ ] All of the "set" commands. Currently, VndbSharp can only get data, not set it
  [ ] Error support. Currently, it has no support for error messages at all
  [ ] Finding a way to deal with Mono's security issue(explained below)

##### Examples
Mono currently has no support for ProtectedMemory, and thus, TLS and use of SecureString should not be trusted.
https://github.com/mono/mono/blob/master/mcs/class/corlib/System.Security/SecureString.cs#L249-L264
