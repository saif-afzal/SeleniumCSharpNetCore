using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using relativepath;
using OpenQA.Selenium.Remote;
using System.Reflection;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using Selenium2.Meridian.Suite;
using System.Diagnostics;
using TestAutomation.Miscellaneous;

namespace Selenium2.Meridian.Smoke
{
    [TestFixture("1",Category = "chrome")]
    //[TestFixture("2",Category = "chrome")]
    //[TestFixture("3",Category = "chrome")]
    //[TestFixture("4",Category = "chrome")]
    //[TestFixture("5",Category = "chrome")]
    [Parallelizable(ParallelScope.Fixtures)]
    class SmokeTest_All : TestBase
    {
        string rootfolder = string.Empty;
        string foldertodll = AppDomain.CurrentDomain.BaseDirectory;
        string excelpath = string.Empty;
        string url = string.Empty;
        string username = string.Empty;
        string passwd = string.Empty;

        ReadExcel test = new ReadExcel();
        string browserstr = string.Empty;
        string _afterLoginUrl;
       
      


        public SmokeTest_All(string browser)
            : base(browser)
        {
            browserstr = browser;
            url = new TestBase(browser).Url(browser);
            Driver.Instance = Driver.Initialize(url);


          //  url = new TestBase(browser).Url(browser);
            //rootfolder = new TestBase(browser).rootfolder(browser);
            username = new TestBase(browser).username(browser);
            passwd = new TestBase(browser).passwd(browser);
            // excelpath = rootfolder + "Regression2.xlsx";
         


        }
        string CareerPathTitle = "CareerPathTitle" + Driver.generateRandom(1, 100);
        string CompetencyTitle = "CompetencyTitle" + Driver.generateRandom(1, 100);
        string JobTitle = "JobTitle" + Driver.generateRandom(1, 100);

