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


namespace Selenium2.Meridian.Suite.Administration.Training.ManageTraining
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Test : TestBase
    {
        string browserstr = string.Empty;
        public Test(string browser)
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
        public void a_Create_a_new_test()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Thread.Sleep(3000);
            Testsobj.Click_CreateGoTo();
            Assert.IsTrue(Testsobj.Populate_CreateForm("admin", browserstr));

        }


        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_Test()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Assert.IsTrue(Testsobj.Click_SearchTest(browserstr));
            driver.Navigate_to_TrainingHome();
           // TrainingHomeobj.isTrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Assert.IsTrue(Testsobj.Click_AdvSearchTest(browserstr));

        }


        [Test]
        public void c_Edit_a_Test()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
            Detailsobj.Click_ManageTestLink();
            Assert.IsTrue(Testsobj.Update_test());

        }

        [Test]
        public void d_Edit_the_test_structure()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
            Detailsobj.Click_ManageTestLink();
            Testsobj.Click_StructureTab();
            Testsobj.Click_CreateNewGroupGoTo();
            EditQuestionGroupobj.Populate_NewGroup(1);
            Testsobj.Click_CreateNewGroupGoTo();
            EditQuestionGroupobj.Populate_NewGroup(2);
            Testsobj.Click_NewQuestionGoTo("New Essay");
            Assert.IsTrue(EditQuestionobj.Populate_NewQuestion());
            Testsobj.Click_NewQuestionGoTo("New Essay");
            Assert.IsTrue(EditQuestionobj.Populate_NewQuestion());

        }

        [Test]
        public void e_Preview_the_test()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
            Detailsobj.Click_ManageTestLink();
            Testsobj.Click_StructureTab();
            Assert.IsTrue(Testsobj.Click_PreviewTest());

        }


        [Test]
        public void f_Delete_a_question()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
            Detailsobj.Click_ManageTestLink();
            Testsobj.Click_StructureTab();
            Assert.IsTrue(Testsobj.Click_DeleteQuestion());

        }

        [Test]
        public void g_Delete_a_group()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
            Detailsobj.Click_ManageTestLink();
            Testsobj.Click_StructureTab();
            Assert.IsTrue(Testsobj.Click_DeleteGroup());

        }


        [Test]
        public void h_Lock_the_test()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
            Assert.IsTrue(Detailsobj.Click_LockTestLink());

        }

        [Test]
        public void i_Publish_the_test()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
            Detailsobj.Click_PublishScrom_1_2_Link();
            Assert.IsTrue(EditSummaryobj.Populate_TestForPublish());

        }


        [Test]
        public void j_Edit_the_Course_Settings_for_a_SCORM_1_2_published_test()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
            Detailsobj.Click_PublishedTestTitleLink(browserstr);
            Detailsobj.Click_ManageTestLink();
            //EditSummaryobj.Click_CourseSettingTab();
            Assert.IsTrue(Scorm1_2obj.Click_CourseSettingForScorm());

        }


        [Test]
        public void l_Assign_required_training_to_a_test()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
            Detailsobj.Click_PublishedTestTitleLink(browserstr);
            Detailsobj.Click_AssignRequiredTrainingLink();
            Assert.IsTrue(requiredtrainingobj.Assigntraining());

        }

        [Test]
        public void k_Copy_the_test()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
           // Detailsobj.Click_PublishedTestTitleLink();
            Assert.IsTrue(Detailsobj.Click_CopyTest());
        }

        [Test]
        public void m_Delete_a_published_test()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tests");
            Testsobj.Click_SearchTest(browserstr);
            Detailsobj.Click_PublishedTestTitleLink(browserstr);
            Assert.IsTrue(Detailsobj.Click_DeletePublishedTestLink());

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
