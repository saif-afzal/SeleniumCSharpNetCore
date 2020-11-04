using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class OrderDetailsPage
    {
        public static ItemDetailsCommand ItemDetails { get { return new ItemDetailsCommand(); } }

        public static bool? VerifyPurchasedContent(string v)
        {
           return  Driver.GetElement(By.XPath("//a[contains(text(),'"+v+"')]")).Text.Equals(v);
        }
    }

    public class ItemDetailsCommand
    {
        public bool? ContentType(string v, string FormatGeneralCourse)
        {
            //string Format= 
            return Driver.GetElement(By.XPath("//a[contains(text(),'"+v+"')]/following::p")).Text.Substring(0,6).Equals(FormatGeneralCourse);
            //if (Format==FormatGeneralCourse)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

        }

        public void ClickContentTitle()
        {
            Driver.clickEleJs(By.XPath("//a[@id='ctl00_MainContent_UC1_rgOrderDetials_ctl00_ctl04_lnkDetails']"));
        }
    }
}