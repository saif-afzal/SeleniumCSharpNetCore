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

namespace Selenium2.Meridian.Suite.Administration.ECommerce
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class ManageExchangeRates : TestBase
    {
        string browserstr = string.Empty;
        public ManageExchangeRates(string browser)
            : base(browser)
        {
            browserstr = browser;

}
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
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
        public void a_Add_a_new_tax_table()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_Ecommerce_click();
            TrainingHomeobj.lnk_CurrencyandTaxes_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tax Rates");
            ManageTaxRatesobj.Click_AddNewTaxRate();
            Assert.IsTrue(ManageTaxRatesobj.Populate_NewTaxRate());

        }

        [Test]
        public void b_Manage_a_tax_table()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_Ecommerce_click();
            TrainingHomeobj.lnk_CurrencyandTaxes_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tax Rates");
            Assert.IsTrue(ManageTaxRatesobj.Click_ManageTaxRate());

        }
        [Test]
        public void c_Edit_a_tax_table()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_Ecommerce_click();
            TrainingHomeobj.lnk_CurrencyandTaxes_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Tax Rates");
            Assert.IsTrue(ManageTaxRatesobj.Click_EditTaxRate());

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
                TrainingHomeobj.lnk_CurrencyandTaxes_click();
                TrainingHomeobj.lnk_Ecommerce_click();
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
