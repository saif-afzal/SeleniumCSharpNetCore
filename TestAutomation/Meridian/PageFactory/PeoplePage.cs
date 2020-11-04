using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class ManageUsersPage
    {
        private IWebDriver objDriver;
        public ManageUsersPage(IWebDriver objDriver)
        {
            this.objDriver = objDriver;
        }
        public  int DisplaysUserlist
        {
           
            get {
                Thread.Sleep(5000);
                objDriver.existsElement(By.XPath("//h3[@class='bs-table-count']"));
                return Driver.getIntegerFromString(objDriver.GetElement(By.XPath("//h3[@class='bs-table-count']")).Text); }
        }

        public  void SearchUser(string v)
        {
            objDriver.GetElement(By.XPath("//input[@id='SEARCH_FOR']")).SendKeysWithSpace(v);
            Thread.Sleep(2000);
            objDriver.ClickEleJs(By.XPath("//button[@id='btnSearchClientSide']"));
        }
    }
}