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

namespace Selenium2.Meridian.Suite.MyOwnLearning
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [Parallelizable(ParallelScope.Fixtures)]
    class MyUpcomingTraining : TestBase
    {
        string browserstr = string.Empty;
        public MyUpcomingTraining(string browser)
            : base(browser)
        {
            browserstr = browser+"MUT";
}
        
        static MyOwnLearningUtils MyOwnLearningobj;
        public TrainingHomes TrainingHomeobj;
        public Training Trainingobj;
        public ContentSearch ContentSearchobj;
        public Create Createobj;
        public Content Contentobj;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
            TrainingHomeobj = new TrainingHomes(driver);
            Trainingobj = new Training(driver);
            ContentSearchobj = new ContentSearch(driver);
            Createobj = new Create(driver);
            Contentobj = new Content(driver);
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
                driver.UserLogin("userforregression", browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Click_the_All_My_Upcoming_Training_button_from_the_My_Upcoming_Training_porlet_or_My_Upcoming_Training_from_the_menu()
        {
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("myupcoming" + 1, browserstr);
            Assert.IsTrue(Contentobj.Click_CheckIn());
            TrainingHomeobj.MyResponsiblities_click();
            Trainingobj.SearchContent_Click();
            ContentSearchobj.NewContent("General Course");
            Createobj.FillGeneralCoursePage("myupcoming" + 2, browserstr);
            Assert.IsTrue(Contentobj.Click_CheckIn());
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            MyOwnLearningobj.EnrollGenCourse(2, "myupcoming", browserstr);
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            MyOwnLearningobj.CompleteTraining(1, 1, "myupcoming", browserstr);
            driver.UserLogin("userforregression", browserstr);

            bool _actualresult = MyOwnLearningobj.CheckStatusofTraining("myupcoming", browserstr);
            Assert.IsTrue(_actualresult);
            ObjectRepository.upcomingtraingcreated = true;
        }

        [Test]
        public void b_Select_a_status_filter_from_the_drop_down()
        {
            bool _actualresult = MyOwnLearningobj.TrainingStatusFilter("myupcoming", browserstr);
            Assert.IsTrue(_actualresult);
        }
        [Test]
        public void c_Click_the_action_button_for_content()
        {
            bool _actualresult = MyOwnLearningobj.ClickActionButton();
            Assert.IsTrue(_actualresult);
        }

        [Test]
        public void d_Click_on_a_content_item()
        {
            bool _actualresult = MyOwnLearningobj.OpenDetailPage("myupcoming", browserstr);
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
