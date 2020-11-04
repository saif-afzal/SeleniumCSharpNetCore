using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class ChangeCertificatePage
    {
        private static readonly object threa;

        public static bool? isAttributesdisplay()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_lnkTitle"));
                result = Driver.existsElement(By.Id("MainContent_MainContent_UC1_btnSearch"));
                
            }
            catch { }
            return result;
        }

        public static void Click_Search()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"));
        }

        public static void SelectandSaveOneCertificate()
        {
            Driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect"));
            Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_RadGrid1_ctl00_ctl04_rbSelect"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
            Thread.Sleep(2000);
            Driver.Instance.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);

        }

        public static string FeedbackMessage(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='content']/div[2]/div"));
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text;
        }

        public static void Click_back()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
        }
    }
}