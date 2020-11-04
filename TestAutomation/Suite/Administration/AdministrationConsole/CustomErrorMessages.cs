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

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class CustomErrorMessages : TestBase
    {
        string browserstr = string.Empty;
        public CustomErrorMessages(string browser)
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
        public void a_Create_a_new_Credit_Type()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Credit Types");
            CreditTypeobj.Click_CreateNewGoTo();
            Assert.IsTrue(CreditTypeobj.Populate_AccountCode(browserstr));

        }


        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_Credit_Type()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Credit Types");
            Assert.IsTrue(CreditTypeobj.Click_Search(browserstr));
            driver.Navigate_to_TrainingHome();
            //TrainingHomeobj.isTrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Credit Types");
            Assert.IsTrue(CreditTypeobj.Click_AdvSearch(browserstr));

        }

        [Test]
        public void c_Manage_the_Credit_Type()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Credit Types");
            CreditTypeobj.Click_Search(browserstr);
            CreditTypeobj.Click_ManageItem();
            Assert.IsTrue(CreditTypeobj.Edit_CreditTypes());

        }



        [Test]
        public void d_Add_User_to_the_Credit_Type()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Credit Types");
            CreditTypeobj.Click_Search(browserstr);
            CreditTypeobj.Click_ManageItem();
            CreditTypeobj.Click_AssignedUserTab();
            AssignedUserobj.Click_AddUserGoTo();
            AddUsersobj.Click_SearchUser();
            AddUsersobj.Click_SelectUserToAdd();
            Assert.IsTrue(AddUsersobj.Click_AddUser());

        }

        [Test]
        public void e_Select_Certificate_to_the_Credit_Type()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Credit Types");
            CreditTypeobj.Click_Search(browserstr);
            CreditTypeobj.Click_ManageItem();
            CreditTypeobj.Click_CertificateTab();
            SelectCertificateobj.Click_SearchCertificate();
            SelectCertificateobj.Click_SelectCertificateToAdd();
            Assert.IsTrue(SelectCertificateobj.Click_SelectCertificate());

        }

        [Test]
        public void f_Delete_a_Credit_Type()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Credit Types");
            CreditTypeobj.Click_Search(browserstr);
            CreditTypeobj.Click_SelectCreditTypeToDelete();

            Assert.IsTrue(CreditTypeobj.Click_DeleteCreditType());

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
                TrainingHomeobj.lnk_ContentManagement_click();
                if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                {
                    driver.Navigate().Refresh();
                }
                
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }

    }
}
