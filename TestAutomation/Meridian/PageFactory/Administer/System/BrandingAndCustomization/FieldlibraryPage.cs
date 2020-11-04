using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class FieldlibraryPage
    {
        public static SystemTabCommand SystemTab { get { return new SystemTabCommand(); } }

        public static void clickSystemTab()
        {
            Driver.existsElement(By.XPath("//a[@id='MainContent_ucTabs_linkSystem']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_ucTabs_linkSystem']"));
        }
    }

    public class SystemTabCommand
    {
        public SystemTabCommand()
        {
        }

        public void ClickAddressLebel()
        {
            Driver.existsElement(By.Id("ctl00_MainContent_UC1_rgSystem_ctl00_ctl04_MHyperLink3"));
            Driver.clickEleJs(By.Id("ctl00_MainContent_UC1_rgSystem_ctl00_ctl04_MHyperLink3"));
        }
    }
}