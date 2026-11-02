# Playwright + NUnit

[HomePageTests.cs](HomePageTests.cs) takes a full-page screenshot with [Playwright for .NET](https://playwright.dev/dotnet/) and tracks it with Visual Regression Tracker. [TestSession.cs](TestSession.cs) starts one VRT build before the tests and stops it after them, also when a test fails.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) (pinned in [global.json](../global.json))
- [PowerShell](https://learn.microsoft.com/powershell/scripting/install/installing-powershell) to install the Playwright browser
- A running Visual Regression Tracker 6.0 server and its API key

## Setup

- Copy `vrt.json.example` to `vrt.json` and set your connection, or use the [`VRT_*` environment variables](https://github.com/Visual-Regression-Tracker/sdk-dotnet#or-as-environment-variables), which override the file
- Build the project: `dotnet build`
- Install the browser: `pwsh bin/Debug/net10.0/playwright.ps1 install --only-shell chromium`

## Run

```sh
dotnet test --output detailed
```

## What to expect

`enableSoftAssert` is on, as in the other examples: the SDK writes a failed check to stderr instead of throwing, so the test passes and prints the status and a link to the test run.

- First run: `New`, with `No baseline` on stderr. The VRT UI shows a build with one new test run, "Home page". Approve it to make it the baseline for the branch.
- Next runs: `Ok` while the page looks the same. When it changes, `Unresolved`, with `Difference found` on stderr, and the build shows the diff to approve or reject.

Set `enableSoftAssert` to `false` to make `New` and `Unresolved` fail the test.
