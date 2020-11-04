using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class SubscriptionPage
    {
        public static AvailableinCatalogCommand AvailableinCatalog { get { return new AvailableinCatalogCommand(); } }

        public static void ClickEdit()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_ucSummary_lnkEdit"));
        }
    }
}