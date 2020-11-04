using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using TestAutomation.Suite1.Administration.AdministrationConsole;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
  //  [Parallelizable(ParallelScope.Fixtures)]
    public class P1_Catalog_ClassroomContentDetailPagesTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_ClassroomContentDetailPagesTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string SectionCode = "CSC" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string documenttitle = "Document" + Meridian_Common.globalnum;
        string scormtitle = "SCROM" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;
        string bunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string OJTTitle = "OJT" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        bool TC56350, TC56877, TC56236, TC56236_1;
        string TATitle= "TA" + Meridian_Common.globalnum;

     
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
     

        //Start writing your test here

        [Test, Order(1)]

        public void a01_As_a_learner_I_want_to_view_classroom_course_content_details_page_Schedule_tab_56348()
        {
            #region Create a classroom course and add multiple section having cost without cost
            //CommonSection.CreateLink.ClassroomCourse();
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_56348");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");

            ManageClassroomCoursePage.ClickSectionTab();
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            SectionDetailsPage.ClickScehduleTab();
            _test.Log(Status.Info, "Click on Schedule tab page");
            SectionDetailsPage.ScheduleTab.ClickCreateNewEvent();
            CreateNewEvent.ScheduleTab.CreateNewEvent("Dally");
            #endregion
            CommonSection.SearchCatalog(classroomcoursetitle + "_56348");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_56348");
            Assert.IsTrue(ContentDetailsPage.isScheduleTabdisplay());
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.IsSectiondisplay());
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.TotlaSchedulesectionCount()>=1);
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.isShotbyDisplay());
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsEnrollbuttonDisplay());
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsViewAllSectionlinkDisplay());
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickSectionlink();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsMoreeventdetailsDisplay());
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.isNumberofSeatAvailable() >= 1);
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.isEnrollmnetopeningInfoDisplay());
            TC56350 = true;
        }
        [Test, Order(17)]
        public void P20_1_User_Adds_Instructor_While_Creating_a_Classroom_Course_34064()
        // Pre-req:  Create a personal Item manually in Instructor Calendar from Avatar >> Calendar

        {
            #region  Pre-req:  Create a personal Item manually in Instructor Calendar from Avatar >> Calendar
            string CreatedEvent = "Appointment with Doctor " + Meridian_Common.globalnum;
            CommonSection.Logout();
            LoginPage.LoginAs("ak_instructor").WithPassword("").Login();
            _test.Log(Status.Info, "Login with instructor Account");
            CommonSection.Avatar.Calendar();
            _test.Log(Status.Info, "Click on Calendar");
            CalendarPage.CreateNewEvent(CreatedEvent);
            _test.Log(Status.Info, "Click on Create New Event to Create new Event");

            Assert.IsTrue(CalendarPage.VerifySuccessMessage());
            #endregion
            //Comment to Check
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Instructor");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Successful Message");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add New section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title As Section1");
            ManageClassroomCoursePage.SelectAllDayEvent();// ScheduleSection.SelectAllDayEvent("Yes");
            _test.Log(Status.Info, "Click All Day Event as Yes");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            _test.Log(Status.Pass, "Verify Select Instructor modal is displayed");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("ak_instructor"); //Instructor Name
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModal.InstructorAvailability("Occupied"));
            _test.Log(Status.Info, "Select Instructor Modal is displayed with availability as Occupied for personal days");
            ManageClassroomCoursePage.SelectInstructorModal.ClickViewScheduleButton();
            _test.Log(Status.Info, "Select View Schedule button for the User with personal days");
            Assert.IsTrue(ManageClassroomCoursePage.InstructorCalendarModal.VerifyPersonalDaysDisplayed(DateTime.Today, CreatedEvent));
            _test.Log(Status.Pass, "Verify Instructor Calendar Modal is displayed with the personal days description");




            //    ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "Instructor");
            //    _test.Log(Status.Info, "New Classroom Course Created");
            //    Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            //    _test.Log(Status.Pass, "Verify Successful Message");

            //    ManageClassroomCoursePage.Clicktab("Sections");
            //    _test.Log(Status.Info, "Clcik on Sections Tab");
            //    ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            //    _test.Log(Status.Info, "Click on Add New section");
            //    ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //    _test.Log(Status.Info, "Enter Section Title As Section1");
            //    ManageClassroomCoursePage.SelectAllDayEvent();// ScheduleSection.SelectAllDayEvent("Yes");
            //    _test.Log(Status.Info, "Click All Day Event as Yes");
            //    ManageClassroomCoursePage.ClickSelectInstructorButton();
            //    _test.Log(Status.Info, "Click Select Instructor Button");
            //    Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            //    _test.Log(Status.Pass, "Verify Select Instructor modal is display");
            //    ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("site");
            //    _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            //    ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            //    _test.Log(Status.Info, "Select searched instructor and Click on Set");
            //    Assert.IsTrue(ManageClassroomCoursePage.InstructorAdded());
            //    _test.Log(Status.Pass, "Verify Added instructor display bellow Select Instructor button");
            //    ManageClassroomCoursePage.ClickSelectInstructorButton();
            //    _test.Log(Status.Info, "Click Select Instructor Button again");
            //    Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            //    _test.Log(Status.Pass, "Verify Select Instructor modal is display");
            //    ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("");
            //    _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            //    ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            //    _test.Log(Status.Info, "Select searched instructor and Click on Set");
            //    Assert.IsTrue(ManageClassroomCoursePage.InstructorAdded());
            //    _test.Log(Status.Pass, "Verify Added instructor display bellow Select Instructor button");
            //    ManageClassroomCoursePage.removeinstructors();
            //    _test.Log(Status.Info, "Select searched instructor and Click on Set");
            //    Assert.IsTrue(ManageClassroomCoursePage.InstructorAdded());
            //    _test.Log(Status.Info, "No Instructor display on screen");
            //    ManageClassroomCoursePage.DeleteContent(classroomcoursetitle + "Instructor");

        }

        [Test, Order(2)]
        public void a02_Learner_view_details_information_in_Section_Card_for_a_section_available_for_Enroll_in_Schedule_tab_56350()
        {
            Assert.IsTrue(TC56350);
        }
        [Test, Order(3)] //depend on TC56348
        public void a03_Learner_view_a_no_Cost_Classroom_Course_View_history_tab_on_Content_Details_Catalog_page_56304()
        {
            CommonSection.SearchCatalog(classroomcoursetitle + "_56348");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_56348");
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickEnrollButton();
            StringAssert.AreEqualIgnoringCase("Success\r\nYou are enrolled in the course.\r\n×", Driver.getSuccessMessage());
            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            ContentDetailsPage.Click_HistoryTab_Curriculum();            
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyEnrolledinSection("Section1"));
        }
        [Test, Order(4)]
        public void a04_Learner_view_details_information_in_Section_Card_for_a_section_available_for_Enroll_with_Cost_in_Schedule_tab_56351()
        {
            #region Create a classroom course and add multiple section having cost without cost
           
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_56351");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            ManageClassroomCoursePage.ClickSectionTab();
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            SectionDetailsPage.ClickEditCost();
          EditSectionCostPage.setDefultCost("5");
            #endregion
            CommonSection.SearchCatalog(classroomcoursetitle + "_56351");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_56351");
            Assert.IsTrue(ContentDetailsPage.isScheduleTabdisplay());
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.IsSectiondisplay());
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.TotlaSchedulesectionCount() >= 1);
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsAddtoCartbuttonDisplay());
            TC56236 = true;
        }
        [Test, Order(5)]
        public void a05_Learner_view_a_Paid_Classroom_Course_View_history_tab_on_Content_Details_Catalog_page_56305()
        {
            CommonSection.SearchCatalog(classroomcoursetitle + "_56351");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_56351");
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickAddtoCartButton();
            CommonSection.Completepurchage(classroomcoursetitle + "_56351");
            //ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            //ContentDetailsPage.ScheduleTab.SectionPortlet.ClickEnrollButton();
            //StringAssert.AreEqualIgnoringCase("Success\r\nYou are enrolled in the course.\r\n×", Driver.getSuccessMessage());
            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            // StringAssert.AreEqualIgnoringCase("Success\r\nThe competency was created.\r\n×", Driver.getSuccessMessage());
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyEnrolledinSection("Section1"));
        }
        [Test, Order(6)]
        public void a06_Learner_view_details_information_in_Section_Card_for_a_section_is_Enrollment_Full_in_Schedule_tab_56352()
        {
            #region Create a classroom course and add multiple section having cost without cost
            
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_56352");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.EnterMaximum("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            _test.Log(Status.Pass, "Verify Enrollment is display");
            ManageClassroomCoursePage.Enrollmenttab.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll");
            ManageClassroomCoursePage.BatchEnrollUserModal.EnrollUser("userreg");
            #endregion

            CommonSection.SearchCatalog(classroomcoursetitle + "_56352");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_56352");
            Assert.IsTrue(ContentDetailsPage.isScheduleTabdisplay());
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.IsSectiondisplay());
            Assert.IsFalse(ContentDetailsPage.ScheduleTab.SectionPortlet.IsEnrollbuttonDisplay());
           // ContentDetailsPage.ScheduleTab.SectionPortlet.ClickEnrollButton();
           // StringAssert.AreEqualIgnoringCase("Success\r\nThe competency was created.\r\n×", Driver.getSuccessMessage()); "Error message is different");
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.isSectionFullinfoDisplay());
        }
        [Test, Order(7)]
        public void a07_Learner_view_a_Classroom_Course_with_AccessKey_View_history_tab_on_Content_Details_Catalog_page_56306()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_56306");
            ContentDetailsPage.Accordians.ClickEdit_CostNSalesTax();
            CostPage.DefaultCostAs("5").Save();
            CostPage.ClickReturn();
            ContentDetailsPage.Accordians.ClickEdit_AccessKey();
            AccessKeysPage.EnableAccessKey("Yes").Save();

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            //ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            ManageClassroomCoursePage.EnterMaximum("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");

            CommonSection.SearchCatalog(classroomcoursetitle + "_56306");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_56306");
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickAddtoCartButton();
            CommonSection.Completepurchage(classroomcoursetitle + "_56306");
            CommonSection.Manage.AccessKeys();
            AccessKeysPage.searchForContent(classroomcoursetitle + "_56306");
            AccessKeysPage.Enroll();

            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            // StringAssert.AreEqualIgnoringCase("Success\r\nThe competency was created.\r\n×", Driver.getSuccessMessage());
            ContentDetailsPage.Click_HistoryTab_Curriculum();

            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyEnrolledinSection("Section1"));
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyEnrolledinSectionwithAccessKey());
        }
        [Test, Order(8)]
        public void a08_View_RT_Assignments_for_Classroom_27128()
        {
            #region Create a classroom course and add multiple section having cost without cost
            
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_27128");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            #endregion
            #region cretate TA
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "27128");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(classroomcoursetitle + "_27128");
            _test.Log(Status.Info, "Content added to training assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assignees button in Assignees tab");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("learner 101");
            _test.Log(Status.Info, "A user added to training assignment");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            string previousCompletions = CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetPreviousCompletionsYesandRecurringNo("days");
            _test.Log(Status.Info, "Set Previous Completions count and save for Non recurring assignement");
            CreateTrainingAssignmentPage.ClickDueDateTab();
            _test.Log(Status.Info, "Click Chage button in Due Date tab");
            Assert.IsTrue(CreateTrainingAssignmentPage.DueDateTab.VerifyPreviousComplistion(previousCompletions));
            _test.Log(Status.Pass, "Verify Copletion count saved properly");
            CreateTrainingAssignmentPage.clickAssignButton();
            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();

            CommonSection.SearchCatalog(classroomcoursetitle + "_27128");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_27128");
            Assert.IsTrue(ContentDetailsPage.isScheduleTabselected());
            ContentDetailsPage.Click_OverviewTab();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isTrainingAssignmentportletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.TrainingAssignment.isDuedatedisplay());
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            //Assert.IsTrue(ContentDetailsPage.ScheduleTab.isMakeaschedulesuggestionLinkDisplay());
            //ContentDetailsPage.ScheduleTab.Click_MakeascheduleSuggestionLink();
            //Assert.IsTrue(ContentDetailsPage.ScheduleTab.isExpressInterstModalDisplay());
            //ContentDetailsPage.ScheduleTab.SubmitExpressInterst("Test");
            //StringAssert.AreEqualIgnoringCase("Success\r\nYou are now enrolled.\r\n×", Driver.getSuccessMessage(), "Error message is different");
        }
        [Test, Order(9)]
        public void a09_Learner_can_see_More_like_this_Part_of_collection_and_Prerequisites_for_this_itemas_portlets_on_classroom_course_detail_page_56168()
        {
            //Create a classromm (classroomcoursetitle_56168")course add a old tag, add some pre requisite and add this classroom couser to any curriculumn/contener
            CommonSection.SearchCatalog("ClassroomCourse-TC56168");
            SearchResultsPage.ClickCourseTitle("ClassroomCourse-TC56168");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isMorelikethisPortletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPartoftheseCollectionDisplay());

        }
        [Test,Order(10)]
        public void a10_Learner_view_Classroom_Overview_Section_Panel_when_access_has_been_requested_on_section_with_cost_and_access_approval_58258()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Create a classroom course and add multiple section having cost without cost
            
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC58258");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            AccessApprovalPage.AssignApproverPath();

            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            ManageClassroomCoursePage.ClickSectionTab();
            ManageClassroomCoursePage.ClickSectionTitle("Section1");
            SectionDetailsPage.ClickEditCost();
            EditSectionCostPage.setDefultCost("5");
            EditSectionCostPage.clickbradcrumbSectionsLink();
            ManageClassroomCoursePage.Sectiontab.ClickaddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section2");
            Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='startDate']")).SendKeys("10/15/2019 5:30 PM");
            Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).Clear();
            Driver.Instance.GetElement(By.XPath("//input[@id='endDate']")).SendKeys("10/15/2019 6:30 PM");
            IWebElement webElement = Driver.Instance.GetElement(By.XPath("//button[@id='location_0']"));//You can use xpath, ID or name whatever you like
            webElement.SendKeys(Keys.Tab);
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Clcik create button");
            ManageClassroomCoursePage.ClickSectionTab();
            ManageClassroomCoursePage.ClickSectionTitle("Section2");
            SectionDetailsPage.ClickEditCost();
            EditSectionCostPage.setDefultCost("5");
            #endregion
            CommonSection.SearchCatalog(classroomcoursetitle + "_TC58258");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC58258");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isNextavailableSectiondisplay());
            string NextAvailableSectionname = ContentDetailsPage.OverviewTab.NextavailableSectionTitle(); //AC1
            Assert.IsTrue(ContentDetailsPage.isScheduleTabdisplay());
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.IsSectiondisplay());
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.TotlaSchedulesectionCount() >= 1);
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsRequestAccessbuttondisplay("Section2")); //AC2
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickRequestAccessbutton("Section2");
            ContentDetailsPage.ScheduleTab.SectionPortlet.RequestAccess_classroomsection();
            _test.Log(Status.Info, "Complete the Access Request process");
            //StringAssert.AreEqualIgnoringCase("Success\r\nYour request for access approval was submitted. You will receive an email indicating whether your request is approved or denied. You will automatically have access to the content if your request is approved.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.IsCancelRequestbuttondisplay("Section2")); //AC3
            ContentDetailsPage.Click_OverviewTab();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.NextavailableSectionTitle() != NextAvailableSectionname); //AC4
            _test.Log(Status.Pass, "Verify Next available section is not the most recent one");
        }
        [Test, Order(11)]
        public void tc_57311_Classroom_Overview_Learner_who_is_not_enrolled_can_view_next_Section()
        {
            //create a section with, section code instructur, location, note and (virtual connector-not posible in external or ps)
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC57311");
            
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionCode(SectionCode);
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
            ManageClassroomCoursePage.ClickSelectInstructorButton();
            _test.Log(Status.Info, "Click Select Instructor Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectInstructorModaldisplay());
            _test.Log(Status.Pass, "Verify Select Instructor modal is display");
            ManageClassroomCoursePage.SelectInstructorModal.SearchInstructor("site");
            _test.Log(Status.Info, "Search any instructor in Select Instructor Modal");
            ManageClassroomCoursePage.SelectInstructorModal.SelectandClickSet();
            _test.Log(Status.Info, "Select searched instructor and Click on Set");
            Assert.IsTrue(ManageClassroomCoursePage.InstructorAdded());
            _test.Log(Status.Pass, "Verify Added instructor display bellow Select Instructor button");
            Assert.IsTrue(ManageClassroomCoursePage.EnterNotes("Testing Notes"));
            _test.Log(Status.Pass, "Assertion Pass - Added Notes into Section");
            ManageClassroomCoursePage.ClickSelectLocationButton();
            _test.Log(Status.Info, "Click on Select Location Button");
            Assert.IsTrue(ManageClassroomCoursePage.SelectLocationModaldisplay());
            _test.Log(Status.Pass, "Select Location Modal is display");
            ManageClassroomCoursePage.SelectLocationModal.Addlocation();
            _test.Log(Status.Info, "Location added");
            
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            ManageClassroomCoursePage.ClickViewasLearner();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isNextavailableSectiondisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.NextavailableSection.isSectionTitledisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.NextavailableSection.isSectionCodedisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.NextavailableSection.isSectionrelatedinfodisplay("startdate", "time", "location", "map", "instructor"));
            Assert.IsTrue(ContentDetailsPage.OverviewTab.NextavailableSection.isEnrollbuttondisplay());
        }
        [Test, Order(12)]
        public void tc_57274_Classroom_Overview_Post_Enrollment_Section_Panel()
        {
            //use tc_57311 data to validate (Enroll and validated)
            //string sectioncode ="12"; //this value should be same as entered value during section cretation
            CommonSection.SearchCatalog(classroomcoursetitle + "_TC57311");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC57311");
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsFalse(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.ContentBanner.CLickScheduleButton();
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickEnrollButton();
            ContentDetailsPage.ContentBanner.Click_ScheduleButton();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.isScetioncodedisplay(SectionCode));
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.isSectionrelatedinfodisplay("startdate", "time", "location", "map", "instructor"));
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.isSectionnotesdisplay());
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.SectionPortlet.isCancelEnrollmentlinkdisplay());
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.GeneralCourse_ReviewsTab.WriteaReview("Title", "For Testing");
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isReviewlistUpdated("Title"));
            TC56877 = true;
        }
        [Test, Order(13)]
        public void tc_57008_Learner_View_content_assignments_associated_with_course()
        {
            //create classromm, section and add different content and one assignemt and make them available on enroll
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickEnrollButton();
            Assert.IsTrue(ContentDetailsPage.isCotentTabDisplay());
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.ContentTab.isAssignedworksectiondisplay());
            Assert.IsTrue(ContentDetailsPage.ContentTab.isCoursematerialsectiondisplay());
            Assert.IsTrue(ContentDetailsPage.ContentTab.Assignedwork.isduedateandgreaddisplay());
            Assert.IsTrue(ContentDetailsPage.ContentTab.Coursematerial.coursetypeandaccessbuttondisplay());


        }
    
        [Test, Order(14)]
        public void tc_56877_Classroom_Course_Reviews_Tab()
        {


            Assert.IsTrue(TC56877);
            

        }
        //[Test, Order(15)]
        //public void tc_56365_Learner_Views_classroom_specific_items_in_Banner_Schedule()
        //{
        //    //cant automate as its envolve virtual connector
        //}
        [Test, Order(16)]
        public void tc_56349_Learner_Make_a_schedule_suggestion_for_classroom_course_from_Classroom_Course_Content_details_page_Schedule_tab()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC56349");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");

            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();

            ManageClassroomCoursePage.ClickViewasLearner();
            ContentDetailsPage.ScheduleTab_click();

            Assert.IsTrue(ContentDetailsPage.ScheduleTab.isMakeaschedusuggestionlinkdisplay());
            ContentDetailsPage.ScheduleTab.ClickMakeaschedusuggestionlink();
            Assert.IsTrue(ContentDetailsPage.ScheduleTab.isExpressInterestModalopened());
            ContentDetailsPage.ScheduleTab.Submitschedulesuggestion();  //you need to verify this method copy from katalon
            StringAssert.AreEqualIgnoringCase("Success The item was submitted.×", Driver.getSuccessMessage(), "Error message is different");

        }
       
       
        [Test, Order(19)]
        public void tc_56216_Enrolled_learner_finds_out_what_classroom_is_about()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC56216");
            AdminContentDetailsPage.CourseInformation.ClickEditButton();
            CourseInformationPage.CourseProvider.Select("Meridian");
            CourseInformationPage.EnterDuration("5");
            CourseInformationPage.clickSave();
            GeneralCoursePage.AddCreditType("5");
            int creditType = ContentDetailsPage.CreditTypeAccordian.CreditTypeNumber();
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionCode(SectionCode);
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");
    
            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            ManageClassroomCoursePage.ClickViewasLearner();

            Assert.IsTrue(ContentDetailsPage.isOverViewTabSelected());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDescriptionDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isCourseProviderDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDurationDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.CreditPortlet.isCreditScoreDisplay()== creditType);
        }
        [Test, Order(18)]
        public void tc_56233_Enrolled_learner_finds_out_what_classroom_is_about_Completed_course()
        {
            //use tc_56216 classroom and complete it from admin menu
            CommonSection.SearchCatalog(classroomcoursetitle + "_TC56216");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC56216");
            ContentDetailsPage.ScheduleTab_click();
            ContentDetailsPage.ScheduleTab.SectionPortlet.ClickEnrollButton();

            ContentDetailsPage.ClickEditContent_New19_2();
            ClassroomCourseDetailsPage.ClickSectionsTab();
            ManageClassroomCoursePage.Sectiontab.ClickManageEnrollment();
            Assert.IsTrue(ManageClassroomCoursePage.Enrollment());
            SectionDetailsPage.ClickGradebookTab();
            SectionDetailsPage.GradebookTab.CompleteSection();
            ManageClassroomCoursePage.ClickViewasLearner();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.iscompleteitemmessage() == "You completed this classroom");


        }
        [Test, Order(20)]
        public void tc_28078_Enrolled_User_enters_Completion_Code_for_Past_Sections()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC28078");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionEndDate(3);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button");
            SectionsPage.ClickSearchSection();
            _test.Log(Status.Info, "Click on Search Button in Sections Tab");

            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            EnrollmentPage.BatchEnrollmentModal.EnrollUser("Site Administrator");
            _test.Log(Status.Info, "Enroll Site Administratio");
            EnrollmentPage.ClickSectionDetailsTab();
            _test.Log(Status.Pass, "Click on Section Tab");

            SectionDetailsPage.SectionDetailsTab.CopyTheCompletionCode();
            _test.Log(Status.Info, "Obtain the Completion Code ");
            SectionDetailsPage.ClickViewAsLearner();
            _test.Log(Status.Info, "Click on View as learner");
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(Driver.comparePartialString("You completed TC28075Afreen : NewSection. This item has been added to your transcript.", ContentDetailsPage.GetCodeRelatedMessage()));
            _test.Log(Status.Pass, "Verify the information message is displayed");
            CommonSection.Dropdowntoggle.Transcript();
            _test.Log(Status.Info, "Click on Transcript");
            Assert.IsTrue(Driver.comparePartialString("Completed", TranscriptPage.VerifyStatus(classroomcoursetitle + "TC28078")));
            _test.Log(Status.Pass, "Verify Status as 'Çompleted'");
            TranscriptPage.ClickRequiredCourse("");
            _test.Log(Status.Info, "Click on Course title");
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(Driver.comparePartialString(" You have already completed this course section.", ContentDetailsPage.GetCodeRelatedMessage()));
            _test.Log(Status.Pass, "Verify the information message is displayed");

        }
        [Test, Order(21)]
        public void tc_28077_Enrolled_User_enters_Completion_Code_for_Current_Section_and_Future_sections()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC28077");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionEndDate(3);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button");
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            EnrollmentPage.BatchEnrollmentModal.EnrollUser("Site Administrator");
            _test.Log(Status.Info, "Enroll Site Administratio");
            EnrollmentPage.ClickSectionDetailsTab();
            _test.Log(Status.Pass, "Click on Section Tab");

            SectionDetailsPage.SectionDetailsTab.CopyTheCompletionCode();
            _test.Log(Status.Info, "Obtain the Completion Code ");
            SectionDetailsPage.ClickViewAsLearner();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isComplistioncodelinkdisplay());
            _test.Log(Status.Info, "Click on View as learner");
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.completioncodeModal.message() == "You can only enter a completion code for a course section that has ended.");
            _test.Log(Status.Pass, "Verify the information message is displayed");
            

            

        }
        [Test, Order(22)]
        public void tc_28075_Unenrolled_User_enters_Completion_Code_for_Past_Sections()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC28075");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));

            _test.Log(Status.Info, "Verify Success message is Displayed");

            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartDate(7);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionEndDate(3);
            _test.Log(Status.Info, "Select section start Date from calendar");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button");
            SectionsPage.ClickSearchSection();
            _test.Log(Status.Info, "Click on Search Button in Sections Tab");
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");

            EnrollmentPage.ClickSectionDetailsTab();
            _test.Log(Status.Pass, "Click on Section Tab");

            SectionDetailsPage.SectionDetailsTab.CopyTheCompletionCode();
            _test.Log(Status.Info, "Obtain the Completion Code ");

            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner's Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC28075");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC28075");

            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(Driver.comparePartialString("You completed Classroom_Test : NewSection. This item has been added to your transcript.", ContentDetailsPage.GetCodeRelatedMessage()));
            _test.Log(Status.Pass, "Verify the information message is displayed");
            CommonSection.Learn.Transcript();
            _test.Log(Status.Info, "Click on Transcript");
            Assert.IsTrue(Driver.comparePartialString("Completed", TranscriptPage.VerifyStatus(classroomcoursetitle + "TC28075")));
            _test.Log(Status.Pass, "Verify Status as 'Çompleted'");
            TranscriptPage.ClickRequiredCourse("");
            _test.Log(Status.Info, "Click on Course title");
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(Driver.comparePartialString(" You have already completed this course section.", ContentDetailsPage.GetCodeRelatedMessage()));
            _test.Log(Status.Pass, "Verify the information message is displayed");
        }
        [Test, Order(23)]
        public void tc_28074_Unenrolled_User_enters_Completion_Code_for_Current_Section_and_Future_sections()
        {
            /*
             *  driver.FindElement(By.LinkText("game 2")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [selectFrame | index=1 | ]]
            driver.FindElement(By.Id("MainContent_UC1_txtCompletionCode")).Click();
            driver.FindElement(By.Id("MainContent_UC1_txtCompletionCode")).Clear();
            driver.FindElement(By.Id("MainContent_UC1_txtCompletionCode")).SendKeys("C6439376D68F4F8");
            driver.FindElement(By.LinkText("Enter your code to receive credit.")).Click();
            Assert.AreEqual("C6439376D68F4F8", driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Completion Code'])[1]/following::dd[1]")).Text);
            driver.FindElement(By.Id("MainContent_UC1_btnComplete")).Click();
            Assert.AreEqual("You can only enter a completion code for a course section that has ended.", driver.FindElement(By.XPath("//div[@id='pnlContent']/div/div")).Text);
            driver.FindElement(By.Id("MainContent_UC1_btnCancel")).Click();
            */
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC28074");
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Info, "Verify Success message is Displayed");

            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add A New Section");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Fill title as Section1");
            ManageClassroomCoursePage.CreateSection.SectionStartDate(1);
            ManageClassroomCoursePage.CreateSection.SectionEndDate(-1);
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(6);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create Button");
            SectionsPage.ClickManageEnrollmentButton();
            _test.Log(Status.Info, "Click on Manage Enrollment");
            EnrollmentPage.ClickSectionDetailsTab();
            _test.Log(Status.Pass, "Click on Section Tab");
            SectionDetailsPage.SectionDetailsTab.CopyTheCompletionCode();
            _test.Log(Status.Info, "Obtain the Completion Code");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout of the Site Admin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner's Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC28074");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC28074");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isComplistioncodelinkdisplay());
            ContentDetailsPage.EnterYourCodeToReceiveCredit();
            _test.Log(Status.Info, "Enter Completion Code");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.completioncodeModal.message() == "You can only enter a completion code for a course section that has ended.");
            _test.Log(Status.Pass, "Verify the information message is displayed");

            

            

        }
        [Test, Order(24)]
        public void tc_27166_As_a_Learner_view_Equivalent_Items_to_an_Classroom_Course()
        {
            
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC27166");
            _test.Log(Status.Info, "A new Classroom Course Created");

            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            _test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
            Assert.IsTrue(EquivalenciesPage.AddEquvalenciesModal.VerifymodalComponets("Search", "ResultGrid", "InactiveCheckbox", "Cancel", "Add"));
            _test.Log(Status.Pass, "Verify componets on Modal");
            EquivalenciesPage.AddEquvalenciesModal.ClickSearch();
            _test.Log(Status.Info, "Performed a blank search");
            string EquivalencyName = EquivalenciesPage.AddEquvalenciesModal.FistrecordTitle();
            EquivalenciesPage.AddEquvalenciesModal.SelectandAddFirstrecord();
            _test.Log(Status.Info, "Select the first record and click add button");
            Assert.IsTrue(EquivalenciesPage.isEquivalenciesadded());
            _test.Log(Status.Pass, "Verify selected content added as Equivalencies");
            Assert.IsTrue(EquivalenciesPage.Resultgrid.isRelationship("2-way"));
            _test.Log(Status.Pass, "Verify added Equivalencies get 2-way relationship");
      
            CommonSection.SearchCatalog(classroomcoursetitle + "_TC27166");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "_TC27166");
            Assert.IsTrue(ContentDetailsPage.ReviewsTab.idEquvalenciesPortletDisplay());
        

    }
        [Test, Order(25)]
        public void tc_26966_View_Prerequisities_to_Classroom()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC26966");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC26966");
            _test.Log(Status.Info, "A new Classroom Course Created");
            AdminContentDetailsPage.AddContentToBundle(GeneralCourseTitle + "_TC26966");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.CreateSection.SectionCode(SectionCode);
            ManageClassroomCoursePage.SelectAddDayEventCheckbox();
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Start date to one day less from current date");

            ManageClassroomCoursePage.EnterMaximum("2");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            ManageClassroomCoursePage.ClickViewasLearner();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay()); //AC1
            Assert.IsFalse(ContentDetailsPage.ContentBanner.IsViewScheduleButtonDisplay());
            ContentDetailsPage.OverviewTab.Prerequisiteportlet.ClickRequestWaiverlink();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isRequestWaiverModalDisplay()); //AC2
            ContentDetailsPage.OverviewTab.RequestWaiverModal.Submitrequestwaiver();
            StringAssert.AreEqualIgnoringCase("Success\r\nSuccess Your waiver request was submitted. You will receive an email indicating whether you have received a waiver for the prerequisite(s).×", Driver.getSuccessMessage(), "Error message is different");

            ContentDetailsPage.OverviewTab.Prerequisiteportlet.ClickPrerequisiteContentTitle(GeneralCourseTitle + "_TC26966");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(GeneralCourseTitle + "_TC26966"));
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            _test.Log(Status.Info, "Complete General Course");
            CertificationDetailsPage.ClickBreadCrumb();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.iscomplted());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.IsViewScheduleButtonDisplay());
            TC56236_1 = true;
        }
        [Test, Order(17)]
        public void tc_56236_Learner_viewing_classroom_course_banner()
        {
            Assert.IsTrue(TC56236);
            Assert.IsTrue(TC56236_1);
        }

    }
}




