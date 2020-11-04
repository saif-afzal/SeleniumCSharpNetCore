using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ManagerProfessionalDevelopmentPage
    {
        public static bool? isDevelopmentPlansdisplay()
        {
            return Driver.existsElement(By.XPath("//a[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkPlan']"));
        }

        public static void Clickfirstdevplan()
        {
            Driver.clickEleJs(By.XPath("//a[@id='ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkPlan']"));
        }
    }
}