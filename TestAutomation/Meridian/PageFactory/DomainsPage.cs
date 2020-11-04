using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class DomainsPage
    {
        public static void ClickDomainLink(string v)
        {
            Driver.clickEleJs(By.XPath("//div[@id='TabMenuMLBASETABDomainsDomainConsoleTree_1']/span[2]"));
            Thread.Sleep(2000);
        }
    }
}