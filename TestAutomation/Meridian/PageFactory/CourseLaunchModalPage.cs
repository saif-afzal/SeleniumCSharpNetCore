using OpenQA.Selenium;
using ParallelTesting_Solution2;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class CourseLaunchModalPage:ObjectInit
    {
        private IWebDriver objDriver;
        public CourseLaunchModalPage(IWebDriver objDriver) : base(objDriver)
        {
            this.objDriver = objDriver;
        }
        public  bool? Exist(string focuswdw="")
        {
            objDriver.focusParentWindow();
            //objDriver..SelectWindowfocus(focuswdw, focuswdw);
       //     Thread.Sleep(15000);
          //  objDriver..SelectWindowClose2("Core Domain", focuswdw);
            Thread.Sleep(5000);
            return true;
        }

        internal  void ClickBrowserX()
        {
            objDriver.SelectWindowClose2("", "Details");
        }
    }
}