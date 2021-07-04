using DocumentFormat.OpenXml.Drawing.ChartDrawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netWealth.Model
{
    public class HomePage : LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(100));
        }

        private By FirstName = By.XPath("//*[@id='FirstName']");
        private By LastName = By.XPath("//*[@id='LastName']");
        private By Email = By.XPath("//*[@id='Email']");
        private By Password = By.XPath("//*[@id='Password']");
        private By ReferralSource = By.XPath("//*[@id='ReferralSource']");
        private By MarketingMaterial = By.XPath("//*[@id='UserWantsMarketingMaterial']");
        private By Sumbit_btn = By.XPath("//div[@class='my-4']/button[@class='btn btn-md btn-primary w-100 w-md-auto' and @name='RegistrationForm']");
            //*[@id="RegisterForm"]/fieldset/div[9]/button
        private By Accept_Cookie = By.Id("jAccept");
        private By Pass_ErrorMes = By.XPath("//*[@id='Password - error']");


        //public void Wait_page_completion(int timeout)
        //{
        //    var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));

        //    // Wait for the page to load
        //    wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        //}
        async void Async_delay()
        {
            await Task.Delay(5000);
        }

        private void WaitElement(By locator)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1000));
            wait.Until(condition: ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        }
        public String GetTitle() 
        {
            return driver.Title;
        }
        public void FillFistName(String _InputFirstName )
        {
            WaitElement(FirstName);
            driver.FindElement(FirstName).SendKeys(_InputFirstName);
            
        
        }
        public void FillLastName(String _InputlastName)
        {
            WaitElement(LastName);
            driver.FindElement(LastName).SendKeys(_InputlastName);

        }
        public void FillEmail(String _InputEmail)
        {
            
            driver.FindElement(Email).SendKeys(_InputEmail);

        }
        public void FillPassword(String _InputPassword)
        {
            
            driver.FindElement(Password).SendKeys(_InputPassword);

        }

        public void FillReferral(String _InputRefferal)
        {
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver; js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", XPosition, yPosition));
            WaitElement(ReferralSource);
            IWebElement _selectElement = driver.FindElement(ReferralSource);
            SelectElement select = new SelectElement(_selectElement);
            select.SelectByText(_InputRefferal);

        }
        public void FillMarketingMaterial(String _InputMarketingPref)
        {
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver; js.ExecuteScript(String.Format("window.scrollTo({0}, {1})", XPosition, yPosition));
            WaitElement(MarketingMaterial);
            IWebElement _selectElement = driver.FindElement(MarketingMaterial);
            SelectElement select = new SelectElement(_selectElement);
            select.SelectByText(_InputMarketingPref);

        }
        public void Submitform()
        {
            driver.FindElement(Sumbit_btn).Click();
            Async_delay();
            
        }
       

        public bool PassError() 
        {
            if (driver.FindElement(Pass_ErrorMes).Text.Equals("Please enter a valid password"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
