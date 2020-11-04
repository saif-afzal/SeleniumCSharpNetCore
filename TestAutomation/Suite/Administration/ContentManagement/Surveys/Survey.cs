﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Threading;
using TestAutomation.Meridian.Regression_Objects;


namespace Selenium2.Meridian.Suite.Administration.ContentManagement
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class Survey : TestBase
    {
        string browserstr = string.Empty;
        public Survey(string browser)
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
        public void a_Create_a_new_survey()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Click_GoToButton();
            Assert.IsTrue(Surveysobj.Populate_Survey(browserstr));

        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_survey()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Assert.IsTrue(Surveysobj.Click_Search(browserstr));
            driver.Navigate_to_TrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Click_lnkadvancesearch();
            Surveysobj.Populate_advancesearch(browserstr);
            Assert.IsTrue(Surveysobj.Click_Search(browserstr));

        }


        [Test]
        public void c_Manage_a_survey()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
            Surveysobj.Click_Manage();
            Assert.IsTrue(Surveysobj.Click_Save());

        }

        [Test]
        public void d_Create_a_new_survey_section()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
            Surveysobj.Click_Manage();
            Surveysobj.Click_SurveyStructureTab();
            for (int i = 0; i <= 2; i++)
            {

                Surveysobj.Click_Structure_Go();
                Assert.IsTrue(Surveysobj.Populate_Structure(i, browserstr));

                //  Assert.IsTrue(Surveyutilobj.Survey_new_section());
            }

        }

        [Test]
        public void e_Link_an_existing_survey_section()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
            Surveysobj.Click_Manage();
            Surveysobj.Click_SurveyStructureTab();
            Surveysobj.Select_Link_Existing_Section();
            Surveysobj.Click_Structure_Go();
            Assert.IsTrue(Surveysobj.Click_link_section());
            // Assert.IsTrue(Surveyutilobj.Survey_link_section());

        }

        [Test]
        public void f_Create_a_new_survey_question_in_a_section()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
            Surveysobj.Click_Manage();
            Surveysobj.Click_SurveyStructureTab();
            Assert.IsTrue(Surveysobj.Click_Populate_Create_Question(browserstr));

        }
        [Test]
        public void g_Link_an_existing_survey_question_to_a_section()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
            Surveysobj.Click_Manage();
            Surveysobj.Click_SurveyStructureTab();
            Assert.IsTrue(Surveysobj.Click_Link_Question());

        }
        [Test]
        public void h_Reorder_sections_for_a_survey()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
            Surveysobj.Click_Manage();
            Surveysobj.Click_SurveyStructureTab();
            Assert.IsTrue(Surveysobj.Click_Reorderscetion());

        }

        [Test]
        public void i_Delete_a_survey_section_from_a_survey()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
            Surveysobj.Click_Manage();
            Surveysobj.Click_SurveyStructureTab();
            Assert.IsTrue(Surveysobj.Click_DeleteSurveySection());

        }

        [Test]
        public void j_Preview_a_survey()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
            Surveysobj.Click_Manage();
            Surveysobj.Click_SurveyStructureTab();
            Assert.IsTrue(Surveysobj.Click_PreviewSection(browserstr));

        }
        [Test]
        public void k_Publish_a_survey()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
            Surveysobj.Click_Manage();
            Surveysobj.Click_SurveyStructureTab();
            Assert.IsTrue(Surveysobj.Click_PublishSurvey());

        }
        [Test]
        public void l_Assign_required_training_to_a_survey()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
           // Surveysobj.Click_Manage();
            Assert.IsTrue(Surveysobj.Click_RequiredTraining());

        }

        [Test]
        public void m_Delete_a_survey()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Surveysobj.Populate_Search(browserstr);
            Surveysobj.Click_Search(browserstr);
            Assert.IsTrue(Surveysobj.Click_Delete());

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