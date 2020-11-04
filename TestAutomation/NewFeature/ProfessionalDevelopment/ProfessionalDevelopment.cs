using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Threading;

namespace Selenium2.Meridian.Suite.NewFeature.ProfessionalDevelopment
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
  public  class ProfessionalDevelopment : TestBase
    {
        string browserstr = string.Empty;
        public ProfessionalDevelopment(string browser)
            : base(browser)
        {
            browserstr = browser;
        }
        bool sectioncreation = false;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
           // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.Quit();
        }

        [SetUp]
        public void starttest()
        {
            classroomcourse = new ClassroomCourse(driver);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("admin",browserstr);
            }
            Meridian_Common.islog = false;
        }
       
        [Test, Order(1)]
        public void Create_Competency_24286()
        {
            
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            Pages.Homepage.Manage.ProfessionalDevelopmentCompetency();
            Pages.ProfessionalDevelopment.ClickCreateCompetency();
            Pages.ProfessionalDevelopment.ClickCompetencyTitleAndSave();
            Assert.IsTrue(Pages.ProfessionalDevelopment.VerifySuccessMessage());
            Pages.Structure.ClickMenu.Logout();
       

        }


        [Test, Order(2)]
        public void Manage_Competency_24286()
        {
            Pages.Login.GotoLogin_Page();
            Pages.Login.Login_User("siteadmin", "passwrod");
            Pages.Homepage.Manage.ProfessionalDevelopmentCompetency();
            Pages.Homepage.Manage.ProfessionalDevelopmentCompetency.SearchforCompetency();
            Assert.IsTrue(Pages.ProfessionalDevelopment.VerifyCompetencyItems());
            Pages.Structure.ClickMenu.Logout();

        }





        [Test]
        public void a57_Create_an_event_for_a_Classroom_course_section_1989()
        {

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
                //    driver.Navigate_to_TrainingHome();
            }
        }

    }
}
