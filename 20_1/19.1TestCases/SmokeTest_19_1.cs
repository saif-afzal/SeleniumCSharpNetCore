using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TestAutomation.Miscellaneous;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;

namespace Selenium2.Meridian.Suite
{

    //[TestFixture("ffbs", Category = "firefox")]
    // [TestFixture("chbs", Category = "chrome")]
    //[TestFixture("iebs", Category = "iexplorer")]
    //[TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    ////   [Parallelizable(ParallelScope.Fixtures)]
    public class SmokeTest_19_1 : TestBase
    {
        string browserstr = string.Empty;
        public SmokeTest_19_1(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
        }
        string CareerPathTitle = "CareerPathTitle" + Driver.generateRandom(1, 100);
        string CompetencyTitle = "CompetencyTitle" + Driver.generateRandom(1, 100);
        string JobTitle = "JobTitle" + Driver.generateRandom(1, 100);

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
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

            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }
        // [TearDown]
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

                    driver.Navigate_to_TrainingHome();
                    Driver.focusParentWindow();
                    CommonSection.Avatar.Logout();
                    LoginPage.LoginClick();
                    LoginPage.LoginAs("siteadmin").WithPassword("password").Login();

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
        public void LoginSmoke_8597()
        {
            LoginPage.GoTo();
            _test.Log(Status.Pass, "Site opens successfully");
            LoginPage.LoginClick();
            _test.Log(Status.Pass, "Login CLick passes");
            LoginPage.LoginAs("siteadmin").WithPassword("LM$@dm1n").Login();
            _test.Log(Status.Pass, "login as siteadmin successful");
            Assert.IsTrue(HomePage.Title == "Home");//checks the Home page title
        }
        [Test, Category("Smoke"), Order(2)]
        public void Help_238()
        {
            CommonSection.ClickHelpIcon();
            _test.Log(Status.Pass, "help icon opens successfully");
            Assert.IsTrue(HelpPage.CheckTitle());//checks the Help page with one click in it

        }
        [Test, Category("Smoke"), Order(3)]
        public void Search_6833()
        {

            CommonSection.CatalogSearchText("Test");
            _test.Log(Status.Info, "Test searched successfully from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Test") >= 1);//chcks the records are not zero
            _test.Log(Status.Pass, "search record is greater than 1"); //CommonSection.Manage.People();
            CommonSection.Manage.People();
            _test.Log(Status.Info, "open people page from common section ");

