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
    class EditQuestion
    {
          private readonly IWebDriver driverobj;

          public EditQuestion(IWebDriver driver)
        {
            driverobj = driver;
        }
          public bool Populate_NewQuestion()
          {
              bool result = false;

              try
              {

                  driverobj.WaitForElement(txt_question_title);
                  driverobj.GetElement(txt_question_title).Clear();
                  driverobj.GetElement(txt_question_title).SendKeysWithSpace("test_structure_question" + ExtractDataExcel.token_for_reg);
                  driverobj.GetElement(btn_create).ClickWithSpace();
                  driverobj.WaitForElement(lbl_success);
                  driverobj.WaitForElement(btn_return);
                  driverobj.GetElement(btn_return).ClickWithSpace();
                  result = true;
              }
              catch (Exception ex)
              {

                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Populate New Question for Test", driverobj);
              }

              return result;
          }
          public bool Populate_NewQuestionForTrueFalse()
          {
              bool result = false;

              try
              {

                  driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE"));
                  driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE")).Clear();
                  driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE")).SendKeysWithSpace("test_structure_question" + ExtractDataExcel.token_for_reg);
                  driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TYPE_TRUEFALSE_VALUE_0")).Click();
                  driverobj.GetElement(btn_create).ClickWithSpace();
                  driverobj.WaitForElement(lbl_success);
                  driverobj.WaitForElement(btn_return);
                  driverobj.GetElement(btn_return).ClickWithSpace();
                  result = true;
              }
              catch (Exception ex)
              {

                  ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Populate New Question for Test", driverobj);
              }

              return result;
          }
          private By txt_question_title = By.Id("TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE");
          private By btn_create = By.Id("ML.BASE.BTN.Create");
          private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
          //private By lnk_editstructure = By.XPath("//a[contains(.,'Edit Structure')]");
         private By btn_return = By.Id("Return");
    }
}
