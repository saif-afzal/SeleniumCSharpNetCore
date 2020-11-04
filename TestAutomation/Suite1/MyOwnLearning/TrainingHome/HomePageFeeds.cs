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
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace Selenium2.Meridian.Suite.MyOwnLearning.TrainingHome
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class HomePageFeedsold : TestBase
    {
        string browserstr = string.Empty;
        public HomePageFeedsold(string browser)
            : base(browser)
        {
            browserstr = browser + "HPF";
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
            HomePageFeedobj = new Homepagefeedutil(driver);
            TrainingHomeobj = new TrainingHomes(driver);
            driver.UserLogin("admin1", browserstr);
        }
      
        static MyOwnLearningUtils MyOwnLearningobj;
        static Homepagefeedutil HomePageFeedobj;
        static TrainingHomes TrainingHomeobj;
   

        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
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
        //[Test] Cannot be done as it deals with the domain
        public void b_Ensure_a_homepage_feed_is_set_for_the_domain()
        {
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.Click_TrainingHome();
            //TrainingHomeobj.isTrainingHome();
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
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    string screenShotPath = ScreenShot.Capture(driver, browserstr);
                    _test.Log(Status.Info, stacktrace + errorMessage);
                    _test.Log(Status.Info, "Snapshot below: " + _test.AddScreenCaptureFromPath(screenShotPath));

                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            //  _extent.Flush();
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            else
            {
                driver.Navigate_to_TrainingHome();
                //  TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Training Management')]"));
                //if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                //{
                //    driver.Navigate().Refresh();
                //}
                //    driver.Navigate().Refresh();
            }
        }


    }
}
