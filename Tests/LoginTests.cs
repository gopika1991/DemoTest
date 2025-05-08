using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SauceDemoTests
{
    public class LoginTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void VerifyLoginTakesToProductsPage()
        {
            Login("standard_user", "secret_sauce");
            Assert.IsTrue(driver.Url.Contains("inventory"), "User was not redirected to the products page.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}