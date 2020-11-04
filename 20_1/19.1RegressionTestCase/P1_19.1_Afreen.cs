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
    //// [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
   // [Parallelizable(ParallelScope.Fixtures)]
    public class P1_19_1_Afreen : TestBase
    {
        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPath" + Meridian_Common.globalnum;
        string bundleTitle = "Bundle" + Meridian_Common.globalnum;
        string SubscriptionsTitle = "Subscription" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string CreditTypeTitle = "CT" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC" + Meridian_Common.globalnum;
        string Section = "Section" + Meridian_Common.globalnum;
        string SectionTitle = "Section_" + Meridian_Common.globalnum;
        string Test = "Test" + Meridian_Common.globalnum;
        bool res1 = false;
        bool ArchivedScale = false;
        string assignment = "Assignment" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        bool TC_35897 = false;
        bool TC_35898 = false;
        bool TC_35901 = false;
        bool TC_35899 = false;
        bool TC_35894 = false;
        string FirstDueDate = string.Empty;
        string OJT_Title = "OJT" + Meridian_Common.globalnum;

        public P1_19_1_Afreen(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

      
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
     
    

        [Test, Order(1)]
        public void A01_Restart_Non_Linear_Curriculum_35890()
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
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click on  Content Tab");
            //Assert.IsFalse(ContentDetailsPage.IsRestartCurriculumDisplayed());
            //_test.Log(Status.Pass, "Verify Restart Curriculum is Not Displayed");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890", "Not Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890ak", "Not Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");

            ContentDetailsPage.CurriculumContentTab.ClickStartGeneralCourse(generalcoursetitle + "TC35890");
            _test.Log(Status.Info, "Launch first General Course");
            ContentDetailsPage.MarkComplete_Curriculum();
            _test.Log(Status.Info, "Complete General Course");
            Assert.IsFalse(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");

            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click on  Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickStartGeneralCourse(generalcoursetitle + "TC35890ak");
            _test.Log(Status.Info, "Launch first General Course");
            ContentDetailsPage.MarkComplete_Curriculum();
            _test.Log(Status.Info, "Complete General Course");
            Assert.IsFalse(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890ak", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");

            Assert.IsTrue(ContentDetailsPage.IsRestartCurriculumDisplayed());
            _test.Log(Status.Pass, "Verify Restart Curriculum is Displayed");

            ContentDetailsPage.ClickRetakeCurriculum_DissmissAlert();
            _test.Log(Status.Pass, "Click restart Curriculum");
            ContentDetailsPage.ClickRetakeCurriculum_AcceptAlert();
            _test.Log(Status.Pass, "Click restart Curriculum");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click on  Content Tab");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890ak", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Pass, "Click History Tab");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyRestartedCurriculum());
            _test.Log(Status.Pass, "Verify in history tab Curriculum is restarted is mentioned");

        }

        [Test, Order(2)]
        public void A02_Restart_Linear_Curriculum_35888()
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
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click on  Content Tab");
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
            ContentDetailsPage.MarkComplete_Curriculum();
            _test.Log(Status.Info, "Complete General Course");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click on  Content Tab");
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
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click on  Content Tab");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35888", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35888ak", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Info, "Click History Tab");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyRestartedCurriculum());
            _test.Log(Status.Pass, "Verify in history tab Curriculum is restarted is mentioned");

        }

        [Test, Order(3)]
        public void A03_Restart_Non_Linear_Curriculum_Transcript__35889()
        {
            CommonSection.Learn.Transcript();
            _test.Log(Status.Pass, "Click transcript from Learn tab");
            TranscriptPage.AllTrainingTab.Filter("Curriculum", "Completed", 0, 0);
            _test.Log(Status.Pass, "Filter From all training List");
            TranscriptPage.AllTrainingTab.ClickContent(curriculamtitle + "TC35890");
            _test.Log(Status.Pass, "Click on the selected Content");
            Assert.IsTrue(ContentDetailsPage.IsRestartCurriculumDisplayed());
            _test.Log(Status.Pass, "Verify Restart Curriculum is Displayed");

            ContentDetailsPage.ClickRetakeCurriculum_DissmissAlert();
            _test.Log(Status.Pass, "Click restart Curriculum");
            ContentDetailsPage.ClickRetakeCurriculum_AcceptAlert();
            _test.Log(Status.Pass, "Click restart Curriculum");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890ak", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Pass, "Click History Tab");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyRestartedCurriculum());
            _test.Log(Status.Pass, "Verify in history tab Curriculum is restarted is mentioned");

        }

        [Test, Order(4)]
        public void A04_Restart_Linear_Curriculum_Transcript__35878()
        {
            CommonSection.Learn.Transcript();
            _test.Log(Status.Pass, "Click transcript from Learn tab");
            TranscriptPage.AllTrainingTab.Filter("Curriculum", "Completed", 0, 0);
            _test.Log(Status.Pass, "Filter From all training List");
            TranscriptPage.AllTrainingTab.ClickContent(curriculamtitle + "TC35888");
            _test.Log(Status.Pass, "Click on the selected Content");
            Assert.IsTrue(ContentDetailsPage.IsRestartCurriculumDisplayed());
            _test.Log(Status.Pass, "Verify Restart Curriculum is Displayed");

            ContentDetailsPage.ClickRetakeCurriculum_DissmissAlert();
            _test.Log(Status.Pass, "Click restart Curriculum");
            ContentDetailsPage.ClickRetakeCurriculum_AcceptAlert();
            _test.Log(Status.Pass, "Click restart Curriculum");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyStatus(generalcoursetitle + "TC35890ak", "Enrolled"));
            _test.Log(Status.Pass, "Verify Status of the content of content Block");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            _test.Log(Status.Pass, "Click History Tab");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyRestartedCurriculum());
            _test.Log(Status.Pass, "Verify in history tab Curriculum is restarted is mentioned");
        }

        [Test, Order(5)]
        public void P20_1_A05_View_Curriculum_after_previously_starting_and_not_completing_one_content_item_within_the_curriculum_35892()
        {
            #region
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35892");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Course");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit content");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkIn Button");
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35892ak");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Course");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit content");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkIn Button");
            #endregion
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35892");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35892");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            ContentDetailsPage.ClickCurriculumnEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click on  Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click on  Content Tab");
            ContentDetailsPage.MarkComplete_Curriculum();//Incomplete Course
            _test.Log(Status.Info, "Leave curriculum incomplete");


        }

        [Test, Order(6)]
        public void P20_1_A06_View_Curriculum_after_previously_starting_and_not_completing_multiple_content_item_within_the_curriculum__35893()
        {
            #region
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35893");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Course");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit content");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkIn Button");
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35893ak");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Course");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit content");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkIn Button");
            #endregion


            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35893");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35893");
            _test.Log(Status.Info, "Add training Activities");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35893ak");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            ContentDetailsPage.ClickCurriculumnEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click on  Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click on  Content Tab");
            ContentDetailsPage.MarkComplete_Curriculum();//Incomplete Course
            _test.Log(Status.Info, "Leave curriculum incomplete");
        }
        [Test, Order(7)]
        public void P20_1_A07_View_Curriculum_from_Transcript_after_previously_enrolling_starting_and_not_completing_an_OJT_within_the_curriculum_35903()
        {
            #region
            ClassroomCourse classroomcourse = new ClassroomCourse(driver);
            OJT onlinejobtraining = new OJT(driver);
            string expectedresult = " The item was created.";
            CommonSection.CreateLink.OJT();
            onlinejobtraining.populatesummaryojt(driver, ExtractDataExcel.MasterDic_ojt["Title"] + browserstr, ExtractDataExcel.MasterDic_ojt["Desc"], 9);
            GeneralCoursePage.SearchTagForNewContent(tagname);
            _test.Log(Status.Info, "Searching Tag.");
            string actres = onlinejobtraining.buttoncreateclick(driver);
            Assert.IsTrue(driver.Compareregexstring(expectedresult, actres));
            #endregion
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35903");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(ExtractDataExcel.MasterDic_ojt["Title"] + browserstr);
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            ContentDetailsPage.ClickCurriculumnEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click on  Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click on  Content Tab");
            ContentDetailsPage.MarkComplete_Curriculum();//Incomplete Course
            _test.Log(Status.Info, "Leave curriculum incomplete");



        }
        [Test, Order(8)]
        public void A08_View_Curriculum_from_Transcript_after_previously_starting_and_not_completing_a_survey_within_the_curriculum_35900()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35900");
            _test.Log(Status.Info, "Create A new Curriculum");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");
            Assert.IsTrue(SurveysPage.IsSurveyPageCompenetsarepresent("btn_AssignSurverbtn", "resultgrid"));
            _test.Log(Status.Info, "Verify Survey page has Assign Surveys button and result grid has no record");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            SurveysPage.AddSurveyModal.AddSurveystoContent();
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.Click_backbutton();
            Assert.IsTrue(ContentDetailsPage.Accordians.VerifySurveyPresnet(AddedsurveyTitle));
            _test.Log(Status.Pass, "Verify existing added survey is display");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Pass, "Click Check in Button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Pass, "View as Lerner");
            CommonSection.Learn.Transcript();
            _test.Log(Status.Pass, "View as Lerner");
            TranscriptPage.AllTrainingTab.Filter(curriculamtitle + "TC35900", "Started", 0, 0);
            _test.Log(Status.Pass, "Filter the Content");
            TranscriptPage.AllTrainingTab.ClickContent(curriculamtitle + "TC35900");
            _test.Log(Status.Pass, "Click Content");


        }

        [Test, Order(9)]
        public void A09_View_Curriculum_from_Transcript_after_previously_enrolling_starting_and_not_completing_a_container_within_the_curriculum_35902()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35902");
            _test.Log(Status.Info, "Create A new Curriculum");


            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(curriculamtitle + "TC35893");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            ContentDetailsPage.ClickCurriculumnEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Pass, "View as Lerner");
            CommonSection.Learn.Transcript();
            _test.Log(Status.Pass, "View as Lerner");
            TranscriptPage.AllTrainingTab.Filter(curriculamtitle + "TC35900", "Started", 0, 0);
            _test.Log(Status.Pass, "Filter the Content");
            TranscriptPage.AllTrainingTab.ClickContent(curriculamtitle + "TC35902");
            _test.Log(Status.Pass, "Click Content");
        }

        [Test, Order(10)]
        public void P20_1_A10_View_Curriculum_from_Transcript_after_previously_enrolling_starting_and_not_completing_an_OJT_within_the_curriculum_35897()
        {
            Assert.IsTrue(TC_35897); // This test case alredy covered into TC 35903
            _test.Log(Status.Info, "Assertion passed under the TC_35903");
        }

        [Test, Order(11)]
        public void P20_1_A11_View_Curriculum_from_Transcript_after_previously_enrolling_starting_and_not_completing_an_Classroom_within_the_curriculum_35895()
        {
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35895");
            _test.Log(Status.Info, "Create A new Classroom Course");
            ManageClassroomCoursePage.Clicktab("Sections");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "A new Section is Created");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35893");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(classroomcoursetitle + "TC35895");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as learner");
            ContentDetailsPage.ClickCurriculumnEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Pass, "View as Lerner");
            CommonSection.Learn.Transcript();
            _test.Log(Status.Pass, "View as Lerner");
            TranscriptPage.AllTrainingTab.Filter(curriculamtitle + "TC35900", "Started", 0, 0);
            _test.Log(Status.Pass, "Filter the Content");
            TranscriptPage.AllTrainingTab.ClickContent(curriculamtitle + "TC35902");
            _test.Log(Status.Pass, "Click Content");
        }
        [Test, Order(12)]
        public void A12_View_Curriculum_after_previously_enrolling_starting_and_not_completing_a_container_within_the_curriculum_35898()
        {
            Assert.IsTrue(TC_35898); // This test case alredy covered into TC 35903
            _test.Log(Status.Info, "Assertion passed under the TC_35902");
        }
        [Test, Order(13)]
        public void A13_View_Curriculum_from_Transcript_after_previously_enrolling_and_not_completing_a_classroom_course_within_the_curriculum_35901()
        {
            Assert.IsTrue(TC_35901); // This test case alredy covered into TC_35895
            _test.Log(Status.Info, "Assertion passed under the TC_35895");
        }


        [Test, Order(14)]
        public void A14_View_Curriculum_from_Transcript_after_previously_starting_and_not_completing_multiple_content_items_within_the_curriculum_35899()
        {
            Assert.IsTrue(TC_35899); // This test case alredy covered into TC_35893
            _test.Log(Status.Info, "Assertion passed under the TC_35893");
        }
        [Test, Order(15)]
        public void P20_1_A15_View_Curriculum_after_previously_starting_and_not_completing_a_survey_within_the_curriculum_35894()
        {
            Assert.IsTrue(TC_35894); // This test case alredy covered into TC_35900
            _test.Log(Status.Info, "Assertion passed under the TC_35900");
        }
        [Test, Order(16)]
        public void P20_1_A16_Choose_New_Locale_for_curriculum_35711()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35711");
            _test.Log(Status.Info, "Creating New Curriculumn");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Create");


            Assert.IsTrue(ContentDetailsPage.isDefultLocaledisplay());
            _test.Log(Status.Pass, "Verify Defult Locale display");

            ContentDetailsPage.AddLocale();
            _test.Log(Status.Info, "Added new locale to curriculumn");

            Assert.IsTrue(ContentDetailsPage.Localedropdownlistdisplay());
            _test.Log(Status.Pass, "Verify Locale dropdown display");



        }

        [Test, Order(17)]
        public void A17_Curriculum_Learner_checks_that_curriculum_is_included_in_other_containers_36446()
        {
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC36446");
            _test.Log(Status.Info, "Creating New Curriculumn");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click CheckIn Button");

            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create Bundle");
            BundlesPage.EnterTitle(bundleTitle + "TC36446");
            _test.Log(Status.Info, "Enter Title");
            BundlesPage.BundleType("Content Bundle");
            _test.Log(Status.Info, "select Bundle Type");
            BundlesPage.BundleCostType();
            _test.Log(Status.Info, "select bundle Cost Type");
            BundlesPage.ClickCreate();
            _test.Log(Status.Info, "Click Create");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Bundle");
            AdminContentDetailsPage.AddContentToBundle(curriculamtitle + "TC36446");
            _test.Log(Status.Info, "Add Content to to Bundle");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click CheckIn Button");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click View As Learner");
            Assert.IsTrue(ContentDetailsPage.IsCurriculumContentDisplayed(curriculamtitle + "TC36446"));
            _test.Log(Status.Pass, "Verify Curriculum Content Is Displayed");
            Assert.IsTrue(ContentDetailsPage.IsCostDisplayed());
            _test.Log(Status.Pass, "Verify Cost is Displayed");



            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create Bundle");
            CertificationPage.FillTitle(CertificatrTitle + "TC36446");
            _test.Log(Status.Info, "Fill Certification Title");
            CertificationPage.CreateCertification();
            _test.Log(Status.Info, "Click Create Certificate");
            AdminContentDetailsPage.EditAndAddCertificationContent(curriculamtitle + "TC36446");
            _test.Log(Status.Info, "Click Edit and Certification Content");
            ContentDetailsPage.ClickBrowserBackButton();
            _test.Log(Status.Info, "Click Browser Back Button");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Certification");
            AdminContentDetailsPage.ClickCheckInbutton();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click View As Learner");
            Assert.IsTrue(ContentDetailsPage.IsCurriculumContentDisplayed(curriculamtitle + "TC36446"));
            _test.Log(Status.Pass, "Verify Curriculum Content Is Displayed");
            Assert.IsTrue(ContentDetailsPage.IsCostDisplayed());
            _test.Log(Status.Pass, "Verify Cost is Displayed");


            CommonSection.CreateLink.Subscription();
            _test.Log(Status.Info, "Click create>Subscriptions");
            SubscriptionsPage.TitleAs(SubscriptionsTitle + "TC36446").SubscriptionType("Dynamic Date").Create();
            _test.Log(Status.Info, "Create a new Subscriptions");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to the Subscription");
            AdminContentDetailsPage.ClickEditandAddSubscriptionContent(curriculamtitle + "TC36446");
            _test.Log(Status.Info, "Click Edit and Add Subscription Content");
            _test.Log(Status.Info, "Add cost to Certification");
            AdminContentDetailsPage.ClickCheckInbutton();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click View As Learner");
            Assert.IsTrue(ContentDetailsPage.IsCurriculumContentDisplayed(curriculamtitle + "TC36446"));
            _test.Log(Status.Pass, "Verify Curriculum Content Is Displayed");
            Assert.IsTrue(ContentDetailsPage.IsCostDisplayed());
            _test.Log(Status.Pass, "Verify Cost is Displayed");
        }

        [Test, Order(18)]
        public void P20_1_A18_Curriculum_View_Training_assignment_information_on_Details_page_35714()
        {
            #region Training Assignment with NO Due date

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35714");
            _test.Log(Status.Info, "Creating New Curriculumn");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click CheckIn Button");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click on Training Assignment link");
            CreateTrainingAssignmentPage.Create(assignment + "TC35714");
            _test.Log(Status.Info, "Create Training assignment");

            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content in Training Assignment Page");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(curriculamtitle + "TC35714");
            _test.Log(Status.Info, "Add content to Training Assignment");

            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assigniees");

            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("ak learner");
            _test.Log(Status.Info, "Add content to Training Assignment");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click  Manage Training Assignments");

            TrainingAssignmentsPage.SearchTrainingAssignment(assignment + "TC35714");
            _test.Log(Status.Info, "Search Training Assignment");

            Assert.IsTrue(TrainingAssignmentsPage.VerifyDueDate_None("None"));
            _test.Log(Status.Pass, "Verify Due date is None");

            #endregion

            #region Training Assignment with 1 due date

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35714");
            _test.Log(Status.Info, "Creating New Curriculumn");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click CheckIn Button");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click on Training Assignment link");
            CreateTrainingAssignmentPage.Create(assignment + "TC35714");
            _test.Log(Status.Info, "Create Training assignment");

            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content in Training Assignment Page");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(curriculamtitle + "TC35714");
            _test.Log(Status.Info, "Add content to Training Assignment");

            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assigniees");

            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("ak learner");
            _test.Log(Status.Info, "Add Training assinment Assignee");

            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click change in Due date tab");
            CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetDueDateNonRecurring("Within days");
            _test.Log(Status.Info, "Set the Due date");
            FirstDueDate = CreateTrainingAssignmentPage.DueDateTab.First_DueDate();
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click  Manage Training Assignments");

            TrainingAssignmentsPage.SearchTrainingAssignment(assignment + "TC35714");
            _test.Log(Status.Info, "Search Training Assignment");
            Assert.IsTrue(TrainingAssignmentsPage.VerifyDueDate(FirstDueDate));
            _test.Log(Status.Info, "Verify single due date");


            #endregion

            #region Training Assignment with Multiple(reccurence) due date


            #region Create content to Add in Curriculum
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35893");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Course");
            CostPage.GoToGeneralCourseBreadCrumb();
            _test.Log(Status.Info, "Click on general Course Breadcrumb");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkIn Button");
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35893ak");
            _test.Log(Status.Info, "Create general Course");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Course");
            CostPage.GoToGeneralCourseBreadCrumb();
            _test.Log(Status.Info, "Click on general Course Breadcrumb");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click checkIn Button");
            #endregion


            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35893");
            _test.Log(Status.Info, "Create Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35893");
            _test.Log(Status.Info, "Add training Activities");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35893ak");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();



            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click on Training Assignment link");
            CreateTrainingAssignmentPage.Create(assignment + "TC35714");
            _test.Log(Status.Info, "Create Training assignment");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content in Training Assignment Page");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(curriculamtitle + "TC35714");
            _test.Log(Status.Info, "Add content to Training Assignment");
            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assigniees");
            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("ak learner");
            _test.Log(Status.Info, "Add Training assinment Assignee");
            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click change in Due date tab");
            CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetDueDateRecurring("Within days");
            _test.Log(Status.Info, "Set the Due date");
            FirstDueDate = CreateTrainingAssignmentPage.DueDateTab.First_DueDate();
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click  Manage Training Assignments");
            TrainingAssignmentsPage.SearchTrainingAssignment(assignment + "TC35714");
            _test.Log(Status.Info, "Search Training Assignment");
            Assert.IsTrue(TrainingAssignmentsPage.VerifyDueDate(FirstDueDate));
            _test.Log(Status.Info, "Verify single due date");
            #endregion

            #region Training Assignment with over due date


            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35714");
            _test.Log(Status.Info, "Creating New Curriculumn");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "click CheckIn Button");

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click on Training Assignment link");
            CreateTrainingAssignmentPage.Create(assignment + "TC35714");
            _test.Log(Status.Info, "Create Training assignment");

            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content in Training Assignment Page");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(curriculamtitle + "TC35714");
            _test.Log(Status.Info, "Add content to Training Assignment");

            CreateTrainingAssignmentPage.AssignessTab.ClickAddAssignees();
            _test.Log(Status.Info, "Click Add Assigniees");

            CreateTrainingAssignmentPage.AssignessTab.AddAssignessModal.AddAssigne("ak learner");
            _test.Log(Status.Info, "Add Training assinment Assignee");

            CreateTrainingAssignmentPage.DueDateTab.ClickChage();
            _test.Log(Status.Info, "Click change in Due date tab");
            CreateTrainingAssignmentPage.DueDateTab.AssignmentDueDateModal.SetDueDateNonRecurring("Within days");
            _test.Log(Status.Info, "Set the Due date");
            FirstDueDate = CreateTrainingAssignmentPage.DueDateTab.First_DueDate();
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Training Page");
            TrainingPage.TrainingAssignments.Click_ManageTrainingAssignments();
            _test.Log(Status.Info, "Click  Manage Training Assignments");

            TrainingAssignmentsPage.SearchTrainingAssignment(assignment + "TC35714");
            _test.Log(Status.Info, "Search Training Assignment");
            Assert.IsTrue(TrainingAssignmentsPage.VerifyDueDate(FirstDueDate));
            _test.Log(Status.Info, "Verify single due date");
            #endregion

        }

        [Test, Order(19)]
        public void A19_Curriculum_Learner_Retakes_test_36445()
        {
            #region User Completes test Outside Curriculum

            CommonSection.Administer.ContentManagement.CreateTest(Test + "TC36445");
            _test.Log(Status.Info, "Create a test");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC36445");
            _test.Log(Status.Info, "Creating New Curriculumn");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(Test + "TC36445");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            CommonSection.CatalogSearchText(Test + "TC36445");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(Test + "TC36445");
            _test.Log(Status.Info, "Click searched course Title");
            Assert.IsTrue(ContentDetailsPage.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "verify open Button is Displayed");

            ContentDetailsPage.ClickOpenItembutton();
            _test.Log(Status.Pass, "Click Open item button");

            ContentDetailsPage.CompleteTest("False");
            _test.Log(Status.Info, "Complete Test for first attempt");
            Assert.IsTrue(ContentDetailsPage.IsOpenCurrentAttemptDisplayed());
            _test.Log(Status.Pass, "verify Open Current Attempt is Displayed");
            Assert.IsTrue(ContentDetailsPage.IsOpenNewAttemptDisplayed());
            _test.Log(Status.Pass, "verify Open Current Attempt is Displayed");
            ContentDetailsPage.ClickOpenNewAttempt();
            _test.Log(Status.Pass, "Click Open New Attempt");
            ContentDetailsPage.CompleteTest("False");
            _test.Log(Status.Info, "Complete Test for last attempt");
            Assert.IsFalse(ContentDetailsPage.IsOpenCurrentAttemptDisplayed());
            _test.Log(Status.Pass, "verify Open Current Attempt is Displayed");
            Assert.IsFalse(ContentDetailsPage.IsOpenNewAttemptDisplayed());
            _test.Log(Status.Pass, "verify Open Current Attempt is Displayed");
            Assert.IsTrue(Driver.comparePartialString("Error You have already used all your available attempts for this test.", ContentDetailsPage.ExaustedAttemptsMessage()));
            _test.Log(Status.Pass, "Verify all attempts used message is Displayed");
            ContentDetailsPage.ClickViewAllAttempts();
            _test.Log(Status.Info, "Click View All Attempts");
            Assert.IsTrue(ContentDetailsPage.ViewAllAttemptsModal.VerifyAttempts());
            _test.Log(Status.Info, "Verify All attempts used");////////
            CommonSection.CatalogSearchText(curriculamtitle + "TC36445");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC36445");
            _test.Log(Status.Info, "Click searched course Title");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click on Content Tab");
            Assert.IsTrue(ContentDetailsPage.VerifyRetakeTest());
            _test.Log(Status.Pass, "Verify Retake button");

            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyRetakeTest());
            _test.Log(Status.Pass, "Verify Retake button");

            ContentDetailsPage.CurriculumContentTab.RetakeTest();
            _test.Log(Status.Info, "Click Retake test Button");
            ContentDetailsPage.CloseSCORMModal();
            _test.Log(Status.Info, "Close Scorm Modal");

            Assert.IsFalse(ContentDetailsPage.CurriculumContentTab.VerifyRetakeTest());
            _test.Log(Status.Pass, "Verify Retake button");
            Assert.IsFalse(ContentDetailsPage.VerifyRetakeTest());
            _test.Log(Status.Pass, "Verify Retake button");

            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyContinueButton());
            _test.Log(Status.Pass, "Verify Retake button");
            Assert.IsFalse(ContentDetailsPage.VerifyContinueButton());
            _test.Log(Status.Pass, "Verify Retake button");

            #endregion

            #region Learner Starts Test From Curriculum

            CommonSection.Administer.ContentManagement.CreateTest(Test + "TC36445");
            _test.Log(Status.Info, "Create a test");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC36445");
            _test.Log(Status.Info, "Creating New Curriculumn");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(Test + "TC36445");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check in Button");

            CommonSection.CatalogSearchText(curriculamtitle + "TC36445");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC36445");
            _test.Log(Status.Info, "Click searched course Title");

            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click Enroll Button");

            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyContinueButton());
            _test.Log(Status.Pass, "Verify Retake button");
            Assert.IsFalse(ContentDetailsPage.VerifyContinueButton());
            _test.Log(Status.Pass, "Verify Retake button");
            Assert.IsTrue(ContentDetailsPage.VerifyCancelEnrollmentButton_Curriculum());
            _test.Log(Status.Pass, "Verify Cancel Enrollment Button of Curriculum");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            Assert.IsTrue(ContentDetailsPage.CurriculumContentTab.VerifyContinueButton());
            _test.Log(Status.Pass, "Verify Retake button");
            ContentDetailsPage.CurriculumContentTab.Click_ContinueButton();
            _test.Log(Status.Pass, "Click Continue Button");

            ContentDetailsPage.CloseSCORMModal();
            _test.Log(Status.Info, "Close Scorm Modal");
            Assert.IsFalse(ContentDetailsPage.VerifyCancelEnrollmentButton_Curriculum());
            _test.Log(Status.Pass, "Verify Cancel Enrollment Button of Curriculum");

            #endregion


            #region Learner Previously Passed test on Curriculum


            CommonSection.Administer.ContentManagement.CreateTest(Test + "TC36445");
            _test.Log(Status.Info, "Create a test");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC36445");
            _test.Log(Status.Info, "Creating New Curriculumn");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(Test + "TC36445");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            CommonSection.CatalogSearchText(Test + "TC36445");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(Test + "TC36445");
            _test.Log(Status.Info, "Click searched course Title");
            Assert.IsTrue(ContentDetailsPage.isOpenItembuttonDisplay());
            _test.Log(Status.Pass, "verify open Button is Displayed");

            ContentDetailsPage.ClickOpenItembutton();
            _test.Log(Status.Pass, "Click Open item button");

            ContentDetailsPage.CompleteTest("False");
            _test.Log(Status.Info, "Complete Test for first attempt");
            Assert.IsTrue(ContentDetailsPage.IsOpenCurrentAttemptDisplayed());
            _test.Log(Status.Pass, "verify Open Current Attempt is Displayed");
            Assert.IsTrue(ContentDetailsPage.IsOpenNewAttemptDisplayed());
            _test.Log(Status.Pass, "verify Open Current Attempt is Displayed");
            ContentDetailsPage.ClickOpenNewAttempt();
            _test.Log(Status.Pass, "Click Open New Attempt");
            ContentDetailsPage.CompleteTest("True");
            _test.Log(Status.Info, "Complete Test for last attempt");
            Assert.IsFalse(ContentDetailsPage.IsOpenCurrentAttemptDisplayed());
            _test.Log(Status.Pass, "verify Open Current Attempt is Displayed");
            Assert.IsFalse(ContentDetailsPage.IsOpenNewAttemptDisplayed());
            _test.Log(Status.Pass, "verify Open Current Attempt is Displayed");
            Assert.IsTrue(Driver.comparePartialString("Error You have already used all your available attempts for this test.", ContentDetailsPage.ExaustedAttemptsMessage()));
            _test.Log(Status.Pass, "Verify all attempts used message is Displayed");
            ContentDetailsPage.ClickViewAllAttempts();
            _test.Log(Status.Info, "Click View All Attempts");
            Assert.IsTrue(ContentDetailsPage.ViewAllAttemptsModal.VerifyAttempts());
            _test.Log(Status.Info, "Verify All attempts used");
            CommonSection.CatalogSearchText(curriculamtitle + "TC36445");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC36445");
            _test.Log(Status.Info, "Click searched course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click Enroll Button");

            //Incomplete Needed verification as View Details Button Does Not Exist




            #endregion




        }

        [Test, Order(20)]
        public void A20_Curriculum_Learner_views_progress_towards_completeing_curriculum_for_Nested_content_35908()
        {
            #region Case1: Nested Curriculum


            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35908");
            _test.Log(Status.Info, "Create General Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click CheckIn Button");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC36445" + "Child");
            _test.Log(Status.Info, "Creating New Curriculumn");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(generalcoursetitle + "TC35908");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC36445" + "Parent");
            _test.Log(Status.Info, "Creating New Curriculumn");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(curriculamtitle + "TC36445" + "Child");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");

            CommonSection.CatalogSearchText(curriculamtitle + "TC36445" + "Parent");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC36445" + "Parent");
            _test.Log(Status.Info, "Click searched course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.Click_CurriculumContent();
            _test.Log(Status.Info, "Click Curriculum Content");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.Click_CurriculumContent();
            _test.Log(Status.Info, "Click Curriculum Content");
            ContentDetailsPage.CompleteLunchedCourse();
            _test.Log(Status.Info, "Complete Launched Course");
            CommonSection.CatalogSearchText(curriculamtitle + "TC36445" + "Parent");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC36445" + "Parent");
            _test.Log(Status.Info, "Click searched course Title");
            Assert.IsTrue(ContentDetailsPage.isStatusBarDisplayed());
            _test.Log(Status.Info, "Verify Status bar is Displayed");

            #endregion


            #region Case3: Nested Classroom

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC35908");
            _test.Log(Status.Info, "New Classroom Course Created");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click Add New Section Tab");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Date");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.Create();

            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35908" + "Child");
            _test.Log(Status.Info, "Creating New Curriculumn");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(classroomcoursetitle + "TC35908");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35908" + "Parent");
            _test.Log(Status.Info, "Creating New Curriculumn");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(curriculamtitle + "TC35908" + "Child");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            CommonSection.CatalogSearchText(curriculamtitle + "TC35908" + "Parent");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35908" + "Parent");
            _test.Log(Status.Info, "Click searched course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.Click_CurriculumContent();
            _test.Log(Status.Info, "Click Curriculum Content");
            ContentDetailsPage.CourseMaterials.ClickContentButton();
            _test.Log(Status.Info, "Click Content Button");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.Click_CurriculumContent();
            _test.Log(Status.Info, "Click Curriculum Content");
            ContentDetailsPage.CourseMaterials.ClickContentButton();
            _test.Log(Status.Info, "Click Content Button");

            CommonSection.Manage.People();
            _test.Log(Status.Info, "Click People from Manage");
            PeoplePage.Search_User("Siteadmin");
            _test.Log(Status.Info, "Search for Siteadmin");
            PeoplePage.viewTranscript();
            _test.Log(Status.Info, "View Transcript");
            TranscriptPage.AllTrainingTab.Filter("Instructor-Led", "Started", -1, 1);
            _test.Log(Status.Info, "Filter transcript From All training Tab");
            TranscriptPage.AllTrainingTab.Click_GO();
            _test.Log(Status.Info, "Click GO button");
            TranscriptPage.AllTrainingTab.MarkComplete_Transcript();
            _test.Log(Status.Info, "Click mark Complete");
            CommonSection.CatalogSearchText(curriculamtitle + "TC35908" + "Parent");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35908" + "Parent");
            _test.Log(Status.Info, "Click searched course Title");

            Assert.IsTrue(ContentDetailsPage.isStatusBarDisplayed());
            _test.Log(Status.Pass, "Verify Status bar is Displayed");
            #endregion

            #region Nested OJT

            CommonSection.CreateNewOJT(OJT_Title + "TC35908");
            _test.Log(Status.Info, "Click create OJT");
            AdminContentDetailsPage.Click_CreateAndManageChecklists();
            _test.Log(Status.Info, "Click Create and manage Checklist");
            ChecklistsPage.CreateAndManageCheckListTab.CreateNewCheckListInAnyOrder();
            _test.Log(Status.Info, "Create New CheckList In Any Order");
            ChecklistsPage.AddANewSection("");
            _test.Log(Status.Info, "Click on Add a new Section");
            ChecklistsPage.EditSection.CreateQuestion("Radio Button");
            _test.Log(Status.Info, "Create a question");
            ChecklistsPage.Publish();
            _test.Log(Status.Info, "Click Publish");
            ChecklistsPage.ClickBreadcrumb_Ckecklists();
            _test.Log(Status.Info, "Click Checklists In the breadcrumbs");
            ChecklistsPage.CreateAndManageCheckListTab.ManageEvaluator("Site Administrator");
            _test.Log(Status.Info, "Manage Evaluator");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35908" + "Child");
            _test.Log(Status.Info, "Creating New Curriculumn");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(OJT_Title + "TC35908");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            CommonSection.CreteNewCurriculumn(curriculamtitle + "TC35908" + "Parent");
            _test.Log(Status.Info, "Creating New Curriculumn");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            _test.Log(Status.Info, "Click Edit Content for Curriculum");
            ContentDetailsPage.ClickAddCurriculumBlock();
            _test.Log(Status.Info, "Click Curriculum content Block");
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs("ak_1");
            _test.Log(Status.Info, "Add Curriculum Block");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(curriculamtitle + "TC35908" + "Child");
            _test.Log(Status.Info, "Add training Activities");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check In button");
            CommonSection.CatalogSearchText(curriculamtitle + "TC35908" + "Parent");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35908" + "Parent");
            _test.Log(Status.Info, "Click searched course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.Click_CurriculumContent();
            _test.Log(Status.Info, "Click Curriculum Content");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click Enroll Button");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.Click_CurriculumContent();
            _test.Log(Status.Info, "Click Curriculum Content");
            ContentDetailsPage.Click_ContentTab();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.ClickCurriculumContentBlock();
            _test.Log(Status.Info, "Click Content Tab");
            ContentDetailsPage.CurriculumContentTab.Click_CurriculumContent();
            _test.Log(Status.Info, "Click Curriculum Content");
            ContentDetailsPage.CourseMaterials.ClickContentButton();
            _test.Log(Status.Info, "Click Content Button");
            CommonSection.Manage.People();
            _test.Log(Status.Info, "Click People from Manage");
            PeoplePage.Search_User("Siteadmin");
            _test.Log(Status.Info, "Search for Siteadmin");
            PeoplePage.viewTranscript();
            _test.Log(Status.Info, "View Transcript");
            TranscriptPage.AllTrainingTab.Filter("On-the-Job Training", "Started", 0, 0);
            _test.Log(Status.Info, "Filter transcript From All training Tab");
            TranscriptPage.AllTrainingTab.Click_GO();
            _test.Log(Status.Info, "Click GO button");
            TranscriptPage.AllTrainingTab.MarkComplete_Transcript();
            _test.Log(Status.Info, "Click mark Complete");
            CommonSection.CatalogSearchText(curriculamtitle + "TC35908" + "Parent");
            _test.Log(Status.Info, "Search for test from catalog");
            SearchResultsPage.ClickCourseTitle(curriculamtitle + "TC35908" + "Parent");
            _test.Log(Status.Info, "Click searched course Title");
            Assert.IsTrue(ContentDetailsPage.isStatusBarDisplayed());
            _test.Log(Status.Pass, "Verify Status bar is Displayed");
            #endregion
        }

        [Test, Order(21)]
        public void P20_1_A21_Learner_filters_information_on_compliance_dashboard_by_content_item_35904()
        {
            CommonSection.Avatar.Reports();
            _test.Log(Status.Info, "Navigate to My Reports Page");
            ReportsPage.ComplianceDashboard();
            _test.Log(Status.Info, "Open Compliance Dashboard Page");

            ComplianceDashboardPage.ApplyContentFilter("GC2611434343anybrowserCTs");
            _test.Log(Status.Info, "Search For Content and Apply Content Filter");
            Assert.IsTrue(ComplianceDashboardPage.VerifySelectedContent("GC2611434343anybrowserCTs"));
            _test.Log(Status.Info, "Verify selected Content");
            ComplianceDashboardPage.Click_RemoveContentFromContentFilter();
            _test.Log(Status.Info, "Click remove Button Content");
            Assert.IsFalse(ComplianceDashboardPage.VerifyRemovedContent());
            _test.Log(Status.Info, "Verify Removed Content remove Button Content");
            Assert.IsTrue(ComplianceDashboardPage.VerifySelectAll());
            _test.Log(Status.Info, "Verify Select All Button");


            #region Checked Out Content

            //Data Dependency
            
            
            #endregion

        }


    }            


}







