using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

//namespace TestAutomation.Data
namespace Selenium2.Meridian
{
   public class ObjectRepository
    {

        //Admin
        public static By scromrequiredtrainingbutton = By.Id("TabMenu_ML_BASE_TAB_Search_ReqTrainingContent_GoButton_1");
        public static By scromsearch_type = By.Id("TabMenu_ML_BASE_TAB_Search_SearchType");
        public static By scromsearch_actingrole = By.Id("TabMenu_ML_BASE_TAB_Search_ManagerRole");
        public static string globalnum = string.Format("{0:ddhhssmmss}", DateTime.Now);
        public static By scromuniqueid = By.Id("MainContent_UC1_CNT_NUMBER");
        public static By scromtrainingpurposetype = By.Id("MainContent_UC1_FormView1_EREP_DET_TRG_PURPOSE_TYPE");
        public static By scromtrainingsourcetypecode = By.Id("MainContent_UC1_FormView1_EHRI_CRSW_TR_SRC_TYP_CO");
        public static By scromtitle = By.Id("CNTLCL_TITLE");
        public static By nxt_btn_new = By.Id("MainContent_UC1_Next");
        public static By adminconsoleopenlink = By.Id("NavigationStrip1_lnkAdminConsole");
        public static string adminwindowtitle = "Administration Console";
        public static By MoveToAdminHomePage = By.LinkText("Administration Console");
        public static By adminconfigconsole = By.XPath("//a[contains(text(),'Configuration Console (Home)')]");
        public static By adminconfigconsolesearch = By.XPath("//a[contains(text(),'Search Standards')]");
        public static By adminconsolesetautosearch = By.Id("TabMenu_ML_BASE_HEAD_SearchStandards_AutoSuggest_0");
        public static By adminconfigurereport = By.LinkText("Reports");
        public static By requiredtraining_link = By.XPath("//a[contains(text(),'Required Training Console')]");
        public static By adminscheduletaskauthorizeuserfalse = By.Id("TabMenu_ML_BASE_CustomReportingAndStorage_ScheduleTaskAuthorizedUserOnly_1");
        public static By adminsavescheduletaskauthorizeuser = By.Id("ML.BASE.BTN.Save");
        // public static By returntoadminconsole = By.Id("Return");
        public static By adminconsole_config_users = By.LinkText("Users");
        public static By adminconsoleapproverlink = By.LinkText("Approval Paths");
        public static By admindiscountlink = By.LinkText("Discount Codes");
        public static By adminMultipleCurrency = By.LinkText("Multiple Currencies");
        public static By adminhomepagefeeds = By.LinkText("Homepage Feeds");
        public static By admindomainmanagment = By.LinkText("Domain Management");

        //common
        public static By createbutton = By.Id("ML.BASE.BTN.Create");
        public static By checkin =By.XPath("//span[contains(.,'Check In')]");
        public static By returnbutton = By.Id("Return");
        public static string filterdropdowntext = "All words";
        public static string filterdropdownexact = "Exact phrase";


        //Announcement
        public static By announcementlink = By.LinkText("Announcements");
        public static By announcementgobutton = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public static By announcementtitle = By.Id("TabMenu_ML_BASE_TAB_EditAnnouncement_ANC_TITLE");
        public static By announcementbody = By.CssSelector("body");
        public static By announcementurl = By.Id("TabMenu_ML_BASE_TAB_EditAnnouncement_ANC_URL");
        // public static By announcementcreatebutton = By.Id("ML.BASE.BTN.Create");
        public static string announcementwindow = "Announcements";
        public static By moreannouncementlink = By.Id("MainContent_ucAnnouncements_lnkMore");
        public static By announcementfirstlink = By.Id("ctl00_MainContent_ucAnnouncements_rlvListing_ctrl0_lnkTitle");
        public static By announcementfirstlaunch = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        public static string moreannouncementlinkscontrol = "ctl00_MainContent_ucAnnouncements_rlvListing_ctrl###_lnkTitle";
        public static By moreannouncementlinks = By.Id(moreannouncementlinkscontrol);


        //genral

        public static string TranscriptPageTitle = "Transcript";
        public static By closebutton = By.Id("ML.BASE.CMD.CloseWindow");
        public static By searchtext = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        public static By searchtype = By.Id("TabMenu_ML_BASE_TAB_Search_SearchType");
        public static By searchbutton = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        public static By deletecontent = By.LinkText("Delete Content");
        public static By deletebutton = By.XPath("/html/body/table/tbody/tr[2]/td/input");


        public static By create_account_link = By.Id("lnkCreateAccount");
        public static By loginid_text = By.Id("MainContent_UC1_USR_LOGIN_ID");
        public static By passwd_text = By.Id("MainContent_UC1_USR_PASSWORD");
        public static By confirmpasswd_text = By.Id("MainContent_UC1_ConfirmPassword");
        public static By fname_text = By.Id("MainContent_MainContent_UC1_USR_FIRST_NAME");
        public static By mname_text = By.Id("MainContent_UC1_USR_MIDDLE_NAME");
        public static By lname_text = By.Id("MainContent_MainContent_UC1_USR_LAST_NAME");
        public static By email_text = By.Id("MainContent_UC1_USR_EMAIL_ADDRESS");

        public static By org_select_link = By.Id("MainContent_UC1_lnkSelectOrg");
        public static By org_search_text = By.Id("MainContent_UC1_txtSearch");
        public static By org_search_btn = By.Id("MainContent_UC1_btnSearch");
        public static By org_radio_btn = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect");
        public static By org_save_btn = By.Id("MainContent_UC1_FormView1_Save");
        public static By org_create_btn = By.Id("MainContent_UC1_Create");
        public static By login_name = By.CssSelector("span.rmText.rmExpandDown");

        public static By logout_link = By.Id("NavigationStrip1_lnkLogout");
        public static By label = By.Id("Label1");

        public static By main_login_button = By.Id("MainContent_UC5_btnLogin");
        public static By login_id = By.Id("MainContent_UC5_login_username");
        public static By login_id_new = By.Id("username");
        public static By login_password = By.Id("MainContent_UC5_login_password");
        public static By login_password_new = By.Id("password");
        public static By signin_button = By.Id("MainContent_UC5_btnLogin");
        public static By signin_button_new = By.XPath("//input[@value='Log In']");

        public static By completed30days = By.Id("MainContent_ucCompletedTraining_lb30Days");
        public static By completed60days = By.Id("MainContent_ucCompletedTraining_lb60Days");
        public static By completed90days = By.Id("MainContent_ucCompletedTraining_lbl90Days");
        public static By frmsucessmessage = By.XPath("//div[@class='alert alert-success']");
        public static string testurlsite = "Google";


        //document
        public static By doc_link = By.XPath("//a[contains(text(),'Documents')]");
        public static By go_btn = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public static By doc_title = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_DOC_TITLE");
        public static By doc_desc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_DOC_DESCRIPTION");
        public static By doc_keyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_DOC_KEYWORDS");
        public static By nxt_btn = By.Id("ML.BASE.BTN.Next");
        public static By url_RB = By.Id("TabMenu_ML_BASE_TAB_EditDocument_EXTERNALFILE_URL");
        public static By url_ED = By.Id("TabMenu_ML_BASE_TAB_EditDocument_DOCUMENT_URL");
        // public static By Create_BTN = By.Id("ML.BASE.BTN.Create");

        public static By catogery_CK = By.XPath("//*[@id='TabMenuMLBASETABEditLocationContentLocation_1']/input");
        public static By save_btn = By.Id("ML.BASE.BTN.Save");

        public static By ChkIn = By.XPath("//*[@id='ML.BASE.WF.Checkin']/span");
        public static By CourseName_Ed = By.XPath("//input[@placeholder='Search for Content']");
        public static By CourseName_Typ = By.XPath("//.[@name='ctl00$MainContent$ucQuickSearch$ddlSearchType']"); //By.Id("ddlSearchType");
        public static By CourseSearch_Btn = By.XPath("//span[contains(.,'Search')]"); //By.XPath(".//*[contains(@id,'btn')]")/span
        public static By open_itemBTN = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        public static By Return_Feedback = By.XPath("//*[@id='ReturnFeedback']");
        public static By Return_Feedback_id = By.Id("ReturnFeedback");
        // public static By Return = By.Id("Return");
        public static By DocumentResultTable = By.Id("ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails");
        public static By DocumentMarkCompleteBlock = By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock");
        public static By DocumentMarkCompleteButton = By.Id("MainContent_UC1_btnMarkComplete");
        public static By DocumentAnotherAttempt = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");


        //admin
        public static By AdminTab = By.XPath("//*[@id='NavigationStrip1_lnkAdminConsole']");
        public static string AdminConsole = "Administration Console";

        //general course
        //public static By gereralcourse_link = By.LinkText("General Course");
        //public static By generalcoursegobutton = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        //public static By genTitle_ED = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_COURSE_TITLE");
        //public static By generalcoursedescription = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_DESCRIPTION");
        //public static By generalcoursekeyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_KEYWORDS");
        //public static By myResponsibilities = By.Id("NavigationStrip1_lbMyResponsibilities");
        public static By gereralcourse_Link = By.XPath("/html/body/form/div[6]/div/div[2]/div/div/ul/li[2]/a/span");
        // public static By searchHome = By.Id("btnContentSearch");
        public static By goCreategeneralcoursebtn = By.Id("MainContent_ucSearchTop_btnCreateNew");
        public static By generalcourseTitle = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        public static By generalcourseDesc = By.XPath("//*[@id='MainContent_UC1_FormView1_CNTLCL_DESCRIPTION']");
        //public static By classroomDesc = By.Id( "MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        public static By generalcourseKeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");

