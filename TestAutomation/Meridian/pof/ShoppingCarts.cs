using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
//using Selenium2.Meridian.Suite.MyResponsibilities.c_ManageContentPortlet;
using System.Reflection;
using System.Threading;
using NUnit.Framework;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
   public class ShoppingCarts
    {
        private readonly IWebDriver driverobj;

        public ShoppingCarts(IWebDriver driver)
        {
            driverobj = driver;
        }



        public bool Click_ShoppingCartLink(string producttitle)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_ShoppingCart);
                driverobj.GetElement(lnk_ShoppingCart).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + producttitle + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public bool Click_CheckOut()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_checkout);
                driverobj.GetElement(btn_checkout).ClickWithSpace();
                driverobj.WaitForElement(btn_useThisPaymentMethod);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public bool Populate_ShippingAddress()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_shippingadd1);
                driverobj.GetElement(txt_shippingadd1).Clear();
                driverobj.GetElement(txt_shippingadd1).SendKeysWithSpace("test add1");
                driverobj.WaitForElement(txt_shippingcity);
                driverobj.GetElement(txt_shippingcity).Clear();
                driverobj.GetElement(txt_shippingcity).SendKeysWithSpace("testcity");
                driverobj.WaitForElement(cmb_shippingcountry);
                driverobj.getcomboitemselected(cmb_shippingcountry, 1);
                driverobj.WaitForElement(cmb_shippingstate);
                driverobj.getcomboitemselected(cmb_shippingstate, 1);
                driverobj.WaitForElement(txt_shippingcode);
                driverobj.GetElement(txt_shippingcode).Clear();
                driverobj.GetElement(txt_shippingcode).SendKeysWithSpace("123456");
                driverobj.WaitForElement(txt_shippingphone);
                driverobj.GetElement(txt_shippingphone).Clear();
                driverobj.GetElement(txt_shippingphone).SendKeysWithSpace("123456789");
                driverobj.WaitForElement(btn_continuetopayment);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public static void completePurchaseProcess()
        {
            Driver.clickEleJs(By.XPath("//span[contains(.,'Shopping Cart')]"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnCheckout']"));
            Driver.clickEleJs(By.XPath("//input[@value='Use this payment method']"));
            Driver.clickEleJs(By.XPath("//input[@id='cbAgreeToTerms']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnPlaceOrder']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));

        }

        public static void purchaseAccessKeys(string v, string coursetype)
        {
            var content = v;
            switch(content)
            {
                case "Bundle":
                    CommonSection.Learn.Home();
                    CommonSection.SearchCatalog(coursetype);
                    Driver.clickEleJs(By.XPath("//a[contains(.,'"+coursetype+"')]"));
                    Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_ucContentECommerce_FormView1_txtQuantity']")).Clear();
                    Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_ucContentECommerce_FormView1_txtQuantity']")).SendKeysWithSpace("10");
                    Driver.clickEleJs(By.XPath("//input[@value='Add to Cart']"));
                    
                    break;

                case "Curriculam":
                    CommonSection.Learn.Home();
                    CommonSection.SearchCatalog(coursetype);
                    Driver.clickEleJs(By.XPath("//a[contains(.,'" + coursetype + "')]"));
                    Driver.Instance.GetElement(By.XPath("//input[@id='hdnQuantity']")).Clear();
                    Driver.Instance.GetElement(By.XPath("//input[@id='hdnQuantity']")).SendKeysWithSpace("10");
                    Driver.clickEleJs(By.XPath("//*[@id='price-block']/div/span/a"));
                    break;

                case "Certification":
                    CommonSection.Learn.Home();
                    CommonSection.SearchCatalog(coursetype);
                    Driver.clickEleJs(By.XPath("//a[contains(.,'" + coursetype + "')]"));
                    Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_ucContentECommerce_FormView1_txtQuantity']")).Clear();
                    Driver.Instance.GetElement(By.XPath("//input[@id='MainContent_ucContentECommerce_FormView1_txtQuantity']")).SendKeysWithSpace("10");
                    Driver.clickEleJs(By.XPath("//input[@value='Add to Cart']"));
                    break;

            }
        }

        public bool Click_CountinueToPayment()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_continuetopayment);
                driverobj.GetElement(btn_continuetopayment).Click();
                driverobj.WaitForElement(btn_next);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public string Click_Update_Content_Amount(string Amount, string title)
        {
            string result = string.Empty;
            try
            {
                var contentAmount = By.XPath("//input[@id='ctl00_MainContent_UC1_MRadGrid_Digital_ctl00_ctl04_SHOPPINGCART_CONTENT_QTY']");
                var updateButton = By.XPath("//input[@id='ctl00_MainContent_UC1_MRadGrid_Digital_ctl00_ctl04_DigitalUpdateItemQuantity']");
                int qty1 = 1;
                int qty2 = 99;
                int num1 = int.Parse(Amount);
                driverobj.FindElement(By.XPath("//a[contains(.,'"+ title +"')]")).FindElement(contentAmount);

                driverobj.WaitForElement(contentAmount);
                driverobj.GetElement(contentAmount).Clear();
                if (Amount.Contains("-"))
                {
                    driverobj.GetElement(contentAmount).SendKeys(Keys.Subtract);
                    Thread.Sleep(3000);
                    driverobj.WaitForElement(updateButton);
                    driverobj.FindElement(updateButton).ClickWithSpace();
                    result = driverobj.gettextofelement(By.XPath("//div[@class='alert alert-error']"));
                }
                if (Amount.Equals("0"))
                {
                    driverobj.GetElement(contentAmount).SendKeysWithSpace(Amount);
                    Thread.Sleep(3000);
                    driverobj.WaitForElement(updateButton);
                    driverobj.FindElement(updateButton).ClickWithSpace();
                    result = driverobj.gettextofelement(By.XPath("//div[@class='alert alert-success']"));
                }
                  if (num1 >= qty1 && num1 <=  qty2 )
                {
                    driverobj.GetElement(contentAmount).SendKeysWithSpace(Amount);
                    //Update content totals by pressing Update
                    Thread.Sleep(3000);
                    driverobj.WaitForElement(updateButton);
                    driverobj.FindElement(updateButton).ClickWithSpace();
                    Thread.Sleep(3000);
                    result = driverobj.gettextofelement(By.XPath("//div[@class='alert alert-success']"));
                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return result;
        }
        
            
        public bool  Click_ShipToThisAddress()
        {

            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_shiptothisaddress);
                driverobj.GetElement(btn_shiptothisaddress).ClickWithSpace();
                Thread.Sleep(1000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public bool Click_Next()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_next);
                driverobj.GetElement(btn_next).Click();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public bool Click_ViewOrder()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_vieworder);
                driverobj.GetElement(btn_vieworder).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public bool Enable_Avalara_Saletax()
        {
            bool actualresult = false;
            try
            {
             if(!driverobj.existsElement(By.Id("TabMenu_ML_BASE_SalesTaxOptions_AvaTaxURL")))
             {
                 driverobj.GetElement(By.Id("TabMenu_ML_BASE_SalesTaxOptions_EnableManualSalesTax_1")).ClickWithSpace();
                 driverobj.GetElement(By.Id("ML.BASE.BTN.Save")).ClickWithSpace();
                 driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_SalesTaxOptions_AvaTaxURL"));
             }
                IWebElement rb_Shippingaddress = driverobj.FindElement(By.Id("TabMenu_ML_BASE_SalesTaxOptions_DefaultTaxAddressDigital_1"));
                if (rb_Shippingaddress.Displayed)
                {
                    driverobj.GetElement(rb_Shippingaddress1).ClickWithSpace();
                    driverobj.GetElement(btn_SaveSaletax).ClickWithSpace();
                    Thread.Sleep(5000);
                    driverobj.SelectWindowClose2("Sales Tax Options", "Details");
                  //  actualresult = true;
                }

                else
                {
                    driverobj.GetElement(rb_FalseManualSaletax).ClickWithSpace();
                    driverobj.GetElement(btn_SaveSaletax).ClickWithSpace();
                    driverobj.WaitForElement(rb_Shippingaddress1);
                    driverobj.GetElement(rb_Shippingaddress1).ClickWithSpace();
                    driverobj.GetElement(btn_SaveSaletax).ClickWithSpace();
                    driverobj.Close();
                 //   actualresult = true;
                }
                
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }
        internal void Click_ManageAccessKeys()
        {
            try
            {
                driverobj.WaitForElement(manageAccessKey);
                driverobj.GetElement(manageAccessKey).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void AssignCourse_AccessKeys(string browserstr)
        {
            try
            {
                List<IWebElement> allCourses = driverobj.FindElements(By.CssSelector("tr[id*='_rgManageAccess']")).ToList();
                foreach (var item in allCourses)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr))
                    {
                        item.FindElement(assignButton).ClickAnchor();
                        Thread.Sleep(2000);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }

        internal void AssignCourse_AccessKeys_Classroomcourse(string browserstr)
        {
            try
            {
                List<IWebElement> allCourses = driverobj.FindElements(By.CssSelector("tr[id*='_rgManageAccess']")).ToList();
                foreach (var item in allCourses)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_classrommcourse["Title"] +  browserstr))
                    {
                        item.FindElement(assignButton).ClickAnchor();
                        Thread.Sleep(2000);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }

        internal void EnterUser_ToEnterAccessKey()
        {
            try
            {
                driverobj.WaitForElement(emailtextBox);
                driverobj.GetElement(emailtextBox).Clear();
                driverobj.GetElement(emailtextBox).SendKeys("automationmeridian@gmail.com");
                driverobj.GetElement(By.CssSelector("div[id='divAssignTokens']")).ClickWithSpace();//Click on lable to just verification of email..
                Thread.Sleep(1000);
                driverobj.GetElement(assignButton_AccessKey).Click();
                driverobj.WaitForElement(sucessAlert);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void AssignCourseUserAccessKey(string browserstr)
        {
            ShoppingCarts ShoppingCartsobj = new ShoppingCarts(driverobj);
            CheckOut CheckOutobj = new CheckOut(driverobj);
            TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
            Details Detailsobj = new Details(driverobj);
            driverobj.GetElement(select_NoOfItems).Clear();
            driverobj.GetElement(select_NoOfItems).SendKeys("5");
            Detailsobj.Click_AddToCart_Accesskey();
            driverobj.WaitForElement(sucessAlert);
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.Click_UseThisPaymentMethod();
            CheckOutobj.PlaceOrder();
            ShoppingCartsobj.Click_ViewOrder();
            ShoppingCartsobj.Click_ManageAccessKeys();
            ShoppingCartsobj.AssignCourse_AccessKeys(browserstr);
            ShoppingCartsobj.EnterUser_ToEnterAccessKey();
        
        }

        internal void PurchaseAccessKeysandOpenViewOrder(string browserstr)
        {
            ShoppingCarts ShoppingCartsobj = new ShoppingCarts(driverobj);
            CheckOut CheckOutobj = new CheckOut(driverobj);
            TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
            Details Detailsobj = new Details(driverobj);
            driverobj.GetElement(select_NoOfItems).Clear();
            driverobj.GetElement(select_NoOfItems).SendKeys("5");
            Detailsobj.Click_AddToCart_Accesskey();
            driverobj.WaitForElement(sucessAlert);
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.Click_UseThisPaymentMethod();
            CheckOutobj.PlaceOrder();
            ShoppingCartsobj.Click_ViewOrder();
        }

        internal void PurchaseAccessKeysandOpenViewOrder_NewUser(string browserstr)
        {
            ShoppingCarts ShoppingCartsobj = new ShoppingCarts(driverobj);
            CheckOut CheckOutobj = new CheckOut(driverobj);
            TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
            Details Detailsobj = new Details(driverobj);
            driverobj.GetElement(select_NoOfItems).Clear();
            driverobj.GetElement(select_NoOfItems).SendKeys("5");
            Detailsobj.Click_AddToCart_Accesskey();
            driverobj.WaitForElement(sucessAlert);
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.Click_UseThisPaymentMethod();
            CheckOutobj.FillBillingAddress();
            CheckOutobj.PlaceOrder();
            ShoppingCartsobj.Click_ViewOrder();
        }



        internal void PurchaseAccessKeysandOpenViewOrder_NewUser_Classroomcourse(string browserstr)
        {
            ShoppingCarts ShoppingCartsobj = new ShoppingCarts(driverobj);
            CheckOut CheckOutobj = new CheckOut(driverobj);
            TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
            Details Detailsobj = new Details(driverobj);
            driverobj.GetElement(select_NoOfItems_Classroom).Clear();
            driverobj.GetElement(select_NoOfItems_Classroom).SendKeys("5");
            Detailsobj.Click_AddToCart_Accesskey_Classroomcourse();
            driverobj.WaitForElement(sucessAlert);
            TrainingHomeobj.ShoppingCartClick();
            ShoppingCartsobj.Click_CheckOut();
            CheckOutobj.Click_UseThisPaymentMethod();
            CheckOutobj.FillBillingAddress();
            CheckOutobj.PlaceOrder();
            ShoppingCartsobj.Click_ViewOrder();
        }

        public bool select_cyberSourceSA()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(rd_cyberSourceSA);
                driverobj.GetElement(rd_cyberSourceSA).ClickWithSpace();
                driverobj.WaitForElement(btn_useThisPaymentMethod);
                driverobj.GetElement(btn_useThisPaymentMethod).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public bool select_invoice()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(rd_invoice);
                driverobj.GetElement(rd_invoice).ClickWithSpace();
                driverobj.WaitForElement(btn_useThisPaymentMethod);
                driverobj.GetElement(btn_useThisPaymentMethod).ClickWithSpace();
                driverobj.WaitForElement(txt_shippingAddress1);
                driverobj.GetElement(txt_shippingAddress1).SendKeysWithSpace("test1");
                driverobj.WaitForElement(txt_shippingCity);
                driverobj.GetElement(txt_shippingCity).SendKeysWithSpace("testcity");
                driverobj.WaitForElement(txt_shippingPinCode);
                driverobj.GetElement(txt_shippingPinCode).SendKeysWithSpace("824201");
                driverobj.WaitForElement(txt_shippingState);
                driverobj.FindSelectElementnew(txt_shippingState, "Alabama");
                driverobj.WaitForElement(txt_shippingState);
                driverobj.FindSelectElementnew(txt_shippingCountry, "UNITED STATES");
                driverobj.WaitForElement(btn_calculateSalesTax);
                driverobj.GetElement(btn_calculateSalesTax).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public bool placeOrder_cyberSourceSA()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_agreeToTerms);
                driverobj.GetElement(chk_agreeToTerms).ClickWithSpace();
                driverobj.WaitForElement(btn_placeOrder);
                driverobj.GetElement(btn_placeOrder).ClickWithSpace();
                driverobj.WaitForElement(btn_visa);
                driverobj.GetElement(btn_visa).ClickWithSpace();
                driverobj.WaitForElement(firstName);
                driverobj.GetElement(firstName).SendKeysWithSpace("Test");
                driverobj.GetElement(lastName).SendKeysWithSpace("User");
                driverobj.GetElement(email).SendKeysWithSpace("test@user.com");
                driverobj.GetElement(cardnumber).SendKeysWithSpace("4111111111111111");
                driverobj.GetElement(cvn).SendKeysWithSpace("123");
                driverobj.FindSelectElementnew(expiryMonth, "12       ");
                driverobj.FindSelectElementnew(expiryYear, "2035       ");
                driverobj.GetElement(btn_useThisPaymentMethod).ClickWithSpace();
                driverobj.WaitForElement(sucessAlert);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        public bool placeOrder_invoice()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_agreeToTerms);
                driverobj.GetElement(chk_agreeToTerms).ClickWithSpace();
                driverobj.WaitForElement(btn_placeOrder);
                driverobj.GetElement(btn_placeOrder).ClickWithSpace();                
                driverobj.WaitForElement(sucessAlert);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }

        internal bool? Click_BuyNow()
        {
            throw new NotImplementedException();
        }

        internal void Click_TermsAndConditions()
        {
            throw new NotImplementedException();
        }

        private By btn_calculateSalesTax = By.Id("MButton1");
        private By txt_shippingAddress1 = By.Id("PI_BILL_TO_TAX_STREET");
        private By txt_shippingCity = By.Id("PI_BILL_TO_TAX_CITY");
        private By txt_shippingState = By.Id("PI_BILL_TO_TAX_STATE_ID");
        private By txt_shippingPinCode = By.Id("PI_BILL_TO_TAX_ZIP");
        private By txt_shippingCountry = By.Id("PI_BILL_TO_TAX_COUNTRY_ID");
        private By expiryYear = By.Id("card_expiry_year");
        private By expiryMonth = By.Id("card_expiry_month");
        private By cvn = By.Id("card_cvn");
        private By cardnumber = By.Id("card_number");
        private By firstName = By.Id("bill_to_forename");
        private By lastName = By.Id("bill_to_surname");
        private By email = By.Id("bill_to_email");
        private By btn_visa = By.Id("_001");
        private By btn_placeOrder = By.Id("MainContent_UC1_btnPlaceOrder");
        private By chk_agreeToTerms = By.Id("cbAgreeToTerms");
        private By rd_cyberSourceSA = By.Id("MainContent_UC1_PMTCYBERSOURCE");
        private By rd_invoice = By.Id("MainContent_UC1_PMTACCOUNTCODE_0");
        private By btn_useThisPaymentMethod = By.XPath("//input[@type='submit']");
        private By sucessAlert = By.CssSelector("div[class*='alert-success']");
        private By emailtextBox = By.Id("MainContent_UC1_txtEmail1");
        private By assignButton_AccessKey = By.Id("MainContent_UC1_btnAssign");
        private By assignButton = By.CssSelector("a[id*='_btnAssign']");
        private By manageAccessKey = By.Id("MainContent_UC1_manageAccessButton");
        private By select_NoOfItems = By.Id("MainContent_ucContentECommerce_FormView1_txtQuantity");
        private By lnk_ShoppingCart = By.Id("NavigationStrip1_qucShoppingCart_lnkIcon");
        private By btn_checkout = By.Id("MainContent_UC1_btnCheckout");
        private By btn_continuetopayment = By.Id("MainContent_UC1_ContinueToPayment");
        private By btn_next = By.Id("MainContent_UC1_Checkout");


        private By btn_shiptothisaddress = By.XPath("//input[@value='Ship to this address']");

        private By txt_shippingadd1 = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_STREET");
        private By txt_shippingcity = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_CITY");
        private By cmb_shippingcountry = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_COUNTRY_ID");
        private By cmb_shippingstate = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_STATE_ID");
        private By txt_shippingcode = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_ZIP");
        private By txt_shippingphone = By.Id("MainContent_UC1_fvShippingInfo_SI_SHIP_TO_PHONE");
        private By btn_vieworder = By.Id("MainContent_UC1_btnViewOrders");

        private By rb_Shippingaddress1 = By.Id("TabMenu_ML_BASE_SalesTaxOptions_DefaultTaxAddressDigital_1");
        private By rb_FalseManualSaletax = By.Id("TabMenu_ML_BASE_SalesTaxOptions_EnableManualSalesTax_1");
        private By btn_SaveSaletax = By.Id("ML.BASE.BTN.Save");

        private By select_NoOfItems_Classroom = By.Id("ctl00_MainContent_ucClassroom_rgSections_ctl00_ctl04_txtQuantity");



    }
}
