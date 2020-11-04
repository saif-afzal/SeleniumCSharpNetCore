using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Collections.ObjectModel;
using System.Reflection;
using OpenQA.Selenium.Support.UI;

namespace Selenium2.Meridian
{
    class MyCalenders
    {
        private readonly IWebDriver driverobj;

        public MyCalenders(IWebDriver driver)
        {
            driverobj = driver;
        }

        public string AddEventToCalender()
        {
            try
            {
                string eventlinktext = string.Empty;
                
                //int CurrentDay = DateTime.Now.Day;
                eventlinktext = DateTime.Now.ToString("yyyy-MM-dd");
                ////if (CurrentDay == 1)
                ////{
                ////    eventlinktext = "0" + eventlinktext + " " + DateTime.Now.ToString("MMM");
                ////}
                By curruntdate = By.XPath("//span[@data-cal-date='" + eventlinktext + "']");
                driverobj.WaitForElement(curruntdate);
                IWebElement currcell = driverobj.GetElement(curruntdate);
                IWebElement parentcell = currcell.FindElement(MoveToParent);
                //hovertoday();
                driverobj.ClickEleJs(By.XPath("//div[@class='cal-month-day cal-day-inmonth cal-day-today']/a/span[1]"));
                //parentcell.FindElement(By.XPath("//div[@class='cal-month-day cal-day-inmonth cal-day-today']/a/span[1]")).Click();
                driverobj.waitforframe(By.XPath(".//*[@id='events-modal']/div[2]/div/div[2]/iframe"));
                driverobj.WaitForElement(CalenderEventTitle);
                driverobj.GetElement(CalenderEventTitle).Clear();
                driverobj.GetElement(CalenderEventTitle).SendKeysWithSpace("Test_Event");
                driverobj.GetElement(CalenderEventStartTime).SendKeysWithSpace("6:30 PM");
                driverobj.GetElement(CalenderEventEndTime).SendKeysWithSpace("7:30 PM");
                driverobj.GetElement(CalenderSaveEditBtn).ClickWithSpace();
                driverobj.WaitForElement(sucessmessage);
                return driverobj.GetElement(sucessmessage).Text;


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to add event to My Calender", driverobj);
                return "";
            }
        }
        public string EditEventFromCalender()
        {

            try
            {
                driverobj.WaitForElement(lnk_events);
                driverobj.ClickEleJs(lnk_events);
             IList<IWebElement>cnt =   driverobj.FindElements(By.XPath("//a[contains(.,'Test_Event')]"));
             foreach (IWebElement element in cnt)
             {
                 element.ClickWithSpace();
                 break;
             }
             
                //driverobj.WaitForElement(By.LinkText("Test_Event"));
                //driverobj.GetElement(By.LinkText("Test_Event")).ClickWithSpace();
                driverobj.waitforframe(By.XPath(".//*[@id='events-modal']/div[2]/div/div[2]/iframe"));
                driverobj.WaitForElement(CalenderEventTitle);
                driverobj.GetElement(CalenderEventTitle).Clear();
                driverobj.GetElement(CalenderEventTitle).SendKeysWithSpace("Test_Event_edit");
                driverobj.GetElement(CalenderSaveEditBtn).ClickWithSpace();
                driverobj.WaitForElement(sucessmessage);
                return driverobj.GetElement(sucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to edit event in My Calander", driverobj);
                return "";
            }
        }
        public string DeleteEventFromCalender()
        {

            try
            {
                driverobj.WaitForElement(lnk_events);
                driverobj.GetElement(lnk_events).ClickWithSpace();
                IList<IWebElement> cnt = driverobj.FindElements(By.XPath("//a[contains(.,'Test_Event')]"));
                foreach (IWebElement element in cnt)
                {
                    element.ClickWithSpace();
                    break;
                }
                //driverobj.WaitForElement(By.PartialLinkText("Test_Event"));
                //driverobj.GetElement(By.PartialLinkText("Test_Event")).Click();
                driverobj.waitforframe(By.XPath(".//*[@id='events-modal']/div[2]/div/div[2]/iframe"));
                driverobj.WaitForElement(CalenderDeleteBtn);
                driverobj.GetElement(CalenderDeleteBtn).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.findandacceptalert();
                driverobj.WaitForElement(sucessmessage);
                return driverobj.GetElement(sucessmessage).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to delete event in My Calender", driverobj);
                return "";
            }
        }

        public bool CalenderSwitchToMonth()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(CalenderWeekBtn);
                driverobj.ClickEleJs(CalenderWeekBtn);
                driverobj.WaitForElement(ClanederWeekView);
                driverobj.GetElement(CalenderMonthBtn).ClickAnchor();
               actualresult= driverobj.existsElement(today);
                return actualresult;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Switch calander View to Month View", driverobj);
                return actualresult;
            }
        }
        public bool CalenderSwitchToWeek()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(CalenderWeekBtn);
                driverobj.ClickEleJs(CalenderWeekBtn);
               actualresult= driverobj.existsElement(ClanederWeekView);
               return actualresult;
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Switch calander View to Week View", driverobj);
                return actualresult;
            }
        }

        public bool PrintCalender()
        {
            try
            {
                driverobj.WaitForElement(btn_print);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btn_print).ClickWithSpace();
                Thread.Sleep(10000);
                driverobj.SwitchWindow("Calender");
                Thread.Sleep(4000);
                Actions action = new Actions(driverobj);
                action.SendKeys(OpenQA.Selenium.Keys.Escape);
                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);

                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to print current event in calander", driverobj);
                return false;
            }
        }

        private void hovertoday()
        {
            WebDriverWait wait = new WebDriverWait(driverobj, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='cal-month-day cal-day-inmonth cal-day-today']")));

            Actions action = new Actions(driverobj);
            action.MoveToElement(element).Perform();
        }
        private By MoveToParent = By.XPath("..");
        private By today = By.XPath("//div[@class='cal-month-day cal-day-inmonth cal-day-today']");
        private By AddEventToCalenderBtn = By.XPath("//div[@class='cal-month-day cal-day-inmonth cal-day-today']/a/span[1]");
        private By CalenderEventTitle = By.Id("MainContent_UC1_FormView1_EVT_TITLE");
        private By CalenderEventStartTime = By.Id("ctl00_MainContent_UC1_FormView1_EVT_START_TIME_dateInput");
        private By CalenderEventEndTime = By.Id("ctl00_MainContent_UC1_FormView1_EVT_END_TIME_dateInput");
        private By CalenderSaveEditBtn = By.Id("MainContent_UC1_Save");
        private By CalenderDeleteBtn = By.Id("MainContent_UC1_Delete");
        private By sucessmessage = By.XPath("//div[@class='alert alert-success']");

      
        private By ClanederWeekView = By.XPath("//div[@class='cal-week-box']");
        private By CalenderMonthBtn =  By.XPath("//button[@data-calendar-view='month']");
        private By CalenderWeekBtn = By.XPath("//button[@data-calendar-view='week']");

        private By btn_print = By.Id("MainContent_UC1_MLinkButton1");
        private By lnk_events = By.XPath("//div[@class='truncate-event dh-event-info ']");
      

    }
}
