using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netWealth.Model
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private By _LoginPageHeading = By.XPath("//div[@class='register-completed__thank-you-box bg-day-100']/h1[@class='mt-0']");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
        }

        async void async_delay()
        {
            await Task.Delay(50000);
        }
        public String GetTitleheading()
        {
            async_delay();
            return driver.FindElement(_LoginPageHeading).Text;
        }
        public String UrlCheck() 
        {
            return driver.Url;
        }
    }
}
