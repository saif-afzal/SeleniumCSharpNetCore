using System;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite
{
    internal class SystemBehaviorAndStoragePage
    {
        internal static void enableTimeZoneVisibility()
        {
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_HEAD_SystemBehaviorAndStorage_TimeZoneSupported_0']"));
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
        }
    }
}