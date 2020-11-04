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


namespace Selenium2.Meridian.Suite.MyOwnLearning.TrainingHome
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
   public class Announcement : TestBase
    {
        string browserstr = string.Empty;
        public Announcement(string browser)
            : base(browser)
        {
            browserstr = browser+"anno";
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
        public void a_Access_the_Training_Home_page_and_view_the_Announcements_portlet()
        {
            TrainingHomeobj.isTrainingHome();
            Assert.IsTrue(TrainingHomeobj.Check_AnnouncementPortlet());
        }
        [Test]
        public  void b_Click_on_an_announcement_link()
        {
            TrainingHomeobj.isTrainingHome();
            string annotitle = TrainingHomeobj.Get_AnnouncementTitle();
            TrainingHomeobj.Click_Announcement();
            Assert.IsTrue( Detailsobj.Check_ContentHeading(annotitle));
         
        }
        [Test]
        public void c_Click_the_More_link()
        {
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            string annotitle = TrainingHomeobj.Get_AnnouncementTitle();
            TrainingHomeobj.Click_MoreAnnouncement();
            Announcements_lobj.Check_Items();
            Announcements_lobj.Click_Search(annotitle);
            Assert.IsTrue(Announcements_lobj.Check_Result(annotitle));
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
