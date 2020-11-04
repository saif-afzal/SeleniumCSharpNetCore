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
    class e_Skillold : TestBase
    {
        string browserstr = string.Empty;
        public e_Skillold(string browser)
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
        public void a_create_a_skill_17496()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_CreateNewCompetency();
           Assert.IsTrue( Createnewcompetencyobj.Click_Create(Variables.SkillTitle,"","Skill"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void b_Edit_a_skill_17496()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_search(Variables.SkillTitle, "Skill");
            SearchResultsobj.MyResponsbilities_Content_Click();
            ProfessionalDevelopmentsobj.Click_Edit();
           Assert.IsTrue( Createnewcompetencyobj.Click_Save(browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void c_Map_Content_to_a_skill_competency_17555()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_search(Variables.SkillTitle, "Skill");
            SearchResultsobj.MyResponsbilities_Content_Click();
            //Createnewcompetencyobj.Click_Save();
            //ProfessionalDevelopmentsobj.Click_Edit();
            ProfessionalDevelopmentsobj.Click_Edit_Map_Conent();
            MappedContentobj.Click_MapContent();
            MappedContentobj.Click_search();
           Assert.IsTrue( MappedContentobj.Click_AddContent());
            
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
