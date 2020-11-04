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

namespace Selenium2.Meridian.Suite.MyResponsibilities.ProfessionalDevelopment.IDP
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class a_CompetencyRolesold : TestBase
    {
        string browserstr = string.Empty;
        public a_CompetencyRolesold(string browser)
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
          
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        [Test]
        public void a_Competency_Manager_system_role_should_be_available_and_able_to_assign_to_users_17286()
        {

            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.click_systemOptionsTab("People");
            TrainingHomeobj.click_systemOptionsAccordian("Users");
            TrainingHomeobj.click_systemOptionsLink("Roles");
            //AdminstrationConsoleobj.Click_OpenItemLink("Roles");
            Roleobj.Click_Search("Competency Manager");
            Assert.IsTrue(Roleobj.count_Record("Competency Manager"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //commented due to bug on using newly created organization user not searched in people
            //driver.UserLogin("admin1");
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.Click_AdminConsoleLink();
            //AdminstrationConsoleobj.Click_OpenItemLink("Organizations");
            //Organizationobj.Click_CreateGoTo();
            //Assert.IsTrue(Organizationobj.Click_Create("sp", ""));
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_People();
            ManageUsersobj.Click_CreateNewUserLink();
            CreateNewAccountobj.PopulateCreateNewUserLink(ExtractDataExcel.MasterDic_idpadmin["Id"] + browserstr, ExtractDataExcel.MasterDic_idpadmin["Firstname"] + browserstr, ExtractDataExcel.MasterDic_idpadmin["Lastname"] + browserstr, ExtractDataExcel.MasterDic_userforreg["Email"] + browserstr);
            CreateNewAccountobj.Click_SelectOrganization("Sample Organization 1");//Variables.organizationTitle + "sp");//
            CreateNewAccountobj.Click_CreateAccount();
            ManageUsersobj.populateaccountsearchform(ExtractDataExcel.MasterDic_idpadmin["Firstname"] + browserstr, ExtractDataExcel.MasterDic_idpadmin["Lastname"] + browserstr);
            ManageUsersobj.Click_SearchUser();
            driver.tempUserLogin("user", ExtractDataExcel.MasterDic_idpadmin["Id"], ManageUsersobj.passwordcreationnewuser(),browserstr);//it is for user for reguser createaccount.tempUserLogin("userforregression", "", passwd);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.click_systemOptionsTab("People");
            TrainingHomeobj.click_systemOptionsAccordian("Users");
            TrainingHomeobj.click_systemOptionsLink("Roles");
            Roleobj.Click_Search("Competency Manager");
            Roleobj.Click_EditUserGoTo();
            Roleobj.Click_AddUserGoTo();
            Roleobj.Click_SearchUserToAdd(ExtractDataExcel.MasterDic_idpadmin["Firstname"]+browserstr);
            Assert.IsTrue(Roleobj.Click_AddUser());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void b_Users_assigned_to_Competency_Manager_role_should_be_able_to_manange_competencies_17291_18338()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Check_allsections();
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
       

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }
        [TearDown]
        public void stoptest()
        {

            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
    }
}
