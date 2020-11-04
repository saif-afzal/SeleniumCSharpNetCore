using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class OrderPage
    {
        public static void Click_Purchased_Content(string s)
        {
            Driver.clickEleJs(By.LinkText(s));
        }

        public static bool Verify_PurchasedAccessKey(string s)
        {
            bool result = false;
            try
            {
                Driver.clickEleJs(By.LinkText("View Order"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(.,'Manage Access Keys')]"));
                Driver.Instance.IsElementVisible(By.XPath("//a[contains(@id,'btnAssign')]"));
                Driver.Instance.IsElementVisible(By.LinkText(s));
                result = true;
            }
            catch (Exception e)
            {

            }

            return result;


        }

        public static void Click_PurchasedContentTitle()
        {
            Driver.clickEleJs(By.Id("ctl00_MainContent_UC1_MRadGrid_Order_ctl00_ctl04_lnkDetails"));
        }

        public static bool? isPurchasedCotentDisplayed()
        {
            return Driver.existsElement(By.XPath("//tr[@id='ctl00_MainContent_UC1_rgOrderHistory_ctl00__0']/td[4]/ul/li/a"));
        }



        public static void ClickOrderedItemViewDetails(string v)
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]/following::a[contains(text(),'View Details')][1]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]/following::a[contains(text(),'View Details')][1]"));
            //Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]/following::a[1]"));
        }
    }
}