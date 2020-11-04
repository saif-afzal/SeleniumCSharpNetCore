using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CreditTypesPage
    {
        public static void ClickCreatenew()
        {
            Thread.Sleep(5000);
            Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu"));
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu"));
            Thread.Sleep(2000);

        }

        public static void ClickMagangeGo()
        {
            Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_Search_CreditType_GoButton_2"));
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_CreditType_GoButton_2"));
            Thread.Sleep(2000);
        }

        public static void inactivepreviouscredittype()
        {
            CommonSection.Administer.ContentManagement.CreditType();
            
            if(Driver.existsElement(By.XPath("//tr[4]/td[3]")))
            {
                CreditTypesPage.ClickMagangeGo();
                EditCreditTypePage.ClickActivity();
                EditCreditTypePage.ActivityTab.SelectInactive();
                EditCreditTypePage.ActivityTab.ClickSave();
                Thread.Sleep(5000);
            }
            
        }
    }
}