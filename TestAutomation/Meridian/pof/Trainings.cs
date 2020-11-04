using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Reflection;

namespace Selenium2.Meridian
{
    class Trainings
    {
        private readonly IWebDriver driverobj;
        public Trainings(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool SearchContent_Click()
        {
            try
            {
                driverobj.WaitForElement(Locator_Training.Training_searchAndCreateContent_link);
              //  driverobj.GetElement(Locator_Training.Training_searchAndCreateContent_link).ClickWithSpace();
                driverobj.ClickEleJs(Training_searchAndCreateContent_link);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
               
            }
            return true;
        }

        public bool CreateContentButton_Click_New(By courselink)
        {
            try
            {
                driverobj.WaitForElement(Locator_Training.Training_CreateButtonClick);
                driverobj.ClickEleJs(Locator_Training.Training_CreateButtonClick);
                driverobj.WaitForElement(courselink);
                driverobj.ClickEleJs(courselink);
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return true;
        }

        public string SuccessMsg_DeletingCertification()
        {
            string text = string.Empty;
            try
            {
                driverobj.WaitForElement(Locator_Survey.Survey_SuccessMsg_Link);
                text= driverobj.gettextofelement(Locator_Survey.Survey_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "";
            }
            return text;
        }

        // On My Responsibilities tab 
        public bool Performance_Click()
        {
            try
            {
                driverobj.WaitForElement(Locator_Training.Training_Performance_Link);
                driverobj.GetElement(Locator_Training.Training_Performance_Link).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        // On My Responsibilities tab 
        public bool ViewMyTeachingSchedule_Click()
        {
            try
            {
                driverobj.WaitForElement(Locator_Training.Training_ViewMyTeachingSchedule);
                driverobj.GetElement(Locator_Training.Training_ViewMyTeachingSchedule).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool MyTeachingCalendar_Click()
        {
            try
            {
                driverobj.WaitForElement(Locator_Training.Training_MyTeachingCalendar_Link);
                driverobj.GetElement(Locator_Training.Training_MyTeachingCalendar_Link).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }

        public bool ViewCalendarEvents()
        {
            try
            {
                driverobj.WaitForElement(Locator_Training.Training_TeachingSchedule_Frame);
                driverobj.SwitchTo().Frame(driverobj.GetElement(Locator_Training.Training_TeachingSchedule_Frame));
                driverobj.GetElement(Locator_Training.Training_Event_Label);
                driverobj.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return true;
        }


        private By Training_searchAndCreateContent_link = By.XPath("//a[contains(.,'Search & Create Content')]");
        private By Training_SuccessMsg_Link = By.XPath("//div[@class='alert alert-success']");
        private By Training_Performance_Link = By.XPath("//span[contains(.,'Performance')]");
        private By Training_ViewMyTeachingSchedule = By.Id("MainContent_ucInstructorToolsSummary_Summary_lbAllMyTeaching");
        private By Training_MyTeachingCalendar_Link = By.Id("MainContent_ucInstructorToolsSummary_Summary_lbViewCalendar");
        private By Training_TeachingSchedule_Frame = By.Id("k-content-frame");
        private By Training_Event_Label = By.Id("rsAptContent");
    }
}


