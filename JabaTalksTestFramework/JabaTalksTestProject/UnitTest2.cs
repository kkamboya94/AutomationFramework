using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using JabaTalksTestProject.Pages;
using JabaTalksTestFramework.Base;
using JabaTalksTestFramework.Helpers;

namespace JabaTalksTestProject
{
    public class UnitTest2
    {
        [OneTimeSetUp]
        public void Test_Setup()
        {
            string fileName = System.IO.Directory.GetCurrentDirectory() + "\\LoginDetails\\Data.xlsx";
            ExcelHelpers.PopulateInCollection(fileName);

            LogHelpers.CreateLogFile();

            string driverpath = System.IO.Directory.GetCurrentDirectory() + "\\ChromeDriver";
            DriverContext.Driver = new ChromeDriver(driverpath);
            LogHelpers.Write("Launched the browser");
            //DriverContext.Driver = new ChromeDriver();
            DriverContext.Driver.Navigate().GoToUrl("http://jt-dev.azurewebsites.net/#/SignUp");
            LogHelpers.Write("Navigated to Application");
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);  //Waiting for 1 min to load the site
        }

        [Test]
        public void Verify_Email()
        {
            LoginPage loginpage = new LoginPage();
            EmailPage emailpage = new EmailPage();

            emailpage.CreateEmailAccount(ExcelHelpers.ReadData(1, "Email"));
            LogHelpers.Write("Email account created successfully");

            loginpage.SignUpForm(
                ExcelHelpers.ReadData(1, "Name"),
                ExcelHelpers.ReadData(1, "OrganizationName"),
                ExcelHelpers.ReadData(1, "Email"));
            LogHelpers.Write("Entered Name, Org name, Email and clicked on submit button");

            emailpage.EmailTab(ExcelHelpers.ReadData(1, "Email"));
            LogHelpers.Write("Navigated to Email tab");

            IList<IWebElement> allEmails = emailpage.GetEmails();
            if (allEmails.Count != 0)
            {
                Assert.Pass("Your email has been received");
                LogHelpers.Write("Received mail");
            }
            else
            {
                Assert.Fail("Your email hasn't been received");
                LogHelpers.Write("Failed email verification");
            }
        }
        [OneTimeTearDown]
        public void Test_Cleanup()
        {
            DriverContext.Driver.Quit();
            LogHelpers.Write("Driver instance closed successfully");
        }
    }
}