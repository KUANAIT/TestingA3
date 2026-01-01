using NUnit.Framework;
using OpenQA.Selenium;

namespace KuanyshAitzhanov_Assignment3.Tests;

public class SearchTests : BaseUiTest
{
    [Test]
    public void Wikipedia_Search_ShouldOpenExpectedArticle()
    {
        Driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");
        TryAcceptCommonConsents();

        var searchInput = WaitVisible(By.CssSelector("input#searchInput"));
        searchInput.Clear();
        searchInput.SendKeys("Казахстан" + Keys.Enter);

        var heading = WaitVisible(By.CssSelector("h1#firstHeading"));
        Assert.That(heading.Text, Does.Contain("Kazakhstan"));
    }
}
