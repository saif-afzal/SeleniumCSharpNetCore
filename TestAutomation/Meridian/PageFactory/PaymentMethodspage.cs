using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class PaymentMethodspage
    {
        public static Cybersoursepaymentcommand Cybersoursepayment { get { return new Cybersoursepaymentcommand(); } }
    }

    public class Cybersoursepaymentcommand
    {
        public Cybersoursepaymentcommand()
        {
        }

        public CardCommand Card { get { return new CardCommand(); } }

        public PaymentDetailsCommand PaymentDetails { get { return new PaymentDetailsCommand(); } }
    }

    public class PaymentDetailsCommand
    {
        public PaymentDetailsCommand()
        {
        }

        public bool? isAmexisSelected()
        {
            return Driver.GetElement(By.XPath("//input[@id='card_type_003']")).Selected;
        }

        public void EnterCarddetails()
        {
            Driver.GetElement(By.XPath("//input[@id='bill_to_phone']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='bill_to_phone']")).SendKeysWithSpace("123456789");
            Driver.GetElement(By.XPath("//input[@id='bill_to_email']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='bill_to_email']")).SendKeysWithSpace("test@test.com");

            Driver.GetElement(By.XPath("//input[@id='card_number']")).Clear();
            Driver.GetElement(By.XPath("//input[@id='card_number']")).SendKeys("378734493671000");
            Driver.clickEleJs(By.Id("card_expiry_month"));
            Driver.select(By.Id("card_expiry_month"), "02");
            Driver.clickEleJs(By.Id("card_expiry_year"));
            Driver.select(By.Id("card_expiry_year"), "2021");
            Driver.GetElement(By.Id("card_cvn")).SendKeys("1234");
        }

        public void clickPay()
        {
            Driver.GetElement(By.XPath("//input[@name='commit']")).ClickWithSpace();
        }
    }

    public class CardCommand
    {
        public CardCommand()
        {
        }

        public void SelectCard(string v)
        {
            Driver.clickEleJs(By.XPath("//button[@title='Amex']"));
        }
    }
}
