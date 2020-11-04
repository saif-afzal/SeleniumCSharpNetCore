using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using TestAutomation.Meridian.Regression_Objects;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;

namespace Selenium2.Meridian.Suite.LoginToolbar
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class g_MyReportold : TestBase
    {
        string browserstr = string.Empty;
        public g_MyReportold(string browser)
            : base(browser)
        {
            browserstr = browser+"report";
            InitializeBase(driver);
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }
    
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        [Test]
        public  void a_Click_on_a_report_link()
        {

            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.lnk_MyReportsClick();
            Assert.IsTrue(MyReportsobj.MyReportlinkcheck());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public  void b_Create_a_scheduled_report()
        {
            //driver.UserLogin("admin1",browserstr);
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_system_click();
            //TrainingHomeobj.lnk_reportsManagement_click();
            //ConfigurationConsoleobj.Click_Link("Custom Reporting and Storage");
            //Config_Reportsobj.scheduletaskauthorizeduser();
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.lnk_MyReportsClick();
            MyReportsobj.MyReportlinkcheck();
            Assert.IsTrue(Detailsobj.scheduleReport());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        [Test]
        public void c_Run_a_report()
        {

            driver.UserLogin("admin1", browserstr);
            string _expectedresult = "The scheduled report task is now running.";
            TrainingHomeobj.lnk_MyReportsClick();
            MyReportsobj.MyReportlinkcheck();
            StringAssert.Contains(_expectedresult, Detailsobj.clickrunicon());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);


        }

        [Test]
        public void d_Click_Select_Criteria_and_run_the_report()
        {
            string reporttitle = "Meridian Global Reporting";
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.lnk_MyReportsClick();
            MyReportsobj.MyReportlinkcheck();
            Assert.IsTrue(Detailsobj.scheduleReport());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
          
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.lnk_MyReportsClick();
            
           string actres = MyReportsobj.Click_btncreteriarun();
            driver.SelectWindowClose2("Meridian Global Reporting", "Reports");
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            StringAssert.AreEqualIgnoringCase(reporttitle, actres);
            

        }

      
        [Test]
        public  void f_Delete_a_scehduled_report()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.lnk_MyReportsClick();
            MyReportsobj.MyReportlinkcheck();
            Assert.IsTrue(Detailsobj.scheduleReport());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            driver.UserLogin("admin1", browserstr);
            string _expectedresultdel = "The selected items were removed.";
            TrainingHomeobj.lnk_MyReportsClick();
            MyReportsobj.MyReportlinkcheck();
           string _actualresultdel = Detailsobj.deleteschedule();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            StringAssert.Contains(_expectedresultdel, _actualresultdel);
           

        }

        [Test]
        public  void e_Suspend_a_scheduled_report()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.lnk_MyReportsClick();
            MyReportsobj.MyReportlinkcheck();
            Assert.IsTrue(Detailsobj.scheduleReport());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            string _expectedresultsus = "The scheduled report task was suspended.";
            TrainingHomeobj.lnk_MyReportsClick();
            MyReportsobj.MyReportlinkcheck();
            string _actualresultsus = Detailsobj.suspendschedule();
            StringAssert.Contains(_expectedresultsus, _actualresultsus);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        //[Test]
        public void g_search_for_archived_scheduled_report()
        {

            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.lnk_MyReportsClick();

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [TearDown]
        public void stoptest()
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
