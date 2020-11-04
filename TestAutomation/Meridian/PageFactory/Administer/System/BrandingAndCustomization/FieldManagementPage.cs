using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class FieldManagementPage
    {
        public static UserprofileCommand Userprofile { get { return new UserprofileCommand(); } }
    }

    public class UserprofileCommand
    {
        public UserprofileCommand()
        {
        }

        public void ClickUserInformation()
        {
            Driver.existsElement(By.Id("MainContent_UC1_UserProfileContact"));
            Driver.clickEleJs(By.Id("MainContent_UC1_UserProfileContact"));
        }
    }
}