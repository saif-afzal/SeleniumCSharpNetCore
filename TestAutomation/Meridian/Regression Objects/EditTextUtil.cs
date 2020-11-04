using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
// using TestAutomation.Data;
using System.Threading;
using Selenium2.Meridian;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class EditTextUtil
    {
        private readonly IWebDriver driverobj;
        public EditTextUtil(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Edittextelements()
        {
            bool actualresult = false;
            int i = 0;
            string[] elements = { "Learning", "Home" };
            try
            {
                foreach (string element in elements)
                {
                    driverobj.OpenToolbarItemsforElement(LinkEditTextElement);
                    //driverobj.SelectFrame();
                    driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                    driverobj.WaitForElement(TxtSearchFor);
                    driverobj.GetElement(TxtSearchFor).Clear();
                    driverobj.GetElement(TxtSearchFor).SendKeys(element);
                    driverobj.GetElement(BtnSearchFor).Click();
                    driverobj.WaitForElement(TxtCustomText);
                    driverobj.GetElement(TxtCustomText).Clear();
                    driverobj.GetElement(TxtCustomText).SendKeys(element + 1);
                    driverobj.GetElement(BtnSave).Click();
                    driverobj.findandacceptalert();
                    Thread.Sleep(15000);
                    if (i == 0)
                    {
                        driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + element + 1 + "')]"));
                        i++;
                    }
                    else
                    {
                        driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + element + 1 + "')]"));
                    }

                }
                foreach (string element in elements)
                {
                    driverobj.OpenToolbarItemsforElement(LinkEditTextElement);
                    //driverobj.SelectFrame();
                    driverobj.waitforframe(ObjectRepository.switchToFrame_New);
                    driverobj.WaitForElement(TxtSearchFor);
                    driverobj.GetElement(TxtSearchFor).Clear();
                    driverobj.GetElement(TxtSearchFor).SendKeys(element + 1);
                    driverobj.GetElement(BtnSearchFor).Click();
                    driverobj.WaitForElement(TxtCustomText);
                    driverobj.GetElement(TxtCustomText).Clear();
                    driverobj.GetElement(BtnSave).Click();
                    driverobj.findandacceptalert();
                    Thread.Sleep(15000);
                    actualresult = true;
                }
            }
            catch (Exception ex)
            {
             ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

      
        private By LinkEditTextElement = By.XPath("//span[contains(.,'Edit Text Elements')]");
        private By TxtSearchFor = By.Id("MainContent_ucAlterText_txtSearchFor");
        private By BtnSearchFor = By.Id("MainContent_ucAlterText_btnSearch");
        private By TxtCustomText = By.Id("ctl00_MainContent_ucAlterText_TextListingGrid_ctl00_ctl04_LOCALE_TEXT_CUSTOM_VALUE");
        private By BtnSave = By.Id("MainContent_ucAlterText_btnSave");
    }
}
