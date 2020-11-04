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
    class h_Goal : TestBase
    {
        string browserstr = string.Empty;
        public h_Goal(string browser)
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
        public void a_Add_a_Goal_to_development_plan()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_CreateDevPlan();
            DevelopmentPlansobj.Update_DevelopmentPlanTitle(Variables.DevPlanTitle + "goal",browserstr);
            Assert.IsTrue(DevelopmentPlansobj.Click_AddGoal(browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void b_Edit_an_existing_goal_in_development_plan()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_FirstDevPlan(Variables.DevPlanTitle + "goal");
            Assert.IsTrue(DevelopmentPlansobj.Click_EditGoal());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void c_Delete_a_goal_that_has_been_added_to_development_plan()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopments_learnerobj.Click_FirstDevPlan(Variables.DevPlanTitle + "goal");
            Assert.IsTrue(DevelopmentPlansobj.Click_DeleteGoal());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
      

        [TearDown]
        public void stoptest()
        {

            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }

    }
}
