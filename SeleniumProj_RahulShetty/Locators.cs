using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;

namespace SeleniumProj_RahulShetty
{
    class Locators
    {
        IWebDriver driver;
        [SetUp]
        public void StartBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }
        [Test]
        public void LocatorsIdentifications()
        {
            driver.FindElement(By.Id("username")).SendKeys("KrishnaReddy");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("KrishnaReddy");
            driver.FindElement(By.Name("password")).SendKeys("Password");
            driver.FindElement(By.CssSelector("input[value='Sign In']")).Submit();
            //Thread.Sleep(3000);
            String error = driver.FindElement(By.ClassName("alert-danger")).Text;
            TestContext.Progress.WriteLine(error);

            IWebElement linkedText= driver.FindElement(By.LinkText("Free Access to InterviewQues/ResumeAssistance/Material"));
            String actualResults=linkedText.GetAttribute("href");
            String exceptedResults = "https://rahulshettyacademy.com/documentsrequest";
            String a=exceptedResults.Insert(40,"-");
            Assert.AreEqual(actualResults, a, "Passed");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();

            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}