        public static By selectcoursetype = By.Id("MainContent_ucSearchTop_ddlCreateNew");
        public static By CheckinNew = By.Id("MainContent_header_FormView1_btnStatus");
        public static By New_Next_Btn = By.Id("MainContent_UC1_Next");
        public static By generalcourseboostindex = By.Id("MainContent_UC1_FormView1_CNT_BOOST");

        public static By generalcoursecourse_cost = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_COST");
        public static By generalcourseduration = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_DURATION");
        public static By generalcoursecourse_num = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_NUMBER");
        public static By generalcoursecredit_value = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_CREDIT_VALUE");
        public static By generalcoursenext_btn = By.Id("MainContent_UC1_Save");
        public static By generalcourserd_btn = By.Id("TabMenu_ML_BASE_TAB_UploadFiles_EXTERNALFILE_URL");
        public static By generalcourseurlradio = By.Id("MainContent_UC1_EXTERNALFILE_URL");
        // public static By generalcourseurl_txtfld = By.Id("TabMenu_ML_BASE_TAB_UploadFiles_COURSE_URL");
        public static By generalcourseurl_txtfld = By.Id("MainContent_UC1_DOCUMENT_URL");
        //  public static By generalcoursecreate_btn = By.Id("ML.BASE.BTN.Create");
        public static By generalcourseReturnFeedback = By.XPath("//*[@id='ReturnFeedback']");
        // public static By generalcourseReturn = By.Id("Return");
        public static By generalcourseveiw_certificate = By.Id("MainContent_ucPrimaryActions_FormView1_CertificateBlock");
        public static By generalcourselaunchattept = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        public static By generalcourseMarkCompleteBlock = By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock");
        public static By generalcourseMarkCompleteButton = By.Id("MainContent_UC1_btnMarkComplete");
        public static By generalcourseenrollbutton = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton");
        public static By generalcourselaunchfirstattempt = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        public static By generalcoursecertificateblock = By.Id("MainContent_ucPrimaryActions_FormView1_CertificateBlock");
        public static By generalcourselaunchanotherattempt = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt");
        public static By generalcoursesearchdropdown = By.Id("ddlSearchType");
        public static By generalcoursesearchbutton = By.Id("btnSearch");
        public static By generalcourseunenroll = By.XPath(".//*[starts-with(@id,'UnEnrollUserButton')]");
        public static By generalcourseeditcostbutton = By.Id("MainContent_MainContent_ucCost_lnkEdit");
        public static By generalcourseeditcosttxt = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_txtDefaultCost");
        public static By generalcoursesavedefaultcost = By.Id("MainContent_MainContent_UC1_Save");
        public static By generalcourseassignapproval = By.Id("ML.BASE.WF.AssignAccessApproval");
        public static By generalcourseassignapprovalsearchfor = By.Id("TabMenu_ML_BASE_TAB_AssignAccessApproval_SearchFor");
        public static By generalcourseassignapprovalrequired = By.Id("TabMenu_ML_BASE_TAB_AssignAccessApproval_ACCESS_APPROVAL_REQUIRED_0");
        public static By generalcourseassignapprovalsearchtype = By.Id("TabMenu_ML_BASE_TAB_AssignAccessApproval_SearchType");
        public static By generalcourseassignapprovalsearchbutton = By.Id("TabMenu_ML_BASE_TAB_AssignAccessApproval_ML.BASE.BTN.Search");
        public static By generalcourseassignapprovalsavebutton = By.Id("ML.BASE.BTN.Save");
        public static By generalcourseassignapprovalpath = By.XPath("//table[@id='TabMenu_ML_BASE_TAB_AssignAccessApproval_ApprovalPathAssign']/tbody/tr[2]/td/span/input");
        public static By generalcoursedeletecontentlink = By.LinkText("Delete Content");
        public static By generalcoursedeletecontentbutton = By.XPath("//input");//By.XPath("/html/body/table/tbody/tr[2]/td/input");
        public static string generalcoursedeletewindow = "Delete Content";
        //public static string CourseTitle = string.Empty;







        //scorm
        public static By scrom12_fileupload = By.Id("TabMenu_ML_BASE_TAB_UploadContent_UploadFile");
        public static By scrom12_link = By.XPath("//a[contains(text(),'SCORM 1.2')]");
        public static By CheckTitle = By.Id("CNT_TITLE");
        public static By requiredTrainingLink = By.XPath("//a[contains(text(),'Required Training')]");
        public static By requiredTraining = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining");
        public static By goTrainingBtn = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu");
        public static By assignTrainingSearchRole = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole");
        public static By assignTrainingSearchType = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchType");
        public static By assignTrainingSearchBtn = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search");
        public static By tableResultAssignTraining = By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0')]");
        public static By assignTrainingLink = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining");
        public static By scromsearch_ed = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        public static By scromsearch_typ = By.Id("TabMenu_ML_BASE_TAB_Search_SearchType");
        public static By scromsearch_btn = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        public static By scromenrollbtn = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton");
        public static By scromenrolcourse = By.Id("MainContent_UC1_btnCourseEnroll");
        public static By scromlaunchfirstattempt = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        public static By scromlunchcourseexisting = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchCourseAttemptExisting");
        public static By scrommarkcompleteblock = By.Id("MainContent_ucPrimaryActions_FormView1_MarkCompleteBlock");
        public static By scrommarkcompletebutton = By.Id("MainContent_UC1_btnMarkComplete");
        public static By scromcertificateblock = By.Id("MainContent_ucPrimaryActions_FormView1_CertificateBlock");
        public static By scromenrollbutton = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton");
        public static By scromenroll_btn = By.Id("MainContent_UC1_btnCourseEnroll");
        public static By scromanotherattempt = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAnotherNewAttempt");


        //classroom course
        public static By myResponsibilities = By.XPath("//a[contains(.,'Manage')]");
        public static By managestudentsinstructortoolslink = By.XPath("/html/body/form/div[6]/div/div[2]/div/div/ul/li[4]/a/span");
        public static By managestudentsmyteachingscheduletab = By.Id("MainContent_UC1_lbMyTeachingSchedule");
        public static By managestudentsmanagestudentstab = By.Id("MainContent_UC1_lbManageStudentsActive");
        public static By classroomCoursesLink = By.XPath("//a[@href='../ContentSearch.aspx']");
        public static By searchHome = By.XPath("//h2[contains(.,'Manage Content')]");
        public static By goCreateClassroombtn = By.Id("MainContent_ucSearchTop_btnCreateNew");
        public static By classroomTitle = By.Id("CNTLCL_TITLE");
        public static By classroomDesc___ = By.Id("ctl00_MainContent_UC1_FormView1_rdEditorDesc");

