using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Reflection;


namespace Selenium2.Meridian
{
    class Login
    {
          private readonly IWebDriver driverobj;
          public Login(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_btnlogin()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_login);
                driverobj.GetElement(btn_login).ClickWithSpace();
                driverobj.WaitForElement(lnk_forgetlogin);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Create on Button GoTo for Creating new Account Codes", driverobj);
            }
            return actualresult;
        }

        public string Click_lnkforgetlogin(string browserstr,string email)
        {
            string actualresult =string.Empty;
            try
            {
                driverobj.WaitForElement(lnk_forgetlogin);
                driverobj.GetElement(lnk_forgetlogin).ClickAnchor();
                driverobj.WaitForElement(By.Id("LastName"));
                driverobj.GetElement(By.Id("LastName")).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr + "forget");
                driverobj.WaitForElement(By.Id("Email"));
                driverobj.GetElement(By.Id("Email")).SendKeysWithSpace(email);
                driverobj.GetElement(btn_forgetuserid).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
              actualresult=  driverobj.GetElement(lbl_success).Text;
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Create on Button GoTo for Creating new Account Codes", driverobj);
            }
            return actualresult;
        }

        public string Click_lnkforgetpassword(string browserstr)
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(lnk_forgetpassword);
               // driverobj.GetElement(lnk_forgetpassword).ClickAnchor();
                driverobj.ClickEleJs(lnk_forgetpassword);
                driverobj.WaitForElement(By.Id("LoginId"));
                driverobj.GetElement(By.Id("LoginId")).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "forget");
                driverobj.GetElement(btn_forgetpassword).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                actualresult = driverobj.GetElement(lbl_success).Text;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Create on Button GoTo for Creating new Account Codes", driverobj);
            }
            return actualresult;
        }

        public bool Click_ContactAdmin(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_contactus);
              //  driverobj.GetElement(lnk_contactus).ClickAnchor();
                driverobj.ClickEleJs(lnk_contactus);
                driverobj.waitforframe(By.ClassName("k-content-frame"));
                driverobj.WaitForElement(txt_contactus_email);
                driverobj.GetElement(txt_contactus_email).SendKeysWithSpace(ExtractDataExcel.MasterDic_newuser["Email"] + browserstr + "forget");
                driverobj.WaitForElement(txt_contactus_subject);
                driverobj.GetElement(txt_contactus_subject).SendKeysWithSpace("Test Subject");
                driverobj.WaitForElement(txt_contactus_message);
                driverobj.GetElement(txt_contactus_message).SendKeysWithSpace("Test Message");
                driverobj.GetElement(btn_send).ClickWithSpace();
                driverobj.SwitchtoDefaultContent();
              actualresult=  driverobj.existsElement(btn_login);
               

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Create on Button GoTo for Creating new Account Codes", driverobj);
            }
            return actualresult;
        }
        private By btn_login = By.Id("MainContent_UC5_btnLogin");
        private By lnk_forgetlogin = By.XPath(".//*[@id='LoginPage']/div[1]/form/div[2]/div[1]/p/a[1]");
        private By lnk_forgetpassword = By.XPath(".//*[@id='LoginPage']/div[1]/form/div[2]/div[1]/p/a[2]");
        private By txt_forgetlastname = By.Id("lastName");
        private By txt_forgetemail = By.Id("email");
        private By btn_forgetuserid = By.XPath("html/body/div[1]/div[2]/div/div/form/div[2]/div[2]/button");
        private By btn_backforgetid = By.XPath("html/body/div[1]/div[2]/div/div/form/div[2]/div[1]/button");
        private By lbl_success = By.XPath("//div[@class='alert alert-success ng-scope']");
        private By txt_forgetpasswordloginid = By.Id("loginId");
        private By btn_forgetpassword = By.XPath("html/body/div[1]/div[2]/div/div/form/div[2]/div[2]/button");
        private By lnk_contactus = By.Id("lnkContactUs");
        private By txt_contactus_email = By.Id("MainContent_UC1_FormView1_From");
        private By txt_contactus_subject = By.Id("MainContent_UC1_FormView1_Subject");
        private By txt_contactus_message = By.Id("MainContent_UC1_FormView1_Message");
        private By btn_send = By.Id("MainContent_UC1_Send");
    }
    
}
