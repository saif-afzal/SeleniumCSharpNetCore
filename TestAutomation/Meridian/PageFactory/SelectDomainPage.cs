using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class SelectDomainPage
    {
        public static void ClickSaveButton()
        {
            Driver.existsElement(By.Id("ML.BASE.BTN.Save"));
            Driver.clickEleJs(By.Id("ML.BASE.BTN.Save"));
            Thread.Sleep(2000);
        }

        public static string GetSuccessfullMessage()
        {
            return Driver.GetElement(By.Id("ReturnFeedback")).Text;
        }

        public static void ClickRolesCredcrumb()
        {
            Driver.clickEleJs(By.XPath("//div[@id='BreadCrumbs']/ol/li[4]/a"));
            Thread.Sleep(2000);
            Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu"));
        }
    }
}