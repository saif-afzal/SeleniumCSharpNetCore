using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian;
using System.Collections.ObjectModel;
using System.Reflection;

namespace Selenium2.Meridian
{
    class MyRequests
    {

        private readonly IWebDriver driverobj;

        public MyRequests(IWebDriver driver)
        {
            driverobj = driver;
        }

        public string Click_FirstItem()
        {
            string elementtitle = string.Empty;
            try
            {
              
                driverobj.WaitForElement(lnk_requestfirstitem);
                elementtitle = driverobj.GetElement(lnk_requestfirstitem).Text;
                driverobj.GetElement(lnk_requestfirstitem).ClickWithSpace();
                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 60));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return elementtitle;
        }

        private By lnk_requestfirstitem = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails");
    }
}
