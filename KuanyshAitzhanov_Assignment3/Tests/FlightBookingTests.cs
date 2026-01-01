using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace KuanyshAitzhanov_Assignment3.Tests;

public class FlightBookingTests : BaseUiTest
{
    [Test]
    public void BlazeDemo_ShouldBookFlight_WithTitleCheckpoint()
    {
        Driver.Navigate().GoToUrl("https://blazedemo.com/");

        var fromSelect = new SelectElement(WaitVisible(By.CssSelector("select[name='fromPort']")));
        fromSelect.SelectByText("Boston");

        var toSelect = new SelectElement(WaitVisible(By.CssSelector("select[name='toPort']")));
        toSelect.SelectByText("New York");

        WaitClickable(By.XPath("//input[@type='submit' and @value='Find Flights']")).Click();

        var heading = WaitVisible(By.CssSelector("h3"));
        Assert.That(heading.Text, Does.Contain("Flights from Boston to New York"));

        WaitClickable(By.CssSelector("table tbody tr:nth-child(1) input[type='submit']")).Click();

        WaitVisible(By.Id("inputName")).SendKeys("Куаныш Айтжанов");
        WaitVisible(By.Id("address")).SendKeys("Толе Би");
        WaitVisible(By.Id("city")).SendKeys("Астана");
        WaitVisible(By.Id("state")).SendKeys("Казахстан");
        WaitVisible(By.Id("zipCode")).SendKeys("010000");

        new SelectElement(WaitVisible(By.Id("cardType"))).SelectByText("Visa");
        WaitVisible(By.Id("creditCardNumber")).SendKeys("1231231231231234");
        WaitVisible(By.Id("creditCardMonth")).Clear();
        WaitVisible(By.Id("creditCardMonth")).SendKeys("12");
        WaitVisible(By.Id("creditCardYear")).Clear();
        WaitVisible(By.Id("creditCardYear")).SendKeys("2026");
        WaitVisible(By.Id("nameOnCard")).SendKeys("Kuanysh Aitzhanov");

        WaitClickable(By.XPath("//input[@type='submit' and @value='Purchase Flight']")).Click();

        Assert.That(Driver.Title, Does.Contain("BlazeDemo"));

        var success = WaitVisible(By.CssSelector("h1"));
        Assert.That(success.Text, Is.EqualTo("Thank you for your purchase today!"));
    }
}
