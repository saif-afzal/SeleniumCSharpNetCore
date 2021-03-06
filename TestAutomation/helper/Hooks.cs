﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using relativepath;
using Selenium2;
using Selenium2.Meridian;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestAutomation.helper;
using TestAutomation.Miscellaneous;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using Keys = OpenQA.Selenium.Keys;

namespace ParallelTesting_Solution2
{

    [TestFixture]
    public class Hooks : Base
    {
        public Hooks()
        {
            var capability = new ChromeOptions();
            
            ChromeOptions options1 = new ChromeOptions();
            options1.AddAdditionalCapability("os", "Windows", true);
            options1.AddAdditionalCapability("os_version", "10", true);
            options1.AddAdditionalCapability("browser", "Chrome", true);
            options1.AddAdditionalCapability("browserstack.local", "true", true);
            options1.AddAdditionalCapability("browser_version", "73", true);
            options1.AddAdditionalCapability("browserstack.local", "false", true);
            options1.AddAdditionalCapability("browserstack.selenium_version", "3.14.0", true);
            options1.AddAdditionalCapability("browserstack.user", "saifafzal2", true);
            options1.AddAdditionalCapability("browserstack.key", "s3rbeAXDiXhSnHDXAkfs", true);
           
            //RelativeDirectory rd = new RelativeDirectory();
            options1.SetLoggingPreference(LogType.Browser, LogLevel.Warning);
            options1.AddArguments("disable-infobars");
            // var downloadDirectory = rd.Up(1) + "downloads";
            // Meridian_Common.MeridianFileDownload = downloadDirectory;
            // options1.AddUserProfilePreference("download.default_directory", downloadDirectory);
            options1.AddUserProfilePreference("download.prompt_for_download", false);
            options1.AddUserProfilePreference("disable-popup-blocking", "true");
           // options1.AddArguments("--headless");
            options1.AddArguments("--start-maximized");
            
            ExtentReport();
            Driver= new RemoteWebDriver(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), options1.ToCapabilities());

