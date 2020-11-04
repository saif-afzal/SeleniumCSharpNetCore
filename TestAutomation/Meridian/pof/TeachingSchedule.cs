using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;

namespace Selenium2.Meridian
{
    class TeachingSchedule
    {
        // Classroom Calendar displays with all courses
        public bool ViewCoursesOnCalendar(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_TeachingSchedule.TeachingSchedule_ScheduledCourses_Label);
                driver.GetElement(Locator_TeachingSchedule.TeachingSchedule_ScheduledCourses_Label);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to View Course on Calander", driver);
                return false;
            }
            return true;
        }

    }

    class Locator_TeachingSchedule
    {
        public static By TeachingSchedule_ScheduledCourses_Label = By.ClassName("rsAptContent");

    }
}
