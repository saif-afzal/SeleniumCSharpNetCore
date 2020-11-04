using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CheckoutPage
    {
        public static OrderSummarySectionCommand OrderSummarySection { get { return new OrderSummarySectionCommand(); } }

        public static Cybersoursepaymentcommand Cybersoursepayment { get { return new Cybersoursepaymentcommand(); } }

        public static void UseThisPaymentMethod()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnUsePaymentMethod']"));
        }

        public static void AcceptTermsandCondition()
        {
            Driver.existsElement(By.XPath("//input[@id='cbAgreeToTerms']"));
            Driver.clickEleJs(By.XPath("//input[@id='cbAgreeToTerms']"));
        }

        public static void PlaceOrder()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnPlaceOrder']"));
        }

        public static void selectPaymentmethod(string v)
        {
            Driver.existsElement(By.XPath("//input[@id='MainContent_UC1_PMTCYBERSOURCE']"));
            if(v== "Cybersource Secure Acceptance")
            {
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_PMTCYBERSOURCE']"));
            }
        }
    }

    public class OrderSummarySectionCommand
    {
        public bool? ContentType(string v, string FormatGeneralCourse)
        {
            return Driver.GetElement(By.XPath("//a[contains(text(),'" + v + "')]/following::small[1]")).Text.Equals(FormatGeneralCourse);
        }
    }
}