using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class TeamPage
    {
        public static bool? IsPeopleCountDisplayed()
        {
            return Driver.existsElement(By.XPath("//h5[@id='DirectReports']"));
        }

        public static bool? VerifyAvatarIsDisplayed()
        {
            return Driver.existsElement(By.XPath("//tr//td[1]//div[1]//div[1]//img[1]"));
        }

        public static bool? VerifyEmployeeInitialsAreDisplayed()
        {
            return Driver.existsElement(By.XPath("//tr[7]//td[1]//div[1]//div[1]//span[1]"));
        }

        public static bool? VerifyEmployeeNamesAreDisplayed()
        {
            return Driver.existsElement(By.XPath("//tr//td[1]//div[1]//div[2]//strong[1]"));
        }
    }
}