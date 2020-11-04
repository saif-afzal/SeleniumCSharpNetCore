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
    public class P1_Catalog_GeneralCourseContentDetailPagesTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_GeneralCourseContentDetailPagesTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
               
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        bool TC26235;
        bool TC56708;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        string TATitle="TrainingAssignment"+ Meridian_Common.globalnum;
        bool TC56397_1, TC56397_2;
        

     
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
     

        //Start writing your test here

        [Test, Order(1)]
        public void a01_General_Course_Reviews_Tab_and_ratings_56591()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC56591");
            DocumentPage.ClickButton_CheckIn();
            #endregion

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("password").Login();
            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC56591");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC56591");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsFalse(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.EnrollinGeneralCourse_new();
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.GeneralCourse_ReviewsTab.WriteaReview("Title", "For Testing");
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isReviewlistUpdated("Title"));


        }

        [Test, Order(2)]
        public void a02_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_General_Course_35687()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            //CommonSection.CreateLink.GeneralCourse();
            //_test.Log(Status.Info, "Goto Content Creation Page");
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC35687");
            _test.Log(Status.Info, "A new Genaral Course Created");
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
            string Surveytitle_OnEnroll = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When learner enrolls");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When learner enrolls");
            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");
            string Surveytitle_OnContentComplete = SurveysPage.AddSurveyModal.AddSurveystoContentWithAvailabilityas("When content completed");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When content completed");
            SurveysPage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(generalcoursetitle + "TC35687");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35687");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysDisplay(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            //Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysDisplay(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysareNotavailable);
            //ContentDetailsPage.EnrollinGeneralCourse_new();
            
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnEnroll));
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnContentComplete));

        }

        [Test, Order(3)]
        public void a03_Enroll_in_General_Course_26224()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC26224");
            DocumentPage.ClickButton_CheckIn();
            #endregion

            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC26224");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC26224");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            ContentDetailsPage.EnrollinGeneralCourse_new();
            //StringAssert.AreEqualIgnoringCase("Success\r\nYou are now enrolled.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancelEnrolllinkDisplay_GeneralCourse());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
        }
        [Test, Order(4)]
        public void a04_Cancel_Enroll_in_General_Course_26223()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC26223");
            DocumentPage.ClickButton_CheckIn();
            #endregion

            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC26223");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC26223");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            ContentDetailsPage.EnrollinGeneralCourse_new();
          //  StringAssert.AreEqualIgnoringCase("Success\r\nYou are now enrolled.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancelEnrolllinkDisplay_GeneralCourse());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            ContentDetailsPage.ContentBanner.Click_CancelEnrollmetlink();
          //  StringAssert.AreEqualIgnoringCase("Success\r\nYour enrollment for the selected course was cancelled.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isCancelEnrolllinkDisplay_GeneralCourse());
            Assert.IsFalse(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());

        }
        [Test, Order(5)]
        public void a05_Add_General_Course_to_Cart_26229()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC26229");
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            DocumentPage.ClickButton_CheckIn();
            #endregion

            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC26229");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC26229");
            Assert.IsTrue(ContentDetailsPage.isAddToCartButtonDisplayed());

            ContentDetailsPage.ClickAddtoCart_GeneralCourse();
           // StringAssert.AreEqualIgnoringCase("Success\r\nThe item was added to the cart.\r\n×", Driver.getSuccessMessage(), "Error message is different");

            Assert.IsTrue(ContentDetailsPage.ClickAddtoCartPortlet.isAddedtocardinfodisplay());
            Assert.IsTrue(CommonSection.isCountincrease_ShopingCart());


        }
        [Test, Order(6)]
        public void a06_General_Course_Learner_Content_Details_Page_components_56517()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC56517");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "A new Genaral Course Created");
            #endregion

            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC56517");
            _test.Log(Status.Info, "Searched created Genaral Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC56517");
            _test.Log(Status.Info, "Click on Genaral Course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(GeneralCourseTitle + "_TC56517"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
           // Assert.IsTrue(ContentDetailsPage.ContentBanner.isLocalepickerdisplay());
            _test.Log(Status.Pass, "Verify locale picker is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay());
            Assert.IsTrue(ContentDetailsPage.isSaveShareandEditContentbuttndisplay());
            _test.Log(Status.Pass, "Verify Save, Share and Edit content button is displayed");
            ContentDetailsPage.EnrollinGeneralCourse_new();
          //  StringAssert.AreEqualIgnoringCase("Success\r\nYou are now enrolled.\r\n×", Driver.getSuccessMessage(), "Error message is different");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancelEnrolllinkDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Varify cancel enroll link display on banner");
            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify History tab is activated");

        }
        [Test, Order(7)]
        public void a07_Request_Access_to_General_Course_26232()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC26232");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            AccessApprovalPage.AssignApproverPath();
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "A new Genaral Course with access approver Created");
            #endregion
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC26232");
            _test.Log(Status.Info, "Searched created Genaral Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC26232");
            _test.Log(Status.Info, "Click on Genaral Course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display on Banner");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");

            ContentDetailsPage.AccessApprovalModal.SubmitCancelRequestAccess("ForTest");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Info, "Verify Cancel Request access wotk flow");
            TC26235 = true;

        }
        [Test, Order(8)]
        public void a08_Cancel_Access_Request_to_General_Course_26235()
        {
            Assert.IsTrue(TC26235);
        }
        [Test, Order(9)]
        public void a09_View_General_Course_Details_26365()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC26365");
            AdminContentDetailsPage.CourseInformation.ClickEditButton();
            CourseInformationPage.CourseProvider.Select("Meridian");
            CourseInformationPage.EnterDuration("5");
            CourseInformationPage.clickSave();
            ContentDetailsPage.PromotionalVideo.Click_Edit();
            PromotionalVideoPage.AddNewURL("//www.youtube.com/embed/Fc1P-AEaEp8");
            PromotionalVideoPage.Click_SaveButton();
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "A new Genaral Course with access approver Created");
            #endregion

            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC26365");
            _test.Log(Status.Info, "Searched created Genaral Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC26365");
            _test.Log(Status.Info, "Click on Genaral Course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(GeneralCourseTitle + "_TC26365"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDescriptionDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isCourseProviderDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDurationDisplay());
           // Assert.IsTrue(ContentDetailsPage.VerifyPromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
        

        }
        [Test, Order(10)]
        public void a10_View_General_Course_Certificate_26238()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC26238");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "A new Genaral Course with access approver Created");
            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC26238");
            _test.Log(Status.Info, "Searched created Genaral Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC26238");
            _test.Log(Status.Info, "Click on Genaral Course title");
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            _test.Log(Status.Info, "Click on Genaral Course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isReviewLinkDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());
            ContentDetailsPage.ContentBanner.clickViewCertificateButton();
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            Driver.focusParentWindow();
           


        }
        [Test, Order(11)]
        public void a11_Learner_view_General_Course_history_tab_on_Content_Details_Catalog_page_56708()
        {
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC56708");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "A new Genaral Course with access approver Created");
            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC56708");
            _test.Log(Status.Info, "Searched created Genaral Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC56708");
            _test.Log(Status.Info, "Click on Genaral Course title");
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            _test.Log(Status.Info, "Click on Genaral Course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isReviewLinkDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());
            ContentDetailsPage.ContentBanner.clickViewCertificateButton();
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            Driver.focusParentWindow();
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.HistoryTab.isViewCertificateButtonDisplay());
            _test.Log(Status.Pass, "Verify view certificate button display in history tab");

        }
        [Test, Order(12)]//"Dolly's General Course w/ promotional video_12172018"
        public void a12_Learner_Plays_Promotional_Videos_From_General_Course_35375()
        {
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC35375", generalcoursetitle + "TC35375");
            _test.Log(Status.Info, "A new Genaral Course Created");
            Assert.IsTrue(ContentDetailsPage.Accordians.isPromotionalVideoPresent());
            _test.Log(Status.Info, "Verify Promotional Video accordian display on RHS side");
            ContentDetailsPage.Accordians.PromotionalVideo.Click_Edit();
            _test.Log(Status.Info, "Click Promotional Video Edit button");
            Assert.IsTrue(PromotionalVideoPage.VerifyCompenets("ULR", "Preview", "Save"));
            _test.Log(Status.Info, "Verify Add URL, preview section and save button are displaying in Promotional Video Page");
            PromotionalVideoPage.AddNewURL(PromoURL); ////www.youtube.com/embed/Fc1P-AEaEp8
            _test.Log(Status.Info, "Add a URl");
            Assert.IsTrue(PromotionalVideoPage.isVideoPreviewDisplay());
            _test.Log(Status.Info, "Verify video is added and preview display");
            PromotionalVideoPage.Click_SaveButton();
            _test.Log(Status.Info, "Click Save button");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
            _test.Log(Status.Info, "Verify Promotional Video preview on content details page");
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.SearchCatalog('"' + generalcoursetitle + "TC35375" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + generalcoursetitle + "TC35375" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC35375"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            //Assert.IsTrue(ContentDetailsPage.VerifyPromotionalVideo()); //Verify the Promotional Video is displayed
            //_test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            //ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            //_test.Log(Status.Info, "Clicked Play button of Promotional video");
            //Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            //_test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
           
            //Assert.IsTrue(ContentDetailsPage.PromotionalVideo.isFullScreenIconisdisabled()); //Verify the promotional Video plays on full screen
            //_test.Log(Status.Pass, "Verifyed the promotional Video plays on inline onle");
           

        }
        [Test, Order(13)]
        public void a13_Complete_General_Course_with_surveys_16744()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Survey with Required Status Yes

            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC16744");
            _test.Log(Status.Info, "A new Genaral Course Created");
            Assert.IsTrue(ContentDetailsPage.isSurveyAccordiandisplayed());
            _test.Log(Status.Info, "Verify Survey accordian display on RHS side");
            ContentDetailsPage.Accordians.ClickManage_Survey();
            _test.Log(Status.Info, "Click Survey Manage button");

            SurveysPage.ClickAssignSurveysnew();
            _test.Log(Status.Info, "Click on Assign Surveys Button");

            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");

            SurveysPage.resultgrid.RequiredforFirstSurvey("Yes");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");

            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC16744");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC16744");
            _test.Log(Status.Info, "Click Course Title");
            AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            _test.Log(Status.Info, "Click on Genaral Course title");

            //_test.Log(Status.Info, "Click on open item and Close the window");
            //Assert.IsTrue(Driver.comparePartialString("You must complete any associated surveys before you can obtain and view a certificate.", ContentDetailsPage.getAssociatedMessage()));
            //_test.Log(Status.Pass, "Verify Displayed Message");
            Assert.IsFalse(ContentDetailsPage.IsViewCertificateButtondisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");

            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey("Before Course Start");
            _test.Log(Status.Info, "Complete Survey");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isReviewLinkDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());
            ContentDetailsPage.ContentBanner.clickViewCertificateButton();
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            Driver.focusParentWindow();
           
            #endregion
        }
        [Test, Order(14)]
        public void a14_Learner_General_Course_Overview_56396()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC56396");
            _test.Log(Status.Info, "A new Genaral Course Created");
            ContentDetailsPage.Accordians.ClickEdit_Prerequisites();
            PrerequisitesPage.ClickAddPrerequisites();
            _test.Log(Status.Info, "Click on ADD Prerequisities Button");
            Assert.IsTrue(AddPrerequisitesPage.IsSearchfieldsDisplayed());
            _test.Log(Status.Info, "Verify Search for, Search Type, Type, User Search, Add button, Back button display");
            AddPrerequisitesPage.SearchFor("");
            _test.Log(Status.Info, "Click Search Button, Select One record and click add button");

            Assert.IsTrue(PrerequisitesPage.isPrerequisitesadded());
            _test.Log(Status.Pass, "Verify Prerequisites are added to Curriculumn");
            AddPrerequisitesPage.ClickBackButton();
            DocumentPage.ClickButton_CheckIn();
            #region cretate TA
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "_TC56396");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(GeneralCourseTitle + "_TC56396");
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

            CommonSection.SearchCatalog(GeneralCourseTitle + "_TC56396");
            SearchResultsPage.ClickCourseTitle(GeneralCourseTitle + "_TC56396");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isTrainingAssignmentportletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.TrainingAssignment.isDuedatedisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            TC56397_2 = true;
        }
        
        
        [Test, Order(15)]
        public void a15_Equivalent_Items_to_a_General_Course_27161()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreateLink.GeneralCourse();
            _test.Log(Status.Info, "Goto Content Creation Page");
            GeneralCoursePage.CreateGeneralCourse(generalcoursetitle + "TC27161", generalcoursetitle + "TC27161");
            _test.Log(Status.Info, "Content Created");
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
            DocumentPage.ClickButton_CheckIn();
            CommonSection.SearchCatalog(generalcoursetitle + "TC27161");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC27161");
            Assert.IsTrue(ContentDetailsPage.ReviewsTab.idEquvalenciesPortletDisplay());
            TC56397_1 = true;
        }
        [Test, Order(16)]
        public void a16_Learner_General_Course_Overview_Related_content_56397()
        {
            Assert.IsTrue(TC56397_1); //AC1
            Assert.IsTrue(TC56397_2); //AC2

        }
    }


}


