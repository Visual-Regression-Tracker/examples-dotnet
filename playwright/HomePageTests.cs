using VisualRegressionTracker;

public class HomePageTests
{
    [Test]
    public async Task HomePageMatchesBaseline()
    {
        var page = await TestSession.Browser.NewPageAsync(new() { ViewportSize = new() { Width = 1280, Height = 720 } });
        await page.GotoAsync("https://the-internet.herokuapp.com/");
        var screenshot = await page.ScreenshotAsync(new() { FullPage = true });

        var result = await TestSession.Vrt.Track(
            "Home page",
            screenshot,
            browser: TestSession.Browser.BrowserType.Name,
            viewport: "1280x720");

        TestContext.Out.WriteLine($"{result.Status}: {result.Url}");
        Assert.That(result.Status, Is.AnyOf(TestRunStatus.Ok, TestRunStatus.Approved, TestRunStatus.AutoApproved));
    }
}
