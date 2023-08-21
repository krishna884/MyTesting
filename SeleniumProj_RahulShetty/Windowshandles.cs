using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProj_RahulShetty
{
    class Windowshandles
    {
        IWebDriver driver;  
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void WindowsHandles()
        {
            String email = "mentor@rahulshettyacademy.com";
            String parentWindowID = driver.CurrentWindowHandle;
            driver.FindElement(By.ClassName("blinkingText")).Click();
            TestContext.Progress.WriteLine(driver.WindowHandles.Count());
            Assert.AreEqual(2, driver.WindowHandles.Count());

            String childname=driver.WindowHandles[1];
            driver.SwitchTo().Window(childname);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);

            //Please email us at mentor @rahulshettyacademy.com with below template to receive response

            String text = driver.FindElement(By.CssSelector(".red")).Text;

            String[] SplittedText=text.Split("at");
            String[] trimmedText=SplittedText[1].Trim().Split(" ");
            Assert.AreEqual(email, trimmedText[0]);
                
            driver.SwitchTo().Window(parentWindowID);
            driver.FindElement(By.Id("username")).SendKeys(trimmedText[0]);

        }
    }
}
