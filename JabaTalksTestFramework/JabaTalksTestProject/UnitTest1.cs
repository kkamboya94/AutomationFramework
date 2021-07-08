using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using System.Threading;
using JabaTalksTestProject.Pages;
using JabaTalksTestFramework.Base;
using JabaTalksTestFramework.Helpers;
using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JabaTalksTestProject
{   
    
    public class UnitTest1
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
        public void Verify_DropDownList()
        {
            LoginPage loginpage = new LoginPage();
            LogHelpers.Write("Loaded SignUp Page ");
            List<string> DDL_ExpectedValues = new List<string> () { "English", "Dutch" };
            List<string>  Actual_DDL = loginpage.GetDDList();
            //Assert.Multiple is used as there are multiple verification in dropdown list
            NUnit.Framework.Assert.Multiple(() =>
            {
                foreach (var item in Actual_DDL)
                {
                    Assert.That(DDL_ExpectedValues.Contains(item));
                    LogHelpers.Write("Checked Dropdown list values");
                }
            });

        }

        [OneTimeTearDown]
        public void Test_Cleanup()
        {
            DriverContext.Driver.Quit();
            LogHelpers.Write("Driver instance closed successfully");
        }
    }
}
