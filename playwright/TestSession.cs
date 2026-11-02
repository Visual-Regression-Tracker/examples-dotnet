using Microsoft.Playwright;
using Tracker = VisualRegressionTracker.VisualRegressionTracker;

[SetUpFixture]
public class TestSession
{
    private static IPlaywright? playwright;

    public static IBrowser Browser { get; private set; } = null!;

    public static Tracker Vrt { get; private set; } = null!;

    [OneTimeSetUp]
    public async Task Start()
    {
        playwright = await Playwright.CreateAsync();
        Browser = await playwright.Chromium.LaunchAsync();

        Vrt = new Tracker();
        await Vrt.Start();
    }

    [OneTimeTearDown]
    public async Task Stop()
    {
        try
        {
            if (Vrt?.IsStarted == true)
            {
                await Vrt.Stop();
            }
        }
        finally
        {
            Vrt?.Dispose();
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }
            playwright?.Dispose();
        }
    }
}
