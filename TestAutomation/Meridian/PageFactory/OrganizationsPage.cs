using OpenQA.Selenium;
using ParallelTesting_Solution2;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class OrganizationsPage
    {
        private IWebDriver objDriver;

        public OrganizationsPage(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public  int DisplaySearchRecords
        {
            get {
                Thread.Sleep(5000);
              objDriver.WaitForElement(By.XPath("//span[@class='PRE']"));
                string text= objDriver.GetElement(By.XPath("//span[@class='PRE']")).Text;
                int retvalue = objDriver.getIntegerFromString(text);
                objDriver.Navigate_to_TrainingHome();
                return retvalue; }
        }
        public  void ClickSearch()
        {
            objDriver.selectWindow("Organizations");
            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']"));
            objDriver.ClickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));
        }

        public static void ClickCreatenew()
        {
            Driver.existsElement(By.XPath("//input[@value='Go']"));
            Driver.clickEleJs(By.XPath("//input[@value='Go']"));
        }

        public static OrganizationSearchCommand SearchWith(string organizationTitle)
        {
            return new OrganizationSearchCommand(organizationTitle);
        }

        public static string verifySearchedOrganizationTitle()
        {
            Driver.Instance.WaitForElement(By.XPath("//tr[2]/td[3]"));
            return Driver.GetElement(By.XPath("//tr[2]/td[3]")).Text;

        }

        public static void ClickManageGoButton()
        {
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_OrganizationListingDataGrid_ctl02_GoButton"));
        }
    }

    public class OrganizationSearchCommand
    {
        private string organizationTitle;

        public OrganizationSearchCommand(string organizationTitle)
        {
            this.organizationTitle = organizationTitle;
        }

        public void Search()
        {
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeysWithSpace(organizationTitle);
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            Thread.Sleep(2000);
        }
    }
}