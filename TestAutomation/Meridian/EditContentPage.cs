using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class EditContentPage
    {
        public static void AddContent(string v)
        {
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_EditContent_GoPageActionsMenu']"));
            Driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_AddContent_SearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_AddContent_ML.BASE.BTN.Search']"));

        }
    }
}