using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProj_RahulShetty
{
    public class SeleniumFirst
    {
        IWebDriver driver;
       [SetUp]

        public void StartBrowser()
        {
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
            // driver = new ChromeDriver();
            // driver = new FirefoxDriver();
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]

        public void Test1()
        {
            
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            Thread.Sleep(1000);
            TestContext.Progress.WriteLine(driver.Title);
            TestContext.Progress.WriteLine(driver.Url);
            TestContext.Progress.WriteLine(driver.PageSource);
            driver.Close();
                
                }
    }
}
