using VisualRegressionTracker;

public class HomePageTests
{
    [Test]
    public async Task HomePageMatchesBaseline()
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
        Assert.That(result.Status, Is.AnyOf(TestRunStatus.Ok, TestRunStatus.Approved, TestRunStatus.AutoApproved));
    }
}
