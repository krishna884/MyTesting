using AngleSharp.Dom;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumProj_RahulShetty
{
    class SortWebTables
    {
        IWebDriver driver;
        [SetUp]
        public void StartWebBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();

            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }
        [Test]
        public void SortTable()
        {
            ArrayList a = new ArrayList();
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("page-menu")));
            dropdown.SelectByText("20");

            // Step 1 - Get all Veg names into arrayList A

            //IList<IWebElement> veggies = driver.FindElements(By.XPath("//table[@class='table table-bordered']//tbody//td[1]")); or
            IList<IWebElement> veggies = driver.FindElements(By.XPath("//tr//td[1]"));

            foreach (IWebElement veggie in veggies)
            {
                a.Add(veggie.Text);
            }

            TestContext.Progress.WriteLine("Before Sorting");
            foreach (var element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            // Step 2 - Sort this arrayList A
            TestContext.Progress.WriteLine("\nAfter Sorting");
            a.Sort();
            foreach (String element in a)
            {
                TestContext.Progress.WriteLine(element);
            }

            // Step 3 - Go and click column to sort

            //Css Locator and xpath locator
            // (th[aria - label *= 'fruit name']) & (//th[contains(@aria-label,'fruit name')])
            driver.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();
            
            // Step 4 - Sort veggies names into arrayList B
            ArrayList b= new ArrayList();
            IList<IWebElement> sortedVeggies = driver.FindElements(By.XPath("//tr//td[1]"));

            foreach (IWebElement veggie in sortedVeggies)
            {
                b.Add(veggie.Text);
            }

            // arrayList A to B = equal
            Assert.AreEqual(a, b);

        }
    }
}
