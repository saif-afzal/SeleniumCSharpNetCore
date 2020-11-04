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
   // [Parallelizable(ParallelScope.Fixtures)]
    public class P1_Catalog_TestsContentDetailsPagesTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_TestsContentDetailsPagesTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string AICCCourseTitle = "AICC" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string TestTitle = "Test" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle= "TA" + Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        bool tc25132, TC25153;
        bool TC26286, TC26287;
        bool TC60280, TC25152;
        bool TC26291;
        bool TC26378;

        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }


        
        [Test, Order(1)]
        public void tc_60287_Tests_Banner_Actions_View_History_for_requesting_access()
        {
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle);
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.setApprovalPath();
            TestwizardPage.checkin();
            CommonSection.SearchCatalog(TestTitle);
            SearchResultsPage.ClickCourseTitle(TestTitle);
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display on Banner");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            ContentDetailsPage.ContentBanner.ClickViewRequestHistory();
            Assert.IsTrue(ContentDetailsPage.isHistorywindowopened());
            
            Assert.IsTrue(ContentDetailsPage.Historywin.isfieldsdisplay(TestTitle, "Content type", "status"));
            Driver.Instance.SelectWindowClose2("History", Meridian_Common.parentwdw);
            ContentDetailsPage.AccessApprovalModal.SubmitCancelRequestAccess("ForTest");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Info, "Verify Cancel Request access wotk flow");
            TC26286 = true;
            TC26287 = true;



        }
        [Test, Order(2)]
        public void P20_1_tc_26286_Request_Access_to_Test()
        {
            Assert.IsTrue(TC26286);

        }
        [Test, Order(3)]
        public void P20_1_tc_26287_Cancel_Access_Request_to_Test()
        {
            Assert.IsTrue(TC26287);
        }
        [Test, Order(4)]
        public void P20_1_tc_26973_View_Prerequisities_to_Test()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC26973");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle+"_tc26973");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.addPrerequisitetotest(GeneralCourseTitle + "TC26973");
            TestwizardPage.checkin();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner105").WithPassword("").Login();
            CommonSection.SearchCatalog(TestTitle+ "_tc26973");
            SearchResultsPage.ClickCourseTitle(TestTitle+ "_tc26973");
           
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify  information");
            tc25132 = true;

        }
        [Test, Order(5)]
        public void tc_25132_Published_Test_Prerequisites()
        {
            Assert.IsTrue(tc25132);
        }
        [Test, Order(6)]
        public void P20_1_tc_27131_View_RT_Assignments_for_Test()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "_TC27131");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.checkin();

            #region cretate TA
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "TC27131");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(TestTitle + "_TC27131");
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

            CommonSection.SearchCatalog(TestTitle + "_TC27131");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC27131");

            ContentDetailsPage.Click_OverviewTab();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isTrainingAssignmentportletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.TrainingAssignment.isDuedatedisplay());
            TC25153 = true;
        }
        [Test, Order(7)]
        public void tc_25153_Published_Test_Required_Training()
        {
            Assert.IsTrue(TC25153);
        }

        [Test, Order(8)]
        public void P20_1_tc_26290_Reviews_and_ratings_the_Tests()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "_TC26290");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.checkin();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("password").Login();
            CommonSection.SearchCatalog(TestTitle + "_TC26290");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC26290");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsFalse(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.ContentBanner.ClickOpenItembutton();
            //ContentDetailsPage.CompleteTest();
            ContentDetailsPage.ContentBanner.CloseOpenedTestwindow();
            
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.GeneralCourse_ReviewsTab.WriteaReview("Title", "For Testing");
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isReviewlistUpdated("Title"));
            _test.Log(Status.Pass, "User submited review");

           
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isEditReviewlinkdisplay());
            _test.Log(Status.Pass, "Verify user can edit his own review in content edit mode");
            ContentDetailsPage.GeneralCourse_ReviewsTab.DeleteReview();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            _test.Log(Status.Pass, "Verify review deleted and Write a Review button display");
            TC60280 = true;
        }
        [Test, Order(9)]
        public void tc_60280_View_the_Tests_Review_and_rating_tab()
        {
            Assert.IsTrue(TC60280);
        }
        [Test, Order (10)]  // created data manualy for this test case
        public void tc_60028_Test_Overview_Tab_What_Other_content_can_I_take()
        {
            CommonSection.SearchCatalog("Test for Automation - tc_60028");
            SearchResultsPage.ClickCourseTitle("Test for Automation-tc_60028");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isMorelikethisPortletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isEquivalenciesDisplayed());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPartoftheseCollectionDisplay());
                
        }

        [Test, Order(11)]
        public void tc_60082_Test_Overview_Tab_What_is_the_content_about()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "_TC60082");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.addCosttoTest("5");
            TestwizardPage.checkin();
            CommonSection.SearchCatalog(TestTitle + "_TC60082");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC60082");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.DescriptionPortletTitle("Description"));
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isMasteryScoredisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isMaxAttempsdisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isNumberidQuestiondisplay());
            _test.Log(Status.Pass, "Verify of Attempts, Mastery Score, Maximum time Allowed options are display");

        }
        [Test, Order(12)]
        public void tc_60286_Test_Banner_Actions_Edit_Save_and_Share()
        {            
            CommonSection.SearchCatalog(TestTitle + "_TC60082");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC60082");
            Assert.IsFalse(ContentDetailsPage.isEditContent_New19_2display());
            Assert.IsTrue(ContentDetailsPage.isOnlySaveandSharebuttndisplay());
            _test.Log(Status.Pass, "Verify only Save and Share button display for test");

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(TestTitle + "_TC60082");
            _test.Log(Status.Info, "Searched created Test");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC60082");
            _test.Log(Status.Info, "Click on test title");
            Assert.IsFalse(ContentDetailsPage.isEditContent_New19_2display());
            Assert.IsTrue(ContentDetailsPage.isOnlySaveandSharebuttndisplay());
            ContentDetailsPage.ClickSaveButton();
            Assert.IsTrue(ContentDetailsPage.isSaveButtonIconGreen());
            _test.Log(Status.Pass, "Click at Green saved button ");
            Assert.IsTrue(ContentDetailsPage.SocialSharingDropDown("Facebook"));
            _test.Log(Status.Pass, "verify the facebook ");


        }

        [Test, Order(13)]
        public void P20_1_tc_60090_Take_Tests_Related_Surveys()
        {

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "_TC60090");
            _test.Log(Status.Info, "A New test created");
           
            TestwizardPage.checkin();
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.searchtest(TestTitle + "_TC60090");
            TestsPage.clickOnTestTitle(TestTitle + "_TC60090");
            TestwizardPage.AddSurvettoTest("Before Course Start", TestTitle + "_TC60090");

            CommonSection.SearchCatalog(TestTitle + "_TC60090");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC60090");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isTakeTestButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.issurveyPortletisDisplay());
            ContentDetailsPage.ContentBanner.ClickTakeTest();
            ContentDetailsPage.CompleteTest(TestTitle + "_TC60090");
            
            Assert.IsTrue(ContentDetailsPage.ContentBanner.RequiredSurveymessage("Complete 1 survey(s) to receive your certificate."));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isTakeSurveyButtonDisplay());
            ContentDetailsPage.ContentBanner.Click_TakeSurveybutton();

            ContentDetailsPage.SurveyPortlet.CompleteSurvey("Before Course Start");
            //_test.Log(Status.Info, "Complete Survey");
            _test.Log(Status.Info, "Complete Survey");
            Assert.True(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            TC25152 = true;
            ContentDetailsPage.ContentBanner.clickViewCertificateButton();
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            Driver.focusParentWindow();
            TC26291 = true;
        }
        [Test, Order(14)]
        public void tc_25152_Published_Test_Surveys()
        {
            Assert.IsTrue(TC25152);
        }
        [Test, Order(15)]
        public void P20_1_tc_26291_View_Test_Certificate()
        {
            Assert.IsTrue(TC26291);
        }
        [Test, Order(16)]
        public void tc_60285_Test_Banner_Actions_Course_Info_and_Navigation()
        {
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "_TC60285");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.UploadImagetoTest();
            _test.Log(Status.Info, "Upload any Image file to content");
            TestwizardPage.checkin();

            CommonSection.SearchCatalog(TestTitle + "_TC60285");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC60285");
            Assert.IsTrue(ContentDetailsPage.isBradCrumbdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(TestTitle + "_TC60285"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay());
            _test.Log(Status.Pass, "Verify Image is display on Banner");
        }
        [Test, Order(17)]
        public void tc_60521_Test_Learner_views_history_tab()
        {
            CommonSection.SearchCatalog(TestTitle + "_TC60285");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC60285");
            Assert.IsFalse(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify history tab is not display as learner yet to enroll");
            ContentDetailsPage.ContentBanner.ClickTakeTest();
            ContentDetailsPage.closeTestModalwithoutComplete(TestTitle + "_TC60285");
            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify history tab is display as learner is enrolled");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.HistoryTab.isStatusDisplay("Started"));
            ContentDetailsPage.ContentBanner.click_continuebutton();
            ContentDetailsPage.CompleteTestwithFail(TestTitle + "_TC60285");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.HistoryTab.isTestfailed());
            _test.Log(Status.Pass, "Verify status display as failed in history tab");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.isTestScoredisplay());
            _test.Log(Status.Pass, "Verify test score display as failed in history tab");
            ContentDetailsPage.ContentBanner.ClickRetakeLink();
            ContentDetailsPage.CompleteTest(TestTitle + "_TC60285");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.HistoryTab.isRestarteddisplay());
            Assert.IsTrue(ContentDetailsPage.HistoryTab.isStatusDisplay("Completed"));
        }

        [Test, Order(17)]
        public void P20_1_tc_26288_Add_Test_to_Cart()
        {
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "_TC26288");
            _test.Log(Status.Info, "A New test created");
            TestwizardPage.addCosttoTest("5");
            _test.Log(Status.Info, "Upload any Image file to content");
            TestwizardPage.checkin();
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(TestTitle + "_TC26288");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC26288");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Verify Add to Cart button display");
            ContentDetailsPage.OverviewTab.click_AddtoCart();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.AddtoCartportlet.isTestAddedtoCart());
            CommonSection.ClickShoppingCart();

            ShoppingCartPage.CompletePurchaseProcess();
            OrderPage.Click_Purchased_Content(TestTitle + "_TC26288");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Costportlet.isViewOrderlinkDisplay());
            _test.Log(Status.Pass, "Verify view order link display on Add to Cart portlet");
            ContentDetailsPage.OverviewTab.Costportlet.ClickViewOrderlink();

            Assert.IsTrue(OrderDetailsPage.VerifyPurchasedContent(TestTitle + "_TC26288"));
            TC26378 = true;
        }
        [Test, Order(18)]
        public void P20_1_tc_26378_View_Test_Purchase_Details()
        {
            Assert.IsTrue(TC26378);
        }
        [Test, Order(19)]
        public void P20_1_tc_26864_Rate_Test_Transcript()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Administer.ContentManagement.Tests();
            TestsPage.ClickCreateNew();
            TestwizardPage.CreateNewTest(TestTitle + "_TC26864");
            _test.Log(Status.Info, "A New test created");

            TestwizardPage.checkin();
            
            CommonSection.Logout();
            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            _test.Log(Status.Info, "Login as Learner");
            CommonSection.SearchCatalog(TestTitle + "_TC26864");
            SearchResultsPage.ClickCourseTitle(TestTitle + "_TC26864");
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsFalse(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.ContentBanner.ClickTakeTest();
            ContentDetailsPage.CompleteTest(TestTitle + "_TC26864");
                       
            Assert.True(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            _test.Log(Status.Pass, "Verify Write a Review Button is display");
            CommonSection.Learn.Transcript();
            TranscriptPage.AllTrainingTab.FilterandClickTesttitle(TestTitle + "_TC26864");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(TestTitle + "_TC26864"));
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.GeneralCourse_ReviewsTab.WriteaReview("Title", "For Testing");
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isReviewlistUpdated("Title"));
            _test.Log(Status.Pass, "User submited review");


            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isEditReviewlinkdisplay());
            _test.Log(Status.Pass, "Verify user can edit his own review in content edit mode");
        }

    }
}



