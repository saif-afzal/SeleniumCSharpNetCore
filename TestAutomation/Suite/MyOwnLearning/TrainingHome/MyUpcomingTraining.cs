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
    class TH_MyUpcomingTraining : TestBase
    {
        string browserstr = string.Empty;
        public TH_MyUpcomingTraining(string browser)
            : base(browser)
        {
            browserstr = browser+"molmyupcmngtra";
        }
      
        static MyOwnLearningUtils MyOwnLearningobj;
        static TrainingHomes TrainingHomeobj;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
            TrainingHomeobj = new TrainingHomes(driver);
        }
        [SetUp]
        public void starttest()
        {
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
                driver.UserLogin("userforregression", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Access_the_Training_Home_page_and_view_the_My_Upcoming_Training_portlet()
        {
            if (ObjectRepository.upcomingtraingcreated == false)
            {
                driver.UserLogin("userforregression",browserstr);
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driver.UserLogin("admin1",browserstr);
                MyOwnLearningobj.CreateGeneralCourse(2, "th_upcoming", browserstr);
                driver.UserLogin("userforregression",browserstr);
                MyOwnLearningobj.EnrollGenCourse(2, "th_upcoming", browserstr);
              //  driver.UserLogin("userforregression",browserstr);
                MyOwnLearningobj.OpenTraining(1, 1, "th_upcoming", browserstr);
               // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }           
          //  driver.UserLogin("userforregression",browserstr);
            bool _actualresult = MyOwnLearningobj.CheckStatusofTraining("th_upcoming", browserstr);
            Assert.IsTrue(_actualresult);
            ObjectRepository.upcomingtraingcreated = true;
        }
        [Test]
        public void b_TrainingStatusFilter()
        {
            bool _actualresult = MyOwnLearningobj.TrainingStatusFilter("th_upcoming", browserstr);
            Assert.IsTrue(_actualresult);
        }

        [Test]
        public void c_ClickAllMyTraining()
        {
            bool _actualresult = MyOwnLearningobj.ClickAllMyTraining("th_upcoming", browserstr);
            Assert.IsTrue(_actualresult);
        }
        [Test]
        public void d_ClickActonButton()
        {
            bool _actualresult = MyOwnLearningobj.th_ClickActionButton();
            Assert.IsTrue(_actualresult);
        }
        [Test]
        public void e_OpenDetailPage()
        {
            bool _actualresult = MyOwnLearningobj.th_OpenDetailPage("th_upcoming", browserstr);
            Assert.IsTrue(_actualresult);
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
