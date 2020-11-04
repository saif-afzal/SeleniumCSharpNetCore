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
    //   [Parallelizable(ParallelScope.Fixtures)]
    public class P1_CurriculumContentDetailsUsabilityImprovementsTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_CurriculumContentDetailsUsabilityImprovementsTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string documenttitle = "Document" + Meridian_Common.globalnum;
        string scormtitle = "SCROM" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        bool TC24948, TC56142;


        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }


        //Start writing your test here
        [Test, Order(1)]
        public void a04_User_can_jump_to_curriculum_content_from_banner_messaging_56247()
        {
            CommonSection.Administer.System.DomainsandURLS.Domains();
            DomainsPage.ClickDomainLink("Meridian Global");
            EditSummaryPage.ClickOptionsTab();
            EditSummaryPage.OptionsTab.AutomaticCurriculumnEnrolment("On");

            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC56247");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            #region Create a curriculum
            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC56247");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered" + "_TC56247");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(GeneralCourseTitle + "_TC56247");

            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.SearchCatalog(curriculamtitle + "_TC56247");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC56247");
            _test.Log(Status.Info, "Click on search result from catalog");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.iscompleteitemmessage("Complete 1 required item(s)"));  //AC2
            CommonSection.Administer.System.DomainsandURLS.Domains();
            DomainsPage.ClickDomainLink("Meridian Global");
            EditSummaryPage.ClickOptionsTab();
            EditSummaryPage.OptionsTab.AutomaticCurriculumnEnrolment("Off");

        }
        [Test, Order(2)]
        public void a01_User_views_access_period_limitations_after_enrolling_in_a_curriculum_52344()
        {
            #region Create a general course
            CommonSection.CreateLink.GeneralCourse();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC51560");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            #region Create a curriculum
            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC51560");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered" + "_TC51560");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(GeneralCourseTitle + "_TC51560");
            CurriculumContentPage.ClickBackbutton();
            ContentDetailsPage.Edit_AddAccessPeriod("1");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.SearchCatalog(curriculamtitle + "_TC51560");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC51560");
            _test.Log(Status.Info, "Click on search result from catalog");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.AccessPeriodtext("Access ends 1 day(s) after enrollment"));
            ContentDetailsPage.EnrollinCurriculum();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.AccessPeriodtext("Your access to this content item ends"));
            _test.Log(Status.Pass, "Verify Access end date message display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancelEnrollmentLinkDisplay());
            TC24948 = true;


        }

        //[Test, Order(2)]
        //public void a02_User_views_curriculum_gamification_points_52343()
        //{
        //    CommonSection.SearchCatalog(curriculamtitle + "_TC51560");
        //    _test.Log(Status.Info, "Enter curriculum title in global search box");
        //    SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC51650");
        //    _test.Log(Status.Info, "Click on search result from catalog");

        //}
        [Test, Order(3)]
        public void a03_Enroll_in_Curriculum_24948()
        {
            Assert.IsTrue(TC24948);
        }
        
        [Test, Order(5)]
        public void a05_User_views_duration_for_content_items_within_curriculum_blocks_56337()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC56337");
            ContentDetailsPage.Click_EditCourseInformation();
            CourseInformationPage.CourseProvider.Select("Meridian");
            CourseInformationPage.EnterDuration("10");
            CourseInformationPage.clickSave();
            DocumentPage.ClickButton_CheckIn();
            #endregion
            #region Create a curriculum
            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC56337");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered" + "_TC56337");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(GeneralCourseTitle + "_TC56337");

            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.SearchCatalog(curriculamtitle + "_TC56337");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC56337");
            _test.Log(Status.Info, "Click on search result from catalog");
            ContentDetailsPage.EnrollinCurriculum();
            ContentDetailsPage.Click_ContentTab();
            //ContentDetailsPage.ContentTab.ExpandCurriculumBlock();
            Assert.IsTrue(ContentDetailsPage.ContentTab.isContentDurationdisplay(GeneralCourseTitle + "_TC56337", "10"));

        }

        [Test, Order(6)]
        public void a06_Restart_Non_Linear_Curriculum_35890()
        {
            #region
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35890");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Course");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit content");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Access Approval Edit Button");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign Approver path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkIn Button");
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35890ak");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Course");
            //CostPage.ClickReturn();
            //CostPage.GoToGeneralCourseBreadCrumb();
            //_test.Log(Status.Info, "Click on general Course Breadcrumb");
            ContentDetailsPage.ClickEditContent();
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Access Approval Edit Button");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign Approver path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkIn Button");
            #endregion
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35890");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35890");
            _test.Log(Status.Info, "Add training Activities");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35890ak");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            ContentDetailsPage.ClickCurriculumnEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click on  Content Tab");
            //ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            //_test.Log(Status.Info, "Click on  Content Tab");
            //Assert.IsFalse(ContentDetailsPage.IsRestartCurriculumDisplayed());
            //_test.Log(Status.Pass, "Verify Restart Curriculum is Not Displayed");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890", "Not Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890ak", "Not Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");

            ContentDetailsPage.CurriculumContentTab.ClickStartGeneralCourse(generalcoursetitle + "TC35890");
            _test.Log(Status.Info, "Launch first General Course");
            ContentDetailsPage.CompleteCurriculumnContent();  //in case of multiple content
            //ContentDetailsPage.MarkComplete_Curriculum();
            //_test.Log(Status.Info, "Complete General Course");
            //Assert.IsFalse(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890", "Enrolled"));
            //_test.Log(Status.Pass, "Verify Status of the content of content Block");

            //ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            //_test.Log(Status.Info, "Click on  Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickStartGeneralCourse(generalcoursetitle + "TC35890ak");
            _test.Log(Status.Info, "Launch first General Course");
            ContentDetailsPage.MarkComplete_Curriculum();
            _test.Log(Status.Info, "Complete General Course");
            //Assert.IsFalse(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890ak", "Enrolled"));
            //_test.Log(Status.Pass, "Verify Status of the content of content Block");

            Assert.IsTrue(ContentDetailsPage.IsRestartCurriculumDisplayed());
            _test.Log(Status.Pass, "Verify Restart Curriculum is Displayed");

            ContentDetailsPage.ClickRetakeCurriculum_DissmissAlert();
            _test.Log(Status.Pass, "Click restart Curriculum");
            ContentDetailsPage.ClickRetakeCurriculum_AcceptAlert();
            _test.Log(Status.Pass, "Click restart Curriculum");
            //ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            //_test.Log(Status.Info, "Click on  Content Tab");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890ak", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Pass, "Click History Tab");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyRestartedCurriculum());
            _test.Log(Status.Pass, "Verify in history tab Curriculum is restarted is mentioned");

        }

        [Test, Order(7)]
        public void a07_Restart_Linear_Curriculum_35888()
        {
            #region
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35888");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Course");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit content");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Access Approval Edit Button");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign Approver path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkIn Button");
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35888ak");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Course");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit content");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Access Approval Edit Button");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign Approver path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkIn Button");
            #endregion

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35888");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");

            CurriculumContentPage.AddCurriculumBlock.AddBlockAs_OrderedType("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");

            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35888");
            _test.Log(Status.Info, "Add training Activities");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35888ak");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            ContentDetailsPage.ClickCurriculumnEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click on  Content Tab");
            //ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            //_test.Log(Status.Info, "Click on  Content Tab");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35888", "Not Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35888ak", "Not Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStartButtonDisplayed(generalcoursetitle + "TC35888"));
            _test.Log(Status.Pass, "Verify Start button is Displayed");
            Assert.IsFalse(ContentDetailsPage.CurriculumContentTab.VerifyStartButtonDisplayed(generalcoursetitle + "TC35888ak"));
            _test.Log(Status.Pass, "Verify Start button is Not Displayed");


            ContentDetailsPage.CurriculumContentTab.ClickStartGeneralCourse(generalcoursetitle + "TC35888");
            _test.Log(Status.Info, "Launch first General Course");
            ContentDetailsPage.CompleteCurriculumnContent();
            _test.Log(Status.Info, "Complete General Course");
            // ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            //_test.Log(Status.Info, "Click on  Content Tab");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35888", "Completed"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStartButtonDisplayed(generalcoursetitle + "TC35888ak"));
            _test.Log(Status.Pass, "Verify Start button is Not Displayed");

            //ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            //_test.Log(Status.Info, "Click on  Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickStartGeneralCourse(generalcoursetitle + "TC35888ak");
            _test.Log(Status.Info, "Launch first General Course");
            ContentDetailsPage.MarkComplete_Curriculum();
            _test.Log(Status.Info, "Complete General Course");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click on  Content Tab");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35888ak", "Completed"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");

            Assert.IsTrue(ContentDetailsPage.IsRestartCurriculumDisplayed());
            _test.Log(Status.Pass, "Verify Restart Curriculum is Displayed");

            ContentDetailsPage.ClickRetakeCurriculum_DissmissAlert();
            _test.Log(Status.Pass, "Click restart Curriculum");
            ContentDetailsPage.ClickRetakeCurriculum_AcceptAlert();
            _test.Log(Status.Pass, "Click restart Curriculum");
            //ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            // _test.Log(Status.Info, "Click on  Content Tab");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35888", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35888ak", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Info, "Click History Tab");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyRestartedCurriculum());
            _test.Log(Status.Pass, "Verify in history tab Curriculum is restarted is mentioned");

        }

        [Test, Order(8)]
        public void a08_Restart_Non_Linear_Curriculum_Transcript__35889()
        {
            CommonSection.Learn.Transcript();
            _test.Log(Status.Pass, "Click transcript from Learn tab");
            TranscriptPage.ClickCurriculumsTab();
            TranscriptPage.CurriculumTab.ClickEnrollmentDate();
            TranscriptPage.CurriculumTab.ClickEnrollmentDate();
            //TranscriptPage.AllTrainingTab.Filter("Curriculum", "Completed", 0, 0);
            // _test.Log(Status.Pass, "Filter From all training List");
            TranscriptPage.AllTrainingTab.ClickContent(curriculamtitle + "TC35890");
            _test.Log(Status.Pass, "Click on the selected Content");
            //Assert.IsTrue(ContentDetailsPage.IsRestartCurriculumDisplayed());
            //_test.Log(Status.Pass, "Verify Restart Curriculum is Displayed");

            //ContentDetailsPage.ClickRetakeCurriculum_DissmissAlert();
            //_test.Log(Status.Pass, "Click restart Curriculum");
            //ContentDetailsPage.ClickRetakeCurriculum_AcceptAlert();
            //_test.Log(Status.Pass, "Click restart Curriculum");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890ak", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Pass, "Click History Tab");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyRestartedCurriculum());
            _test.Log(Status.Pass, "Verify in history tab Curriculum is restarted is mentioned");

        }

        [Test, Order(9)]
        public void a09_Restart_Linear_Curriculum_Transcript__35878()
        {
            CommonSection.Learn.Transcript();
            _test.Log(Status.Pass, "Click transcript from Learn tab");
            TranscriptPage.ClickCurriculumsTab();
            TranscriptPage.CurriculumTab.ClickEnrollmentDate();
            TranscriptPage.CurriculumTab.ClickEnrollmentDate();
            TranscriptPage.AllTrainingTab.ClickContent(curriculamtitle + "TC35888");
            _test.Log(Status.Pass, "Click on the selected Content");
            //  Assert.IsTrue(ContentDetailsPage.IsRestartCurriculumDisplayed());
            // _test.Log(Status.Pass, "Verify Restart Curriculum is Displayed");

            // ContentDetailsPage.ClickRetakeCurriculum_DissmissAlert();
            //  _test.Log(Status.Pass, "Click restart Curriculum");
            // ContentDetailsPage.ClickRetakeCurriculum_AcceptAlert();
            // _test.Log(Status.Pass, "Click restart Curriculum");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890ak", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Pass, "Click History Tab");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyRestartedCurriculum());
            _test.Log(Status.Pass, "Verify in history tab Curriculum is restarted is mentioned");
        }
        [Test, Order(10)]
        public void P20_1_a10_Curriculum_Leamer_Navigates_to_Content_Details_Page_Via_Transcript_57860()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.Learn.Transcript();
            TranscriptPage.ClickCurriculumsTab();
            TranscriptPage.CurriculumTab.ClickCurriculumtitle("test_curri_3005");
            Assert.IsTrue(ContentDetailsPage.isContentTabSelected());
        }
        [Test, Order(11)]
        public void P20_1_tc_57849_Curriculum__User_navigates_to_Content_Details_page_of_General_Course()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC57849");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC57849");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");

            CurriculumContentPage.AddCurriculumBlock.AddBlockAs_OrderedType("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");

            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC57849");
            _test.Log(Status.Info, "Add training Activities");

            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            ContentDetailsPage.EnrollinCurriculum();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CurriculumBlock.iscontentdisplay(generalcoursetitle + "TC57849"));
            ContentDetailsPage.ContentTab.CurriculumBlock.ClickContenttitle(generalcoursetitle + "TC57849");



        }
        [Test, Order(12)]
        public void P20_1_tc_57847_Curriculum__User_navigates_to_Content_Details_page_of_Classroom()
        {
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Naviagte to Cretae Classroom Course page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "_TC57847");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC57847");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");

            CurriculumContentPage.AddCurriculumBlock.AddBlockAs_OrderedType("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");

            CurriculumContentPage.AddTrainingActivities_UnOrdered(classroomcoursetitle + "_TC57847");
            _test.Log(Status.Info, "Add training Activities");

            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            ContentDetailsPage.EnrollinCurriculum();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CurriculumBlock.iscontentdisplay(classroomcoursetitle + "_TC57847"));
            ContentDetailsPage.ContentTab.CurriculumBlock.ClickContenttitle(classroomcoursetitle + "_TC57847");
            Assert.IsTrue(Driver.Instance.Url.Contains("contentdetails"));
            ContentDetailsPage.ClickBreadCrumb(curriculamtitle + "TC57847");            
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(curriculamtitle + "TC57847"));
        }

        [Test, Order(15)]
        public void P20_1_tc_57848_Curriculum__User_navigates_to_content_Details_page_of_a_Document()
        {
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Naviagte to Cretae Document page");
            CommonSection.CreteNewDocuemnt(documenttitle + "TC57848");
            _test.Log(Status.Info, "A new Document Created");
            ContentDetailsPage.Click_Check_in();

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC57848");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");

            CurriculumContentPage.AddCurriculumBlock.AddBlockAs_OrderedType("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");

            CurriculumContentPage.AddTrainingActivities_UnOrdered(documenttitle + "TC57848");
            _test.Log(Status.Info, "Add training Activities");

            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            ContentDetailsPage.EnrollinCurriculum();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CurriculumBlock.iscontentdisplay(documenttitle + "TC57848"));
            ContentDetailsPage.ContentTab.CurriculumBlock.ClickContenttitle(documenttitle + "TC57848");
            Assert.IsTrue(Driver.Instance.Url.Contains("contentdetails"));
            ContentDetailsPage.ClickBreadCrumb(curriculamtitle + "TC57848");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(curriculamtitle + "TC57848"));

        }
        [Test, Order(16)]
        public void P20_1_tc_57850_Curriculum__User_access_Content_Details_page_of_SCORM_from_Curriculum()
        {
            CommonSection.CreateLink.SCORM();
            Uploadscromecourse.uploadfile();
            CretaeSCROM2004Page.Tile(scormtitle + "TC57850");
            CretaeSCROM2004Page.clickSaveButton();
            _test.Log(Status.Info, "A new SCROM Course Created");
            ContentDetailsPage.Click_Check_in();

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC57850");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");

            CurriculumContentPage.AddCurriculumBlock.AddBlockAs_OrderedType("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");

            CurriculumContentPage.AddTrainingActivities_UnOrdered(scormtitle + "TC57850");
            _test.Log(Status.Info, "Add training Activities");

            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isInstructionalMessage("Enroll in the Curriculum to get started"));
            TC56142 = true;
            ContentDetailsPage.EnrollinCurriculum();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CurriculumBlock.iscontentdisplay(scormtitle + "TC57850"));
            ContentDetailsPage.ContentTab.CurriculumBlock.ClickContenttitle(scormtitle + "TC57850");
            Assert.IsTrue(Driver.Instance.Url.Contains("contentdetails"));
            ContentDetailsPage.ClickBreadCrumb(curriculamtitle + "TC57850");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(curriculamtitle + "TC57850"));

        }
        [Test, Order(17)]
        public void tc_56142_User_Views_Instructional_text_in_Enroll_button_for_Curriculum()
        {
            Assert.IsTrue(TC56142);

        }
        [Test, Order(18)]
        public void tc_35907_Curriculum__Learner_views_progress_towards_completeing_curriculum_for_each_block_type()
        {
            #region create 4 general course
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35907_od_1");
            _test.Log(Status.Info, "Create general Course");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35907_od_2");
            _test.Log(Status.Info, "Create general Course");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35907_Uod_1");
            _test.Log(Status.Info, "Create general Course");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35907_Uod_2");
            _test.Log(Status.Info, "Create general Course");
            DocumentPage.ClickButton_CheckIn();
            #endregion

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35907");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("UnOrdered");
            _test.Log(Status.Info, "Add Curriculum UnOrdered Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35907_Uod_1");
            _test.Log(Status.Info, "Add training Activities");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35907_Uod_2");
            _test.Log(Status.Info, "Add training Activities");

            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs_OrderedType("Ordered");
            _test.Log(Status.Info, "Add Curriculum Ordered Block");
            CurriculumContentPage.AddTrainingActivities_Ordered(generalcoursetitle + "TC35907_od_1");
            _test.Log(Status.Info, "Add training Activities");
            CurriculumContentPage.AddTrainingActivities_Ordered(generalcoursetitle + "TC35907_od_2");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(curriculamtitle + "TC35907");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35907");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(curriculamtitle + "TC35907"));
            _test.Log(Status.Pass, "Verify Content details page is opend");
            ContentDetailsPage.ClickCurriculumnEnroll();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContentProgress() == "0%");
            _test.Log(Status.Pass, "Verify Curriculum progress is 0%");
            Assert.IsTrue(ContentDetailsPage.ContentTab.CurriculumUnOrderedBlock.BannerCompletionText("Complete 2 in any order"));
            ContentDetailsPage.CurriculumContentTab.ClickStartGeneralCourse(generalcoursetitle + "TC35907_Uod_1");
            _test.Log(Status.Info, "Launch first General Course");
            ContentDetailsPage.CompleteCurriculumnContent();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CurriculumUnOrderedBlock.BannerCompletionContentCount("1 / 2"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContentProgress() == "25%");
            _test.Log(Status.Pass, "Verify Curriculum progress is 25%");

            Assert.IsTrue(ContentDetailsPage.ContentTab.CurriculumOrderedBlock.BannerCompletionText("Complete 2 in any order"));
            ContentDetailsPage.CurriculumContentTab.ClickStartGeneralCourse(generalcoursetitle + "TC35907_od_1");
            _test.Log(Status.Info, "Launch first General Course");
            ContentDetailsPage.CompleteCurriculumnContent();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CurriculumOrderedBlock.BannerCompletionContentCount("1 / 2"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContentProgress() == "50%");
            _test.Log(Status.Pass, "Verify Curriculum progress is 50%");

        }
        [Test, Order(19)]
        public void tc_52418_Curriculums_Panel_Prerequisite_for_these_Items()
        {

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC52418_Child");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.Click_Check_in();

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC52418_Parent");
            _test.Log(Status.Info, "Create Curriculum");
            AdminContentDetailsPage.AddPrequisites(curriculamtitle + "TC52418_Child");
            ContentDetailsPage.Click_Check_in();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isContentdisplay(curriculamtitle + "TC52418_Child"));
            ContentDetailsPage.OverviewTab.Prerequisiteportlet.ClickPrerequisiteContentTitle(curriculamtitle + "TC52418_Child");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(curriculamtitle + "TC52418_Child"));
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitefortheseitems());
            ContentDetailsPage.OverviewTab.clickToexpandPrerequisitefortheseitems();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisitefortheseitems.isContentdisplay(curriculamtitle + "TC52418_Parent"));

        }

        [Test, Order(20)]
        public void tc_56143_User_Views_pre_requisite_requirements_in_banner_Pre_requisite_Not_Completed()
        {
            CommonSection.SearchCatalog(curriculamtitle + "TC52418_Parent");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC52418_Parent");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isContentdisplay(curriculamtitle + "TC52418_Child"));
            Assert.IsFalse(ContentDetailsPage.isEnrollButtonDisplay());
            _test.Log(Status.Pass, "Verify No Enroll button is display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to enroll"));

        }
        [Test, Order(21)]
        public void tc_56144_User_Views_pre_requisite_requirements_in_banner_Pre_requisite_Completed()
        {
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC56144");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC56144");
            _test.Log(Status.Info, "Create Curriculum");
            AdminContentDetailsPage.AddPrequisites(generalcoursetitle + "TC56144");
            ContentDetailsPage.Click_Check_in();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isContentdisplay(curriculamtitle + "TC52418_Child"));
            Assert.IsFalse(ContentDetailsPage.isEnrollButtonDisplay());
            _test.Log(Status.Pass, "Verify No Enroll button is display on banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to enroll"));
            ContentDetailsPage.OverviewTab.Prerequisiteportlet.ClickPrerequisiteContentTitle(generalcoursetitle + "TC56144");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(generalcoursetitle + "TC56144"));
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            ContentDetailsPage.ClickBreadCrumb(curriculamtitle + "TC56144");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(curriculamtitle + "TC56144"));
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to enroll"));
            Assert.IsTrue(ContentDetailsPage.isEnrollButtonDisplay());
        }
        [Test, Order(22)]
        public void P20_1_tc_56398_User_Views_Access_Key_usage_info_when_enrolling_in_curriculum()
        {

            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC56398");
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            DocumentPage.ClickButton_CheckIn();
            #endregion
            #region Create a curriculum
            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC56398");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered" + "_TC56398");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(GeneralCourseTitle + "_TC56398");
            CurriculumContentPage.ClickBackbutton();
            ContentDetailsPage.Accordians.ClickEdit_CostNSalesTax();
            CostPage.DefaultCostAs("5").Save();
            CostPage.ClickReturn();
            ContentDetailsPage.Accordians.ClickEdit_AccessKey();
            AccessKeysPage.EnableAccessKey("Yes").Save();
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.SearchCatalog(curriculamtitle + "_TC51560");
            _test.Log(Status.Info, "Enter curriculum title in global search box");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "_TC51560");
            _test.Log(Status.Info, "Click on search result from catalog");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            ContentDetailsPage.OverviewTab.click_AddtoCart();

            CommonSection.Completepurchage(curriculamtitle + "_TC51560");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.isContentTabSelected());
            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyEnrolledinSectionwithAccessKey());
        }
        //[Test, Order(14)]
        //public void tc_57858_Bundles__Verify_Specific_content_can_be_Mark_Complete_once_content_is_started__Curriculum()
        //{


        //}

    }


}


