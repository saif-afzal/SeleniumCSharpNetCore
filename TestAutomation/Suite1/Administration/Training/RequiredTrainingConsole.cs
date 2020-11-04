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
    class RequiredTrainingConsoleold : TestBase
    {
        string browserstr = string.Empty;
        public RequiredTrainingConsoleold(string browser)
            : base(browser)
        {
            browserstr = browser+"rtco";
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
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
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Conduct_a_simple_and_advanced_search_for_a_content_item()
        {

            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Content Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Blogs");
            Blogsobj.Click_GoToButton();
            Assert.IsTrue(Blogsobj.Populate_blogs("blogs_rt", browserstr));
            driver.Navigate_to_TrainingHome();
            //     TrainingHomeobj.lnk_requiredTrainingManagement_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            Assert.IsTrue(RequiredTrainingConsolesobj.Click_GoToRequiredTraining());
            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentAdvSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            Assert.IsTrue(RequiredTrainingConsolesobj.Click_GoToRequiredTraining());

        }


        [Test]
        public void b_Conduct_a_Click_on_the_information_icon_for_a_content_item()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            Assert.IsTrue(RequiredTrainingConsolesobj.Click_InformationIcon("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr));

        }


        [Test]
        public void c_Assign_a_content_item_as_required_training_for_a_user()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.selectProfile();
            requiredtrainingobj.Click_SelectProfileGoBtn();
            SelectProfileobj.Click_SearchProfile("Dynamic Profile");
            SelectProfileobj.Click_SelectProfile();
            requiredtrainingobj.Click_SearchUserforAssignTraining();
            Assert.IsTrue(requiredtrainingobj.Click_SelectUserforTraining());
            requiredtrainingobj.Click_RequiredTrainingLink();
            requiredtrainingobj.Click_SearchUserforRequiredTraining();
            Assert.IsTrue(requiredtrainingobj.CheckRequiredTraining());

        }

        [Test]
        public void d_Conduct_a_search_for_the_user_who_was_assigned_training()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.Click_SearchUserforRequiredTraining();
            Assert.IsTrue(requiredtrainingobj.CheckRequiredTraining());

        }

        [Test]
        public void e_Assign_an_extension_period_to_an_entity()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.Click_SearchUserforRequiredTraining();
            requiredtrainingobj.CheckRequiredTraining();
            Assert.IsTrue(requiredtrainingobj.Click_ApplyExtensionGoTo());

        }

        [Test]
        public void f_Remove_an_extension_period_to_an_entity()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@aria-controls='admin-console-requiredTrainingManagement']"));
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.Click_SearchUserforRequiredTraining();
            requiredtrainingobj.CheckRequiredTraining();
            Assert.IsTrue(requiredtrainingobj.Click_RemoveExtensionGoTo());

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
