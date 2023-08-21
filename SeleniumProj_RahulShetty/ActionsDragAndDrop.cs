using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProj_RahulShetty
{
     class ActionsDragAndDrop
    {
        IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver =new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://demoqa.com/droppable";
        }
        [Test]
        public void test_DropAndDrag()
        {
            Actions a = new Actions(driver);
            a.DragAndDrop(driver.FindElement(By.Id("draggable")), driver.FindElement(By.Id("droppable"))).Perform();
        }
    }
}
