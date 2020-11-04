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

    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SmokeTestProd : TestBase
    {
        string browserstr = string.Empty;
        public SmokeTestProd(string browser)
             : base(browser)
        {
            browserstr = browser;
            Driver.Instance = driver;
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
     
        [Test,Category("Smoke"),Order(1)]
        public void LoginSmoke()
        {
            _test.Log(Status.Pass, "Site opens successfully");
            LoginPage.GoTo();
            _test.Log(Status.Pass, "Login CLick passes");
            LoginPage.LoginClick();
            
            LoginPage.LoginAs("siteadmin").WithPassword("LM$@dm1n").Login();
            _test.Log(Status.Pass, "login as siteadmin successful");
            Assert.IsTrue(HomePage.Title=="Home");//checks the Home page title
        }
        [Test, Category("Smoke"),Order(2)]
        public void Help()
        {
            CommonSection.ClickHelpIcon();
            _test.Log(Status.Pass, "help icon opens successfully");
            Assert.IsTrue(HelpPage.CheckTitle());//checks the Help page with one click in it
         
        }
        [Test, Category("Smoke"),Order(3)]
        public void Search()
        {
            
            CommonSection.CatalogSearchText("Test");
            _test.Log(Status.Info, "Test searched successfully from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Test")>=1);//chcks the records are not zero
                                                                          // _test.Log(Status.Info, "search record is greater than 1"); CommonSection.Manage.People();
            CommonSection.Manage.People();
            _test.Log(Status.Info, "open people page from common section ");

            ManageUsersPage.SearchUser("");
            _test.Log(Status.Info, "blank search takes place from manage users page");
            Assert.IsTrue(ManageUsersPage.DisplaysUserlist>=1);//checks people search is working
         
        }
        [Test, Category("Smoke"),Order(4)]
        public void Administration()
        {
            CommonSection.Administer.People.Organizations();
            _test.Log(Status.Info, "Organization page opens");
            OrganizationsPage.ClickSearch();
            _test.Log(Status.Info, "Done Blank search");
            Assert.IsTrue(OrganizationsPage.DisplaySearchRecords > 1);//checks Organization search is working
            CommonSection.Manage.Careers.JobTitletab();
            _test.Log(Status.Info, "Opened Careers page");
            // CommonSection.Administer.People.JobTitles();not avaialable in 18.1
            CareersPage.JobTitleKI.SearchJobtitle("");
            _test.Log(Status.Info, "did blank search in job tiltle");
            Assert.IsTrue(CareersPage.JobTitleKI.DisplaySearchRecords >= 1);
            //   JobTitlesPage.SearchJobtitle("");not avaialable in 18.1
            //  Assert.IsTrue(JobTitlesPage.DisplaySearchRecords > 1);//checks Jobtitle search is working

            CommonSection.Administer.System.BrandingAndCustomization.HomepageCustomization();
            _test.Log(Status.Info, "opened home customization page");
            Assert.IsTrue(HomePage.Title=="Home");// just checks the title
        }
        [Test, Category("Smoke"),Order(5)]
        public void Reports()
        {
            CommonSection.Administer.System.Reporting.ReportConsole();
            _test.Log(Status.Info, "opened reports console from kview");
            ReportsConsolePage.SearchText("My");
            _test.Log(Status.Info, "Searched My");
            Assert.IsTrue(ReportsConsolePage.DisplayResult>1);//checks results display more than 1
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
            Assert.IsTrue(MeridianGlobalReportingPage.Title=="Meridian Global Reporting");
           // RunReportPage.ClickRunReport();
            Assert.IsTrue(MeridianGlobalReportingPage.Displays>1);
            DetailsPage.ClickExporttoPDF();
            _test.Log(Status.Info, "CLick export to pdf");
            Assert.IsTrue(MyTrainingProgressPDFPage.Title.EndsWith("My_Training_Progress.pdf"));
         //   MyTrainingProgressPDFPage.ClickBrowsertabX();
         //   Assert.IsTrue(DetailsPage.Displays>1);
            MeridianGlobalReportingPage.CloseWindow();
            _test.Log(Status.Info, "Closes pdf window");
            Assert.IsTrue(RunReportPage.Title=="Run Report");
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
           StringAssert.EndsWith("Details",restext);
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
            StringAssert.AreEqualIgnoringCase(RunReportPage.Title,"Reports");
     
        }
        [Test, Category("Smoke"), Order(6)]
        public void Upload_Launch_Course()
        {
            CommonSection.CreateLink.SCORM();
            _test.Log(Status.Info, "open scorm page");
            CreatePage.ClickBrowsebutton();
            _test.Log(Status.Info, "browse the content and click create button");
            //  //  CreatePage.UploadScormfile("\\fileserver\\maindrive\\product_team\\SCORM\\SCORM_1_2\\maritime_navigation_exam_only.zip");
            //  CreatePage.ClickCreatebutton();
            Assert.IsTrue(SummaryPage.Title=="Summary");
            StringAssert.AreEqualIgnoringCase("The course was created.", SummaryPage.GetSuccessMessage(), "Error message is different");
            SummaryPage.UpdateTitle("Maritime Navigation - Exam only for Migration Test");
         //   SummaryPage.ClickSavebutton();
            StringAssert.AreEqualIgnoringCase("The changes were saved.", AdminContentDetailsPage.GetSuccessMessage(), "Error message is different");
            AdminContentDetailsPage.ClickCheckInbutton();
            _test.Log(Status.Info, "Checkin scorm course");
            CommonSection.CatalogSearchText("Migration");
            _test.Log(Status.Info, "search migration");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Maritime Navigation - Exam only for Migration Test")>=1);
            SearchResultsPage.ClickCourseTitle("Maritime Navigation - Exam only for Migration Test");
            _test.Log(Status.Info, "opens searched content link");
            Assert.IsTrue(AdminContentDetailsPage.CheckCourseTitle("Maritime Navigation - Exam only for Migration Test"));
            AdminContentDetailsPage.ClickOpenItembutton();
            _test.Log(Status.Info, "Enrols and open the scorm course");
            Assert.IsTrue(CourseLaunchModalPage.Exist("Maritime Navigation - Exam only for Migration Test"));
           // CourseLaunchModalPage.ClickBrowserX();
            Assert.IsTrue(AdminContentDetailsPage.CheckResumeButton());

            CommonSection.Manage.Training();
            _test.Log(Status.Info, "open training page");
            TrainingPage.ManageContentPortlet.SearchForContent("Migration");
            _test.Log(Status.Info, "search for content migration");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Maritime Navigation - Exam only for Migration Test")>=1);
            SearchResultsPage.ClickCourseTitle("Maritime Navigation - Exam only for Migration Test");
            _test.Log(Status.Info, "click the searjced title link");
            AdminContentDetailsPage.Summary.ClickViewButton();//need towrite the code
            _test.Log(Status.Info, "CLick view button");
            Assert.IsTrue(SummaryPage.Title== "Maritime Navigation - Exam only for Migration Test");//need towrite the code
            Assert.IsTrue(AdminContentDetailsPage.CheckCourseTitleOnClickingEditButton("Maritime Navigation - Exam only for Migration Test"));
            AdminContentDetailsPage.DeleteContent();
            _test.Log(Status.Info, "deleting the content");
            //  StringAssert.StartsWith("Success", ContentDetailsPage.GetRemovalSuccessMessage(), "Error message is different");
            CommonSection.SearchCatalog("Maritime Navigation - Exam only for Migration Test");
            Assert.IsTrue((SearchResultsPage.ReturnFirstRecordTitle()!="Maritime Navigation - Exam only for Migration Test"));
        }

      //  [Test, Category("Smoke"), Order(8)]
        public void Navigate_to_Public_Catalog()
        {
            Driver.Instance.Navigate().GoToUrl("https://prodsupport-ki-17-3.meridianksi.net/public/trainingcatalog.aspx");
            //EnterURL("baseqa-17-3-m-c1.meridianksi.net/public/trainingcatalog.aspx");
            Assert.IsTrue(CatalogPage.Title=="Public Catalog");
            CatalogPage.SearchContent();
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("")>1);
            SearchResultsPage.ClickCourseTitle("");
            Assert.IsTrue(AdminContentDetailsPage.CheckCourseTitle(""));

        }

       //  [Test, Category("Smoke"), Order(7)]

        public void Social()
        {
            CommonSection.Learn.Spaces();
            Assert.IsTrue(SpacesPage.CheckTitle=="Collaboration Spaces");
            SpacesPage.TypePublicSpace.ClickSpaceTitle();
            SpacesPage.SpaceTitlePage.ClickJoinButton();
            StringAssert.AreEqualIgnoringCase("You Joined the Collaboration Space", SpacesPage.GetSuccessMessage(), "Error message is different");
            SpacesPage.SpaceTitlePage.SelectAccessSpace();
            Assert.IsTrue(CSLaunchPage.Exist());

        }

        [Test, Category("Smoke"), Order(9)]
        public void Other()
        {
            CommonSection.SearchCatalog("");
            _test.Log(Status.Info, "do blank catalog search");
            //CommonSection.Learn.Home();
            HomePage.ClickAboutLink();
            _test.Log(Status.Info, "CLick about link");
            Assert.IsTrue(HomePage.ClickModalX());
            Assert.IsTrue(HomePage.Title=="Search Results");
         

            CommonSection.Administer.System.SystemAdministration.SystemCertificate("Certificates");
            _test.Log(Status.Info, "opens certificate page");
            Assert.IsTrue(SystemCertificatePage.Title=="System Certificate");
            SystemCertificatePage.Preview("Default");
            _test.Log(Status.Info, "CLick default button");
            Assert.IsTrue(CertificatePage.VerifyFileDownload("\\Certificate.pdf"));
            Assert.IsTrue(SystemCertificatePage.Title=="System Certificate");
            // CommonSection.Avatar.Logout();
            // Assert.IsTrue(LoginPage.Title=="Login");
            //foreach (Process Proc in (from p in Process.GetProcesses()
            //                          where p.ProcessName == "chromedriver" ||p.ProcessName=="chrome"  
            //                          select p))
            //{
            //    // "Kill" the process
            //    Proc.Kill();
            //}



        }
    }

    //internal class SummaryPage
    //{
    //    public static string Title
    //    {
    //        get {
                
    //            string res=Driver.Instance.Title;
    //            //Driver.clickEleJs(By.Id("MainContent_ucEditContent_FormView1_btnEditContent"));
    //            return res;
    //        }
    //    }

    //    public static SelectDropDownCommand SelectDropDown { get { return new SelectDropDownCommand(); } }

    //    public static SelectDropDownonSummaryCommand SelectDropDownonSummary { get { return new SelectDropDownonSummaryCommand(); } }

    //    internal static void ClickSavebutton()
    //    {
    //       Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
    //    }

    //    internal static string GetSuccessMessage()
    //    {
    //        string rettext = Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
    //        return rettext;
    //    }

    //    internal static void UpdateTitle(string v)
    //    {
    //       Driver.GetElement(By.Id("CNTLCL_TITLE")).Clear();
    //        Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(v);
    //        Driver.clickEleJs(By.XPath(".//*[@id='MainContent_UC1_Save']"));
    //    }

    //    internal static bool? VerifyCompletionCriterianoteditable(string v)
    //    {
    //        Thread.Sleep(3000);
    //        Driver.Instance.WaitForElement(By.XPath("//div[7]/div/div/div/label"));
    //        return Driver.GetElement(By.XPath("//*[@id='CERT_COMPLETION_CRITERIA']")).Enabled;
    //       // return true;
    //    }

    //    internal static bool? VerifyTotalHoursnoteditable(string v)
    //    {
    //        IWebElement dd = Driver.GetElement(By.XPath("//div[2]/div/input"));
    //        return dd.Enabled;
    //    }

    //    internal static bool? VerifyfCreditTypenoteditable(string v)
    //    {
    //        IWebElement dd = Driver.GetElement(By.XPath("//div[3]/div/div/select"));

    //        return dd.Enabled;
    //    }

    //    internal static void clicksave()
    //    {
    //        Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
    //        Thread.Sleep(2000);
    //    }

    //    internal static void ClickonCertificationsBreadcromb()
    //    {
    //        Thread.Sleep(2000);
    //        Driver.Instance.WaitForElement(By.XPath("//div[@id='content']/div/ol/li[3]/a"));
    //        Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[3]/a"));
    //        Thread.Sleep(3000);

    //    }

    //    internal static bool? AddnewTag(string v)
    //    {
    //        bool result = false;
    //        try
    //        {
    //            Thread.Sleep(5000);
    //            Driver.clickEleJs(By.Id("ContentTags"));
    //            //Driver.clickEleJs(By.XPath("//input[@id='s2id_autogen4']"));
    //            Driver.GetElement(By.XPath("//input[@autocapitalize='off']")).SendKeysWithSpace(v);
    //            Thread.Sleep(1000);
    //            IWebElement webElement = Driver.Instance.FindElement(By.XPath("//input[@autocapitalize='off']"));
    //            webElement.SendKeys(OpenQA.Selenium.Keys.Tab);
    //            Thread.Sleep(1000);
    //            Driver.clickEleJs(By.XPath("//div[@id='container-tags']/div/span/div/form/div/div/div[2]/button/i"));
    //            Thread.Sleep(1000);
    //            result = true;
    //        }
    //        catch (Exception ex)
    //        {

    //        }
    //        return result;
    //    }

    //    internal static bool? checkContentTagsOnDetailsPage()
    //    {
    //        return Driver.existsElement(By.XPath("//div[@id='MainContent_pnlContent']/div[2]/div/div/ul/li[3]/strong"));
    //    }
    //}

    //internal class SelectDropDownonSummaryCommand
    //{
    //    public SelectDropDownonSummaryCommand()
    //    {
    //    }

    //    internal void ReCertificationCriteriaAs(string v)
    //    {
    //        Thread.Sleep(5000);
    //        Driver.Instance.WaitForElement(By.XPath("//div[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div/div/div/div/button/span[2]/span"));
    //        Driver.GetElement(By.XPath("//div[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div/div/div/div/button/span[2]/span")).ClickWithSpace();
    //        Thread.Sleep(3000);
    //        Driver.selectdropdown(By.XPath("//*[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div[1]/div/div/div/div/ul"), v);
    //        Thread.Sleep(5000);
    //    }

    //    internal void TotalHrsscrollAs(string v)
    //    {
    //        Driver.existsElement(By.XPath("//fieldset[2]/div/div[2]/div/input"));
    //        Driver.GetElement(By.XPath("//fieldset[2]/div/div[2]/div/input")).Clear();
    //        Driver.GetElement(By.XPath("//fieldset[2]/div/div[2]/div/input")).SendKeys(v);
    //        Thread.Sleep(2000);
    //    }

    //    internal void CreditTypeAs(string v)
    //    {
    //        Driver.existsElement(By.XPath("//div[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div[3]/div/div/button/span/small"));
    //        Driver.Instance.WaitForElement(By.XPath("//div[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div[3]/div/div/button/span/small"));
    //        Driver.clickEleJs(By.XPath("//div[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div[3]/div/div/button/span/small"));
    //        Driver.selectdropdown(By.XPath("//*[@id='MainContent_MainContent_UC1_FormView1_fvCertificate_pnlCertificate']/div[2]/fieldset[2]/div/div[3]/div/div/div/ul"), v);
    //        Thread.Sleep(5000);
        
    //}
    //}
}
