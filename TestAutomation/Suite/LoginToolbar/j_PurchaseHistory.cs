using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium2;
using OpenQA.Selenium;
using NUnit.Framework;
using Selenium2.Meridian;
using TestAutomation.Meridian.Regression_Objects;

namespace Selenium2.Meridian.Suite.LoginToolbar
{
    [TestFixture("ffbs", Category = "firefox")]
    [TestFixture("chbs", Category = "chrome")]
    [TestFixture("iebs", Category = "iexplorer")]
    [TestFixture("anybrowser", Category = "local")]
    [Parallelizable(ParallelScope.Fixtures)]
    class j_PurchaseHistory: TestBase
    {
        string browserstr = string.Empty;
         public j_PurchaseHistory(string browser)
            : base(browser)
        {
            browserstr = browser+"purchis";
}
     
        static ShoppingCartUtil ShoppingCartobj;
        static MyOwnLearningUtils MyOwnLearningobj;
        static Purchaseutil Purchaseutilobj;
        static TrainingHomes TrainingHomesobj;
        static MyAccount MyAccountobj;
        static MyPurchases MyPurchasesobj;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            ShoppingCartobj = new ShoppingCartUtil(driver);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
            Purchaseutilobj = new Purchaseutil(driver);
            TrainingHomesobj = new TrainingHomes(driver);
            MyAccountobj = new MyAccount(driver);
            MyPurchasesobj = new MyPurchases(driver);
        }
        [SetUp]
        public void starttest()
        {
            Meridian_Common.islog = false;
            int ix1 = TestContext.CurrentContext.Test.FullName.LastIndexOf('.');
            int ix2 = ix1 > 0 ? TestContext.CurrentContext.Test.FullName.LastIndexOf('.', ix1 - 1) : -1;
            Meridian_Common.CurrentTestName = TestContext.CurrentContext.Test.FullName.Remove(0, ix2 + 1);
        }
        [Test]
        public  void a_Click_the_Purchase_History_link_from_the_portlet()
        {
           // driver.UserLogin("admin1",browserstr);
           // ShoppingCartobj.CreateGeneralCourseforcart(1,"purchase");
           // driver.UserLogin("userforregression",browserstr);
           // ShoppingCartobj.additemtocartforgenral(1, 1);
           // driver.UserLogin("admin1",browserstr);
           // Purchaseutilobj.AddAccountCodes();
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
           // driver.UserLogin("userforregression",browserstr);
           // ShoppingCartobj.setbillingaddress();
           // Purchaseutilobj.AccountCodeCheckout();
           // TrainingHomesobj.Click_MyAccount();
           //Assert.IsTrue( MyAccountobj.ClickPurchaseHistory());
           // driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            driver.UserLogin("userforregression", browserstr);
             TrainingHomesobj.Click_MyAccount();
             MyAccountobj.ClickEcommerceTab();
             Assert.IsTrue(MyAccountobj.ClickPurchaseHistory(browserstr));
            driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }
        [Test]
        public void a_View_the_Purchase_Details_for_a_content_item()
        {
            string addtext="purchase";
            int num=1;
            string expectedresult = ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "_" + addtext + num;
            driver.UserLogin("admin1", browserstr);
            ShoppingCartobj.CreateGeneralCourseforcart(num, addtext,browserstr);
            driver.UserLogin("userforregression", browserstr);
            ShoppingCartobj.additemtocartforgenral(1, 1);
            //driver.UserLogin("admin1", browserstr);
            //Purchaseutilobj.AddAccountCodes(browserstr);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("userforregression", browserstr);
            driver.WaitForElement(By.Id("lnkShoppingCart"));
            driver.GetElement(By.Id("lnkShoppingCart")).ClickWithSpace();
            driver.WaitForElement(By.Id("MainContent_UC1_btnCheckout"));
            driver.GetElement(By.Id("MainContent_UC1_btnCheckout")).ClickWithSpace();
            driver.WaitForElement(By.XPath(".//*[@id='MainContent_UC1_pnlPaymentInfo']/input"));
            driver.GetElement(By.XPath(".//*[@id='MainContent_UC1_pnlPaymentInfo']/input")).ClickWithSpace();
            //ShoppingCartobj.setbillingaddress();
            Purchaseutilobj.AccountCodeCheckout();
            //TrainingHomesobj.Click_MyAccount();
            //Assert.IsTrue(MyAccountobj.ClickPurchaseHistory(browserstr));
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            //driver.UserLogin("userforregression", browserstr);
            TrainingHomesobj.Click_MyAccount();
            MyAccountobj.ClickEcommerceTab();
            MyAccountobj.ClickPurchaseHistory(browserstr);
            StringAssert.AreEqualIgnoringCase(expectedresult,MyPurchasesobj.View_PurchaseHistoryDetail());
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
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

    }
}
