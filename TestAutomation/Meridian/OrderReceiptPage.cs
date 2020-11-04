using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class OrderReceiptPage
    {
        public static OrderReceiptSectionCommand OrderReceiptSection { get { return new OrderReceiptSectionCommand(); } }

        public static string SuccessMessage()
        {
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text;
        }

        public static void ViewOrder()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_UC1_btnViewOrders']"));
        }

        public static bool? paymentsccessmessage(string v)
        {
            Driver.existsElement(By.XPath("//div[@class='alert alert-success']"));
            return Driver.GetElement(By.XPath("//div[@class='alert alert-success']")).Text.Equals(v);
        }

        public static bool? isOrdernumberdisplay()
        {
            return Driver.GetElement(By.XPath("//div[@id='content']/div[3]/div/div/div/h2")).Text.Contains("Order");
        }
    }

    public class OrderReceiptSectionCommand
    {
        public bool? ContentType(string v, string FormatGeneralCourse)
        {
            return Driver.GetElement(By.XPath("//a[contains(text(),'" + v + "')]/following::small")).Text.Equals(FormatGeneralCourse);
        }
    }
}