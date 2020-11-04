﻿using System;
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
    class EditField
    {
         private readonly IWebDriver driverobj;

         public EditField(IWebDriver driver)
        {
            driverobj = driver;
        }
         public bool Click_EditDefaultField()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_defaulteditfield);
                 string originalHandle = driverobj.CurrentWindowHandle;
                 driverobj.GetElement(lnk_defaulteditfield).ClickWithSpace();
                 Thread.Sleep(4000);
                 driverobj.selectWindow("Select Text Value");
                 Thread.Sleep(4000);
                 driverobj.WaitForElement(txt_changefield);
                 driverobj.GetElement(txt_changefield).Clear();
                 driverobj.GetElement(txt_changefield).SendKeys("keyword_" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(btn_saveeditedfield).ClickWithSpace();
                 driverobj.WaitForElement(lbl_success);
                 driverobj.Close();
                 Thread.Sleep(3000);
                 driverobj.SwitchTo().Window(originalHandle);
                 driverobj.WaitForElement(By.XPath("//td[contains(.,'"+"keyword_" + ExtractDataExcel.token_for_reg+"')]"));
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }

         public bool Click_EditCustomField()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(lnk_customeditfield);
                 string originalHandle = driverobj.CurrentWindowHandle;
                 driverobj.GetElement(lnk_customeditfield).ClickWithSpace();
                 Thread.Sleep(4000);
                 driverobj.selectWindow("Select Text Value");
                 Thread.Sleep(4000);
                 driverobj.WaitForElement(txt_changefield);
                 driverobj.GetElement(txt_changefield).Clear();
                 driverobj.GetElement(txt_changefield).SendKeys("Custom_edited" + ExtractDataExcel.token_for_reg);
                 driverobj.GetElement(btn_saveeditedfield).ClickWithSpace();
                 driverobj.WaitForElement(lbl_success);
                 driverobj.Close();
                 Thread.Sleep(3000);
                 driverobj.SwitchTo().Window(originalHandle);
                 driverobj.WaitForElement(By.XPath("//td[contains(.,'" + "Custom_edited" + ExtractDataExcel.token_for_reg + "')]"));

                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }
         public bool Click_UnCheckVisibility()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(chk_visible);
               //  driverobj.GetElement(chk_visible).Click();
                 driverobj.ClickEleJs(chk_visible);
                 driverobj.GetElement(btn_save).ClickWithSpace();
                 Thread.Sleep(10000);
                 driverobj.WaitForElement(lbl_success);
                 result = true;
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }
         private By lnk_defaulteditfield = By.Id("TabMenu_ML_BASE_LBL_EditField_CUSTOM_FIELD_LABEL_EDIT");
         private By lnk_customeditfield = By.Id("TabMenu_ML_BASE_LBL_EditCustomField_CUSTOM_FIELD_LABEL_EDIT");
         private By txt_changefield = By.Id("TabMenu_ML_BASE_TAB_LocaleText_CUSTOM_FIELD_LABEL");
         private By btn_saveeditedfield = By.Id("SaveStrings");
         private By btn_save = By.Id("primaryaction");
         private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");

         private By chk_visible = By.Id("TabMenu_ML_BASE_LBL_EditCustomField_CUSTOM_FIELD_ATTRIBUTES_3");
        
    }
}