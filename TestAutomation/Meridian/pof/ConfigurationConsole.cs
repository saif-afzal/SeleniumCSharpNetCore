using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class ConfigurationConsole
    {
        private readonly IWebDriver driverobj;
        public ConfigurationConsole(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_Link(string linktext)
        {
            bool actualresult = false;
            By ConfigurationConsole_Link = By.XPath("//a[text()='" + linktext + "']");
            try
            {
                driverobj.WaitForElement(ConfigurationConsole_Link);

                driverobj.GetElement(ConfigurationConsole_Link).ClickWithSpace();

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link" + linktext, driverobj);
            }
            return actualresult;
        }
      
        
    }
}