        //public static By classroomDesc = By.XPath("//*[@id='ctl00_MainContent_UC1_FormView1_rdEditorDesc_contentIframe']");
        public static By classroomDesc = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        public static By courseinformationsearchprioritytextbox = By.Id("MainContent_UC1_FormView1_CNT_BOOST");
        public static By classroomKeyword = By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
        public static By classroomTitle_ = By.Id("MainContent_UC1_FormView1_CRSW_COURSE_TITLE");
        public static By classroomDesc_ = By.Id("MainContent_UC1_FormView1_CRSW_DESCRIPTION");
        public static By classroomKeyword_ = By.Id("MainContent_UC1_FormView1_CRSW_KEYWORDS");
        public static By classroomSuccessMsg = By.XPath("//form[@id='Form1']/div[6]/div/div[4]/div");
        public static By manageenrolmentforonlinecoursesearchbutton = By.Id("btnSearchCourses");
        public static By manageenrolmentforonlinecoursesearchtextbox = By.Id("MainContent_ucSearchTop_FormView1_SearchFor");
        public static By manageenrolmentforonlinecoursefilterdropdown = By.Id("MainContent_ucSearchTop_FormView1_SearchType");
        public static By manageenrolmentforonlinecourseresulttablelink = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
        public static By manageenrolmentforonlinecoursebuttonenrollcourse = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnEnrollUser");
        public static By manageenrolmentforonlinecoursemanageenrollment = By.Id("ctl00_MainContent_ucSearchTop_rgCourses_ctl00_ctl04_btnManageEnrollment");
        public static By ClassroomLinkEdit = By.Id("lnkEdit");
        public static By ManageSectionsLink = By.Id("MainContent_hlNewSection");
       // public static By AddNewsectionBtn = By.XPath("//*[@id='MainContent_pnlMVCSection']/div[1]/a");
        public static By AddNewsectionBtn = By.LinkText("Add a New Section");
        public static By SectionTitle = By.Id("section-title");
        public static By NxtBtn = By.Id("MainContent_MainContent_UC1_btnNext");
        public static By StartDate = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_START_DATE_dateInput");
        public static By EndDate = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_FormView1_CRSSECT_SECTION_END_DATE_dateInput");
        public static By AllDayEvnt = By.Id("MainContent_MainContent_UC1_FormView1_EVT_ALLDAYEVENT");
        public static By MinimumCapacity = By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY");
        public static By MaximumCapacity = By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY");
        public static By SaveAndExit = By.Id("btnCreate");
        public static By ChangeEnrolDate = By.Id("MainContent_MainContent_UC1_FormView1_lnkEnrollInfo");
        public static By EnroStartDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_dateInput");
        public static By EnrolEndDate = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_dateInput");
        public static By EnroStartDate_ = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_DATE_popupButton");
        public static By EnrolEndDate_ = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_DATE_popupButton");
        public static By EnrolStartTime = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_START_TIME_dateInput");
        public static By EnrolEndTime = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_ENROLL_END_TIME_dateInput");
        public static By ClassroomCalendarView = By.Id("MainContent_MainContent_ucTopBar_FormView1_hlSectionCalendar");
        public static By CalenderDetail = By.Id("div.rsAptContent");
        public static By SectionLink = By.XPath("//tr[@id='ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0']/td/a");
        public static By ManageLink = By.Id("MainContent_MainContent_UC4_hlManage");
        public static By CourseSectionLink = By.Id("MainContent_lcClassroomCourseware");
        public static By CourseSectionLink1 = By.Id("MainContent_MHyperLink2");
        public static By ClassroomcourseFrame = By.XPath("/html/body/div[2]/div[2]/iframe");
        public static By ClassroomcourseSave = By.Id("MainContent_UC1_Save");
        public static By MyRespnsibilitySearch = By.XPath("//a[contains(.,'Search & Create Content')]");
        public static By MyRespnsibilitySearchFilter = By.Id("MainContent_ucSearchTop_SearchType");
        public static By MyRespnsibilitySearchButton = By.Id("btnSearchCourses");
        public static By ContentSearchResultTitle = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
        public static By sectionsucessmessage = By.XPath("//div[@class='alert alert-success']");
        public static By detailssectioninfo = By.XPath("//tr[@id='ctl00_MainContent_ucClassroom_rgSections_ctl00__0']/td[2]/img");
        public static By myresponsibilitiesmycontenttitlelink = By.Id("ctl00_MainContent_ucLastModifiedContent_RadGrid1_ctl00_ctl04_lnkDetails");
        public static By myresponsibilitiesaddnew = By.Id("MainContent_ucLastModifiedContent_hlAddNew");
        public static By myresponsibilitiesinstructortoolsportletdrpdwn = By.Id("MainContent_ucInstructorToolsSummary_Instructor");
        public static By myresponsibilitiesinstructortoolsportletbutton = By.Id("MainContent_ucInstructorToolsSummary_btnSearch");
        public static By myresponsibilitiesinstructortoolsportlettableresult = By.Id("ctl00_MainContent_ucInstructorToolsSummary_RadGrid1_ctl00_ctl04_lnkDetails");
        public static By myresponsibilitiesinstructortoolsportlettableresultcount = By.XPath("//*[@id='ctl00_MainContent_ucInstructorToolsSummary_RadGrid1_ctl00']/tbody/tr");
        public static By detailseventschedulesectiontitle = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl06_rgEvents_ctl00_ctl04_MLabel2");
        public static By detailsenrolbutton = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_btnEnroll");
        public static By managestudentslink = By.Id("MainContent_UC4_hlManage");
        public static By myresponsibilitiesinstructortoolportletallmysectionbutton = By.Id("MainContent_ucInstructorToolsSummary_lnkAllMySections");
        public static By managestudentsallinstructorstab = By.Id("MainContent_ucTabs_lbManageStudentsActive");
        public static By contentsearchresultcount = By.XPath("/html/body/form/div[6]/div/div[6]/div/div[3]");
        public static By myresponsibilitiestodaylink = By.XPath("//a[@id='MainContent_ucSearchTop_CreatedBy']");
        public static By managestudentsrosterenrolledtab = By.Id("MainContent_UC1_lnkEnrolledActive");
        public static By managestudentsrosterwaitlistedtab = By.Id("MainContent_UC1_lnkWaitlisted");
        public static By managestudentsrosteremailallbutton = By.Id("MainContent_UC2_MButton1");
        public static By managestudentsrosteremailthroughinstructorbutton = By.Id("ctl00_MainContent_UC2_rgEnrolled_ctl00_ctl04_imgSendEmail");
        public static By sendemailsubjecttextbox = By.Id("MainContent_UC1_Subject");
        public static By sendemailmessagetextbox = By.Id("MainContent_UC1_Message");
        public static By sendemailsendbutton = By.Id("MainContent_UC1_Send");
        public static By emailsentsucessmessage = By.XPath("//div[@class='alert alert-success']");
        public static By sectionenrolsucessmessage = By.XPath("//div[@class='alert alert-success']");
        public static By instructortools = By.XPath("//a[contains(.,'Instructor Tools')]");
        public static By manage = By.Id("MainContent_ucTabs_lbManageStudents");
        public static By allinstructors = By.Id("MainContent_ucInstructorToolsResults_ucLinks_hlAll");
        public static By managestudentsallinstructorssearchtextbox = By.Id("MainContent_ucInstructorToolsResults_ucITSearch_txtSearchFor");
        public static By managestudentinstructortoolssearchfilterdrpdown = By.Id("MainContent_ucInstructorToolsResults_ucITSearch_SectionStatus");
        public static By managestudentsinstructortoolsearchbutton = By.Id("MainContent_ucInstructorToolsResults_ucITSearch_btnSearch");
        public static By resulttabletext = By.Id("ctl00_MainContent_ucInstructorToolsResults_ucResults_rgInstructorTools_ctl00_ctl04_rgSections_ctl00_ctl04_lnkSection");
        public static By recordattendanceandscores = By.Id("MainContent_UC2_MEditScores");
        public static By resulttabletext1 = By.Id("ctl00_MainContent_UC1_rgEnrolled_ctl00_ctl04_lblFirstName");
        public static By attendancechkbox = By.Id("MainContent_UC1_chkAttendanceAll");
        public static By statusdrpdown = By.Id("MainContent_UC1_ddlProgressAll");
        public static By attendancebutton = By.Id("MainContent_UC1_btnAttendance");
        public static By statusfilterbutton = By.Id("MainContent_UC1_btnProgress");
        public static By scorebutton = By.Id("MainContent_UC1_btnScore");
        public static By savebutton = By.Id("btnCreate");
        public static By scoretextbox = By.Id("MainContent_UC1_txtScoreAll");
        public static By progressstatus = By.Id("ctl00_MainContent_UC1_rgEnrolled_ctl00_ctl04_ddlProgress");
        public static By scoretext = By.Id("ctl00_MainContent_UC1_rgEnrolled_ctl00_ctl04_PRG_FINAL_SCORE");
        public static By myresponsibilitiesmostrecentrequestusernamelink = By.Id("ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_lnkContentTitle");
        public static By myresponsibilitiesmostrecentrequestcontenttitlelink = By.Id("ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_lnkSectionTitle");
        //  public static By myresponsibilitiesmostrecentrequestcontenttitlelink = By.XPath("//a[contains(@id,'ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_lnkContentTitle')]"); 
        //     ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_lnkCntTitle
        public static By informationcitylabel = By.XPath("//li[contains(.,'City:')]");
        public static By sectioninformationclosewindowlink = By.Id("ML.BASE.CMD.CloseWindow");
        public static By myresponsibilitiesmyteachinesceduletodaylabel = By.Id("ctl00_MainContent_ucMyTeachingScheduleSummary_rgMyTeachingSchedule_ctl00_ctl04_MLiteral34");
        public static By myresponsibilitiesmyteachinescedulenxt30daylabel = By.Id("ctl00_MainContent_ucMyTeachingScheduleSummary_rgMyTeachingSchedule_ctl00_ctl04_MLiteral30");
        public static By myresponsibilitiesmyteachingschedulenoresultintablelabel = By.Id("ctl00_MainContent_ucMyTeachingScheduleSummary_rgMyTeachingSchedule_ctl00_ctl04_lblNoRecords");
        public static By myresponsibilitiesmyteachingschedulenxt7daystab = By.Id("ctl00_MainContent_ucMyTeachingScheduleSummary_rgMyTeachingSchedule_ctl00_ctl04_lblNoRecords");
        public static By myresponsibilitiesmyteachingscheduletodaytab = By.Id("MainContent_ucMyTeachingScheduleSummary_lbToday");
        public static By myresponsibilitiesmyteachingschedule30daytab = By.Id("MainContent_ucMyTeachingScheduleSummary_lb30Days");
        public static By myresponsibilitiesmyteachingschedule7daytab = By.Id("MainContent_ucMyTeachingScheduleSummary_lb7Days");
        public static By myresponsibilitiesmyteachingscheduleupcomingtab = By.Id("MainContent_ucMyTeachingScheduleSummary_lbAllUpcoming");
        public static By myresponsibilitiesmyteachingschedulerecentlyendedtab = By.Id("MainContent_ucMyTeachingScheduleSummary_lbRecentlyEnded");
        public static By myresponsibilitiesmyteachingschedulemyteachingcalendarlink = By.Id("MainContent_ucMyTeachingScheduleSummary_lbViewCalendar");
        public static By myresponsibilitiesviewlallmyteachingschedulebutton = By.Id("MainContent_ucMyTeachingScheduleSummary_lbAllMyTeaching");
        public static By myteachingscheduleeventlabel = By.Id("ctl00_MainContent_ucTeachingSchedule_rgMyTeachingSchedule_ctl00_ctl04_MLiteral34");
        //change password
        public static By currentpassword = By.Id("MainContent_UC1_CurrentPassword");
        public static By editpassword = By.Id("MainContent_UC1_USR_PASSWORD");
        public static By repeatpassword = By.Id("MainContent_UC1_ConfirmPassword");
        public static By saveeditpassword = By.Id("MainContent_UC1_Save");
        public static By sucessmessage = By.XPath("//div[@class='alert alert-success']");
        public static By pagehavingtitle = By.TagName("Title");

        //Hover
        //public static By HoverMainLink = By.XPath("//span[@class='caret']");
        public static By HoverMainLink = By.XPath("//span[contains(@data-bind,'NAME.substring(0, 1)')]");
        public static By LogoutHoverLink = By.XPath("//a[contains(text(),'Logout')]");
        public static By MyAccountHoverLink = By.XPath("//a[normalize-space()='Account']");
        public static By MyReportsHoverLink = By.XPath("//a[normalize-space()='Reports']");
        public static By MyCalenderHoverLink = By.XPath("//a[normalize-space()='Calendar']");
        public static By OrdersHoverLink = By.XPath("//a[normalize-space()='Orders']");


        //traininghome
        public static By TrainingHome = By.XPath("//a[text()='Home']");
        
