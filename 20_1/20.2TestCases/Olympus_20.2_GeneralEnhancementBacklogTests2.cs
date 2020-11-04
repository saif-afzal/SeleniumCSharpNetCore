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
    public class NF_Olympus_20_2_GeneralEnhancementBacklogTest2 : TestBase
    {
        string browserstr = string.Empty;
        bool TC35342;
        public NF_Olympus_20_2_GeneralEnhancementBacklogTest2(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            InitializeBase(driver);
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }

        string curriculamtitle = "Curriculum" + Meridian_Common.globalnum;
        string email = "test" + Meridian_Common.globalnum + "@test.com";
        [SetUp]
        public void starttest()
        {

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);


        }
        
        [Test, Order(1)]
        public void tc_24974_Domain_Report_Training_Assignments_by_User_Admin()
        {            
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Assignments"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Assignments");
            _test.Log(Status.Info, "Clicked Domain Report - Training Assignments Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingAssignmentsLabeldisplay());
            Assert.IsTrue(RunReportPage.isComplestionStatusDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingAssignmenstlevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Assignment level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

        }
        [Test, Order(2)]
        public void tc_24975_Domain_Report_Training_Assignment_Periods_by_User_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Assignment Periods by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Assignment Periods by User");
            _test.Log(Status.Info, "Clicked Domain Report - Training Assignment Periods by User Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingAssignmentPeriodbyUserLabeldisplay());
            Assert.IsTrue(RunReportPage.isComplestionStatusDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingAssignmenPeriodbyUsertlevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Assignment period by User level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectContentActivity();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyContentActivityAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

        }
        [Test, Order(3)]
        public void tc_24975_Domain_Report_Training_Assignments_by_Content_Item_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Assignments by Content Item"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Assignments by Content Item");
            _test.Log(Status.Info, "Clicked Domain Report - Training Assignments by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingAssignmentsbyContentItemLabeldisplay());
           
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingAssignmenbyContentItemlevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Assignment by Content Item level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

        }
        [Test, Order(4)]
        public void tc_24996_Organization_Report_Training_Assignments_by_Content_Item_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments by Content Item"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments by Content Item");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignments by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentsbyContentItemLabeldisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();            
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingAssignmenstbyContentItemlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment by Content Item level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

        }
        [Test, Order(5)]
        public void tc_24997_Organization_Report_Training_Assignments_by_User_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments by User");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignments by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");            
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentsbyUserLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingAssignmenstbyUserlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment by User level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectContentActivity();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyContentActivityAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

        }
        [Test, Order(6)]
        public void tc_24999_Organization_Report_Training_Assignment_Periods_by_Content_Item_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignment Periods by Content Item"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignment Periods by Content Item");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignment Periods by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentPeriodbyContentItemLabeldisplay());            
            Assert.IsTrue(RunReportPage.isComplestionStatusDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgReportTrainingAssignmenPeriodbyContentItemlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment period by Content item level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

        }
        [Test, Order(7)]
        public void tc_63295_Training_Progress_Details_by_Container_Report_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Training Progress Details by Container"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Training Progress Details by Container");
            _test.Log(Status.Info, "Clicked Training Progress Details by Container Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isTrainingProgressDetailsbyContainerLabeldisplay());            
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTrainingProgressDetailsbyContainerlevelColumns());
            _test.Log(Status.Pass, "Verify some Training Progress Details by Container level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

        }
        [Test, Order(9)]
        public void tc_63924_Managers_Report_Training_Assignment_Exemptions_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");            
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Manager's Report - Training Assignment Exemptions"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickManagersReportTrainingAssignmentExemptionsTitle();// SearchReportTitle("Manager's Report: Training Assignment");
            _test.Log(Status.Info, "Clicked Manager's Report - Training Assignment Exemptions Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReport_TrainingAssignmentsExemptionsLabeldisplay());            
            Assert.IsTrue(RunReportPage.isExemptionTypeTypedisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyManagersReportTrainingAssignmentsExemptionslevelColumns());
            _test.Log(Status.Pass, "Verify some Managers Report_Training Assignment Exeptions level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

        }
        [Test, Order(8)]
        public void tc_63659_Managers_Report_Training_Assignment_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Logout();
            LoginPage.LoginAs("srreportmanager").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Report Manager");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Assignments"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Assignments");
            _test.Log(Status.Info, "Clicked Domain Report - Training Assignments Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingAssignmentsLabeldisplay());
            Assert.IsTrue(RunReportPage.isComplestionStatusDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingAssignmenstlevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Assignment level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

           
        }
        [Test, Order(9)]
        public void tc_63786_Organization_Report_Training_Assignments_by_Content_Item_Report_manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments by Content Item"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments by Content Item");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignments by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentsbyContentItemLabeldisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingAssignmenstbyContentItemlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment by Content Item level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

           
        }
        [Test, Order(10)]
        public void tc_63765_Domain_Report_Training_Assignments_by_Content_Item_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Assignments by Content Item"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Assignments by Content Item");
            _test.Log(Status.Info, "Clicked Domain Report - Training Assignments by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingAssignmentsbyContentItemLabeldisplay());

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingAssignmenbyContentItemlevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Assignment by Content Item level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

           
        }
        [Test, Order(11)]
        public void tc_63764_Domain_Report_Training_Assignment_Periods_by_User_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Assignment Periods by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Assignment Periods by User");
            _test.Log(Status.Info, "Clicked Domain Report - Training Assignment Periods by User Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingAssignmentPeriodbyUserLabeldisplay());
            Assert.IsTrue(RunReportPage.isComplestionStatusDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingAssignmenPeriodbyUsertlevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Assignment period by User level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectContentActivity();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyContentActivityAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

          
        }
        [Test, Order(12)]
        public void tc_63680_Organization_Report_Training_Assignments_by_User_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments by User");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignments by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentsbyUserLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingAssignmenstbyUserlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment by User level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectContentActivity();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyContentActivityAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

           
        }
        [Test, Order(13)]
        public void tc_63784_Organization_Report_Training_Assignment_Periods_by_Content_Item_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignment Periods by Content Item"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignment Periods by Content Item");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignment Periods by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentPeriodbyContentItemLabeldisplay());
            
            Assert.IsTrue(RunReportPage.isComplestionStatusDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgReportTrainingAssignmenPeriodbyContentItemlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment period by Content item level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

           
        }
        [Test, Order(14)]
        public void tc_63790_Training_Progress_Details_by_Container_Report_Admin()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Training Progress Details by Container"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Training Progress Details by Container");
            _test.Log(Status.Info, "Clicked Training Progress Details by Container Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isTrainingProgressDetailsbyContainerLabeldisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyTrainingProgressDetailsbyContainerlevelColumns());
            _test.Log(Status.Pass, "Verify some Training Progress Details by Container level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

           
        }
        [Test, Order(9)]
        public void tc_63773_Managers_Report_Training_Assignment_Exemptions_Report_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Manager's Report - Training Assignment Exemptions"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickManagersReportTrainingAssignmentExemptionsTitle();// SearchReportTitle("Manager's Report: Training Assignment");
            _test.Log(Status.Info, "Clicked Manager's Report - Training Assignment Exemptions Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReport_TrainingAssignmentsExemptionsLabeldisplay());
            Assert.IsTrue(RunReportPage.isExemptionTypeTypedisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyManagersReportTrainingAssignmentsExemptionslevelColumns());
            _test.Log(Status.Pass, "Verify some Managers Report_Training Assignment Exeptions level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

        }
        [Test, Order(15)]
        public void tc_63787_Organization_Report_Training_Assignments_by_Content_Item_Org_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Logout();
            LoginPage.LoginAs("sampleorgmanager").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Org Manager");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments by Content Item"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments by Content Item");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignments by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentsbyContentItemLabeldisplay());
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingAssignmenstbyContentItemlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment by Content Item level columns are display in report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify Sample Org 1 is display in report header");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

           
        }
        [Test, Order(16)]
        public void tc_63679_Organization_Report_Training_Assignments_by_User_Org_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignments by User"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignments by User");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignments by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentsbyUserLabeldisplay());
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrganizationReportTrainingAssignmenstbyUserlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment by User level columns are display in report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify Sample Org 1 is display in report header");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectContentActivity();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyContentActivityAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");
           
        }
        [Test, Order(17)]
        public void tc_63785_Organization_Report_Training_Assignment_Periods_by_Content_Item_Organization_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Organization Report - Training Assignment Periods by Content Item"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Organization Report - Training Assignment Periods by Content Item");
            _test.Log(Status.Info, "Clicked Organization Report - Training Assignment Periods by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isOrganizationReport_TrainingAssignmentPeriodbyContentItemLabeldisplay());
            
            Assert.IsTrue(RunReportPage.isComplestionStatusDisplay());
            Assert.IsTrue(RunReportPage.Organization.isdisplay("Sample Organization 1"));
            Assert.IsTrue(RunReportPage.Organization.isSelectble("Sample Organization 1"));
            _test.Log(Status.Info, "Verify use can select only Sample Organization 1");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgReportTrainingAssignmenPeriodbyContentItemlevelColumns());
            _test.Log(Status.Pass, "Verify some Organization Report_Training Assignment period by Content item level columns are display in report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyOrgName("Sample Organization 1"));
            _test.Log(Status.Pass, "Verify Sample Org 1 is display in report header");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

           
        }
        
        [Test, Order(9)]
        public void tc_63777_Managers_Report_Training_Assignment_Exemptions_User_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Logout();
            LoginPage.LoginAs("usermanager").WithPassword("").Login();
            _test.Log(Status.Info, "Login as user Manager");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Manager's Report - Training Assignment Exemptions"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickManagersReportTrainingAssignmentExemptionsTitle();// SearchReportTitle("Manager's Report: Training Assignment");
            _test.Log(Status.Info, "Clicked Manager's Report - Training Assignment Exemptions Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isManagersReport_TrainingAssignmentsExemptionsLabeldisplay());
            Assert.IsTrue(RunReportPage.isExemptionTypeTypedisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyManagersReportTrainingAssignmentsExemptionslevelColumns());
            _test.Log(Status.Pass, "Verify some Managers Report_Training Assignment Exeptions level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");

        }
        [Test, Order(10)]
        public void tc_63769_Domain_Report_Training_Assignments_by_Content_Item_Content_Manager()
        {
            Driver.focusParentWindow();
            _test.Log(Status.Info, "Closes pdf window");
            CommonSection.Logout();
            LoginPage.LoginAs("ak_contentmanager").WithPassword("").Login();
            _test.Log(Status.Info, "Login as content manager");
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("Domain Report - Training Assignments by Content Item"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickSearchReportTitle("Domain Report - Training Assignments by Content Item");
            _test.Log(Status.Info, "Clicked Domain Report - Training Assignments by Content Item Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.CLickSearchButton();
            RunReportPage.SelectFirstresultandClickSelect();
            Assert.IsTrue(RunReportPage.isDomainReport_TrainingAssignmentsbyContentItemLabeldisplay());

            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyDomainReportTrainingAssignmenbyContentItemlevelColumns());
            _test.Log(Status.Pass, "Verify some Domain Report_Training Assignment by Content Item level columns are display in report");
            MeridianGlobalReportingPage.ClickTabileEditicon();
            MeridianGlobalReportingPage.CustomizeTable.SelectLoginId();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyLoginidAddedtoreportTable());
            _test.Log(Status.Pass, "Verify new column added into result grid");


        }
    }
}



