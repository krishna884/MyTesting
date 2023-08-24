using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProj_RahulShetty
{
    class E2ETest
    {
        IWebDriver driver;
        [SetUp]
        public void browserStart()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver=new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void Endtoendtest()
        {
            String indiacountry = "India";
            String[] excepectedproducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
            driver.FindElement(By.XPath("//*[contains(@id,'username')]")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.XPath("//div[@class='form-group'][2]//input")).SendKeys("learning");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]//input[@id='signInBtn']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            IList<IWebElement> products= driver.FindElements(By.TagName("app-card"));

            foreach (IWebElement product in products)
            {
                if(excepectedproducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click() ;
                }


                TestContext.Progress.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click();

            IList<IWebElement> items= driver.FindElements(By.CssSelector("h4 a"));
            for (int i=0; i<items.Count; i++)
            {
                actualProducts [i]=items[i].Text;
            }
            Assert.AreEqual(excepectedproducts, actualProducts);

            driver.FindElement(By.CssSelector(".btn-success")).Click();

            driver.FindElement(By.Id("country")).SendKeys("ind");
            //Thread.Sleep(6000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));

            /*IList<IWebElement> countries = driver.FindElements(By.XPath("//div[@class='suggestions']//li//a"));

            foreach (IWebElement country in countries)
            {
                if(indiacountry.Contains(country.Text))
                {
                    country.Click();
                }
            }*/

            driver.FindElement(By.XPath("//div[@class='suggestions']/ul[1]/li/a")).Click();
        }
    }
}
