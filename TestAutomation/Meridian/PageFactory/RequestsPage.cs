using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class RequestsPage
    {
        public static RequestsCommand Requests { get { return new RequestsCommand(); } }
    }

    public class RequestsCommand
    {
        public bool? ContentRequestType(string v)
        {
            throw new NotImplementedException();
        }

        public bool? ContentRequestType(string v, string FormatGeneralCourse)
        {
            return Driver.GetElement(By.XPath("//a[contains(text(),'"+v+"')]/following::td")).Text.Equals(FormatGeneralCourse);
        }
    }
}