using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;

namespace Selenium2.Meridian
{
    class ManageStudents
    {
        public bool ClassroomCalendarView_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ManageStudents.ManageStudents_ClassroomCalendarView_Link);
                driver.GetElement(Locator_ManageStudents.ManageStudents_ClassroomCalendarView_Link).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Mnage Student Classroom Calander View Link", driver);
                return false;
            }
            return true;
        }

        public bool SearchForSectionInMangeStudentsTab(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ManageStudents.ManageStudents_Filter_Button);
            //    driver.GetElement(Locator_ManageStudents.ManageStudents_Search_Textbox).SendKeys(Variables.classroomCourseTitle+browserstr);
                driver.select(Locator_ManageStudents.ManageStudents_PendingAction_Dropdown,"All");
                driver.GetElement(Locator_ManageStudents.ManageStudents_Filter_Button).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Find Section inManage Student Tab", driver);
                return false;
            }
            return true;
        }

        public bool DisplaySections(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ManageStudents.ManageStudents_CCSection_Link);
                driver.GetElement(Locator_ManageStudents.ManageStudents_CCSection_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool SectionTitle_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ManageStudents.ManageStudents_CCSection_Link);
                driver.GetElement(Locator_ManageStudents.ManageStudents_CCSection_Link).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool RosterPage(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ManageStudents.ManageStudents_Enrolled_Tab);
                driver.GetElement(Locator_ManageStudents.ManageStudents_Enrolled_Tab);
                driver.GetElement(Locator_ManageStudents.ManageStudents_Waitlisted_Tab);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool ExportToExcel(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ManageStudents.ManageStudents_ExprtToExcel_Button);
                driver.GetElement(Locator_ManageStudents.ManageStudents_ExprtToExcel_Button).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool EmailToUsers(IWebDriver driver)
        {
            try
            {
                if(Variables.isRoster)
                {
                    driver.WaitForElement(Locator_ManageStudents.ManageStudents_EmailAll_Button);
                    driver.GetElement(Locator_ManageStudents.ManageStudents_EmailAll_Button).Click();
                }
                else{
                    driver.WaitForElement(Locator_ManageStudents.ManageStudents_Email_Button);
                    driver.GetElement(Locator_ManageStudents.ManageStudents_Email_Button).Click();
                }               
                
                driver.SwitchTo().Frame(driver.GetElement(Locator_ManageStudents.ManageStudents_SendEmail_Frame));
                driver.WaitForElement(Locator_ManageStudents.ManageStudents_Send_Button);
                driver.GetElement(Locator_ManageStudents.ManageStudents_Subject_Textbox).SendKeys("TestSubject");
                driver.GetElement(Locator_ManageStudents.ManageStudents_Message_Textbox).SendKeys("TestMessage");
                driver.GetElement(Locator_ManageStudents.ManageStudents_Send_Button).Click();
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public string SuccessMsgDisplayed(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ManageStudents.ManageStudents_SuccessMsg_Link);
                return driver.gettextofelement(Locator_ManageStudents.ManageStudents_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return "";
            }
        }

        public bool ManageNotes_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ManageStudents.ManageStudents_ManageNotes_Button);
                driver.GetElement(Locator_ManageStudents.ManageStudents_ManageNotes_Button ).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool SurveyDisplayed(IWebDriver driver,string browserstr)
        {
            try
            {
                driver.WaitForElement(By.XPath("//a[contains(.,'" + Variables.surveyTitle+browserstr +browserstr+"')]"));
                driver.GetElement(By.XPath("//a[contains(.,'" + Variables.surveyTitle+browserstr +browserstr +"')]"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }
    }

    class Locator_ManageStudents
    {
        public static By ManageStudents_ClassroomCalendarView_Link = By.Id("MainContent_ucInstructorToolsResults_ucLinks_MHyperLink1");
        public static By ManageStudents_Search_Textbox = By.Id("MainContent_ucInstructorToolsResults_ucITSearch_txtSearchFor");
        public static By ManageStudents_Filter_Button = By.Id("MainContent_ucInstructorToolsResults_ucITSearch_btnSearch");
        public static By ManageStudents_PendingAction_Dropdown = By.Id("MainContent_ucInstructorToolsResults_ucITSearch_SectionStatus");
        public static By ManageStudents_CCSection_Link = By.Id("ctl00_MainContent_ucInstructorToolsResults_ucResults_rgInstructorTools_ctl00_ctl04_rgSections_ctl00_ctl04_lnkSection");
        public static By ManageStudents_Enrolled_Tab = By.Id("MainContent_UC1_lnkEnrolledActive");
        public static By ManageStudents_Waitlisted_Tab = By.Id("MainContent_UC1_lnkWaitlisted");
        public static By ManageStudents_ExprtToExcel_Button = By.Id("MainContent_UC2_btnExport");
        public static By ManageStudents_EmailAll_Button = By.Id("MainContent_UC2_MButton1");
        public static By ManageStudents_SendEmail_Frame = By.ClassName("k-content-frame");
        public static By ManageStudents_Subject_Textbox = By.Id("MainContent_UC1_Subject");
        public static By ManageStudents_Message_Textbox = By.Id("MainContent_UC1_Message");
        public static By ManageStudents_Send_Button = By.Id("MainContent_UC1_Send");
        public static By ManageStudents_SuccessMsg_Link = By.XPath("//div[@class='alert alert-success']");
        public static By ManageStudents_Email_Button = By.Id("ctl00_MainContent_UC2_rgEnrolled_ctl00_ctl04_imgSendEmail");
        public static By ManageStudents_ManageNotes_Button = By.Id("ctl00_MainContent_UC2_rgEnrolled_ctl00_ctl04_lnkNotes");
        //public static By ManageStudents_Survey_Link = By.XPath("//a[contains(.,'" + Variables.surveyTitle+browserstr + "')]");
    }
}
