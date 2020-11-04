using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using System.Threading;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class AdministrationConsoles
    {
         private readonly IWebDriver driverobj;

         public AdministrationConsoles(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool RequiredTraining_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_AdminConsole.AdministrationConsole_RequiredTrainingConsole_Link);
                driver.GetElement(Locator_AdminConsole.AdministrationConsole_RequiredTrainingConsole_Link).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool Surveys_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_AdminConsole.AdministrationConsole_Surveys_Link);
                driver.GetElement(Locator_AdminConsole.AdministrationConsole_Surveys_Link).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool Instructors_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_AdminConsole.AdministrationConsole_Instructor_Link);
                driver.GetElement(Locator_AdminConsole.AdministrationConsole_Instructor_Link).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool DomainManagement_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_AdminConsole.AdministrationConsole_DomainManagement_Link);
                driver.GetElement(Locator_AdminConsole.AdministrationConsole_DomainManagement_Link).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool Click_OpenItemLink(string linktext)
        {
            bool result = false;
            By AdministrationConsole_Link = By.XPath("//a[text()='" + linktext + "']");
            try
            {
                //Thread.Sleep(3000);
                //driverobj.selectWindow(adminwindowtitle);
                driverobj.WaitForElement(AdministrationConsole_Link);
                driverobj.GetElement(AdministrationConsole_Link).ClickAnchor();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_SelectItemLink(string linktext)
        {
            bool result = false;
            By AdministrationConsole_Link = By.XPath("//a[contains(.,'" + linktext + "')]");
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

        

        string adminwindowtitle = "Administration Console";
    }



    

    class Locator_AdminConsole
    {
        
        public static By AdministrationConsole_RequiredTrainingConsole_Link = By.XPath("//a[contains(.,'Required Training Console')]");  
        public static By AdministrationConsole_Surveys_Link = By.XPath("//a[contains(.,'Surveys')]");
        public static By AdministrationConsole_Instructor_Link = By.XPath("//a[contains(.,'Instructors')]");
        public static By AdministrationConsole_DomainManagement_Link = By.XPath("//a[contains(.,'Domain Management')]");
    }
}
