using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
using Selenium2.Meridian;
using OpenQA.Selenium.Interactions;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class ToolbarUtil
    {
        private readonly IWebDriver driverobj;
       

        public ToolbarUtil(IWebDriver driver)
        {
            driverobj = driver;
        }
 
        public string HelpLinkClick()
        {
            string helptitle = string.Empty;
            try
            {
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(ObjectRepository.HelpLink_id);
                driverobj.GetElement(ObjectRepository.HelpLink_id).Click();
                Thread.Sleep(3000);
                driverobj.SwitchWindow("Help");
                 helptitle = driverobj.Title;
                 driverobj.Close();
                 Thread.Sleep(3000);
                 driverobj.SwitchTo().Window(originalHandle);
                 
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Help Link", driverobj);
            }

            return helptitle;
        }

        public bool ClickOnMyCalender()
        {
            try
            {
                driverobj.OpenToolbarItems(ObjectRepository.MyCalenderHoverLink);
                driverobj.WaitForElement(ObjectRepository.ClanederMonthView);
             
                    return true;
                
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
        }

        public string AddEventToCalender()
        {
            try
            {
                string eventlinktext = string.Empty;
               driverobj.OpenToolbarItems(ObjectRepository.MyCalenderHoverLink);
                int CurrentDay = DateTime.Now.Day;
                eventlinktext = CurrentDay.ToString();
                if (CurrentDay == 1)
                {
                    eventlinktext ="0"+ eventlinktext +" "+ DateTime.Now.ToString("MMM");
                }
                driverobj.WaitForElement(By.LinkText(eventlinktext));
                IWebElement currcell = driverobj.GetElement(By.LinkText(eventlinktext));
                IWebElement parentcell = currcell.FindElement(ObjectRepository.MoveToParent);
                parentcell.FindElement(ObjectRepository.AddEventToCalenderBtn).Click();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.GetElement(ObjectRepository.CalenderEventTitle).Clear();
                driverobj.GetElement(ObjectRepository.CalenderEventTitle).SendKeys("Test_Event");
                driverobj.GetElement(ObjectRepository.CalenderEventStartTime).SendKeys("6:30 PM");
                driverobj.GetElement(ObjectRepository.CalenderEventEndTime).SendKeys("7:30 PM");
                driverobj.GetElement(ObjectRepository.CalenderSaveEditBtn).Click();
                return driverobj.GetElement(ObjectRepository.sucessmessage).Text;


            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "";
            }
        }
        public string EditEventFromCalender()
        {

            try
            {
               driverobj.OpenToolbarItems(ObjectRepository.MyCalenderHoverLink);
               driverobj.WaitForElement(By.LinkText("Test_Event"));
                driverobj.GetElement(By.LinkText("Test_Event")).Click();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.GetElement(ObjectRepository.CalenderEventTitle).Clear();
                driverobj.GetElement(ObjectRepository.CalenderEventTitle).SendKeys("Test_Event_edit");
                driverobj.GetElement(ObjectRepository.CalenderSaveEditBtn).Click();
                
                return driverobj.GetElement(ObjectRepository.sucessmessage).Text;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "";
            }
        }
        public string DeleteEventFromCalender()
        {

            try
            {
               driverobj.OpenToolbarItems(ObjectRepository.MyCalenderHoverLink);
               driverobj.WaitForElement(By.PartialLinkText("Test_Event"));
                driverobj.GetElement(By.PartialLinkText("Test_Event")).Click();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.GetElement(ObjectRepository.CalenderDeleteBtn).Click();
                Thread.Sleep(3000);
                driverobj.findandacceptalert();
                driverobj.WaitForElement(ObjectRepository.TrainingHome);
                return driverobj.GetElement(ObjectRepository.sucessmessage).Text;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "";
            }
        }

        public bool CalenderSwitchToMonth()
        {
            try
            {
                driverobj.OpenToolbarItems(ObjectRepository.MyCalenderHoverLink);
                driverobj.GetElement(ObjectRepository.CalenderWeekBtn).Click();
                driverobj.WaitForElement(ObjectRepository.ClanederWeekView);
                driverobj.GetElement(ObjectRepository.CalenderMonthBtn).Click();
                driverobj.WaitForElement(ObjectRepository.ClanederMonthView);
                return true;

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
        }
        public bool CalenderSwitchToWeek()
        {
            try
            {
                driverobj.OpenToolbarItems(ObjectRepository.MyCalenderHoverLink);
                driverobj.GetElement(ObjectRepository.CalenderWeekBtn).Click();
                driverobj.WaitForElement(ObjectRepository.ClanederWeekView);
                return true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
        }

        public bool PrintCalender()
        {
            try
            {
                driverobj.OpenToolbarItems(ObjectRepository.MyCalenderHoverLink);
                driverobj.WaitForElement(By.Id("MainContent_UC1_MLinkButton1"));
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(By.Id("MainContent_UC1_MLinkButton1")).Click();
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
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
        }

    }
}
