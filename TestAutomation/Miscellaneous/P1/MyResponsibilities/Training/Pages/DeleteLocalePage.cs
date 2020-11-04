using OpenQA.Selenium;
using System;

namespace Selenium2.Meridian.P1.MyResponsibilities.Training
{
    public class DeleteLocalePage
    {
        public static void ClickDeleteLocalButton()
        {
            Driver.Instance.FindElement(By.Id("MainContent_MainContent_UC1_deleteLocale")).ClickWithSpace();
        }
    }
}