using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class TrainingAssignemntDashboardPage
    {
        public static bool? ischartdisplay()
        {
            return Driver.existsElement(By.XPath("//div[@class='col-sm-6 col-md-4']"));
        }

        public static bool? isfiltersaredisplay()
        {
            Driver.existsElement(By.XPath("//span[@class='org-filter-value']"));
            return Driver.existsElement(By.XPath("//button[@id='btnContentSearch']"));
        }

        public static bool? isresultsDisplayed()
        {
            return Driver.existsElement(By.XPath("//div[2]/div/div/div[2]/div[2]/div/div/div"));
        }
    }
}