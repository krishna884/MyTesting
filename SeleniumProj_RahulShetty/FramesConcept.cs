using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProj_RahulShetty
{
     class FramesConcept
    {
        IWebDriver driver;
        [SetUp]
        public void startTheBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [Test]
        public void framesMethod()
        {
            IWebElement ele = driver.FindElement(By.Id("courses-iframe"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", ele);

            driver.SwitchTo().Frame("courses-iframe");
            driver.FindElement(By.XPath("//nav[contains(@class,'main-menu')]//li[3]//a[contains(@class,'new')]")).Click();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
            driver.SwitchTo().DefaultContent();
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector("h1")).Text);
        }
    }
}
