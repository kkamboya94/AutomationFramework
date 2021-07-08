using JabaTalksTestFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JabaTalksTestProject.Pages
{
    class LoginPage : BasePage
    {
        //Objects for the login page
        [FindsBy(How = How.CssSelector, Using = "#language > div.ui-select-match.ng-scope > span > span.ui-select-match-text.pull-left")]
        public IWebElement DDlang { get; set; }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement txt_Name { get; set; }

        [FindsBy(How = How.Id, Using = "orgName")]
        public IWebElement txt_Org_name { get; set; }

        [FindsBy(How = How.Id, Using = "singUpEmail")]
        public IWebElement txt_Email { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[2]/section/div/div[3]/div/section/div[1]/form/fieldset/div[4]/label/span")]
        public IWebElement chk_IAgree { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content > div > div.main-body > div > section > div.form-container > form > fieldset > div:nth-child(5) > button")]
        public IWebElement btn_GetStarted { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'ui-select-choices-row-1-')]//a//div")]
        public IWebElement DDList { get; set; }

        //To check dropdown values
        public List<string> GetDDList()
        {
            DDlang.Click();

            List<string> ActualVal = new List<string>();

            IList<IWebElement> dropdown_list = DriverContext.Driver.FindElements(By.XPath("//*[contains(@id,'ui-select-choices-row-1-')]//a//div"));

            foreach (IWebElement item in dropdown_list)
            {
                ActualVal.Add(item.Text);
            }
            return ActualVal;
        }

        //To perform SignUp
        public void SignUpForm(string Name, string OrgName, string Email)
        {
            //DDlang.SendKeys(Language);
            txt_Name.Clear();
            txt_Org_name.Clear();
            txt_Email.Clear();

            txt_Name.SendKeys(Name);
            txt_Org_name.SendKeys(OrgName);
            txt_Email.SendKeys(Email);

            chk_IAgree.Click();
            btn_GetStarted.Click();
        
        }

    }
}
