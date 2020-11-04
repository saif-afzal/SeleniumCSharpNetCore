using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ExpiredLearningPrintPage
    {
        public static ExpiredLearningContentCommand ExpiredLearningContent { get { return new ExpiredLearningContentCommand(); } }
    }

    public class ExpiredLearningContentCommand
    {
        public bool? ContentType()
        {
            Driver.Instance.selectWindow("Expired InComplete Content");
            return Driver.GetElement(By.XPath("//tr//td[2]")).Displayed;
        }
    }
}