using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Linq;

namespace SauceDemoTests
{
    public class OrderTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void MakeOrderWithTotalBetween30And60()
        {
            Login("standard_user", "secret_sauce");
            AddItemsToBasket(3);

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            var itemPrices = driver.FindElements(By.ClassName("inventory_item_price"))
                                   .Select(e => decimal.Parse(e.Text.Replace("$", "")))
                                   .ToList();

            decimal total = itemPrices.Sum();
            Assert.IsTrue(total >= 30 && total <= 60, $"Total is {total}, which is not between $30 and $60.");

            Checkout();

            Assert.IsTrue(driver.PageSource.Contains("Thank you for your order!"), "Order confirmation message not found.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
