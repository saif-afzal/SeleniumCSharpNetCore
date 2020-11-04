﻿using System;
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
    class Product : TestBase
    {
        string browserstr = string.Empty;
        public Product(string browser)
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
        public void a_Create_a_new_Product()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Products");
            Productsobj.Click_CreateNewGoTo();
            Productsobj.Populate_Product("admin",browserstr);
            Productsobj.btncreateclick();
            Productsobj.updatecost();
            Assert.IsTrue(Productsobj.checkinproduct());



        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_Product()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Products");
            Productsobj.Populate_Search("admin", browserstr);
            Assert.IsTrue(Productsobj.Click_Search("admin", browserstr));
            driver.Navigate_to_TrainingHome();
            //TrainingHomeobj.isTrainingHome();
            AdminstrationConsoleobj.Click_OpenItemLink("Products");
            Productsobj.Click_lnkadvancesearch();
            Productsobj.Populate_advancesearch("admin", browserstr);
            Assert.IsTrue(Productsobj.Click_Search("admin", browserstr));

        }


        [Test]
        public void c_Manage_a_Product()
        {

            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Products");
            Productsobj.Populate_Search("admin", browserstr);
            Productsobj.Click_Search("admin", browserstr);

            Productsobj.Click_Manage();
            Productsobj.Click_CheckOut();
            Assert.IsTrue(Productsobj.Click_save("admin", browserstr));
            Assert.IsTrue(Productsobj.checkinproduct());
        }
        [Test]
        public void d_Edit_the_stock_for_a_product()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Products");
            Productsobj.Populate_Search("admin", browserstr);
            Productsobj.Click_Search("admin", browserstr);

            Productsobj.Click_Manage();
           Productsobj.Click_CheckOut();
            Assert.IsTrue(Productsobj.Click_addstock("admin"));

        }


        [Test]
        public void e_Delete_Product_Detail()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Products");
            Productsobj.Populate_Search("admin", browserstr);
            Productsobj.Click_Search("admin", browserstr);
            Assert.IsTrue(Productsobj.Click_Delete());

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