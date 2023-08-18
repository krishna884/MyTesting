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

    class FunctionTests
    {
        IWebDriver driver;
        

        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void DropDown()
        {
            IWebElement dropDown = driver.FindElement(By.CssSelector("select.form-control"));
            SelectElement element = new SelectElement(dropDown);
            element.SelectByText("Consultant");

            //IList<IWebElement> radio = driver.FindElements(By.CssSelector("input[type='radio']"));
            foreach (IWebElement a in driver.FindElements(By.CssSelector("input[type='radio']")))
            {
                if (a.GetAttribute("value").Equals("user"))
                {
                    a.Click();
                }

            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Okay')]")));

            driver.FindElement(By.XPath("//button[contains(text(),'Okay')]")).Click();

            Boolean result = driver.FindElement(By.Id("usertype")).Selected;

            //Assert.That(result, Is.True);


        }
    }
}