        public static By trainingcatalog = By.XPath("//a[contains(text(),'Catalog')]");
        public static By TrainingRequiredLegend = By.Id("MainContent_ucUpcomingTraining_legReqTraining");
        public static By TrainingOverDueLegend = By.Id("MainContent_ucUpcomingTraining_legOverdue");
        public static By TrainingDueSoonLegend = By.Id("MainContent_ucUpcomingTraining_legDueSoon");
        public static By TrainingRecurringLegend = By.Id("MainContent_ucUpcomingTraining_legRecurring");
        public static By AllMyUpComingTrainingButton = By.Id("MainContent_ucUpcomingTraining_MLinkButton1");
        public static By AllMyUpComingTrainingFilter = By.Id("MainContent_ucUpcomingTraining_ddlFilter");
        public static By AllMyUpComingTrainingActionBtn = By.Id("ctl00_MainContent_UC3_RadGrid1_ctl00_ctl06_btnAction");
        public static By AllMyUpcomingTraingItemDetails = By.XPath("//a[contains(text(),'Item Details')]");
        public static By AllMyCompletedTrainingActionBtn1 = By.Id("ctl00_MainContent_ucCompletedTraining_RadGrid1_ctl00_ctl04_btnAction");
        public static By AllMyCompletedTrainingActionBtn2 = By.Id("ctl00_MainContent_ucCompletedTraining_RadGrid1_ctl00_ctl06_btnAction");
        public static By AllMyCompletedTrainingButton = By.Id("MainContent_ucCompletedTraining_MLinkButton2");
        public static By AllMyUpcomingTraingItemRating = By.Id("lblRating");
        public static By FirstItemCertificate = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_btnAction");
        public static string CertificateWindow = "CertificateWindow";
        public static By CertifateUserFirstName = By.Id("UserName");
        public static By TanscriptPrintBtn = By.Id("MainContent_UC1_MLinkButton1");


        //transcript
        public static By transcriptdocumentname = By.XPath("//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__1']/td[1]");
        public static By transcriptdocumentstatus = By.XPath("//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__1']/td[3]");
        public static By transcriptgeneralcoursename = By.XPath("//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__2']/td[1]");
        public static By transcriptgeneralcoursestatus = By.XPath("//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__2']/td[3]");
        public static By transcriptscormtname = By.XPath("//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__3']/td[1]");
        public static By transcriptscormstatus = By.XPath("//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__3']/td[3]");
        public static By transcriptclassroomcoursename = By.XPath("//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__0']/td[1]");
        public static By transcriptclassroomcoursestatus = By.XPath("//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__0']/td[3]");
        public static By transcriptclassroomcoursescore = By.XPath("//*[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__0']/td[4]");



        public static By classroomsectionMinimumCapacity = By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_MIN_CAPACITY");
        public static By classroomsectionMaximumCapacity = By.Id("MainContent_MainContent_UC1_FormView1_CRSSECT_MAX_CAPACITY");
        public static By schedulemanagesectionclassroomcalendarlink = By.Id("MainContent_MainContent_ucTopBar_FormView1_hlSectionCalendar");
        public static By classroomcalendarviewlink = By.XPath("//a[contains(@id,'lnkbtnEditEvent')]");
        public static By sectiondetailexpenseseditlink = By.Id("MainContent_MainContent_ucSectionExpenses_accSectionExpenses_lbEdit");
        public static By expensesprofessionalservices = By.Id("CRSSECT_PROF_SERVICE");
        public static By expensesfacilityservices = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_FACILITY_FEES");
        public static By expensestravelexpenses = By.Id("MainContent_UC1_FormView1_CRSSECT_TRAVEL_EXPENSES");
        public static By expensesequipmentrental = By.Id("MainContent_UC1_FormView1_CRSSECT_EQUIPMENT_RENTAL");
        public static By expensessavebutton = By.Id("MainContent_UC1_Save");
        public static By sectiondetailexpensestotal = By.Id("MainContent_MainContent_ucSectionExpenses_accSectionExpenses_lblTotalValue");
        public static By contentdeletecontentbutton = By.Id("MainContent_header_FormView1_btnDelete");
        public static By myresponsibilitiesviewallcoursesbutton = By.Id("MainContent_ucLastModifiedContent_lbAllContent");
        public static By createnewcoursesectionandeventradiobutton = By.Id("MainContent_UC1_FormView1_CRSSECT_WAITLIST_OPTION_0");
        public static By scheduleandmanagesectionsmanageenrollmentbutton = By.Id("MainContent_header_FormView1_lnkManageEnroll");
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
        public static By batchenrollmenttablelastnamelabel = By.Id("ctl00_MainContent_UC1_rgUsers_ctl00_ctl04_lblFirstName");
        public static By batchenrollmentbatchenrollusersbutton = By.Id("MainContent_UC1_btnEnrollUsers");
        public static By manageenrollmentmanagewaitlistbutton = By.Id("ctl00_MainContent_UC1_rgSections_ctl00_ctl04_btnManageWaitlist");
        public static By batchenrollmentfeedback = By.XPath("//div[@class='alert alert-success']");
        //Content Search
        public static By contentsearchSearchAdvlnk = By.XPath("//a[contains(.,'See more search criteria')]");
        public static By contentsearchSearchfortxtbx = By.Id("MainContent_ucSearchTop_SearchFor");
        public static By contentsearchSearchfilterdrpdwn = By.Id("MainContent_ucSearchTop_SearchType");
        public static By contentsearchSearchTitletxtbx = By.Id("MainContent_ucSearchTop_CNT_TITLE");
        public static By contentsearchSearchDescriptiontxtbx = By.Id("MainContent_ucSearchTop_CNT_DESCRIPTION");
        public static By contentsearchSearchKeywordstxtbx = By.Id("MainContent_ucSearchTop_CNT_KEYWORDS");
        public static By contentsearchSearchCategorytxtbx = By.Id("MainContent_ucSearchTop_CNTCTGY_CATEGORY_ID");
        public static By contentsearchSearchRatingfilterdrpdwn = By.Id("MainContent_ucSearchTop_strRatingType");
        public static By contentsearchSearchRatingdrpdwn = By.Id("MainContent_ucSearchTop_intRating");
        public static By contentsearchSearchEditingStatusdrpdwn = By.Id("MainContent_ucSearchTop_SearchStatusType");
        public static By contentsearchSearchActivitydrpdwn = By.Id("MainContent_ucSearchTop_SearchActivity");
        public static By contentsearchSearchbutton = By.Id("btnSearchCourses");
        public static By contentsearchResultTable = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
        public static By contentsearchItemscountlbl = By.XPath("//strong[@data-bind='formatText: [total]']");

        //section search
        public static By schedulemanagesectionSearcfortxtbox = By.Id("filterNameCode");
        public static By schedulemanagesectionSectionstatusdrpdwn = By.Id("MainContent_MainContent_ucTopBar_ddlSectionStatus");
        public static By schedulemanagesectionActivitydrpdwn = By.Id("MainContent_MainContent_ucTopBar_ddlSearchActivity");
        public static By schedulemanagesectionStartdatetxtbox = By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rdStartDate_dateInput");
        public static By schedulemanagesectionEnddatetxtbox = By.Id("ctl00_ctl00_MainContent_MainContent_ucTopBar_rdEndDate_dateInput");
        public static By schedulemanagesectionFilterbutton = By.XPath(".//*[@id='MainContent_pnlMVCSection']/div[1]/div[2]/div/div[1]/div/span/button");
        public static By schedulemanagesectionResulttable = By.XPath("//tr[@id = 'ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0']/td/a");

        //managesections
        public static By contentclassroomtitlelabel = By.Id("MainContent_MainContent_ucSummary_FormView1_MLabel2");
        //   public static By schedulemanagesectionsectiontitlelink = By.XPath("//a[contains(.,'" +ExtractDataExcel.MasterDic_classrommcourse["Title"]+browserstr+"')]");
        public static By schedulemanagesectionsectiontitlelink = By.CssSelector("#ctl00_ctl00_MainContent_MainContent_ucTopBar_rgSections_ctl00__0 > td > a");
        public static By sectiondetailsEdit = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkEdit");
        //assignsurvey
        public static By contentmanagelink = By.Id("MainContent_MainContent_UC4_hlManage");
        public static By managestudentsmanagesurveylink = By.Id("MainContent_UC4_hlManage");
        public static By sectiondetailsmanagelink = By.Id("MainContent_MainContent_ucEvaluations_hlManage");
        public static By surveysassignsurveyslink = By.Id("MainContent_MainContent_UC1_btnAssignSurveys");
        public static By surveyframesearchtxtbox = By.Id("MainContent_UC1_txtSearchFor");
        public static By surveyframesearchtxtfilter = By.Id("MainContent_UC1_ddlSearchType");
        public static By surveyframesearchbutton = By.Id("MainContent_UC1_btnSearch");
        public static By surveyframeselectchkbox = By.Id("ctl00_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect");
        public static By surveyframesavebutton = By.Id("MainContent_UC1_Save");
        public static By surveyremovebutton = By.Id("MainContent_MainContent_UC1_btnRemove");
        //copy classroom course section
        public static By sectiondetailscopybutton = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkCopy");
        public static By copyframedatetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_NEWSTART_DATE_dateInput");
        public static By copyframetimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_CRSSECT_NEWSTART_TIME_dateInput");
        public static By copyframecopybutton = By.Id("MainContent_UC1_Save");
        public static By sectiondetailssuccessmessage = By.XPath("//div[@class='alert alert-success']");

        //delete classroom course section
        public static By sectiondetaildeletesectionbutton = By.Id("MainContent_MainContent_ucSummary_FormView1_lnkDelete");
        public static By sectiondetailsdeletemessage = By.XPath("//div[@class='alert alert-success']");

        //Order Details

        public static By manageaccesskeys = By.Id("MainContent_UC1_manageAccessButton");

