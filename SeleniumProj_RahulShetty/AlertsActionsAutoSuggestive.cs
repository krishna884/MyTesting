using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Interactions;

namespace SeleniumProj_RahulShetty
{
    class AlertsActionsAutoSuggestive
    {
        IWebDriver driver;
        [SetUp]
        public void StartWebBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();

            driver.Url = "https://rahulshettyacademy.com/AutomationPractice/";
        }
        [Test]
        public void test_Alert()
        {
            String name = "Krishna";
            driver.FindElement(By.CssSelector("#name")).SendKeys(name);
            driver.FindElement(By.CssSelector("input[onclick*='displayAlert']")).Click();

            String alertmsg = driver.SwitchTo().Alert().Text;
            //To click on Okay (for positive scenarios) in the alert msg
            driver.SwitchTo().Alert().Accept();
            //To click on Cancel, No (for Negative scenarios) in the alert msg
            //driver.SwitchTo().Alert().Dismiss();
            //To enter data in the alert form
            //driver.SwitchTo().Alert().SendKeys("Keirkjdh");

            StringAssert.Contains(name, alertmsg);
        }
        [Test]
        public void test_AutoSuggestiveDropDowns()
        {
            driver.FindElement(By.Id("autocomplete")).SendKeys("ind");
            Thread.Sleep(3000);

            IList<IWebElement> options= driver.FindElements(By.CssSelector(".ui-menu-item div"));
            foreach (IWebElement option in options)
            {
                if(option.Text.Equals("India"))
                {
                    option.Click();
                }
            }
            //Dynamic values cant be fetch through .Text attribute in selenium, can be perfomred with GetAttribute method
            TestContext.Progress.WriteLine(driver.FindElement(By.Id("autocomplete")).GetAttribute("value"));
        }
        [Test]
        public void test_Actions()
        {
            driver.Url = "https://rahulshettyacademy.com/";
            Actions a = new Actions(driver);
            a.MoveToElement(driver.FindElement(By.CssSelector("a.dropdown-toggle"))).Perform();

            //In the below2 lines any one can be performed
            driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a")).Click();

            //a.MoveToElement(driver.FindElement(By.XPath("//ul[@class='dropdown-menu']/li[1]/a"))).Click().Perform();

        }
    }
}
