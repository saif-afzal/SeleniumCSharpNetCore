using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    internal class AddUsersPage
    {
        public static SelectSearchedUserCommand SelectSearchedUser { get
            { return new SelectSearchedUserCommand(); }  }

        internal static string GetSuccessMessage()
        {
            throw new NotImplementedException();
        }

        internal static void VerifySearchButton()
        {
            throw new NotImplementedException();
        }

        internal static void VerifyBackButton()
        {
            throw new NotImplementedException();
        }

        internal static void VerifySaveButton()
        {
            throw new NotImplementedException();
        }

        internal static void Search(string v)
        {
            throw new NotImplementedException();
        }

        internal static void ManageRecord(string v)
        {
            throw new NotImplementedException();
        }

        internal static SearchUserCommand SearchLearneraccountwithFirstname(string firstname)
        {
            return new SearchUserCommand(firstname);
        }

        internal static void clicksearch()
        {
            throw new NotImplementedException();
        }

        internal static string VerifySearchText(string v)
        {
            return Driver.GetElement(By.XPath("//table[@id='TabMenu_ML_BASE_TAB_AddUsers_ContentUsers']/tbody/tr[2]/td[3]")).Text;
        }

        internal static string VerifySuccessfullMessage(string v)
        {
            return Driver.GetElement(By.XPath("//span[@id='ReturnFeedback']")).Text;
        }
    }

    internal class SelectSearchedUserCommand
    {
        public SelectSearchedUserCommand()
        {
        }

        internal void ClickAddSelected()
        {
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnAdd"));
        }

        internal void Clickcheckbox()
        {
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl02_DataGridItem_PRM_ENTITY_NAME"));
            Thread.Sleep(1000);
        }
    }

    internal class SearchUserCommand
    {
        private string lastName;
        private string v;

        public SearchUserCommand(string firstname)
        {
            this.v = firstname;
        }

        public SearchUserCommand LastName(string lastname)
        {
            this.lastName = lastname;
            return this;
        }

        internal void clicksearch()
        {
            Thread.Sleep(2000);
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_AddUsers_USR_LAST_NAME")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_AddUsers_USR_LAST_NAME")).SendKeysWithSpace(lastName);
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_AddUsers_USR_FIRST_NAME")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnSearch"));
            Thread.Sleep(2000);
            

        }
    }
}