using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace KuanyshAitzhanov_Assignment3.Tests;

public abstract class BaseUiTest
{
    protected IWebDriver? Driver;
    protected WebDriverWait? Wait;

    [SetUp]
    public void SetUp()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());

        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");

        Driver = new ChromeDriver(options);
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
    }

    [TearDown]
    public void TearDown()
    {
        try { Driver?.Quit(); } catch { }
        try { Driver?.Dispose(); } catch { }
    }

    protected IWebElement WaitVisible(By by) =>
        Wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));

    protected IWebElement WaitClickable(By by) =>
        Wait!.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));

    protected void TryAcceptCommonConsents()
    {
        TryClickIfExists(By.CssSelector("button#accept-cookie-policy, button#wm-accept"));
        TryClickIfExists(By.XPath("//button[contains(.,'Accept') or contains(.,'I agree') or contains(.,'Agree')]"));
        TryClickIfExists(By.CssSelector("button[aria-label='Accept all'], button[title='Accept all']"));
        TryClickIfExists(By.XPath("//button[contains(.,'Accept all') or contains(.,'Accept All')]"));
    }

    protected bool TryClickIfExists(By by, int seconds = 2)
    {
        try
        {
            var shortWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
            var el = shortWait.Until(d =>
            {
                var e = d.FindElements(by).FirstOrDefault();
                return (e != null && e.Displayed && e.Enabled) ? e : null;
            });

            el?.Click();
            return el != null;
        }
        catch
        {
            return false;
        }
    }
}
