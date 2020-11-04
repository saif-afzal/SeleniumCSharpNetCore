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
    class AccountCode : TestBase
    {
        string browserstr = string.Empty;
        public AccountCode(string browser)
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
          //  driver.SelectWindowClose();
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
            if (Meridian_Common.islog == true)
            {
             driver.UserLogin("admin1",browserstr);
            }
         //   driver.SwitchtoDefaultContent();
            Meridian_Common.islog = false;
        }
        [Test]
        public void a_Create_a_new_account_code()
        {
            //driver.UserLogin("admin1", browserstr);
           TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_Ecommerce_click();
            TrainingHomeobj.lnk_PricingandCodes_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Account Codes");
            AccountCodesobj.Click_CreateNewGoTo();
            Assert.IsTrue(AccountCodesobj.Populate_AccountCode(browserstr));

        }


        [Test]
        public void b_Conduct_a_simple_and_advanced_search_for_an_account_code()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_Ecommerce_click();
            TrainingHomeobj.lnk_PricingandCodes_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Account Codes");
            Assert.IsTrue(AccountCodesobj.Click_Search(browserstr));
            driver.Navigate_to_TrainingHome();
           // TrainingHomeobj.isTrainingHome();
       
            AdminstrationConsoleobj.Click_OpenItemLink("Account Codes");
            Assert.IsTrue(AccountCodesobj.Click_AdvSearch(browserstr));

        }

        [Test]
        public void c_Click_on_the_information_icon_for_an_account_code()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_Ecommerce_click();
            TrainingHomeobj.lnk_PricingandCodes_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Account Codes");
            AccountCodesobj.Click_Search(browserstr);
            Assert.IsTrue(AccountCodesobj.Click_InformationIcon(browserstr));

        }

        [Test]
        public void d_Manage_the_account_code()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_Ecommerce_click();
            TrainingHomeobj.lnk_PricingandCodes_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Account Codes");
            AccountCodesobj.Click_Search(browserstr);
            AccountCodesobj.Click_ManageItem();
            Assert.IsTrue(AccountCodesobj.Edit_AccountCodes());

        }



        [Test]
        public void e_Add_content_to_the_account_code()
        {
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_Ecommerce_click();
            TrainingHomeobj.lnk_PricingandCodes_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Account Codes");
            AccountCodesobj.Click_Search(browserstr);
            AccountCodesobj.Click_ManageItem();
            AccountCodesobj.Click_ContentTab();
            AccountCodesobj.Click_AddContentGoTo();
            AccountCodesobj.Click_SearchContent();
            AccountCodesobj.Click_SelectAccountCodetoAddContent();
            Assert.IsTrue(AccountCodesobj.Click_AddContent());

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
                TrainingHomeobj.lnk_PricingandCodes_click();
                TrainingHomeobj.lnk_Ecommerce_click();
                if (!driver.GetElement(By.Id("lbUserView")).Displayed)
                {
                    driver.Navigate().Refresh();
                }
                
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
