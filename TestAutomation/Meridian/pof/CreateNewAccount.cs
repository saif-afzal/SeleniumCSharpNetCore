using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium2.Meridian;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using Utility;
using System.Reflection;
using relativepath;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian
{
   public class CreateNewAccount
    {
        private readonly IWebDriver driverobj;

        public CreateNewAccount(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool PopulateCreateNewUserLink(string id,string firstname,string lastname,string email="@Test.com")
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_loginid);
                driverobj.GetElement(txt_loginid).SendKeysWithSpace(id);
                ObjectRepository.newuserloginid = id;
                driverobj.GetElement(txt_firstname).SendKeysWithSpace(firstname);
                driverobj.GetElement(txt_lastname).SendKeysWithSpace(lastname);
                driverobj.GetElement(txt_email).SendKeysWithSpace(id + "@tpg.com");
                //driverobj.GetElement(txt_password).SendKeysWithSpace("password");
               // driverobj.GetElement(txt_confirmPasspord).SendKeysWithSpace("password");
                driverobj.GetElement(lnk_selectorg).ClickWithSpace();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
               result = driverobj.existsElement(ObjectRepository.org_search_text);

              
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public static bool? LoginIDMaxLengthisWorking()
        {
            // Locating firstname web element
            IWebElement LoginID = Driver.Instance.FindElement(By.Id("MainContent_UC1_USR_LOGIN_ID"));

            /***************** Way 1 ********************************/

            // Type more than 100 characters as max limit is defined as 10 as per requirement
            LoginID.SendKeysWithSpace("AutomationTesting142AutomationTesting142AutomationTesting142AutomationTesting142AutomationTesting142extra");

            // Get the typed value
            String typedValue = LoginID.GetAttribute("value");

            // Get the length of typed value
            int size = typedValue.Length;            

            // Assert with expected
            if (size == 100)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public static bool? LoginIDMaxLength(string v)
        {
            Driver.existsElement(By.Id("MainContent_UC1_USR_LOGIN_ID"));
            return Driver.GetElement(By.Id("MainContent_UC1_USR_LOGIN_ID")).GetAttribute("maxlength").Equals(v);
        }

        //This is a copy of the PopulateCreateNewUserLink method becouse during account creation from outer page we need to enter password fields
        public bool PopulateCreateNewUserLinkOuter(string id, string firstname, string lastname, string email = "@Test.com")
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_loginid);
                driverobj.GetElement(txt_loginid).Clear();
                driverobj.GetElement(txt_loginid).SendKeysWithSpace(id);
                ObjectRepository.newuserloginid = id;
                driverobj.GetElement(txt_firstname).SendKeysWithSpace(firstname);
                driverobj.GetElement(txt_lastname).SendKeysWithSpace(lastname);
                driverobj.GetElement(txt_email).SendKeysWithSpace(id + "@tpg.com");
                driverobj.GetElement(txt_password).SendKeysWithSpace("password");
                driverobj.GetElement(txt_confirmPasspord).SendKeysWithSpace("password");
                driverobj.GetElement(lnk_selectorg).ClickWithSpace();
                Thread.Sleep(5000);
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                Thread.Sleep(5000);
                result = driverobj.existsElement(ObjectRepository.org_search_text);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public static void EnteredConfirmPassword(string v)
        {
            Driver.GetElement(By.Id("MainContent_UC1_ConfirmPassword")).Clear();
            Driver.GetElement(By.Id("MainContent_UC1_ConfirmPassword")).SendKeysWithSpace(v);
        }

        public static void EnteredPassword(string v)
        {
            Driver.existsElement(By.Id("MainContent_UC1_USR_PASSWORD"));
            Driver.GetElement(By.Id("MainContent_UC1_USR_PASSWORD")).Clear();
            Driver.GetElement(By.Id("MainContent_UC1_USR_PASSWORD")).SendKeysWithSpace(v);
        }

        public static void SelectOrganization(string v)
        {
            Driver.clickEleJs(By.Id("MainContent_UC1_lnkSelectOrg"));
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            Driver.existsElement(By.Id("MainContent_UC1_txtSearch"));
            Driver.GetElement(By.Id("MainContent_UC1_txtSearch")).Clear();
            Driver.GetElement(By.Id("MainContent_UC1_txtSearch")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("MainContent_UC1_btnSearch"));
            Thread.Sleep(5000);

            Driver.clickEleJs(By.XPath("//td/input"));
            Driver.clickEleJs(By.Id("MainContent_UC1_FormView1_Save"));

        }

        public static bool? CreateButtonisEnabled()
        {
            return Driver.GetElement(By.XPath("//input[@id='MainContent_UC1_Create']")).Enabled;
        }

        public static bool? ConfirmEmailAddressValidationmessagedisplay(string v)
        {
            Driver.existsElement(By.Id("MainContent_UC1_RegularExpressionValidator1"));
            return Driver.GetElement(By.Id("MainContent_UC1_RegularExpressionValidator1")).Text.StartsWith(v);
        }

        public static void ClearEmailAddress()
        {
            IWebElement webElement = Driver.GetElement(By.Id("USR_EMAIL_ADDRESS"));
            webElement.Clear();
            
            webElement.SendKeys(Keys.Tab);
        }

        public static void FilEmailAddress(string email)
        {
            IWebElement webElement = Driver.GetElement(By.Id("USR_EMAIL_ADDRESS"));
            webElement.Clear();
            webElement.SendKeysWithSpace(email);
            webElement.SendKeys(Keys.Tab);
        }

        public static void FilConfirmEmail(string email)
        {
            IWebElement webElement = Driver.GetElement(By.Id("USR_EMAIL_ADDRESS_CONFIRM"));
            webElement.Clear();
            webElement.SendKeysWithSpace(email);
            webElement.SendKeys(Keys.Tab);
        }

        public static bool isConfirmEmailfielddisplaywithEditMode()
        {
            return Driver.GetElement(By.Id("USR_EMAIL_ADDRESS_CONFIRM")).Enabled;
        }

        public static string isConfirmEmailfielddisplaywithNonEditMode()
        {
            Driver.existsElement(By.Id("USR_EMAIL_ADDRESS_CONFIRM"));
            return Driver.GetElement(By.Id("USR_EMAIL_ADDRESS_CONFIRM")).GetAttribute("disabled");
        }

        public bool Click_SelectOrganization(string orgname)
        {
            bool result = false;
            try
            {
                driverobj.IsElementDisplayed_Generic_Selectorg();
                driverobj.WaitForElement(btn_searchorg);
                driverobj.GetElement(txt_searchorg).SendKeysWithSpace(orgname);
                driverobj.GetElement(btn_searchorg).ClickWithSpace();
                Thread.Sleep(5000);
                driverobj.WaitForElement(rb_selectorg);
              //  driverobj.GetElement(rb_selectorg).Click();
                driverobj.ClickEleJs(rb_selectorg);
                Thread.Sleep(5000);
                driverobj.WaitForElement(btn_saveorg);
                driverobj.GetElement(btn_saveorg).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.SwitchtoDefaultContent();
                //driverobj.SwitchTo().DefaultContent();
                


                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }

       

        public bool Click_CreateAccount()
        {
            bool result = false;
            try
            {
                
                driverobj.WaitForElement(btn_createuser);
                driverobj.GetElement(btn_createuser).ClickWithSpace();
                //driverobj.WaitForElement(ObjectRepository.sucessmessage);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        private By txt_loginid = By.Id("MainContent_UC1_USR_LOGIN_ID");
        private By txt_firstname = By.Id("MainContent_UC1_USR_FIRST_NAME");
        private By txt_lastname = By.Id("MainContent_UC1_USR_LAST_NAME");
        private By txt_email = By.Id("MainContent_UC1_USR_EMAIL_ADDRESS");
        private By txt_password = By.Id("MainContent_UC1_USR_PASSWORD");
        private By txt_confirmPasspord = By.Id("MainContent_UC1_ConfirmPassword");
        private By lnk_selectorg = By.Id("MainContent_UC1_lnkSelectOrg");
        private By txt_searchorg = By.Id("MainContent_UC1_txtSearch");
        private By btn_searchorg = By.Id("MainContent_UC1_btnSearch");
        private By rb_selectorg = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect");
        private By btn_saveorg = By.Id("MainContent_UC1_FormView1_Save");
        private By btn_createuser = By.Id("MainContent_UC1_Create");
        private By login_name = By.CssSelector("span.rmText.rmExpandDown");

        internal void Click_SelectOrganization()
        {
            throw new NotImplementedException();
        }
    }
}