        //access approval
        public static By myresponsibilitiesmostrecentrequestsapprovebutton = By.Id("ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_btnMyApprove");
        public static By myresponsibilitiesmostrecentrequestsdenybutton = By.Id("ctl00_MainContent_ucMostRescentApprovalRequests_rgMostRecentRequests_ctl00_ctl04_btnMyDeny");
        public static By myresponsibilitiesmostrecentrequestsviewallrequestsbutton = By.Id("MainContent_ucMostRescentApprovalRequests_btnAllPendingRequests");
        public static By contentaccessapprovaleditbutton = By.Id("MainContent_MainContent_ucAccessApproval_lnkEdit");
        public static By manageaccessapprovalradiobutton = By.Id("MainContent_MainContent_UC1_FormView1_rbApprovalRequired_0");
        public static By manageaccessapprovalsearchtxtbox = By.Id("MainContent_MainContent_UC1_txtSearch");
        public static By manageaccessapprovalfiltercombobox = By.Id("MainContent_MainContent_UC1_SearchType");
        public static By manageaccessapprovalsearchbutton = By.Id("MainContent_MainContent_UC1_btnSearch");
        public static By manageaccessapprovaltsavebutton = By.Id("MainContent_MainContent_UC1_Save");
        public static By manageaccessapprovaltableresultradiobutton = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect");
        public static By contentsearchapprovalrequestlink = By.XPath("//span[contains(.,'Approval Requests')]");
        public static By accessapprovalawaitingmyapprovaltab = By.Id("MainContent_UC1_lbMine");
        public static By accessapprovalawaitingapprovalfromothertab = By.Id("MainContent_UC1_lbOther");
        public static By accessapprovalfinalizedrequeststab = By.Id("MainContent_UC1_lbFinal");
        public static By accessapprovalmanagerequesttab = By.Id("MainContent_UC1_lbManage");
        public static By accessapprovalapprovedenycheckbox = By.Id("ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00_ctl04_chkMyAction");
        public static By accessapprovalfindarequesttxtbox = By.Id("MainContent_ucSearchWithin_txtSearch");
        public static By accessapprovalfindarequestsearchbutton = By.Id("btnFilterSearch");
        public static By accessapprovalclassroomsectionfacetchkbox = By.XPath("//div[@id='FacetCTYPLCL_DISPLAY_NAME']/input");
        public static By accessapprovaldatefacetchkbox = By.CssSelector("#FacetDATE_FACET > input[type='checkbox']");
        public static By contentaccessapprovalsuccessmessage = By.XPath("//div[@class='alert alert-success']");
        public static By myOwnlearning = By.Id("lbUserView");
        public static By detailsRequestaccessbutton = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_btnRequestAccess");
        public static By accessapprovalrequestaccessbutton = By.Id("MainContent_UC1_RequestAccess");
        public static By detailsaccessapprovalsuccessmessage = By.XPath("//div[@class='alert alert-success']");
        public static By accessapprovaltableresultstitlelink = By.Id("ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00_ctl04_lnkSectionTitle");
        public static By accessapprovaldenybutton = By.Id("ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00_ctl04_btnMyDeny");
        public static By accessapprovaldenyframebutton = By.Id("MainContent_UC1_SubmitRequest");
        public static By accessapprovalapprovebutton = By.Id("ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00_ctl04_btnMyApprove");
        public static By accessapprovalapproveframebutton = By.Id("MainContent_UC1_SubmitRequest");
        public static By accessapprovalrescindframebutton = By.Id("MainContent_UC1_SubmitRequest");
        public static By accessapprovalmanagerequestsresultcount = By.XPath("/html/body/form/div[6]/div/div[5]/div/div[4]/table/tbody/tr/td");
        public static By accessapprovalclassroomsectionfacetchecckbox = By.XPath("/html/body/form/div[6]/div/div[4]/div[2]/div[3]/input[4]");
        public static By accessapprovaldatefacetchecckbox = By.CssSelector("#FacetDATE_FACET > input[type='checkbox']");
        public static By accessapprovalrescindbutton = By.Id("ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00_ctl04_btOFRescind");
        public static By accessapprovalviewrequestimage = By.XPath("//tr[@id='ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00__0']/td[6]/img");
        public static By accessapprovalviewrequestlink = By.Id("ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00_ctl06_lnkHistory");
        public static By historydeniedlabel = By.XPath("//td[contains(.,'Pending')]");

        //edit cost

        public static By sectiondetailscostbutton = By.Id("MainContent_MainContent_ucCost_accCost_MHyperLink1");
        public static By costsdefaultcosttextbox = By.Id("MainContent_MainContent_UC1_FormView1_txtDefaultCost");
        public static By costsavebutton = By.Id("MainContent_MainContent_UC1_Save");

        //edit event
        public static By sectiondetailediteventlink = By.Id("MainContent_MainContent_ucSectionEvents_accSectionEvents_lbEdit");
        public static By eventseditbutton = By.Id("ctl00_MainContent_UC1_rgEvents_ctl00_ctl04_btnGo");
        public static By editeventstrttimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_EVT_START_TIME_dateInput");
        public static By editeventendtimetxtbox = By.Id("ctl00_MainContent_UC1_FormView1_EVT_END_TIME_dateInput");
        public static By editeventsaveandexitbutton = By.Id("MainContent_UC1_btnSave");
        public static By eventssuccessmessage = By.XPath("//div[@class='alert alert-success']");

        //location
        public static By editeventselectlocationbutton = By.Id("MainContent_UC1_FormView1_lnkSelectLoc");
        public static By selectlocationframesearchbutton = By.Id("MainContent_UC1_btnSearch");
        public static By selectlocationframesroomtyperadiobutton = By.Id("ctl00_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect");
        public static By selectlocationframessaveandexitbutton = By.Id("MainContent_UC1_Save");
        public static By selectlocationssuccessmessage = By.XPath("//div[@class='alert alert-success']");

        //instructor
        public static By editeventselectinstructorbutton = By.Id("MainContent_UC1_FormView1_lnkSelectInst");
        public static By selectinstructorframesearchbutton = By.Id("MainContent_UC1_btnSearch");
        public static By selectinstructorframecheckbox = By.Id("ctl00_MainContent_UC1_SectionInstructorSearch_ctl00_ctl04_chkSelect");
        public static By selectinstructorframessaveandexitbutton = By.Id("MainContent_UC1_Save");
        public static By selectinstructorssuccessmessage = By.XPath("//div[@class='alert alert-success']");

        //delete event
        public static By eventselecteventcheckbox = By.Id("ctl00_MainContent_UC1_rgEvents_ctl00_ctl04_chkSelect");
        public static By eventremoveeventbutton = By.Id("MainContent_UC1_FormViewButton_btnGo");
        public static By deleteeventsuccessmessage = By.XPath("//div[@class='alert alert-success']");




        //certifications
        public static string Certificationlink = "//a[contains(text(),'Certifications')]";
        public static string CertificationConsolelink = "//a[contains(text(),'Certification Console')]";
        public static By Certificationgobutton = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public static By CertificationTitle = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_TITLE");
        public static By CertificationDesc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_DESCRIPTION");
        public static By CertificationKeyWord = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_KEYWORDS");
        public static By CertificationType = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_CERTTYPE_ID");
        public static By CertificationCost = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_COST_TYPE_ID_1");
        public static By CertificationPeriod = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_PRD_FLAG_1");
        public static By CertificationPast = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_INCL_PAST_COMPLETION_1");
        public static By CertificationObjective = By.Id("TabMenu_ML_BASE_HEAD_EditObjectives_COBJ_OBJECTIVE");
        public static By Certificationsearcheditem = By.Id("ctl00_MainContent_ucSearch_rlvSearchResults_ctrl0_lnkDetails");
        public static By CertificationOpenAccess = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag");
        public static By CertificationSerachFor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        public static By CertificationSearchType = By.Id("ddlSearchType");
        public static By CertificationViewUserGoToButton = By.Id("TabMenu_ML_BASE_TAB_Search_CONTENT_SEARCH_GoButton_1");
        public static By CertificationViewUserSearchText = By.Id("TabMenu_ML_BASE_ACT_ViewUsers_SearchFor");
        public static By CertificationViewSearchUserButton = By.Id("TabMenu_ML_BASE_ACT_ViewUsers_ML.BASE.BTN.Search");
        public static By CertificationViewHistoryButton = By.Id("TabMenu_ML_BASE_ACT_ViewUsers_LMS_USER_GoButton_1");
        public static By CertificationCertifyRd = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_CH_STATUS_ID_0");
        public static By CertificationSuspendRd = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_CH_STATUS_ID_1");
        public static By CertificationRevokeRd = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_CH_STATUS_ID_2");
        public static By CertificationTakeAction = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_ML.BASE.BTN.TakeAction");
        public static By CertificationProbIcon = By.Id("MainContent_ucCertSummary_imgCertProb");
        public static By CertificationOkIcon = By.Id("MainContent_ucCertSummary_imgCertOk");
        public static By CertificationExpiredCount = By.Id("MainContent_ucCertSummary_pnlExpired");
        public static By CertificationInProgressCount = By.Id("MainContent_ucCertSummary_pnlStarted");
        public static By CertificationCompletedCount = By.Id("MainContent_ucCertSummary_pnlCompleted");
        public static By CertificationRevokeCount = By.Id("MainContent_ucCertSummary_pnlRevoked");
        public static By CertificationHistoryChangeDate = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_PRG_COMPLETE_DATE||DATEPICKER_dateInput");
        public static By CertificationHistoryChangeReason = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_CH_REASON");
        public static By CertificationSummaryLink = By.Id("MainContent_ucCertSummary_lnkCert");

        public static By TranscriptCertificationLink = By.Id("MainContent_ucQLinks_lnkCert");
        public static By CertificationLinkonTranscript = By.Id("ctl00_MainContent_UC2_RadGrid1_ctl00_ctl04_lnkDetails");
        public static By CertTranscriptsearchforbtn = By.Id("MainContent_UC1_txtSearchFor");

