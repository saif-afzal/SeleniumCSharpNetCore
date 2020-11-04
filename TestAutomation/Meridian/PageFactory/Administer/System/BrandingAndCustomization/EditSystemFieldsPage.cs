using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class EditSystemFieldsPage
    {
        public static bool? isIncludeonAccountCreationDisplay()
        {
            return Driver.existsElement(By.XPath("//label[contains(text(),'Include on Account Creation.')]"));
        }

        public static bool? isIncludeonAccountCreationisUnchecked()
        {
            return Driver.GetElement(By.XPath("//input[@id='DBFA_ACCOUNT_CREATION']")).Selected;
        }
    }
}