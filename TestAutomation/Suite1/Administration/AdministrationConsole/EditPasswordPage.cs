using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    internal class EditPasswordPage
    {
        internal static void CreatePasseord()
        {
            throw new NotImplementedException();
        }

        internal static void CreatePasseord(string password)
        {
            Driver.Instance.GetElement(By.Id("MainContent_UC1_CurrentPassword")).SendKeys(password);
            Driver.Instance.GetElement(By.Id("MainContent_UC1_USR_PASSWORD")).SendKeys("password");
            Driver.Instance.GetElement(By.Id("MainContent_UC1_ConfirmPassword")).SendKeys("password");
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }
    }
}