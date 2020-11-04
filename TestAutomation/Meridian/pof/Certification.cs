using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
namespace Selenium2.Meridian
{
    class Certification
    {
        //Adding Certification Activities
        public bool AddContent(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Certification.Certification_AddContent_Button);
                driver.GetElement(Locator_Certification.Certification_AddContent_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click Add Content Button", driver);
                return false;
            }
            return true;
        }

    }

    public class Locator_Certification
    {
        public static By Certification_AddContent_Button = By.Id("MainContent_MainContent_UC1_lnkUserGroup");
    }
}
