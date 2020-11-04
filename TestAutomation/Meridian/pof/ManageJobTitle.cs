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
    class ManageJobTitle
    {
        private readonly IWebDriver driverobj;
        public ManageJobTitle(IWebDriver driver)
        {
            driverobj = driver;
        }
    
        public bool Populate_JobTitle(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createtitle);
                driverobj.GetElement(txt_createtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_JobTitle["Name"]+browserstr);
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_JobTitle["Desc"]);
                driverobj.GetElement(txt_createkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_JobTitle["Desc"]);
                driverobj.GetElement(txt_createjobcode).SendKeysWithSpace(ExtractDataExcel.MasterDic_JobTitle["Name"]+browserstr);
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Populate job Title", driverobj);
            }
            return actualresult;
        }
     

        public bool Click_evalutionTab()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(tab_evalution);
                driverobj.ClickEleJs(tab_evalution);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public bool Click_Searchevalution()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_searchevalution);
                driverobj.WaitForElement(btn_searchevalution);
                driverobj.ClickEleJs(btn_searchevalution);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool Click_Selectevalutiontoadd()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_selectevalution);
             //   driverobj.GetElement(chk_selectevalution).Click();
                driverobj.ClickEleJs(chk_selectevalution);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public bool Click_Selectevalution()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_selectevalution);
                driverobj.ClickEleJs(btn_selectevalution);
                driverobj.WaitForElement(lbl_success);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool Click_Save()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_save);
                driverobj.ClickEleJs(btn_save);
                driverobj.WaitForElement(lbl_success);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        private By txt_createtitle = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_JBTTLLCL_TITLE");
        private By txt_createdesc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_JBTTLLCL_DESCRIPTION");
        private By txt_createkeyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_JBTTLLCL_KEYWORDS");
        private By txt_createjobcode = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_JBTTLLCL_JOB_CODE");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
       
        private By btn_save = By.Id("ML.BASE.BTN.Save");

        private By tab_evalution = By.XPath("//span[contains(.,'Evaluation')]");

        private By txt_searchevalution = By.Id("TabMenu_ML_BASE_TAB_SelectEvaluation_SearchFor");
        private By btn_searchevalution = By.Id("TabMenu_ML_BASE_TAB_SelectEvaluation_SearchTemplates");
        private By chk_selectevalution = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_SelectEvaluation_SELECTTEMPLATE_1_EVAL_TEMPLATE_1_0_')]");
        private By btn_selectevalution = By.Id("TabMenu_ML_BASE_TAB_SelectEvaluation_Select");
        
    }
}
