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
    class c_Competency : TestBase
    {
        string browserstr = string.Empty;
        public c_Competency(string browser)
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
        public void a_create_a_performance_competency_17338()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_CreateNewCompetency();
            Assert.IsTrue(Createnewcompetencyobj.Click_Create(Variables.PerformanceCompetencyTitle,"", "Performance Competency"));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void b_Edit_a_performance_competency_17338_17339()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_search(Variables.PerformanceCompetencyTitle, "Performance Competency");
            SearchResultsobj.MyResponsbilities_Content_Click();
            ProfessionalDevelopmentsobj.Click_Edit();
           Assert.IsTrue( Createnewcompetencyobj.Click_Save(browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void c_Map_Content_to_a_performance_competency_17554()
        {
            driver.UserLogin("idpadmin",browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            ProfessionalDevelopmentsobj.Click_search(Variables.PerformanceCompetencyTitle, "Performance Competency");
            SearchResultsobj.MyResponsbilities_Content_Click();
            //ProfessionalDevelopmentsobj.Click_Edit();
            ProfessionalDevelopmentsobj.Click_Edit_Map_Conent();
            MappedContentobj.Click_MapContent();
            MappedContentobj.Click_search();
            Thread.Sleep(10000);
           Assert.IsTrue( MappedContentobj.Click_AddContent());
            
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void d_Map_Performance_comepetency_to_a_Content_17602()
        {
            driver.UserLogin("admin1",browserstr);
            TrainingHomeobj.MyResponsiblities_click();
            Trainingsobj.SearchContent_Click();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("competency",browserstr);
            String successMsg = Contentobj.SuccessMsgDisplayed();
            StringAssert.Contains("The item was created.", successMsg);
            //MyResponsibilitiesobj.Click_ProfessionalDevelopment();
            //ProfessionalDevelopmentsobj.Click_search(Variables.PerformanceCompetencyTitle, "Performance Competency");
            //SearchResultsobj.MyResponsbilities_Content_Click();
            //ProfessionalDevelopmentsobj.Click_Edit_Map_Conent();
            Contentobj.Click_EditCompetency();
            MappedCompetencyobj.Click_MapContent();
            MappedCompetencyobj.Click_search();
            Assert.IsTrue(MappedCompetencyobj.Click_AddCompetency());
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
