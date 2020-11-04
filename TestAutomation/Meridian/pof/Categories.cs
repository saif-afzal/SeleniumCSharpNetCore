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
using relativepath;

namespace Selenium2.Meridian
{
    class Categories
    {
        private readonly IWebDriver driverobj;

        public Categories(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_CreateGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_CreateGoTo);
                driverobj.GetElement(btn_CreateGoTo).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Job Title", driverobj);
            }

            return result;
        }

        public bool Populate_CreateForm()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_create_title);
                driverobj.GetElement(txt_create_title).Clear();
                driverobj.GetElement(txt_create_title).SendKeys("cat" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(txt_create_desc).Clear();
                driverobj.GetElement(txt_create_desc).SendKeys("cat" + ExtractDataExcel.token_for_reg);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }

            return result;
        }


        public bool Click_CreateCategory()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_create);
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        private By btn_CreateGoTo = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_create_title = By.Id("TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_TITLE");
        private By txt_create_desc = By.Id("TabMenu_ML_BASE_TAB_EditCategory_CTGYLCL_DESCRIPTION");
     
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
    }
}