        public static By CertTranscriptprintbtn = By.XPath("//a[contains(text(),'Print')]"); //By.Id("MainContent_UC1_MLinkButton1");// not using id bcoz differs on ff and ie
        public static By CertTranscriptprintpagelink = By.Id("ctl00_MainContent_UC2_RadGrid1_ctl00_ctl04_lnkDetails");

        public static string CertTranscriptprintpagetitle = "Certifications";
        public static By CertTranscriptsaveaspdfbtn = By.XPath("//a[contains(text(),'Save as PDF')]");//By.Id("MainContent_UC1_SaveAsPDF");// not using id bcoz differs on ff and ie
        public static string CertTranscriptpdfpagetitle = "MyCertificationsPrint.aspx";

        //training home
        public static By traininghomesearchtext = By.Id("MainContent_ucQuickSearch_txtSearch");
        public static By traininghomeSearchType = By.Id("ddlSearchType");
        public static By traininghomeSearchButton = By.Id("btnSearch");
        public static By searchautocomplete = By.Id("Autocomplete_8ffe");

        //global vars
        public static bool isrunning = false;
        //public static IWebDriver _driverforall = null;
        public static string newuserloginid = string.Empty;
        public static int maildomain = 0;

        //profile
        public static By userqualificationedulevel = By.Id("MainContent_UC1_FormView1_USR_EDUCATION_LEVEL_ID");
        public static By myprofilelink = By.Id("NavigationStrip1_HyperLink1");
        // public static By myprofilewindowidentifier = By.Id("KendoUIMGDialog_wnd_title");
        // public static By edituserqualification = By.XPath("(//a[contains(text(),'Edit')])[5]");
        public static By edituserqualification = By.Id("MainContent_UCProfile_ucQualification_lnkEdit");
        public static By userqualificationeducationdescription = By.Id("MainContent_UC1_FormView1_USR_EDUCATION_DESCRIPTION");
        public static By userqualificationexpertise = By.Id("MainContent_UC1_FormView1_USR_EXPERTISE");
        public static By userqualificationjoddescription = By.Id("MainContent_UC1_FormView1_USR_JOB_DESCRIPTION");
        public static By userqualificationsave = By.Id("MainContent_UC1_Save");



        public static By edituserpref = By.XPath("(//a[contains(text(),'Edit')])[7]");
        // public static By userprefshowlanguage = By.Id("MainContent_UC1_FormView1_USR_508C_OPTION");
        public static By userprefshowcontactinfo = By.Id("MainContent_UC1_FormView1_USR_SHOW_CONTACT_INFO");
        public static By userpreshowprofessionalinfo = By.Id("MainContent_UC1_FormView1_USR_SHOW_PROFESSIONAL_INFO");
        public static By userprefcommunicationemail = By.Id("MainContent_UC1_FormView1_USR_COMMUNICATION_EMAIL");
        public static By userprefcommunicationmessage = By.Id("MainContent_UC1_FormView1_USR_COMMUNICATION_MESSAGES");

        public static By userpreflocallanguage = By.Id("MainContent_UC1_FormView1_USR_LANGUAGE_LOCALE_ID");
        public static By userpreflocalregion = By.Id("MainContent_UC1_FormView1_USR_REGION_LOCALE_ID");
        public static By userpreftimezone = By.Id("MainContent_UC1_FormView1_USR_TIME_ZONE_ID");
        public static By userpreftheme = By.Id("MainContent_UC1_FormView1_STYLESHEET");
        public static By userprefpagesize = By.Id("MainContent_UC1_FormView1_PAGE_SIZE");

        public static By userprefsave = By.Id("MainContent_UC1_Save");

        public static By edituserworkinfo = By.Id("MainContent_UCProfile_ucWorkInfo_lnkEdit");

        public static By edituserworkinfo_addorg = By.Id("MainContent_UC1_FormView1_lnkAddOrg");
        public static By edituserworkinfo_search = By.Id("MainContent_UC1_btnSearch");
        public static By edituserworkinfo_checkoptions = By.XPath("//input[contains(@id, '_chkSelect')]");
        public static By edituserworkinfo_saveorok = By.Id("MainContent_UC1_Save");
        public static By editworkinfo_FormView1_Save = By.Id("MainContent_UC1_FormView1_Save");
        public static By edituserworkinfo_addjobtitle = By.Id("MainContent_UC1_FormView1_HyperLink2");
        public static By edituserworkinfo_addmanagers = By.Id("MainContent_UC1_FormView1_HyperLink1");
        public static By edituserworkinfo_usrcompanyname = By.Id("MainContent_UC1_FormView1_USR_COMPANY");
        public static By edituserworkinfo_companystreetadd = By.Id("MainContent_UC1_FormView1_USR_WORK_STREET_ADDRESS");
        public static By edituserworkinfo_companycity = By.Id("MainContent_UC1_FormView1_USR_WORK_CITY");
        public static By edituserworkinfo_companypostalcode = By.Id("MainContent_UC1_FormView1_USR_WORK_POSTAL_CODE");
        public static By edituserworkinfo_config_enablemultiplejobtitle = By.Id("TabMenu_ML_BASE_HEAD_Users_ENABLE_USERMULTIPLEJOBTITLES_1");
        public static By edituserworkinfo_config_enablemultipleorg = By.Id("TabMenu_ML_BASE_HEAD_Users_ENABLE_USERMULTIPLEORGANIZATIONS_1");
        public static By edituserworkinfo_config_enablemultiplemanagers = By.Id("TabMenu_ML_BASE_HEAD_Users_ENABLE_USERMULTIPLEMANAGERS_1");
        public static By MyProfileMgrsToDelete = By.XPath("//a[contains(@id, '_lnkMgrDelete')]");
        public static By MyProfileJobTitleToDelete = By.XPath("//a[contains(@id, '_lnkRemoveUserJobTitle')]");
        public static By MyProfileOrgsToDelete = By.XPath("//a[contains(@id, '_lnkRemoveUserManager')]");

        public static By MyProfileMgrsIconToDelete = By.Id("ctl00_MainContent_UC1_FormView1_rlvOrg_ctrl1_imgMgrDelete");
        public static By MyProfileJobTitleIconToDelete = By.Id("ctl00_MainContent_UC1_FormView1_rlvJobTitle_ctrl1_lnkRemoveUserJobTitle");
        public static By MyProfileOrgsIconToDelete = By.Id("ctl00_MainContent_UC1_FormView1_rlvManager_ctrl0_lnkRemoveUserManager");

