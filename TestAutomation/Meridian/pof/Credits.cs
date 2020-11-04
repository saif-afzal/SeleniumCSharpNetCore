using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian
{
    class Credits
    {
        private readonly IWebDriver driverobj;

        public Credits(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Check_CreditsonStart()
        {
            try
            {
                driverobj.WaitForElement(btn_addcredittype); // checkpoint on creating bundle/course
                driverobj.WaitForElement(btn_remove);
                driverobj.WaitForElement(lbl_defaultcredit);
                if (driverobj.GetElement(txt_defaultcredit).Text == "0")
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }

        public bool Click_AddCredits()
        {
            try
            {
                driverobj.WaitForElement(btn_addcredittype); // checkpoint on creating bundle/course
                driverobj.ClickEleJs(btn_addcredittype);
                //Thread.Sleep(5000);
                //driverobj.SelectFrame();
                //Thread.Sleep(5000);
                driverobj.WaitForElement(txt_firstcredit);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
                return false;
            }
            return true;
        }
        public bool Fill_MultipleCredits()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(txt_firstcredit);
                driverobj.GetElement(txt_firstcredit).Clear();
                driverobj.GetElement(txt_firstcredit).SendKeysWithSpace("5");
                //driverobj.GetElement(txt_secondcredit).Clear();
                //driverobj.GetElement(txt_secondcredit).SendKeysWithSpace("10");

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }

        public bool Click_SaveCredits()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_savecredits);
                driverobj.GetElement(btn_savecredits).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
           //     driverobj.WaitForElement(chk_firstcredit);
           //     driverobj.WaitForElement(chk_secndcredit);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }
       

        public bool Click_SaveAllCredits()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(chk_allcredits);
               // driverobj.GetElement(chk_allcredits).ClickWithSpace();
                driverobj.ClickEleJs(chk_allcredits);
                driverobj.GetElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl06_txtCreditValue")).SendKeysWithSpace("2");
                driverobj.GetElement(btn_saveallcredits).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }

        public bool Click_Return()
        {
            bool result = false;
            try
            {
                driverobj.WaitForElement(btn_return);
                driverobj.GetElement(btn_return).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;

        }
        private By btn_addcredittype = By.Id("MainContent_MainContent_UC1_btnAddNew");
        private By btn_remove = By.Id("MainContent_MainContent_UC1_btnRemove");
        private By lbl_defaultcredit =By.XPath("//td[contains(.,'Default Credit Type')]");
        private By txt_defaultcredit = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl04_txtCreditValue");
        private By txt_defaultcreditentry = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl08_txtCreditValue");
        private By txt_firstcredit = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl04_txtCreditValue");
        private By txt_secondcredit = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl06_txtCreditValue");
        private By btn_savecredits = By.Id("MainContent_MainContent_UC1_Add");
        private By lbl_success = By.XPath("//div[@class='alert alert-success']");
        private By chk_firstcredit = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl06_chkRemove");
        private By chk_secndcredit = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl08_chkRemove");
        private By btn_return = By.Id("MainContent_MainContent_UC1_btnCancel");
        private By chk_allcredits = By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgCredits_ctl00_ctl02_ctl01_chkRemoveHeader");
        private By btn_saveallcredits = By.Id("MainContent_MainContent_UC1_MButton1");
    }
}
