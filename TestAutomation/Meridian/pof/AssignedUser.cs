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
    class AssignedUser
    {
        private readonly IWebDriver driverobj;
        public AssignedUser(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_AddUserGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_addusergoto);
                driverobj.ClickEleJs(btn_addusergoto);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
     
        private By btn_addusergoto = By.Id("TabMenu_ML_BASE_LBL_AssignedUsers_GoPageActionsMenu");
     
    }
}
