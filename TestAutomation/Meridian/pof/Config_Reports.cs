using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
// using TestAutomation.Data;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Selenium2.Meridian
{
    class Config_Reports
    {

        private readonly IWebDriver driverobj;

        public Config_Reports(IWebDriver driver)
        {
            driverobj = driver;
        }
        public void scheduletaskauthorizeduser()
        {
            try
            {

                driverobj.WaitForElement(ObjectRepository.adminscheduletaskauthorizeuserfalse);
                driverobj.GetElement(ObjectRepository.adminscheduletaskauthorizeuserfalse).ClickWithSpace();
                driverobj.WaitForElement(ObjectRepository.adminsavescheduletaskauthorizeuser);
                driverobj.GetElement(ObjectRepository.adminsavescheduletaskauthorizeuser).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//span[@id='ReturnFeedback']"));
                //driverobj.WaitForElement(ObjectRepository.returnbutton);
                //driverobj.GetElement(ObjectRepository.returnbutton).ClickWithSpace();
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

        }
    }
}
