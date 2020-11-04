using OpenQA.Selenium;
using System;

namespace Selenium2.Meridian.P1.MyResponsibilities.Training
{
    public class AddLocalePage
    {
        public static string SetInfo()
        {
            string langSet = string.Empty;
            Driver.Instance.FindElement(By.XPath("//input[contains(@id,'MainContent_MainContent_UC1_chkLocale_0')]")).ClickWithSpace();
            langSet = Driver.Instance.FindElement(By.XPath("//label[@for='MainContent_MainContent_UC1_chkLocale_0']")).Text;
            Driver.Instance.FindElement(By.XPath("//input[@id='MainContent_MainContent_UC1_Save']")).ClickWithSpace();
            return langSet;
//            Verify the modal window is closed, and feedback is displayed indicating the locale(s) have been created for the content.

//Verify the locales selection/viewing listbox is displayed.

//Verify the default locale is marked in the selection/viewing listbox.

//Verify the new locale(s) are created for the content item.

            throw new NotImplementedException();
        }
    }
}