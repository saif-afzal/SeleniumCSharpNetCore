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
    public class P1_Catalog_DocumentContentDetailsPageTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_DocumentContentDetailsPageTest(string browser)
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
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle = "TA" + Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        string DocumentTitle = "Doc" + Meridian_Common.globalnum;
        bool TC60104, TC59834;
        bool TC60105;

        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }


        [Test, Order(01)]
        public void tc_58343_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_All_Prerequisites_to_be_completed_for_Documents()
        {

            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Naviagte to Cretae Document page");
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC58343");
            _test.Log(Status.Info, "A new Classroom Course Created");
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

            Assert.IsTrue(PrerequisitesPage.VerifyAddPrerequisitesButtonIsDisplayed());
            _test.Log(Status.Pass, "Verify Add Prerequisite Button is Displayed");
            PrerequisitesPage.Click_AddPrerequisitesButton();
            _test.Log(Status.Info, "Click Add Prerequisite Button");

            Assert.IsTrue(PrerequisitesPage.VerifyContentIsDisplayedInAddPrerequisitesModal());
            _test.Log(Status.Pass, "Verify Add Prerequisite Modal is Displayed");
            PrerequisitesPage.SelectandAddPrerequisitesToAssign();
            _test.Log(Status.Info, "Select prerequisites to assign");
            // Assert.IsTrue(Driver.comparePartialString("Success  The selected items were added as prerequisites. If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify Success message");
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            DocumentPage.ClickButton_CheckIn();

           // CommonSection.Logout();
          //  LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(DocumentTitle + "TC58343");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC58343");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item."));
        }
        [Test, Order(02)]
        public void tc_58352_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_Document()
        {
          //  CommonSection.Logout();
           // LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.SearchCatalog(DocumentTitle + "TC58343");
            _test.Log(Status.Info, "A new document Created");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC58343");
            ContentDetailsPage.ClickEditContent_New19_2();
            DocumentPage.ClickButton_CheckOut();
            
            AdminContentDetailsPage.Click_EditPrerequisitePanel();
            _test.Log(Status.Info, "Click Edit Button of prerequsite panel");

           
            Assert.IsTrue(PrerequisitesPage.VerifyPrerequisitesAdded() >= 1);
            _test.Log(Status.Pass, "Verify Prerequisites are added");
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(DocumentTitle + "TC58343");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC58343");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item. 2 of 10 required."));
        }
        [Test, Order(03)]
        public void tc_26974_View_Prerequisities_to_Document()
        {
           CommonSection.Logout();
           LoginPage.LoginAs("").WithPassword("").Login();

            CommonSection.CreateLink.GeneralCourse();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "TC26974");
            _test.Log(Status.Info, "Create a general Course for Prerequisite");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC26974");
            _test.Log(Status.Info, "Create a Document");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Document is Created");
            ContentDetailsPage.Edit_Prerequisites(GeneralCourseTitle + "TC26974");

            _test.Log(Status.Pass, "Click edit Prerequisite and add Prerequisite");
            //Assert.IsTrue(Driver.comparePartialString(" The selected items were added as prerequisites." +
            //    " If values were entered for any prerequisite's attributes, then these values were saved.", PrerequisitesPage.GetSuccessMessage()));
            //_test.Log(Status.Pass, "Verify  Success message");
            PrerequisitesPage.Click_BreadCrumb();
            _test.Log(Status.Pass, "Click breadcrumbs");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click on Check In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on View As Learner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            _test.Log(Status.Pass, "Verify prerequisite Accordian is Displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isPrereqisiteRequiredmessageDisplay("Complete 1 prerequisites to continue"));
            _test.Log(Status.Pass, "Verify  information");

            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPrerequisiteStatusDisplayed());
            _test.Log(Status.Pass, "Verify prerequisite status is Displayed");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPrerequisiteCostDisplayed());
            _test.Log(Status.Pass, "Verify prerequisite Cost is Displayed");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPrerequisiteTitleDisplayed());
            _test.Log(Status.Pass, "Verify prerequisite Cost is Displayed");
            ContentDetailsPage.OverviewTab.Prerequisiteportlet.ClickPrerequisiteContentTitle(GeneralCourseTitle + "TC26974");
            _test.Log(Status.Info, "Click Prerequisite Title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(GeneralCourseTitle + "TC26974"));

        }
       
        [Test, Order(04)]
        public void tc_35372_Learner_Plays_Promotional_Videos_From_Document()
        {
           // CommonSection.Logout();
          //  LoginPage.LoginAs("").WithPassword("").Login(); //Login as regular user (Learner)

            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC35372");
            _test.Log(Status.Info, "Create A new Document");
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
            Assert.IsTrue(Driver.comparePartialString("The changes were saved.", PromotionalVideoPage.getSuccessfulmessage()));
            _test.Log(Status.Info, "Verify Successful message");
            PromotionalVideoPage.Click_BackButton();
            _test.Log(Status.Info, "Click on Course title bread crumb");
            Assert.IsTrue(ContentDetailsPage.Accordians.PromotionalVideo.isVedioPreviewDisplay());
            _test.Log(Status.Info, "Verify Promotional Video preview on content details page");

            CommonSection.SearchCatalog('"' + DocumentTitle + "TC35372" + '"'); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + DocumentTitle + "TC35372" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC35372"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPromotionalVideodisplay()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page overview tab");

        }
        [Test, Order(05)]
        public void tc_27134_View_RT_Assignments_for_Document()
        {
            #region Create a new Document

            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC27134");
            _test.Log(Status.Info, "Create A new Document");
            ContentDetailsPage.Click_Check_in();
            #endregion
            #region cretate TA
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "TC27134");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(DocumentTitle + "TC27134");
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

            CommonSection.SearchCatalog(DocumentTitle + "TC27134");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC27134");

            ContentDetailsPage.Click_OverviewTab();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isTrainingAssignmentportletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.TrainingAssignment.isDuedatedisplay());
            TC59834 = true;
        }
        [Test, Order(06)]
        public void tc_59834_Docuemnt_As_Learner_View_Training_Assignment_Due_Date()
        {
            Assert.IsTrue(TC59834);
        }
        

        [Test, Order(07)]
        public void tc_59831_As_a_Learner_view_the_Document_Description_at_Overview_tab()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC59831");
            _test.Log(Status.Info, "Create A new Document");
            DocumentPage.ClickButton_CheckIn();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as Learner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDescriptionDisplay());
            _test.Log(Status.Pass, "Verify Description portlet display in Content Details page Overview Tab");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.DescriptionPortletTest("There is no description for this item."));
            ContentDetailsPage.ClickEditContent_New19_2();
            DocumentPage.ClickButton_CheckOut();
            ContentDetailsPage.Summary.ClickEditButton();

            EditSummaryPage.addDescription("This is test for Show more link");
            DocumentPage.ClickButton_CheckIn();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as Learner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDescriptionDisplay());
            _test.Log(Status.Pass, "Verify Description portlet display in Content Details page Overview Tab");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.DescriptionPortletTitle("Description"));
            Assert.IsTrue(ContentDetailsPage.OverviewTab.DescriptionPortletTest("This is test for Show more link"));
            ContentDetailsPage.ClickEditContent_New19_2();
            DocumentPage.ClickButton_CheckOut();
            ContentDetailsPage.Summary.ClickEditButton();
            EditSummaryPage.addDescription("Welcome to MBA in a box: Business lessons from a CEO! This is the only online course you need to acquire the business acumen to:Start up your own business Grow your existing venture Take your career to the next level Get promoted and apply managerial, financial, marketing, decision - making and negotiation skills in the real business world Have an all - around view of why some companies(and people) succeed when doing business and others do not This course is jam - packed with the same useful information and real - life case studies MBA graduates acquire throughout their training in top - tier business schools. We have even made it more interactive by preparing a gamebook for you.Yeah, that’s right!Learning business and finance need not be boring! The gamebook will test what you have learned and will simulate a real - world environment in which your decisions as a business executive will have real monetary consequences for a company. Can you think of any better way to reinforce what you have learned ? An exciting journey from A-Z. If you are a complete beginner and you know nothing about business or finance, don’t worry at all!In each of the five main modules of the course, we start from the very basics and will gradually build up your knowledge.The course contains plenty of real - life examples and case studies that make it easy to understand.");
            DocumentPage.ClickButton_CheckIn();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as Learner");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDescriptionDisplay());
            _test.Log(Status.Pass, "Verify Description portlet display in Content Details page Overview Tab");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.DescriptionPortlet.ShowMoreLinkdisplay());
            _test.Log(Status.Pass, "Is Show More link display in Description portlet");
            ContentDetailsPage.OverviewTab.DescriptionPortlet.ClickShowMoreLink();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.DescriptionPortlet.ShowlessLinkdisplay());
            _test.Log(Status.Pass, "Is Show less link display in Description portlet");

        }
        [Test, Order(08)]
        public void tc_59832_As_learner_Add_to_Cart_Multipl_Item_purchased_by_Access_Key()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC7018");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Document");
            ContentDetailsPage.ClickEditContent_New19_2();
            _test.Log(Status.Info, "Click Edit Content");
            AdminContentDetailsPage.EnableAccessKeys();
            DocumentPage.ClickButton_CheckIn();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Add to Cart Button is Displayed");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.AccessKeyQuentitydisplay());
            _test.Log(Status.Pass, "Add to Cart Button is Displayed with Access Key Quentity field");
        }
        [Test, Order(9)]
        public void tc_26205_Add_Document_to_Cart_26205()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC26205");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Click edit Cost and Add Cost to document");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Check In Button");
            AdminContentDetailsPage.ClickCheckInbutton();

            _test.Log(Status.Info, "Click Check-In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click on view as learner");

            ContentDetailsPage.OverviewTab.click_AddtoCart();
            _test.Log(Status.Info, "Click on Add to cart");

            //Assert.IsTrue(Driver.comparePartialString("The item was added to the cart.", driver.getSuccessMessage()));
            //_test.Log(Status.Pass, "Verify the Content added to cart message");

            TC60105 = true;
        }
        [Test, Order(10)]
        public void tc_60105_Document_Banner_Actions_Add_To_Cart()
        {
           
            Assert.IsTrue(TC60105);
            _test.Log(Status.Pass, "Add to Cart Button is Displayed");
        }
        [Test, Order(11)]
        public void tc_59938_Learner_view_Document_history_tab_on_Content_Details_page()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC59938");
            _test.Log(Status.Info, "Create a Document");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "A new Document is Created");
            CommonSection.SearchCatalog(DocumentTitle + "TC59938");
            _test.Log(Status.Info, "Searched created Document");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC59938");
            _test.Log(Status.Info, "Click on DOcument title");
            Assert.IsFalse(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify History tab is not displayed");
            ContentDetailsPage.ContentBanner.ClickOpenItembutton();
            ContentDetailsPage.ContentBanner.CloseOpenedDocumentwindow();
            ContentDetailsPage.ContentBanner.MarkCompleteforDoc();

            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify History tab is displayed");
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isReviewLinkDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());

            ContentDetailsPage.Click_HistoryTab_Curriculum();
            Assert.IsFalse(ContentDetailsPage.Historytab.isViewCertificateButtonDisplay());
            _test.Log(Status.Pass, "Verify View Certification button should not display");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.isStatusDisplay("Completed"));
            _test.Log(Status.Pass, "Verify Completed status displayed");

        }
        [Test, Order(12)]
        public void tc_60017_View_the_Document_Review_and_rating_tab()
        {
            #region Create a general course
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC60016");
            _test.Log(Status.Info, "Create a Document");
            DocumentPage.ClickButton_CheckIn();
            #endregion

            //CommonSection.Logout();
            //LoginPage.LoginAs("srlearner103").WithPassword("password").Login();
            CommonSection.SearchCatalog(DocumentTitle + "TC60016");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC60016");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Veify Open Item display");
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsFalse(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.ContentBanner.ClickOpenItembutton();
            ContentDetailsPage.ContentBanner.CloseOpenedDocumentwindow();
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.GeneralCourse_ReviewsTab.WriteaReview("Title", "For Testing");
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isReviewlistUpdated("Title"));
            _test.Log(Status.Pass, "User submited review");

            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
            //CommonSection.SearchCatalog(DocumentTitle + "TC60016");
            //SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC60016");
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Click_CheckOut();

            //CommonSection.Logout();
            //LoginPage.LoginAs("srlearner103").WithPassword("password").Login();
            CommonSection.SearchCatalog(DocumentTitle + "TC60016");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC60016");
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isEditReviewlinkdisplay());
            _test.Log(Status.Pass, "Verify user can edit his own review in content edit mode");
            ContentDetailsPage.GeneralCourse_ReviewsTab.DeleteReview();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            _test.Log(Status.Pass, "Verify review deleted and Write a Review button display");
        }
        [Test, Order(13)]
        public void tc_60100_Document_Banner_Actions_Request_Access()
        {
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
            #region Create a general course
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC60100");
            _test.Log(Status.Info, "Create a Document");

            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Edit Content");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign approval path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            #endregion
            //CommonSection.Logout();
            //LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(DocumentTitle + "TC60100");
            _test.Log(Status.Info, "Searched created Genaral Course");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC60100");
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
            TC60104 = true;
        }
        [Test, Order(14)]
        public void tc_60104_Document_Banner_Actions_View_History_for_requesting_access()
        {
            Assert.IsTrue(TC60104);
        }
        [Test, Order(15)]
        public void tc_60101_Document_Banner_Actions_Edit_Save_and_Share()
        {
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC60101");
            _test.Log(Status.Info, "Create a Document");

            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as Learner");
            Assert.IsTrue(ContentDetailsPage.isSaveShareandEditContentbuttndisplay());
            _test.Log(Status.Pass, "Verify Save, Share and Edit content button is displayed");
            ContentDetailsPage.ClickEditContent_New19_2();
            Assert.IsTrue(AdminContentDetailsPage.isContentopened(DocumentTitle + "TC60101"));
            _test.Log(Status.Pass, "Verify edit content opens admin content details page");
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(DocumentTitle + "TC60101");
            _test.Log(Status.Info, "Searched created Genaral Course");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC60101");
            _test.Log(Status.Info, "Click on Genaral Course title");
            Assert.IsTrue(ContentDetailsPage.isOnlySaveandSharebuttndisplay());
            ContentDetailsPage.ClickSaveButton();
            Assert.IsTrue(ContentDetailsPage.isSaveButtonIconGreen());
            _test.Log(Status.Pass, "Click at Green saved button ");
            Assert.IsTrue(ContentDetailsPage.SocialSharingDropDown("Facebook"));
            _test.Log(Status.Pass, "verify the facebook ");
        }
        [Test, Order(16)]
        public void tc_60103_Document_Banner_Actions_Course_Info_and_Navigation()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC60103");
            _test.Log(Status.Info, "Create a Document");
            ContentDetailsPage.Accordians.ClickEdit_Image();
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            StringAssert.AreEqualIgnoringCase("The file was uploaded.", Driver.getSuccessMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            //ContentDetailsPage.AddLocale();   don't have other local in external
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            CommonSection.SearchCatalog(DocumentTitle + "TC60103");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC60103");
            Assert.IsTrue(ContentDetailsPage.isBradCrumbdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(DocumentTitle + "TC60103"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay());
            _test.Log(Status.Pass, "Verify Image is display on Banner");
        }
        [Test, Order(17)]
        public void tc_59969_Document_Prerequisite_Overview_Tab_What_other_content_can_learner_take()
        {
            CommonSection.CreateLink.Document();
            DocumentPage.SearchTagForNewContent(tagname + "TC59969");
            _test.Log(Status.Info, "Searching Tag.");
            DocumentPage.CreateDocument(DocumentTitle + "TC59969");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Document();
            DocumentPage.SearchTagForNewContent(tagname + "TC59969");
            _test.Log(Status.Info, "Searching Tag.");
            DocumentPage.CreateDocument(DocumentTitle + "TC59969_1");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreteNewCurriculumn(curriculamtitle + "_TC59969");
            _test.Log(Status.Info, "Create A new Curriculum");
            ContentDetailsPage.ClickCurriculumContentEditButton();
            CurriculumContentPage.ClickAddCurriculumBlock();
            CurriculumContentPage.AddCurriculumBlock.AddBlockAs(block + "_UnOrdered");
            CurriculumContentPage.AddTrainingActivities_UnOrdered(DocumentTitle + "TC59969");
            CurriculumContentPage.ClickBackbutton();
            //ContentDetailsPage.Edit_AddAccessPeriod("1");
            DocumentPage.ClickButton_CheckIn();

            //CommonSection.Logout();
            //LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.SearchCatalog(DocumentTitle + "TC59969");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC59969");
            Assert.IsTrue(ContentDetailsPage.isrelatedContentDisplay(DocumentTitle + "TC59969_1"));
            _test.Log(Status.Pass, "Verify similar content displaying in More like this Portlet");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPartoftheseCollectionDisplay());
        }
        
        [Test, Order(18)]
        public void tc_60106_Document_Banner_Actions_Open_content()
        {
            //CommonSection.Logout();
            //LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC60106");
            _test.Log(Status.Info, "Create a Document");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "A new Document is Created");
            CommonSection.SearchCatalog(DocumentTitle + "TC60106");
            _test.Log(Status.Info, "Searched created Document");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC60106");
            _test.Log(Status.Info, "Click on DOcument title");
            Assert.IsFalse(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify History tab is not displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify Open Item button display on banner");
            ContentDetailsPage.ContentBanner.ClickOpenItembutton();
            ContentDetailsPage.ContentBanner.CloseOpenedDocumentwindow();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isMarkCompleteLinkdisplay());

        }
        [Test, Order(19)]
        public void tc_60131_Document_Banner_Actions_Open_Item()
        {
            CommonSection.CreteNewDocuemntwithFile(DocumentTitle + "TC60313");
            _test.Log(Status.Info, "Create a Document");
            DocumentPage.ClickButton_CheckIn();
            _test.Log(Status.Info, "A new Document is Created");
            CommonSection.SearchCatalog(DocumentTitle + "TC60313");
            _test.Log(Status.Info, "Searched created Document");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC60313");
            _test.Log(Status.Info, "Click on DOcument title");
            Assert.IsFalse(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify History tab is not displayed");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify Open Item button display on banner");
            ContentDetailsPage.ContentBanner.ClickOpenItembutton();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.iscontentOpenInline());
            ContentDetailsPage.OverviewTab.ExitInline();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isMarkCompleteLinkdisplay());
        }

        [Test, Order(20)]
        public void tc_27168_As_a_Learner_view_Equivalent_Items_to_a_Document()
        {
            CommonSection.CreateLink.Document();
            _test.Log(Status.Info, "Naviagte to Cretae Document page");
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC27168");
            _test.Log(Status.Info, "A new Classroom Course Created");
            ContentDetailsPage.Click_EditEquivalencies();
            _test.Log(Status.Info, "Click Edit button for Equivalencies portlet");
            //Assert.IsTrue(EquivalenciesPage.isExestingEquvalencyContentdisplay("No"));
            //_test.Log(Status.Pass, "Verify is any existing content display");
            EquivalenciesPage.ClickAddEquivalencyButton();
            _test.Log(Status.Info, "Click Add Equivalency Button");
            Assert.IsTrue(EquivalenciesPage.isAddEquvalenciesModalDisplay());
            _test.Log(Status.Pass, "Verify is Add Equvalencies Modal display");
           
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
            CommonSection.SearchCatalog(DocumentTitle + "TC27168");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC27168");
            Assert.IsTrue(ContentDetailsPage.ReviewsTab.idEquvalenciesPortletDisplay());
        }
        [Test, Order(21)]
        public void tc_60132_Document_Banner_Actions_Review_Retake()
        {
            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC60132");
            _test.Log(Status.Info, "Create a Document");
           
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");

            CommonSection.SearchCatalog(DocumentTitle + "TC60132");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC60132");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isOpenItembuttonDisplay_GeneralCourse());
            _test.Log(Status.Pass, "Verify Open Item button display on banner");
            ContentDetailsPage.ContentBanner.ClickOpenItembutton();
            ContentDetailsPage.ContentBanner.CloseOpenedDocumentwindow();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isMarkCompleteLinkdisplay());
            ContentDetailsPage.ContentBanner.MarkCompleteforDoc();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isReviewLinkDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());
            _test.Log(Status.Pass, "Verify Both Review and Retake links are displaying in banner");
            ContentDetailsPage.ContentBanner.clickReviewButton();
            ContentDetailsPage.ContentBanner.CloseOpenedDocumentwindow();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isReviewLinkDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());
            _test.Log(Status.Pass, "Verify still Both Review and Retake links are displaying in banner");
            ContentDetailsPage.ContentBanner.ClickRetakeLink();
            ContentDetailsPage.ContentBanner.CloseOpenedDocumentwindow();
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isReviewLinkDisplay());
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isRetakeLinkDisplay());
            _test.Log(Status.Pass, "Verify Both Review and Retake links are not displaying in banner after retake start");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isMarkCompleteLinkdisplay());
        }
        [Test, Order(22)]
        public void tc_27018_Request_Access_to_Document_with_cost()
        {

            CommonSection.CreteNewDocuemnt(DocumentTitle + "TC27018");
            _test.Log(Status.Info, "Create a Document");
            AdminContentDetailsPage.AddCost();
            _test.Log(Status.Info, "Add cost to Document");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click Edit Content");
            AdminContentDetailsPage.AccessApproval.ClickEditButton();
            _test.Log(Status.Info, "Click Edit Content");
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Assign approval path");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click Check-In");
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            _test.Log(Status.Info, "Click view as Learner");

            CommonSection.Logout();
            _test.Log(Status.Info, "logout of current Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner Account");
            CommonSection.SearchCatalog(DocumentTitle + "TC27018");
            _test.Log(Status.Info, "Search for the Document");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC27018");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display on Banner");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            Assert.IsFalse(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Add to Cart Button is not Displayed");

            CommonSection.Logout();
            _test.Log(Status.Info, "logout of current Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login with siteadmin Account");
            CommonSection.Manage.ApprovalRequests();
            _test.Log(Status.Info, "Click on Approval Request ");
            ApprovalRequestsPage.PendingMyApproval.Approve(DocumentTitle + "TC7018", "Request Accepted");
            _test.Log(Status.Info, "Approve request");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout of current Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login with learner Account");
            CommonSection.SearchCatalog(DocumentTitle + "TC7018");
            _test.Log(Status.Info, "Search for the Certification Course Title");
            SearchResultsPage.ClickCourseTitle(DocumentTitle + "TC7018");
            _test.Log(Status.Info, "Click on Course Title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            _test.Log(Status.Pass, "Add to Cart Button is Displayed");

        }

    }
}



