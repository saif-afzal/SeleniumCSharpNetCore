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

namespace Selenium2.Meridian
{
    class AdminstrationConsole
    {
         private readonly IWebDriver driverobj;

         public AdminstrationConsole(IWebDriver driver)
        {
            driverobj = driver;
        }
      
        public bool Click_OpenItemLink(string linktext)
        {
            bool result = false;
            By AdministrationConsole_Link = By.XPath("//a[text()='" + linktext + "']");
            try
            {

               //driverobj.selectWindow(adminwindowtitle);
                driverobj.WaitForElement(AdministrationConsole_Link);
                if (Meridian_Common.MeridianTestbrowser == "IE")
                {
                    driverobj.ClickEleJs(AdministrationConsole_Link);
                }
                else
                {
                    driverobj.ClickEleJs(AdministrationConsole_Link);
                    //driverobj.GetElement(AdministrationConsole_Link).ClickWithSpace();
                }
                driverobj.selectWindow();
                result = true;
            }
            catch(Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link " + AdministrationConsole_Link, driverobj);
            }

            return result;
        }

        internal bool ClickOnCollaborationSpace_AdminConsole()
        {
             bool result = false;
            try
            {
                List<IWebElement> ele = driverobj.FindElements(By.CssSelector("a[onclick*='ML.BASE.CSPACE']")).ToList();
                foreach (var item in ele)
                {
                    if (item.Text.Equals("Collaboration Spaces")) { item.Click(); break; }
                }
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link " , driverobj);
            }
            return result;
        }
        public bool Click_OpenItemLinkById(string linkid)
        {
            bool result = false;
            By AdministrationConsole_Link = By.Id(linkid);
            try
            {

                //driverobj.selectWindow(adminwindowtitle);
                driverobj.WaitForElement(AdministrationConsole_Link);
                driverobj.GetElement(AdministrationConsole_Link).ClickAnchor();
                driverobj.selectWindow();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link " + AdministrationConsole_Link, driverobj);
            }

            return result;
        }
        public bool Click_SelectItemLink(string linktext)
        {
            bool result = false;
            By AdministrationConsole_Link = By.XPath("//a[text()='" + linktext + "']");
            try
            {
                driverobj.WaitForElement(AdministrationConsole_Link);
                driverobj.GetElement(AdministrationConsole_Link).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool verify_ConfigurationConsoleVisible()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_ConfigurationConsole);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool verify_ConfigurationConsoleNotVisible()
        {
            bool result = false;

            try
            {
                driverobj.ElementNotPresent(lnk_ConfigurationConsole);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        string adminwindowtitle = "Administration Console";

        private By lnk_ConfigurationConsole = By.XPath("//a[contains(text(),'Configuration Console')]");
   }    
    
}
