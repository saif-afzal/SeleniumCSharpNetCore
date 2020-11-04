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
    public class P2_ImpactedRegressionTest : TestBase
    {
        string browserstr = string.Empty;
        public P2_ImpactedRegressionTest(string browser)
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
        string AICCTitle= "GC_AICC" + Meridian_Common.globalnum;
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
        bool TC60841;

        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }

        [Test, Order(1)]
        public void tc_58349_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_minimum_Prerequisites_to_be_completed_in_AICC()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC58349");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
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
            PrerequisitesPage.prerequisitesmustbecompleteddropdown.Selectlist("2");
            DocumentPage.ClickButton_CheckIn();

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(AICCTitle + "TC58349");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC58349");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item. 2 of 10 required."));
        }
        [Test, Order(2)]
        public void tc_58340_As_a_learner_I_want_to_know_what_are_the_options_to_satisfy_prerequisites_When_admin_has_selected_All_Prerequisites_to_be_completed_for_AICC()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            _test.Log(Status.Info, "AICC files are uploaded");
            string actualresult = driver.gettextofelement(By.XPath("//h1[contains(.,'Summary')]"));
            CreateAICCPage.Title(AICCTitle + "TC58340");
            EditSummaryPage.ClickSavebutton();
            _test.Log(Status.Info, "Create a new AICC Course");
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

            CommonSection.Logout();
            LoginPage.LoginAs("srlearner103").WithPassword("").Login();
            CommonSection.SearchCatalog(AICCTitle + "TC58340");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC58340");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.Prerequisiteportlet.isPortletheadershowes("Warning\r\nComplete the prerequisites to access this item."));
        }
        [Test]
        public void a16_As_a_learner_I_want_to_see_what_surveys_are_required_and_when_they_are_available_AICC_Course_35688()
        {
            #region Create AICC Course
            Document documentpage = new Document(driver);
            string expectedresult = "Summary";
            string expectedresult1 = "The course was created.";
            AICC aicccourse = new AICC(driver);
            Scorm12 CreateScorm = new Scorm12(driver);
            CommonSection.CreateLink.AICC();
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.au", By.Id("ctl00_MainContent_UC1_rau_aufile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.crs", By.Id("ctl00_MainContent_UC1_rau_crsfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.cst", By.Id("ctl00_MainContent_UC1_rau_cstfile0"));
            driver.navigateAICCfile("Data\\mv_mvet_a03_it_enus.des", By.Id("ctl00_MainContent_UC1_rau_desfile0"));
            CreateScorm.buttoncreateclick(driver, true);
            // UploadaiccPage.UploadfileandClickCreate();
            CreateAICCPage.CreateAICC(AICCTitle + "TC35688");
            _test.Log(Status.Info, "Create a new AICC Course");
            #endregion
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

            CommonSection.SearchCatalog(AICCTitle + "TC35688");
            SearchResultsPage.ClickCourseTitle(AICCTitle + "TC35688");
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysDisplay(Surveytitle_OnEnroll, Surveytitle_OnContentComplete));
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysareNotavailable);
            ContentDetailsPage.ClickEnroll();
            Assert.IsTrue(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnEnroll));
            //AdminContentDetailsPage.ClickOpenNewAttemptbutton.CompleteContent();
            // Assert.IsFalse(ContentDetailsPage.SurveyPortlet.IsSurveysAvailable(Surveytitle_OnContentComplete));

        }
        [Test]//"Dolly's AICC Course with Promotional Video_12172018"
        public void a21_Learner_Plays_Promotional_Videos_From_AICC_35374()

        {

            CommonSection.Logout();
            LoginPage.LoginAs("ak_learner").WithPassword("").Login(); //Login as regular user (Learner)

            //CommonSection.SearchCatalog("Dollys AICC Course with Promotional Video_12172018"); // Search for Bundle that has Promotional Video

            CommonSection.SearchCatalog(ExtractDataExcel.MasterDic_aicc["Title"] + browserstr); // Search for Bundle that has Promotional Video
            _test.Log(Status.Info, "Searched" + "Dollys AICC Course with Promotional Video_12172018" + "from Catalog");
            SearchResultsPage.ClickCourseTitle(ExtractDataExcel.MasterDic_aicc["Title"] + browserstr); // Click on Bundle Title
            _test.Log(Status.Info, "Clicked searched course title");
            Assert.IsTrue(ContentDetailsPage.VerifyPromotionalVideo()); //Verify the Promotional Video is displayed
            _test.Log(Status.Pass, "Verified Promotional Video display in content details page");
            ContentDetailsPage.PromotionalVideo.ClickPlayButton(); //Click on Play button on Promotional Video
            _test.Log(Status.Info, "Clicked Play button of Promotional video");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is playing in Inline mode");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Full Screen Icon
            _test.Log(Status.Info, "Clicked fullscreen icon for Promotional Video");
            Assert.IsFalse(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays on full screen
            _test.Log(Status.Pass, "Verifyed the promotional Video plays on full screen");
            ContentDetailsPage.PromotionalVideo.ClickFullScreenIconAndPlay(); //Click on Minimize Screen Icon
            _test.Log(Status.Info, "Clicked on Minimize Screen Icon");
            Assert.IsTrue(ContentDetailsPage.PromotionalVideo.VerifyPlaysInline()); //Verify the promotional Video plays Inline on the Page
            _test.Log(Status.Pass, "Verified Promotional Video is plays Inline on the Page");
            ContentDetailsPage.ReturnToDefaultContent();
            _test.Log(Status.Pass, "Return to default Content");
        }
        [Test, Order(6), Category("AutomatedP1")]
        public void While_searching_for_AICC_course_Learner_views_credit_type_and_credit_type_value_33877()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a AICC course i.e. DV_AICC_CV_0507 , and add credit type, DV_Credit_Type and give value =3 in this
            //login with learner
            CommonSection.SearchCatalog('"' + "AICC-TEST_Somnath" + '"');
            _test.Log(Status.Info, "Search Classroom course Somnath-AICC from catalog search");
            StringAssert.AreEqualIgnoringCase("AICC-TEST_Somnath", SearchResultsPage.VerifyCourseTitleText("AICC-TEST_Somnath"));
            _test.Log(Status.Info, "Verify course name");
            StringAssert.AreEqualIgnoringCase("dv_credit_type (5)", SearchResultsPage.VerifyTextCredits("dv_credit_type (5)"));
            _test.Log(Status.Info, "Verify Credit type value and Credit Type");

        }

        [Test, Order(5), Category("AutomatedP1")]
        public void Learner_views_credit_type_help_text_from_AICC_Course_Details_33807()
        {
            //login with a admin 
            // Create a Credit type from Administer>Training.Content Management>Credit Types like with name DV_Credit_Type, don't assign it to specific user and assign it to admin
            //Now create a AICC course i.e. DV_AICC_CV_0507 , and add credit type, DV_Credit_Type and Defailt Credit Type with values like 5 and 4
            //login with learner
            CommonSection.SearchCatalog('"' + "SR-AICC-0104" + '"');
            _test.Log(Status.Info, "Search and open AICC course Somnath-AICC  from catalog search");
            SearchResultsPage.ClickCourseTitle("SR-AICC-0104");
            _test.Log(Status.Info, "Click on course Somnath-AICC title from search result page");
            StringAssert.AreEqualIgnoringCase("Credits", AdminContentDetailsPage.Credits.VerifyTitleText("Credits"));
            _test.Log(Status.Info, "Verify Credit type text");
            StringAssert.AreEqualIgnoringCase("Continuing Education Units: 6", AdminContentDetailsPage.Credits.VerifyAvailableCreditTypeText("Continuing Education Units: 6"));
            _test.Log(Status.Info, "Verify Credit type value for Defautlt Credit Type");
            StringAssert.AreEqualIgnoringCase("You are not eligible to earn other credit types for this item.", AdminContentDetailsPage.Credits.VerifyNoteligiblesText("You are not eligible to earn other credit types for this item."));
            _test.Log(Status.Info, "Verify Credit type text info that user is not eligible for ");
        }

    }
}



