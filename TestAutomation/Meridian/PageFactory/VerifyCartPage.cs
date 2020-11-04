using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class VerifyCartPage
    {
        public static ContentCommand Content { get { return new ContentCommand(); } }
    }

    public class ContentCommand
    {
        public void ContentType(string FormatGeneralCourse)
        {
            Driver.GetElement(By.XPath("//div[@id='content']/div/h1/following::span[1]")).Text.Equals(FormatGeneralCourse);
        }
    }
}