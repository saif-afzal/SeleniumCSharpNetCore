using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class AddDevelopmentActivityPage
    {
        public static AddDevelopmentContentCommand Content { get { return new AddDevelopmentContentCommand(); } }

        public static void ClickSearchbutton()
        {
            Driver.existsElement(By.Id("btnSearch"));
            Driver.clickEleJs(By.Id("btnSearch"));
        }

        public static void AddContent()
        {
            Driver.clickEleJs(By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_chkAdd"));
            Driver.clickEleJs(By.Id("MainContent_ucSearchResults_btnAdd"));
        }
    }

    public class AddDevelopmentContentCommand
    {
        public AddDevelopmentContentCommand()
        {
        }

        public bool? ContentTypeisDisplay(string v)
        {
            return Driver.existsElement(By.XPath("//div[@id='MGSearchResults']/div[3]/ul/li/div/div[2]/p"));
        }
    }
}