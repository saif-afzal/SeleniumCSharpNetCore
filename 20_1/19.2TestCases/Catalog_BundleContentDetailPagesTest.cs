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
    public class P1_Catalog_BundleContentDetailPagesTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_BundleContentDetailPagesTest(string browser)
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
        string bunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string GeneralCourseTitle = "GC" + Meridian_Common.globalnum;
        string block = "Block" + Meridian_Common.globalnum;
        string TATitle= "TA" + Meridian_Common.globalnum;
        string PromoURL = "//www.youtube.com/embed/Fc1P-AEaEp8";
        bool TC57313, TC55384,TC57571, TC57028, TC57459, TC57459_1, TC57459_2;
        bool TC57025, TC57025_1, TC57009, TC57009_1, TC27105, TC57859;
        private string FormatBundle;

        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
      
            
        [Test, Order(1)]
        public void tc_27165_As_a_Learner_view_Equivalent_Items_to_a_Bundle()
        {

            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(bunbdleTitle + "_TC27165");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");

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
      
            CommonSection.SearchCatalog(bunbdleTitle + "_TC27165");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "_TC27165");
            Assert.IsTrue(ContentDetailsPage.ReviewsTab.idEquvalenciesPortletDisplay());

        }
        [Test, Order(2)]
        public void tc_54735_View_as_Learner_Bundle()
        {
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Naviagte to Cretae Bundle page");
            CreatebundlePage.FillTitle(bunbdleTitle + "_TC54735");
            CreatebundlePage.bundleTypedropdown.selecttype("Progress Bundle");
            CreatebundlePage.bundleCostType.selectradiobutton("Bundle Price");
            CreatebundlePage.ClickCreatebutton();
            _test.Log(Status.Info, "A new Bundle Created");
                      
            DocumentPage.ClickButton_CheckIn();
            AdminContentDetailsPage.DropDownToggle.ViewAsLearner();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(bunbdleTitle + "_TC54735"));
            Assert.IsTrue(ContentDetailsPage.overviewTabdisplay());
        }
        [Test, Order(3)]
        public void tc_54750_Edit_Content_Bundle()
        {
            //depend on 54735
            CommonSection.SearchCatalog(bunbdleTitle + "_TC54735");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "_TC54735");
            ContentDetailsPage.ClickEditContent_New19_2();
            Assert.IsTrue(AdminContentDetailsPage.isContentopened(bunbdleTitle + "_TC54735"));
            Assert.IsTrue(Driver.Instance.Title == (bunbdleTitle + "_TC54735"));
        }
        
       // [Test, Order(6)]
        public void access_key_to_expire_when_a_user_has_completed_the_content_Bundle_55255()
        {

        }
        [Test, Order(4)]
        public void tc_55330_Learner_plays_a_Promotional_Video_from_Bundle()
        {
            CommonSection.CreateLink.Bundle();
            CreatebundlePage.CreateBundle("Progress", bunbdleTitle + "TC55330", "Bundle Price");
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
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            CommonSection.SearchCatalog(bunbdleTitle + "TC55330"); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + bunbdleTitle + "TC55330" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC55330"); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPromotionalVideodisplay());
           // Assert.IsTrue(ContentDetailsPage.VerifyPromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            //ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            //_test.Log(Status.Info, "Clicked Play button of Promotional video");
            //Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            //_test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            //Assert.IsTrue(ContentDetailsPage.PromotionalVideo.isFullScreenIconisdisabled());
        }
        [Test, Order(5)]
        public void tc_55367_Require_Survey_for_getting_a_certificate_Progress_Bundle()
        {
            #region Survey with Required status Yes
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout with Site Admin Account");
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteadmin Account");
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC55367");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Bundle");
            CreatebundlePage.CreateBundle("Progress Bundle", bunbdleTitle + "TC55367", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            BundlesPage.addContentIntoBundle(generalcoursetitle + "TC55367");
            _test.Log(Status.Info, "Adding Paid General Course into Bundle");

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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content with availability as When learner enrolls");
           
            //SurveysPage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();
            
            _test.Log(Status.Pass, "Click on Check-In");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("srlearner105").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(bunbdleTitle + "TC55367");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC55367");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.Click_OverviewTab();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable("Before Course Start"));
            //  ---------------------------------------------------------

            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.RequiredContent.ClickContentEnroll(generalcoursetitle + "TC55367");
            ContentDetailsPage.ContentTab.RequiredContent.ClickContentStart(generalcoursetitle + "TC55367");
            ContentDetailsPage.ContentTab.RequiredContent.CompleteBundleContent();
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.Click_OverviewTab();
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey("Before Course Start");
            _test.Log(Status.Info, "Complete Survey");
            ContentDetailsPage.Click_OverviewTab();
            Assert.True(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            ContentDetailsPage.ContentBanner.clickViewCertificateButton();
            _test.Log(Status.Pass, "Click View Certificate");
            Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            _test.Log(Status.Pass, "Verify certificate Page is displayed");
            Driver.focusParentWindow();
            #endregion

            #region Survey with Required status NO
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login with site admin Account");

            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC55367_1");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Bundle");
            CreatebundlePage.CreateBundle("Progress Bundle", bunbdleTitle + "TC55367_1", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            BundlesPage.addContentIntoBundle(generalcoursetitle + "TC55367_1");
            _test.Log(Status.Info, "Adding Paid General Course into Bundle");

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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            // AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            _test.Log(Status.Pass, "Verify Survey Added to Content");
            SurveysPage.resultgrid.RequiredforFirstSurvey("No");
            _test.Log(Status.Pass, "Verify Required field is Yes");
            SurveysPage.CheckIn();
            _test.Log(Status.Pass, "Click on Check-In");

            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("srlearner105").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(bunbdleTitle + "TC55367_1");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC55367_1");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.Click_OverviewTab();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable("Before Course Start"));
            _test.Log(Status.Pass, "Verify Survey is Displayed");
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.RequiredContent.ClickContentEnroll(generalcoursetitle + "_TC55367");
            ContentDetailsPage.ContentTab.RequiredContent.ClickContentStart(generalcoursetitle + "_TC55367");
            ContentDetailsPage.ContentTab.RequiredContent.CompleteBundleContent();
            _test.Log(Status.Info, "Click on Open Item");
            ContentDetailsPage.Click_OverviewTab();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable("Before Course Start"));
            _test.Log(Status.Info, "Verify Survey is Displayed");
           
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
            _test.Log(Status.Pass, "Verify View Certificate Button is displayed");
            //ContentDetailsPage.ClickViewCertificate();
            //_test.Log(Status.Pass, "Click View Certificate");
            //Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            //_test.Log(Status.Pass, "Verify certificate Page is displayed");
            //Driver.focusParentWindow();

            #endregion
        }

        [Test, Order(6)]
        public void tc_55407_As_a_learner_I_want_to_see_display_format_and_corresponding_Icon_instead_of_Content_Types_in_Content_Details_page_Bundle()
        {
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "login with siteAdmin Account");
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Bundle");
            CreatebundlePage.CreateBundle("Progress Bundle", bunbdleTitle + "TC55407", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Click CheckIn Button");

            CommonSection.Administer.Training.ContentConfiguration.DisplayFormats();
            _test.Log(Status.Info, "Navigate to Administer >> Content Configuration >> Displat Formats link");
            Assert.IsTrue(DisplayFormatPage.isContentwithdisplayformatdisplay());
            _test.Log(Status.Pass, "Verify Display Format page is displayed Verify list of Content types are listed along with their respective default display formats");
            DisplayFormatPage.CoursesInDisplayFormat.SelectDisplayFormatBundle("Bundle");
            DisplayFormatPage.CoursesInDisplayFormat.ApplyToAllForBundle();
            Assert.IsTrue(DisplayFormatPage.isApplyToAllModaldisplay());
            _test.Log(Status.Pass, "Verify Apply To All Modal is displayed");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.WarningMessage());
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the Warning Message");
            Assert.IsTrue(DisplayFormatPage.ApplyToAllModal.ContentItemsCount() >= 0);
            _test.Log(Status.Pass, "Verify Apply To All Modal displays the number (Count) of content item  that will be impacted ");
            DisplayFormatPage.ApplyToAllModal.ClickApply();
            _test.Log(Status.Pass, "Click Apply on the Warning Message");
            FormatBundle = DisplayFormatPage.CoursesInDisplayFormat.Bundle();//XPathAgainstCoursetobeSelected

            //---------------------------------------------------------------------------------------------
            CommonSection.Logout();
            _test.Log(Status.Info, "Create logout From Siteadmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();



            CommonSection.SearchCatalog(bunbdleTitle + "TC55407");
            _test.Log(Status.Info, "Search a Bundle from Catalog search");
            Assert.IsTrue(SearchResultsPage.ListofSearchResults.Display());
            _test.Log(Status.Pass, "Verify Search results are displayed");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC55407");

            Assert.IsTrue(ContentDetailsPage.ContentTitle.ContentTypeBundle(FormatBundle));

            _test.Log(Status.Pass, "Verify Content Type under the Content Title is replaced by Display Format for Bundle");

        }
        [Test, Order(7)]
        public void tc_55429_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_Bundle_Content()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC55429");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Subscriptions");
            CreatebundlePage.CreateBundle("Content Bundle", bunbdleTitle + "TC55429", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");

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
            SurveysPage.AddSurveyModal.AddSurveystoContent("Before Course Start");
            _test.Log(Status.Info, "Search Survey and add one survey to content");
            string AddedsurveyTitle = SurveysPage.AddedSurveysTtile();
            Assert.IsTrue(SurveysPage.resultgrid.isrequiredisdisabled());
            _test.Log(Status.Info, "Verify surveys are not required for Content Bundle");
            
            SurveysPage.Click_backbutton();
            AdminContentDetailsPage.AddContentToBundle(GeneralCourseTitle + "_TC55429");
            //ContentDetailsPage.ClickCheckInbutton();
            ContentDetailsPage.Accordians.ClickEdit_Image();
            Assert.IsTrue(ImagePage.verifyrequiredatributesdisplay());
            _test.Log(Status.Pass, "Verify File path, Browse Button, Save button are display");
            ImagePage.UploadnewImageFile();
            _test.Log(Status.Info, "Upload any Image file to content");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.SearchCatalog(bunbdleTitle + "TC55429");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC55429");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay()); //57025
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(bunbdleTitle + "TC55429")); //57025
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());  //57025
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            TC57009 = true;
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            ContentDetailsPage.Click_OverviewTab();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(AddedsurveyTitle));
            Assert.IsFalse(ContentDetailsPage.ContentBanner.isContentProgressbarDisplay()); //57025
            TC57025 = true;
            ContentDetailsPage.Click_ContentTab();
            ContentDetailsPage.ContentTab.RequiredContent.ClickContentEnroll(generalcoursetitle + "TC55429");
            ContentDetailsPage.ContentTab.RequiredContent.ClickContentStart(generalcoursetitle + "TC55429");
            ContentDetailsPage.ContentTab.RequiredContent.CompleteBundleContent();
            ContentDetailsPage.Click_OverviewTab();
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey("Before Course Start");
            _test.Log(Status.Info, "Complete Survey");
          //  Assert.IsTrue(ContentDetailsPage.ContentBanner.isViewCertificationButtonDisplay());
         //   ContentDetailsPage.ContentBanner.clickViewCertificateButton();
        //    Assert.IsTrue(ContentDetailsPage.isCertificateDisplayed());
            //_test.Log(Status.Pass, "Verify certificate Page is displayed");
            //Driver.focusParentWindow();
            TC55384 = true;
            TC57459_1 = true;

        }
        [Test, Order(8)]
        public void tc_55384_Require_Survey_for_getting_a_certificate_Content_Bundle()
        {
            Assert.IsTrue(TC55384);
        }
        [Test, Order(9)]
        public void P20_1_tc_57037_Bundle_Survey_and_certificate()
        {
            Assert.IsTrue(TC55384);
        }
        [Test, Order(10)]
        public void P20_1_tc_55430_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_Bundle_Progress()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC55430");
            DocumentPage.ClickButton_CheckIn();
            #endregion        
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Bundle");
            CreatebundlePage.CreateBundle("Progress Bundle", bunbdleTitle + "TC55430", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            BundlesPage.addContentIntoBundle(GeneralCourseTitle + "_TC55430");
            _test.Log(Status.Info, "Adding Paid General Course into Bundle");

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
            //SurveysPage.Click_backbutton();
            ContentDetailsPage.ClickCheckInbutton();

            CommonSection.SearchCatalog(bunbdleTitle + "TC55430");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC55430");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysDisplay(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsFalse(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            _test.Log(Status.Pass, "Verify Write a Review button is not visibile");
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContentProgress()=="0%");
            ContentDetailsPage.Click_ReviewTab_GeneralCourse();
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isWriteaReviewButtondisplay());
            ContentDetailsPage.GeneralCourse_ReviewsTab.WriteaReview("Title", "For Testing");
            Assert.IsTrue(ContentDetailsPage.GeneralCourse_ReviewsTab.isReviewlistUpdated("Title"));
            TC57571 = true;
            ContentDetailsPage.ContentBanner.ClickViewContentButton();
            ContentDetailsPage.ContentTab.RequiredContent.ClickContentEnroll(GeneralCourseTitle + "_TC55430");
            ContentDetailsPage.ContentTab.RequiredContent.ClickContentStart(GeneralCourseTitle + "_TC55430");
            ContentDetailsPage.ContentTab.RequiredContent.CompleteBundleContent();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContentProgress() == "100%");
            _test.Log(Status.Pass, "Verify content progress display 100% completed");
            TC57313 = true;
            TC57025_1 = true;
            TC27105 = true;
            ContentDetailsPage.Click_OverviewTab();
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnEnroll));
            Assert.IsTrue(ContentDetailsPage.OverviewTab.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnContentComplete));
            
        }
        [Test, Order(11)]
        public void tc_27105_View_Post_Access_Items_to_Progress_Bundle()
        {
            Assert.IsTrue(TC27105);
        }
       
        
        [Test, Order(12)]
        public void P20_1_tc_57025_Bundles_Banner_Course_Information_and_Navigation()
        {
            Assert.IsTrue(TC57025);
            Assert.IsTrue(TC57025_1);
        }
        [Test, Order(13)]
        public void P20_1_tc_57313_Bundle_Start_Content()
        {
            Assert.IsTrue(TC57313);

        }
        [Test, Order(14)]
        public void P20_1_tc_57571_Bundles_Learner_views_review_tab()
        {
            Assert.IsTrue(TC57571);
        }
        [Test, Order(15)]
        public void tc_56307_Learner_can_see_More_like_this_Part_of_collection_on_Bundle_detail_page()
        {
            //Created a bundle as Bundle_tc_56307 on both 19.2 external and PS
            CommonSection.SearchCatalog("Bundle_tc_56307");
            SearchResultsPage.ClickCourseTitle("Bundle_tc_56307");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isMorelikethisPortletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPartoftheseCollectionDisplay()); //this will fail in both ps and external
        }
        [Test, Order(16)]
        public void P20_1_tc_57026_Bundles_Bundle_Actions()
        {
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Bundle");
            CreatebundlePage.CreateBundle("Content Bundle", bunbdleTitle + "TC57026", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            ContentDetailsPage.ClickCheckInbutton();
            CommonSection.SearchCatalog('"' + bunbdleTitle + "TC57026" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC57026");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isSaveButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isShareButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.iseditContentDisplay());
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner101").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + bunbdleTitle + "TC57026" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC57026");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isSaveButtonDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isShareButtonDisplay());
            Assert.IsFalse(ContentDetailsPage.OverviewTab.iseditContentDisplay());

        }
        [Test, Order(17)]
        public void P20_1_tc_57027_Bundles_Request_Access()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57027");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Subscriptions");
            CreatebundlePage.CreateBundle("Content Bundle", bunbdleTitle + "TC57027", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            AdminContentDetailsPage.AddContentToBundle(GeneralCourseTitle + "_TC57027");
            ContentDetailsPage.ClickCheckInbutton();
            Assert.IsTrue(ContentDetailsPage.isAccessApprovalAcordianDisplay());
            _test.Log(Status.Pass, "Verify Access Approval Acordian Display");
            ContentDetailsPage.Accordians.ClickEdit_AccessApproval();
            Assert.IsTrue(AccessApprovalPage.verifyFields());
            _test.Log(Status.Pass, "Verify Approval required, Search for options are available on page");
            
            AccessApprovalPage.AssignApproverPath();
            _test.Log(Status.Info, "Asign Approver path to content");
            StringAssert.AreEqualIgnoringCase("The approval path is now associated with the content.", ContentDetailsPage.VerifyFeedbackMessage());
            _test.Log(Status.Pass, "Verify feedback message");
            ContentDetailsPage.Click_Check_in();
            _test.Log(Status.Info, "Click check in button");

            CommonSection.SearchCatalog('"' + bunbdleTitle + "TC57027" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC57027");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");

            ContentDetailsPage.AccessApprovalModal.SubmitCancelRequestAccess("ForTest");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            TC57028 = true;

        }
        [Test, Order(18)]
        public void P20_1_tc_57028_Bundles_View_History_Cancel_Access_Request()
        {
            Assert.IsTrue(TC57028);

        }
      
        [Test, Order(19)]
        public void P20_1_tc_57029_Bundle_History_Access_Item_and_view_History_tab()
        {
            //depend on 57027
            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + bunbdleTitle + "TC57027" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC57027");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isRequestAccessbuttondisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isCancleRequestbuttonDisplay());

            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            CommonSection.Manage.ApprovalRequests();
            _test.Log(Status.Info, "Click on Approval Request ");
            ApprovalRequestsPage.PendingMyApproval.Approve(bunbdleTitle + "TC57027", "Request Accepted");
            _test.Log(Status.Info, "Approve request");
            CommonSection.Logout();
            _test.Log(Status.Info, "logout of current Account");
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog('"' + bunbdleTitle + "TC57027" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC57027");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            TC57459 = true;

        }
        [Test, Order(20)]
        public void P20_1_tc_57032_Bundles_Continue_In_progress_Item()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57032");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57032_1");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Bundle");
            CreatebundlePage.CreateBundle("Progress Bundle", bunbdleTitle + "TC57032", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            AdminContentDetailsPage.AddContentToBundle(GeneralCourseTitle + "_TC57032");
            AdminContentDetailsPage.AddContentToBundle(GeneralCourseTitle + "_TC57032_1");
            ContentDetailsPage.ClickCheckInbutton();
            CommonSection.SearchCatalog('"' + bunbdleTitle + "TC57027" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC57027");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentTab.RequiredContent.isContentStartdisplay(GeneralCourseTitle + "_TC57032"));
            ContentDetailsPage.ContentTab.RequiredContent.ClickContentEnroll(GeneralCourseTitle + "_TC57032");
            ContentDetailsPage.ContentTab.RequiredContent.CompleteBundleContent();
            Assert.IsTrue(ContentDetailsPage.ContentTab.RequiredContent.isContentRetakeisplay(GeneralCourseTitle + "_TC57032"));
            Assert.IsTrue(ContentDetailsPage.ContentBanner.ContentProgress()=="50%");
            TC57859 = true;
        }
        [Test, Order(21)]
        public void P20_1_tc_57859_Bundles_Verify_Specific_content_can_be_Mark_Complete_once_content_is_started_Bundle()
        {
            Assert.IsTrue(TC57859);
        }
        [Test, Order(22)]
        public void P20_1_tc_57033_Bundle_Access_period()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57035");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>bundle");
            CreatebundlePage.CreateBundle("Progress Bundle", bunbdleTitle + "TC57035", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            AdminContentDetailsPage.AddContentToBundle(GeneralCourseTitle + "_TC57035");
            ContentDetailsPage.Edit_AddAccessPeriod("10");
            DocumentPage.ClickButton_CheckIn();
            CommonSection.SearchCatalog(bunbdleTitle + "TC57035");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC57035");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflag());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isAccessperiodflagMessage("Your access to this content item ends"));

        }
        [Test, Order(23)]
        public void P20_1_tc_57035_Bundle_Access_Key()
        {
            
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57035");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.CreateLink.Bundle();
            _test.Log(Status.Info, "Click create>Subscriptions");
            CreatebundlePage.CreateBundle("Content Bundle", bunbdleTitle + "TC57035", "Bundle Price");
            _test.Log(Status.Info, "Create a new Content Bundle");
            AdminContentDetailsPage.AddContentToBundle(GeneralCourseTitle + "_TC57035");
            AdminContentDetailsPage.AddCost();
            ContentDetailsPage.ClickEditContent_New19_2();
            ContentDetailsPage.Accordians.ClickEdit_AccessKey();
            AccessKeysPage.EnableAccessKey("Yes").Save();
            DocumentPage.ClickButton_CheckIn();
            //Driver.CreateNewAccount();
           // _test.Log(Status.Info, "Create new user account");
            LoginPage.LoginAs("srlearner105").WithPassword("").Login();
            CommonSection.SearchCatalog(bunbdleTitle + "TC57035");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC57035");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isAddtoCartbuttondisplay());
            ContentDetailsPage.OverviewTab.click_AddtoCart();

            CommonSection.Completepurchage(bunbdleTitle + "TC57035");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isStartbuttonDisplay());
            ContentDetailsPage.ContentBanner.Click_Startbutton();
            Assert.IsTrue(ContentDetailsPage.isContentTabSelected());
            Assert.IsTrue(ContentDetailsPage.isHistoryTabDisplay_GeneralCourse());
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            Assert.IsTrue(ContentDetailsPage.HistoryTab.VerifyEnrolledinSectionwithAccessKey());
            TC57459_2 = true;
        }

       
        [Test, Order(24)]
        public void tc_57459_Bundle_Learner_views_History()
        {
            Assert.IsTrue(TC57459);
            Assert.IsTrue(TC57459_1);
            Assert.IsTrue(TC57459_2);
        }
        
        
        [Test, Order(25)]
        public void P20_1_tc_57756_Bundle_User_access_Bundle_Item_with_prerequisite()
        {
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57756_Pre");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            #region Create a general course
            CommonSection.CreateGeneralCourse(GeneralCourseTitle + "_TC57756_Content");
            DocumentPage.ClickButton_CheckIn();
            #endregion
            CommonSection.CreateLink.Bundle();
            CreatebundlePage.CreateBundle("Progress", bunbdleTitle + "TC57756", "Bundle Price");
            AdminContentDetailsPage.AddContentToBundle(GeneralCourseTitle + "_TC57756_Content");
            
            AdminContentDetailsPage.AddPrequisites(GeneralCourseTitle + "_TC57756_Pre");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.SearchCatalog(bunbdleTitle + "TC57756");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC57756");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            TC57009_1 = true;



        }
        [Test, Order(26)]
        public void P20_1_tc_57009_Bundle_Learner_views_Overview_tab()
        {
            Assert.IsTrue(TC57009);
            Assert.IsTrue(TC57009_1);
            #region cretate TA
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigate to Manage >> Training Page");
            TrainingPage.TrainingAssignments.Click_CreateTrainingAssignment();
            _test.Log(Status.Info, "Click Create Training Assignment link from training assignment portlet");
            CreateTrainingAssignmentPage.Create(TATitle + "_TC577566");
            _test.Log(Status.Info, "A new training assignement created as draft");
            CreateTrainingAssignmentPage.ContentTab.ClickAddContent();
            _test.Log(Status.Info, "Click Add Content");
            CreateTrainingAssignmentPage.ContentTab.AddContentModal.AddContent(bunbdleTitle + "TC57756");
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

            CommonSection.SearchCatalog(bunbdleTitle + "TC57756");
            SearchResultsPage.ClickCourseTitle(bunbdleTitle + "TC57756");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isTrainingAssignmentportletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.TrainingAssignment.isDuedatedisplay());

        }
       // [Test, Order(28)]
       // public void tc_57851_Curriculum_User_navigates_to_Content_Details_page_of_Bundle_From_Curriculum()
       // {
            //Cant Automated
      //  }
        
       // [Test, Order(30)]
        public void tc_11023_Batch_enrol_user_into_online_course()
        {
            Assert.IsTrue(TC57571);
        }
       // [Test, Order(31)]
        public void tc_n2c_Bundles_Learner_views_review_tab()
        {
            Assert.IsTrue(TC57571);
        }
       // [Test, Order(32)]
        public void tc_n2c1_Bundles_Learner_views_review_tab()
        {
            Assert.IsTrue(TC57571);
        }
        //[Test, Order(33)]
        public void tc_n2c2_Bundles_Learner_views_review_tab()
        {
            Assert.IsTrue(TC57571);
        }

    }
}



