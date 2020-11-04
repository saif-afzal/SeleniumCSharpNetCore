using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class TestsPage
    {
        public static void ClickCreateNew()
        {
            Driver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu']"));
        }

        public static void searchtest(string v)
        {
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeys(v);
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
            Thread.Sleep(10000);
            Driver.clickEleJs(By.LinkText(v));
        }

        public static void clickOnTestTitle(string v)
        {
            Driver.existsElement(By.LinkText(v));
            Driver.clickEleJs(By.LinkText(v));
        }
    }
}