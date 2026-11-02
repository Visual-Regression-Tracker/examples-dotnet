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
dotnet test
```

## What to expect

- First run: the test fails with `No baseline` and a link to the test run. The VRT UI shows a build with one `New` test run, "Home page".
- Approve it in the UI. It becomes the baseline for the branch.
- Next runs pass while the page looks the same (`Ok`). When it changes, the test fails with `Difference found` and the build shows an `Unresolved` test run with the diff. Approve the change to make it the new baseline, or reject it.

`New` and `Unresolved` fail the test; `Ok`, `Approved` and `AutoApproved` pass. With `enableSoftAssert`, the SDK writes the failure to stderr instead of throwing, and the status assertion in the test fails it.
