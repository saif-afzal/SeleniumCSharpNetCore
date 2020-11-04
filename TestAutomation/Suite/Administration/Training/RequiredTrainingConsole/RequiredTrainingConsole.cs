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


namespace Selenium2.Meridian.Suite.Administration.Training
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class RequiredTrainingConsole : TestBase
    {
        string browserstr = string.Empty;
        public RequiredTrainingConsole(string browser)
            : base(browser)
        {
            browserstr = browser;
}

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
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
        public void a_Conduct_a_simple_and_advanced_search_for_a_content_item()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Blogs");
            Blogsobj.Click_GoToButton();
            Assert.IsTrue(Blogsobj.Populate_blogs("blogs_rt", browserstr));
            driver.Navigate_to_TrainingHome();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            Assert.IsTrue(RequiredTrainingConsolesobj.Click_GoToRequiredTraining());
            driver.Navigate_to_TrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentAdvSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            Assert.IsTrue(RequiredTrainingConsolesobj.Click_GoToRequiredTraining());

        }


        [Test]
        public void b_Conduct_a_Click_on_the_information_icon_for_a_content_item()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            Assert.IsTrue(RequiredTrainingConsolesobj.Click_InformationIcon("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr));

        }


        [Test]
        public void c_Assign_a_content_item_as_required_training_for_a_user()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
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
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Training Assignments");
            RequiredTrainingConsolesobj.Click_RequiredTrainingContentSearch("testblog_blogs_rt" + ExtractDataExcel.token_for_reg + browserstr);
            RequiredTrainingConsolesobj.Click_GoToRequiredTraining();
            requiredtrainingobj.Click_SearchUserforRequiredTraining();
            Assert.IsTrue(requiredtrainingobj.CheckRequiredTraining());

        }

        [Test]
        public void e_Assign_an_extension_period_to_an_entity()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
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
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_requiredTrainingManagement_click();
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
            if (Meridian_Common.islog == true)
            {
                 driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();   
                TrainingHomeobj.lnk_requiredTrainingManagement_click();
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
