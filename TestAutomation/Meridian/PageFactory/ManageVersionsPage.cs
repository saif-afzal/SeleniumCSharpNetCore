using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ManageVersionsPage
    {
        public static string VerifyDeleteVersionSuccessMessage()
        {
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public static void Click_Back()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));
        }
    }
}