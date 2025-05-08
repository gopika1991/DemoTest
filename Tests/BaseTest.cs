// filepath: c:\Tests\Tests\BaseTest.cs
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SauceDemoTests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        protected void WaitForElement(By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        protected void Login(string username, string password)
        {
            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Id("password")).SendKeys(password);
            driver.FindElement(By.Id("login-button")).Click();
        }

        protected void AddItemsToBasket(int itemCount)
        {
            var addToCartButtons = driver.FindElements(By.ClassName("btn_inventory"));
            for (int i = 0; i < itemCount && i < addToCartButtons.Count; i++)
            {
                addToCartButtons[i].Click();
            }
        }

        protected void Checkout()
        {
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.Id("first-name")).SendKeys("Test");
            driver.FindElement(By.Id("last-name")).SendKeys("User");
            driver.FindElement(By.Id("postal-code")).SendKeys("12345");
            driver.FindElement(By.Id("continue")).Click();
            driver.FindElement(By.Id("finish")).Click();
        }
    }
}