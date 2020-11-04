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
   public class i_ShoppingCart : TestBase
    {
        string browserstr = string.Empty;
         public i_ShoppingCart(string browser)
            : base(browser)
        {
            browserstr = browser+"shoppingcart";
}
      
        static ShoppingCartUtil ShoppingCartobj;
        static Productutil productobj;
        static MyOwnLearningUtils MyOwnLearningobj;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver.Manage().Window.Maximize();
            // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 5, 0));
            // driver.Navigate().GoToUrl("http://basedev3-ki-13-2-sql.meridianksi.net/Default.aspx");
            driver.Navigate().GoToUrl(Meridian_Common.MeridianTestSite);
            ShoppingCartobj = new ShoppingCartUtil(driver);
            MyOwnLearningobj = new MyOwnLearningUtils(driver);
            productobj = new Productutil(driver);

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
        public void a_Add_an_item_to_the_shopping_cart_that_has_sales_tax()
        {

            //driver.UserLogin("admin1",browserstr);
            //ShoppingCartobj.Enable_SalesTax();
            //ShoppingCartobj.managetaxrate();
            //ShoppingCartobj.Createtaxitemcategory();

            ////driver.UserLogin("admin1",browserstr);
            ////ShoppingCartobj.SetMultipleCurrency();
            //driver.UserLogin("userforregression",browserstr);
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            driver.UserLogin("admin1", browserstr);
            ShoppingCartobj.CreateGeneralCourseforcart(2, "SC", browserstr);
            //driver.UserLogin("admin");
            //ShoppingCartobj.SetMultipleCurrency();
            //driver.UserLogin("admin");
            //ShoppingCartobj.CreateGeneralCourseforcart(2);
            driver.UserLogin("userforregression", browserstr);
            ShoppingCartobj.additemtocartforgenral(2, 1);
       
        }

        [Test]
        public void b_Click_on_the_Shopping_Cart_icon()
        {


            driver.UserLogin("userforregression", browserstr);
            ShoppingCartobj.setbillingaddress();
            ShoppingCartobj.SwitchCurrency("United States Dollar", "USD");
            driver.UserLogin("userforregression", browserstr);
            bool _actualresult = ShoppingCartobj.CheckIteminCart(1,2);
            Assert.IsTrue(_actualresult);
        }
        //[Test]
        public void c_Change_the_billing_address()
        {


            //driver.UserLogin("userforregression",browserstr);
            //ShoppingCartobj.setbillingaddress();
            //driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

        }

        [Test]
        public void d_Remove_items_from_the_shopping_cart()
        {

            string _expectedresult = "50.00";
            driver.UserLogin("userforregression", browserstr);
            string _actualresult = ShoppingCartobj.RemoveItemfromCart();
            StringAssert.AreEqualIgnoringCase(_actualresult, _expectedresult);
            //driver.UserLogin("userforregression",browserstr);
            // bool _actualresultall = ShoppingCartobj.RemoveAllfromCart();
            //    Assert.IsTrue(_actualresultall);


        }
        [Test]
        public void e_Update_quantities_of_products_in_the_shooping_cart()
        {
            driver.UserLogin("admin1", browserstr);
            productobj.CreateProduct(1, "scart", browserstr);
            driver.UserLogin("userforregression", browserstr);
            ShoppingCartobj.additemtocartforproduct(1, 1, "scart", browserstr);
            driver.UserLogin("userforregression", browserstr);
            string _expectedresult = "150.00";
            string _actualresult = ShoppingCartobj.UpdateQuantityinCart();
            StringAssert.AreEqualIgnoringCase(_actualresult, _expectedresult);

        }
        [Test]
        public void f_Apply_a_discount_code_to_an_order()
        {

            driver.UserLogin("admin1", browserstr);
            ShoppingCartobj.adddiscount(browserstr);
            driver.UserLogin("userforregression",browserstr);
            
           Assert.IsTrue( ShoppingCartobj.ApplyDiscount(browserstr));
            


        }
        [Test]
        public void g_Switch_the_currency()
        {

            driver.UserLogin("userforregression", browserstr);
            bool _actualresult = ShoppingCartobj.SwitchCurrency("British Pound", "GBP");
            Assert.IsTrue(_actualresult);
        }
        [Test]
        public void h_Complete_a_purchase_using_a_AccountCode()
        {

            driver.UserLogin("userforregression", browserstr);
            
           ShoppingCartobj.checkoutitems();
           ShoppingCartobj.Purchaseusingaccountcode();
         Assert.IsTrue(  ShoppingCartobj.Complete_Purchase());
         driver.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        }

        [Test]
        public void i_Complete_a_purchase_using_a_Cybersource()
        {

            driver.UserLogin("userforregression", browserstr);
            ShoppingCartobj.additemtocartforgenral(1, 1);
            driver.UserLogin("userforregression", browserstr);
            ShoppingCartobj.checkoutnexttime();
          Assert.IsTrue(  ShoppingCartobj.Purchaseusingcybersource());
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
