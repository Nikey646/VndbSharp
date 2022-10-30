# VndbSharp
A C# [Vndb](https://vndb.org/) API Library. #OriginalNamingScheme

VndbSharp is a C# library for the Visual Novel Database TCP API
  - Supports TLS (Secure Connections)
  - Support for most filters and flags at this time
  - Easily Extensible

# Future of Project
Due to lack of interest in Visual Novels at this point in time, I have no active or maintained projects using this library. This unfortunately means that unless a bug is reported, there will be no future development on the library.

With the release of the HTTPS Api, when the TCP Api is shutdown and I become aware I will publicly archive this project. Until then, as per https://github.com/Nikey646/VndbSharp/issues/83#issuecomment-1296278655, I am happy to assist in the development of a replacement API via discussion or accepting PRs.

## Usage
Check out the [VndbConsole projects](VndbConsoleCore/Program.cs) for basic usage guidance. The one `Program.cs` file is used for both the .Net Framework and .Net Core projects, but works in both. This shows that the library can be used from either the .Net Framework (4.6+) or .Net Core (.Net Standard 1.3+)

## Building
To build the project you need to use Visual Studio 2017 RC3 or newer.

## Supported Filters
 - Id
 - Alias Id
 - User Id
 - First Character (Letter)
 - Released
 - Language(s)
 - Original Name
 - Original Language(s)
 - Platform(s)
 - Search
 - Tag(s)
 - Trait(s)
 - Title
 - Name 
 - Username
 - Visual Novel

## TODO
There is no guarantee that anything listed on this will be implemented.

  - [ ] Work on the Read Me
  - [X] Provide a default RequestOptions class
  - [ ] ~~Wiki everything!~~ Document everything (public)!
  - [ ] Nuget package (Github actions now builds a version of VndbSharp)

## API Version
Updated to Vndb 2020-07-09 API version  
The command "set ulist" has not been added, because it is experimental
