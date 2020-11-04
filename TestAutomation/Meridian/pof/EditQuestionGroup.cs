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
    class EditQuestionGroup
    {
         private readonly IWebDriver driverobj;

         public EditQuestionGroup(IWebDriver driver)
        {
            driverobj = driver;
        }

         public bool Populate_NewGroup(int i)
         {
             bool result = false;

             try
             {
                 
                     driverobj.WaitForElement(txt_structuretitle);
                     driverobj.GetElement(txt_structuretitle).Clear();
                     driverobj.GetElement(txt_structuretitle).SendKeysWithSpace("test_structure_" + ExtractDataExcel.token_for_reg + i);
                     driverobj.GetElement(txt_structuredesc).Clear();
                     driverobj.GetElement(txt_structuredesc).SendKeysWithSpace("test_structure_" + ExtractDataExcel.token_for_reg);
                     driverobj.GetElement(txt_structurekeyword).Clear();
                     driverobj.GetElement(txt_structurekeyword).SendKeysWithSpace("test_structure_" + ExtractDataExcel.token_for_reg);
                     driverobj.GetElement(txt_structurequestion).Clear();
                     driverobj.GetElement(txt_structurequestion).SendKeysWithSpace("1");
                     driverobj.GetElement(btn_create).ClickWithSpace();
                     driverobj.WaitForElement(lbl_success);
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
         private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
         private By txt_structuretitle = By.Id("TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_TITLE");
         private By txt_structuredesc = By.Id("TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_DESCRIPTION");
         private By txt_structurekeyword = By.Id("TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_KEYWORDS");
         private By txt_structurequestion = By.Id("TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_NUM_QUESTIONS");
         private By btn_create = By.Id("ML.BASE.BTN.Create");
         private By btn_return = By.Id("Return");
    }
}
