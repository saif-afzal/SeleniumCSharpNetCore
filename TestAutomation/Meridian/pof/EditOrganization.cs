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
   public class EditOrganization
    {
        private readonly IWebDriver driverobj;

        public EditOrganization(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_SelectManager()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(tab_selectmanager);
                driverobj.ClickEleJs(tab_selectmanager);
              //  driverobj.FindElement(tab_selectmanager).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Tab for Selecting a Mnager for Organization", driverobj);
            }

            return result;
        }

        public bool Click_Selecttpoc()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(tab_selectpoc);
                driverobj.GetElement(tab_selectpoc).Click();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        private By tab_selectmanager =By.XPath("//span[contains(.,'Select Managers')]");
        private By tab_selectpoc = By.Id("ML.BASE.WF.SelectTrainingPOCsactive");
    }
}
