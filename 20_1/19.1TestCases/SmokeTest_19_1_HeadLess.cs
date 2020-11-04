using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
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
   // [TestFixture("anybrowser", Category = "local")]
    ////   [Parallelizable(ParallelScope.Fixtures)]
    public class SmokeTest_19_1_HeadLess : TestBase
    {
        string browserstr = string.Empty;
        public SmokeTest_19_1_HeadLess(string browser)
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

        [Test, TestCaseSource(typeof(myDataClass))]
        public void LoginSmoke_8597(string url,string userName, string password)
        {
            LoginPage.GoTo(url);
            _test.Log(Status.Pass, "Site opens successfully");
            LoginPage.LoginClick();
            _test.Log(Status.Pass, "Login CLick passes");
            LoginPage.LoginAs(userName).WithPassword(password).Login();
            _test.Log(Status.Pass, "login as siteadmin successful");
            Assert.IsTrue(HomePage.Title == "Home");//checks the Home page title
            CommonSection.CatalogSearchText("Test");
            _test.Log(Status.Info, "Test searched successfully from Catalog search");
            Assert.IsTrue(SearchResultsPage.CheckSearchRecord("Test") >= 1);//chcks the records are not zero
            _test.Log(Status.Pass, "search record is greater than 1");
            CommonSection.Logout();
        }
      
      //  [Test, Category("Smoke"), Order(3)]
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
    

    }
    class myDataClass:IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
           
                yield return new object[] { "https://lmsadmin.advancedch.com/", "siteadmin", "LM$@dm1n" };
                yield return new object[] { "http://mylearning.dbhdduniversity.com/", "siteadmin", "LM$@dm1n" };
           
        }
    }

    

}
