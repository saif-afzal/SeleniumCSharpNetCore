using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class ActivityPage
    {
        public static ActivityCommand Activity { get { return new ActivityCommand(); } }

        public static bool? verifyrequiredatributesdisplay()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.XPath("//legend"));
                Driver.GetElement(By.XPath("//div[2]/div/div/label")).Text.Equals("No Start Date");
                result = Driver.GetElement(By.XPath("//div[2]/div[2]/label")).Text.Equals("End Date");
               
           }
            catch { }
            return result;
        }
    }

    public class ActivityCommand
    {
        public ActivityCommand()
        {
        }

        public void InactiveContent()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_OBJ_IS_ACTIVE_0"));
            Thread.Sleep(5000);
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_Save"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
        }

        public void ActivewithStartandEndDate()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_FormView1_OBJ_IS_ACTIVE_1"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_FormView1_OBJ_IS_ACTIVE_1"));
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_Save"));
            IWebElement Dtdate = Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_OBJ_ACTIVE_START_DATE_dateInput"));
            IWebElement Enddate = Driver.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_OBJ_ACTIVE_END_DATE_dateInput"));
            Dtdate.Click();
            Dtdate.Clear();
            Dtdate.SendKeysWithSpace("10/01/2018");
            Enddate.Click();
            Enddate.Clear();
            Enddate.SendKeysWithSpace("10/30/2019");
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));



        }
    }
}