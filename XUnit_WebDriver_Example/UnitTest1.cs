using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace XUnit_WebDriver_Example
{
    public class UnitTest1: IDisposable
    {
        private readonly IWebDriver _seleniumDriver;
        
        public UnitTest1()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");

            _seleniumDriver = new ChromeDriver(AppContext.BaseDirectory + "/chromedriver_win32", chromeOptions)
            {
                Url = "https://www.google.com/"
            };

            _seleniumDriver.Manage().Window.Maximize();
            _seleniumDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0.5);
        }

        public void Dispose()
        {
            _seleniumDriver.Close();
            _seleniumDriver.Dispose();
        }

        [Fact]
        public void TitleTest()
        {
            _seleniumDriver.Url = "https://www.google.com/";
            Assert.Equal("Google", _seleniumDriver.Title);
        }

        [Fact]
        public void SearchHelloWorld_ReturnsResults()
        {
            _seleniumDriver.Url = "https://www.google.com/";

            var searchbox = _seleniumDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[2]/div/div[1]/div/div[1]/input"));
            searchbox.SendKeys("Hello World!" + Keys.Enter);
            var elements = _seleniumDriver.FindElements(By.TagName("h3"));

            Assert.True( elements.Count > 0);  
        }

    }
}
