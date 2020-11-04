using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class ReCertification
    {
        //Adding ReCertification Activities
        public bool AddContent(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ReCertification.ReCertification_AddContent_Button);
                driver.GetElement(Locator_ReCertification.ReCertification_AddContent_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button for Adding Content for Recertification", driver);
                return false;
            }
            return true;
        }

    }

    public class Locator_ReCertification
    {
        public static By ReCertification_AddContent_Button = By.Id("MainContent_MainContent_UC1_lnkAddContent");
    }
}
