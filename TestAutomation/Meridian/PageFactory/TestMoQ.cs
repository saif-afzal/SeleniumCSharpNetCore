using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using Selenium2.Meridian.Suite;
using Selenium2.Meridian.Suite.Administration.AdministrationConsole;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TestAutomation.Suite.Responsibilities.ProfessionalDevelopment;
using TestAutomation.Suite1.Administration.AdministrationConsole;


namespace Selenium2.Meridian.Suite
{

    [TestFixture("ffbs", Category = "firefox")]
    // [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class TestMoQ : TestBase
    {
        string browserstr = string.Empty;
        public TestMoQ(string browser)
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
        private string SelectInterestTag;
        string LevelName = "Level" + Meridian_Common.globalnum;
        string OrganizationTitle= "Organization" + Meridian_Common.globalnum;
        string CreditTypeTitle = "CT" + Meridian_Common.globalnum;
        string CertificatrTitle = "Reg_Cert_CV" + Meridian_Common.globalnum;
        string curriculamtitle="curr"+ Meridian_Common.globalnum;
        string generalcoursetitle="GC"+ Meridian_Common.globalnum;

        public object CareersNavigatorPage { get; private set; }
        public object CareersDevelopmentPage { get; private set; }

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
/*
      
        [Test, Order(4), Category("P1")]
       
        public void Filter_Results_By_Different_Career_Level_33725()

        {
            CommonSection.Learn.CareerDevelopment(); 
            CareerDevelopmentPage.ClickExploreCareersbutton();
            Assert.IsTrue(CareerNavigatorPage());
            CareerNavigatorPage.Jobs.ClickCareerPathdropdown.SelectCareerPath("Career Path"); //Select a Career Path
            CareerNavigatorPage.Levels.ClickLevelsdropdown.SelectLevels("Levels"); //Select a Level
            Assert.IsTrue.CareerNavigatorPage.Result.JobCards(); //Verify the JobCards are displayed for the Career Path and Level selected
            Assert.IsTrue.CareerNavigatorPage.Result.JobCardsAlphabeticallyByJobTitle(); //Verify the jobCards are displayed alphabetically by JobTitle
            CareerNavigatorPage.Jobs.ClickCareerPathdropdown.SelectCareerPath("Career Path");
            CareerNavigatorPage.Levels.ClickLevelsdropdown.SelectLevels("All");
            Assert.IsTrue.CareerNavigatorPage.Result.JobCardsAllLevels(); //Verify the JobCards are displayed for the Career Path for All Levels
            Assert.IsTrue.CareerNavigatorPage.Result.JobCardsAlphabeticallyByLevel(); //Verify the results show all jobs in the same career path alphabetically in order by level
            CareerNavigatorPage.Jobs.ClickCareerPathdropdown.SelectCareerPathWithNoLevels("Career Path"); //Look for JobCard where Career Path exists, but no level exists
            Assert.IsTrue.CareerNavigatorPage.Result.LevelFilterDisabled(); //Verify the Levels dropdown does not show
            Assert.IsTrue.CareerNavigatorPage.Result.JobCardsforCareerPath();
            CareerNavigatorPage.Jobs.ClickCareerPathdropdown.SelectNoCareerPath("Career Path"); //Look for Job Card where no Career Path Exists
            Assert.IsTrue.CareerNavigatorPage.Result.CareerPathFilter.All(); //Verify the results Show "All" Filter
            Assert.IsTrue.CareerNavigatorPage.Result.CareerPathFilter.Saved(); //Verify the results Show "Saved" Filter
            Assert.IsTrue.CareerNavigatorPage.Result.CareerPathFilter.CareerPathExists(); //Verify the results Show CareerPaths Filter that exists.

        }

        [Test, Order(13)]
        public void learner_views_credit_hours_required_for_Certification_and_any_completed_content_toward_those_hours_33921()
        {
            //login with a admin 
            //Pre-Req- Create a Certification with completion criteria as Credit Hrs.(with 3 Default Credit Type) Achieved.
            //login with learner
            CatalogSearch.SearchCourse("DV_Re_Cert_0803").click();
            _test.Log(Status.Info, "Search Certification DV_Re_Cert_0803 from catalog search and open it");
            StringAssert.AreEqualIgnoringCase("DV_Re_Cert_0803", DV_Re_Cert_0803Page.VerifyText("DV_Re_Cert_0803"));
            _test.Log(Status.Info, "Verify Certification course name");
            DV_Cert_CV_0507Page.ClickAccessItem();
            _test.Log(Status.Info, "Click  Access Item button");
            StringAssert.AreEqualIgnoringCase("Completion Criteria", SearchResultsPage.VerifyText("Completion Criteria"));
            _test.Log(Status.Info, "Verify Completion Criteria section for this certificaiton");
            StringAssert.AreEqualIgnoringCase("3 Default Credit Type", SearchResultsPage.VerifyText("3 Default Credit Type"));
            _test.Log(Status.Info, "Verify Credit type Value needed to complete this certificaiton");
            StringAssert.AreEqualIgnoringCase("You must earn 3 Default Credit Type credits to complete this certification. Below is a list of content you’ve previously completed that awards this credit type.", SearchResultsPage.VerifyText(""));
            _test.Log(Status.Info, "Verify Text displayed for Credit type Value needed to complete this certificaiton");
        }
        */
    }

}
