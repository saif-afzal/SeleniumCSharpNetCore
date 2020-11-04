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
   class Training
    {
        private readonly IWebDriver driverobj;
        public Training(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool SearchContent_Click()
        {
            try
            { 
                driverobj.WaitForElement(Locator_Training.Training_searchAndCreateContent_link);
                driverobj.ClickEleJs(Locator_Training.Training_searchAndCreateContent_link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public string SuccessMsg_DeletingCertification()
        {
            try
            {
                driverobj.WaitForElement(Locator_Survey.Survey_SuccessMsg_Link);
                return driverobj.gettextofelement(Locator_Survey.Survey_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return "";
            }
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
                return false;
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
                return false;
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
                return false;
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
                return false;
            }
            return true;
        }
    }

    public class Locator_Training
    {
        public static By Training_searchAndCreateContent_link = By.XPath("//a[contains(.,'Search & Create Content')]");
        public static By Training_SuccessMsg_Link = By.XPath("//div[@class='alert alert-success']");
        public static By Training_Performance_Link = By.XPath("//span[contains(.,'Performance')]");
        public static By Training_ViewMyTeachingSchedule = By.Id("MainContent_ucInstructorToolsSummary_Summary_lbAllMyTeaching");
        public static By Training_MyTeachingCalendar_Link = By.Id("MainContent_ucInstructorToolsSummary_Summary_lbViewCalendar");
        public static By Training_TeachingSchedule_Frame = By.Id("k-content-frame");
        public static By Training_Event_Label = By.Id("rsAptContent");
        public static By Training_CreateButtonClick = By.XPath("//button[@data-toggle='dropdown']");

        //for new create button at responsiilities
        public static By GeneralCourseClick = By.XPath("//a[contains(.,'General Course')]");
        public static By AICC_CourseClick = By.XPath("//a[@href='/admin/uploadaicc.aspx']");
        public static By Classroom_CourseClick = By.XPath("//a[@href='/admin/createclassroom.aspx']");
        public static By Scorm_CourseClick = By.XPath("//a[@href='/admin/uploadscormcourse.aspx']");
        public static By Announcement_CourseClick = By.XPath("//a[contains(.,'Announcement')]");
        public static By Document_CourseClick = By.XPath("//a[contains(.,'Document')]");
        public static By Survey_CourseClick = By.XPath("//a[@href='/admin/createsurvey.aspx']");
        public static By Bundle_CourseClick = By.XPath("//a[contains(.,'Bundle')]");
        public static By Certificate_CourseClick = By.XPath("//a[@href='/admin/createcertification.aspx']");
        public static By Curriculum_CourseClick = By.XPath("//a[contains(.,'Curriculums')]");
        public static By OJT_GeneralCourseClick = By.XPath("//a[@href='/admin/createojt.aspx']");
        public static By Subscription_CourseClick = By.XPath("//a[contains(.,'Subscriptions')]");
    }
}


