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
    class SelectTrainingPOC
    {
        private readonly IWebDriver driverobj;

        public SelectTrainingPOC(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_Addtpoc()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addtrainingpoc);
                driverobj.GetElement(btn_addtrainingpoc).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button for Adding Training POC", driverobj);
            }

            return result;
        }

        private By btn_addtrainingpoc = By.Id("TabMenu_ML_BASE_SelectTrainingPOCs_GoPageActionsMenu");
    }
}
