using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class NewRolePage
    {
        public static void FillName(string v)
        {
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_NAME")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_NAME")).SendKeysWithSpace(v);
        }

        public static void FillDescription(string v)
        {
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_ROLE_DESCRIPTION")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_ROLE_DESCRIPTION")).SendKeysWithSpace(v);
        }

        public static void ClickCreateButton()
        {
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Create']"));
            Thread.Sleep(2000);
        }
    }


}