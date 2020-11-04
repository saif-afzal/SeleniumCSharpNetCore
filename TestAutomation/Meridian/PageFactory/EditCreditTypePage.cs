using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    internal class EditCreditTypePage
    {
        public static ActivityTabCommand ActivityTab { get { return new ActivityTabCommand(); } }

        internal static void ClickActivity()
        {
            Driver.Instance.WaitForElement(By.XPath("//a[@id='ML.BASE.WF.EditActivity']/span"));
            Driver.clickEleJs(By.XPath("//a[@id='ML.BASE.WF.EditActivity']/span"));
            Thread.Sleep(2000);
        }
    }

    internal class ActivityTabCommand
    {
        public ActivityTabCommand()
        {
        }

        internal void SelectInactive()
        {
            Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_IS_ACTIVE_0"));
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_IS_ACTIVE_0"));
        }

        internal void ClickSave()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.Id("ML.BASE.BTN.Save"));
        }
    }
}