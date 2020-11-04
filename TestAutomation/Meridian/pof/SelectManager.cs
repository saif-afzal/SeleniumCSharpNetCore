using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using Selenium2.Meridian;
using System.Threading;
using NUnit.Framework;
using System.Text.RegularExpressions;
using Utility;
using System.Reflection;
using relativepath;

namespace Selenium2.Meridian
{
   public class SelectManager
    {
        private readonly IWebDriver driverobj;

        public SelectManager(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_AddManager()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addmanager);
                driverobj.GetElement(btn_addmanager).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click On Add Manager Button", driverobj);
            }

            return result;
        }

        private By btn_addmanager = By.Id("TabMenu_ML_BASE_TAB_SelectManagers_GoPageActionsMenu");
    }
}
