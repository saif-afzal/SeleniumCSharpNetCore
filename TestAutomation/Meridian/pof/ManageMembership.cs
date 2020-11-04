using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;

namespace Selenium2.Meridian
{
    class ManageMembership
    {
        // Add instructors to domain
        public bool AddMembers_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ManageMembership.ManageMembership_Go_Button);
                driver.GetElement(Locator_ManageMembership.ManageMembership_Go_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Go button to Add Button", driver);
                return false;
            }
            return true;
        }
    }

    class Locator_ManageMembership
    {
        public static By ManageMembership_Go_Button = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
    }
}
