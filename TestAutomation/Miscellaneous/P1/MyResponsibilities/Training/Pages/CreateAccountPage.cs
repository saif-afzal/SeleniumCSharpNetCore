using OpenQA.Selenium;
using System;
using System.Threading;

namespace Selenium2.Meridian.P1.MyResponsibilities.Training
{
    public class CreateAccountPage
    {
       static By btn_searchorg = By.Id("MainContent_UC1_btnSearch");
       static By txt_searchorg = By.Id("MainContent_UC1_txtSearch");
       static By rb_selectorg = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect");
       static By btn_saveorg = By.Id("MainContent_UC1_FormView1_Save");
        internal static void CreateAccount(string v1, string v2, string v3,string v4="")
        {
            Driver.GetElement(By.Id("MainContent_UC1_USR_LOGIN_ID")).SendKeysWithSpace(v1);
            Driver.GetElement(By.Id("MainContent_UC1_USR_FIRST_NAME")).SendKeysWithSpace(v2);
            Driver.GetElement(By.Id("MainContent_UC1_USR_LAST_NAME")).SendKeysWithSpace(v3);
            if(v4!=null)
            {
                Driver.GetElement(By.XPath("//input[@id='USR_EMAIL_ADDRESS']")).SendKeysWithSpace(v4);
                Driver.GetElement(By.XPath("//input[@id='USR_EMAIL_ADDRESS']")).SendKeys(Keys.Tab);
                Driver.GetElement(By.XPath("//input[@id='USR_EMAIL_ADDRESS_CONFIRM']")).SendKeys(v4);
            }
            Driver.clickEleJs(By.Id("MainContent_UC1_lnkSelectOrg"));
            Thread.Sleep(5000);
            //driverobj.SelectFrame();
            Driver.Instance.waitforframe(ObjectRepository.switchToFrame_New);
            Thread.Sleep(5000);
            SelectOrganization("Sample Organization");
            Driver.clickEleJs(By.Id("MainContent_UC1_Create"));

        }
        internal static void SelectOrganization(string v1)
        {
            Driver.Instance.IsElementDisplayed_Generic_Selectorg();
            Driver.Instance.WaitForElement(btn_searchorg);
            Driver.Instance.GetElement(txt_searchorg).SendKeysWithSpace(v1);
            Driver.Instance.GetElement(btn_searchorg).ClickWithSpace();
            Thread.Sleep(5000);
            Driver.Instance.WaitForElement(rb_selectorg);
            //  driverobj.GetElement(rb_selectorg).Click();
            Driver.Instance.ClickEleJs(rb_selectorg);
            Thread.Sleep(5000);
            Driver.Instance.WaitForElement(btn_saveorg);
            Driver.Instance.GetElement(btn_saveorg).ClickWithSpace();
            Thread.Sleep(3000);
            
            Driver.Instance.SwitchTo().DefaultContent();


        }
        private By txt_loginid = By.Id("MainContent_UC1_USR_LOGIN_ID");
        private By txt_firstname = By.Id("MainContent_UC1_USR_FIRST_NAME");
        private By txt_lastname = By.Id("MainContent_UC1_USR_LAST_NAME");
        private By txt_email = By.Id("MainContent_UC1_USR_EMAIL_ADDRESS");
        private By txt_password = By.Id("MainContent_UC1_USR_PASSWORD");
        private By txt_confirmPasspord = By.Id("MainContent_UC1_ConfirmPassword");
        private By lnk_selectorg = By.Id("MainContent_UC1_lnkSelectOrg");
      //  private By txt_searchorg = By.Id("MainContent_UC1_txtSearch");
       // private By btn_searchorg = By.Id("MainContent_UC1_btnSearch");
       // private By rb_selectorg = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect");
      //  private By btn_saveorg = By.Id("MainContent_UC1_FormView1_Save");
        private By btn_createuser = By.Id("MainContent_UC1_Create");
        private By login_name = By.CssSelector("span.rmText.rmExpandDown");

        public static bool? checkTilte(string v)
        {
            return Driver.checkTitle(v);
        }

        public static string CreateNewUserLinkOuter(string id, string firstname, string lastname, string email = "@Test.com")
        {
            

            try
            {
                Driver.existsElement(By.XPath("//input[@id='signup-id']"));
                Driver.GetElement(By.XPath("//input[@id='signup-id']")).SendKeysWithSpace(id);                
                ObjectRepository.newuserloginid = id;
                Driver.GetElement(By.XPath("//input[@id='signup-pw']")).SendKeysWithSpace("password");
                Driver.GetElement(By.XPath("//input[@id='signup-pw2']")).SendKeysWithSpace("password");
                Driver.GetElement(By.XPath("//input[@id='signup-email']")).SendKeysWithSpace(id + "@tpg.com");
                Driver.GetElement(By.Id("signup-email2")).SendKeysWithSpace(id + "@tpg.com");
                Driver.GetElement(By.XPath("//input[@id='signup-fname']")).SendKeysWithSpace(firstname);
                Driver.GetElement(By.XPath("//input[@id='signup-lname']")).SendKeysWithSpace(lastname);
                Driver.clickEleJs(By.XPath("//a[@class='btn btn-default signup-form-next']"));
               


            }
            catch (Exception ex)
            {

                
            }

            return id;
        }

        public static bool? isNextpagedisplay()
        {
            return Driver.existsElement(By.XPath("//button[@class='btn btn-primary signup-form-create']"));
        }

        public static void clickCreate()
        {
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));
            Thread.Sleep(5000);
        }

        public static bool? isSuccessmessagedisplay()
        {
            return Driver.existsElement(By.XPath("//div[@class='alert alert-success ng-scope']"));
        }

        public static void SelectPerPageRec()
        {
            Driver.clickEleJs(By.XPath("//span[2]/span"));
            Driver.clickEleJs(By.LinkText("10"));
            Driver.select(By.Id("PAGE_SIZE"), "10");
           
        }

        public static bool? isSelectOrgdisplay()
        {
            return Driver.existsElement(By.XPath("//label[text()='Organizations']"));
        }
    }
    
}