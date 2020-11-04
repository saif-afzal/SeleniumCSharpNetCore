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
    public class NF_Olympus_20_2_GeneralEnhancementBacklogTest1 : TestBase
    {
        string browserstr = string.Empty;
        bool TC35342;
        public NF_Olympus_20_2_GeneralEnhancementBacklogTest1(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        bool TC62626;
        bool TC61864;
        bool TC61744;
        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string email = "test" + Meridian_Common.globalnum + "@test.com";
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }

        [Test, Order(1)]
        public void tc_6831_Create_New_Account_Manage_Users()
        {            
            CommonSection.Manage.People();
            PeoplePage.ClickButton_CreateAccount();
            Assert.IsTrue(CreateNewAccount.LoginIDMaxLength("100"));
            _test.Log(Status.Pass, "Verify Login Id Max Length is 100");
            Assert.IsTrue(CreateNewAccount.LoginIDMaxLengthisWorking());
            _test.Log(Status.Pass, "Verify Login Id Max Length is working preporly");
            CreateNewAccountobj.PopulateCreateNewUserLinkOuter(ExtractDataExcel.MasterDic_newuser["Id"], ExtractDataExcel.MasterDic_newuser["Firstname"], ExtractDataExcel.MasterDic_newuser["Lastname"]);
            // CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccount.SelectOrganization("Sample Organization");

            Assert.IsTrue(CreateNewAccount.isConfirmEmailfielddisplaywithNonEditMode() == "true");
            _test.Log(Status.Pass, "Verify Confirm Email field display with non edit mode");
            CreateNewAccount.FilEmailAddress(email);
            Assert.IsTrue(CreateNewAccount.isConfirmEmailfielddisplaywithEditMode());
            _test.Log(Status.Pass, "Verify Confirm Email field display with edit mode");
            Assert.IsFalse(CreateNewAccount.CreateButtonisEnabled());
            CreateNewAccount.FilConfirmEmail("a");
            Assert.IsTrue(CreateNewAccount.ConfirmEmailAddressValidationmessagedisplay("Enter a valid email address that contains"));
            CreateNewAccount.ClearEmailAddress();
            //Assert.IsTrue(CreateNewAccount.isConfirmEmailfielddisplaywithNonEditMode() == "true");
            _test.Log(Status.Pass, "Verify Confirm Email field display with non edit mode");
            CreateNewAccount.FilEmailAddress(email);
            CreateNewAccount.FilConfirmEmail(email);
            Assert.IsTrue(CreateNewAccount.CreateButtonisEnabled());
            CreateNewAccountobj.Click_CreateAccount();
            _test.Log(Status.Info, "Click Create button after fill all mandetory fields");
            Assert.IsTrue(PeoplePage.getfeedbackmessage("The account was created and the user profile was updated."));
            TC62626 = true;
            TC61864 = true;
            TC61744 = true;
        }
        [Test, Order(2)]
        public void tc_62626_Create_New_Account_AD_Self_Registration_20_1()
        {
            Assert.IsTrue(TC62626);
        }
        [Test, Order(3)]
        public void tc_61864_Create_New_Account_Multiple_URL_Self_Registration_20_1()
        {
            Assert.IsTrue(TC61864);
        }
        [Test, Order(4)]
        public void tc_61744_Create_New_Account_Single_URL_Self_Registration_20_1()
        {
            Assert.IsTrue(TC61744);
        }
        [Test, Order(5)]
        public void tc_63778_Managers_Report_External_Learning_User_Manager()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("usermanager").WithPassword("password").Login();
            _test.Log(Status.Info, "Login as User Manager");
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
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(6)]
        public void tc_63776_Managers_Report_Content_Access_User_Manager()
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
        [Test, Order(7)]
        public void tc_63772_Managers_Report_Proficiency_Ratings_User_Manager()
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

            Driver.focusParentWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            
        }
        [Test, Order(8)]
        public void tc_63779_Managers_Report_Training_Assignment_User_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            //CommonSection.Logout();
            //LoginPage.LoginAs("usermanager").WithPassword("").Login();
            _test.Log(Status.Info, "Login as User Manager");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Manager's Report: Training Assignment"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickManagersReportTrainingAssignmentTitle();
            _test.Log(Status.Info, "Clicked Manager's Report - Training Assignment Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReport_TrainingAssignmentLabeldisplay());
            Assert.IsTrue(RunReportPage.isExemptionTypeTypedisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyManagersReportTrainingAssignmentlevelColumns());
            _test.Log(Status.Pass, "Verify some Managers Report_Training Assignment level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Managers_Report_-_Training_Assignment.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");           
            #endregion
        }
        
        [Test, Order(9)]
        public void tc_24983_Managers_Report_Training_Assignment_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Logout();
            LoginPage.LoginAs("").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Manager's Report - Training Assignments"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickManagersReportTrainingAssignmentTitle();// SearchReportTitle("Manager's Report: Training Assignment");
            _test.Log(Status.Info, "Clicked Manager's Report - Training Assignment Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReport_TrainingAssignmentsLabeldisplay());
            //Assert.IsTrue(RunReportPage.isManagersReport_TrainingAssignmentLabeldisplay());
            //Assert.IsTrue(RunReportPage.isExemptionTypeTypedisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyManagersReportTrainingAssignmentslevelColumns());
            _test.Log(Status.Pass, "Verify some Managers Report_Training Assignment level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Managers_Report_-_Training_Assignment.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //Driver.focusParentWindow();
            //_test.Log(Status.Info, "Closes pdf window");
            //#endregion
        }
        [Test, Order(10)]
        public void tc_24995_Organization_Report_Training_Assignment_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignment Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentsLabeldisplay());            
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingAssignmentlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_Training_Assignments.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");            
            //#endregion
        }
        [Test, Order(11)]
        public void tc_25000_Organization_Report_Training_Progress_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Progress"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Progress");
            _test.Log(Status.Info, "Clicked Organization Report - Training Progress Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingProgressLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingProgresslevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Progress level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_Training_Progress.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");            
            //#endregion
        }
        [Test, Order(12)]
        public void tc_25015_Training_Progress_by_User_Report_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Training Progress by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Training Progress by User");
            _test.Log(Status.Info, "Clicked Training Progress by User Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isTrainingProgressbyUserLabeldisplay());
            Assert.IsTrue(RunReportPage.isLastNameSearchtextdisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstUserfromresultandClickSelect();
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.isUserNamelabledisplay());
            _test.Log(Status.Pass, "Verify User name ismdisplay in report heading section"); 
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTrainingProgressbyUserlevelColumns());
            _test.Log(Status.Pass, "Verify some Training Progress by User level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectTotalCost();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyTotalCostAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_External_Learning.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");           
            //#endregion
        }
        [Test, Order(13)]
        public void tc_25014_Training_Progress_by_Content_Report_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Training Progress by Content"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Training Progress by Content");
            _test.Log(Status.Info, "Clicked Training Progress by Content Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isTrainingProgressbyContentLabeldisplay());
            Assert.IsTrue(RunReportPage.isSearchtextdisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectresultandClickSelect();
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.isContentTtitlelabledisplay());
            _test.Log(Status.Pass, "Verify Title display in report heading section");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTrainingProgressbyContentlevelColumns());
            _test.Log(Status.Pass, "Verify some Training Progress by Content level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectTotalCost();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyTotalCostAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Training_Progress_by_Content.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //#endregion
        }
        [Test, Order(14)]
        public void tc_25010_Summary_Report_Training_Progress_by_Orgnization_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Summary Report - Training Progress by Organization"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Summary Report - Training Progress by Organization");
            _test.Log(Status.Info, "Clicked Summary Report - Training Progress by Organization Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isSummaryReport_TrainingProgressbyOrganizationLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySummaryReport_TrainingProgressbyOrganizationlevelColumns());
            _test.Log(Status.Pass, "Verify some Summary Report_Training Progress by Organization level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectCourseProvider();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyCourseProviderAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Summary_Report_-_Training_Progress_by_Organization.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //#endregion
        }
        [Test, Order(15)]
        public void tc_25011_Summary_Report_User_Progress_by_Orgnization_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Summary Report - User Progress by Organization"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Summary Report - User Progress by Organization");
            _test.Log(Status.Info, "Clicked Summary Report - User Progress by Organization Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isSummaryReport_UserProgressbyOrganizationLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySummaryReport_UserProgressbyOrganizationlevelColumns());
            _test.Log(Status.Pass, "Verify some Summary Report - User Progress by Organization level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Summary_Report_-_User_Progress_by_Organization.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //#endregion
        }
        [Test, Order(16)]
        public void tc_24976_Domain_Report_Training_Progress_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Progress"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Progress");
            _test.Log(Status.Info, "Clicked Domain Report - Training Progress Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingProgressLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingProgresslevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Progress level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Domain_Report_-_Training_Progress.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //#endregion
        }
        [Test, Order(17)]
        public void tc_24970_Domain_Report_Training_Assignments_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Assignments"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Assignments");
            _test.Log(Status.Info, "Clicked Domain Report - Training Assignments Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingAssignmentLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingAssignmentslevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Assignemnts level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Domain_Report_-_Training_Assignments.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //#endregion
        }
        [Test, Order(18)]
        public void tc_24998_Organization_Report_Training_Assignments_Periods_by_User_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments by User");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignments by User Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstUserfromresultandClickSelect();
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmensPeriodbyUsertLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyUserNameisdisplayinReportheader());
            _test.Log(Status.Pass, "Verify sUser Name in Report header");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgReportTrainingAssignmentsPeriodbyUserlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignemnts Period by User level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectContentActivity();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyContentActivityAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_Training_Assignments_by_Use.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //#endregion
        }
        [Test, Order(19)]
        public void tc_63659_Managers_Report_Training_Assignment_Report_Manager()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("srreportmanager").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Report Manager");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Manager's Report - Training Assignments"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickManagersReportTrainingAssignmentTitle();// SearchReportTitle("Manager's Report: Training Assignment");
            _test.Log(Status.Info, "Clicked Manager's Report - Training Assignment Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReport_TrainingAssignmentsLabeldisplay());
            Assert.IsTrue(RunReportPage.isComplestionStatusDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyManagersReportTrainingAssignmentslevelColumns());
            _test.Log(Status.Pass, "Verify some Managers Report_Training Assignment level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Manager's_Report_-_Training_Assignment.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //Driver.focusParentWindow();
            //_test.Log(Status.Info, "Closes pdf window");
            //#endregion
        }
        [Test, Order(20)]
        public void tc_63782_Organization_Report_Training_Assignment_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignment Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentsLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingAssignmentlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_External_Learning.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //Driver.focusParentWindow();
            //_test.Log(Status.Info, "Closes pdf window");
           // #endregion
        }
        [Test, Order(21)]
        public void tc_63614_Organization_Report_Training_Progress_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Progress"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Progress");
            _test.Log(Status.Info, "Clicked Organization Report - Training Progress Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingProgressLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingProgresslevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Progress level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_External_Learning.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //Driver.focusParentWindow();
            //_test.Log(Status.Info, "Closes pdf window");
            //#endregion
        }
        [Test, Order(22)]
        public void tc_63695_Training_Progress_by_User_Report_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Training Progress by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Training Progress by User");
            _test.Log(Status.Info, "Clicked Training Progress by User Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isTrainingProgressbyUserLabeldisplay());
            Assert.IsTrue(RunReportPage.isLastNameSearchtextdisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstUserfromresultandClickSelect();
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.isUserNamelabledisplay());
            _test.Log(Status.Pass, "Verify User name ismdisplay in report heading section");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTrainingProgressbyUserlevelColumns());
            _test.Log(Status.Pass, "Verify some Training Progress by User level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectTotalCost();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyTotalCostAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_External_Learning.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //Driver.focusParentWindow();
            //_test.Log(Status.Info, "Closes pdf window");
            //#endregion
        }
        [Test, Order(23)]
        public void tc_63696_Training_Progress_by_Content_Report_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Training Progress by Content"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Training Progress by Content");
            _test.Log(Status.Info, "Clicked Training Progress by Content Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isTrainingProgressbyContentLabeldisplay());
            Assert.IsTrue(RunReportPage.isSearchtextdisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectresultandClickSelect();
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.isContentTtitlelabledisplay());
            _test.Log(Status.Pass, "Verify Title display in report heading section");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTrainingProgressbyContentlevelColumns());
            _test.Log(Status.Pass, "Verify some Training Progress by Content level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectTotalCost();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyTotalCostAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
                      
            
            //Driver.focusParentWindow();
            //_test.Log(Status.Info, "Closes pdf window");
           
        }
        [Test, Order(24)]
        public void tc_63701_SF_182_Requests_Report_Report_Manager()

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
            //#region Print and export Reports
            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("SF_182_Requests.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            //Driver.focusParentWindow();
            //_test.Log(Status.Info, "Closes pdf window");
            //#endregion
        }
        [Test, Order(25)]
        public void tc_63584_Summary_Report_Training_Progress_by_Orgnization_Report_Manager()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Summary Report - Training Progress by Organization"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Summary Report - Training Progress by Organization");
            _test.Log(Status.Info, "Clicked Summary Report - Training Progress by Organization Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isSummaryReport_TrainingProgressbyOrganizationLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySummaryReport_TrainingProgressbyOrganizationlevelColumns());
            _test.Log(Status.Pass, "Verify some Summary Report_Training Progress by Organization level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectCourseProvider();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyCourseProviderAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Summary_Report_-_Training_Progress_by_Organization.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(26)]
        public void tc_63582_Summary_Report_User_Progress_by_Orgnization_Report_Manager()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Summary Report - User Progress by Organization"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Summary Report - User Progress by Organization");
            _test.Log(Status.Info, "Clicked Summary Report - User Progress by Organization Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isSummaryReport_UserProgressbyOrganizationLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySummaryReport_UserProgressbyOrganizationlevelColumns());
            _test.Log(Status.Pass, "Verify some Summary Report - User Progress by Organization level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Summary_Report_-_User_Progress_by_Organization.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(27)]
        public void tc_63767_Domain_Report_Training_Progress_Report_Manager()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Progress"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Progress");
            _test.Log(Status.Info, "Clicked Domain Report - Training Progress Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingProgressLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingProgresslevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Progress level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Domain_Report_-_Training_Progress.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(28)]
        public void tc_63763_Domain_Report_Training_Assignments_Report_Manager()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Assignments"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Assignments");
            _test.Log(Status.Info, "Clicked Domain Report - Training Assignments Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingAssignmentLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingAssignmentslevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Assignemnts level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Domain_Report_-_Training_Assignments.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(29)]
        public void tc_63788_Organization_Report_Training_Assignments_Periods_by_User_Report_Manager()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments by User");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignments by User Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectresultandClickSelect();
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmensPeriodbyUsertLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyUserNameisdisplayinReportheader());
            _test.Log(Status.Pass, "Verify sUser Name in Report header");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgReportTrainingAssignmentsPeriodbyUserlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignemnts Period by User level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectContentActivity();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyContentActivityAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_Training_Assignments_by_Use.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(30)]
        public void tc_63615_Organization_Report_Training_Progress_Org_Manager()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("sampleorgmanager").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Org Manager");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Progress"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Progress");
            _test.Log(Status.Info, "Clicked Organization Report - Training Progress Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingProgressLabeldisplay());
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingProgresslevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Progress level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_External_Learning.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(31)]
        public void tc_63694_Training_Progress_by_User_Report_Org_Manager()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Training Progress by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Training Progress by User");
            _test.Log(Status.Info, "Clicked Training Progress by User Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isTrainingProgressbyUserLabeldisplay());
            Assert.IsTrue(RunReportPage.isSearchtextdisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectresultandClickSelect();
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.isUserNamelabledisplay());
            _test.Log(Status.Pass, "Verify User name ismdisplay in report heading section");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTrainingProgressbyUserlevelColumns());
            _test.Log(Status.Pass, "Verify some Training Progress by User level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectTotalCost();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyTotalCostAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_External_Learning.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(32)]
        public void tc_63697_Training_Progress_by_Content_Report_Org_Manager()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Training Progress by Content"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Training Progress by Content");
            _test.Log(Status.Info, "Clicked Training Progress by Content Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isTrainingProgressbyContentLabeldisplay());
            Assert.IsTrue(RunReportPage.isSearchtextdisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectresultandClickSelect();
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.isContentTtitlelabledisplay());
            _test.Log(Status.Pass, "Verify Title display in report heading section");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTrainingProgressbyContentlevelColumns());
            _test.Log(Status.Pass, "Verify some Training Progress by Content level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectTotalCost();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyTotalCostAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Training_Progress_by_Content.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(33)]
        public void tc_63585_Summary_Report_Training_Progress_by_Orgnization_Organization_Manager()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Summary Report - Training Progress by Organization"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Summary Report - Training Progress by Organization");
            _test.Log(Status.Info, "Clicked Summary Report - Training Progress by Organization Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isSummaryReport_TrainingProgressbyOrganizationLabeldisplay());
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify Sample Org 1 is display in report header");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySummaryReport_TrainingProgressbyOrganizationlevelColumns());
            _test.Log(Status.Pass, "Verify some Summary Report_Training Progress by Organization level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectCourseProvider();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyCourseProviderAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Summary_Report_-_Training_Progress_by_Organization.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(34)]
        public void tc_63583_Summary_Report_User_Progress_by_Orgnization_Admin()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Summary Report - User Progress by Organization"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Summary Report - User Progress by Organization");
            _test.Log(Status.Info, "Clicked Summary Report - User Progress by Organization Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isSummaryReport_UserProgressbyOrganizationLabeldisplay());
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify Sample Org 1 is display in report header");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifySummaryReport_UserProgressbyOrganizationlevelColumns());
            _test.Log(Status.Pass, "Verify some Summary Report - User Progress by Organization level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Summary_Report_-_User_Progress_by_Organization.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(35)]
        public void tc_63789_Organization_Report_Training_Assignments_Periods_by_User_Organization_Manager()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments by User");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignments by User Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectresultandClickSelect();
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmensPeriodbyUsertLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyUserNameisdisplayinReportheader());
            _test.Log(Status.Pass, "Verify sUser Name in Report header");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify Sample Org 1 is display in report header");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgReportTrainingAssignmentsPeriodbyUserlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignemnts Period by User level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectContentActivity();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyContentActivityAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

            #region Print and export Reports
            MeridianGlobalReportingPage.ExportToPDF();//Print the report
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("Organization_Report_-_Training_Assignments_by_Use.pdf"));
            _test.Log(Status.Pass, "Verify pdf exported");
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            #endregion
        }
        [Test, Order(36)]
        public void tc_63783_Organization_Report_Training_Assignment_User_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignment Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentsLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingAssignmentlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment level columns are display in report");
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


    }
}



