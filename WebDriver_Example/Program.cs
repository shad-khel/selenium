using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.seleniumhq.org/docs/05_selenium_rc.jsp#programming-your-test
            //https://www.azuredevopslabs.com/labs/vstsextend/selenium/
            //https://docs.microsoft.com/en-us/azure/devops/pipelines/test/continuous-test-selenium?view=azure-devops

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");

            IWebDriver driver = new ChromeDriver(AppContext.BaseDirectory, chromeOptions)
            {
                Url = "https://www.google.com/"
            };

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0.5);

            var searchbox = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[2]/div/div[1]/div/div[1]/input"));
            searchbox.SendKeys("Hello World!" + Keys.Enter);
            
            var elements = driver.FindElements(By.TagName("h3"));

            foreach (var e in elements)
            {
                Console.WriteLine(e.Text);
            }

            Console.WriteLine("Results found :" + elements.Count);

            Console.ReadLine();
        }
    }
}
