using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using JabaTalksTestFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabaTalksTestProject.Pages
{
    class EmailPage : BasePage
    {
        //Objects for the Email Page
        [FindsBy(How = How.Id, Using = "inbox-id")]
        public IWebElement uname { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/div/span[1]/span/input")]
        public IWebElement setmailtxtbox { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[2]/div/span[1]/span/button[1]")]
        public IWebElement setemailbtn { get; set; }

        //Create an email account
        public void CreateEmailAccount(string email)
        {            
            ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript("window.open();"); //For opening new tab in browser.
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.WindowHandles.Last());
            DriverContext.Driver.Navigate().GoToUrl("https://www.guerrillamail.com/inbox");
            uname.Click();
            setmailtxtbox.Clear();
            System.Threading.Thread.Sleep(5000);
            setmailtxtbox.SendKeys(email);
            setemailbtn.Click();
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.WindowHandles.First());
        }

        //Go to Email Tab
        public void EmailTab(string email)
        {
            DriverContext.Driver.SwitchTo().Window(DriverContext.Driver.WindowHandles.Last());
            DriverContext.Driver.Navigate().Refresh();
        }

        //Get all emails
        public IList<IWebElement> GetEmails()
        {
            IList<IWebElement> AllEmails = DriverContext.Driver.FindElements(By.Id("email_list"));
            return AllEmails;
        }
    }
}
