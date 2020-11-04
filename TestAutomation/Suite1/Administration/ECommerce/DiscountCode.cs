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

namespace Selenium2.Meridian.Suite.Administration.ECommerce
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("safari", Category = "safari")]
    [TestFixture("edge", Category = "edge")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class DiscountCodeold : TestBase
    {
        string browserstr = string.Empty;
        public DiscountCodeold(string browser)
            : base(browser)
        {
            browserstr = browser+"dco";
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
        public void a_Create_a_new_discount_code_for_item()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Discount Codes");
            DiscountCodesobj.Click_DiscontCodeTypeItem();
            DiscountCodesobj.Click_CreateNewGoTo();
            Assert.IsTrue(DiscountCodesobj.Populate_DiscountCode_item(browserstr));

        }

        [Test]
        public void a_Create_a_new_discount_code_for_order()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Discount Codes");
            DiscountCodesobj.Click_DiscontCodeTypeOrder();
            DiscountCodesobj.Click_CreateNewGoTo();
            Assert.IsTrue(DiscountCodesobj.Populate_DiscountCode_order(browserstr));

        }
        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_an_discount_code()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Discount Codes");
            Assert.IsTrue(DiscountCodesobj.Click_Search(browserstr));
            driver.Navigate_to_TrainingHome();
            // TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Discount Codes");
            Assert.IsTrue(DiscountCodesobj.Click_AdvSearch(browserstr));

        }

        [Test]
        public void c_Click_on_the_information_icon_for_an_discount_code()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Discount Codes");
            DiscountCodesobj.Click_Search(browserstr);
            Assert.IsTrue(DiscountCodesobj.Click_InformationIcon(browserstr));

        }

        [Test]
        public void d_Manage_the_discount_code()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Discount Codes");
            DiscountCodesobj.Click_Search(browserstr);
            DiscountCodesobj.Click_ManageItem();
            Assert.IsTrue(DiscountCodesobj.Edit_DiscountCodes());

        }



        [Test]
        public void e_Add_content_to_the_discount_code()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Discount Codes");
            DiscountCodesobj.Click_Search(browserstr);
            DiscountCodesobj.Click_ManageItem();
            DiscountCodesobj.Click_ContentTab();
            DiscountCodesobj.Click_AddContentGoTo();
            DiscountCodesobj.Click_SearchContent();
            DiscountCodesobj.Click_SelectDiscountCodetoAddContent();
            Assert.IsTrue(DiscountCodesobj.Click_AddContent());
        }

        [Test]
        public void e_Add_user_group_to_the_discount_code()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Discount Codes");
            DiscountCodesobj.Click_Search(browserstr);
            DiscountCodesobj.Click_ManageItem();
            DiscountCodesobj.Click_userTab();
            DiscountCodesobj.Click_AddUserGoTo();
            DiscountCodesobj.Click_SearchUser();
            DiscountCodesobj.Click_SelectDiscountCodetoAddUser();
            Assert.IsTrue(DiscountCodesobj.Click_AddUser());

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