            //Driver = new ChromeDriver(options1);
            ObjectInit obj = new ObjectInit(Driver);
            obj.InitializeBase(Driver);
        }
        protected ExtentReports _extent;
        protected ExtentTest _test;
        public void ExtentReport()
        {
            var dir = TestContext.CurrentContext.TestDirectory + Meridian_Common.globalnum;
            _extent = new ExtentReports();
            var dir1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            DirectoryInfo di = Directory.CreateDirectory(dir1 + "\\Test_Execution_Reports\\" + Meridian_Common.globalnum + "_" + this.GetType().ToString());
            var htmlReporter = new ExtentHtmlReporter(dir1 + "\\Test_Execution_Reports\\" + Meridian_Common.globalnum + "_" + this.GetType().ToString() + "\\" + ".html");

            Meridian_Common.resultpath = dir1 + "Test_Execution_Reports\\" + Meridian_Common.globalnum + "_" + this.GetType().ToString();
            // _extent.AddSystemInfo(“Environment”, “Journey of Quality”);
            // _extent.AddSystemInfo(“User Name”, “Sanoj”);
            htmlReporter.Config.DocumentTitle = this.GetType().ToString();
            _extent.AddSystemInfo("Environment", ConfigurationManager.AppSettings["MeridianTestEnvironment"]);

            _extent.AddSystemInfo("Browser", ConfigurationManager.AppSettings["Selenium2Browserch"]);
            _extent.AttachReporter(htmlReporter);

        }
        public void cleanup()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var testCaseName = TestContext.CurrentContext.Test.Name;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(Driver, "");
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    screenShotPath = screenShotPath.Replace(@"C:\RegressionSuite\Regression Scripts\Somnath\TestAutomation\ErrorScreenshots", @"Z:\");
                    _test.Log(Status.Info, "MailSnapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    //adding codes to attached screenshot to test plan
                    //Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                    //string path = Directory.GetCurrentDirectory() + (testCaseName+".png");
                    //ss.SaveAsFile(path);
                    TestContext.AddTestAttachment(screenShotPath);//, String descriptio = null);
                                                                  //this.TestContext.AddResultFile(path);
                                                                  //end of code
                    string tcid1 = string.Empty;
                    string testname = TestContext.CurrentContext.Test.Name;
                    IList<string> testid = testname.Split('_');
                    foreach (string x in testid)
                    {
                        //if (Driver.getintegerfromstring(x).ToString().Length > 4)
                        //{
                        //    tcid1 = x;
                        //    break;
                        //}

                    }

                    //tcid1 = driver.getintegerfromstring(testname); 
                    //string tcid = string.Empty;
                    //int pfrom = testname.IndexOf("tc_")+"tc_".Length;
                    //int pto = testname.LastIndexOf("_");
                    //string str = testname.Substring(pfrom, pto-pfrom);

                    //if(pfrom!=-1)
                    //{
                    //    tcid = testname.Substring(pfrom + 3);
                    //}

                    testname = testname.Substring(testname.LastIndexOf("_"));
                    string testname2 = testname.Substring(testname.LastIndexOf("_"));
                    int testname1 = 1;// Driver.getintegerfromstring(testname);
                    string msg = stacktrace.Substring(stacktrace.LastIndexOf(' '));
                    msg = msg.Replace("\r\n", "");
                    string screenShotPath1 = ScreenShot.Capture(Driver, "tc_" + tcid1 + " _line no is " + msg + "_");
                    //screenShotPath = screenShotPath + TestContext.CurrentContext.Test.ClassName + "_"+ TestContext.CurrentContext.Test.ClassName;
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    screenShotPath1 = screenShotPath1.Replace(@"C:\RegressionSuite\Regression Scripts\Somnath\TestAutomation\ErrorScreenshots", @"Z:\");

                    //if (driver.Title == "Object reference not set to an instance of an object.")
                    //{
                    //    driver.Navigate_to_TrainingHome();
                    //    Driver.focusParentWindow();
                    //    CommonSection.Avatar.Logout();
                    //    LoginPage.LoginClick();
                    //    LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
                    //}
                    //if (driver.gettextofelement(By.XPath("//*[@id='content']/div/div/h1")) == "Something went wrong.")
                    //{
                    //    driver.Navigate_to_TrainingHome();
                    //    Driver.focusParentWindow();
                    //    CommonSection.Avatar.Logout();
                    //    LoginPage.LoginClick();
                    //    LoginPage.LoginAs("siteadmin").WithPassword("password").Login();
                    //}
                    ////if (!Meridian_Common.isadminlogin)
                    ////{
                    ////    CommonSection.Logout();
                    ////    LoginPage.LoginAs("").WithPassword("").Login();
                    ////}


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
                //  driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                // driver.Navigate_to_TrainingHome();
                //  TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                //if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                //{
                //    driver.Navigate().Refresh();
                //}
                //    driver.Navigate().Refresh();
            }
        }

        private IWebDriver objDriver;
     
        public LoginPage loginPage1;
        public HelpPage helpPage1;
        public TrainingPage trainingPage1;
        public CommonSection commonSection;
        public SearchResultsPage searchResultsPage1;
        public ClassroomCourseDetailsPage classroomDetailsPage1;
        public SectionsPage sectionPage1;
        public CreateNewCourseSectionAndEventPage createNewCourseSectionAndEventPage1;
        public ManageUsersPage manageUsersPage1;
        public OrganizationsPage organizationsPage1;
        public CareersPage careersPage1;
        public HomePage homePage1;
        public ReportsConsolePage reportConsolePage1;
        public DetailsPage detailsPage1;
        public RunReportPage runReportPage1;
        public MeridianGlobalReportingPage meridianGlobalReportingPage1;
        public MyTrainingProgressPDFPage myTrainingProgressPDFPage1;
        public ReportsPage reportsPage1;
        public ContentDetailsPage contentDetailsPage1;
        public SummaryPage summaryPage1;
        public CreatePage createPage1;
        public CourseLaunchModalPage courseLaunchModalPage1;
        public SystemCertificatePage systemCertificatePage1;
        public CertificatePage certificatePage1;
        public void InitializeBase(IWebDriver objDriver)
        {
            homePage1 = new HomePage(objDriver);
            loginPage1 = new LoginPage(objDriver);
            helpPage1 = new HelpPage(objDriver);
            commonSection = new CommonSection(objDriver);
            trainingPage1 = new TrainingPage(objDriver);
            searchResultsPage1 = new SearchResultsPage(objDriver);
            classroomDetailsPage1 = new ClassroomCourseDetailsPage(objDriver);
            sectionPage1 = new SectionsPage(objDriver);
            createNewCourseSectionAndEventPage1 = new CreateNewCourseSectionAndEventPage(objDriver);
            manageUsersPage1 = new ManageUsersPage(objDriver);
            organizationsPage1 = new OrganizationsPage(objDriver);
            careersPage1 = new CareersPage(objDriver);
            reportConsolePage1 = new ReportsConsolePage(objDriver);
            detailsPage1 = new DetailsPage(objDriver);
            runReportPage1 = new RunReportPage(objDriver);
            meridianGlobalReportingPage1 = new MeridianGlobalReportingPage(objDriver);
            myTrainingProgressPDFPage1 = new MyTrainingProgressPDFPage(objDriver);
            contentDetailsPage1 = new ContentDetailsPage(objDriver);
            reportsPage1 = new ReportsPage(objDriver);
            summaryPage1 = new SummaryPage(objDriver);
            createPage1 = new CreatePage(objDriver);
            courseLaunchModalPage1 = new CourseLaunchModalPage(objDriver);
            systemCertificatePage1 = new SystemCertificatePage(objDriver);
            certificatePage1 = new CertificatePage(objDriver);


            //LoginPage = new MdnHomePage(driver);
            //LoginPage1 = new MdnLoginPage1(driver);
            //HomePage = new MdnHomePage(driver);
            //CommonPage = new MdnCommonPage(driver);

            //#region initialize old
            //driver = objDriver;
            //CheckOutobj = new CheckOut(driver);
            //takeScreenhsot = new ScreenShot(driver);
            //approvalrequest = new Approvalrequestobject(driver);
            //instructors = new Instructor(driver);
            //approvalrequest = new Approvalrequestobject(driver);
            //DomainConsoleobj = new DomainConsole(driver);
            //ManageGradebookobj = new ManageGradebook();
            //Instructorsobj = new Instructorspof();
            //MyResponsibilitiesobj = new My_Responsibilities(driver);
            //manageuserobj = new ManageUsers(driver);
            //objTrainingHome = new TrainingHomes(driver);
            //objCurriculum = new CreateCurriculum(driver);
            //classroomcourse = new ClassroomCourse(driver);
            //ContentSearchobj = new ContentSearch(driver);
            //objCreate = new Create(driver);
            //detailspage = new Details(driver);


            //TrainingHomeobj = new TrainingHomes(driver);
            //AdminstrationConsoleobj = new AdminstrationConsole(driver);
            //Testsobj = new Tests(driver);
            //Detailsobj = new Details(driver);
            //EditSummaryobj = new EditSummary(driver);
            //Scorm1_2obj = new Scorm1_2(driver);
            //EditQuestionobj = new EditQuestion(driver);
            //EditQuestionGroupobj = new EditQuestionGroup(driver);

            //AddUsrObj = new AddUsers(driver);

            //generalcourseobj = new GeneralCourse(driver);
            //myteachingscheduleobj = new MyTeachingSchedule();
            //professionaldevelopmentobj = new ProfessionalDevelopments(driver);
            //documentobj = new Document(driver);
            //CreateNewAccountobj = new CreateNewAccount(driver);
            //ManageUsersobj = new ManageUsers(driver);
            //Createobj = new Create(driver);
            //summaryobj = new Summary(driver);
            //reauiredtrainingconsoleobj = new RequiredTrainingConsoles(driver);
            //requiredtrainingobj = new RequiredTraining(driver);
            //Trainingobj = new Training(driver);
            //Loginobj = new Login(driver);
            //Contentobj = new Content(driver);
            //Creditsobj = new Credits(driver);
            //AddContentobj = new AddContent(driver);
            //Summaryobj = new Summary(driver);
            //ScheduleAndManageSectionobj = new ScheduleAndManageSection(driver);
            //SearchResultsobj = new SearchResults(driver);
            //CourseSectionobj = new CreateNewCourseSectionAndEventPage(driver);
            //Transcriptsobj = new Transcripts(driver);
            //Productsobj = new Products(driver);
            //BrowseTrainingCatalogobj = new BrowseTrainingCatalog(driver);
            //ShoppingCartsobj = new ShoppingCarts(driver);
            //ProfessionalDevelopmentsobj = new ProfessionalDevelopments(driver);
            //Createnewproficencyscaleobj = new Createnewproficencyscale(driver);
            //Createnewcompetencyobj = new Createnewcompetency(driver);
            //CreateNewSucessProfileobj = new CreateNewSucessProfile(driver);
            //SucessProfileobj = new SucessProfile(driver);
            //Searchobj = new Search(driver);
            //TrainingActivitiesobj = new TrainingActivities(driver);
            //ProfessionalDevelopments_learnerobj = new ProfessionalDevelopments_learner(driver);
            //Organizationobj = new Organization(driver);
            //DevelopmentPlansobj = new DevelopmentPlans(driver);
            //AddDevelopmentActivitiesobj = new AddDevelopmentActivities(driver);
            //MyAccountobj = new MyAccount(driver);
            //UsersUtilobj = new UsersUtil(driver);
            //MyCalendersobj = new MyCalenders(driver);
            //MyReportsobj = new MyReports(driver);
            //Config_Reportsobj = new Config_Reports(driver);
            //ConfigurationConsoleobj = new ConfigurationConsole(driver);
            //ApprovalPathobj = new ApprovalPath(driver);
            //MyMessageobj = new MyMessages(driver);
            //MessageUtilobj = new MessageUtil(driver);
            //MyRequestsobj = new MyRequests(driver);
            //Blogsobj = new Blogs(driver);
            //CollabarationSpacesobj = new CollabarationSpaces(driver);
            //Faqsobj = new Faqs(driver);
            //HomePageFeedobj = new HomePageFeed(driver);
            //ProductTypesobj = new ProductTypes(driver);
            //Surveysobj = new Surveys(driver);
            //SurveyScalesobj = new SurveyScales(driver);
            //AuditingConsolesobj = new AuditingConsoles(driver);
            //Categoryobj = new Category(driver);
            //Trainingsobj = new Trainings(driver);
            //VirtualMeetingsobj = new VirtualMeetings(driver);
            //CreditTypeobj = new CreditType(driver);
            //AssignedUserobj = new AssignedUser(driver);
            //AddUsersobj = new AddUsers(driver);
            //CustomFieldobj = new CustomField(driver);
            //CreateNewCustomFieldobj = new CreateNewCustomField(driver);
            //EditFieldobj = new EditField(driver);
            //EducationLevelobj = new EducationLevel(driver);
            //EditOrganizationobj = new EditOrganization(driver);
            //SelectManagerobj = new SelectManager(driver);
            //Roleobj = new Role(driver);
            //SelectTrainingPOCobj = new SelectTrainingPOC(driver);
            //Complexobj = new Complex(driver);
            //AccountCodesobj = new AccountCodes(driver);
            //AccountCodeTypesobj = new AccountCodeTypes(driver);
            //DiscountCodesobj = new DiscountCodes(driver);
            //ManageTaxRatesobj = new ManageTaxRates(driver);
            //TaxItemCategoriesobj = new TaxItemCategories(driver);
            //Certificatesobj = new Certificates(driver);
            //CourseProvidersobj = new CourseProviders(driver);
            //ExternalLearningsobj = new ExternalLearnings(driver);
            //ExternalLearningConsolesobj = new ExternalLearningConsoles(driver);
            //ExternalLearningtypesobj = new ExternalLearningtypes(driver);
            //RequiredTrainingConsolesobj = new RequiredTrainingConsoles(driver);
            //SelectProfileobj = new SelectProfile(driver);
            //TrainingProfilesobj = new TrainingProfiles(driver);
            //EditTrainingProfileobj = new EditTrainingProfile(driver);
            //MergeUsersobj = new MergeUsers(driver);
            //UserGroupobj = new UserGroup(driver);
            //SelectCertificateobj = new SelectCertificate(driver);
            //ManageProficencyScaleobj = new ManageProficencyScale(driver);
            //ArchivedProficencyScaleobj = new ArchivedProficencyScale(driver);
            //MappedContentobj = new MappedContent(driver);
            //MappedCompetencyobj = new MappedCompetency(driver);
            //ManageSuccessProfileobj = new ManageSuccessProfile(driver);
            //FAQ_lobj = new FAQ_l(driver);
            //Announcements_lobj = new Announcements_l(driver);
            //JobTitlesobj = new JobTitles(driver);
            //ManageJobTitleobj = new ManageJobTitle(driver);
            //ManagePricingScheduleobj = new ManagePricingSchedule(driver);
            //ExternalLearningSearchobj = new ExternalLearningSearch(driver);
            //urlobj = new url(driver);
            //skinobj = new skin(driver);
            //MyOwnLearningobj = new MyOwnLearningUtils(driver);
            //CurrentTrainingsobj = new CurrentTrainings(driver);
            //scormobj = new Scorm12(driver);
            //aicccourse = new AICC(driver);
            //ojtcourse = new OJT(driver);
            //TrainingCatalogobj = new TrainingCatalogUtil(driver);
            //accesskeys = new AccessKeys(driver);
            //#endregion
        }

        [OneTimeTearDown]
        protected void TearDown()
        {

            _extent.Flush();
            String Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");

            string destpath = string.Empty;
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string otherpath = pth.Substring(0, pth.LastIndexOf("bin"));
            destpath = new Uri(otherpath).LocalPath;
            string fileName = string.Empty;
            string destFile = string.Empty;
            string fileRename = string.Empty;
            //  pth.Substring(0, pth.LastIndexOf("bin"))
            //if (!Directory.Exists(otherpath))
            //{

            //    // otherpath1 = new Uri(otherpath).LocalPath;
            //    Directory.CreateDirectory(destpath);


            //}

            string sourcepath = Meridian_Common.resultpath;// + this.GetType().ToString();
            string[] files1 = Directory.GetFiles(sourcepath, "*.html", SearchOption.TopDirectoryOnly);
            //string[] files = System.IO.Directory.GetFiles(root);
            fileRename = System.IO.Path.Combine(destpath, "TestResult.html");
            foreach (var filename in files1)
            {
                fileName = System.IO.Path.GetFileName(filename);
                //fileName = Meridian_Common.SmokeTestSite + fileName;
                destFile = System.IO.Path.Combine(destpath, fileName);
                if (fileName == "index.html")
                {
                    if (File.Exists(fileRename))
                    {
                        File.Delete(fileRename);
                    }
                    File.Copy(filename, destFile, true);

                    File.Move(destFile, fileRename);
                }

            }
            Driver.Quit();
            //  Driver.Instance.Close(); ;
        }
       

    }
 
  

}
