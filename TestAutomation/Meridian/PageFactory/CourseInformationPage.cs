using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections.Generic;

namespace Selenium2.Meridian.Suite
{
    public class CourseInformationPage
    {
        public static CourseProviderCommand CourseProvider { get { return new CourseProviderCommand(); } }

        public static void EnterDuration(string v)
        {
            Driver.GetElement(By.Id("MainContent_MainContent_UC1_FormView1_CRSW_DURATION")).SendKeys(v);
        }

        public static void clickSave()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
        }

        public static void click_Back()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
        }
    }

    public class CourseProviderCommand
    {
        public CourseProviderCommand()
        {
        }

        public void Select(string v)
        {
            Driver.GetElement(By.Id("MainContent_MainContent_UC1_FormView1_CRSW_PROVIDER")).ClickWithSpace();
            
            Driver.select(By.Id("MainContent_MainContent_UC1_FormView1_CRSW_PROVIDER"), v);

        }
    }
}