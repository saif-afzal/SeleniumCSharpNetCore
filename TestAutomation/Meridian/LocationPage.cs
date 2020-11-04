using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    internal class LocationPage
    {
        internal static void ClickRemove()
        {
            Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSelectedLocation_ctrl0_lnkDelete"));
            Driver.Instance.findandacceptalert();

           // throw new NotImplementedException();
        }

        internal static void RemoveLocation()
        {
            Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rlvSelectedLocation_ctrl0_lnkDelete"));
            Driver.Instance.findandacceptalert();
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
            //throw new NotImplementedException();
        }

        internal static void AddLocation()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"));
            Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));

        }
    }
}