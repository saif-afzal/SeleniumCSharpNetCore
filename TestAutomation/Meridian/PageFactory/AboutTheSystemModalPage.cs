using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    internal class AboutTheSystemModalPage
    {
        internal static bool? ClickModalX()
        {
            Driver.clickEleJs(By.XPath("//a[@class='k-window-action k-link k-state-hover']"));
            return true;
        }
    }
}