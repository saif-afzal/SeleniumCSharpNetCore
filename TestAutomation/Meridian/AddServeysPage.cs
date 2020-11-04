using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class AddServeysPage
    {
        public static bool? IsSearchfieldsDisplayed()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_lblSearchFor"));
                result = Driver.existsElement(By.XPath("//div[@id='MainContent_MainContent_UC1_pnlSearch']/div/div[2]/label"));
               
            }
            catch
            { }
            return result;

        }

        public static void AddSurveystoContent()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"));
            Driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"));
            Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));

        }
    }
}