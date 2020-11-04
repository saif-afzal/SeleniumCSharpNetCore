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
    public class NF_Olympus_20_2_GeneralEnhancementBacklogTest : TestBase
    {
        string browserstr = string.Empty;
        bool TC35342;
        public NF_Olympus_20_2_GeneralEnhancementBacklogTest(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;       
       
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }

        [Test, Order(1)]
        public void tc_32143_Managers_Report_Proficiency_Ratings()
        {

            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "opened reports console from kview");
            ReportsConsolePage.SearchText("Manager's Report - Proficiency Ratings");
            _test.Log(Status.Info, "Searched Manager's Report - Proficiency Ratings");
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1);//checks results display more than 1
            ReportsConsolePage.ClickManagersReportProficiencyRatings();
            _test.Log(Status.Info, "ClickedManager's Report - Proficiency Ratings");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReport_ProficiencyRatingsisDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyManagerProficiencyRatingReportlevelColumns());
            _test.Log(Status.Info, "Verify some Manager Proficiency Rating Reports columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());

            Driver.focusParentWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Run Report");
        }
        [Test, Order(2)]
        public void tc_50927_Competency_Progress_Report()

        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Competency progress"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickCompetencyProgressReportTitle();
            _test.Log(Status.Info, "Clicked Competency progress Report Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isCompentencysearchfielddisplay());

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "Save New", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyCompetencyinheaderisdisplay());
            _test.Log(Status.Info, "Verify Compentency Name is Header section");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyReportContaindColumns());
            _test.Log(Status.Info, "Verify ewrult grid display with compentency header");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyRequiredContentCompletionColumnValue() > 0);
            _test.Log(Status.Info, "Verify Required Content Completion Column value is more than 0");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added to result grid");           
           
        }
        [Test, Order(3)]
        public void tc_51081_Job_fit_Report()

        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();

            ReportsConsolePage.SearchText("Fit job"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickFitJobTitle();
            _test.Log(Status.Info, "Clicked Content Usage Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isSearchtextdisplay());
            //RunReportPage.Searchwith("").CLickSearchButton();
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectresultandClickSelect();

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyJobTitleinheaderisdisplay());
            _test.Log(Status.Info, "Verify some Jabtitle Name is Header section");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyReportContaindColumns());
            _test.Log(Status.Info, "Verify ewrult grid display with compentency header");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyRequiredContentCompletionColumnValue() > 0);
            _test.Log(Status.Info, "Verify Required Content Completion Column value is more than 0");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added to result grid");           
            

        }
        [Test, Order(4)]
        public void tc_24984_Managers_Report_Content_Access()
        {
            Driver.focusParentWindow();            
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Manager's Report: Content Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickManagersReportContentAccessReportTitle();
            _test.Log(Status.Info, "Clicked Manager's Report: Content Access Report Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReportContentAccessdisplay());

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "Save New", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyManagersReportContentAccessColumns());
            _test.Log(Status.Info, "Verify some Manager's Report: Content Access Reports columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());

            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Run Report");
        }
        [Test, Order(5)]
        public void tc_34686_Run_Response_Level_Survey_Data_Report_As_Administrator()

        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            #region All Questions,All SurveyReport
            ReportsConsolePage.SearchText("All Questions,All Surveys"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickAllQuestionAllSurveysTitle();
            _test.Log(Status.Info, "Clicked All Question All Surveys Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySurveyReportlevelColumns());
            _test.Log(Status.Pass, "Verify some survey level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #endregion
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("All_Questions__All_Surveys.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
          
            #endregion             

        }
        [Test, Order(6)]
        public void tc_63408_SF_182_Requests_Report()

        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");           
            CommonSection.Administer.System.Reporting.ReportConsole();
            #region All Questions,All SurveyReport
            ReportsConsolePage.SearchText("SF 182 Requests"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSF182RequestsTitle();
            _test.Log(Status.Info, "Clicked SF 182 Requests Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isSF_182Requestsdisplay());
            Assert.IsTrue(RunReportPage.isSF_182Sratusdisplay());
            RunReportPage.selectSF182Sratus("ALL");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySF_182ReportlevelColumns());
            _test.Log(Status.Pass, "Verify some survey level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectStatusDate();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyStatusDateAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #endregion
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("SF-182_Requests.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            
            #endregion
        }
        [Test, Order(7)]
        public void tc_63413_Organization_Report_External_Learning()

        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            #region All Questions,All SurveyReport
            ReportsConsolePage.SearchText("Organization Report - External Learning"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickOrganizationReport_ExternalLearningTitle();
            _test.Log(Status.Info, "Clicked Organization Report - External Learning Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_ExternalLearningLableDisplay());
            Assert.IsTrue(RunReportPage.isExternalLearneringTypedisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyExternalLearningOrglevelColumns());
            _test.Log(Status.Pass, "Verify some Extrenal Learnering Org level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #endregion
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_External_Learning.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
           
            #endregion
        }
        [Test, Order(8)]
        public void tc_63412_Domain_Report_External_Learning()

        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            #region All Questions,All SurveyReport
            ReportsConsolePage.SearchText("Domain Report - External Learning"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickDomainReport_ExternalLearningTitle();
            _test.Log(Status.Info, "Clicked Domain Report - External Learning Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isDomainReport_ExternalLearningLabeldisplay());
            Assert.IsTrue(RunReportPage.isExternalLearneringTypedisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyExternalLearningOrglevelColumns());
            _test.Log(Status.Pass, "Verify some Extrenal Learnering Org level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #endregion
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Domain_Report_-_External_Learning.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
           
            #endregion
        }
        [Test, Order(9)]
        public void tc_63414_Managers_Report_External_Learning_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Manager's Report - External Learning"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickManagersReportExternalLearningTitle();
            _test.Log(Status.Info, "Clicked Manager's Report - External Learning Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReport_ExternalLearningLabeldisplay());
            Assert.IsTrue(RunReportPage.isExternalLearneringTypedisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyExternalLearningOrglevelColumns());
            _test.Log(Status.Pass, "Verify some Extrenal Learnering Org level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Managers_Report_-_External_Learning.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
           
            #endregion
        }
        [Test, Order(10)]
        public void tc_25006_Recent_User_Access_Report_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Recent User Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickRecentUserAccessTitle();
            _test.Log(Status.Info, "Clicked Recent User Access Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isRecentUserAccessLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyRecentUserAccessColumns());
            _test.Log(Status.Pass, "Verify some Recen tUser Access level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Recent_User_Access.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
           
            #endregion
        }
        [Test, Order(11)]
        public void tc_25008_Repeat_User_Access_Report_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Repeat User Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickRepeatUserAccessTitle();
            _test.Log(Status.Info, "Clicked Repeat User Access Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isRepeatUserAccessLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyRepeatUserAccessColumns());
            _test.Log(Status.Pass, "Verify some Repeat user Access level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Repeat_User_Access.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
           
            #endregion
        }
        [Test, Order(12)]
        public void tc_24992_Organization_Report_Content_Access_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Content Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickOrgReportContentAccessReportTitle();
            _test.Log(Status.Info, "Clicked Org Report: Content Access Report Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrgReportContentAccessdisplay());

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "Save New", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgReportContentAccessColumns());
            _test.Log(Status.Info, "Verify some Org Report: Content Access Reports columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());

            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Run Report");
        }
        [Test, Order(13)]
        public void tc_16883_Test_Item_Analysis_Aggregated_Response_Report_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Test Item Analysis Response Summary"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickTestItemAnalysisResponseSummaryTitle();
            _test.Log(Status.Info, "Clicked Test Item Analysis Response Summary Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isTestItemAnalysisResponseSummarydisplay());
            Assert.IsTrue(RunReportPage.isSearchtextdisplay());
            //RunReportPage.Searchwith("").CLickSearchButton();
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTestItemAnalysisResponseSummaryLableColumns());
            _test.Log(Status.Info, "Verify result grid display with Test Item Analysis Response Summary header");

            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.Unselectanyfield();
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Test_Item_Analysis_Response_Summary.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
           
        }
        [Test, Order(14)]
        public void tc_16884_Test_Item_Analysis_Detailed_Response_Report_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Test Item Analysis Response Details"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickTestItemAnalysisResponseDetailsTitle();
            _test.Log(Status.Info, "Clicked Test Item Analysis Response Details Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");            
            Assert.IsTrue(RunReportPage.isSearchtextdisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isTestItemAnalysisResponseDetailsdisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTestItemAnalysisResponseDetailsLableColumns());
            _test.Log(Status.Info, "Verify result grid display with Test Item Analysis Response Details header");

            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.Unselectanyfield();
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Test_Item_Analysis_Response_Details.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
           
        }
        [Test, Order(15)]
        public void tc_63770_Job_Fit_Report_Report_Manager()

        {
            Driver.focusParentWindow();
            CommonSection.Logout();
            LoginPage.LoginAs("srreportmanager").WithPassword("").Login();
            CommonSection.Administer.System.Reporting.ReportConsole();

            ReportsConsolePage.SearchText("Fit job"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickFitJobTitle();
            _test.Log(Status.Info, "Clicked Content Usage Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isSearchtextdisplay());
            //RunReportPage.Searchwith("").CLickSearchButton();
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectresultandClickSelect();

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyJobTitleinheaderisdisplay());
            _test.Log(Status.Info, "Verify some Jabtitle Name is Header section");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyReportContaindColumns());
            _test.Log(Status.Info, "Verify ewrult grid display with compentency header");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyRequiredContentCompletionColumnValue() > 0);
            _test.Log(Status.Info, "Verify Required Content Completion Column value is more than 0");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added to result grid");
           
        }
        [Test, Order(16)]
        public void tc_63700_SF_182_Requests_Report_Report_Manager()

        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            #region All Questions,All SurveyReport
            ReportsConsolePage.SearchText("SF 182 Requests"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSF182RequestsTitle();
            _test.Log(Status.Info, "Clicked SF 182 Requests Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isSF_182Requestsdisplay());
            Assert.IsTrue(RunReportPage.isSF_182Sratusdisplay());
            RunReportPage.selectSF182Sratus("ALL");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySF_182ReportlevelColumns());
            _test.Log(Status.Pass, "Verify some survey level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectStatusDate();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyStatusDateAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #endregion
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("SF-182_Requests.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
          
            #endregion
        }
        [Test, Order(17)]
        public void tc_63761_Competency_Progress_Report_Report_Manager()

        {
            Driver.focusParentWindow();
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Competency progress"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickCompetencyProgressReportTitle();
            _test.Log(Status.Info, "Clicked Competency progress Report Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isCompentencysearchfielddisplay());

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "Save New", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyCompetencyinheaderisdisplay());
            _test.Log(Status.Info, "Verify Compentency Name is Header section");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyReportContaindColumns());
            _test.Log(Status.Info, "Verify ewrult grid display with compentency header");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyRequiredContentCompletionColumnValue() > 0);
            _test.Log(Status.Info, "Verify Required Content Completion Column value is more than 0");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added to result grid");
           
        }
        [Test, Order(18)]
        public void tc_63762_Domain_Report_External_Learning_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            #region All Questions,All SurveyReport
            ReportsConsolePage.SearchText("Domain Report - External Learning"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickDomainReport_ExternalLearningTitle();
            _test.Log(Status.Info, "Clicked Domain Report - External Learning Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isDomainReport_ExternalLearningLabeldisplay());
            Assert.IsTrue(RunReportPage.isExternalLearneringTypedisplay());
            
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyExternalLearningOrglevelColumns());
            _test.Log(Status.Pass, "Verify some Extrenal Learnering Org level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #endregion
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Domain_Report_-_External_Learning.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");           
            #endregion
        }
        [Test, Order(19)]
        public void tc_63771_Managers_Report_Proficiency_Ratings_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "opened reports console from kview");
            ReportsConsolePage.SearchText("Manager's Report - Proficiency Ratings");
            _test.Log(Status.Info, "Searched Manager's Report - Proficiency Ratings");
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1);//checks results display more than 1
            ReportsConsolePage.ClickManagersReportProficiencyRatings();
            _test.Log(Status.Info, "ClickedManager's Report - Proficiency Ratings");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReport_ProficiencyRatingsisDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyManagerProficiencyRatingReportlevelColumns());
            _test.Log(Status.Info, "Verify some Manager Proficiency Rating Reports columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
                       
        }
        [Test, Order(20)]
        public void tc_63704_Recent_User_Access_Report_Report_Manager()
        {
            Driver.focusParentWindow();
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Recent User Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickRecentUserAccessTitle();
            _test.Log(Status.Info, "Clicked Recent User Access Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isRecentUserAccessLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyRecentUserAccessColumns());
            _test.Log(Status.Pass, "Verify some Recen tUser Access level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Recent_User_Access.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
          
            #endregion
        }
        [Test, Order(21)]
        public void tc_63702_Repeat_User_Access_Report_Report_Manager()
        {
            Driver.focusParentWindow();
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Repeat User Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickRepeatUserAccessTitle();
            _test.Log(Status.Info, "Clicked Repeat User Access Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isRepeatUserAccessLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyRepeatUserAccessColumns());
            _test.Log(Status.Pass, "Verify some Repeat user Access level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Repeat_User_Access.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            #endregion
        }
        [Test, Order(22)]
        public void tc_63775_Managers_Report_Content_Access_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Manager's Report: Content Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickManagersReportContentAccessReportTitle();
            _test.Log(Status.Info, "Clicked Manager's Report: Content Access Report Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReportContentAccessdisplay());

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "Save New", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyManagersReportContentAccessColumns());
            _test.Log(Status.Info, "Verify some Manager's Report: Content Access Reports columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
                       
        }
        [Test, Order(23)]
        public void tc_63777_Managers_Report_External_Learning_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Manager's Report - External Learning"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickManagersReportExternalLearningTitle();
            _test.Log(Status.Info, "Clicked Manager's Report - External Learning Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReport_ExternalLearningLabeldisplay());
            Assert.IsTrue(RunReportPage.isExternalLearneringTypedisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyExternalLearningOrglevelColumns());
            _test.Log(Status.Pass, "Verify some Extrenal Learnering Org level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Managers_Report_-_External_Learning.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
          
            #endregion
        }
        [Test, Order(24)]
        public void tc_63780_Organization_Report_External_Learning_Report_Manager()

        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - External Learning"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickOrganizationReport_ExternalLearningTitle();
            _test.Log(Status.Info, "Clicked Organization Report - External Learning Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_ExternalLearningLableDisplay());
            Assert.IsTrue(RunReportPage.isExternalLearneringTypedisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyExternalLearningOrglevelColumns());
            _test.Log(Status.Pass, "Verify some Extrenal Learnering Org level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_External_Learning.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");          
            #endregion
        }
        [Test, Order(25)]
        public void tc_63612_Organization_Report_Content_Access_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Content Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickOrgReportContentAccessReportTitle();
            _test.Log(Status.Info, "Clicked Org Report: Content Access Report Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrgReportContentAccessdisplay());

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "Save New", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgReportContentAccessColumns());
            _test.Log(Status.Info, "Verify some Org Report: Content Access Reports columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());

            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Run Report");
        }
        [Test, Order(26)]
        public void tc_63699_Test_Item_Analysis_Aggregated_Response_Report_Reports_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");            
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Test Item Analysis Response Summary"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickTestItemAnalysisResponseSummaryTitle();
            _test.Log(Status.Info, "Clicked Test Item Analysis Response Summary Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            
            Assert.IsTrue(RunReportPage.isSearchtextdisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isTestItemAnalysisResponseSummarydisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTestItemAnalysisResponseSummaryLableColumns());
            _test.Log(Status.Info, "Verify result grid display with Test Item Analysis Response Summary header");

            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.Unselectanyfield();
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Test_Item_Analysis_Response_Summary.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            
        }
        [Test, Order(27)]
        public void tc_63698_Test_Item_Analysis_Detailed_Response_Report_Reports_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Test Item Analysis"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Test Item Analysis");
            _test.Log(Status.Info, "Clicked Test Item Analysis Response Details Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            
            Assert.IsTrue(RunReportPage.isSearchtextdisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isTestItemAnalysisResponseSummarydisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");

            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTestItemAnalysisResponseSummaryLableColumns());
            _test.Log(Status.Info, "Verify result grid display with Test Item Analysis Response Summary header");

            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.Unselectanyfield();
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Test_Item_Analysis_Response_Details.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
          
        }

        [Test, Order(28)]
        public void tc_35341_Run_Response_Level_Survey_Data_Report_As_Content_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Logout();
            LoginPage.LoginAs("ak_contentmanager").WithPassword("").Login();
            CommonSection.Administer.System.Reporting.ReportConsole();
            #region All Questions,All SurveyReport
            ReportsConsolePage.SearchText("All Questions,All Surveys"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickAllQuestionAllSurveysTitle();
            _test.Log(Status.Info, "Clicked All Question All Surveys Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySurveyReportlevelColumns());
            _test.Log(Status.Pass, "Verify some survey level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #endregion
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("All_Questions__All_Surveys.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            
            #endregion
            TC35342 = true;
        }
        [Test, Order(29)]
        public void tc_35342_Run_Response_Level_Survey_Data_Report_As_Report_Manager()
        {
            Assert.IsTrue(TC35342);
        }
        
        
        [Test, Order(30)] //create org manager in PS for sampleorg1
        public void tc_63705_Recent_User_Access_Report_Organization_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Logout();
            LoginPage.LoginAs("sampleorgmanager").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Org Manager");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Recent User Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickRecentUserAccessTitle();
            _test.Log(Status.Info, "Clicked Recent User Access Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isRecentUserAccessLabeldisplay());
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify Sample Org 1 is display in report header");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyRecentUserAccessColumns());
            _test.Log(Status.Pass, "Verify some Recen tUser Access level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Recent_User_Access.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");           
            #endregion
        }
        [Test, Order(31)]
        public void tc_63703_Repeat_User_Access_Report_Organization_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Repeat User Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickRepeatUserAccessTitle();
            _test.Log(Status.Info, "Clicked Repeat User Access Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isRepeatUserAccessLabeldisplay());
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyRepeatUserAccessColumns());
            _test.Log(Status.Pass, "Verify some Repeat user Access level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Repeat_User_Access.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");           
            #endregion
        }
        [Test, Order(32)]
        public void tc_63613_Organization_Report_Content_Access_Organization_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Content Access"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickOrgReportContentAccessReportTitle();
            _test.Log(Status.Info, "Clicked Org Report: Content Access Report Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrgReportContentAccessdisplay());
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "Save New", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify Sample Org 1 display");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgReportContentAccessColumns());
            _test.Log(Status.Info, "Verify some Org Report: Content Access Reports columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());

            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Run Report");
        }
        [Test, Order(33)]
        public void tc_63781_Organization_Report_External_Learning_Organization_Manager()

        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            #region All Questions,All SurveyReport
            ReportsConsolePage.SearchText("Organization Report - External Learning"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickOrganizationReport_ExternalLearningTitle();
            _test.Log(Status.Info, "Clicked Organization Report - External Learning Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_ExternalLearningLableDisplay());
            Assert.IsTrue(RunReportPage.isExternalLearneringTypedisplay());
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify Sample Org 1 display");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyExternalLearningOrglevelColumns());
            _test.Log(Status.Pass, "Verify some Extrenal Learnering Org level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
            #endregion
            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_External_Learning.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");           
            #endregion
        }
    }
}



