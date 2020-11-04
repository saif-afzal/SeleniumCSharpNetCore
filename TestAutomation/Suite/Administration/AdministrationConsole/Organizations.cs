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
    class Organizations : TestBase
    {
        string browserstr = string.Empty;
        public Organizations(string browser)
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
        public void a_Create_a_new_organization()
        {


            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Organizations");
            Organizationobj.Click_CreateGoTo();
            Assert.IsTrue(Organizationobj.Click_Create(browserstr));

        }
        [Test]
        public void b_Select_managers_for_an_organization()
        {


            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Organizations");
            Organizationobj.Click_Search(browserstr);
            Organizationobj.Click_ManageGoTo();
            EditOrganizationobj.Click_SelectManager();
            SelectManagerobj.Click_AddManager();
            Roleobj.Click_SearchUserToAdd("");
            Assert.IsTrue(Roleobj.Click_AddUsertoorganization());

        }
        //  [Test]
        public void c_Select_Training_POC_for_an_organization()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_People_click();
            TrainingHomeobj.lnk_peopleManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Organizations");
            Organizationobj.Click_Search(browserstr);
            Organizationobj.Click_ManageGoTo();
            EditOrganizationobj.Click_Selecttpoc();
            SelectTrainingPOCobj.Click_Addtpoc();
           Roleobj.Click_SearchUserToAdd("");
            Assert.IsTrue(Roleobj.Click_AddUsertoorganization());

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
