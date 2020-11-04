using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;

namespace Selenium2.Meridian
{
    class ScheduleAndManageSection
    {
          private readonly IWebDriver driverobj;

          public ScheduleAndManageSection(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool AddNewSection_Click()
        {
            try
            {
                driverobj.WaitForElement(btn_ScheduleAndManageSection);
                driverobj.GetElement(btn_ScheduleAndManageSection).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public string VerifyMultipleCredits()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.WaitForElement(lblmultiplecredits);
                actualresult = driverobj.GetElement(lblmultiplecredits).Text.Trim().Replace("Credit Hours:", "");
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
               
            }
            return actualresult;
        }

        private By btn_ScheduleAndManageSection = By.Id("MainContent_MainContent_ucTopBar_btnAddNewSection");
        private By lblmultiplecredits = By.XPath("//ul[@id='moreDetails']/li[2]/div/div[1]");

    }
}
