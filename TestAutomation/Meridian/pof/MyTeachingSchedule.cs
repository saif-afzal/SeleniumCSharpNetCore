using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;

namespace Selenium2.Meridian
{
    class MyTeachingSchedule
    {
        public string Days7ScheduleTab_Click(IWebDriver driver)
        {
            string ccSectionName;
            try
            {
                driver.WaitForElement(Locator_MyTeachingSchedule.MyTeachingSchedule_Next7Days_Tab);
                driver.GetElement(Locator_MyTeachingSchedule.MyTeachingSchedule_Next7Days_Tab).Click();

                driver.WaitForElement(Locator_MyTeachingSchedule.MyTeachingSchedule_CourseSectionName_Label);
                ccSectionName = driver.gettextofelement(Locator_MyTeachingSchedule.MyTeachingSchedule_CourseSectionName_Label);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return "";
            }
            return ccSectionName;
        }

        public bool ManageStudentsTab_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_MyTeachingSchedule.MyTeachinSchedule_ManageStudents_Tab);
                driver.GetElement(Locator_MyTeachingSchedule.MyTeachinSchedule_ManageStudents_Tab).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click Mnage Student Tab in Teaching Schedule", driver);
                return false;
            }
            return true;
        }
    }

    class Locator_MyTeachingSchedule
    {
        public static By MyTeachingSchedule_Next7Days_Tab = By.Id("MainContent_ucTeachingSchedule_lb7Days");
     //   public static By MyTeachinSchedule_CourseDate_Label = By.Id("instructor-tools-date");
        public static By MyTeachingSchedule_CourseSectionName_Label = By.XPath("//li[contains(text(),'Section:')]/strong");
        public static By MyTeachinSchedule_ManageStudents_Tab = By.Id("MainContent_ucTabs_lbManageStudents");
    }
}
