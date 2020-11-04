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


namespace Selenium2.Meridian.Suite.Administration.ContentManagement
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class HomePageFeeds : TestBase
    {
        string browserstr = string.Empty;
        public HomePageFeeds(string browser)
            : base(browser)
        {
            browserstr = browser+"CMHpf";
        }
        bool isdomain = false;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
         driver.UserLogin("admin1",browserstr);
            isdomain = false;
        }
        [SetUp]
        public void starttest()
        {

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

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_BrandingandCustomization_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Homepage Feeds");
            HomePageFeedobj.Click_GoToButton();
            Assert.IsTrue(HomePageFeedobj.Populate_HomeFeeds("adminhfeed", browserstr));

        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_HomePageFeed()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_BrandingandCustomization_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Homepage Feeds");
            HomePageFeedobj.Populate_Search("adminhfeed",browserstr);
            Assert.IsTrue(HomePageFeedobj.Click_Search("adminhfeed", browserstr));
            driver.Navigate_to_TrainingHome();
           // TrainingHomeobj.isTrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Homepage Feeds");
            HomePageFeedobj.Click_lnkadvancesearch();
            HomePageFeedobj.Populate_advancesearch("adminhfeed", browserstr);
            Assert.IsTrue(HomePageFeedobj.Click_Search("adminhfeed", browserstr));

        }


        [Test]
        public void c_Manage_a_HomePageFeed()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_BrandingandCustomization_click();
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
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_DomainsandURLS_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Domains");
            Assert.IsTrue(HomePageFeedobj.Click_SetDomainFeeds("adminhfeed", browserstr));
            isdomain = true;
        }

        [Test]
        public void e_Delete_HomePageFeed()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_system_click();
            TrainingHomeobj.lnk_BrandingandCustomization_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Homepage Feeds");
            HomePageFeedobj.Populate_Search("adminhfeed", browserstr);
            HomePageFeedobj.Click_Search("adminhfeed", browserstr);
            Assert.IsTrue(HomePageFeedobj.Click_Delete());

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
                driver.Navigate_to_TrainingHome();
             
               // TrainingHomeobj.lnk_system_click();
                TrainingHomeobj.lnk_SystemOptions_click();
              
               
            }
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Meridian_Common.islog = false;
            driver.Quit();
        }
    }
}