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
    class AuditRecordsold : TestBase
    {
        string browserstr = string.Empty;
        public AuditRecordsold(string browser)
            : base(browser)
        {
            browserstr = browser+"auditrecords";
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
        public void a_Conduct_a_general_search_in_the_auditing_console()
        {


            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_system']"));
            driver.ClickEleJs(By.XPath("//a[@href='#administer_tool']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");

            //AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");
            AuditingConsolesobj.Click_GeneralSearch();
            Assert.IsTrue(AuditingConsolesobj.Check_Search());
            _test.Log(Status.Info, "Assert Pass as condition is false");

        }
        [Test]
        public void b_Apply_the_faceted_search_filters_to_the_general_search_results()
        {


       //     TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_system']"));
            driver.ClickEleJs(By.XPath("//a[@href='#administer_tool']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");

            //AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");
            AuditingConsolesobj.Click_GeneralSearch();
            AuditingConsolesobj.Click_facet();
            Assert.IsTrue(AuditingConsolesobj.Click_refineresult());
            _test.Log(Status.Info, "Assert Pass as condition is false");

        }
        [Test]
        public void c_Conduct_a_user_search_in_the_auditing_console()
        {

            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_system']"));
            driver.ClickEleJs(By.XPath("//a[@href='#administer_tool']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");

            //AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");
            AuditingConsolesobj.Click_lnkusersearch();
            AuditingConsolesobj.Click_UserSearch();
            Assert.IsTrue(AuditingConsolesobj.Check_SearchUser());
            _test.Log(Status.Info, "Assert Pass as condition is false");

        }

        [Test]
        public void d_Apply_the_faceted_search_filters_to_the_user_search_results()
        {

            //  TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#administer_system']"));
            driver.ClickEleJs(By.XPath("//a[@href='#administer_tool']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Audit Records");
            AuditingConsolesobj.Click_lnkusersearch();
            AuditingConsolesobj.Click_UserSearch();
            AuditingConsolesobj.Click_facet();
            Assert.IsTrue(AuditingConsolesobj.Click_refineresult());

            _test.Log(Status.Info, "Assert Pass as condition is false");
        }

        //[Test]
        //public void e_Print_the_search_results()
        //{

        //    driver.UserLogin("admin1",browserstr);
        //    TrainingHomeobj.isTrainingHome();
        //    TrainingHomeobj.Click_AdminConsoleLink();
        //    AdminstrationConsoleobj.Click_OpenItemLink("Auditing Console");

        //     driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //}
        [TearDown]
        public void stoptest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
        var  errorMessage = TestContext.CurrentContext.Result.Message;
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
           // _extent.Flush();
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
