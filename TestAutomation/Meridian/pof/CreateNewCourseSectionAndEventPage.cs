using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;
using System.Threading;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian
{
    public class CreateNewCourseSectionAndEventPage
    {
        public readonly IWebDriver driverobj;

        public static SchedulePortletCommand SchedulePortlet
        {
            get { return new SchedulePortletCommand(); }
        }

        public CreateNewCourseSectionAndEventPage(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool CreateNewSection(string browserstr)
        {
            bool actualresult = false;
            try
            {
                string format = "M/d/yyyy";
                driverobj.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_Next_Button);
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SectionTitle_Textbox).SendKeys(Variables.sectionTitle + browserstr);
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_Format_OptionButton).Click();
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_Next_Button).Click();

                driverobj.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_SaveAndExitSection_Button);
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_StartDate_Textbox).SendKeys(DateTime.Now.AddDays(2).ToString(format));
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_EndDate_Textbox).SendKeys(DateTime.Now.ToString(format));
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_StartTime_Textbox).SendKeys("12:00 AM");
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_EndTime_Textbox).SendKeys("11:45 PM");

                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_VirtualEventInfo_Button).Click();
                driverobj.SwitchTo().Frame(driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SectionFrame_Frame));
                driverobj.select(Locator_CourseSectionEvent.CourseSectionEvent_VirtualEventType_Dropdown, "Generic");
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_Go_Button).Click();
                driverobj.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_HostId_Textbox);
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_HostId_Textbox).SendKeys("https://www.google.co.in");
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SaveAndExit_Button).Click();
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_SuccessMsg_Link);

                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SelectInstructor_Button).Click();
                driverobj.SwitchTo().Frame(driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SectionFrame_Frame));
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_Lastname_Textbox).SendKeys("user");
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_Search_Button).Click();
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_InstructorName_Checkbox).Click();
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SaveAndExit_Button).Click();
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_SuccessMsg_Link);
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_MinCapacity_Textbox).SendKeys("0");
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_MaxCapacity_Textbox).SendKeys("1");

                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_ChangeEnrollment_Link).Click();
                driverobj.SwitchTo().Frame(driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SectionFrame_Frame));
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_EnrollmentStartDate_Textbox).SendKeys(DateTime.Now.AddDays(2).ToString(format));
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_EnrollmentEndDate_Textbox).SendKeys(DateTime.Now.ToString(format));
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SaveAndExit_Button).Click();
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_SuccessMsg_Link);
                driverobj.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SaveAndExitSection_Button).Click();
                actualresult = driverobj.existsElement(Locator_CourseSectionEvent.CourseSectionEvent_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool CreateNewSectionInPerson(IWebDriver driver, String InstructorLName, string browserstr)
        {
            bool actualresult = false;
            try
            {
                string format = "M/d/yyyy";
                driver.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_Next_Button);
                driver.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_SectionTitle_Textbox);
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SectionTitle_Textbox).SendKeysWithSpace(Variables.sectionTitle + browserstr);
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_Format_OptionButtonInPerson).ClickWithSpace();
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_Next_Button).ClickWithSpace();

                driver.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_SaveAndExitSection_Button);
                driver.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_StartDate_Textbox);
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_StartDate_Textbox).SendKeysWithSpace(DateTime.Now.ToString(format));
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_EndDate_Textbox).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString(format));
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_StartTime_Textbox).SendKeysWithSpace("12:00 AM");
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_EndTime_Textbox).SendKeysWithSpace("11:45 PM");

                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SelectInstructor_Button).ClickWithSpace();
                //Thread.Sleep(5000);
                //driver.SelectFrame();
                driver.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_Lastname_Textbox);
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_Lastname_Textbox).SendKeysWithSpace(InstructorLName);
                driver.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_Search_Button);
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_Search_Button).ClickWithSpace();
                driver.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_InstructorName_Checkbox);
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_InstructorName_Checkbox).ClickWithSpace();
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SaveAndExit_Button).ClickWithSpace();
                //Thread.Sleep(2000);
                //driver.SwitchTo().DefaultContent();
                driver.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_SuccessMsg_Link);
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_MinCapacity_Textbox).SendKeysWithSpace("0");
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_MaxCapacity_Textbox).SendKeysWithSpace("1");

                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_ChangeEnrollment_Link).ClickWithSpace();
                Thread.Sleep(5000);
                //driver.SelectFrame();
                driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_EnrollmentStartDate_Textbox).SendKeysWithSpace(DateTime.Now.ToString(format));
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_EnrollmentEndDate_Textbox).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString(format));
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_EnrollmentStartTime_Textbox).SendKeysWithSpace("12:00 AM");
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_EnrollmentEndTime_Textbox).SendKeysWithSpace("11:45 PM");
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SaveAndExit_Button_Enrollmentpopup).ClickWithSpace();
                driver.SwitchTo().DefaultContent();
                driver.WaitForElement(Locator_CourseSectionEvent.CourseSectionEvent_SaveAndExitSection_Button);
                driver.GetElement(Locator_CourseSectionEvent.CourseSectionEvent_SaveAndExitSection_Button).ClickWithSpace();
                actualresult = driver.existsElement(Locator_CourseSectionEvent.CourseSectionEvent_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                driver.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, ex.Message, ex.StackTrace);


            }
            return actualresult;
        }

        public static void SectionTitleAs(string v)
        {
            Driver.existsElement(By.Id("section-title"));
            Driver.GetElement(By.Id("section-title")).Clear();
            Driver.GetElement(By.Id("section-title")).SendKeysWithSpace(v);
            Thread.Sleep(2000);
        }

        public static void CreateSection(string sectiontitle, string schedulestartswith = "", string scheduleendswith = "", string enrollmentstartswith = "", string enrollmentendswith = "")
        {
            Driver.GetElement(By.Id("section-title")).SendKeysWithSpace(sectiontitle);
            Driver.GetElement(By.Id("startDate")).Clear();
            Driver.GetElement(By.Id("startDate")).SendKeysWithSpace(schedulestartswith);
            Driver.GetElement(By.Id("endDate")).Clear();
            Driver.GetElement(By.Id("endDate")).SendKeysWithSpace(scheduleendswith);
           
            //Driver.GetElement(By.Id("enrollmentStartDate")).Clear();
            //Driver.GetElement(By.Id("enrollmentStartDate")).SendKeysWithSpace(enrollmentstartswith);
            //Driver.GetElement(By.Id("enrollmentEndDate")).Clear();
            //Driver.GetElement(By.Id("enrollmentEndDate")).SendKeysWithSpace(enrollmentendswith);
            Driver.clickEleJs(By.Id("btnCreate"));
            Driver.getSuccessMessage();
        }

        public static bool? isDisplayed()
        {
            throw new NotImplementedException();
        }

        public static bool? isVirtualMeetingTypeDisplayed()
        {
            throw new NotImplementedException();
        }

        public static void SelectGotoMeeting()
        {
            throw new NotImplementedException();
        }

        public static bool? isVirtualMeetingHostDisplayed()
        {
            throw new NotImplementedException();
        }

        public static void SelectVirtualMeetingHost()
        {
            throw new NotImplementedException();
        }

        public static void ClickDone()
        {
            throw new NotImplementedException();
        }

        public static bool? isSelectInstructorModalDisplayed()
        {
            throw new NotImplementedException();
        }

        public static void SetInstructor()
        {
            throw new NotImplementedException();
        }

        public static void ClickCreate()
        {
            throw new NotImplementedException();
        }

      

       

        public static void SelectInstructor(string v)
        {
            Driver.clickEleJs(By.XPath("//button[@id='instructor_0']"));
            Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_instructorName']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@id='instructorsearch']"));
            Driver.clickEleJs(By.XPath("//td[contains(text(),'" + v + "')]/preceding::input[1]"));
            Driver.clickEleJs(By.XPath("//button[@id='btnSetInstructor']"));



        }

        public static string SectionStartDate()
        {
            return Driver.GetElement(By.XPath("//input[@id='startDate']")).Text;
        }

        public static string SectionEndDate()
        {
            return Driver.GetElement(By.XPath("//input[@id='endDate']")).Text;
        }
    }

    public class SchedulePortletCommand
    {
        public SchedulePortletCommand()
        {
        }

        public void AllDayevent(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='event0']/div/div/div/div/div/span[2]"));
            Driver.GetElement(By.XPath("//div[@id='event0']/div/div/div/div/div/span[2]")).ClickWithSpace();
        }

        public void SelectVirtualClassroom()
        {
            throw new NotImplementedException();
        }

        public void VirtualMeetingType()
        {
            throw new NotImplementedException();
        }

        public void SelectInstructor()
        {
            throw new NotImplementedException();
        }
    }

    class Locator_CourseSectionEvent
    {
        public static By CourseSectionEvent_EnrollmentStartTime_Textbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput");
        public static By CourseSectionEvent_EnrollmentEndTime_Textbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput");
        public static By CourseSectionEvent_FramePath = By.XPath("//div[@id='KendoUIMGDialog']/iframe");
        public static By CourseSectionEvent_Format_OptionButtonInPerson = By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_FORMAT_0");
        public static By CourseSectionEvent_SectionTitle_Textbox = By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_TITLE");
        public static By CourseSectionEvent_Next_Button = By.Id("MainContent_MainContent_UC1_btnNext");
        public static By CourseSectionEvent_Format_OptionButton = By.Id("MainContent_UC1_FormView1_CRSSECT_FORMAT_1");
        public static By CourseSectionEvent_StartDate_Textbox = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput");
        public static By CourseSectionEvent_EndDate_Textbox = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput");
        public static By CourseSectionEvent_StartTime_Textbox = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_TIME_dateInput");
        public static By CourseSectionEvent_EndTime_Textbox = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_TIME_dateInput");
        public static By CourseSectionEvent_SelectInstructor_Button = By.Id("MainContent_MainContent_UC1_FormView1_lnkSelectInst");
        public static By CourseSectionEvent_SectionFrame_Frame = By.ClassName("k-content-frame");
        public static By CourseSectionEvent_SaveAndExitSection_Button = By.Id("MainContent_MainContent_UC1_btnSave");
        public static By CourseSectionEvent_Lastname_Textbox = By.Id("MainContent_MainContent_UC1_USR_LAST_NAME");
        public static By CourseSectionEvent_Search_Button = By.Id("MainContent_MainContent_UC1_btnSearch");
        public static By CourseSectionEvent_InstructorName_Checkbox = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_SectionInstructorSearch_ctl00_ctl04_chkSelect");
        public static By CourseSectionEvent_SaveAndExit_Button = By.Id("MainContent_MainContent_UC1_Save");
        public static By CourseSectionEvent_SaveAndExit_Button_Enrollmentpopup = By.Id("MainContent_UC1_Save");
        public static By CourseSectionEvent_MinCapacity_Textbox = By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY");
        public static By CourseSectionEvent_MaxCapacity_Textbox = By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY");
        public static By CourseSectionEvent_ChangeEnrollment_Link = By.Id("MainContent_MainContent_UC1_FormView1_lnkEnrollInfo");
        public static By CourseSectionEvent_EnrollmentStartDate_Textbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_dateInput");
        public static By CourseSectionEvent_EnrollmentEndDate_Textbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_dateInput");
        public static By CourseSectionEvent_VirtualEventInfo_Button = By.Id("MainContent_UC1_FormView1_lnkSelectVirtual");
        public static By CourseSectionEvent_HostId_Textbox = By.Id("MainContent_UC1_FormView1_EVT_HOST_URL");
        public static By CourseSectionEvent_SuccessMsg_Link = By.XPath("//div[@class='alert alert-success']");
        public static By CourseSectionEvent_VirtualEventType_Dropdown = By.Id("EVT_VIRTUAL_FORMAT");
        public static By CourseSectionEvent_Go_Button = By.Id("MainContent_UC1_FormView1_btnGo");
    }
}
