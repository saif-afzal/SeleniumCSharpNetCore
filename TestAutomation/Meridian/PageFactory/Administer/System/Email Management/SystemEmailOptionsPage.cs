using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class SystemEmailOptionsPage
    {
        public static bool? isSenderNamedisplay()
        {
      
            return Driver.existsElement(By.Id("TabMenu_ML_BASE_SystemEmailOptions_DefaultSenderEmailName"));
        }

        public static void EnterSenderName(string senderName)
        {
            Driver.GetElement(By.Id("TabMenu_ML_BASE_SystemEmailOptions_DefaultSenderEmailName")).Clear();
            Driver.GetElement(By.Id("TabMenu_ML_BASE_SystemEmailOptions_DefaultSenderEmailName")).SendKeysWithSpace(senderName);
        }

        public static void ClickSave()
        {
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
        }

        public static string getSenderName()
        {
            return Driver.GetElement(By.Id("TabMenu_ML_BASE_SystemEmailOptions_DefaultSenderEmailName")).Text;
        }
    }
}