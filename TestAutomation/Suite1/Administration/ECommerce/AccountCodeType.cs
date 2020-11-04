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
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
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
    class AccountCodeTypeold : TestBase
    {
        string browserstr = string.Empty;
        public AccountCodeTypeold(string browser)
            : base(browser)
        {
            browserstr = browser+"acto";
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
        public void a_Create_a_new_Account_Code_Type()
        {
            Meridian_Common.parentwdw = driver.CurrentWindowHandle;
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Account Code Types");
            AccountCodeTypesobj.Click_CreateNewGoTo();
            Assert.IsTrue(AccountCodeTypesobj.Populate_AccountCodeType(browserstr));

        }


        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_an_Account_Code_Type()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Account Code Types");
            Assert.IsTrue(AccountCodeTypesobj.Click_Search(browserstr));
            driver.Navigate_to_TrainingHome();
            // TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Ecommerce')]"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Account Code Types");
            Assert.IsTrue(AccountCodeTypesobj.Click_AdvSearch(browserstr));

        }

        [Test]
        public void c_Click_on_the_information_icon_for_an_Account_Code_Type()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='/kview/customcodebehind/base/ecommerce/accountcode/acodetypesimplesearch.aspx']"));
            driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            AdminstrationConsoleobj.Click_OpenItemLink("Account Code Types");
            AccountCodeTypesobj.Click_Search(browserstr);
            Assert.IsTrue(AccountCodeTypesobj.Click_InformationIcon(browserstr));

        }

        [Test]
        public void d_Manage_the_Account_Code_Type()
        {
            //TrainingHomeobj.isTrainingHome();
            //TrainingHomeobj.lnk_SystemOptions_click();
            //TrainingHomeobj.lnk_Ecommerce_click();
            //TrainingHomeobj.lnk_PricingandCodes_click();
            TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[@href='/kview/customcodebehind/base/ecommerce/accountcode/acodetypesimplesearch.aspx']"));
           // driver.GetElement(By.XPath("//a[contains(.,'Pricing and Codes')]")).ClickWithSpace();
            //AdminstrationConsoleobj.Click_OpenItemLink("Account Code Types");
            AccountCodeTypesobj.Click_Search(browserstr);
            AccountCodeTypesobj.Click_ManageItem();
            Assert.IsTrue(AccountCodeTypesobj.Edit_AccountCodeType());

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
