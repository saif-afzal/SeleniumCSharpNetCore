using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class RolesPage
    {
        public static SearchResultCommand SearchResult { get
            { return new SearchResultCommand(); } }

        public static SelectCreateNewCommand SelectCreateNew {
            get { return new SelectCreateNewCommand(); }
        }

        public static SearchRoleCommand SearchText(string v)
        {
            return new SearchRoleCommand(v);
        }

        public static string VerifySearchText()
        {
            Driver.Instance.WaitForElement(By.XPath("//table[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch']/tbody/tr[2]/td[3]"));
            Thread.Sleep(2000);
            return Driver.GetElement(By.XPath("//table[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch']/tbody/tr[2]/td[3]")).Text;
        }
    }

    public class SearchResultCommand
    {
        public SearchResultCommand()
        {
        }

        public void Select(string v)
        {
            Driver.existsElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl03_ActionsMenu']"));
            Driver.GetElement(By.XPath("//td[6]/select")).ClickWithSpace();
            Thread.Sleep(1000);
            Driver.select(By.XPath("//td[6]/select"), v);
        }

        public void ClickGo()
        {
            Driver.GetElement(By.XPath("//td[6]/input")).ClickWithSpace();
            Thread.Sleep(3000);
        }
    }

    public class SearchRoleCommand
    {
        private string v;

        public SearchRoleCommand(string v)
        {
            this.v = v;
        }

        public void ClickSearchbutton()
        {
            Thread.Sleep(2000);
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            Thread.Sleep(2000);



        }
    }

    public class SelectCreateNewCommand
    {
        public SelectCreateNewCommand()
        {

        }

        public void ClickGo()
        {
            Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu"));
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu"));
            Thread.Sleep(2000);

        }
    }
}