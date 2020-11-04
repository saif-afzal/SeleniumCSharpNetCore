using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CreateChecklistPage
    {
        public static void Create(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='CNTLCL_TITLE']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
        }

        public static void CheckIn()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
        }

        public static void Publish()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnPublish']"));
            Driver.Instance.findandacceptalert();
        }
    }
}