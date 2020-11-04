using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ExternalLearningConsolePage
    {
        public static void SearchUser(string v)
        {
            Driver.existsElement(By.Id("TabMenu_ML_BASE_LBL_SearchUsers_USR_LAST_NAME"));
            Driver.GetElement(By.Id("TabMenu_ML_BASE_LBL_SearchUsers_USR_LAST_NAME")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_LBL_SearchUsers_ELR_STATUS_ID"));
            Driver.select(By.Id("TabMenu_ML_BASE_LBL_SearchUsers_ELR_STATUS_ID"), "Approved");
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_LBL_SearchUsers_ML.BASE.BTN.Search"));


        }

        public static bool? isExternalLearningdisplay(string extlearningTitle)
        {
            return Driver.existsElement(By.XPath("//td[contains(text(),'test')]"));
        }
    }
}