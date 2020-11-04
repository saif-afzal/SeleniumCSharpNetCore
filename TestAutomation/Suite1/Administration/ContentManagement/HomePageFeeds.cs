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
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian.Suite.Administration.ContentManagement
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class HomePageFeedsold : TestBase
    {
        string browserstr = string.Empty;
        bool isdomain = false;
        public HomePageFeedsold(string browser)
            : base(browser)
        {
            browserstr = browser+"CMHpf";
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
            isdomain = false;
        }
       
       
        [SetUp]
        public void starttest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
             driver.UserLogin("admin1",browserstr);
            }
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Create_a_new_HomePageFeed()
        {

            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_system_click();
            //TrainingHomeobj.lnk_BrandingandCustomization_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[@href='#admin-console-system']"), By.XPath("//a[contains(.,'Branding and Customization')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Homepage Feeds");
            HomePageFeedobj.Click_GoToButton();
            Assert.IsTrue(HomePageFeedobj.Populate_HomeFeeds("adminhfeed", browserstr));

        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_HomePageFeed()
        {

            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_system_click();
            //TrainingHomeobj.lnk_BrandingandCustomization_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[@href='#admin-console-system']"), By.XPath("//a[contains(.,'Branding and Customization')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Homepage Feeds");
            HomePageFeedobj.Populate_Search("adminhfeed",browserstr);
            Assert.IsTrue(HomePageFeedobj.Click_Search("adminhfeed", browserstr));
            driver.Navigate_to_TrainingHome();
            // TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[@href='#admin-console-system']"), By.XPath("//a[contains(.,'Branding and Customization')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Homepage Feeds");
            HomePageFeedobj.Click_lnkadvancesearch();
            HomePageFeedobj.Populate_advancesearch("adminhfeed", browserstr);
            Assert.IsTrue(HomePageFeedobj.Click_Search("adminhfeed", browserstr));

        }


        [Test]
        public void c_Manage_a_HomePageFeed()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_system_click();
            //TrainingHomeobj.lnk_BrandingandCustomization_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[@href='#admin-console-system']"), By.XPath("//a[contains(.,'Branding and Customization')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Homepage Feeds");
            HomePageFeedobj.Populate_Search("adminhfeed", browserstr);
            HomePageFeedobj.Click_Search("adminhfeed", browserstr);
            HomePageFeedobj.Click_Manage();
            HomePageFeedobj.Click_CheckOut();
            Assert.IsTrue(HomePageFeedobj.Click_save());

        }

        [Test]
        public void d_Select_a_HomePageFeed()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_system_click();
            //TrainingHomeobj.lnk_DomainsandURLS_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[@href='#admin-console-system']"), By.XPath("//a[contains(.,'Domains and URLS')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            Assert.IsTrue(HomePageFeedobj.Click_SetDomainFeeds("adminhfeed", browserstr));
            isdomain = true;
        }

        [Test]
        public void e_Delete_HomePageFeed()
        {

            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_system_click();
            //TrainingHomeobj.lnk_BrandingandCustomization_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[@href='#admin-console-system']"), By.XPath("//a[contains(.,'Branding and Customization')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Homepage Feeds");
            HomePageFeedobj.Populate_Search("adminhfeed", browserstr);
            HomePageFeedobj.Click_Search("adminhfeed", browserstr);
            Assert.IsTrue(HomePageFeedobj.Click_Delete());

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