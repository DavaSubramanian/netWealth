using netWealth.Model;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace netWealth.TestScripts
{
    public class netWealthTestScripts
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private HomePage _homePage;
        private LoginPage _LoginPage;
        //string FirstName, LastName, Email, Password, RefferralSource, MarketingInterest;
       

        [SetUp]
        public void setup()
         { 
                // Create a driver instance for chromedriver
                driver = new ChromeDriver();
                //Navigate to google page
                driver.Navigate().GoToUrl("https://dev.id.netwealth.com/account/register?returnUrl=https://dev.netwealth.com/login");
                //Maximize the window
                driver.Manage().Window.Maximize();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                driver.FindElement(By.Id("jAccept")).Click();
        }

        //= new HomePage(driver);
        //[Test]
        ////Verify the HomePage url title to
        //public void VerifyTitle()
        //{
        //    _homePage = new HomePage(driver);
        //    Console.WriteLine(_homePage.GetTitle());
        //}

        [Test]
        [TestCase("Johnny", "Depp", "test1@test1.com", "Eights_23", "Event", "Yes", true)]
        //[TestCase("Al", "Pacino", "test2@test2.com", "Eight23", "Event", "Yes", false)]
        //[TestCase("Brad", "Pitt", "tes3@test3.com", "eight_23", "Event", "Yes", false)]
        //[TestCase("Al", "Pacino", "test4@test4.com", "Eight", "Event", "Yes", false)]
        //[TestCase("Al", "Pacino", "test4@test4.com", "Eightsss", "Event", "Yes", false)]
        //[TestCase("Al", "Pacino", "test4@test4.com", "Eightsss", "Event", "Yes", true)]
        public void FillTheForm(string FirstName, string LastName, string Email, string Password,
                                 string ReferralSource, string MarketingInterest, bool IsRegistered)
        {
            _homePage = new HomePage(driver);
            _homePage.FillFistName(FirstName);
            _homePage.FillLastName(LastName);
            _homePage.FillEmail(Email);
            _homePage.FillPassword(Password);
            _homePage.FillReferral(ReferralSource);
            _homePage.FillMarketingMaterial(MarketingInterest);
            _homePage.Submitform();
            Thread.Sleep(5000);
            //driver.Url.Contains("RegisteredCompleted");
            Assert.That(new LoginPage(driver).UrlCheck().Contains("RegisterCompleted"));
                //Assert.That(_homePage.PassError, Is.EqualTo("Please enter a valid password"));


        }

       
        //Verify the LoginPage url title to
        //public void ReturnHeading()
        //{
        //    _LoginPage = new LoginPage(driver);
        //    _LoginPage.GetTitleheading().Equals("Thank you for registering");
        //}

        //private bool IsRegSuccess()
        //{
        //    try
        //    {
        //        _LoginPage.GetTitleheading().Equals("Thank you for registering");
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}


       // [TearDown]
       //public void CloseBrowser()
       // {
       //     driver.Quit();
       //     driver.Dispose();
       // }

    }
}
