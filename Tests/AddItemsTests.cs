using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace SauceDemoTests
{
    public class AddItemsTests : BaseTest
    {
        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [Test]
        public void AddThreeItemsAndBuyTwo()
        {
            Login("standard_user", "secret_sauce");
            AddItemsToBasket(3);

            driver.FindElement(By.ClassName("shopping_cart_link")).Click();

            var removeButtons = driver.FindElements(By.ClassName("cart_button"));
            if (removeButtons.Count > 0)
            {
                removeButtons[0].Click(); // Remove 1 item
            }

            var cartItems = driver.FindElements(By.ClassName("cart_item"));
            Assert.AreEqual(2, cartItems.Count, "Expected 2 items in the cart.");

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
