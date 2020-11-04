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
    class ProductType : TestBase
    {
        string browserstr = string.Empty;
        public ProductType(string browser)
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
        [Test]
        public void a_Create_a_new_Product_Type()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Product Types");
            ProductTypesobj.Click_GoToButton();
            Assert.IsTrue(ProductTypesobj.Populate_ProductType());

        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_Product_Type()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Product Types");
            ProductTypesobj.Populate_Search();
            Assert.IsTrue(ProductTypesobj.Click_Search(browserstr));
            driver.Navigate_to_TrainingHome();
           // TrainingHomeobj.isTrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Product Types");
            ProductTypesobj.Click_lnkadvancesearch();
            ProductTypesobj.Populate_advancesearch();
            Assert.IsTrue(ProductTypesobj.Click_Search(browserstr));

        }


        [Test]
        public void c_Manage_a_Product_Type()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Product Types");
            ProductTypesobj.Populate_Search();
            ProductTypesobj.Click_Search(browserstr);
            ProductTypesobj.Click_Manage();
            Assert.IsTrue(ProductTypesobj.Click_save());

        }



        [Test]
        public void d_Delete_Product_Type_Detail()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Product Types");
            ProductTypesobj.Populate_Search();
            ProductTypesobj.Click_Search(browserstr);
            Assert.IsTrue(ProductTypesobj.Click_Delete());

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
