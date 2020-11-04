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
    public class P1_SurveyReportingEnhancementTest : TestBase
    {
        string surveyTitle = "Survey" + Meridian_Common.globalnum;
        string BunbdleTitle = "Bundle" + Meridian_Common.globalnum;
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string DocumentTitle = "Doc" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string SubscriptionsTitle = "Subscriptions" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;
        string generalcoursedec = "GC_Dec" + Meridian_Common.globalnum;
        string CategoryTitle = "Category" + Meridian_Common.globalnum;
        string AICCTitle = "AICC" + Meridian_Common.globalnum;
        string SCORMTitle = "SCORM" + Meridian_Common.globalnum;
        string browserstr = string.Empty;
        string CreatedEvent = "Visit Doctor " + Meridian_Common.globalnum;
        string Question;
        bool TC56918;
        public P1_SurveyReportingEnhancementTest(string browser)
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
        public void tc_56908_As_an_Admin_Run_a_report_on_rating_type_questions_in_standard_survey_reports()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("RatingTypeQuestion_Report");
            _test.Log(Status.Info, "Search Created Survey");
            SurveyPage.ItemsTab.ViewVisualReportFromActionsMenu("RatingTypeQuestion_Report");
            _test.Log(Status.Info, "Click on View Report from Action Dropdown for Published Survey with Responses");
            Assert.IsTrue(SurveyReportPage.VerifySurveyReportIsDisplayed("RatingTypeQuestion_Report"));
            _test.Log(Status.Pass, "Verify Survey Report is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyRatingTypeQuestionTextIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Text is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyOverallAverageRatingIsDisplayed());
            _test.Log(Status.Pass, "Verify Overall Average Rating is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyTabularRepresentationIsDisplayed());
            _test.Log(Status.Pass, "Verify Tabular Representation is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyChoisesAndPercentageResponseIsDisplayed());
            _test.Log(Status.Pass, "Verify % of Responses (Responses) for each rating choices is displayed in Tabular Representation");
            Assert.IsTrue(SurveyReportPage.VerifyTotalOfResponsesIsDisplayed());
            _test.Log(Status.Pass, "Verify # of Responses (Total) for each rating is displayed in Tabular Representation");
        }
        //[Test, Order(2)]
        //public void tc_56909_As_an_Admin_Run_a_exportable_report_on_rating_type_questions()
        //{

        //    //duplicate test case of 58320
        //}
        [Test, Order(3)]
        public void tc_57100_As_an_Admin_Run_a_report_on_Matrix_type_questions_in_standard_survey_reports()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("MatrixTypeQuestion_Report");
            _test.Log(Status.Info, "Search Created Survey");
            SurveyPage.ItemsTab.ViewVisualReportFromActionsMenu("MatrixTypeQuestion_Report");
            _test.Log(Status.Info, "Click on View Report from Action Dropdown for Published Survey with Responses");
            Assert.IsTrue(SurveyReportPage.VerifySurveyReportIsDisplayed("MatrixTypeQuestion_Report"));
            _test.Log(Status.Pass, "Verify Survey Report is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyMatrixQuestionTextAreDisplayed());
            _test.Log(Status.Pass, "Verify Question Text is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyMatrixOverallAverageRatingIsDisplayed());
            _test.Log(Status.Pass, "Verify Overall Average Rating is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyMatrixTabularRepresentationIsDisplayed());
            _test.Log(Status.Pass, "Verify Tabular Representation is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyMatrixChoisesAndPercentageResponseIsDisplayed());
            _test.Log(Status.Pass, "Verify % of Responses (Responses) for each rating choices is displayed in Tabular Representation");
            Assert.IsTrue(SurveyReportPage.VerifyMatrixTotalOfResponsesIsDisplayed());
            _test.Log(Status.Pass, "Verify # of Responses (Total) for each rating is displayed in Tabular Representation");
           
        }
        [Test, Order(4)]
        public void tc_57101_As_an_Admin_Run_a_exportable_report_on_matrix_type_questions()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("MatrixTypeQuestion_Report");
            _test.Log(Status.Info, "Search Created Survey");
            SurveyPage.ItemsTab.ViewExportableReportFromActionsMenu("MatrixTypeQuestion_Report");
            _test.Log(Status.Info, "Click on View Report from Action Dropdown for Published Survey with Responses");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySurveyExportableReportIsDisplayed("MatrixTypeQuestion_Report"));
            _test.Log(Status.Pass, "Verify Survey Report is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySurveyIsDisplayed());
            Assert.IsTrue(SurveyReportPage.VerifyQuestionTextIsDisplayedinExportableReport());
            _test.Log(Status.Pass, "Verify Question Text is Displayed");
           Assert.IsTrue(SurveyReportPage.VerifyMatrixRowTextIsDisplayed());
            _test.Log(Status.Pass, "Verify matrix row Text is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyResponseValueInExportableReoprtIsDisplayed());
            _test.Log(Status.Pass, "Verify Response Value is Displayed");
            SurveyReportPage.CloseExportableReport();
            _test.Log(Status.Info, "Close Exportable Report");


        }
        [Test, Order(5)]
        public void tc_57425_As_an_Admin_Run_a_report_on_Paragraph_type_questions_in_standard_survey_reports()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("ParagraphTypeQuestion_Report");
            _test.Log(Status.Info, "Search Created Survey");
            SurveyPage.ItemsTab.ViewVisualReportFromActionsMenu("ParagraphTypeQuestion_Report");
            _test.Log(Status.Info, "Click on View Report from Action Dropdown for Published Survey with Responses");
            Assert.IsTrue(SurveyReportPage.VerifySurveyReportIsDisplayed("ParagraphTypeQuestion_Report"));
            _test.Log(Status.Pass, "Verify Survey Report is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyParagraphQuestionTextIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Text is Displayed");
            Assert.IsTrue(SurveyReportPage.Verify5ResponsesAreDisplayed()<=5);
            _test.Log(Status.Pass, "Verify 5 paragraph responses are displayed");
            Assert.IsTrue(SurveyReportPage.VerifyMoreResponsesAreDisplayed()>=5);
            _test.Log(Status.Pass, "Verify more than 5 responses are displayed");


        }


        [Test, Order(6)]
        public void tc_58018_As_an_Admin_I_want_to_see_comments_to_the_Question_as_a_part_of_standard_survey()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("MultipleTypeQuestion_Report");
            _test.Log(Status.Info, "Search Created Survey");
            SurveyPage.ItemsTab.ViewVisualReportFromActionsMenu("MultipleTypeQuestion_Report");
            _test.Log(Status.Info, "Click on View Report from Action Dropdown for Published Survey with Responses");
            Assert.IsTrue(SurveyReportPage.VerifySurveyReportIsDisplayed("MultipleTypeQuestion_Report"));
            _test.Log(Status.Pass, "Verify Survey Report is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyMultipleTypeRadioButtonQuestionTextIsDisplayed());
            _test.Log(Status.Pass, "Verify Question Text is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyCommenUnderCommentButton());
            _test.Log(Status.Pass, "Verify Comment under comment button is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyCountIsDisplayedOnCommentButton());
            _test.Log(Status.Pass, "Verify count on button is equal to comment displayed under button");
            

        }


        [Test, Order(7)]
        public void tc_58298_As_an_Admin_Run_a_report_on_multiple_type_questions_in_standard_survey_reports()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("MultipleTypeQuestion_Report");
            _test.Log(Status.Info, "Search Created Survey");
            SurveyPage.ItemsTab.ViewVisualReportFromActionsMenu("MultipleTypeQuestion_Report");
            _test.Log(Status.Info, "Click on View Report from Action Dropdown for Published Survey with Responses");
            Assert.IsTrue(SurveyReportPage.VerifySurveyReportIsDisplayed("MultipleTypeQuestion_Report"));
            _test.Log(Status.Pass, "Verify Survey Report is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyMultipleTypeRadioButtonQuestionTextIsDisplayed());
            _test.Log(Status.Pass, "Verify Multiple type Radio button Question Text is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyMultipleTypeDropdownQuestionTextIsDisplayed());
            _test.Log(Status.Pass, "Verify Multiple type Dropdown Question Text is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyMultipleTypeCheckboxQuestionTextIsDisplayed());
            _test.Log(Status.Pass, "Verify Multiple type Checkbox Question Text is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyOverallAverageRatingIsDisplayed());
            _test.Log(Status.Pass, "Verify Overall Average Rating is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyTabularRepresentationIsDisplayed());
            _test.Log(Status.Pass, "Verify Tabular Representation is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyChoisesAndPercentageResponseIsDisplayed());
            _test.Log(Status.Pass, "Verify % of Responses (Responses) for each rating choices is displayed in Tabular Representation");
            Assert.IsTrue(SurveyReportPage.VerifyTotalOfResponsesIsDisplayed());
            _test.Log(Status.Pass, "Verify # of Responses (Total) for each rating is displayed in Tabular Representation");

           
        }
        [Test, Order(8)]
        public void tc_58320_As_an_Admin_Run_a_exportable_report_on_rating_type_questions()
        {

            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("RatingTypeQuestion_Report");
            _test.Log(Status.Info, "Search Created Survey");
            SurveyPage.ItemsTab.ViewExportableReportFromActionsMenu("RatingTypeQuestion_Report");
            _test.Log(Status.Info, "Click on View Report from Action Dropdown for Published Survey with Responses");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySurveyExportableReportIsDisplayed("RatingTypeQuestion_Report"));
            _test.Log(Status.Pass, "Verify Survey Report is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySurveyIsDisplayed());
            Assert.IsTrue(SurveyReportPage.VerifyQuestionTextIsDisplayedinExportableReport());
            _test.Log(Status.Pass, "Verify Question Text is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyResponseValueInExportableReoprtIsDisplayed());
            _test.Log(Status.Pass, "Verify Response Value is Displayed");
            SurveyReportPage.CloseExportableReport();
            _test.Log(Status.Info, "Close Exportable Report");

        }
        //[Test, Order(9)]
        //public void tc_58321_As_an_Admin_Run_a_exportable_report_on_Slider_type_questions()
        //{
        //    //Deprecated Testcase
        //}
        [Test, Order(10)]
        public void tc_58597_As_an_Admin_Run_a_exportable_report_on_Checkbox_type_questions_in_a_survey()
        {
            CommonSection.Manage.SurveysAndEvaluations();
            _test.Log(Status.Info, "Click Surveys and Evaluations under Manage");
            SurveysPage.SearchSurvey("CheckboxTypeQuestion_Report");
            _test.Log(Status.Info, "Search Created Survey");
            SurveyPage.ItemsTab.ViewExportableReportFromActionsMenu("CheckboxTypeQuestion_Report");
            _test.Log(Status.Info, "Click on View Report from Action Dropdown for Published Survey with Responses");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySurveyExportableReportIsDisplayed("CheckboxTypeQuestion_Report"));
            _test.Log(Status.Pass, "Verify Survey Report is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySurveyIsDisplayed());
            Assert.IsTrue(SurveyReportPage.VerifyQuestionTextIsDisplayedinExportableReport());
            _test.Log(Status.Pass, "Verify Question Text is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyResponseValueInExportableReoprtIsDisplayed());
            _test.Log(Status.Pass, "Verify Response Value is Displayed");
            SurveyReportPage.CloseExportableReport();
            _test.Log(Status.Info, "Close Exportable Report");

            //    Assert.IsTrue(SurveyReportPage.VerifyQuestionTextIsDisplayed());
            //    Assert.IsTrue(SurveyReportPage.VerifyResponseValueIsDisplayed());
        }



    }






}
