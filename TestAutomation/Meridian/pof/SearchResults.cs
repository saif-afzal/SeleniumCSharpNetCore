using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class SearchResults
    {
          private readonly IWebDriver driverobj;
          public SearchResults(IWebDriver driver)
        {
            driverobj = driver;
        }
        // certification/curriculum on training catalog
        public bool Content_Click()
        {
            try
            {
                driverobj.WaitForElement(By.CssSelector("a[data-bind*='ContentDetails']"));
                driverobj.ClickEleJs(By.CssSelector("a[data-bind*='ContentDetails']"));
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public bool MyResponsbilities_Content_Click()
        {
            try
            {
                driverobj.WaitForElement(lnk_myresponsbilities_content);
                driverobj.GetElement(lnk_myresponsbilities_content).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool MyResponsbilities_Content_Click_Catalog()
        {
            try
            {
                driverobj.WaitForElement(lnk_myresponsbilities_content_catalog);
                driverobj.GetElement(lnk_myresponsbilities_content_catalog).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }
        public bool MyResponsbilities_ContentSP_Click()
        {
            try
            {
                driverobj.WaitForElement(lnk_myresponsbilities_contentSP);
                driverobj.GetElement(lnk_myresponsbilities_contentSP).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }
        // searching of goals on My Responsibilty - Performance Tab
        public bool GoalsInList()
        {
            try
            {
                driverobj.WaitForElement(lnk_GoalsName);
                driverobj.GetElement(lnk_GoalsName);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool verify_searchObject(String searchObject)
        {
            By lnk_searchObject = By.XPath("//a[text()='"+searchObject+"']");
            try
            {
                driverobj.WaitForElement(lnk_searchObject);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        
        private By lnk_myresponsbilities_content = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
        private By lnk_myresponsbilities_contentSP = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
        
        private By lnk_ContentName = By.Id("ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails");
        private By lnk_GoalsName = By.Id("ctl00_MainContent_ucSearchResults_rlvSearchResults_ctrl0_lnkDetails");
        private By lnk_myresponsbilities_content_catalog = By.Id("ctl00_MainContent_UC3_rlvSearchResults_ctrl0_lnkDetails");
        
    }
}
