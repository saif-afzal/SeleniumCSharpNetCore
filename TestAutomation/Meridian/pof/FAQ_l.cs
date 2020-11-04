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
    class FAQ_l
    {
        private readonly IWebDriver driverobj;
        public FAQ_l(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Check_Items()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(pagetitle);

                actualresult = true;
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
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_rlvSearchResults_ctrl0_lnkQuestionDetails"));
                string textFAQContent = driverobj.gettextofelement(By.Id("ctl00_MainContent_UC1_rlvSearchResults_ctrl0_lnkQuestionDetails"));
                if (textFAQContent.Contains(contenttitle)) { actualresult = true; }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Create on Button GoTo for Creating new Account Codes", driverobj);
            }
            return actualresult;
        }

        private By pagetitle = By.XPath("//h1[contains(.,'FAQs')]");
        private By txt_filter = By.Id("MainContent_UC1_txtSearch");
        private By cmb_filter = By.Id("MainContent_UC1_ddlSearchType");
        private By btn_filter = By.Id("MainContent_UC1_btnSearch");
    }
}