            ManageUsersPage.SearchUser("");
            _test.Log(Status.Info, "blank search takes place from manage users page");
            Assert.IsTrue(ManageUsersPage.DisplaysUserlist >= 1);//checks people search is working
            _test.Log(Status.Pass, "search record is greater than 1");

        }
        [Test, Category("Smoke"), Order(4)]
        public void Administration_Organization_Search_56127()
        {
            CommonSection.Administer.People.Organizations();
            _test.Log(Status.Info, "Organization page opens");
            OrganizationsPage.ClickSearch();
            _test.Log(Status.Info, "Done Blank search");
            Assert.IsTrue(OrganizationsPage.DisplaySearchRecords > 1);//checks Organization search is working
        }


        [Test, Category("Smoke"), Order(5)]
        public void Careers_Manage_JobTitle_22212() // used this test cases for job title search
        {

            CommonSection.Manage.Careers.JobTitletab();
            _test.Log(Status.Info, "Opened Careers page");
            // CommonSection.Administer.People.JobTitles();not avaialable in 18.1
            CareersPage.JobTitleKI.SearchJobtitle("");
            _test.Log(Status.Info, "did blank search in job tiltle");
            Assert.IsTrue(CareersPage.JobTitleKI.DisplaySearchRecords >= 1);
            //   JobTitlesPage.SearchJobtitle("");not avaialable in 18.1
            //  Assert.IsTrue(JobTitlesPage.DisplaySearchRecords > 1);//checks Jobtitle search is working
        }
        [Test, Category("Smoke"), Order(6)]
        public void Administration_HomePage_Customization_23935()
        {
            CommonSection.Administer.System.BrandingAndCustomization.HomepageCustomization();
            _test.Log(Status.Info, "opened home customization page");
            Assert.IsTrue(HomePage.Title == "Home");// just checks the title
        }
        [Test, Category("Smoke"), Order(7)]
        public void Reports_24843()
        {
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
            //   MyTrainingProgressPDFPage.ClickBrowsertabX();
            //   Assert.IsTrue(DetailsPage.Displays>1);
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

            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "CLose window meridian global reporting page");
            StringAssert.AreEqualIgnoringCase(RunReportPage.Title, "Reports");

        }
        [Test, Category("Smoke"), Order(8)]
        public void Create_SCROM_Course_7251()
        {
            CommonSection.CreateLink.SCORM();
            _test.Log(Status.Info, "open scorm page");
            CreatePage.ClickBrowsebutton();
            _test.Log(Status.Info, "browse the content and click create button");
            //  //  CreatePage.UploadScormfile("\\fileserver\\maindrive\\product_team\\SCORM\\SCORM_1_2\\maritime_navigation_exam_only.zip");
            //  CreatePage.ClickCreatebutton();
            Assert.IsTrue(SummaryPage.Title == "Summary", "Expected = Summary, but actual was " + SummaryPage.Title);
            StringAssert.AreEqualIgnoringCase("The course was created.", SummaryPage.GetSuccessMessage(), "Error message is different");
            SummaryPage.UpdateTitle("Maritime Navigation - Exam only for Migration Test");
            //   SummaryPage.ClickSavebutton();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", ContentDetailsPage.GetSuccessMessage(), "Error message is different");
            ContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Checkin scorm course");
        }
        [Test, Category("Smoke"), Order(9)]
        public void Search_SCROM_Course_26248()
        {
            CommonSection.CatalogSearchText("Maritime Navigation - Exam only for Migration Test");
            _test.Log(Status.Info, "search migration");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Maritime Navigation - Exam only for Migration Test") >= 1);
            SearchResultsPage.ClickCourseTitle("Maritime Navigation - Exam only for Migration Test");
            _test.Log(Status.Info, "opens searched content link");
            Assert.IsTrue(ContentDetailsPage.CheckCourseTitle("Maritime Navigation - Exam only for Migration Test"));
            //ContentDetailsPage.ContentBanner.ClickEnrollButton();
            ContentDetailsPage.ClickOpenItembutton();
            _test.Log(Status.Info, "Enrols and open the scorm course");
            Assert.IsTrue(CourseLaunchModalPage.Exist("Maritime Navigation - Exam only for Migration Test"));
            // CourseLaunchModalPage.ClickBrowserX();
            Assert.IsTrue(ContentDetailsPage.ContentBanner.isContinueButtonDisplsplay());
        }
        [Test, Category("Smoke"), Order(10)]
        public void Delete_SCROM_Course_7438()
        {
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "open training page");
            TrainingPage.ManageContentPortlet.SearchForContent("Migration");
            _test.Log(Status.Info, "search for content migration");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Migration") >= 1);
            SearchResultsPage.ClickCourseTitle("Maritime Navigation - Exam only for Migration Test");
            _test.Log(Status.Info, "click the searjced title link");
            ContentDetailsPage.Summary.ClickViewButton();//need towrite the code
            _test.Log(Status.Info, "CLick view button");
            Assert.IsTrue(SummaryPage.Title == "Maritime Navigation - Exam only for Migration Test");//need towrite the code
            Assert.IsTrue(ContentDetailsPage.CheckCourseTitleOnClickingEditButton("Maritime Navigation - Exam only for Migration Test"));
            ContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "deleting the content");
            //  StringAssert.StartsWith("Success", ContentDetailsPage.GetRemovalSuccessMessage(), "Error message is different");
            CommonSection.Manage.Training();
            _test.Log(Status.Info, "open training page");
            TrainingPage.ManageContentPortlet.SearchForContent("Migration");
            _test.Log(Status.Info, "search for content migration");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Migration") == 0);
        }

        //    //  [Test, Category("Smoke"), Order(8)]
        //    public void Navigate_to_Public_Catalog()
        //    {
        //        Driver.Instance.Navigate().GoToUrl("https://prodsupport-ki-17-3.meridianksi.net/public/trainingcatalog.aspx");
        //        //EnterURL("baseqa-17-3-m-c1.meridianksi.net/public/trainingcatalog.aspx");
        //        Assert.IsTrue(CatalogPage.Title == "Public Catalog");
        //        CatalogPage.SearchContent();
        //        Assert.IsTrue(SearchResultsPage.CheckSearchRecord("") > 1);
        //        SearchResultsPage.ClickCourseTitle("");
        //        Assert.IsTrue(ContentDetailsPage.CheckCourseTitle(""));

        //    }

        //    //  [Test, Category("Smoke"), Order(7)]

        //    public void Social()
        //    {
        //        CommonSection.Learn.Spaces();
        //        Assert.IsTrue(SpacesPage.CheckTitle == "Collaboration Spaces");
        //        SpacesPage.TypePublicSpace.ClickSpaceTitle();
        //        SpacesPage.SpaceTitlePage.ClickJoinButton();
        //        StringAssert.AreEqualIgnoringCase("You Joined the Collaboration Space", SpacesPage.GetSuccessMessage(), "Error message is different");
        //        SpacesPage.SpaceTitlePage.SelectAccessSpace();
        //        Assert.IsTrue(CSLaunchPage.Exist());

        //    }

        [Test, Category("Smoke"), Order(11)]
        public void About_the_System_Link_7662()
        {
            CommonSection.SearchCatalog("");
            _test.Log(Status.Info, "do blank catalog search");
            //CommonSection.Learn.Home();
            HomePage.ClickAboutLink();
            _test.Log(Status.Info, "CLick about link");
            Assert.IsTrue(HomePage.ClickModalX());
            Assert.IsTrue(HomePage.Title == "Search Results");

        }
        [Test, Category("Smoke"), Order(12)]
        public void View_System_Certificate_35597()
        {
            CommonSection.Administer.System.SystemAdministration.SystemCertificate("Certificates");
            _test.Log(Status.Info, "opens certificate page");
            Assert.IsTrue(SystemCertificatePage.Title == "System Certificate");
            SystemCertificatePage.Preview("Default");
            _test.Log(Status.Info, "CLick default button");
            Assert.IsTrue(CertificatePage.VerifyFileDownload("\\Certificate.pdf"));
            Assert.IsTrue(SystemCertificatePage.Title == "System Certificate");

        }

    }
}
