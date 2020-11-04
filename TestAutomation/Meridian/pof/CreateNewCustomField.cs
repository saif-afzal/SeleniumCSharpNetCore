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
    class CreateNewCustomField
    {
         private readonly IWebDriver driverobj;

         public CreateNewCustomField(IWebDriver driver)
        {
            driverobj = driver;
        }

         public bool Populate_NewCustomField()
         {
             bool result = false;

             try
             {
                 driverobj.WaitForElement(cmb_fieldtype);
                 driverobj.FindSelectElementnew(cmb_fieldtype, "Text Box");
                 driverobj.FindSelectElementnew(cmb_datatype, "String");
                 driverobj.GetElement(txt_fieldlable).Clear();
                 driverobj.GetElement(txt_fieldlable).SendKeys("custom_"+ExtractDataExcel.token_for_reg);
              //   driverobj.GetElement(chk_visible).Click();
                 driverobj.ClickEleJs(chk_visible);
               //  driverobj.GetElement(chk_inuse).Click();
                 driverobj.ClickEleJs(chk_inuse);
                // driverobj.GetElement(chk_searchable).Click();
                 driverobj.ClickEleJs(chk_searchable);
                 driverobj.GetElement(btn_createbtn).ClickWithSpace();
                 driverobj.findandacceptalert();
                 Thread.Sleep(5000);
               result =  driverobj.existsElement(lbl_success);
                 //driverobj.GetElement(btn_return).ClickWithSpace();
                
             }
             catch (Exception ex)
             {

                 ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
             }

             return result;
         }
         private By cmb_fieldtype = By.Id("TabMenu_ML_BASE_LBL_CreateNewCustomField_CUSTOM_FIELD_TYPE");
         private By cmb_datatype = By.Id("TabMenu_ML_BASE_LBL_CreateNewCustomField_CUSTOM_FIELD_DATA_TYPE");
         private By txt_fieldlable = By.Id("TabMenu_ML_BASE_LBL_CreateNewCustomField_CUSTOM_FIELD_LABEL");
         private By chk_visible = By.Id("TabMenu_ML_BASE_LBL_CreateNewCustomField_CUSTOM_FIELD_ATTRIBUTES_2");
         private By chk_inuse = By.Id("TabMenu_ML_BASE_LBL_CreateNewCustomField_CUSTOM_FIELD_ATTRIBUTES_3");
         private By chk_searchable = By.Id("TabMenu_ML_BASE_LBL_CreateNewCustomField_CUSTOM_FIELD_ATTRIBUTES_4");
         private By btn_createbtn = By.Id("primaryaction");
         private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
         private By btn_return = By.Id("Return");


    }
}
