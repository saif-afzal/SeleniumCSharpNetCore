using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;

using relativepath;
using System.Collections.ObjectModel;
using System.Reflection;
namespace Selenium2.Meridian
{
    class MyTasks
    {
        private readonly IWebDriver driverobj;
        public MyTasks(IWebDriver driver)
        {
            driverobj = driver;
        }
        public void tabcontentmanagementclick()
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.classroomCoursesLink);
                driverobj.GetElement(ObjectRepository.classroomCoursesLink).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.goCreateClassroombtn);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Create on Content Managment Tab", driverobj);
            }

        }
        public string testcode()
        {
            string format = "MM/dd/yyyy";
            try
            {
                driverobj.ScrollToCoordinated("1500", "1500");
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Schedule Evaluation')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Schedule Evaluation')]")).ClickWithSpace();
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_START_DATE_dateInput"));
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_START_DATE_dateInput")).SendKeysWithSpace(DateTime.Now.ToString(format));
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_END_DATE_dateInput")).SendKeysWithSpace(DateTime.Now.ToString(format));
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_START_TIME_dateInput")).SendKeysWithSpace("12");
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_FormView1_CER_SCHEDULED_END_TIME_dateInput")).SendKeysWithSpace("12");
             //   driverobj.GetElement(By.XPath("//h2[contains(.,'Evaluation Date & Time')]")).ClickWithSpace();
                driverobj.GetElement(By.Id("MainContent_UC1_btnSave")).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(locator.sectionsucessmessage);
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return driverobj.gettextofelement(locator.sectionsucessmessage);
        }
        public void populatesummaryojt(IWebDriver iSelenium, string title, string desc, int i)
        {

            try
            {
                driverobj.WaitForElement(ObjectRepository.genCourseTitle_ED);
                driverobj.GetElement(ObjectRepository.genCourseTitle_ED).ClickWithSpace();
                driverobj.GetElement(ObjectRepository.genCourseTitle_ED).SendKeys(title);
                driverobj.SetDescription1(desc_htmleditor, desc_htmlcontrol, ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                //Thread.Sleep(4000);
                //ojt.GetElement(ObjectRepository.ojtdescription).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                //if (!driverobj.existsElement(locator.classroomDesc))
                //{
                //    driverobj.SelectFrame();
                //    driverobj.GetElement(By.CssSelector("body")).ClickWithSpace();
                //    driverobj.GetElement(By.CssSelector("body")).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Desc"]);

                //    driverobj.SwitchTo().DefaultContent();
                //}
                //else
                //{
                //    driverobj.GetElement(locator.classroomDesc).SendKeys(ExtractDataExcel.MasterDic_genralcourse["Desc"]);
                //}
                // driverobj.WaitForElement(locator.classroomDesc);
                //driverobj.GetElement(locator.classroomDesc).ClickWithSpace();
                //driverobj.GetElement(locator.classroomDesc).SendKeys(desc);
                driverobj.GetElement(locator.generalcoursekeyword).SendKeys(desc);
              //  driverobj.GetElement(By.XPath("//textarea[contains(@id,'INFO')]")).SendKeys("1234567890");
                //     ojt.FindSelectElementnew(locator.ojttrainingpurposetype, "New Work Assignment");
                //    ojt.FindSelectElementnew(locator.ojttrainingsourcetypecode, "Government Internal");
                //    ojt.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNTEHRI_TUITION_FEE_COST']")).SendKeys("100");
                //    ojt.GetElement(By.XPath("//input[@id='MainContent_UC1_FormView1_CNTEHRI_NON_GOVT_COST']")).SendKeys("100");
                //   ojt.GetElement(By.XPath("//input[@id='MainContent_UC1_CRSW_DURATION']")).SendKeys("10");
                //   ojt.GetElement(By.XPath("//input[@id='MainContent_UC1_CRSW_CREDIT_VALUE']")).SendKeys("5");
                //  ojt.select(By.XPath("//select[@id='MainContent_UC1_CRSW_CREDIT_TYPE']"), "Continuing Education Units");

                //driverobj.GetElement(locator.driverobjuniqueid).Clear();
                //driverobj.GetElement(locator.driverobjuniqueid).SendKeys(locator.globalnum + i);

                //ojt.GetElement(ObjectRepository.nxt_btn).ClickWithSpace();
                // Thread.Sleep(10000);
                // ojt.WaitForElement(ObjectRepository.ojtrd_btn);
                //  tocreateojt = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
        }
        public void populateselectcoursecreation(string selecttext)
        {

            try
            {
                driverobj.select(ObjectRepository.selectcoursetype, selecttext);
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void buttongoclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.goCreategeneralcoursebtn).ClickWithSpace();
              
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void buttoncreatenewclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.create_btn_new).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.sectionsucessmessage);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void buttoncreateandmanagechecklistclick()
        {

            try
            {
                driverobj.GetElement(By.Id("MainContent_hlChecklist")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("MainContent_MainContent_ucTopBar_MLinkButton1"));

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void useandexistingchecklistclick()
        {

            try
            {
                driverobj.GetElement(By.Id("MainContent_MainContent_ucTopBar_MLinkButton1")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("MainContent_MainContent_UC1_SearchFor"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void populatechecklistsearch(string searchtext,string filter)
        {

            try
            {
                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_SearchFor")).ClickWithSpace();
                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_SearchFor")).SendKeys(searchtext);
                driverobj.FindSelectElementnew(ObjectRepository.manageaccessapprovalfiltercombobox, filter);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void buttonchecklistsearchclick()
        {

            try
            {
                driverobj.GetElement(By.Id("btnSearchChecklists")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgChecklistSearch_ctl00_ctl04_chkSelect"));

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void selectandclickaddclick()
        {

            try
            {
                driverobj.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgChecklistSearch_ctl00_ctl04_chkSelect")).ClickWithSpace();
                driverobj.GetElement(By.Id("MainContent_MainContent_UC1_btnAdd")).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.CheckinNew);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void buttonCheckinclick()
        {

            try
            {
                driverobj.GetElement(ObjectRepository.CheckinNew).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.myResponsibilities);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void tabmyownlearningclick()
        {

            try
            {
                //driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                //driverobj.UserLogin("admin");
                driverobj.GetElement(ObjectRepository.myOwnlearning).ClickAnchor();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void buttonenrolojtclick()
        {

            try
            {
                driverobj.WaitForElement(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollOJT"));
                driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollOJT")).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.sectionsucessmessage);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void buttonlaunchojtclick()
        {

            try
            {
                driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_OJTLaunchAttempt")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("ctl00_MainContent_ucOJT_FormView1_rgRequired_ctl00_ctl04_lnkDetails"));

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void linktestchecklistclick()
        {

            try
            {
                driverobj.GetElement(By.Id("ctl00_MainContent_ucOJT_FormView1_rgRequired_ctl00_ctl04_lnkDetails")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("MainContent_ucChecklistDetails_FormView1_SelectAndSubmitEvalRequest"));

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void populateframeevaluators()
        {

            try
            {
                driverobj.WaitForElement(By.Id("MainContent_ucChecklistDetails_FormView1_SelectAndSubmitEvalRequest"));
                driverobj.GetElement(By.Id("MainContent_ucChecklistDetails_FormView1_SelectAndSubmitEvalRequest")).ClickWithSpace();
               
                //driverobj.SelectFrame();
                driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect"));
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect")).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public void buttonsaveframeclick()
        {

            try
            {
                driverobj.GetElement(By.Id("MainContent_UC1_FormView1_Save")).ClickWithSpace();
                driverobj.SwitchTo().DefaultContent();
                driverobj.WaitForElement(ObjectRepository.sectionsucessmessage);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }
        public string mailcheck()
        {

            try
            {

                driverobj.GetElement(By.Id("NavigationStrip1_qucMessages_imgQueueIcon")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkSubject"));
                string actualresult = driverobj.gettextofelement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkSubject"));
                return actualresult;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return "";
            }

        }
        private By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
        private By desc_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        public static class locator
        {

            public static string globalnum = string.Format("{0:ddhhssmmss}", DateTime.Now);
            public static By driverobjuniqueid = By.Id("MainContent_UC1_CNT_NUMBER");
            public static By myresponsibilitiescontentmanagementtab = By.XPath("//span[contains(.,'Content Management')]");
            public static By selectcoursetype = By.Id("MainContent_ucSearchTop_ddlCreateNew");
            public static By goCreategeneralcoursebtn = By.Id("MainContent_ucSearchTop_btnCreateNew");
            public static By NxtBtn = By.Id("MainContent_UC1_btnNext");
            public static By StartDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput");
            public static By EndDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput");
            public static By AllDayEvnt = By.Id("MainContent_UC1_FormView1_EVT_ALLDAYEVENT");
            public static By MinimumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY");
            public static By MaximumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY");
            public static By SaveAndExit = By.Id("MainContent_UC1_btnSave");
            public static By ChangeEnrolDate = By.Id("MainContent_UC1_FormView1_lnkEnrollInfo");
            public static By EnroStartDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_dateInput");
            public static By EnrolEndDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_dateInput");
            public static By EnroStartDate_ = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_popupButton");
            public static By EnrolEndDate_ = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_popupButton");
            public static By EnrolStartTime = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput_text");
            public static By EnrolEndTime = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput_text");
            public static By ClassroomCalendarView = By.Id("MainContent_MainContent_ucTopBar_FormView1_hlSectionCalendar");
            public static By manageenrollmentenrolusersbutton = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnEnrollUser");
            public static By manageenrollmentmanageenrollmentbutton = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnManageEnrollment");
            public static By cancelenrolmentselectwaitlistcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl06_cbSelected");
            public static By cancelenrolmentselectenrolledcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_cbSelected");
            public static By cancelenrolmentorwaitlistreasontextbox = By.Id("MainContent_UC1_tbUnenrollReason");
            public static By cancelenrolmentorwaitlistcancelenrolmentorwaitlistbutton = By.Id("MainContent_UC1_btnCancelEnrollWaitlist");
            public static By waitlistuserswaitlistusersbutton = By.Id("MainContent_UC1_btnWaitlistUsers");
            public static By batchenrollmentlastnametxtbox = By.Id("MainContent_UC1_USR_LAST_NAME");
            public static By batchenrollmentfirstnametxtbox = By.Id("MainContent_UC1_USR_FIRST_NAME");
            public static By batchenrollmentsearchbutton = By.Id("MainContent_UC1_btnSearch");
            public static By batchenrollmentselectcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_cbEnrolluser");
            public static By waitlistselectcheckbox = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_cbWaitlist");
            public static By batchenrollmenttablelastnamelabel = By.XPath("//td[contains(.,'Site')]");
            public static By batchenrollmentbatchenrollusersbutton = By.Id("MainContent_UC1_btnEnrollUsers");
            public static By manageenrollmentmanagewaitlistbutton = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnManageWaitlist");
            public static By batchenrollmentfeedback = By.XPath("//div[@class='alert alert-success']");
            public static By schedulemanagesectionSearcfortxtbox = By.Id("filterNameCode");
            public static By schedulemanagesectionSectionstatusdrpdwn = By.Id("MainContent_MainContent_ucTopBar_ddlSectionStatus");
            public static By schedulemanagesectionActivitydrpdwn = By.Id("MainContent_MainContent_ucTopBar_ddlSearchActivity");
            public static By schedulemanagesectionStartdatetxtbox = By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rdStartDate_dateInput");
            public static By schedulemanagesectionEnddatetxtbox = By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rdEndDate_dateInput");
            public static By schedulemanagesectionFilterbutton = By.XPath(".//*[@id='MainContent_pnlMVCSection']/div[1]/div[2]/div/div[1]/div/span/button");
            public static By schedulemanagesectionResulttable = By.XPath("//tr[@id = 'ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0']/td/a");
            public static By schedulemanagesectionclassroomcalendarlink = By.Id("MainContent_MainContent_ucTopBar_FormView1_hlSectionCalendar");
            public static By editeventselectlocationbutton = By.Id("MainContent_UC1_FormView1_lnkSelectLoc");
            public static By selectlocationframesearchbutton = By.Id("MainContent_UC1_btnSearch");
            public static By selectlocationframesroomtyperadiobutton = By.Id("ctl00_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect");
            public static By selectlocationframessaveandexitbutton = By.Id("MainContent_UC1_Save");
            public static By selectlocationssuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By LogoutHoverLink = By.XPath("//a[normalize-space()='Logout']");
            public static By classroomcalendarviewlink = By.XPath("//a[contains(@id,'lnkDetails')]");
            public static By ClassroomcourseSave = By.Id("MainContent_UC1_Save");
            public static By classroomCoursesLink = By.XPath("//span[contains(.,'Content Management')]");
            public static By classroomTitle = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
            public static By classroomDesc = By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']");
            public static By classroomDesc1 = By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']");
            public static By classroomKeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By classroomsectionMinimumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY");
            public static By classroomsectionMaximumCapacity = By.Id("MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY");
            public static By contentaccessapprovaleditbutton = By.Id("MainContent_MainContent_ucAccessApproval_accAccesApproval_lnkEdit");
            public static By contentaccessapprovalsuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By contentdeletecontentbutton = By.Id("MainContent_header_FormView1_btnDelete");
            public static By contentmanagelink = By.Id("MainContent_MainContent_UC4_hlManage");
            public static By managestudentsmanagesurveylink = By.Id("MainContent_UC4_hlManage");
            public static By sectiondetailsmanagelink = By.Id("MainContent_MainContent_ucdriverobjs_hlManage");
            public static By surveysassignsurveyslink = By.Id("MainContent_UC1_btnAssignSurveys");
            public static By surveyframesearchtxtbox = By.Id("MainContent_UC1_txtSearchFor");
            public static By surveyframesearchtxtfilter = By.Id("MainContent_UC1_ddlSearchType");
            public static By surveyframesearchbutton = By.Id("MainContent_UC1_btnSearch");
            public static By surveyframeselectchkbox = By.Id("ctl00_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect");
            public static By surveyframesavebutton = By.Id("MainContent_UC1_Save");
            public static By surveyremovebutton = By.Id("MainContent_UC1_btnRemove");
            public static By contentsearchSearchAdvlnk = By.Id("MainContent_ucSearchTop_FormView1_lblSeeMore");
            public static By contentsearchSearchfortxtbx = By.Id("MainContent_ucSearchTop_FormView1_SearchFor");
            public static By contentsearchSearchfilterdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchType");
            public static By contentsearchSearchTitletxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_TITLE");
            public static By contentsearchSearchDescriptiontxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_DESCRIPTION");
            public static By contentsearchSearchKeywordstxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNT_KEYWORDS");
            public static By contentsearchSearchCategorytxtbx = By.Id("MainContent_ucSearchTop_FormView1_CNTCTGY_CATEGORY_ID");
            public static By contentsearchSearchRatingfilterdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_strRatingType");
            public static By contentsearchSearchRatingdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_intRating");
            public static By contentsearchSearchEditingStatusdrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchStatusType");
            public static By contentsearchSearchActivitydrpdwn = By.Id("MainContent_ucSearchTop_FormView1_SearchActivity");
            public static By contentsearchSearchbutton = By.Id("btnSearchCourses");
            public static By contentsearchResultTable = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By contentsearchItemscountlbl = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By MyRespnsibilitySearch = By.Id("MainContent_ucAdminQuickSearch_txtSearch");
            public static By MyRespnsibilitySearchFilter = By.Id("ddlSearchType");
            public static By MyRespnsibilitySearchButton = By.Id("btnContentSearch");
            public static By ContentSearchResultTitle = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By contentsearchresultcount = By.XPath("/html/body/form/div[6]/div/div[6]/div/div[3]");
            public static By sectiondetailscopybutton = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkCopy");
            public static By copyframedatetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_NEWSTART_DATE_dateInput");
            public static By copyframetimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_NEWSTART_TIME_dateInput");
            public static By copyframecopybutton = By.Id("MainContent_UC1_Save");
            public static By sectiondetailssuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By courseinformationtrainingpurposetypecodedrpdwn = By.Id("MainContent_UC1_FormView1_EREP_DET_TRG_PURPOSE_TYPE");
            public static By courseinformationtrainingsourcetypecodedrpdwn = By.Id("MainContent_UC1_FormView1_EHRI_CRSW_TR_SRC_TYP_CO");
            public static By courseinformationuniqueidtextbox = By.Id("MainContent_UC1_CNT_NUMBER");
            public static By CourseSectionLink1 = By.Id("MainContent_MHyperLink2");
            public static By eventselecteventcheckbox = By.Id("ctl00_MainContent_UC1_rgEvents_ctl00_ctl04_chkSelect");
            public static By eventremoveeventbutton = By.Id("MainContent_UC1_FormViewButton_btnGo");
            public static By deleteeventsuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By detailsenrolbutton = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_btnEnroll");
            public static By detailssectioninfo = By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/img");
            public static By myresponsibilitiesmycontenttitlelink = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By myresponsibilitiesaddnew = By.Id("MainContent_ucLastModifiedContent_hlAddNew");
            public static By myresponsibilitiesinstructortoolsportletdrpdwn = By.Id("MainContent_ucInstructorToolsSummary_Instructor");
            public static By myresponsibilitiesinstructortoolsportletbutton = By.Id("MainContent_ucInstructorToolsSummary_btnSearch");
            public static By myresponsibilitiesinstructortoolsportlettableresult = By.Id("ctl00_MainContent_ucInstructorToolsSummary_RadGrid1_ctl00_ctl04_lnkDetails");
            public static By myresponsibilitiesinstructortoolsportlettableresultcount = By.XPath("//div[3]/div[2]/table/tbody/tr");
            public static By detailseventschedulesectiontitle = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl06_rgEvents_ctl00_ctl04_MLabel2");
            public static By sectiondetailediteventlink = By.Id("MainContent_MainContent_ucSectionEvents_MAccordion1_lbEdit");
            public static By eventseditbutton = By.Id("ctl00_MainContent_UC1_rgEvents_ctl00_ctl04_btnGo");
            public static By editeventstrttimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_EVT_START_TIME_dateInput");
            public static By editeventendtimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_EVT_END_TIME_dateInput");
            public static By editeventsaveandexitbutton = By.Id("MainContent_UC1_btnSave");
            public static By eventssuccessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By expensesprofessionalservices = By.Id("CRSSECT_PROF_SERVICE");
            public static By expensesfacilityservices = By.Id("MainContent_UC1_FormView1_CRSSECT_FACILITY_FEES");
            public static By expensestravelexpenses = By.Id("MainContent_UC1_FormView1_CRSSECT_TRAVEL_EXPENSES");
            public static By expensesequipmentrental = By.Id("MainContent_UC1_FormView1_CRSSECT_EQUIPMENT_RENTAL");
            public static By expensessavebutton = By.Id("MainContent_UC1_Save");
            public static By managestudentsinstructortoolslink = By.XPath("/html/body/form/div[6]/div/div[2]/div/div/ul/li[4]/a/span");
            public static By managestudentsmyteachingscheduletab = By.Id("MainContent_UC1_lbMyTeachingSchedule");
            public static By managestudentsmanagestudentstab = By.Id("MainContent_UC1_lbManageStudentsActive");
            public static By searchHome = By.Id("btnContentSearch");
            public static By goCreateClassroombtn = By.Id("MainContent_ucSearchTop_btnCreateNew");
            public static By informationcitylabel = By.Id("MainContent_UC1_PopUpUserInfo_lblCityTxt");
            public static By manageenrolmentforonlinecoursebuttonenrollcourse = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnEnrollUser");
            public static By manageenrolmentforonlinecoursesearchbutton = By.Id("btnSearchCourses");
            public static By manageenrolmentforonlinecoursesearchtextbox = By.Id("MainContent_ucSearchTop_FormView1_SearchFor");
            public static By manageenrolmentforonlinecoursefilterdropdown = By.Id("MainContent_ucSearchTop_FormView1_SearchType");
            public static By manageenrolmentforonlinecourseresulttablelink = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
            public static By myResponsibilities = By.Id("NavigationStrip1_lbMyResponsibilities");
            public static By manageenrolmentforonlinecoursemanageenrollment = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnManageEnrollment");

            // general course
            public static By create_btn_new = By.Id("MainContent_UC1_Save");
            public static By genCourseTitle_ED = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
            public static By generalcourseenroll_btn = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton");
            public static By generalcoursekeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By myresponsibilitiesmanageenrolmentonlinecourses = By.Id("MainContent_ucManageEnrollmentMenu_hlManageOnlineEnrollement");

            public static By myresponsibilitiesmostrecentrequestusernamelink = By.Id("ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_lnkContentTitle");
            public static By myresponsibilitiesmostrecentrequestcontenttitlelink = By.Id("ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_lnkSectionTitle");
            public static By myresponsibilitiestodaylink = By.Id("MainContent_ucBrowseByDate_CreatedBy");
            public static By myresponsibilitiesviewallcoursesbutton = By.Id("MainContent_ucLastModifiedContent_lbAllContent");
            public static By org_select_link = By.Id("MainContent_UC1_lnkSelectOrg");
            public static By org_search_text = By.Id("MainContent_UC1_txtSearch");
            public static By org_search_btn = By.Id("MainContent_UC1_btnSearch");
            public static By org_radio_btn = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect");
            public static By org_save_btn = By.Id("MainContent_UC1_Save");
            public static By org_create_btn = By.Id("MainContent_UC1_Create");
            public static By login_name = By.CssSelector("span.rmText.rmExpandDown");

            public static By createnewcoursesectionandeventradiobutton = By.Id("MainContent_UC1_FormView1_CRSSECT_WAITLIST_OPTION_0");
            public static By scheduleandmanagesectionsmanageenrollmentbutton = By.Id("MainContent_header_FormView1_lnkManageEnroll");
            public static By schedulemanagesectionsectiontitlelink = By.CssSelector("#ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0 > td > a");
            public static By sectiondetailsEdit = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkEdit");
            public static By contentclassroomtitlelabel = By.Id("MainContent_MainContent_ucSummary_FormView1_MLabel2");
            public static By sectiondetaildeletesectionbutton = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkDelete");
            public static By sectiondetailsdeletemessage = By.XPath("//div[@class='alert alert-success']");
            public static By sectiondetailexpenseseditlink = By.Id("MainContent_MainContent_ucSectionExpenses_MAccordion1_lbEdit");
            public static By sectiondetailexpensestotal = By.Id("MainContent_MainContent_ucSectionExpenses_MAccordion1_lblTotalValue");
            public static By sectionenrolsucessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By sectioninformationclosewindowlink = By.Id("ML.BASE.CMD.CloseWindow");
            public static By sectionsucessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By sucessmessage = By.XPath("//div[@class='alert alert-success']");
            public static By attendancebutton = By.Id("MainContent_UC1_btnAttendance");
        }    
    }

}
