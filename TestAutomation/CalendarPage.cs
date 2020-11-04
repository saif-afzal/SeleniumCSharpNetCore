using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CalendarPage
    {
        public static void CreateNewEvent(string CreatedEvent)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC1_lnkAddEvent']"));
            Driver.waitforframe();
            Driver.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_EVT_TITLE']")).SendKeysWithSpace(CreatedEvent);
            Driver.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_EVT_START_TIME_dateInput']")).SendKeysWithSpace("12:00 AM");
            Driver.GetElement(By.XPath("//input[@id='ctl00_MainContent_UC1_FormView1_EVT_END_TIME_dateInput']")).SendKeysWithSpace("11:30 PM");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
            Driver.Instance.SwitchtoDefaultContent();
        }

        public static bool? VerifySuccessMessage()
        {
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text.Equals("The event was created.");
        }
    }
}