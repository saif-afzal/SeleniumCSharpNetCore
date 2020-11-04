using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class CreateSurveypage
    {
        public static bool? Title(string v)
        {
            Thread.Sleep(2000);
            return Driver.Instance.Title.Equals(v);
        }

        public static void Click_SurveyTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_hlSurvey']"));
        }
    }
}