        //generalcourse
        public static By create_btn_new = By.Id("MainContent_UC1_Save");
        public static By create_btn_newchklist = By.Id("MainContent_MainContent_UC1_Save");
        public static By genCourseTitle_updateED = By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_TITLE");
        public static By genCourseTitle_ED = By.Id("CNTLCL_TITLE");
        //public static By genCourseTitle_ED = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        public static By generalcourseenroll_btn = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton");
        public static By generalcoursekeyword = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
        public static By generalcoursechecklistkeyword = By.Id("MainContent_MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
        public static By myresponsibilitiesmanageenrolmentonlinecourses = By.Id("MainContent_ucManageEnrollmentMenu_hlManageOnlineEnrollement");
        public static By desc_htmleditor = By.XPath("//div[@id='Editor']/div[2]/div/p");
        public static By desc_htmlcontrol = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");

        //change user id
        public static By EditLoginIdBtn = By.Id("lnkLoginEdit");
        public static By OldUserId = By.Id("MainContent_UC1_OldLoginId");
        public static By NewUserId = By.Id("MainContent_UC1_USR_LOGIN_ID");
        public static By SaveChangedUserIdBtn = By.Id("MainContent_UC1_Save");

        //change Password
        public static By EditPasswordBtn = By.Id("lnkPasswordEdit");
        public static By OldPassword = By.Id("MainContent_UC1_CurrentPassword");
        public static By NewPassword = By.Id("MainContent_UC1_USR_PASSWORD");
        public static By ConfirmNewPassword = By.Id("MainContent_UC1_ConfirmPassword");
        public static By SaveChangedPasswordBtn = By.Id("MainContent_UC1_Save");

        //change security question
        public static By EditsecurityquestionBtn = By.Id("lnkSecurityQuestionsEdit");
        public static By securityquestion = By.Id("ctl00_MainContent_UC1_rlvQuestions_ctrl1_MQuestion");
        public static By securityanswer = By.Id("ctl00_MainContent_UC1_rlvQuestions_ctrl0_MAnswer");
        public static By SavesecurityquestiondBtn = By.Id("MainContent_UC1_Save");

        //homepagetoolbar
        public static By HelpLink_id = By.Id("NavigationStrip1_lnkHelp");
        // public static By ClanederMonth = By.XPath("//div[@id='ctl00_MainContent_UC1_RadScheduler1']/div/div/ul/li[@class='rsSelected']/em");
        public static By ClanederMonthView = By.CssSelector("div.rsContent.rsMonthView");
        public static By ClanederWeekView = By.CssSelector("div.rsContent.rsWeekView");
        public static By CalenderMonthBtn = By.CssSelector("a.rsHeaderMonth > span");
        public static By CalenderWeekBtn = By.CssSelector("a.rsHeaderWeek > span");

        public static By ShoppingCartLink = By.Id("NavigationStrip1_lnkShoppingCart");
        //tarainig catalog
        public static By trainingcatalogtextsearchfor = By.Id("MainContent_ucSearchLanding_txtSearchFor");
        public static By trainingcatalogtextsearchtype = By.Id("ddlSearchType");
        public static By trainingcatalogtextsearchbutton = By.Id("btnSearch");
        public static By trainingcatalogaddtocart = By.Id("MainContent_ucPrimaryActions_FormView1_AddToCartButtonFlag");
        public static By trainingcatalogaddproducttocart = By.Id("MainContent_ucPrimaryActions_FormView1_AddToCartButtonProductFlag");
                                                                
        public static By trainingcatalogsearch = By.Id("btnSearch");




        //report

        public static By MyReportfirstreport = By.Id("ctl00_MainContent_MyReports_rgReports_ctl00_ctl04_lnkDetails");
        public static By MyReportschedulereport = By.Id("MainContent_ucPrimaryActions_FormView1_ScheduleReport");
        public static By MyReportselectreport = By.Id("TabMenu_ML_BASE_TAB_Report_strContentType_0");
        public static By MyReportstartdatefixcheck = By.Id("TabMenu_ML_BASE_TAB_Report_strFixedDate");
        public static By MyReportselectstartdate = By.Id("TabMenu_ML_BASE_TAB_Report_strFixedStartDate||DATEPICKER_dateInput");
        // public static string schedulereport = "5";
        public static By MyReportrunschedulereport = By.Id("TabMenu_ML_BASE_TAB_Report_RunReport");
        public static By MyReportreporttitle = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_TITLE");
        public static By MyReportreportdiscription = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_DESCRIPTION");
        public static By MyReportrecurrancestartdate = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_START_DATE||DATEPICKER_dateInput");
        public static By MyReportrecurancetime = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_START_DATE||TIMEPICKER_dateInput");//"TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_START_DATE||TIMEPICKER_dateInput_text";

        public static By MyReportrecurranceenddate = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RPTSCH_RECURRENCE_END_DATE||DATEPICKER_dateInput");
        public static By MyReportrecurrancetype = By.CssSelector("option[value=\"ML.BASE.DV.RecurrenceType.Type2WorkDays\"]");
        public static By MyReportrecurrancenext = By.Id("ML.BASE.BTN.Next");
        public static By MyReportscheduleuserlastname = By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_USR_FIRST_NAME");
        public static By MyReportscheduleusersearch = By.Id("TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_ML.BASE.BUTTON.UserSearch");
        // public static string scheduleusersearchlist = "TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_ML.BASE.DATAGRID.UserSearchResults_ctl02_E3DC7289F9D0400686F9D6BFB1055543_MKSI.LMS.Id.SystemEmail.Recipient.DeliveryType.To";
        public static By MyReportscheduleusersearchlist = By.XPath("//table[@id='TabMenu_ML_BASE_TAB_EmailConsole_Trigger_Email_EditRecipients_ML.BASE.DATAGRID.UserSearchResults']/tbody/tr[2]/td/span/input");
        //public static By MyReportcreateschedule = By.Id("ML.BASE.BTN.Create");
        //public static string MyReportbtndeletetask = "//tr[@id=#####]/td[6]/a[contains(@id, '_btnDeleteTask')]";


        public static By MyReportbtndeletetask = By.XPath("//a[contains(@id, '_btnDeleteTask')]");

        public static By MyReportbtnsuspendtask = By.XPath("//a[contains(@id, '_btnSuspendTask')]");


        public static string nameofschedule = string.Empty;

        //set approver
        public static By approvercreategobtn = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public static By approvertitle = By.Id("TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_TITLE");
        public static By approverdesc = By.Id("TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_DESCRIPTION");
        //public static By approvercreatebtn = By.Id("ML.BASE.BTN.Create");
        public static By approvertype = By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl03_DataGridItem_Id");
        public static By approvertypesetbtn = By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_ML.BASE.BTN.AddSelected");
        public static By approverrequestaccessbtnflag = By.Id("MainContent_ucPrimaryActions_FormView1_RequestAccessButtonFlag");
        public static By approverrequestaccessbtn = By.Id("MainContent_UC1_RequestAccess");
        public static By MyResponsbilityApproverrequestlink = By.XPath("//div[@id='ctl00_SiteNavigationBar2_rdNavigationMenu']/ul/li[3]/a/span");
        public static By MyResponsbilityFirstApprovebtn = By.Id("ctl00_MainContent_UC3_rgMyApprovalsByDate_ctl00_ctl04_btnMyApprove");
        public static By MyResponsbilityApprovebtn = By.Id("MainContent_UC1_SubmitRequest");
        public static By MyRequestPendingapprovercount = By.Id("MainContent_ucAddlLinksMyRequests_MLabel1");
        public static By MyRequestAllRequestLink = By.Id("MainContent_ucAddlLinksMyRequests_lnkMyRequests");

        //shopping Cart
        public static By ShoppingCartDeleteFirstItem = By.Id("ctl00_MainContent_UC1_MRadGrid_Digital_ctl00_ctl04_lnkCartItemDelete");
        public static By ShoppingCartDigitalSubTotal = By.XPath(".//*[@id='ctl00_MainContent_UC1_MRadGrid_Digital_ctl00']/tfoot/tr/td[2]/p/strong");
        public static By ShoppingCartSubTotal = By.XPath(".//*[@id='MainContent_UC1_pnlShoppingPanel']/div[3]/div[2]/div[1]/div[2]");

        public static By ShoppingCartUpdateQuantityText = By.Id("ctl00_MainContent_UC1_MRadGrid_Product_ctl00_ctl04_SHOPPINGCART_CONTENT_QTY");
        public static By ShoppingCartUpdateQuantityBtn = By.Id("ctl00_MainContent_UC1_MRadGrid_Product_ctl00_ctl04_UpdateItemQuantity");

        //discount
        public static By DiscountGoBtn = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public static By DiscountTitle = By.Id("TabMenu_ML_BASE_TAB_EditDiscountCode_DSCLCL_TITLE");
        public static By DiscountDesc = By.Id("TabMenu_ML_BASE_TAB_EditDiscountCode_DSCLCL_DESCRIPTION");
        public static By DiscountKeyword = By.Id("TabMenu_ML_BASE_TAB_EditDiscountCode_DSCLCL_KEYWORDS");
        public static By DiscountCode = By.Id("TabMenu_ML_BASE_TAB_EditDiscountCode_DSC_CODE");
        public static By DiscountValue = By.Id("TabMenu_ML_BASE_TAB_EditDiscountCode_DSC_TYPE_VAL");
        // public static By DiscountCreateBtn = By.Id("ML.BASE.BTN.Create");
        public static By DiscountUserGoBtn = By.Id("TabMenu_ML_BASE_TAB_EditUsersOrUserGroup_GoPageActionsMenu");
        public static By DiscountUserSearch = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_SearchRole");
        public static By DiscountSearchType = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_SearchType");
        public static By DiscountSearchGroupBtn = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_ML.BASE.BTN.Search");
        public static By DiscountSelectUserGroupFromList = By.CssSelector("input[id*='TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_ENTITY_ID']");
        // public static By DiscountSelectUserGroupFromList = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_ENTITY_ID_6_ENTITY_LIST_1_5_3C910F4801E54FDCA6A821CD2F09754D_P_");
        public static By DiscountAssignUserGroupBtn = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_AssignTraining");
        public static By DiscountEditActivit = By.XPath("//a[@id='ML.BASE.WF.EditActivity']/span");
        public static By DiscountSaveBtn = By.Id("ML.BASE.BTN.Save");
        public static By DiscountSelectToDelete = By.Id("TabMenu_ML_BASE_TAB_Search_DeletedCode_1_DISCOUNT_CODE_1_0_58E37AD800F84F1597992F3C893CB33E_P_");
        public static By DiscountDeleteBtn = By.Id("TabMenu_ML_BASE_TAB_Search_Delete");
        public static By DiscountCodeApplytxt = By.Id("MainContent_UC1_tbDiscountCode");
        public static By DiscountApplyBtn = By.Id("MainContent_UC1_ApplyDiscountCode");
        public static By ShoppingCartGrandTotal = By.XPath("//div[@id='MainContent_UC1_pnlShoppingPanel']/div[3]/div[2]/div[5]/div/div[2]");//By.XPath("//span[@class='grand-total']");
        public static By ShoppingCartCheckoutPageBtn = By.Id("MainContent_UC1_Checkout");

        public static By MultipleCurrencyCheck = By.Id("TabMenu_ML_BASE_MultipleCurrency_MULTICURRENCY_SUPPORT_0");
        public static By MultipleCurrencySaveBtn = By.Id("ML.BASE.BTN.Save");

        public static By SwitchCurrencyBtn = By.Id("MainContent_UC1_SwitchCurrency");
        public static By SwitchCurrencySelectCurrency = By.Id("MainContent_UC1_USR_CURRENCY_ID");
        public static By SwitchCurrencySaveBtn = By.Id("MainContent_UC1_Save");

        public static By SwitchCurrencyExchangeRate = By.Id("MainContent_UC1_pnlExchangeRate");

        public static By ShippingStreet = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_STREET");
        public static By ShippingCity = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_CITY");
        public static By ShippingState = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_STATE_ID");
        public static By ShippingCountry = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_COUNTRY_ID");
        public static By ShippingZipCode = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_ZIP");
        public static By ShippingPhoneNo = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_PHONE");
        public static By ShippingContinueToCheckout = By.Id("MainContent_UC1_ContinueToPayment");

        public static By BillingStreet = By.Id("PI_BILL_TO_STREET");
        public static By BillingCity = By.Id("PI_BILL_TO_CITY");
        public static By BillingState = By.Id("PI_BILL_TO_STATE_ID");
        public static By BillingCountry = By.Id("PI_BILL_TO_COUNTRY_ID");
        public static By BillingZip = By.Id("PI_BILL_TO_ZIP");
        public static By BillingPhone = By.Id("PI_BILL_TO_PHONE");
        public static By BillingSaveBtn = By.Id("MainContent_UC1_btnSave");


        public static By ShoppingCartCheckOut = By.Id("MainContent_UC1_Checkout");
        // public static IWebDriver _driverforall = null;


        //calender
        public static By MoveToParent = By.XPath("..");
        public static By AddEventToCalenderBtn = By.LinkText("+");
        public static By CalenderEventTitle = By.Id("MainContent_UC1_FormView1_EVT_TITLE");
        public static By CalenderEventStartTime = By.Id("ctl00_MainContent_UC1_FormView1_EVT_START_TIME_dateInput");
        public static By CalenderEventEndTime = By.Id("ctl00_MainContent_UC1_FormView1_EVT_END_TIME_dateInput");
        public static By CalenderSaveEditBtn = By.Id("MainContent_UC1_Save");
        public static By CalenderDeleteBtn = By.Id("MainContent_UC1_Delete");

        //homepagefeeds
        public static By HomeFeedsGoBtn = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public static By HomeFeedsTitle = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_HMFD_FILE_TITLE");
        public static By HomeFeedsDesc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_HMFD_FILE_DESCRIPTION");
        public static By HomeFeedsKeywords = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_HMFD_FILE_KEYWORDS");
        // public static By HomeFeedsCreateBtn = By.Id("ML.BASE.BTN.Create");
        public static By HomeFeedsHtmlInfo = By.Id("TabMenu_ML_BASE_TAB_EditHtmlInfo_HMFD_HTML_BLOCK");
        public static By HomeFeedsSaveBtn = By.Id("ML.BASE.BTN.Save");
        public static By HomeFeedsSelectDomain = By.XPath("//span[contains(.,'Meridian Global - Core Domain(Default)')]"); //By.XPath("//div[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1']/span[2]");
        public static By HomeFeedsSetDomain = By.XPath("//span[contains(.,'Homepage Feed')]");
        public static By HomeFeedsSearchFor = By.Id("TabMenu_ML_BASE_TAB_SelectHomepageFeed_SearchFor");
        public static By HomeFeedsSearchForBtn = By.Id("TabMenu_ML_BASE_TAB_SelectHomepageFeed_SearchFeeds");
        public static By HomeFeedsSelectFeed = By.Id("TabMenu_ML_BASE_TAB_SelectHomepageFeed_HomepageFeeds_ctl02_DataGridItem_HMFD_FILE_ID");
        public static By HomeFeedsSelectFeedBtn = By.Id("TabMenu_ML_BASE_TAB_SelectHomepageFeed_ML.BASE.BTN.SelectFeed");

        //upcoming training
        public static By UpComingTraining = By.XPath("//a[contains(text(),'Upcoming Learning')]");
        public static By UpComingTrainingFilter = By.Id("MainContent_UC3_ddlFilter");
        public static By UpComingTrainingRequiredLegend = By.Id("MainContent_UC3_legReqTraining");
        public static By UpComingTrainingOverDueLegend = By.Id("MainContent_UC3_legOverdue");
        public static By UpComingTrainingDueSoonLegend = By.Id("MainContent_UC3_legDueSoon");
        public static By UpComingTrainingRecurringLegend = By.Id("MainContent_UC3_legRecurring");

        //externallearningtype
        public static By eltypegobutton = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public static By eltype_link = By.XPath("//a[contains(text(),'External Learning Types')]");
        public static By eltypetitle = By.Id("TabMenu_ML_BASE_TAB_EditExternalLearningType_ELTL_TYPE_TITLE");
        public static By eltypedesc = By.Id("TabMenu_ML_BASE_TAB_EditExternalLearningType_ELTL_TYPE_DESC");
        public static By eltypecreate = By.Id("ML.BASE.BTN.Create");
        public static By eltypesave = By.Id("ML.BASE.BTN.Save");
        public static By eltypesucessmsg = By.Id("ReturnFeedback");

        //externallerning
        public static By elgobutton = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public static By el_link = By.XPath("//a[text()='External Learning']");

        public static By eltitle = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_EXT_TITLE");
        public static By eldescription = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_EXT_DESCRIPTION");
        public static By elkeyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_EXT_KEYWORDS");
        public static By eltypeselect = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_EXT_LEARNING_TYPE_ID");
        public static By elcreate = By.Id("ML.BASE.BTN.Create");


        //externallerning

        public static By elconsole_link = By.XPath("//a[contains(text(),'External Learning')]");

        public static By eluserfirstname = By.Id("TabMenu_ML_BASE_LBL_SearchUsers_USR_FIRST_NAME");
        public static By elusersearch = By.Id("TabMenu_ML_BASE_LBL_SearchUsers_ML.BASE.BTN.Search");
        public static By elgoforaction = By.Id("TabMenu_ML_BASE_LBL_SearchUsers_CONTENT_ITEM_GoButton_1");
        public static By elapprovecheck = By.Id("TabMenu_ML_BASE_ACT_TakeAction_ELH_STATUS_ID_0");

        public static By elapprovereason = By.Id("TabMenu_ML_BASE_ACT_TakeAction_ELH_REASON");
        public static By elexpirydate = By.Id("TabMenu_ML_BASE_ACT_TakeAction_ELR_EXP_DATE||DATEPICKER_dateInput");
        public static By eltakeaction = By.Id("TabMenu_ML_BASE_ACT_TakeAction_ML.BASE.BTN.TakeAction");
        public static By elconsolesucessmsg = By.Id("ReturnFeedback");
        public static By elsubmitrequestbutton = By.Id("MainContent_ucPrimaryActions_FormView1_SubmitRequestBlock");
        public static By elrequestreason = By.Id("MainContent_UC1_fvSubmitRequest_ELR_REASON");
        public static By elrequestdateobtained = By.Id("ctl00_MainContent_UC1_fvSubmitRequest_ELR_OBTAINED_DATE_dateInput");
        public static By elrequestsubmitrequestbtn = By.Id("MainContent_UC1_SubmitRequest");


        public static By TranscriptHome = By.XPath("//a[contains(text(),'Transcript')]");
        public static By TranscriptELLink = By.Id("MainContent_ucQLinks_lnkEL");
        public static By elsubmitrequestbtn = By.Id("MainContent_UC2_MLinkButton1");
        public static By elsearchforbtn = By.Id("MainContent_UC1_txtSearchFor");

        public static By elprintbtn = By.XPath("//a[contains(text(),'Print')]"); //By.Id("MainContent_UC1_MLinkButton1");// not using id bcoz differs on ff and ie
        public static By elprintpagelink = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails");
        public static string elprintpagetitle = "All My Training";

        public static By elsaveaspdfbtn = By.XPath("//a[contains(text(),'Save as PDF')]");//By.Id("MainContent_UC1_SaveAsPDF");// not using id bcoz differs on ff and ie
        public static string elpdfpagetitle = "AllMyTrainingPrint.aspx";

        //All My Training
        public static By allmytraininglink = By.Id("MainContent_ucQLinks_lnkAllTraining");
        public static By allmytrainingstatusfilter = By.Id("MainContent_UC1_ddlStatus");


        public static By allmytrainingprintbtn = By.XPath("//a[contains(text(),'Print')]"); //By.Id("MainContent_UC1_MLinkButton1");// not using id bcoz differs on ff and ie
        public static By allmytrainingprintpagelink = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails");
        public static string allmytrainingprintpagetitle = "All My Training";

        public static By allmytrainingsaveaspdfbtn = By.XPath("//a[contains(text(),'Save as PDF')]");//By.Id("MainContent_UC1_SaveAsPDF");// not using id bcoz differs on ff and ie
        public static string allmytrainingpdfpagetitle = "AllMyTrainingPrint.aspx";

        //sales tax
        public static By ManageTaxRateLink = By.LinkText("Manage Tax Rates");
        public static By TaxItemCatagoryLink = By.LinkText("Tax Item Categories");

        //manage tax
        public static By AddNewTaxTableBtn = By.Id("MainContent_UC1_btnAddNewTaxTable");
        public static By TaxTableTitle = By.Id("MainContent_UC1_tbTaxTableTitle");
        public static By AddTaxTableBtn = By.Id("MainContent_UC1_btnAddNewTaxTable");

        public static By alltaxtable = By.XPath("//a[contains(@id, '_btnManageTaxRateTable')]");// By.XPath("//tr['ctl00_MainContent_UC1_rgTaxTables_ctl00']/tbody/tr");
        public static string ManageTaxTableBtn = "ctl00_MainContent_UC1_rgTaxTables_ctl00__";
        public static By ManageTaxRateState = By.Id("MainContent_UC1_ADD_STATE_DLL");
        public static By taxratetxt = By.Id("MainContent_UC1_tbDefaultTaxRate");
        public static By checkshippingtax = By.Id("MainContent_UC1_cbTaxShipping");
        public static By shippingtaxratetxt = By.Id("MainContent_UC1_tbShippingTaxRate");
        public static By addshippinforstatebtn = By.Id("MainContent_UC1_btnAddStateAndCounties");
        public static By Returntoadminbtn = By.Id("Return");

        //taxitemcategory
        public static By AddNewTaxItemCatageroyBtn = By.Id("MainContent_UC1_btnAddFirstTaxItemCategory");
        public static By TaxCategoryTxt = By.Id("MainContent_UC1_tbTaxItemCategoryTitle");
        public static By selectTaxTable = By.Id("MainContent_UC1_ddlTaxTables");
        public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_btnAddTaxItemCategory");

        public static bool upcomingtraingcreated = false;


        public static By content_management_Link = By.XPath("//div[@id='ctl00_SiteNavigationBar2_rdNavigationMenu']/ul/li[2]/a/span");

        //My Tasks

        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_ucSearchTop_ddlCreateNew");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_ucSearchTop_btnCreateNew");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_btnAddTaxItemCategory");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_btnAddTaxItemCategory");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_btnAddTaxItemCategory");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_btnAddTaxItemCategory");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_btnAddTaxItemCategory");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_btnAddTaxItemCategory");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_btnAddTaxItemCategory");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_btnAddTaxItemCategory");
        //public static By AddTaxItenCatageryBtn = By.Id("MainContent_UC1_btnAddTaxItemCategory");

        public static By switchToFrame_New = By.CssSelector("iframe[class='k-content-frame']");
    }
}
