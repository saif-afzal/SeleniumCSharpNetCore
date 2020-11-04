using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ContentSharingPage
    {
        public static void PublishtoPublishcatalog()
        {
            Driver.existsElement(By.XPath("//input[@id='MainContent_MainContent_UC2_ShareToPublicCatalog']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC2_ShareToPublicCatalog']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC2_Save']"));

        }
    }
}