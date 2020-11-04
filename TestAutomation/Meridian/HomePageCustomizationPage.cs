using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class HomePageCustomizationPage
    {
        public static void Click_Collapse_RecentlyAddedPortlet()
        {
            Driver.clickEleJs(By.XPath("//div[@id='ctl00_MainContent_rdDock_ucRecentlyAdded_T']/ul/li/a/span"));
        }

        public static void Click_Collapse_RecommendationPortlet()
        {
            Driver.clickEleJs(By.XPath("//div[@id='ctl00_MainContent_rdDock_ucLearnerRecommendations_T']/ul/li/a/span"));
        }

        public static void ClickButton_Save()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_PageSaveButton']"));
            Driver.Instance.findandacceptalert();
            Thread.Sleep(5000);
        }

        public static void Click_Expand_RecentlyAddedPortlet()
        {
            Driver.clickEleJs(By.XPath("//div[@id='ctl00_MainContent_rdDock_ucRecentlyAdded_T']/ul/li/a/span"));
        }

        public static void Click_Expand_RecommendationPortlet()
        {
            Driver.clickEleJs(By.XPath("//div[@id='ctl00_MainContent_rdDock_ucLearnerRecommendations_T']/ul/li/a/span"));
        }

        public static void DragandDrop_RecommendationPortlet()
        {
            Actions ac = new Actions(Driver.Instance);
            ac.DragAndDrop(Driver.Instance.FindElement(By.XPath("//div[@id='ctl00_MainContent_rdDock_ucLearnerRecommendations_T']/em")), Driver.Instance.FindElement(By.XPath("//div[@id='ctl00_MainContent_rdzPanel_1']")));
            ac.Build().Perform();
        }

        public static void DragandDrop_RecommendationPortlet_Revert()
        {
            Actions ac = new Actions(Driver.Instance);
            ac.DragAndDrop(Driver.Instance.FindElement(By.XPath("//div[@id='ctl00_MainContent_rdzPanel_1']")), Driver.Instance.FindElement(By.XPath("//div[@id='ctl00_MainContent_rdDock_ucLearnerRecommendations_T']/em")));
            ac.Build().Perform();
        }

        public static void Add_CustomBlock()
        {
            string CustomBlock = Driver.GetElement(By.XPath("//div[@id='ctl00_MainContent_rdDock_ucCustomBlocks_T']/ul/li/a/span")).GetAttribute("title");
            if (CustomBlock=="Show")
            {
                Driver.clickEleJs(By.XPath("//div[@id='ctl00_MainContent_rdDock_ucCustomBlocks_T']/ul/li/a/span"));
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_PageSaveButton']"));
                Driver.Instance.findandacceptalert();
            }
            else
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_PageSaveButton']"));
                Driver.Instance.findandacceptalert();
            }
        }
    }
}