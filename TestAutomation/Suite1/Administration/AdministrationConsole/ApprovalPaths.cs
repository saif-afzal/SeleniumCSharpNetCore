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
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]

    [Parallelizable(ParallelScope.Fixtures)]
    class ApprovalPathsold : TestBase
    {
        string browserstr = string.Empty;
      
        public ApprovalPathsold(string browser)
            : base(browser)
        {
            browserstr = browser+"apo";
       
            

       
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
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
        public void a_Create_a_new_approval_path()
        {
       
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Access Approval Paths");
          //  driver.selectWindow("");
            ApprovalPathobj.Click_CreateNewGoTo();
            ApprovalPathobj.Click_Create("admin", browserstr);
            Assert.IsTrue(ApprovalPathobj.Click_AddApproval());
            //Assert.Fail();
            _test.Log(Status.Info, "Assert Pass as condition is false");
           

        }
        [Test]
        public void b_Conduct_a_search_for_an_approval_path()
        {
        
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Access Approval Paths");
          //  driver.selectWindow("");
            Assert.IsTrue(ApprovalPathobj.Click_Search("admin", browserstr));
           // Assert.Fail();
            _test.Log(Status.Info, "Assert Pass as condition is false");

        }
        [Test]
        public void c_Edit_approves_and_stages_for_an_approval_path()
        {
            //test = extent.CreateTest("" + TestContext.CurrentContext.Test.Name);
            //driver.HoverLinkClick(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            //driver.FindElement(By.XPath("//a[contains(.,'Access Approval Paths')]")).ClickWithSpace();
            //driver.selectWindow("");

            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_TrainingManagement_click();
            //AdminstrationConsoleobj.Click_OpenItemLink("Access Approval Paths");
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Access Approval Paths");
         //   driver.selectWindow("");
            ApprovalPathobj.Click_Search("admin", browserstr);
            ApprovalPathobj.Click_ManageGoTo();
            ApprovalPathobj.Click_Approvertab();
            Assert.IsTrue(ApprovalPathobj.Click_AddApproval());
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
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
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

   

    }
}
