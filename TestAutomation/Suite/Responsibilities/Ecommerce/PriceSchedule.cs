using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Selenium2.Meridian;
using OpenQA.Selenium;
using Selenium2;
using System.Text.RegularExpressions;
using System.Threading;

namespace Selenium2.Meridian.Suite.MyResponsibilities.h_Ecommerce
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class a_PriceSchedule : TestBase
    {
        string browserstr = string.Empty;
        public a_PriceSchedule(string browser)
            : base(browser)
        {
            browserstr = browser;
        }

        public bool chktest = false;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            InitializeBase(driver);
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {

            driver.Quit();
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0,ix2+1);
        }
        [Test]
        public void a_Create_new_price_schedule()
        {
            bool foundresult = false;
            string expectedresult = "The item was created.";
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
        //    Thread.Sleep(2000);
            MyResponsibilitiesobj.Click_ECommerce();
            ManagePricingScheduleobj.Click_Add_New_Pricing_Schedule();
            ManagePricingScheduleobj.PopulatePricingScheduleName(Variables.PriceScheduleNameObj + browserstr);
            ManagePricingScheduleobj.PopulatePriceScheduleDescription();
            ManagePricingScheduleobj.Select_Valid_From();
            
            if (ManagePricingScheduleobj.Click_Create().Contains(expectedresult))
            {
                foundresult = true;

            }
            Assert.IsTrue(foundresult);
            
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
     
        }
        [Test]
        public void b_Search_And_Add_Content_PriceShedule_10197()
        {
            bool foundresult = false;
            string expectedresult = "The selected items were added.";
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ECommerce();
            ManagePricingScheduleobj.PopulatePricingScheduleSearch(browserstr);
            ManagePricingScheduleobj.Click_Search();
            ManagePricingScheduleobj.Click_Manage();
            ManagePricingScheduleobj.Click_AddContent();
            ManagePricingScheduleobj.Click_AddContent_Search();
            ManagePricingScheduleobj.PriceSchedule_Select_Content();

            if (ManagePricingScheduleobj.Click_Add_Content().Contains(expectedresult))
            {
                foundresult = true;

            }
            Assert.IsTrue(foundresult);

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
        [Test]
        public void c_Manage_And_Add_UserGroup_PriceShedule_10232()
        {
            bool foundresult = false;
            string expectedresult = "The selected items were added.";
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ECommerce();
            ManagePricingScheduleobj.PopulatePricingScheduleSearch(browserstr);
            ManagePricingScheduleobj.Click_Search();
            ManagePricingScheduleobj.Click_Manage();
            ManagePricingScheduleobj.Click_Add_UserGroup();
            ManagePricingScheduleobj.Click_AddUserGroup_Search();
            ManagePricingScheduleobj.PopulateUserGroupCost();

            if (ManagePricingScheduleobj.Click_AddUserGroup().Contains(expectedresult))
            {
                foundresult = true;

            }
            Assert.IsTrue(foundresult);

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        [Test]
        public void d_Copy_A_PriceShedule()
        {
            bool foundresult = false;
            string expectedresult = "The pricing schedule was copied.";
            driver.UserLogin("admin1", browserstr);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.MyResponsiblities_click();
            MyResponsibilitiesobj.Click_ECommerce();
            ManagePricingScheduleobj.PopulatePricingScheduleSearch(browserstr);
            ManagePricingScheduleobj.Click_Search();
            ManagePricingScheduleobj.Click_Copy();
            //driver.SelectFrame();
            driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            ManagePricingScheduleobj.Select_Valid_From();
            //ManagePricingScheduleobj.Click_Create();
            //driver.SwitchTo().DefaultContent();
        //    Assert.IsTrue(driver.WaitForElement(By.XPath("//div[@class='alert alert-success']")));
            
            Assert.IsTrue(driver.Compareregexstring(expectedresult,ManagePricingScheduleobj.Click_Create()));

            

            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }
     


        [TearDown]
        public void stoptest()
        {
            if (Meridian_Common.islog == true)
            {
                driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
        }
         }
}
