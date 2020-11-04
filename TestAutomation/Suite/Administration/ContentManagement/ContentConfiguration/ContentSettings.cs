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
    class ContentSettings : TestBase
    {
        string browserstr = string.Empty;
        public ContentSettings(string browser)
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
            driver.UserLogin("admin1",browserstr);

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
        string title = "testblog_" + ExtractDataExcel.token_for_reg;
        [Test]
        public void a_Create_a_new_blog()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Blogs");
            Blogsobj.Click_GoToButton();
            Assert.IsTrue(Blogsobj.Populate_blogs("", browserstr));

        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_blog()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Blogs");
            Blogsobj.Populate_Search("", browserstr);
            Assert.IsTrue(Blogsobj.Click_Search("", browserstr));
            driver.Navigate_to_TrainingHome();
            // TrainingHomeobj.isTrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Blogs");
            Blogsobj.Click_lnkadvancesearch();
            Blogsobj.Populate_advancesearch("", browserstr);
            Assert.IsTrue(Blogsobj.Click_Search("", browserstr));

        }


        [Test]
        public void c_Manage_a_blog()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Blogs");
            Blogsobj.Populate_Search("", browserstr);
            Blogsobj.Click_Search("", browserstr);
            Blogsobj.Click_Manage();
            Blogsobj.Click_CheckOut();
            Assert.IsTrue(Blogsobj.Click_save());

        }

        [Test]
        public void d_Assign_required_training_to_a_blog()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Blogs");
            Blogsobj.Populate_Search("", browserstr);
            Blogsobj.Click_Search("", browserstr);
            Assert.IsTrue(Blogsobj.blogs_req_training());

        }


        [Test]
        public void e_Delete_blog()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Blogs");
            Blogsobj.Populate_Search("", browserstr);
            Blogsobj.Click_Search("", browserstr);
            Assert.IsTrue(Blogsobj.Click_Delete());

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
                TrainingHomeobj.lnk_ContentManagement_click();
               // if (!driver.GetElement(By.Id("lbUserView")).Displayed)
               // {
                    driver.Navigate().Refresh();
              //  }
                
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