using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;
using System.Threading;

namespace Selenium2.Meridian
{
    class CreateCurriculum 
    {
        private readonly IWebDriver driverobj;
        public TrainingHomes objTrainingHome;
        public Trainings Trainingsobj;
        public Create objCreate;
        public Document documentobj;
        public Scorm1_2 Scorm1_2obj;
        public Content objContent;
        public TrainingActivities TrainingActivitiesobj;
        public TrainingActivities objTrainingActivities;
        public AddContent objAddContent;
        public ClassroomCourse classroomcourse;

        public CreateCurriculum(IWebDriver driver)
        
        {
            driverobj = driver;
            objTrainingHome = new TrainingHomes(driver);
            Trainingsobj = new Trainings(driver);
            objCreate = new Create(driver);
            documentobj = new Document(driver);
            Scorm1_2obj = new Scorm1_2(driver);
            objContent = new Content(driver);
            TrainingActivitiesobj = new TrainingActivities(driver);
            objTrainingActivities = new TrainingActivities(driver);
            objAddContent = new AddContent(driver);
            classroomcourse = new ClassroomCourse(driver);
        }

        public bool createCurriculum(string browserstr)
        {
            bool result = false;

            try
            {
                
                objTrainingHome.MyResponsiblities_click();
                Trainingsobj.CreateContentButton_Click_New(Locator_Training.Curriculum_CourseClick);
                objCreate.FillCurriculumPage("", browserstr);
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool manageCurriculum(string type, string browserstr)
        {
            bool result = false;
            try
            {
                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucSummary_lnkEdit']"));
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'Summary')]"));
                driverobj.GetElement(By.XPath("//textarea[@id='MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS']")).SendKeysWithSpace(" Edited for regression");
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumCategory(string type, string browserstr)
        {
            bool result = false;
            try
            {
                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                driverobj.Checkout();
                Scorm1_2obj.setCategory();

                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumCertificate(string type, string browserstr)
        {
            bool result = false;
            try
            {
                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);

                Scorm1_2obj.setCertificate(browserstr);
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumCost(string type, string browserstr)
        {
            bool result = false;
            try
            {
                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);

                Scorm1_2obj.setCost();
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumAlternativeCost(string type, string browserstr)
        {
            bool result = false;
            try
            {
                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);

                Scorm1_2obj.setAlternateCost();
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumImage(string type, string browserstr)
        {
            bool result = false;
            try
            {
                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                documentobj.sètImage(browserstr);
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumActivity(string type, string browserstr)
        {
            bool result = false;
            try
            {
                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                documentobj.editActivityMarkInactive();
                Scorm1_2obj.verifyActivityInactive(browserstr, Variables.curriculumTitle + browserstr + type);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                driverobj.Checkout();
                documentobj.editActivityMarkActive();
                Scorm1_2obj.verifyActivityactive(Variables.curriculumTitle + browserstr + type, browserstr);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                driverobj.Checkout();
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumDelete()
        {
            bool result = false;
            try
            {

                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumContentSharing(string type, string browserstr)
        {
            bool result = false;
            try
            {
                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                documentobj.shareDocument(browserstr);
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumSurvey(string type, string browserstr)
        {
            bool result = false;
            try
            {
                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_MainContent_UC4_hlManage']"));
                driverobj.ClickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC4_hlManage']"));
                driverobj.WaitForElement(By.XPath("//input[@class='btn btn-primary']")); 
                driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary']"));
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']"));
                driverobj.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace("Survey Regression Daily");
                driverobj.ClickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
                driverobj.WaitForElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect']"));
                driverobj.ClickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect']"));
                driverobj.ClickEleJs(By.XPath("//input[@class='btn btn-primary pull-right']"));
                driverobj.WaitForElement(By.XPath("//div[@class='alert alert-success']"));
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumAddTrainingActivity(string type, string browserstr)
        {
            bool result = false;
            try
            {
                objTrainingHome.MyResponsiblities_click();
                Trainingsobj.CreateContentButton_Click_New(Locator_Training.GeneralCourseClick);
                objCreate.FillGeneralCoursePage("", browserstr);
                driverobj.WaitForElement(ObjectRepository.CheckinNew);
                //driverobj.ClickEleJs(ObjectRepository.CheckinNew);

                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                objContent.Edit_TrainingActivities();
                TrainingActivitiesobj.Click_AddCurriculamBlock();
                TrainingActivitiesobj.Click_SaveandExitCurriculamBlock("", browserstr);
                objTrainingActivities.AddTrainingActivities_Click();
                objAddContent.SearchAndAddActivityGC(browserstr);
                //String assertion on adding training activities
                String successMsg1 = objAddContent.SuccessMsg();

                String successMsg = objContent.SuccessMsgDisplayed();
                //    StringAssert.Contains("The item was created.", successMsg);
               
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool curriculumAddTrainingActivityClassroom(string type, string browserstr)
        {
            bool result = false;
            try
            {
                string expectedresult = " The item was created.";
                objTrainingHome.MyResponsiblities_click();
                Trainingsobj.CreateContentButton_Click_New(Locator_Training.Classroom_CourseClick);
                classroomcourse.populateClassroomform(ExtractDataExcel.MasterDic_classrommcourse["Title"] + "Create" + browserstr, ExtractDataExcel.MasterDic_classrommcourse["Desc"]);
                driverobj.Compareregexstring(expectedresult, classroomcourse.buttonsaveclick());

                classroomcourse.linkSectionsClick();
                classroomcourse.addNewSectionClick();
                classroomcourse.populatesectionform1(browserstr);
                classroomcourse.populatesectionform12();
                classroomcourse.populateframeform();
                classroomcourse.buttonsaveframeclick();

                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                objContent.Edit_TrainingActivities();
                TrainingActivitiesobj.Click_AddCurriculamBlock();
                TrainingActivitiesobj.Click_SaveandExitCurriculamBlock("", browserstr);
                objTrainingActivities.AddTrainingActivities_Click();
                objAddContent.SearchAndAddActivityClassroom(browserstr);
                //String assertion on adding training activities
                String successMsg1 = objAddContent.SuccessMsg();

                String successMsg = objContent.SuccessMsgDisplayed();
                //    StringAssert.Contains("The item was created.", successMsg);

                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }


        public bool curriculumApprovalPath(string type, string browserstr)
        {
            bool result = false;
            try
            {
                Document documentpage = new Document(driverobj);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                documentobj.editApprovalEnable();
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driverobj.UserLogin("userforregression", browserstr);
                Scorm1_2obj.verifyApprovalPath(browserstr, Variables.curriculumTitle + browserstr + type);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driverobj.UserLogin("admin1", browserstr);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                driverobj.Checkout();

                documentobj.editApprovalDiable();
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driverobj.UserLogin("userforregression", browserstr);
                Scorm1_2obj.verifyApprovalPathAfterRemoval(browserstr, Variables.curriculumTitle + browserstr + type);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driverobj.UserLogin("admin1", browserstr);
                documentpage.linkmyresponsibilitiesclick();
                documentobj.searchForContentFromAdminSide("scorm", browserstr, Variables.curriculumTitle + browserstr + type);
                driverobj.Checkout();
                result = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
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
}
