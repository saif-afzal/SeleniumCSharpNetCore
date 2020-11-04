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
    public class P1_Catalog_SurveyContentDetailsPagesTest : TestBase
    {
        string browserstr = string.Empty;
        public P1_Catalog_SurveyContentDetailsPagesTest(string browser)
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
        bool TC60841;
        string EvaluationTitle= "Eval" + Meridian_Common.globalnum;

        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }


        [Test, Order(01)]
        public void tc_60737_As_a_learner_I_want_to_see_most_relevant_Survey_Banner_Actions()
        {
            CommonSection.CreateLink.Survey();
            SurveysPage.CreateNewSurvey(surveyTitle + "TC60737");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.CreateRadiobuttontype("RadioTypeQuestion", "good", "Not good");
            ManageSurveyPage.clickSurveyTab();
            SurveyPage.AddImage();
            _test.Log(Status.Info, "Add image to Survey");
            SurveyPage.Click_Publish();
            SurveyPage.ClickViewasLearner();

            Assert.IsTrue(ContentDetailsPage.isBradCrumbdisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(surveyTitle + "TC60737"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTypedisplay());
            _test.Log(Status.Pass, "Verify Content type is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentImagedisplay());
            _test.Log(Status.Pass, "Verify Image is display on Banner");

            Assert.IsTrue(ContentDetailsPage.isSaveShareandEditContentbuttndisplay());
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isTakeSurveyButtonDisplay());

            ContentDetailsPage.ContentBanner.Click_TakeSurveybutton();
            ContentDetailsPage.closeSurveywindow(surveyTitle + "TC60737");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
            _test.Log(Status.Pass, "Verify Continue button is display on Banner");
            ContentDetailsPage.ContentBanner.click_continuebutton();
            ContentDetailsPage.ComleteSurvey(surveyTitle + "TC60737");            
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isReviewButtonDisplay());
            _test.Log(Status.Pass, "Verify Review button is display on Banner");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isReTakeSurveylinkDisplsplay());
            _test.Log(Status.Pass, "Verify is Retake Surveylink is display on Banner");


        }
        [Test,Order(2)]
        public void tc_60725_As_a_learner_I_want_to_see_details_about_a_Survey_Overview_Tab()
        {
            // creata new survey add decribstion, video, add this to any training assignment and equivalency, partof these collestion
            CommonSection.SearchCatalog("Survey for Automation-60725");
            SearchResultsPage.ClickCourseTitle("Survey for Automation-60725");
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPrerequisitePortletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isDescriptionDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPromotionalVideodisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isTrainingAssignmentportletDisplay());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isEquivalenciesDisplayed());
            Assert.IsTrue(ContentDetailsPage.OverviewTab.isPartoftheseCollectionDisplay());
        }
        [Test, Order(3)]
        public void P20_1_tc_26218_Rate_Review_Survey()
        {
            CommonSection.CreateLink.Survey();
            SurveysPage.CreateNewSurvey(surveyTitle + "TC26218");
            _test.Log(Status.Info, "A new Survey Created");           
            SurveyPage.Click_Publish();

            CommonSection.SearchCatalog(surveyTitle + "TC26218");
            SearchResultsPage.ClickCourseTitle(surveyTitle + "TC26218");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContentTitledisplay(surveyTitle + "TC26218"));
            _test.Log(Status.Pass, "Verify Content title is display on Banner");
            Assert.IsFalse(ContentDetailsPage.isreviewTabdisdisplay());
            _test.Log(Status.Pass, "Verify Tab is not display");            
            ContentDetailsPage.ContentBanner.Click_TakeSurveybutton();
            ContentDetailsPage.closeSurveywindow(surveyTitle + "TC26218");
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
            Assert.IsFalse(ContentDetailsPage.isreviewTabdisdisplay());
            _test.Log(Status.Pass, "Verify Tab is not display after enroll into course");
        }

        [Test, Order(4)]
        public void tc_60841_As_a_learner_I_want_to_see_the_interactions_I_had_in_History_Tab_of_Survey()
        {
            CommonSection.CreateLink.Survey();
            SurveysPage.CreateNewSurvey(surveyTitle + "TC26218");
            _test.Log(Status.Info, "A new Survey Created");
            ManageSurveyPage.Structure.Click_AddAQuestion();
            _test.Log(Status.Info, "Click on Add A Question");
            Assert.IsTrue(ManageSurveyPage.VerifyAddAQuestionModal());
            _test.Log(Status.Pass, "Click on Add A Question");
            ManageSurveyPage.AddaQuestionModal.CreateRadiobuttontype("RadioTypeQuestion", "good", "Not good");
            ManageSurveyPage.clickSurveyTab();
            SurveyPage.Click_Publish();
            SurveyPage.ClickViewasLearner();

            Assert.IsTrue(ContentDetailsPage.ContentBanner.isTakeSurveyButtonDisplay());
            ContentDetailsPage.ContentBanner.Click_TakeSurveybutton();
            ContentDetailsPage.ComleteSurvey(surveyTitle + "TC60737");
            ContentDetailsPage.Click_HistoryTab_Curriculum();
            Assert.IsFalse(ContentDetailsPage.Historytab.isViewCertificateButtonDisplay());
            _test.Log(Status.Pass, "Verify View Certification button should not display");
            Assert.IsTrue(ContentDetailsPage.HistoryTab.isStatusDisplay("Completed"));
            _test.Log(Status.Pass, "Verify Completed status displayed");
        }
       

    }
}



