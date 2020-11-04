using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Selenium2.Meridian.Suite.P1.AdministrationConsole
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]

    [Parallelizable(ParallelScope.Fixtures)]
    class OrganizationsP1 : TestBase
    {
        string browserstr = string.Empty;
        public OrganizationsP1(string browser)
            : base(browser)
        {
            browserstr = browser;
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //      _test = _extent.CreateTest("TestSuiteStarted");
         //   _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            driver.UserLogin("admin1", browserstr);


        }

      //  [OneTimeSetUp]
        public void StartSuite()
        {
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            //      _test = _extent.CreateTest("TestSuiteStarted");
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            driver.UserLogin("admin1", browserstr);
        }


        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
             driver.UserLogin("admin1",browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Create_a_new_organization_8552()
        {

            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Organizations");
            Organizationobj.Click_CreateGoTo();
            Assert.IsTrue(Organizationobj.Click_Create(browserstr));
            _test.Log(Status.Info, "Assert Pass as condition is false");

        }
        [Test]
        public void b_Manage_Organization_8553()
        {

            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Organizations");
            Organizationobj.Click_Search(browserstr);
            Organizationobj.Click_ManageGoTo();
            EditOrganizationobj.Click_SelectManager();
            SelectManagerobj.Click_AddManager();
            Roleobj.Click_SearchUserToAdd("");
            Assert.IsTrue(Roleobj.Click_AddUsertoorganization());
            _test.Log(Status.Info, "Assert Pass as condition is false");

        }
       
        [TearDown]
        public void stoptest()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    string screenShotPath = ScreenShot.Capture(driver, "ScreenShotName");
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    logstatus = Status.Fail;
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
     //   [OneTimeTearDown]
        protected void ExitSuite()
        {

            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            var errorMessage = TestContext.CurrentContext.Result.Message;
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    string screenShotPath = ScreenShot.Capture(driver, "ScreenShotName");
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));
                    logstatus = Status.Fail;
                    _test.Log(logstatus, "Test ended with prerequisites failed " + logstatus + stacktrace);
                    break;
            }

        }

    }
}
