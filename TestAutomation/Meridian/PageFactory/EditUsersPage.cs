using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    internal class EditUsersPage
    {
        public static AddUserCommand SelectOptions { get
            { return new AddUserCommand(); } }
    }

    internal class AddUserCommand
    {
        public AddUserCommand()
        {
        }

        internal void AddUserClickGo()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditRole_GoPageActionsMenu"));

        }
    }
}