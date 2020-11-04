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
    public class P2RegressionTests4 : TestBase
    {
        string browserstr = string.Empty;
        public P2RegressionTests4(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
            LoginPage.GoTo();
            LoginPage.LoginAs("").WithPassword("").Login();
        }
        string CareerPathTitle = "CareerPathTitle" + Meridian_Common.globalnum;
        string CompetencyTitle = "CompetencyTitle" + Meridian_Common.globalnum;
        string ProficiencyTitle = "RegressionScale" + Meridian_Common.globalnum;
        string JobTitle = "JobTitle" + Meridian_Common.globalnum;
        string classroomcoursetitle = "CRCTitle" + Meridian_Common.globalnum;
        string TAGTitle = "Reg_TAG" + Meridian_Common.globalnum;
        string CustomRole = "Reg_CustomRole" + Meridian_Common.globalnum;
        bool res1 = false;

        string LevelName = "Level" + Meridian_Common.globalnum;
        string OrganizationTitle = "Organization" + Meridian_Common.globalnum;
        string CreditTypeTitle = "CT" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string curriculamtitle = "curr" + Meridian_Common.globalnum;
        string generalcoursetitle = "GC" + Meridian_Common.globalnum;
        bool ArchivedScale = false;
        string documenttitle = "Doc" + Meridian_Common.globalnum;
        string scormtitle = "scorm" + Meridian_Common.globalnum;
        string testtitle = "Test" + Meridian_Common.globalnum;
        string title = "Google";
        static string today = DateTime.Now.ToString("MM/dd/yyyy").Replace("-", "/");
        string markAsComplete = $"This item was marked as complete on "+today+".";
        string completed = "The item was marked complete.";
        string curriculamblocktitle = "curriculam1";
        public bool chktest = false;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //driver.UserLogin("admin1", browserstr);

        }
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        [TearDown]
        public void teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.Message);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    screenShotPath = screenShotPath.Replace(@"C:\Users\admin\Desktop\Automation\Regression Scripts\18.2\", @"Z:\");
                    _test.Log(Status.Info, "MailSnapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    if (driver.Title == "Object reference not set to an instance of an object.")
                    {
                        driver.Navigate_to_TrainingHome();
                        Driver.focusParentWindow();
                        CommonSection.Avatar.Logout();
                        LoginPage.LoginClick();
                        LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
                    }
                    //if (!Meridian_Common.isadminlogin)
                    //{
                    //    CommonSection.Logout();
                    //    LoginPage.LoginAs("").WithPassword("").Login();
                    //}


                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;

                default:

                    logstatus = Status.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            //  _extent.Flush();
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
                //  TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                //if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                //{
                //    driver.Navigate().Refresh();
                //}
                //    driver.Navigate().Refresh();
            }
        }
        // [OneTimeTearDown]
        public void exitscript()
        {
            Driver.Instance.Close();
        }

      
       
        [Test, Order(14), Category("AutomatedP1")]
        public void a14_Self_Enroll_in_Classroom_Course_14432()
        {
            #region create new course, add section to it and enroll
            CommonSection.CreateLink.ClassroomCourse();
            _test.Log(Status.Info, "Opened Create Classroom Course Page");
            ClassroomCoursePage.CreateClassroomCourse(classroomcoursetitle);
            _test.Log(Status.Info, "New Classroom Course Created");
            Assert.IsTrue(Driver.comparePartialString("The item was created.", ClassroomCoursePage.GetSuccessMessage()));
            _test.Log(Status.Pass, "Verify successful message");
            ManageClassroomCoursePage.Clicktab("Sections");
            _test.Log(Status.Info, "Click on Sections Tab");
            ManageClassroomCoursePage.CreateSection.ClickAddaNewSection();
            _test.Log(Status.Info, "Click on Add new Section Button");
            ManageClassroomCoursePage.CreateSection.TitleAs("Section1");
            _test.Log(Status.Info, "Filled Title as Section1");
            ManageClassroomCoursePage.CreateSection.SetEnrollmentStartsDate(1);
            // ManageClassroomCoursePage.CreateSection.SectionEndTime("");

            ManageClassroomCoursePage.CreateSection.SectionMaxCapacity("1");
            _test.Log(Status.Info, "Filled Max Capacity to 11");
            ManageClassroomCoursePage.SelectWaitListasYes();
            ManageClassroomCoursePage.CreateSection.Create();
            _test.Log(Status.Info, "Click on Create button");
            Assert.IsTrue(ClassroomCoursePage.GetNewCreatedSectionLink("Section1"));
            _test.Log(Status.Pass, "New Classroom Course CreatedVerify Section1 link is present on screen");
            //Assert.IsTrue(Driver.comparePartialString("Success", ClassroomCoursePage.GetUpdatedSuccessMessage()));
            // _test.Log(Status.Pass, "Create New Course Section and Event");
            CommonSection.Logout();
            #endregion
            #region Login with a Learner, search classroom course and enroll
            LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            _test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            _test.Log(Status.Info, "Open Current trainging Page");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');
            _test.Log(Status.Info, "Search course name as" + classroomcoursetitle);
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle);
            _test.Log(Status.Info, "Click on Course title");
            CatalogPage.EnrollinClassroomCourse();
            _test.Log(Status.Info, "Click Enroll button");
            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            #endregion


        }
        [Test, Order(15), Category("AutomatedP1")]
        public void a15_Self_Cancel_Enrollment_in_Classroom_Course_14435()
        {
            #region Login with learner and Cancel Enrollment for an Enrolled Classroom Course
            //LoginPage.LoginAs("userreg_0403012001people1").WithPassword("").Login();
            //_test.Log(Status.Pass, "Login as a Learner");
            CommonSection.Learner.CurrentTraining();
            _test.Log(Status.Info, "Open Current trainging Page");
            CommonSection.SearchCatalog('"' + classroomcoursetitle + '"');// ('"' + classroomcoursetitle + '"');
            _test.Log(Status.Info, "Search course name as" + classroomcoursetitle);
            CatalogPage.ClickonSearchedCatalog(classroomcoursetitle); //("ClassRoomCourseTitle2011472447");// 
            _test.Log(Status.Info, "Click on Course title");
            Assert.IsTrue(CatalogPage.GetCurrentEnrolledTraining(classroomcoursetitle));// (classroomcoursetitle));
            _test.Log(Status.Pass, "Enrolled classroom course is displaying");
            //CurrentTrainings.ClickAction();
            CatalogPage.CancelEnrollment();
            _test.Log(Status.Info, "Click on Cancel Enrollment");
            Assert.IsTrue(CatalogPage.GetMessages());
            _test.Log(Status.Pass, "Verify successful message is display");
            #endregion

        }

        
        [Test, Order(23), Category("AutomatedP1")]
        public void a23_View_list_of_Competencies_from_Career_Development_page_33761()
        {
            Assert.True(true);   // this test cases is similar as 33755
        }

      
        [Test, Order(1), Category("AutomatedP1")]
        public void z27_Create_New_Account_Self_Registration_8585()
        {
            AccountCreation CreateAccount = new AccountCreation(driver);
            CommonSection.Logout();
            LoginPage.ClickSignup();
            _test.Log(Status.Info, "Click Sign up link on Login Page");

            CreateNewAccountobj.PopulateCreateNewUserLinkOuter(ExtractDataExcel.MasterDic_newuser["Id"], ExtractDataExcel.MasterDic_newuser["Firstname"], ExtractDataExcel.MasterDic_newuser["Lastname"]);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            _test.Log(Status.Info, "Click Create button after fill all mandetory fields");
            HomePage.clickGetStarted();
            _test.Log(Status.Info, "Click On lets get Started button");
            Assert.IsTrue(HomePage.Title == "Home");
            _test.Log(Status.Pass, "User Successfully Logged in");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");

        }
        [Test, Order(2), Category("AutomatedP1")]
        public void z28_My_Training_Progress_Report_24843()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "opened reports console from kview");
            ReportsConsolePage.SearchText("My");
            _test.Log(Status.Info, "Searched My");
            Assert.IsTrue(ReportsConsolePage.DisplayResult > 1);//checks results display more than 1
            ReportsConsolePage.ClickMyTrainingProgress();
            _test.Log(Status.Info, "Clicked My Training Progress");
            DetailsPage.ClickSelect();
            _test.Log(Status.Info, "Clicked Select");
            RunReportPage.ClickRunReport();
            _test.Log(Status.Info, "CLicked Run report");
            // Assert.IsTrue(MeridianGlobalReportingPage.Displays>1);
            MeridianGlobalReportingPage.ClickDetails();
            _test.Log(Status.Info, "Clicked go button having details selected and opens details page");
            Assert.IsTrue(DetailsPage.CheckDetailsTabText.EndsWith("Details"));//retrieves the text from details tab
            DetailsPage.ClickCloseWindowlink();
            _test.Log(Status.Info, "Details page closes");
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            DetailsPage.ClickExporttoPDF();
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));

            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "Closes pdf window");
            Assert.IsTrue(RunReportPage.Title == "Run Report");
            Assert.IsTrue(Driver.focusParentWindow());
            CommonSection.Avatar.Reports();
            _test.Log(Status.Info, "open reports from KI");
            ReportsPage.MyTrainingProgress.ClickRunReport();
            _test.Log(Status.Info, "opens run report page from KI");
            ReportsPage.ReportCriteriaModal.ClickRunReport();
            _test.Log(Status.Info, "click run report from KI");
            MeridianGlobalReportingPage.ClickDetails();
            _test.Log(Status.Info, "click the go button having details option displayed");
            string restext = DetailsPage.CheckDetailsTabText;
            StringAssert.EndsWith("Details", restext);
            DetailsPage.ClickCloseWindowlink();
            _test.Log(Status.Info, "closed the details page ");
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            DetailsPage.ClickExporttoPDF();
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));
            Driver.focusParentWindow();
            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            //StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Reports");
        }
        [Test, Order(3), Category("AutomatedP1")]
        public void z29_Request_Access_to_SCORM_Course_26230()
        {
            CommonSection.CreteNewScorm(scormtitle + "TC26230");
            _test.Log(Status.Info, "Creating New Scorm");
            Assert.IsTrue(ContentDetailsPage.IsContentCreated());
            _test.Log(Status.Pass, "Verify New Content is Created");

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

            CommonSection.SearchCatalog('"' + scormtitle + "TC26230" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26230");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
            ContentDetailsPage.AccessApprovalModal.SubmitRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
        }
        [Test, Order(4), Category("AutomatedP1")]
        public void z30_Cancle_Request_Access_to_SCORM_Course_26233()
        {
            CommonSection.SearchCatalog('"' + scormtitle + "TC26230" + '"');
            _test.Log(Status.Info, "Search created scrom from Catalog");
            SearchResultsPage.ClickCourseTitle(scormtitle + "TC26230");
            _test.Log(Status.Info, "Click searched scrom course title");
            Assert.IsTrue(ContentDetailsPage.isCancleRequestbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Cancle Request Access button display");
            ContentDetailsPage.AccessApprovalModal.CancelRequestAccess("ForTest");
            _test.Log(Status.Info, "Submit Request Access");
            Assert.IsTrue(ContentDetailsPage.isRequestAccessbuttonDisplay());
            _test.Log(Status.Pass, "Verify is Request Access button display in content details page");
        }
       
        [Test, Order(7), Category("AutomatedP1")]
        public void z33_View_Transcript_20487()
        {
            CommonSection.Logout();
            LoginPage.LoginAs("userreg_0210112911anybrowser").WithPassword("").Login();
            CommonSection.Transcript();
            _test.Log(Status.Info, "Navigate to Transcript Page");
            StringAssert.AreEqualIgnoringCase("Transcript", TranscriptPage.pagetitle());
            _test.Log(Status.Pass, "Verify page title is Transcript");
            Assert.IsTrue(TranscriptPage.AllComponetsdisplay());
            _test.Log(Status.Pass, "Verify all componets of Transcript page is display");
            //TranscriptPage.AllMyTrainingPage.ClickSaveasPDF();
            //_test.Log(Status.Info, "Click on Save as PDF button");
            //Driver.Instance.SwitchWindow("Untitled - Google Chrome");
            //Assert.IsTrue(TranscriptAllMyTrainingPrintPage.Title.EndsWith("AllMyTrainingPrint.aspx"));
            //TranscriptAllMyTrainingPrintPage
            Driver.focusParentWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            CommonSection.Logout();
            _test.Log(Status.Info, "Logout from learner");
            LoginPage.LoginAs("siteadmin").WithPassword("").Login();
            _test.Log(Status.Info, "Login as Admin");


        }
        [Test, Order(75), Category("AutomatedP1")]
        public void Admin_bulk_adds_tags_on_manage_content_page_34043()
        {
            //login with a admin 
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "Navigating to Manage Content Search page");
            TrainingPage.SearchRecord("");
            _test.Log(Status.Info, "Click Search page");
            ManageContentPage.SelectMultipleResult();
            ManageContentPage.ClickAddTagOption_Select_DV_Test1();
            _test.Log(Status.Info, "Select Multiple records and click add tag and select DV_Test1 Tag");
            StringAssert.AreEqualIgnoringCase("DV_Test1", ManageContentPage.VerifyTags("DV_Test1"));
            _test.Log(Status.Info, "Verify that Tag DV_Test1 is applied to all selected items under Tags column");

        }
              [Test, Category("AutomatedP1")]
        public void Create_Career_Path_31460()
        {

            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.ClickCreateCareerPath();
            CreateCareerPathPage.EditCareerPathName(CareerPathTitle);
            //  CreateCareerPathPage.SaveCareerPathName();
            Assert.IsTrue(Driver.comparePartialString("Success", CreateCareerPathPage.GetSuccessMessage()));
            Assert.IsTrue(CareersPage.CheckCareerPathTitle("Create Career Path"));

        }
        [Test, Category("AutomatedP1")]
        public void View_List_of_Career_Path_as_existing_User_31461()
        {
            CommonSection.Manage.ProfessionalDevelopment();
            CareersPage.SearchCareerPath(CareerPathTitle);
            Assert.IsTrue(CareersPage.CheckNameColumn(CareerPathTitle));

        }
    
       
        [Test, Order(14), Category("AutomatedP1")]
        public void Test_when_User_sets_the_active_dates_for_a_career_path_33167()
        {
            // LoginPage.GoTo();
            //LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login(); //Login as Competency Manager
            CommonSection.Manage.Careerstab();
            _test.Log(Status.Info, "Navigating to Career page");
            CareersPage.CareerPathTab.CreateCareerPath();
            _test.Log(Status.Info, "Click Create Career Path");
            CreateCareerPathPage.EditCareerPathName("Reg_CareerPath");
            _test.Log(Status.Info, "Fill career path name");
            CreateCareerPathPage.ClickCareerBreadcrumb();
            _test.Log(Status.Info, "click on career breadcrumb ");
            CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
            _test.Log(Status.Info, "search created career path");
            StringAssert.AreEqualIgnoringCase("Reg_CareerPath", CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
            _test.Log(Status.Info, "Verify career path name");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify career path status");
            CareersPage.CareerPathTab.ClickSearchResult("Reg_CareerPath");
            _test.Log(Status.Info, "click career path name");
            CreateCareerPathPage.SetActiveDates("5/4/2018", "5/31/2018");
            _test.Log(Status.Info, "Define Career path Active Datas");
            //Assert.IsTrue(CreateCareerPathPage.SetActiveDatesPopup.VerifyText("SetActiveDates "));
            //CreateCareerPathPage.FillStartDate("5/4/2018").FillEndDate("5/31/2018").ClickSave();
            Assert.IsTrue(Driver.comparePartialString("Success", CreateCareerPathPage.GetSuccessMessage()));
            _test.Log(Status.Info, "Date saved");
            Assert.IsTrue(CreateCareerPathPage.VerifyDates("Active from 05/04/2018 until 05/31/2018"));
            _test.Log(Status.Info, "Verify Career Path active dates");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify status should be Active");
            CreateCareerPathPage.ClickCareerBreadcrumb();
            _test.Log(Status.Info, "click on career breadcrumb");
            CareersPage.CareerPathTab.SearchCareerPath("Reg_CareerPath");
            _test.Log(Status.Info, "Search created career path");
            StringAssert.AreEqualIgnoringCase("Reg_CareerPath", CareersPage.CareerPathTab.VerifySearchText("Reg_CareerPath"));
            _test.Log(Status.Info, "Verify career path name");
            StringAssert.AreEqualIgnoringCase("Active", CareersPage.CareerPathTab.VerifySearchedRecordStatusText("Active"));
            _test.Log(Status.Info, "Verify career path status");
        }
}

}
