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
    class ProductTypeold : TestBase
    {
        string browserstr = string.Empty;
        public ProductTypeold(string browser)
            : base(browser)
        {
            browserstr = browser+"pto";
            InitializeBase(driver);
            Driver.Instance = driver;
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            driver.UserLogin("admin1", browserstr);
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
        public void a_Create_a_new_Product_Type()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_ContentManagement_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Content Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Product Types");
            ProductTypesobj.Click_GoToButton();
            Assert.IsTrue(ProductTypesobj.Populate_ProductType());

        }

        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_a_Product_Type()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_ContentManagement_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Content Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Product Types");
            ProductTypesobj.Populate_Search();
            Assert.IsTrue(ProductTypesobj.Click_Search(browserstr));
            driver.Navigate_to_TrainingHome();
            // TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Content Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Product Types");
            ProductTypesobj.Click_lnkadvancesearch();
            ProductTypesobj.Populate_advancesearch();
            Assert.IsTrue(ProductTypesobj.Click_Search(browserstr));

        }


        [Test]
        public void c_Manage_a_Product_Type()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_ContentManagement_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Content Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Product Types");
            ProductTypesobj.Populate_Search();
            ProductTypesobj.Click_Search(browserstr);
            ProductTypesobj.Click_Manage();
            Assert.IsTrue(ProductTypesobj.Click_save());

        }



        [Test]
        public void d_Delete_Product_Type_Detail()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_ContentManagement_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Content Management')]"));
            AdminstrationConsoleobj.Click_OpenItemLink("Product Types");
            ProductTypesobj.Populate_Search();
            ProductTypesobj.Click_Search(browserstr);
            Assert.IsTrue(ProductTypesobj.Click_Delete());

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
