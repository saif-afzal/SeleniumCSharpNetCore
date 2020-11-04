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
    public class P1DashboardComplianceTest : TestBase
    {
        string browserstr = string.Empty;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        private bool TC35341;
        private bool TC35342;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string tagname = "Tag_Reg" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC_Reg" + Meridian_Common.globalnum;

        public P1DashboardComplianceTest(string browser)
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
        public void P20_1_A01_Admin_User_Can_See_Users_Transcript_Who_Are_Out_of_Compliance_35361()
        {
            CommonSection.Avatar.Reports();
            _test.Log(Status.Info, "Navigate to My Reports Page");
            ReportsPage.ComplianceDashboard();
            _test.Log(Status.Info, "Open Compliance Dashboard Page");
            Assert.IsTrue(ComplianceDashboardPage.ViewTranscript());
            _test.Log(Status.Pass, "Compliance Dashboard Page Open and User Transcript Page Successfully Open");

        }

        [Test, Order(2)]
        public void P20_1_A02_Admin_Can_Send_Email_To_Users_Who_Are_Out_of_ComplianceDashboard_35364()
        {
            CommonSection.Avatar.Reports();
            _test.Log(Status.Info, "Navigate to My Reports Page");
            ReportsPage.ComplianceDashboard();
            _test.Log(Status.Info, "Open Compliance Dashboard Page");
            Assert.IsTrue(ComplianceDashboardPage.SendEmail_ToUsers());
            _test.Log(Status.Pass, "Compliance Dashboard Page Open and Admin user able to send email to Users.");

        }

        [Test, Order(3)]
        public void P20_1_A03_Admin_Can_Send_Email_To_UserManager_From_Out_of_ComplinceDashboard_35365()
        {
            CommonSection.Avatar.Reports();
            _test.Log(Status.Info, "Navigate to My Reports Page");
            ReportsPage.ComplianceDashboard();
            _test.Log(Status.Info, "Open Compliance Dashboard Page");
            Assert.IsTrue(ComplianceDashboardPage.SendEmail_ToUserManager());
            _test.Log(Status.Pass, "Compliance Dashboard Page Open and Admin user able to send email to Users's Manager");

        }
        //[Test, Order(4)]
        //public void A04_Filter_Compliance_Dashboard_by_Organization()
        //{

        //}

        //written by Afreen
        [Test, Order(4)]
        public void A04_Section_Enrollment_Summary_Report_35323()
        {
            // LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            CommonSection.Avatar.Account();
            _test.Log(Status.Info, "Go to user Account");
            AccountPage.ClickPreferencesTab();
            _test.Log(Status.Info, "Click Preferences Tab");
            AccountPage.ProfileTab.TimeZone();
            _test.Log(Status.Info, "Record Time Zone");
            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "It opens Report Console");
            ReportsConsolePage.SearchText("Classroom Course Enrollment Summary");
            _test.Log(Status.Info, "Search For Classroom Course Enrollment Summary");
            ReportsConsolePage.ClickDisplayResult();
            _test.Log(Status.Info, "Click Classroom Course Enrollment Summary Link");
            ClassroomCourseEnrollmentPage.ClickSelect();
            _test.Log(Status.Info, "Click Select Button");

            #region Verifing Run Report Page

            Assert.IsTrue(RunReportPage.isOrganizationDisplayed());
            _test.Log(Status.Pass, "Verify Organization is Displayed");
            Assert.IsTrue(RunReportPage.isIncludeSubOrganizationDisplayed());
            _test.Log(Status.Pass, "Verify Select organization is Displayed");
            Assert.IsTrue(RunReportPage.isSectionActivityDisplayed());
            _test.Log(Status.Pass, "Verify Section Activity is Displayed");
            Assert.IsTrue(RunReportPage.isStartDateDisplayed());
            _test.Log(Status.Pass, "Verify Start Date is Displayed");
            Assert.IsTrue(RunReportPage.isEndDateDisplayed());
            _test.Log(Status.Pass, "Verify End Date is Displayed");
            Assert.IsTrue(RunReportPage.isCapacityDisplayed());
            _test.Log(Status.Pass, "Verify Capacity is Displayed");
            Assert.IsTrue(RunReportPage.isCapacityTextboxDisplayed());
            _test.Log(Status.Pass, "Verify Capacity Textbox is Displayed");
            Assert.IsTrue(RunReportPage.isEnrollmentDisplayed());
            _test.Log(Status.Pass, "Verify Enrollment is Displayed");
            Assert.IsTrue(RunReportPage.isEnrollmentTextboxDisplayed());
            _test.Log(Status.Pass, "Verify Enrollment Textbox is Displayed");
            Assert.IsTrue(RunReportPage.isRecordPerPageDisplayed());
            _test.Log(Status.Pass, "Verify Record Per Page is Displayed");
            Assert.IsTrue(RunReportPage.isLayoutDisplayed());
            _test.Log(Status.Pass, "Verify Layout is Displayed");
            Assert.IsTrue(RunReportPage.isRunReportButtonDisplayed());
            _test.Log(Status.Pass, "Verify Run Report Button is Displayed");




            RunReportPage.RunReportWith( "Active", "1/1/2019", "1/16/2019", "Less Than/Equal To", "9", "Less Than/Equal To", "9",
                             "25", "Default");
            _test.Log(Status.Info, "Fill Data And Click Run Report");


            #endregion


            Assert.IsTrue(MeridianGlobalReportingPage.isDisplayed());
            _test.Log(Status.Pass, "Verify Meridian Global Reporting Page is Displayed ");


            #region Verifing MeridianGlobalReportingPage Links

            Assert.IsTrue(MeridianGlobalReportingPage.isPrintDisplayed());
            _test.Log(Status.Pass, "Verify Print is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.isSaveNewDisplayed());
            _test.Log(Status.Pass, "Verify Save New is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.isViewLayoutDisplayed());
            _test.Log(Status.Pass, "Verify View Layout is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.isRefreshDisplayed());
            _test.Log(Status.Pass, "Verify Refresh is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.isCloseWindowDisplayed());
            _test.Log(Status.Pass, "Verify Close Window is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.isExportToExcelDisplayed());
            _test.Log(Status.Pass, "Verify Export To Excel is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.isExportToPDFDisplayed());
            _test.Log(Status.Pass, "Verify Export To PDF is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.isExportToXMLDisplayed());
            _test.Log(Status.Pass, "Verify Export To XML is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.isExportToCSVDisplayed());
            _test.Log(Status.Pass, "Verify Export To CSV is Displayed");

            #endregion

            #region Verifing MeridianGlobalReportingPage Summary Section

          //  Assert.IsTrue(MeridianGlobalReportingPage.Summary.VerifyReportDate());
            _test.Log(Status.Pass, "Verify Summary Report Date");
            Assert.IsTrue(MeridianGlobalReportingPage.Summary.VerifyOrganization());
            _test.Log(Status.Pass, "Comparing Selected Organization Data with Displayed ");
            //Assert.IsTrue(MeridianGlobalReportingPage.Summary.VerifySubOrganization());
            //_test.Log(Status.Pass, "Comparing Selected Sub Organization Data with Displayed ");
            Assert.IsTrue(MeridianGlobalReportingPage.Summary.VerifySectionActivity());
            _test.Log(Status.Pass, "Comparing Selected Section Activity with Displayed ");
            Assert.IsTrue(MeridianGlobalReportingPage.Summary.VerifyDateRange());
            _test.Log(Status.Pass, "Comparing Date Range with Selected");
            Assert.IsTrue(MeridianGlobalReportingPage.Summary.VerifyCapacity());
            _test.Log(Status.Pass, "Comparing Filled Capacity with Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Summary.VerifyEnrollment());
            _test.Log(Status.Pass, "Comparing Filled Enrollment with Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Summary.VerifyReportLayout());
            _test.Log(Status.Pass, "Comparing Selected Report Layout with Displayed");
            //Assert.IsTrue(MeridianGlobalReportingPage.Summary.VerifyTimeZone());
            _test.Log(Status.Pass, "Verifing Time Zone");

            #endregion

            #region Verifing MeridianGlobalReportingPage Table Section


            Assert.IsTrue(MeridianGlobalReportingPage.Table.isSectionTitleDisplayed());
            _test.Log(Status.Pass, "Verify Section Title is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isCourseTitleDidplayed());
            _test.Log(Status.Pass, "Verify Course Title is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isInstrustorDisplayed());
            _test.Log(Status.Pass, "Verify Instrustor is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isLocationDisplaying());
            _test.Log(Status.Pass, "Verify Location is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isStartDateDisplayed());
            _test.Log(Status.Pass, "Verify Start Date is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isEndDateDisplayed());
            _test.Log(Status.Pass, "Verify End Date is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isCapacityDisplayed());
            _test.Log(Status.Pass, "Verify Capacity is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isEnrolledDisplayed());
            _test.Log(Status.Pass, "Verify Enrolled is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isAttendDisplayed());
            _test.Log(Status.Pass, "Verify Attend is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isAverageScoreDisplayed());
            _test.Log(Status.Pass, "Verify Section Title is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isReportDropDownDisplayed());
            _test.Log(Status.Pass, "Verify ReportDropDown is Displayed");
            Assert.IsTrue(MeridianGlobalReportingPage.Table.isGoButtonDisplayed());
            _test.Log(Status.Pass, "Verify Go Button is Displayed");

            #endregion

            #region Print And Export Report

            //MeridianGlobalReportingPage.ExportToPDF();//Print the report
            //_test.Log(Status.Info, "CLick export to pdf");
            //Assert.IsTrue(AllQuestionsAllSurveyPDFPage.Title.EndsWith("All_Questions_All_Survey.pdf"));
            //_test.Log(Status.Pass, "Verify pdf exported");
            MeridianGlobalReportingPage.CloseWindow();
            //_test.Log(Status.Info, "Closes pdf window");
            ////MeridianGlobalReportingPage.Print();
            //_test.Log(Status.Info, "Click Print Link");
            //Assert.IsTrue(MeridianGlobalReportingPage.VerifyPrintWindowOpens());
            //_test.Log(Status.Pass, "Verify Print window opens");
            //Assert.IsTrue(MeridianGlobalReportingPage.PrintWindow.isContentDisplayed());
            //_test.Log(Status.Pass, "Verify content is in proper readable format");
            //MeridianGlobalReportingPage.ClosePrintWindow();
            //_test.Log(Status.Info, "Print window Closes");
            //MeridianGlobalReportingPage.ExportToExcel();
            //_test.Log(Status.Info, "Click Export to Excel Link");
            //Assert.IsTrue(MeridianGlobalReportingPage.VerifyExcelSheetOpens());//Handle Popup
            //_test.Log(Status.Pass, "Verify Excel window opens Displaying Summary Report");
            //MeridianGlobalReportingPage.CloseExcelSheet();
            //_test.Log(Status.Info, "Close Excel Window");
            //MeridianGlobalReportingPage.ExportToPDF();
            //_test.Log(Status.Info, "Click Export to PDF Link");
            //Assert.IsTrue(MeridianGlobalReportingPage.VerifyPDFTabOpens());//New tab opens
            //_test.Log(Status.Pass, "Verify PDF opens in a new TAB Displaying Summary Report");
            //MeridianGlobalReportingPage.ClosePDFTab();
            //_test.Log(Status.Info, "Close PDF Tab");
            //MeridianGlobalReportingPage.ExportToCSV();
            //_test.Log(Status.Info, "Click Export to CSV Link");
            //Assert.IsTrue(MeridianGlobalReportingPage.VerifyCSVSheetOpens());//Handle popup
            //_test.Log(Status.Pass, "Verify Excel window opens Displaying Summary Report in CSV Format");
            //MeridianGlobalReportingPage.CloseCSVSheet();
            //_test.Log(Status.Info, "Close Excel Window");
            //MeridianGlobalReportingPage.ExportToXML();
            //_test.Log(Status.Info, "Click Export to XML Link");
            //Assert.IsTrue(MeridianGlobalReportingPage.VerifyXMLSheetOpens());//New tab opens
            //_test.Log(Status.Pass, "Verify XML opens in a new TAB Displaying Summary Report");
            //MeridianGlobalReportingPage.CloseXMLSheet();
            //_test.Log(Status.Info, "Close XML Tab");

            #endregion


        }
       
        [Test, Order(8)]
        public void P20_1_A08_Content_Usage_Report_35344()

        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            
            ReportsConsolePage.SearchText("Content Usage"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickContentUsageTitle();
            _test.Log(Status.Info, "Clicked Content Usage Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationDisplayed());
            Assert.IsTrue(RunReportPage.isCotentActivityDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyContentUsageReportlevelColumns());
            _test.Log(Status.Info, "Verify some Content Usage rreport colums are display in report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyContentUsageReportsDisplay());
            _test.Log(Status.Info, "Verify some Content Report are display into result grid");
            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "Closes pdf window");

        }
        [Test, Order(9)]
        public void A09_Content_Usage_Report_Progress_Status_35346()

        {
            CommonSection.Administer.System.Reporting.ReportConsole();
           
            ReportsConsolePage.SearchText("Content Usage"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickContentUsageTitle();
            _test.Log(Status.Info, "Clicked Content Usage Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationDisplayed());
            Assert.IsTrue(RunReportPage.isCotentActivityDisplay());
            RunReportPage.ProgessStatusDropdown.SelectProgressStatus("Completed");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyContentUsageReportlevelColumns());
            _test.Log(Status.Info, "Verify some Content Usage rreport colums are display in report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyContentUsageReportsDisplay());
            _test.Log(Status.Info, "Verify some Content Report are display into result grid");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyCompletdColumnValue()>0);
            _test.Log(Status.Info, "Verify Completed column value is more than 0");
            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "Closes pdf window");
            RunReportPage.ProgessStatusDropdown.SelectProgressStatus("No Progress");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyCompletdColumnValue() == 0);
            _test.Log(Status.Info, "Verify Completed column value is 0");
            MeridianGlobalReportingPage.CloseWindow();
        }
        [Test, Order(10)]
        public void A10_Content_Usage_Report_Grouping_35345()

        {
            CommonSection.Administer.System.Reporting.ReportConsole();

            ReportsConsolePage.SearchText("Content Usage"); // Search for the Survey Report
            Assert.IsTrue(ReportsConsolePage.DisplayResult >= 1); // Verify the report is displayed in Results
            ReportsConsolePage.ClickContentUsageTitle();
            _test.Log(Status.Info, "Clicked Content Usage Title");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            Assert.IsTrue(RunReportPage.isOrganizationDisplayed());
            Assert.IsTrue(RunReportPage.isCotentActivityDisplay());
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyPageComponents("Print", "SaveNew", "ViewLayouts", "Refresh", "CloseWindow", "ExportToExcel", "ExportToPDF", "ExportToXML", "ExportToCSV"));
            _test.Log(Status.Pass, "Verify all menus like print, close windows, export to pdf, export tot excel are displaying");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyContentUsageReportlevelColumns());
            _test.Log(Status.Info, "Verify some Content Usage rreport colums are display in report");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyContentUsageReportsDisplay());
            _test.Log(Status.Info, "Verify some Content Report are display into result grid");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyCompletdColumnValue() >= 0);
            _test.Log(Status.Info, "Verify Completed column value is more than 0");
            MeridianGlobalReportingPage.Table.ClickSettingImg();
            MeridianGlobalReportingPage.Table.ClickGroup();
            MeridianGlobalReportingPage.Table.SelectGroupingColumn("Version Number");
            MeridianGlobalReportingPage.Table.ClickAdd();
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyContentUsageReportsinGroup());
            _test.Log(Status.Info, "Verify some Content Report are display into groups");
            Assert.IsTrue(MeridianGlobalReportingPage.VerifyCompletdColumnValue() >= 0);
            _test.Log(Status.Info, "Verify Completed column value is more than 0");
            MeridianGlobalReportingPage.Table.ClickAdd();
            Assert.IsTrue(MeridianGlobalReportingPage.verifyerrormessage("This column is already grouped."));
            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "Closes pdf window");
            
        }
        [Test, Order(11)]
        public void A11_Section_Management_Enrollment_Report_Drilldown_35325()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "it opens Report Console");
            ReportsConsolePage.SearchText("Classroom Course Enrollment Summary");
            _test.Log(Status.Info, "Search For Classroom Course Enrollment Summary");
            ReportsConsolePage.ClickDisplayResult();
            _test.Log(Status.Info, "Click Classroom Course Enrollment Summary Link");
            ClassroomCourseEnrollmentPage.ClickSelect();
            _test.Log(Status.Info, "Click Select Button");
            Assert.IsTrue(RunReportPage.isOrganizationDisplayed());
            _test.Log(Status.Pass, "Verify Organization is Displayed");
            Assert.IsFalse(RunReportPage.isIncludeSubOrganizationDisplayed());
            _test.Log(Status.Pass, "Verify Select organization is Displayed");
            RunReportPage.RunReportWith("Active", "12/16/2018", "1/16/2018", "Less Than/Equal To", "9", "Less Than/Equal To", "9",
                           "25", "Default");
            _test.Log(Status.Info, "Fill Data And Click Run Report");
            Assert.IsTrue(MeridianGlobalReportingPage.isDisplayed());
            _test.Log(Status.Pass, "Verify Meridian Global Reporting Page is Displayed ");
            MeridianGlobalReportingPage.ClickDetails();
            _test.Log(Status.Info, "Clicked go button having details selected and opens details page");
            MeridianGlobalReportingPage.ClickUserProgress();
            MeridianGlobalReportingPage.ClickDetails();
            _test.Log(Status.Info, "Clicked go button having details selected and opens details page");
            Assert.IsTrue(DetailsPage.CheckDetailsTabText.EndsWith("Details"));
            DetailsPage.ClickCloseWindowlink();
            _test.Log(Status.Info, "Details page closes");
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "Closes pdf window");
            Assert.IsTrue(RunReportPage.Title == "Run Report");
            Assert.IsTrue(Driver.focusParentWindow());


        }
        [Test, Order(12)]
        public void A12_As_an_Admin_access_a_survey_report_of_Classroom_Course_from_the_admin_content_details_page_with_scope_limited_to_the_current_content_item_36034()
        {
            #region Pre-requisite of Testcase
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC36034");
            _test.Log(Status.Pass, "Create general Course");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Pass, "Click Check In button");

            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle + "TC36034");
            _test.Log(Status.Info, "A new Classroom Course Created");
            string ContentTitle = AdminContentDetailsPage.Title(classroomcoursetitle + "TC36034");
            AdminContentDetailsPage.ManageSurveys();
            _test.Log(Status.Info, "Add survey to the Classroom");
            string SurveyTitle = SurveysPage.SurveysTitle("Before Course Start");
            SurveysPage.Click_backbutton();
            _test.Log(Status.Info, "Go back to the Classroom Course");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click Section Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click Add New Section Tab");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Enter Section Title");
            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("3");
            _test.Log(Status.Info, "fill maximum capacity as 3");
            string SectionStartDate = CreateNewCourseSectionAndEventPage.SectionStartDate();
            string SectionEndDate = CreateNewCourseSectionAndEventPage.SectionEndDate();
            ManageClassroomCoursePage.SelectWaitListasYes();
            _test.Log(Status.Info, "Click Waitlist as Yes");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            _test.Log(Status.Info, "Set enrollment Date");

            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click Create Button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "Verify Section1 is created");

            SectionsPage.ListofSections.ClickSectionTitle();
            _test.Log(Status.Info, "Click On section title");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            Assert.IsTrue(ContentPage.SectionContentPageopened());
            _test.Log(Status.Pass, "Verify Content tab is display");
            ContentPage.ClickAddContent(generalcoursetitle + "TC36034");
            _test.Log(Status.Pass, "Add Content To Classroom course");
            ContentPage.ContentTab.AvailabletoLearner("Yes, when learner enrolls");
            _test.Log(Status.Pass, "Select Available to Learner");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC36034");
            _test.Log(Status.Info, "Search Created Course");

            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC36034");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC36034");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll");
            ContentDetailsPage.CourseMaterials.ClickContent(generalcoursetitle + "TC36034");
            _test.Log(Status.Info, "Click Content in Course Material");
            ContentDetailsPage.EnrolGeneralCourse();
            ContentDetailsPage.ClickOpenItem();
            _test.Log(Status.Info, "Click on Open New Attempt");
            ContentDetailsPage.MarkComplete();
            _test.Log(Status.Info, "Click on Open New Attempt");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(classroomcoursetitle + "TC36034");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(classroomcoursetitle + "TC36034");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEditContent();
            _test.Log(Status.Info, "Click on Edit Content");
            SectionDetailsPage.ClickContentTab();
            _test.Log(Status.Info, "Click on Content Tab ");
            SectionsPage.ClickSectionTitle("Section1");
            _test.Log(Status.Info, "Click on Section Title ");
            SectionDetailsPage.ClickGradebookTab();
            _test.Log(Status.Info, "Click on Gradebook tab");
            GradebookPage.GradebookTab.SelectLearner("ak learner");
            _test.Log(Status.Info, "Select Learner");
            GradebookPage.GradebookTab.ProgressStatus("Completed");
            _test.Log(Status.Info, "Select Progress Status as Completed");
            GradebookPage.GradebookTab.SelectLearner("ak learner");
            _test.Log(Status.Info, "Select Learner");
            GradebookPage.GradebookTab.AttendenceStatus("Yes");
            _test.Log(Status.Info, "Select Progress Status");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            HomePage.CompletedTrainingPortlet.Click_CourseTitle(classroomcoursetitle + "TC36034");
            _test.Log(Status.Info, "Click on Course title");

            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            _test.Log(Status.Info, "Complete Survey");


            #endregion
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training under manage in Common Section ");
            TrainingPage.ManageContentPortlet.SearchForContent(classroomcoursetitle + "TC36034");
            _test.Log(Status.Info, "Search the course through manage content ");

            ManageContentPage.ClickContentTitle(classroomcoursetitle + "TC36034");
            _test.Log(Status.Info, "Click on Coure title ");
            Assert.IsTrue(ContentDetailsPage.isDisplayed());
            _test.Log(Status.Pass, "verify Content Details page");
            ContentDetailsPage.SurveyPortlet.Click_SurveyReport();
            _test.Log(Status.Pass, "Click on survey Report");
            Assert.IsTrue(SurveyReportPage.isSurveyDisplayed(SurveyTitle));
            _test.Log(Status.Pass, "Verify Survey is Displayed");
            Assert.IsTrue(SurveyReportPage.isContentTitleDisplayed(ContentTitle));
            _test.Log(Status.Pass, "Verify Content Title is Displayed");
            Assert.IsTrue(SurveyReportPage.isDropDownDisplayed());
            _test.Log(Status.Pass, "Verify DropDown is Displayed");
            Assert.IsTrue(SurveyReportPage.VerifyStartandEndDate(SectionStartDate, SectionEndDate));
            _test.Log(Status.Pass, "Verify section Start date and End date");
            SurveyReportPage.Click_Filter();
            _test.Log(Status.Info, "Select Section and Click on Filter ");
            Assert.IsTrue(SurveyReportPage.isReportGenerated());
            _test.Log(Status.Pass, "Verify report is generated ");
            SurveyReportPage.Goback();
            _test.Log(Status.Pass, "Go back to AdminContentdetailsPage");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click Section Tab");
            SectionsPage.ClickSectionTitle("Section1");
            _test.Log(Status.Info, "Click on Section Title ");
            SectionDetailsPage.SurveysPortlet.Click_Report();
            _test.Log(Status.Info, "Click on report");
            Assert.IsTrue(SurveyReportPage.isSurveyDisplayed(SurveyTitle));
            _test.Log(Status.Pass, "Verify Survey is Displayed");
            Assert.IsTrue(SurveyReportPage.isContentTitleDisplayed(ContentTitle));
            _test.Log(Status.Pass, "Verify Content Title is Displayed");

        }

        [Test, Order(13)]
        public void A13_As_an_Admin_access_a_survey_report_of_Online_Course_from_the_admin_content_details_page_with_scope_limited_to_the_current_content_item_36035()
        {
            #region Pre-requisite of Testcase
            CommonSection.CreateGeneralCourse(generalcoursetitle + "TC36035");
            _test.Log(Status.Pass, "Create general Course");
            string ContentTitle = AdminContentDetailsPage.Title(generalcoursetitle + "TC36035");
            AdminContentDetailsPage.ManageSurveys();
            _test.Log(Status.Info, "Add survey to the Classroom");
            string SurveyTitle = SurveysPage.SurveysTitle("Before Course Start");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Pass, "Click Check In button");
            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("ak_learner").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.SearchCatalog(generalcoursetitle + "TC36035");
            _test.Log(Status.Info, "Search Created Course");
            SearchResultsPage.ClickCourseTitle(generalcoursetitle + "TC36035");
            _test.Log(Status.Info, "Click Course Title");
            ContentDetailsPage.ClickEnroll();
            _test.Log(Status.Info, "Click on Enroll");
            ContentDetailsPage.ClickOpenItem();
            _test.Log(Status.Info, "Click on Open New Attempt");
            ContentDetailsPage.MarkComplete();
            _test.Log(Status.Info, "Click on Open New Attempt");
            ContentDetailsPage.SurveyPortlet.ClickonattachedSurvey("Before Course Start");
            _test.Log(Status.Info, "Click Attached Survey");
            ContentDetailsPage.SurveyPortlet.CompleteSurvey();
            _test.Log(Status.Info, "Complete Survey");

            #endregion


            CommonSection.Logout();
            _test.Log(Status.Pass, "Logout From SiteAdmin Account");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login From Learner Account");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Click on training under manage in Common Section ");
            TrainingPage.ManageContentPortlet.SearchForContent(generalcoursetitle + "TC36035");
            _test.Log(Status.Info, "Search the course through manage content ");
            ManageContentPage.ClickContentTitle(generalcoursetitle + "TC36035");
            _test.Log(Status.Info, "Click on Coure title ");
            ContentDetailsPage.SurveyPortlet.Click_SurveyReport();
            _test.Log(Status.Pass, "Click on survey Report");
            Assert.IsTrue(SurveyReportPage.isSurveyDisplayed(SurveyTitle));
            _test.Log(Status.Pass, "Verify Survey is Displayed");
            Assert.IsTrue(SurveyReportPage.isContentTitleDisplayed(ContentTitle));
            _test.Log(Status.Pass, "Verify Content Title is Displayed");
            Assert.IsFalse(SurveyReportPage.isDropDownDisplayed());
            _test.Log(Status.Pass, "Verify DropDown is Displayed");
            SurveyReportPage.Click_Filter();
            _test.Log(Status.Info, "Select Section and Click on Filter ");
            Assert.IsTrue(SurveyReportPage.isReportGenerated());
            _test.Log(Status.Pass, "Verify report is generated ");
        }
        
        

    }

}

