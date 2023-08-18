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
            String[] excepectedproducts = { "iphone X", "Blackberry" };
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
        }
    }
}
