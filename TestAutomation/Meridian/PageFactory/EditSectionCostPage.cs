using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class EditSectionCostPage
    {
        public static void setDefultCost(string v)
        {
            Driver.existsElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']"));
            Driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost']")).SendKeys(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
        }

        public static void clickbradcrumbSectionsLink()
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'Sections')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Sections')]"));
        }
    }
}