        //  [OneTimeSetUp]
        public void Login()
        {

            //LoginPage.GoTo();
            ////    LoginPage.LoginClick();
            //LoginPage.LoginAs("").WithPassword("").Login();
        }
        [SetUp]
        public void starttest()
        {
            //_extent.AddSystemInfo("Environment", url);
            //_extent.AddSystemInfo("Browser", "chrome");
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }
        [TearDown]
        public void teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(Driver.Instance, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

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

        [Test, Category("Smoke"), Order(1)]
        public void LoginSmoke()
        {
            LoginPage.GoTo(url);
            LoginPage.LoginClick();
            LoginPage.LoginAs(username).WithPassword(passwd).Login();
            Assert.IsTrue(HomePage.Title == "Home");//checks the Home page title
        }
        [Test, Category("Smoke"), Order(2)]
        public void Help()
        {
            CommonSection.ClickHelpIcon();
            Assert.IsTrue(HelpPage.CheckTitle());//checks the Help page with one click in it
        }
        [Test, Category("Smoke"), Order(3)]
        public void Search()
        {

            CommonSection.CatalogSearchText("Test");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Test") >= 1);//chcks the records are not zero
            CommonSection.Manage.People();
            ManageUsersPage.SearchUser("");
            Assert.IsTrue(ManageUsersPage.DisplaysUserlist >= 1);//checks people search is working
        }
        [Test, Category("Smoke"), Order(4)]
        public void Administration()
        {
            CommonSection.Administer.People.Organizations();
            OrganizationsPage.ClickSearch();
            Assert.IsTrue(OrganizationsPage.DisplaySearchRecords > 1);//checks Organization search is working
            CommonSection.Manage.Careerstab();
            // CommonSection.Administer.People.JobTitles();not avaialable in 18.1
            CareersPage.JobTitleKI.SearchJobtitle("");
            Assert.IsTrue(CareersPage.JobTitleKI.DisplaySearchRecords >= 1);
            //   JobTitlesPage.SearchJobtitle("");not avaialable in 18.1
            //  Assert.IsTrue(JobTitlesPage.DisplaySearchRecords > 1);//checks Jobtitle search is working

            CommonSection.Administer.System.BrandingAndCustomization.HomepageCustomization();
            Assert.IsTrue(HomePage.Title == "Home");// just checks the title
        }
        [Test, Category("Smoke"), Order(5)]
        public void Reports()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            ReportsConsolePage.SearchText("My");
            Assert.IsTrue(ReportsConsolePage.DisplayResult > 1);//checks results display more than 1
            ReportsConsolePage.ClickMyTrainingProgress();
            DetailsPage.ClickSelect();
            RunReportPage.ClickRunReport();
            // Assert.IsTrue(MeridianGlobalReportingPage.Displays>1);
            MeridianGlobalReportingPage.ClickDetails();
            Assert.IsTrue(DetailsPage.CheckDetailsTabText.EndsWith("Details"));//retrieves the text from details tab
            DetailsPage.ClickCloseWindowlink();
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            DetailsPage.ClickExporttoPDF();
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));
            //   MyTrainingProgressPDFPage.ClickBrowsertabX();
            //   Assert.IsTrue(DetailsPage.Displays>1);
            MeridianGlobalReportingPage.CloseWindow();
            Assert.IsTrue(RunReportPage.Title == "Run Report");
            CommonSection.Avatar.Reports();
            ReportsPage.MyTrainingProgress.ClickRunReport();
            ReportsPage.ReportCriteriaModal.ClickRunReport();
            MeridianGlobalReportingPage.ClickDetails();
            Assert.IsTrue(DetailsPage.CheckDetailsTabText.EndsWith("Details"));
            DetailsPage.ClickCloseWindowlink();
            Assert.IsTrue(MeridianGlobalReportingPage.Title == "Meridian Global Reporting");
            // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays > 1);
            DetailsPage.ClickExporttoPDF();
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));

            MeridianGlobalReportingPage.CloseWindow();
            StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Reports");

        }
        [Test, Category("Smoke"), Order(6)]
        public void Upload_Launch_Course()
        {
            CommonSection.CreateLink.SCORM();
            CreatePage.ClickBrowsebutton();
            //  CreatePage.UploadScormfile("\\fileserver\\maindrive\\product_team\\SCORM\\SCORM_1_2\\maritime_navigation_exam_only.zip");
            //  CreatePage.ClickCreatebutton();
            Assert.IsTrue(SummaryPage.Title == "Summary");
            StringAssert.AreEqualIgnoringCase("The course was created.", SummaryPage.GetSuccessMessage(), "Error message is different");
            SummaryPage.UpdateTitle("Maritime Navigation - Exam only for Automation Test");
            //   SummaryPage.ClickSavebutton();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", AdminContentDetailsPage.GetSuccessMessage(), "Error message is different");
            AdminContentDetailsPage.ClickCheckInbutton();
            CommonSection.CatalogSearchText("Migration");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Maritime Navigation - Exam only for Automation Test") >= 1);
            SearchResultsPage.ClickCourseTitle("Maritime Navigation - Exam only for Automation Test");
            Assert.IsTrue(AdminContentDetailsPage.CheckCourseTitle("Maritime Navigation - Exam only for Automation Test"));
            AdminContentDetailsPage.ClickOpenItembutton();
            Assert.IsTrue(CourseLaunchModalPage.Exist("Maritime Navigation - Exam only for Automation Test"));
            // CourseLaunchModalPage.ClickBrowserX();
            Assert.IsTrue(AdminContentDetailsPage.CheckResumeButton());

            CommonSection.Manage.Training();
            TrainingPage.ManageContentPortlet.SearchForContent("Migration");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Maritime Navigation - Exam only for Automation Test") >= 1);
            SearchResultsPage.ClickCourseTitle("Maritime Navigation - Exam only for Automation Test");
            AdminContentDetailsPage.Summary.ClickViewButton();//need towrite the code
            Assert.IsTrue(SummaryPage.Title == "Maritime Navigation - Exam only for Automation Test");//need towrite the code
            Assert.IsTrue(AdminContentDetailsPage.CheckCourseTitleOnClickingEditButton("Maritime Navigation - Exam only for Automation Test"));
            AdminContentDetailsPage.DeleteContent();

            StringAssert.StartsWith("Success", AdminContentDetailsPage.GetRemovalSuccessMessage(), "Error message is different");
            //  SearchResultsPage.Search("Maritime Navigation - Exam only for Migration Test");
            //    Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Maritime Navigation - Exam only for Migration Test")==0);
        }

     


        [Test, Category("Smoke"), Order(9)]
        public void Other()
        {
            CommonSection.SearchCatalog("");
            //CommonSection.Learn.Home();
            HomePage.ClickAboutLink();
            Assert.IsTrue(HomePage.ClickModalX());
            Assert.IsTrue(HomePage.Title == "Search Results");


            CommonSection.Administer.System.SystemAdministration.SystemCertificate("Certificates");
            Assert.IsTrue(SystemCertificatePage.Title == "System Certificate");
            SystemCertificatePage.Preview("Default");
            Assert.IsTrue(CertificatePage.VerifyFileDownload("\\Certificate.pdf"));
            Assert.IsTrue(SystemCertificatePage.Title == "System Certificate");
         
            foreach (Process Proc in (from p in Process.GetProcesses()
                                      where p.ProcessName == "chromedriver" || p.ProcessName == "chrome"
                                      select p))
            {
                // "Kill" the process
                Proc.Kill();
            }



        }
    }

   

}
