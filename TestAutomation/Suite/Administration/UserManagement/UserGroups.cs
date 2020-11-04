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

namespace Selenium2.Meridian.Suite.Administration.UserManagement
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class UserGroups : TestBase
    {
        string browserstr = string.Empty;
        public UserGroups(string browser)
            : base(browser)
        {
            browserstr = browser;
}
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);

        }
        [SetUp]
        public void starttest()
        {

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
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("User Groups");
            UserGroupobj.Click_GoToCreateGroup();
            UserGroupobj.Populate_UserGroup();

        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_UserGroup()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("User Groups");
            Assert.IsTrue(UserGroupobj.Click_SearchUserGroup());
            driver.Navigate_to_TrainingHome();
            //TrainingHomeobj.isTrainingHome();
               AdminstrationConsoleobj.Click_OpenItemLink("User Groups");
            Assert.IsTrue(UserGroupobj.Click_AdvSearchUserGroup());

        }

        [Test]
        public void c_Create_criteria_sets_in_the_user_group()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
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
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
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
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
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
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
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
            if (Meridian_Common.islog == true)
            {
                 driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
                TrainingHomeobj.lnk_peopleManagement_click();
                TrainingHomeobj.lnk_People_click();
                TrainingHomeobj.lnk_SystemOptions_click();
                
                
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.Quit();
        }

    }
}
