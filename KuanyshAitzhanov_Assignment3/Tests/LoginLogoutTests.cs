using NUnit.Framework;
using OpenQA.Selenium;

namespace KuanyshAitzhanov_Assignment3.Tests;

public class LoginLogoutTests : BaseUiTest
{
    [Test]
    public void Login_And_Logout_ShouldWork()
    {
        Driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

        WaitVisible(By.XPath("//input[@id='username']")).SendKeys("tomsmith");
        WaitVisible(By.XPath("//input[@id='password']")).SendKeys("SuperSecretPassword!");
        WaitClickable(By.XPath("//button[@type='submit']")).Click();

        var flash = WaitVisible(By.CssSelector("#flash"));
        Assert.That(flash.Text, Does.Contain("You logged into a secure area!"));

        WaitClickable(By.CssSelector("a.button.secondary.radius")).Click();

        var loginBtn = WaitVisible(By.CssSelector("button[type='submit']"));
        Assert.That(loginBtn.Displayed, Is.True);
    }
}
