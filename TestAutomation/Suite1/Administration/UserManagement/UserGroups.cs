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

namespace Selenium2.Meridian.Suite.Administration.UserManagement
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class UserGroupsold : TestBase
    {
        string browserstr = string.Empty;
        public UserGroupsold(string browser)
            : base(browser)
        {
            browserstr = browser+"ugo";
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
                driver.UserLogin("admin1", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Create_a_new_user_group()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("User Groups");
            UserGroupobj.Click_GoToCreateGroup();
            UserGroupobj.Populate_UserGroup();

        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_UserGroup()
        {

            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("User Groups");
            Assert.IsTrue(UserGroupobj.Click_SearchUserGroup());
            driver.Navigate_to_TrainingHome();
            //TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("User Groups");
            Assert.IsTrue(UserGroupobj.Click_AdvSearchUserGroup());

        }

        [Test]
        public void c_Create_criteria_sets_in_the_user_group()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("User Groups");
            UserGroupobj.Click_SearchUserGroup();
            UserGroupobj.Click_GoToManage();
            UserGroupobj.Click_CriteriaTab();
            UserGroupobj.Click_AddCriteriaSet();
            UserGroupobj.Click_SetCriteria();
            UserGroupobj.Click_TabAssignUser();
            Assert.IsTrue(UserGroupobj.Verify_nouser());

        }

        [Test]
        public void d_Preview_the_users_in_the_user_group()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("User Groups");
            UserGroupobj.Click_SearchUserGroup();
            UserGroupobj.Click_GoToManage();
            UserGroupobj.Click_TabAssignUser();
            UserGroupobj.Click_PreviewUser();
            Assert.IsTrue(UserGroupobj.GetUserInPreview());

        }
        [Test]
        public void e_Assign_users_to_the_user_group()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("User Groups");
            UserGroupobj.Click_SearchUserGroup();
            UserGroupobj.Click_GoToManage();
            UserGroupobj.Click_TabAssignUser();
            UserGroupobj.Click_PreviewUser();
            Assert.IsTrue(UserGroupobj.Click_AssignUserToGroup());

        }

        //[Test]
        public void f_Delete_a_criteria_set_from_a_user_group()
        {
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='#admin-console-personnel']"));
            AdminstrationConsoleobj.Click_OpenItemLink("User Groups");
            UserGroupobj.Click_SearchUserGroup();
            UserGroupobj.Click_GoToManage();
            UserGroupobj.Click_CriteriaTab();
            UserGroupobj.Click_EditCriteria();
            Assert.IsTrue(UserGroupobj.Click_AddRemoveCriteria());
            UserGroupobj.Click_TabAssignUser();
            Assert.IsTrue(UserGroupobj.GetUserInCriteria());

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
