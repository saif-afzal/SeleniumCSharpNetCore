using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian
{
    class Announcements_l
    {
        private readonly IWebDriver driverobj;
        public Announcements_l(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Check_Items()
        {
            bool actualresult = false;
            try
            {
               actualresult = driverobj.existsElement(pagetitle);
            
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Create on Button GoTo for Creating new Account Codes", driverobj);
            }
            return actualresult;
        }

          public bool Click_Search(string contenttitle)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_filter);
                driverobj.GetElement(txt_filter).SendKeysWithSpace(contenttitle);
                driverobj.WaitForElement(cmb_filter);
                driverobj.ClickEleJs(btn_filter);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Create on Button GoTo for Creating new Account Codes", driverobj);
            }
            return actualresult;
          }

          public bool Check_Result(string contenttitle)
        {
            bool actualresult = false;
            try
            {
                string text = driverobj.FindElement(By.Id("ctl00_MainContent_UC1_rlvSearchResults_ctrl0_lnkAnnDetails")).Text;
                if (text.Equals(contenttitle))
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Create on Button GoTo for Creating new Account Codes", driverobj);
            }
            return actualresult;
          }
      
        private By pagetitle= By.XPath("//h1[contains(.,'Announcements')]");
        private By txt_filter = By.Id("MainContent_UC1_txtSearch");
        private By cmb_filter = By.Id("MainContent_UC1_ddlSearchType");
        private By btn_filter = By.Id("MainContent_UC1_btnSearch");
    }
}
