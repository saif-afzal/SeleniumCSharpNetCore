using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class PeoplePage
    {
        private IWebDriver objDriver;
        private CommonSection commonSectionPage3;
        public PeoplePage(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
            commonSectionPage3 = new CommonSection(objDriver);
        }
        public  CraeteAccountCommand CraeteAccount
        {
            get { return new CraeteAccountCommand(objDriver); }
        }

        public static void ClickButton_CreateAccount()
        {
            Driver.clickEleJs(By.Id("MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser"));
        }

        public class CraeteAccountCommand
        {
            private IWebDriver objDriver;
            private CommonSection commonSectionPage3;
            public CraeteAccountCommand(IWebDriver objDriver)
            {
                this.objDriver = objDriver;
                commonSectionPage3 = new CommonSection(objDriver);
            }
            public void PopulateForm()
            {
                Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LOGIN_ID']")).SendKeys(ExtractDataExcel.MasterDic_newuser["Id"]);
                Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_FIRST_NAME']")).SendKeys(ExtractDataExcel.MasterDic_newuser["Firstname"]);
                Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_UC1_USR_LAST_NAME']")).SendKeys(ExtractDataExcel.MasterDic_newuser["Lastname"]);
                Driver.clickEleJs(By.Id("MainContent_UC1_lnkSelectOrg"));
                Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Driver.Instance.GetElement(By.Id("MainContent_UC1_txtSearch")).SendKeys("Sample");
                Driver.clickEleJs(By.Id("MainContent_UC1_btnSearch"));
                Driver.clickEleJs(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect"));
                Driver.clickEleJs(By.Id("MainContent_UC1_FormView1_Save"));
                Driver.Instance.SwitchtoDefaultContent();
                
            }

            public void ClickButton_Create()
            {
                Driver.clickEleJs(By.Id("MainContent_UC1_Create"));
            }
        }

        public  void Search_User(string s)
        {
            commonSectionPage3.Manage.People();
            Thread.Sleep(4000);
            Driver.Instance.GetElement(By.Id("SEARCH_FOR")).SendKeys(s);
            Driver.clickEleJs(By.Id("btnSearchClientSide"));
            Thread.Sleep(4000);
        }

        public static string Generate_Password()
        {
            Driver.select(By.XPath("//select[@id='ddlUsrAction_0']"), "Login Assistance");
            Driver.clickEleJs(By.XPath("//a[@class='btn btn-default go']"));
            Driver.Instance.waitforframe(By.XPath(".//*[@id='KendoUIMGDialog']/iframe"));
            Thread.Sleep(10000);
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
            Thread.Sleep(3000);
            Driver.Instance.SwitchtoDefaultContent();
            Driver.Instance.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
            string msgstring = Driver.Instance.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
            var elements = msgstring.Split(' ');
            string passwd = string.Empty;
            if (Meridian_Common.MeridianTestbrowser == "iebs" || Meridian_Common.MeridianTestbrowser == null)
            {
                string text = string.Empty;
                text = Driver.Instance.GetBrwser();
                if (text == "chrome" || text == "IE")//used IE as safari need to change
                {
                    passwd = elements[5];

                }
                else
                {
                    passwd = elements[6];
                }
            }

            else
            {
                passwd = elements[5];
            }
            passwd = passwd.Replace(".", "");
            Thread.Sleep(2000);
            return passwd;

           
        }

        public static void ClickCreateAccount()
        {
            Driver.clickEleJs(By.Id("MainContent_ucUserSimpleSearch_lnkBtnCreateNewUser"));
        }

        public static bool viewTranscript()
        {
            bool result = false;
            try
            {
                Driver.Instance.selectDropdownValue(By.XPath("//select[@id='ddlUsrAction_0']"), "View Transcript");
                Driver.clickEleJs(By.XPath("//a[@class='btn btn-default go']"));
                result = true;
            }catch(Exception e)
            {

            }
            return result;
        }

        public static bool? getfeedbackmessage(string v)
        {
            Driver.existsElement(By.XPath("//div[@class='alert alert-success']"));
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text.Equals(v);
        }
    }
}