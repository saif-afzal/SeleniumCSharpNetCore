using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class NewCreditTypePage
    {
        public static CreditTypeCreateCommand TitleAs(string title)
        {
            return new CreditTypeCreateCommand(title);
        }

        public static AddUsertoCreditTypeCommand AssignedUsers(string v)
        {
            return new AddUsertoCreditTypeCommand(v);
        }

        public static void ClickAddCredit()
        {
            Driver.Instance.WaitForElement(By.Id("MainContent_MainContent_UC1_btnAddNew"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnAddNew"));
            Thread.Sleep(2000);
        }

        public static void AddCreditValuetoCreditType()
        {
            Driver.Instance.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl04_txtCreditValue"));
            Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl04_txtCreditValue")).Clear();
            Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl04_txtCreditValue")).SendKeysWithSpace("6");
            Thread.Sleep(1000);
            Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl06_txtCreditValue")).Clear();
            Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl06_txtCreditValue")).SendKeysWithSpace("5");
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Add"));
            Thread.Sleep(5000);
        }

        public static void AddDefaultCreditValue(string v)
        {
            Driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl04_txtCreditValue"));
            Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl04_txtCreditValue")).SendKeys(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_MButton1']"));
            Driver.existsElement(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));

        }
    }

    public class AddUsertoCreditTypeCommand
    {
        private string UserName;
        private string v;
        private string selectu;
        public AddUsertoCreditTypeCommand(string v)
        {
            this.v = v;
        }

        

        public AddUsertoCreditTypeCommand SearchText(string username)
        {
            this.UserName = username;
            return this;
        }

        public AddUsertoCreditTypeCommand SelectAdminuser(string selectuser)
        {
            this.selectu = selectuser;
            return this;
        }

        public void Add()
        {
            Driver.Instance.WaitForElement(By.XPath("//div[3]/div/ul/li[4]/a/span"));
            Driver.clickEleJs(By.XPath("//div[3]/div/ul/li[4]/a/span"));
            Thread.Sleep(2000);
            IWebElement AddUser = Driver.GetElement(By.Id("TabMenu_ML_BASE_LBL_AssignedUsers_GoPageActionsMenu"));
            AddUser.ClickWithSpace();
            IWebElement SearchText = Driver.GetElement(By.Id("TabMenu_ML_BASE_HEAD_AddUsers_SearchRole"));
            SearchText.Clear();
            SearchText.SendKeysWithSpace(UserName);
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_HEAD_AddUsers_ML.BASE.BTN.Search"));
            Thread.Sleep(3000);
            Driver.Instance.WaitForElement(By.XPath("//tr[4]/td[2]/span/input"));
            Driver.clickEleJs(By.XPath("//tr[4]/td[2]/span/input"));
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_HEAD_AddUsers_AssignTraining"));
        }
    }

    public class CreditTypeCreateCommand
    {
        private string Des;
        private string Title;

        public CreditTypeCreateCommand(string title)
        {
            this.Title = title;
        }

        public CreditTypeCreateCommand DescriptionAs(string v)
        {
            this.Des = v;
            return this;
        }

        public void Create()
        {
            Driver.existsElement(By.Id("TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_TITLE"));

            Driver.GetElement(By.Id("TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_DESCRIPTION")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_DESCRIPTION")).SendKeysWithSpace(Des);
            Driver.GetElement(By.Id("TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_TITLE")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_HEAD_EditCreditType_CRDTYPELCL_TITLE")).SendKeysWithSpace(Title);
            Driver.clickEleJs(By.Id("ML.BASE.BTN.Create"));
        }
    }
}