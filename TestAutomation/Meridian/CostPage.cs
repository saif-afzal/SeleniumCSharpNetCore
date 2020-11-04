using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CostPage
    {
        public static alternetCostsPortlateCommand alternetCostsPortlate { get { return new alternetCostsPortlateCommand(); } }

        public static DefaultCostCommand DefaultCostAs(string v)
        {
            return new DefaultCostCommand(v);
        }

        public static bool Successmessage(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='content']/div[2]/div"));
            return Driver.Instance.FindElement(By.XPath("//div[@id='content']/div[2]/div")).Text.Equals(v);
        }

        public static void ClickReturn()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
        }

        public static bool? VerifyDifferentPortlets()
        {
            bool result=false;
            try
            {
                string a=Driver.Instance.FindElement(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlCostEdit']/div/div/div/div/h3")).Text;
                a.Equals("Default Cost");
                //Driver.GetElement(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlCostEdit']/div/div[2]/div/div/h3")).Text.Equals("Manage Sales Tax");
               return Driver.GetElement(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlCostEdit']/div[2]/div/div/div/h3")).Text.Equals("Alternate Costs");
                //Driver.GetElement(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlCostEdit']/div[3]/div/div/div/h3")).Text.Equals("Pricing Schedules");

                
            }
            catch(Exception ex)
            {

            }
            return result;
        }

        public static void GoToGeneralCourseBreadCrumb()
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[3]/a"));
            //Driver.clickEleJs(By.XPath("//a[@id='MainContent_ucEditContent_FormView1_btnEditContent']"));
        }
    }

    public class alternetCostsPortlateCommand
    {
        public alternetCostsPortlateCommand()
        {
        }

        public bool? NoUserorgroupsadded()
        {

            return Driver.GetElement(By.XPath("//table[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00']/tbody/tr/td/span")).Text.Equals("No records found.");
        }

        public void ClickAddmoreusersNgroups()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_lnkCostAdd"));
        }

        public bool? Userorgroupsadded()
        {
            return Driver.existsElement(By.XPath("//tr[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00__0']/td[2]"));
        }

        public void removeAddedusergroup()
        {
            Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCostEntities_ctl00_ctl04_chkSelect"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnRemove"));
            Thread.Sleep(2000);
            Driver.Instance.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

        }
    }

    public class DefaultCostCommand
    {
        private string v;

        public DefaultCostCommand(string v)
        {
            this.v = v;
        }

        public void Save()
        {
            Driver.Instance.Checkout();
            Driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost"));
            Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost")).Clear();
            Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost")).SendKeys(v);
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            Thread.Sleep(5000);
        }
    }
}