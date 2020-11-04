using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;
using System.Threading;

namespace Selenium2.Meridian
{
    class AddDevelopmentActivities
    {
        private readonly IWebDriver driverobj;

        public AddDevelopmentActivities(IWebDriver driver)
        {
            driverobj = driver;
        }
     
        public bool Click_AddDevelopmentActivity()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(btn_search).ClickWithSpace();

                result = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }

            return result;
        }
        private By txt_searchfor = By.Id("MainContent_UC1_SearchFor");
        private By btn_search = By.Id("btnSearch");
        
    }
}
