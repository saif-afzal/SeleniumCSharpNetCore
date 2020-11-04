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
    public class HomePageFeeds : TestBase
    {
        string browserstr = string.Empty;
        public HomePageFeeds(string browser)
            : base(browser)
        {
            browserstr = browser + "HPF";
        }
      
        static MyOwnLearningUtils MyOwnLearningobj;
        static Homepagefeedutil HomePageFeedobj;
        static TrainingHomes TrainingHomeobj;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
            HomePageFeedobj = new Homepagefeedutil(driver);
            TrainingHomeobj = new TrainingHomes(driver);
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
        public void a_Conduct_a_site_search()
        {
            MyOwnLearningobj.CreateGeneralCourse(1, "site_search", browserstr);
            driver.UserLogin("userforregression",browserstr);
            Assert.IsTrue(MyOwnLearningobj.SiteSearch("site_search", browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void b_Ensure_a_homepage_feed_is_set_for_the_domain()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.Click_TrainingHome();
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.click_systemOptions();
            TrainingHomeobj.click_systemOptionsTab("System");
            TrainingHomeobj.click_systemOptionsAccordian("Branding and Customization");
            TrainingHomeobj.click_systemOptionsLink("Homepage Feeds");
            HomePageFeedobj.CreateHomeFeeds("mol");
            TrainingHomeobj.click_systemOptionsTab("System");
            TrainingHomeobj.click_systemOptionsAccordian("Domains and URLS");
            TrainingHomeobj.click_systemOptionsLink("Domains");
            Assert.IsTrue(HomePageFeedobj.SetDomainFeeds("mol"));
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
