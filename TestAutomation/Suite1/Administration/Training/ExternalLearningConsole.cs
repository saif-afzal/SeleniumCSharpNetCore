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

namespace Selenium2.Meridian.Suite.Administration.Training
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class ExternalLearningConsoleold : TestBase
    {
        string browserstr = string.Empty;
        public ExternalLearningConsoleold(string browser)
            : base(browser)
        {
            browserstr = browser+"elc";
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("userforregression", browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            ExternalLearningConsolesobj.CreateExternalLearning_AssingtoNewUser(browserstr);
            driver.Navigate().Refresh();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Conduct_a_search_for_users()
        {

            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("External Learning Requests");
            Assert.IsTrue(ExternalLearningConsolesobj.Click_SearchUser(browserstr, "Search User"));
        }

        [Test]
        public void b_Conduct_a_search_for_content()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("External Learning Requests");
            Assert.IsTrue(ExternalLearningConsolesobj.Click_SearchUser(browserstr, "Search Content"));
        }
        [Test]
        public void c_Click_on_the_information_icon_for_a_user()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("External Learning Requests");
            ExternalLearningConsolesobj.Click_SearchUser(browserstr, "Search User");
             Assert.IsTrue(ExternalLearningConsolesobj.Click_InformationIcon(browserstr, "InformationIcon_SearchUser"));
        }
        [Test]
        public void d_Click_on_the_information_icon_for_a_content_item()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("External Learning Requests");
            ExternalLearningConsolesobj.Click_SearchUser(browserstr, "Search Content");
             Assert.IsTrue(ExternalLearningConsolesobj.Click_InformationIcon(browserstr, "InformationIcon_SearchContent"));
        }

        [Test]
        public void e_Deny_a_user_request_for_an_external_learning_item()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("External Learning Requests");
            ExternalLearningConsolesobj.Click_SearchUser(browserstr, "Search User");
             Assert.IsTrue(ExternalLearningConsolesobj.VerfyAccept_DenayUserRequest(browserstr, "DenyUser"));
        }

        [Test]
        public void f_Approve_a_user_request_for_an_external_learning_item()
        {
            ExternalLearningConsolesobj.AssignUser_ExternalLearningConsole(ExtractDataExcel.MasterDic_EL["Title"] + browserstr + "ELC",browserstr);
            driver.UserLogin("admin1", browserstr);
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("External Learning Requests");
            ExternalLearningConsolesobj.Click_SearchUser(browserstr, "Search User");
            Assert.IsTrue (ExternalLearningConsolesobj.VerfyAccept_DenayUserRequest(browserstr, "ApproveUser"));
        }
        [Test]
        public void f_View_History_for_an_external_learning_item()
        {
            ExternalLearningConsolesobj.AssignUser_ExternalLearningConsole(ExtractDataExcel.MasterDic_EL["Title"] + browserstr + "ELC", browserstr);
            driver.UserLogin("admin1", browserstr);
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("External Learning Requests");
            ExternalLearningConsolesobj.Click_SearchUser(browserstr, "Search User");
            Assert.IsTrue(ExternalLearningConsolesobj.VerifyItemHistory(browserstr));
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
