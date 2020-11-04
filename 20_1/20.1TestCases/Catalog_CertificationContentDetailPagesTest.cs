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
    //[Parallelizable(ParallelScope.Fixtures)]
    public class P1_Catalog_CertificationContentDetailPagesTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_CertificationContentDetailPagesTest(string browser)
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
        string bunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string OJTTitle = "OJT" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle = "TA" + Meridian_Common.globalnum;
        string CertificatrTitle = "Certification" + Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";


        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }


        //Start writing your test here

        [Test, Order(1)]//Dollys Certification w/ Promo Video_12182018
        public void P20_1_tc_35368_Learner_Plays_Promotional_Videos_From_Certification()
        {

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC35368");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            DocumentPage.ClickButton_CheckIn();

            //CommonSection.Logout();
            //LoginPage.LoginAs("srlearner103").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC35368" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC35368" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35368"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPromotionalVideodisplay()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            //ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            //_test.Log(Status.Info, "Clicked Play button of Promotional video");
            //Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            //_test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");

        }
        [Test, Order(2)]
        public void tc_56910_Learner_view_Certification_Overview_Tab_Prerequisite()
        {
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC35368" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC35368" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35368"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            //ContentDetailsPage.Click_CheckOut();
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Click_CheckOut();
            AdminContentDetailsPage.AddPrequisites("General");
            ContentDetailsPage.Click_Check_in();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC35368" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC35368" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35368"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
        }

        [Test, Order(3)]
        public void tc_56911_Learner_view_Certification_Overview_Tab_Training_assignment_date()
        {

            #region cretate TA
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "56911");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(CertificatrTitle + "TC35368");
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
            LoginPage.LoginAs("srlearner101").WithPassword("password").Login();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC35368" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC35368" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35368"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isTrainingAssignmentportletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.TrainingAssignment.isDuedatedisplay());
            _test.Log(Status.Pass, "Verify training assignment portlet display on oberview tab.");

        }
        [Test, Order(4)]
        public void tc_56912_Learner_view_Certification_Overview_Tab_Survey()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC35368" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC35368" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35368"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");

            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Click_CheckOut();
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");

            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            Assert.IsTrue(SurveysPage.AddSurveyModal.IsSearchfieldsDisplayed());
            _test.Log(Status.Pass, "Verify Search, Result grid, Add button on Add survey Modal");
            //SurveysPage.AddSurveyModal.AddSurveystoContent();
            //_test.Log(Status.Info, "Search Survey and add one survey to content");
            string Surveytitle_OnEnroll = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When learner enrolls");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When learner enrolls");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            string Surveytitle_OnContentComplete = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When content completed");
            SurveysPage.Click_backbutton();
            ContentDetailsPage.Click_Check_in();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC35368" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "TC35368" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35368"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysDisplay(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));

            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysareNotavailable);
            _test.Log(Status.Pass, "Verify surveys are display and not activated");
        }
        [Test, Order(5)]
        public void tc_57159_Certification_Reviews_Tab_and_ratings()
        {


            CommonSection.SearchCatalog('"' + CertificatrTitle + "TC35368" + '"');
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "TC35368");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            _test.Log(Status.Pass, "Verify Start button is display in banner");
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsFalse(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            _test.Log(Status.Pass, "Verify Write a Review button is not display in review tab");
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.GeneralCourse_ReviewsTab.WriteaReview("Title", "For Testing");
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isReviewlistUpdated("Title"));
            _test.Log(Status.Pass, "Verify review added to content");
            ContentDetailsPage.GeneralCourse_ReviewsTab.DeleteReview();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            _test.Log(Status.Pass, "Verify review deleted and Write a Review button display");
        }
        [Test, Order(6)]
        public void P20_1_tc_26327_Add_Certification_to_Cart()
        {

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC26327");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");

            AdminContentDetailsPage.AddCost();

            ContentDetailsPage.ClickEditContent_New19_2();
            DocumentPage.ClickButton_CheckIn();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC26327" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC26327" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC26327"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.isAddToCartButtonDisplayed());
            ContentDetailsPage.ClickAddtoCart_GeneralCourse();
            // StringAssert.AreEqualIgnoringCase("Success\r\nThe item was added to the cart.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(ContentDetailsPage.ClickAddtoCartPortlet.isAddedtocardinfodisplay());
            Assert.IsTrue(CommonSection.isCountincrease_ShopingCart());
            _test.Log(Status.Pass, "Verify content added to cart and cart count increased");
        }


        [Test, Order(7)]
        public void tc_57096_Learner_can_see_More_like_this_Part_of_collection_and_Prerequisites_for_this_items_portlets_on_certifications_detail_page()
        {
            //Create a certification name as Certi_TC57096 and add existing tag, add this to any other content pre requisite and add this certificate to other contentner content
            CommonSection.SearchCatalog("Certi_TC57096");
            SearchResultsPage.ClickCourseTitle("Certi_TC57096");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            //Assert.IsTrue(ContentDetailsPage.OverviewTab.isMorelikethisPortletDisplay()); //(cann't work on external)
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPartoftheseCollectionDisplay());
        }
        [Test, Order(8)]
        public void tc_58123_Certification_Banner_Action_Navigation()
        {

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC58123");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            ContentDetailsPage.Accordians.ClickEdit_Image();
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");

            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            CommonSection.SearchCatalog(CertificatrTitle + "_TC58123");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC58123");
            Assert.IsTrue(ContentDetailsPage.isBradCrumbdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC58123"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay());
            _test.Log(Status.Pass, "Verify Image is display on Banner");
            //            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentProgressbarDisplay());
            //          _test.Log(Status.Pass, "Verify Content Progress bar display on banner");
        }
        [Test, Order(9)]
        public void tc_58124_Certification_Banner_Actions_Edit_Save_Share()
        {
            CommonSection.SearchCatalog(CertificatrTitle + "_TC58123");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC58123");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(CertificatrTitle + "_TC58123"));
            Assert.IsTrue(ContentDetailsPage.isSaveShareandEditContentbuttndisplay());
            _test.Log(Status.Pass, "Verify Save, Share and Edit content button is displayed");
            ContentDetailsPage.ClickEditContent_New19_2();
            Assert.IsTrue(AdminContentDetailsPage.isContentopened(CertificatrTitle + "_TC58123"));
            _test.Log(Status.Pass, "Verify edit content opens admin content details page");
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(CertificatrTitle + "_TC58123");
            _test.Log(Status.Info, "Searched Certification course");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC58123");
            _test.Log(Status.Info, "Click on Certification course title");
            Assert.IsTrue(ContentDetailsPage.isOnlySaveandSharebuttndisplay());
            ContentDetailsPage.ClickSaveButton();
            Assert.IsTrue(ContentDetailsPage.isSaveButtonIconGreen());
            _test.Log(Status.Pass, "Click at Green saved button ");
            Assert.IsTrue(ContentDetailsPage.SocialSharingDropDown("Facebook"));
            _test.Log(Status.Pass, "verify the facebook ");
        }
        [Test, Order(10)]
        public void tc_57816_Learner_view_Certification_linear_Content_Tab_Core_Certification()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57816");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57816_1");
            ContentDetailsPage.Accordians.ClickEdit_Image();
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC57816");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC57816" + '"');
            CertificatePage.Click_backbutton();
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC57816_1" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();


            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC57816" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC57816" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC57816");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.Click_ContentTab();
            Assert.IsFalse(ContentDetailsPage.ContentTab.CoreCertification.Actionbuttondisplay());

            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            Assert.IsFalse(ContentDetailsPage.isContentTabSelected());
            ContentDetailsPage.ContentBanner.ClickViewContentButton();
            //Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.Actionbuttondisplay());
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.ContentTitledisplay(GeneralCourseTitle + "_TC57816"));
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.ContentTypedisplay());
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.ContentImagedisplay());
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC57816");
            ContentDetailsPage.ContentBanner.ClickViewContentButton();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.isStartbuttondisplay(GeneralCourseTitle + "_TC57816"));
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC57816");
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.otherActionbuttondisplay(GeneralCourseTitle + "_TC57816", "Continue", "Mark Complete"));
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC57816");
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.ReviewActionbuttondisplay());


        }
        [Test, Order(11)]
        public void tc_58125_Certification_Banner_Context_Driver_Actions()
        {

            #region Create a certification course
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC58125");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Edit Content");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign approval path");
            DocumentPage.ClickButton_CheckIn();
            #endregion

            CommonSection.SearchCatalog(CertificatrTitle + "_TC58125");
            _test.Log(Status.Info, "Search certification Course");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC58125");
            _test.Log(Status.Info, "Click on AICC Course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display on Banner");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            ContentDetailsPage.ContentBanner.ClickViewRequestHistory();
            Assert.IsTrue(ContentDetailsPage.isHistorywindowopened());

            Assert.IsTrue(ContentDetailsPage.Historywin.isfieldsdisplay(CertificatrTitle + "_TC58125", "Content type", "status"));
            Driver.Instance.SelectWindowClose2("History", Meridian_Common.parentwdw);

            ContentDetailsPage.AccessApprovalModal.SubmitCancelRequestAccess("ForTest");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Info, "Verify Cancel Request access wotk flow");
        }
        [Test, Order(12)]
        public void tc_57829_Learner_view_Certification_Non_linear_Content_Tab_Core_Certification()
        {

            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57829");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57829_1");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC57829");
            //CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC57829" + '"');
            CertificatePage.Click_backbutton();
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC57829_1" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();


            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC57829" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC57829" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC57829");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.Click_ContentTab();
            Assert.IsFalse(ContentDetailsPage.ContentTab.CoreCertification.Actionbuttondisplay());

            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.ContentBanner.ClickViewContentButton();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.Actionbuttondisplay());
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.ContentTitledisplay(GeneralCourseTitle + "_TC57829"));
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.ContentTypedisplay());
            //Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.otherActionbuttondisplay(GeneralCourseTitle + "_TC57829_1", "Enroll"));
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC57829");
            ContentDetailsPage.ContentBanner.ClickViewContentButton();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.isStartbuttondisplay(GeneralCourseTitle + "_TC57829"));
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC57829");
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.otherActionbuttondisplay(GeneralCourseTitle + "_TC57829", "Continue", "Mark Complete"));
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC57829");
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.ReviewActionbuttondisplay());


        }
        [Test, Order(13)]
        public void tc_57830_Learner_view_Certification_Credit_base_Content_Tab_Core_Certification()
        {


            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC57830");
            CertificationPage.selectCompletionCriteria("Total credit hours are achieved");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");

            ContentDetailsPage.ClickCheckInbutton();


            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC57830" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC57830" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC57830");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.Click_ContentTab();
            //Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.contentnotcompletedmessagedisplay());
            Assert.IsTrue(ContentDetailsPage.ContentTab.isFindQualifyingContentbuttondisplay());

            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.ContentTab.clickFindQualifyingContent();
            Assert.IsTrue(Driver.checkTitle("Search Results"));


        }
        [Test, Order(14)]
        public void tc_57831_Learner_view_Certification_Content_Tab_Alternate_Option()
        {

            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57831");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57831_1");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC57831");
            //CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC57831" + '"');
            CertificatePage.Click_backbutton();
            CertificatePage.addContentIntoCertificateAlternetOption('"' + GeneralCourseTitle + "_TC57831_1" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC57831" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC57831" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC57831");
            _test.Log(Status.Info, "Clicked searched course title");

            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.ContentBanner.ClickViewContentButton();
            Assert.IsTrue(ContentDetailsPage.ContentTab.isAlternetOptionportletdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentTab.AlternetOption.isCountdisplay());

            Assert.IsTrue(ContentDetailsPage.ContentTab.AlternetOption.Actionbuttondisplay(GeneralCourseTitle + "_TC57831_1"));
            Assert.IsTrue(ContentDetailsPage.ContentTab.AlternetOption.ContentTitledisplay(GeneralCourseTitle + "_TC57831_1"));
            Assert.IsTrue(ContentDetailsPage.ContentTab.AlternetOption.ContentTypedisplay(GeneralCourseTitle + "_TC57831_1"));
            ContentDetailsPage.ContentTab.AlternetOption.ClickEnroll(GeneralCourseTitle + "_TC57831_1");
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.ContentTab.AlternetOption.isStartbuttondisplay(GeneralCourseTitle + "_TC57831_1"));
            ContentDetailsPage.ContentTab.AlternetOption.StarContentandClose(GeneralCourseTitle + "_TC57831_1");
            ContentDetailsPage.Click_ContentTab();
            //Assert.IsTrue(ContentDetailsPage.ContentTab.AlternetOption.otherActionbuttondisplay(GeneralCourseTitle + "_TC57831_1", "Continue", "Mark Complete"));
            ContentDetailsPage.ContentTab.AlternetOption.SelectMarkComplete(GeneralCourseTitle + "_TC57831_1");
            //ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            //Assert.IsTrue(ContentDetailsPage.ContentBanner.ContentProgress()== "100%");

        }
        [Test, Order(15)]
        public void tc_60313_Learner_view_Re_Certification_linear_Content_Tab_Core_Re_Certification()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60313");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60313_ReCerti");
            ContentDetailsPage.Accordians.ClickEdit_Image();
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60313_ReCerti_1");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60313");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            //CertificationPage.Whenistsertificationperiod("Immediately").until("1").Days();
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC60313" + '"');
            CertificatePage.Click_backbutton();

            CertificatePage.addContenttoRecertification('"' + GeneralCourseTitle + "_TC60313_ReCerti" + '"');
            CertificatePage.Click_backbutton();
            CertificatePage.addContenttoRecertification('"' + GeneralCourseTitle + "_TC60313_ReCerti_1" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            //CommonSection.Logout();
            //LoginPage.LoginAs("srlearner103").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60313" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60313" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60313");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());

            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC60313");
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.isStartbuttondisplay(GeneralCourseTitle + "_TC60313"));
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC60313");

            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC60313");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStart_recertificationLinkdisplay());
            _test.Log(Status.Pass, "Verify recertify link display on banner");
            ContentDetailsPage.ContentBanner.Click_recertificationLink();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            //ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.ContentTab.isRecertificationCriteriaportletdisplay());
            _test.Log(Status.Pass, "Verify recertification content display");
            Assert.IsTrue(ContentDetailsPage.ContentTab.RecertificationCriteria.Actionbuttondisplay());
            Assert.IsTrue(ContentDetailsPage.ContentTab.RecertificationCriteria.ContentTitledisplay(GeneralCourseTitle + "_TC60313_ReCerti"));
            _test.Log(Status.Pass, "Verify content title on recertification criteria");
            ContentDetailsPage.ContentTab.RecertificationCriteria.ClickEnroll(GeneralCourseTitle + "_TC60313_ReCerti");
            Assert.IsTrue(ContentDetailsPage.ContentTab.RecertificationCriteria.isStartbuttondisplay(GeneralCourseTitle + "_TC60313_ReCerti"));
            _test.Log(Status.Pass, "Verify start button for recertification criteria content");
            ContentDetailsPage.ContentTab.RecertificationCriteria.StarContentandClose(GeneralCourseTitle + "_TC60313_ReCerti");
            Assert.IsTrue(ContentDetailsPage.ContentTab.RecertificationCriteria.otherActionbuttondisplay(GeneralCourseTitle + "_TC60313_ReCerti", "Continue", "Mark Complete"));
            _test.Log(Status.Pass, "Verify Mark Complete, continue button for recertification criteria content");
            ContentDetailsPage.ContentTab.RecertificationCriteria.SelectMarkComplete(GeneralCourseTitle + "_TC60313_ReCerti");
            //Assert.IsTrue(ContentDetailsPage.ContentTab.RecertificationCriteria.otherActionbuttondisplay(GeneralCourseTitle + "_TC60313_ReCerti", "Review"));


        }
        [Test, Order(16)]
        public void tc_58126_Certification_Banner_Actions_Enroll()
        {
            //CommonSection.Logout();
           // LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC58126");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC58126");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC58126" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC58126" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC58126" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC58126");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC58126");
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.isStartbuttondisplay(GeneralCourseTitle + "_TC58126"));
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC58126");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC58126");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            ContentDetailsPage.ContentBanner.clickViewCertificateButton();
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            Driver.focusParentWindow();
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isReviewLinkDisplay());
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());

        }
        [Test, Order(17)]
        public void tc_58144_Certifications_Banner_Actions_Access_period()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC58144");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC58144");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC58126" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.Edit_AddAccessPeriod("10");
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC58126" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC58126" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC58126");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Verify access period flag display in banner");
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            _test.Log(Status.Pass, "Verify access period flag display in banner after start certification");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflagMessage("Your access to this content item ends"));
        }
        [Test, Order(18)] //create data for this test case
        public void P20_1_tc_26240_Rate_AICC_Course()
        {
            CommonSection.SearchCatalog("Automation AICC-TC59282");
            _test.Log(Status.Info, "Searched Automation AICC - TC59282 from Catalog");
            SearchResultsPage.ClickCourseTitle("Automation AICC-TC59282");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.Click_ReviewTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.reviewcount() > 10);
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is pagination display on review tab");
        }
        [Test, Order(19)] //create data for this test case
        public void P20_1_tc_26837_Rate_Classroom_Course()
        {
            CommonSection.SearchCatalog("Classroom Course for Automation");
            _test.Log(Status.Info, "Searched Classroom Course for Automation from Catalog");
            SearchResultsPage.ClickCourseTitle("Classroom Course for Automation");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.Click_ReviewTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.reviewcount() > 10);
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is pagination display on review tab");

        }
        [Test, Order(20)] //create data for this test case
        public void P20_1_tc_26208_Rate_Document()
        {
            CommonSection.SearchCatalog("tc_26208_Rate_Document");
            _test.Log(Status.Info, "Searched tc_26208_Rate_Document from Catalog");
            SearchResultsPage.ClickCourseTitle("tc_26208_Rate_Document");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.Click_ReviewTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.reviewcount() > 10);
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is pagination display on review tab");


        }
        [Test, Order(21)] //create data for this test case
        public void P20_1_tc_26239_Rate_SCROM_Course()
        {
            CommonSection.SearchCatalog("SCROM_TC57645");
            _test.Log(Status.Info, "Searched SCROM_TC57645 from Catalog");
            SearchResultsPage.ClickCourseTitle("SCROM_TC57645");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.Click_ReviewTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.reviewcount() > 10);
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is pagination display on review tab");


        }
        [Test, Order(22)] //create data for this test case
        public void P20_1_tc_26241_Rate_General_Course()
        {
            CommonSection.SearchCatalog("tc_26241_Rate_General_Course");
            _test.Log(Status.Info, "Searched tc_26241_Rate_General_Course from Catalog");
            SearchResultsPage.ClickCourseTitle("tc_26241_Rate_General_Course");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.Click_ReviewTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.reviewcount() > 10);
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is pagination display on review tab");


        }
        [Test, Order(23)] //create data for this test case
        public void P20_1_tc_26320_Rate_Bundle()
        {
            CommonSection.SearchCatalog("Bundle_tc_56307");
            _test.Log(Status.Info, "Searched Bundle_tc_56307 from Catalog");
            SearchResultsPage.ClickCourseTitle("Bundle_tc_56307");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.Click_ReviewTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.reviewcount() > 10);
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is pagination display on review tab");


        }
        [Test, Order(24)] //create data for this test case
        public void P20_1_tc_26328_Rate_Certification()
        {
            CommonSection.SearchCatalog("tc_26328_Rate_Certification");
            _test.Log(Status.Info, "Searched tc_26328_Rate_Certification from Catalog");
            SearchResultsPage.ClickCourseTitle("tc_26328_Rate_Certification");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.Click_ReviewTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.reviewcount() > 10);
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is pagination display on review tab");


        }
        [Test, Order(25)] //create data for this test case
        public void P20_1_tc_26348_Rate_Curriculumn()
        {
            CommonSection.SearchCatalog("tc_26328_Rate_Certification");
            _test.Log(Status.Info, "Searched tc_26328_Rate_Certification from Catalog");
            SearchResultsPage.ClickCourseTitle("tc_26328_Rate_Certification");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.Click_ReviewTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.reviewcount() > 10);
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is pagination display on review tab");


        }
        [Test, Order(26)]
        public void tc_60474_Pagination_in_Review_for_Tests_course()
        {
            CommonSection.SearchCatalog("tc_60474_Pagination");
            _test.Log(Status.Info, "Searched tc_60474_Pagination from Catalog");
            SearchResultsPage.ClickCourseTitle("tc_60474_Pagination");
            _test.Log(Status.Info, "Clicked searched course title");
            ContentDetailsPage.Click_ReviewTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.reviewcount() > 10);
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isPaginationdisplay());
            _test.Log(Status.Pass, "Verify is pagination display on review tab");
        }
        [Test, Order(27)]
        public void tc_60312_Learner_view_Re_Certification_non_linear_Content_Tab_Core_Re_Certification()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60312");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60312_Recerti");
            ContentDetailsPage.Accordians.ClickEdit_Image();
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC60312_Recerti_1");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60312");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.isthisarecurringcertification("Yes");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC60312" + '"');
            CertificatePage.Click_backbutton();
            CertificatePage.addContenttoRecertification('"' + GeneralCourseTitle + "_TC60312_Recerti" + '"');
            CertificatePage.Click_backbutton();
            CertificatePage.addContenttoRecertification('"' + GeneralCourseTitle + "_TC60312_Recerti_1" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();


            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60312" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60312" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60312");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC60312");
            //ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC60312");
            Assert.IsTrue(ContentDetailsPage.ContentTab.CoreCertification.otherActionbuttondisplay(GeneralCourseTitle + "_TC60312", "Continue", "Mark Complete"));
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC60312");

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStart_recertificationLinkdisplay());
            _test.Log(Status.Pass, "Verify recertify link display on banner");
            ContentDetailsPage.ContentBanner.Click_recertificationLink();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewContentButtonDisplay());
            ContentDetailsPage.Click_ContentTab();
            Assert.IsTrue(ContentDetailsPage.ContentTab.isRecertificationCriteriaportletdisplay());
            _test.Log(Status.Pass, "Verify recertification content display");
            Assert.IsTrue(ContentDetailsPage.ContentTab.RecertificationCriteria.Actionbuttondisplay());
            Assert.IsTrue(ContentDetailsPage.ContentTab.RecertificationCriteria.ContentTitledisplay(GeneralCourseTitle + "_TC60312_Recerti"));
            _test.Log(Status.Pass, "Verify content title on recertification criteria");
            ContentDetailsPage.ContentTab.RecertificationCriteria.ClickEnroll(GeneralCourseTitle + "_TC60312_Recerti");
            Assert.IsTrue(ContentDetailsPage.ContentTab.RecertificationCriteria.isStartbuttondisplay(GeneralCourseTitle + "_TC60312_Recerti"));
            _test.Log(Status.Pass, "Verify start button for recertification criteria content");
            ContentDetailsPage.ContentTab.RecertificationCriteria.StarContentandClose(GeneralCourseTitle + "_TC60312_Recerti");
            //Assert.IsTrue(ContentDetailsPage.ContentTab.RecertificationCriteria.otherActionbuttondisplay(GeneralCourseTitle + "_TC60312_Recerti", "Continue", "Mark Complete"));
            _test.Log(Status.Pass, "Verify Mark Complete, continue button for recertification criteria content");
            ContentDetailsPage.ContentTab.RecertificationCriteria.SelectMarkComplete(GeneralCourseTitle + "_TC60312_Recerti");
            //Assert.IsTrue(ContentDetailsPage.ContentTab.RecertificationCriteria.otherActionbuttondisplay(GeneralCourseTitle + "_TC60312_Recerti", "Review"));

        }
        [Test, Order(28)]
        public void tc_60458_Learner_view_Certification_Overview_Tab_Expiration_and_Re_Certification()
        {
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC60458");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC60458" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC60458" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC60458");
            _test.Log(Status.Info, "Clicked searched course title");

            Assert.IsTrue(ContentDetailsPage.OverviewTab.isCertificationExpiriespaneldesplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.CertificationExpiries.Status("Never"));
            ContentDetailsPage.ClickEditContent_New19_2();
            AdminContentDetailsPage.Summary.ClickEdit();
            CertificatePage.Doesthiscertificationexpire("Yes");
            EditSummaryPage.ClickSavebutton();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on View As Learner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isCertificationExpiriespaneldesplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.CertificationExpiries.Status("1 Day(s) after completion"));

            ContentDetailsPage.ClickEditContent_New19_2();
            AdminContentDetailsPage.Summary.ClickEdit();
            CertificationPage.isthisarecurringcertification("Yes");
            EditSummaryPage.ClickSavebutton();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on View As Learner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isCertificationisgooddesplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isReCertiypaneldisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.ReCertify.Status("Every 1 Day(s)"));

        }
        [Test, Order(29)]
        public void tc_61021_As_a_Learner_Verify_the_Banner_Notifications_for_Certification()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC61021");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61021");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.SelectautomaticallygrantedcertificationDefaultValue("No");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC61021" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61021" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61021" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61021");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContextDrivenMessage.BeforeStart("Click Start to Continue"));
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContextDrivenMessage.AfterContentStart("Complete 1 items to earn this certification"));
            ContentDetailsPage.ContentBanner.ClickViewContentButton();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC61021");
            //ContentDetailsPage.Click_ContentTab(); 
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC61021");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContextDrivenMessage.InProgressContentTitle(GeneralCourseTitle + "_TC61021"));
            //ContentDetailsPage.ContentBanner.ClickViewContentButton();
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC61021");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContextDrivenMessage.PendingforApproval("You completed the required content. Your certification is pending final approval."));

            CommonSection.Manage.Certification();
            _test.Log(Status.Info, "Navigated to Manage > Certification");
            CertificationConsolePage.Search(CertificatrTitle + "_TC61021");
            CertificationConsolePage.ClickSearchedContentTitle(CertificatrTitle + "_TC61021");
            CertificationConsolePage.SearchUser("admin");
            Assert.IsTrue(CertificationConsolePage.Resulttable.isUserdisplay("admin"));
            _test.Log(Status.Pass, "Verify user is display");
            Assert.IsTrue(CertificationConsolePage.Resulttable.CurrentStatus("Not Certified"));
            Assert.IsTrue(CertificationConsolePage.Resulttable.ProgressStatus("Pending"));
            //Assert.IsTrue(CertificationConsolePage.Resulttable.ActionMenuItems("Certify", "Suspend"));
            _test.Log(Status.Pass, "Verify current status, progress status and action items are display");
            CertificationConsolePage.Resulttable.SelectActionItem("Suspend");
            _test.Log(Status.Info, "Mark certification as Suspended");

            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61021" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61021" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61021");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContextDrivenMessage.Suspended("Your certification was suspended on"));

        }
        [Test, Order(31)]
        public void tc_61100_Certification_Pending_status_does_not_Give_completion()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC61100");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "_TC61100");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.selectCompletionCriteria("Liner");
            _test.Log(Status.Info, "Fill title");
            CertificatePage.Doesthiscertificationexpire("Yes");
            CertificationPage.SelectautomaticallygrantedcertificationDefaultValue("No");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            CertificatePage.addContentIntoCertificate('"' + GeneralCourseTitle + "_TC61100" + '"');
            CertificatePage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            Driver.CreateNewAccount();
            _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs(Meridian_Common.NewUserId).WithPassword("").Login();
            CommonSection.SearchCatalog('"' + CertificatrTitle + "_TC61100" + '"');
            _test.Log(Status.Info, "Searched" + CertificatrTitle + "_TC61100" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(CertificatrTitle + "_TC61100");
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());           
            ContentDetailsPage.ContentBanner.Click_Startbutton();            
            ContentDetailsPage.ContentBanner.ClickViewContentButton();
            ContentDetailsPage.ContentTab.CoreCertification.ClickEnroll(GeneralCourseTitle + "_TC61100");
           //ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.StarContentandClose(GeneralCourseTitle + "_TC61100");
            //ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.CoreCertification.SelectMarkComplete(GeneralCourseTitle + "_TC61100");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContextDrivenMessage.PendingforApproval("You completed the required content. Your certification is pending final approval."));

            CommonSection.Transcript();
            TranscriptPage.ClickCertificationsTab();
            Assert.IsTrue(TranscriptPage.CertificationTab.isCertificationStatus(CertificatrTitle + "_TC61100") == "Pending");
            CommonSection.ClickHome();
            Assert.IsTrue(HomePage.CertificationPortlet.isStatus(CertificatrTitle + "_TC61100", "Pending"));
        }
        [Test, Order(30)]
        public void tc_58197_As_an_Admin_I_want_to_set_when_a_learner_can_begin_recertification_and_whether_they_can_complete_after_expiration()
        {
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.Certifications();
            _test.Log(Status.Info, "Click create>certification");
            CertificationPage.FillTitle(CertificatrTitle + "TC57970");
            _test.Log(Status.Info, "Fill title");
            CertificationPage.DoesthisCertificationexpire("Yes");
            Assert.IsTrue(CertificationPage.isthisarecurringcertificationLeveldisplay());
            CertificationPage.isthisarecurringcertification("Yes");
            Assert.IsTrue(CertificationPage.isWhenistherecertificationperiodLevelDisplay()); //AC1
            CertificationPage.Whenistherecertificationperiod.Setbeforeexpiration();
            Assert.IsTrue(CertificationPage.isCertificationperiodfieldsDisplay()); //AC2
            CertificationPage.Whenistherecertificationperiod.Brfore("15");
            CertificationPage.Whenistherecertificationperiod.SetEndsAs("Set period");
            CertificationPage.Whenistherecertificationperiod.After("15");
            CertificationPage.ClickCreateCertification();
            _test.Log(Status.Info, "Click create");
            Assert.IsTrue(ContentDetailsPage.Summary.VerifyRecertificationIntervaldays("15 Days")); //AC3
           
        }

    }
}



