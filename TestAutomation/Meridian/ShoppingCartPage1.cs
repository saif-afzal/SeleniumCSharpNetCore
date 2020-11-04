using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class ShoppingCartPage
    {
        public static void Checkout()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//input[@value='Checkout']"));
        }
        public static CheckOutModalCommand CheckOutModal { get { return new CheckOutModalCommand(); } }

        public static ShoppingContentCommand Content { get { return new ShoppingContentCommand(); } }

        public static void ClickCheckout_public()
        {
            Driver.clickEleJs(By.XPath("//input[@value='Checkout']"));
        }

        public static void CompletePurchaseProcess()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnCheckout']"));
            Driver.clickEleJs(By.XPath("//input[@value='Use this payment method']"));
            Driver.clickEleJs(By.XPath("//input[@id='cbAgreeToTerms']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnPlaceOrder']"));
            Driver.Instance.IsElementVisible(By.XPath("//div[@class='alert alert-success']"));
        }

        public static bool? Title(string v)
        {
            
            return Driver.Instance.Title.Equals(v);
        }

        public static void ApplyDiscountCode(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='MainContent_UC1_tbDiscountCode']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_ApplyDiscountCode']"));
        }

        public static string VerifyWrongDiscountCodeMessage()
        {
            return Driver.GetElement(By.XPath("//div[@class='alert alert-error']")).Text;
        }

        public static string VerifyValidDiscountCodeMessage()
        {
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public static bool? DiscountedAmountIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_UC1_MRadGrid_Digital_ctl00__0']/td[3]/p[3]/span"));
        }

        public static void RemoveDiscountCode()
        {
            Driver.clickEleJs(By.XPath("//span[@class='fa fa-close']"));
        }

        public static string VerifyDiscountCodeRemoveMessage()
        {
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public static bool? DiscountedAmountInPercentageDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[@id='ctl00_MainContent_UC1_MRadGrid_Digital']//p[3]"));
        }

        public static void RemoveContent(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'"+v+"')]/following::td/input"));
            Driver.Instance.findandacceptalert();
        }
    }

    public class ShoppingContentCommand
    {
        public bool? ContentType(string v, string FormatGeneralCourse)
        {
            return Driver.GetElement(By.XPath("//a[contains(text(),"+v+")]/following::small")).Text.Equals(FormatGeneralCourse);
        }

        public bool? ContentType()
        {
            return Driver.GetElement(By.XPath("//small")).Displayed;
        }
    }

    public class CheckOutModalCommand
    {
        public CheckOutModalCommand()
        {
        }

        public void Login()
        {
            Driver.clickEleJs(By.Id("MainContent_UC1_Login"));
        }
    }
}