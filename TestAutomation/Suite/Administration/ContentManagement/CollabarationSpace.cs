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


namespace Selenium2.Meridian.Suite.Administration.ContentManegment
{
    [TestFixture("ffbs")]
    [TestFixture("chbs")]
    [TestFixture("iebs")]
    [Parallelizable(ParallelScope.Fixtures)]
    class CollabarationSpace : TestBase
    {
        string browserstr = string.Empty;
        public CollabarationSpace(string browser)
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
        public void a_Create_a_new_collaboration_space()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLinkById("phAdminMenu_lnkCollboration");
            CollabarationSpacesobj.Click_GoToButton();
        //    Assert.IsTrue(CollabarationSpacesobj.Populate_Collabaration("admincoll",browserstr));

        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_collaboration_space()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();

            AdminstrationConsoleobj.Click_OpenItemLinkById("phAdminMenu_lnkCollboration");
            CollabarationSpacesobj.Populate_Search("admincoll", browserstr);
            Assert.IsTrue(CollabarationSpacesobj.Click_Search("admincoll", browserstr));
            driver.Navigate_to_TrainingHome();
            //TrainingHomeobj.isTrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLinkById("phAdminMenu_lnkCollboration");
            CollabarationSpacesobj.Click_lnkadvancesearch();
            Assert.IsTrue(CollabarationSpacesobj.Populate_advancesearch("admincoll", browserstr));

        }


        [Test]
        public void c_Manage_a_collaboration_space()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLinkById("phAdminMenu_lnkCollboration");
            CollabarationSpacesobj.Populate_Search("admincoll", browserstr);
            CollabarationSpacesobj.Click_Search("admincoll", browserstr);
            CollabarationSpacesobj.Click_Manage();
            Assert.IsTrue(CollabarationSpacesobj.Click_save());

        }

        [Test]
        public void d_Edit_the_logo_for_a_collaboration_space()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLinkById("phAdminMenu_lnkCollboration");
            CollabarationSpacesobj.Populate_Search("admincoll", browserstr);
            CollabarationSpacesobj.Click_Search("admincoll", browserstr);
            CollabarationSpacesobj.Click_Manage();
            Assert.IsTrue(CollabarationSpacesobj.editcolspacelogo());

        }

        [Test]
        public void e_Edit_the_roles_for_a_collaboration_space()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLinkById("phAdminMenu_lnkCollboration");
            CollabarationSpacesobj.Populate_Search("admincoll", browserstr);
            CollabarationSpacesobj.Click_Search("admincoll", browserstr);
            CollabarationSpacesobj.Click_Manage();
            Assert.IsTrue(CollabarationSpacesobj.colspacerole());

        }
        [Test]
        public void f_Assign_required_training_to_a_collaboration_space()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLinkById("phAdminMenu_lnkCollboration");
            CollabarationSpacesobj.Populate_Search("admincoll", browserstr);
            CollabarationSpacesobj.Click_Search("admincoll", browserstr);
            Assert.IsTrue(CollabarationSpacesobj.Collabarationspace_req_training());

        }



        [Test]
        public void g_Delete_col_space_Detail()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLinkById("phAdminMenu_lnkCollboration");
            CollabarationSpacesobj.Populate_Search("admincoll", browserstr);
            CollabarationSpacesobj.Click_Search("admincoll", browserstr);
            Assert.IsTrue(CollabarationSpacesobj.Click_Delete());

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
