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

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole.Roles
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Roles : TestBase
    {
        string browserstr = string.Empty;
        public Roles(string browser)
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
         driver.UserLogin("admin1",browserstr);
        }
        [SetUp]
        public void starttest()
        {

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
        public void a_Conduct_a_search_for_role()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Roles");
            Roleobj.Click_Search("Administrator");
            Assert.IsTrue(Roleobj.count_Record("Administrator"));

        }
        [Test]
        public void b_Edit_user_in_a_system_role()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "role", ExtractDataExcel.MasterDic_newuser["Firstname"] + browserstr + "role", ExtractDataExcel.MasterDic_newuser["Lastname"] + browserstr + "role", ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization");
            CreateNewAccountobj.Click_CreateAccount();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr + "role", ExtractDataExcel.MasterDic_newuser["Lastname"]+browserstr + "role");
            ManageUsersobj.Click_SearchUser();
            driver.tempUserLogin("user", ExtractDataExcel.MasterDic_newuser["Id"] + browserstr + "role", ManageUsersobj.passwordcreationnewuser(), browserstr);//it is for user for reguser createaccount.tempUserLogin("userforregression", "", passwd);
             driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

          driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Roles");
            Roleobj.Click_Search("Administrator");
            Roleobj.Click_EditUserGoTo();
            Roleobj.Click_AddUserGoTo();
            Roleobj.Click_SearchUserToAdd(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr + "role");
            Assert.IsTrue(Roleobj.Click_AddUser());

        }
        [Test]
        public void c_Create_a_custom_role_and_add_user_to_it()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Roles");
            Roleobj.Click_CreateNewRoleGoTo();
            Assert.IsTrue(Roleobj.Click_CreateNewRole());
            Roleobj.Click_Search("role" + ExtractDataExcel.token_for_reg);
            Roleobj.Click_EditUserGoTo();
            Roleobj.Click_AddUserGoTo();
            Roleobj.Click_SearchUserToAdd(ExtractDataExcel.MasterDic_newuser["Firstname"]+browserstr + "role");
            Assert.IsTrue(Roleobj.Click_AddUser());

        }
        //[Test]
        public void d_Test_to_view_needs_grading_portlet_to_permissions_in_custom_roles_19229()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Roles");
            Roleobj.Click_Search("meera");
            Roleobj.SelectAction("Edit Permissions");
            Roleobj.Click_EditUserGoTo();

            Assert.IsTrue(EditPermissionobj.Validate_tree_structure(), "The tree stucture is not have allow deny");

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
