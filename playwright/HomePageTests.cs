public class HomePageTests
{
    [Test]
    public async Task TrackHomePage()
    {
        await using var context = await TestSession.Browser.NewContextAsync();
        var page = await context.NewPageAsync();
        await page.GotoAsync("https://the-internet.herokuapp.com/");
        var screenshot = await page.ScreenshotAsync(new() { FullPage = true });

        var result = await TestSession.Vrt.Track(
            "Home page",
            screenshot,
            browser: TestSession.Browser.BrowserType.Name,
            viewport: $"{page.ViewportSize!.Width}x{page.ViewportSize.Height}");

        TestContext.Out.WriteLine($"{result.Status}: {result.Url}");
    }
}
