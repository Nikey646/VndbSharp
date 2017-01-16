# VndbSharp
A C# [Vndb](https://vndb.org/) API Library. #OriginalNamingScheme

VndbSharp is a C# library for the Visual Novel Database API

  - Supports TLS (Secure Login)
  - Support for most filters and flags at this time (Jan 2017, Api version 2.27)
  - Easily Extendible

### Mono and .Net Core Usage Warning
Monos current [SecureString](https://github.com/mono/mono/blob/master/mcs/class/corlib/System.Security/SecureString.cs) implementation, as of Jan 2017, does [not encrypt](https://github.com/mono/mono/blob/master/mcs/class/corlib/System.Security/SecureString.cs#L249-L264) the string in memory, making it insecure compared to the windows version. It is advisable to warn any users, or not provide login capabilities when using this library.

.Net Core has stated that [it will not encrypt](https://github.com/dotnet/coreclr/blob/master/src/mscorlib/corefx/System/Security/SecureString.Unix.cs#L18) the data, which presents a similar issue to mono.

It should be noted, that due to requiring the password to be sent in plain text (over a secure TLS connection), the password is restored to a plain string form to be placed into the JSON payload, meaning there are chances the benefits from SecureString are ignored, so this is not a vital issue.

## Examples
Here's an example of how to use this library's commands:

```csharp
var client = new VndbClient();
var requestFlags = VndbFlags.Basic | VndbFlags.Details | VndbFlags.Anime | VndbFlags.Tags | VndbFlags.Stats | VndbFlags.Screens | VndbFlags.Relations;
var result = await client.GetVisualNovelAsync(requestFlags, FilterId.FromEquals(17));
```

## TODO
  - [x] The various "set" commands.
  - [x] Retrieving Tag, Trait and Vote Dumps and providing Models (Will not store this information)
  - [x] Better Error Handling.
  - [ ] .Net Core / .Net Standard support
  - [ ] Restructure the Models to reduce repeated data
  - [ ] Wiki everything!
  - [ ] Nuget package?
