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
    class SelectCertificate
    {
        private readonly IWebDriver driverobj;
        public SelectCertificate(IWebDriver driver)
        {
            driverobj = driver;
        }
        
        public bool Click_SearchCertificate()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_searchcertificate);
                driverobj.ClickEleJs(btn_searchcertificate);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool Click_SelectCertificateToAdd()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(rb_selectcertificate);
              //  driverobj.GetElement(rb_selectcertificate).ClickWithSpace();
                driverobj.ClickEleJs(rb_selectcertificate);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public bool Click_SelectCertificate()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_selectcertificate);
                driverobj.ClickEleJs(btn_selectcertificate);
               // driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_success);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        private By tab_Certificate = By.XPath("//span[contains(.,'Certificate')]");
        private By btn_searchcertificate = By.Id("TabMenu_ML_BASE_BTN_SelectCertificate_ML.BASE.BTN.Search");
        private By rb_selectcertificate = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_BTN_SelectCertificate_CertificateSearch_ctl03_')]");
        private By btn_selectcertificate = By.Id("TabMenu_ML_BASE_BTN_SelectCertificate_ML.BASE.BTN.SelectCertificate");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");

    }
}
