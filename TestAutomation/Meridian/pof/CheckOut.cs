using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;
namespace Selenium2.Meridian
{
    class CheckOut
    {


        private readonly IWebDriver driverobj;
        public CheckOut(IWebDriver driver)
        {
            driverobj = driver;
        }



        public bool Click_CreditCard()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_creditcard);
                driverobj.GetElement(btn_creditcard).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool CreditCartInformation()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(creditcardtype);
                SelectElement cardSelect = new SelectElement(driverobj.GetElement(creditcardtype));
                cardSelect.SelectByText("Visa");
                driverobj.WaitForElement(creditcardnumber);
                driverobj.GetElement(creditcardnumber).SendKeysWithSpace("4111111111111111");
                SelectElement yearSelect = new SelectElement(driverobj.FindElement(expirationdate));
                yearSelect.SelectByText("2023");
                driverobj.WaitForElement(securitycode);
                driverobj.GetElement(securitycode).SendKeysWithSpace("123");
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool Click_UseThisPaymentMethod()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_usethispaymentmethod);
                driverobj.GetElement(btn_usethispaymentmethod).ClickWithSpace();

               

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool FillBillingAddress()
        {
            bool actualresult = false;
            try
            {
                if (IsBillingAddressPresent())
                {
                    return true;
                }
                else
                {
                    if (driverobj.existsElement(txt_Address1))
                    {
                       By txtName = By.Id("SI_SHIP_TO_NAME");
                       By txtphone = By.Id("SI_SHIP_TO_PHONE");
                        txt_Address1 = By.Id("SI_SHIP_TO_STREET");
                        txt_City = By.Id("SI_SHIP_TO_CITY");
                        drp_Country = By.Id("SI_SHIP_TO_COUNTRY_ID");
                        drp_State = By.Id("SI_SHIP_TO_STATE_ID");
                        txt_Postalcode = By.Id("SI_SHIP_TO_ZIP");
                        driverobj.WaitForElement(txt_Address1);

                        driverobj.GetElement(txt_Address1).SendKeysWithSpace("2001 Edmund Halley Drive");
                        driverobj.GetElement(txt_City).SendKeysWithSpace("Reston");
                        driverobj.FindSelectElement(drp_Country, "UNITED STATE");
                        driverobj.GetElement(txt_Postalcode).SendKeysWithSpace("24141");
                        driverobj.FindSelectElement(drp_State, "Virginia");
                        driverobj.GetElement(txtName).SendKeysWithSpace("Shipping1");
                        driverobj.GetElement(txtphone).SendKeysWithSpace("111111");

                    }
                    if (driverobj.existsElement(By.Id("PI_BILL_TO_TAX_STREET")))
                    {
                        By txtName = By.Id("SI_SHIP_TO_NAME");
                        By txtphone = By.Id("SI_SHIP_TO_PHONE");
                        txt_Address1 = By.Id("PI_BILL_TO_TAX_STREET");
                        txt_City = By.Id("PI_BILL_TO_TAX_CITY");
                        drp_Country = By.Id("PI_BILL_TO_TAX_COUNTRY_ID");
                        drp_State = By.Id("PI_BILL_TO_TAX_STATE_ID");
                        txt_Postalcode = By.Id("PI_BILL_TO_TAX_ZIP");
                        driverobj.WaitForElement(txt_Address1);

                        driverobj.GetElement(txt_Address1).SendKeysWithSpace("2001 Edmund Halley Drive");
                        driverobj.GetElement(txt_City).SendKeysWithSpace("Reston");
                        driverobj.FindSelectElement(drp_Country, "UNITED STATE");
                        driverobj.GetElement(txt_Postalcode).SendKeysWithSpace("24141");
                        driverobj.FindSelectElement(drp_State, "Virginia");
                        //driverobj.GetElement(txtName).SendKeysWithSpace("Shipping1");
                      //  driverobj.GetElement(txtphone).SendKeysWithSpace("111111");
                    }
                    if(driverobj.existsElement(By.Id("btnShipto")))
                    {
                        driverobj.GetElement(By.Id("btnShipto")).ClickWithSpace();
                        driverobj.WaitForElement(By.Id("lnkEditShipping"));
                    }
                  if(driverobj.existsElement(btn_calculatesalestax))
                  {
                      driverobj.GetElement(btn_calculatesalestax).ClickWithSpace();
                    
                  }
                  else
                  {
                      driverobj.GetElement(By.Id("PI_BILL_TO_USER_NAME")).SendKeysWithSpace("testbill");
                      driverobj.GetElement(By.Id("PI_BILL_TO_PHONE")).SendKeysWithSpace("1111 1111");
                      driverobj.WaitForElement(btn_save);
                      driverobj.GetElement(btn_save).ClickWithSpace();
                  }
                 //   driverobj.WaitForElement(By.XPath("//p[contains(.,'Order Total:        $50.00')]"));
                    actualresult = true;
                }


              //  driverobj.GetElement(btn_usethispaymentmethod).ClickWithSpace();
if(driverobj.existsElement(By.Id("btnAddShipto")))
{
    driverobj.GetElement(By.Id("btnAddShipto")).ClickWithSpace();
    driverobj.WaitForElement(By.Id("lnkEditShipping"));
}


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool IsBillingAddressPresent()
        {
            try
            {
                return driverobj.FindElement(By.Id("MainContent_UC1_lblAcceptTerms")).Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Print()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(btn_print);
                driverobj.GetElement(btn_print).ClickWithSpace();
                var window = driverobj.WindowHandles;
                foreach (string wdwtitle in window)
                {
                    driverobj.SwitchTo().Window(wdwtitle);
                    if (driverobj.Title == "Receipt")
                    {
                        actualresult = true;
                        driverobj.SelectWindowClose2(driverobj.Title, "Order Details");
                        break;
                    }
                }
                

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool ViewDetails()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(btn_viewdetails);
                driverobj.GetElement(btn_viewdetails).ClickWithSpace();
                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
     
        public bool PlaceOrder()
        {
            bool actualresult = false;
            try
            {
                IWebElement element = driverobj.FindElement(btn_placeorder);
                ((IJavaScriptExecutor)driverobj).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                driverobj.WaitForElement(btn_accept);
                driverobj.GetElement(btn_accept).Click();
                driverobj.WaitForElement(btn_placeorder);
                driverobj.GetElement(btn_placeorder).ClickWithSpace();
                if (driverobj.existsElement(successmessage))
                    actualresult = true;
                else
                    actualresult = false;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool PaymentMethodEdit()
        {
            bool actualresult = false;
            try
            {
                IWebElement element = driverobj.FindElement(btn_paymentmethodedit);
                ((IJavaScriptExecutor)driverobj).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                driverobj.WaitForElement(btn_paymentmethodedit);
                driverobj.GetElement(btn_paymentmethodedit).ClickWithSpace();
              
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool ClickCreditCard()
        {
            bool actualresult = false;
            try
            {
                IWebElement element = driverobj.FindElement(btn_paymentmethodedit);
                ((IJavaScriptExecutor)driverobj).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                driverobj.WaitForElement(btn_creditcard);
                driverobj.GetElement(btn_creditcard).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool ShippingAddress()
        {
            bool actualresult = false;
            try
            {
                if (!driverobj.existsElement(By.Id("btnShipto")))
                {
                    driverobj.WaitForElement(name);
                    driverobj.GetElement(name).SendKeysWithSpace("Test");
                    driverobj.WaitForElement(address1);
                    driverobj.GetElement(address1).SendKeysWithSpace("Main st");
                    driverobj.WaitForElement(city);
                    driverobj.GetElement(city).SendKeysWithSpace("Main City");
                    driverobj.WaitForElement(state);
                    SelectElement selectState = new SelectElement(driverobj.FindElement(state));
                    selectState.SelectByText("Maryland");
                    driverobj.WaitForElement(postalcode);
                    driverobj.GetElement(postalcode).SendKeysWithSpace("20874");
                    SelectElement selectCountry = new SelectElement(driverobj.FindElement(country));
                    selectCountry.SelectByText("UNITED STATES");
                    driverobj.WaitForElement(phonenumber);
                    driverobj.GetElement(phonenumber).SendKeysWithSpace("2222222222");
                    actualresult = true;

                }
                else
                {
                    driverobj.GetElement(By.Id("btnShipto")).ClickWithSpace();

                    actualresult = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool SameAsBillingAddress()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(btn_sameasbillingaddress);
                driverobj.GetElement(btn_sameasbillingaddress).ClickWithSpace();
                driverobj.WaitForElement(btn_calculatesalestax);
                driverobj.GetElement(btn_calculatesalestax).ClickWithSpace();
               
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool CreditCardInfoSave()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(btn_save);
                driverobj.GetElement(btn_save).ClickWithSpace();
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
       

        private By btn_creditcard = By.Id("MainContent_UC1_PMTPAYFLOWPROCREDITCARD");
        private By creditcardtype = By.Id("PI_CREDIT_CARD_TYPE");
        private By creditcardnumber = By.Id("ENCRYPTED_PI_CREDIT_CARD_NUMBER");
        private By expirationdate = By.Id("ENCRYPTED_PI_CREDIT_CARD_EXP_YEAR");
        private By securitycode = By.Id("ENCRYPTED_PI_CREDIT_CARD_CVC_NUMBER");
        private By btn_usethispaymentmethod = By.XPath("//input[@name='ctl00$MainContent$UC1$ctl01']");
        private By btn_accept = By.Id("cbAgreeToTerms");
        private By btn_placeorder = By.Id("MainContent_UC1_btnPlaceOrder");
        private By btn_sameasshippingaddress = By.Id("cbTaxShipSameAsBill");
        private By name = By.Id("SI_SHIP_TO_NAME");
        private By address1 = By.Id("SI_SHIP_TO_STREET");
        private By city = By.Id("SI_SHIP_TO_CITY");
        private By state = By.Id("SI_SHIP_TO_STATE_ID");
        private By postalcode = By.Id("SI_SHIP_TO_ZIP");
        private By country = By.Id("SI_SHIP_TO_COUNTRY_ID");
        private By phonenumber = By.Id("SI_SHIP_TO_PHONE");
        private By btn_sameasbillingaddress = By.Id("cbTaxShipSameAsBill");
        private By successmessage = By.XPath("//div[@class='alert alert-success']");
        private By btn_calculatesalestax = By.Id("MButton1");
        private By btn_paymentmethodedit = By.Id("MainContent_UC1_lnkPaymentEdit");
        private By btn_save = By.Id("MainContent_UC1_btnSave");
        private By btn_print = By.Id("MainContent_UC1_btnPrint");
        private By btn_viewdetails = By.Id("ctl00_MainContent_UC1_rgOrderHistory_ctl00_ctl04_lnkPurchaseDetails");

        private By txt_Address1 = By.Id("PI_BILL_TO_STREET");
        private By txt_City = By.Id("PI_BILL_TO_CITY");
        private By drp_Country = By.Id("PI_BILL_TO_COUNTRY_ID");
        private By drp_State = By.Id("PI_BILL_TO_STATE_ID");
        private By txt_Postalcode = By.Id("PI_BILL_TO_ZIP");



        
    }
}


