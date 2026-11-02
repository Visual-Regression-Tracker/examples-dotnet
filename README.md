# Visual Regression Tracker examples for .NET

Each folder is a separate project with its own `.csproj`, `vrt.json.example` and README, on [sdk-dotnet](https://github.com/Visual-Regression-Tracker/sdk-dotnet) 5.0.0 from NuGet and .NET 10. The examples open https://the-internet.herokuapp.com headless and track screenshots in a [Visual Regression Tracker](https://github.com/Visual-Regression-Tracker/Visual-Regression-Tracker) 6.0 server.

| Example                  | Stack                      | Client                                                                |
| ------------------------ | -------------------------- | --------------------------------------------------------------------- |
| [playwright](playwright) | Playwright for .NET, NUnit | [sdk-dotnet](https://github.com/Visual-Regression-Tracker/sdk-dotnet) |

The examples connect with `vrt.json` or `VRT_*` environment variables, the way [sdk-dotnet reads its configuration](https://github.com/Visual-Regression-Tracker/sdk-dotnet#configure-connection). `vrt.json.example` holds the URL, API key and project of a fresh local install; copy it to `vrt.json` and change what differs.

CI runs every example against a VRT server started from [.github/vrt/docker-compose.yml](.github/vrt/docker-compose.yml).
