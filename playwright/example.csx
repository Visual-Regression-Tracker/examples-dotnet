#r "nuget: VisualRegressionTracker, 4.7.0"
#r "nuget: PlaywrightSharp, 0.162.1"

using System;
using PlaywrightSharp;
using VisualRegressionTracker;

{
    using var playwright = await Playwright.CreateAsync();
    await using var browser = await playwright.Chromium.LaunchAsync();
    var page = await browser.NewPageAsync();
    await page.GoToAsync("https://github.com/Visual-Regression-Tracker/sdk-dotnet/tree/main");
    var screenshot = await page.ScreenshotAsync();

    var vrt = new VisualRegressionTracker.VisualRegressionTracker();
    await using var cleanup = await vrt.Start();
    await vrt.Track("sdk-dotnet", screenshot);

    Console.WriteLine("Done");
}
