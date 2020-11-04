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
    class ExternalLearnings
    {
        private readonly IWebDriver driverobj;
        public ExternalLearnings(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_CreateNewGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_createnewgoto);
             //  driverobj.GetElement(btn_createnewgoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_createnewgoto);
                driverobj.WaitForElement(txt_createtitle);


                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Populate_ExternalLearning(string typeofel, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createtitle);
                driverobj.GetElement(txt_createtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_EL["Title"]+browserstr+typeofel);
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_EL["Desc"]);
                driverobj.GetElement(txt_createkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_EL["Desc"]);
                driverobj.getcomboitemselected(cmb_createtype,1);
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_Search(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_EL["Title"]+browserstr);
                driverobj.ClickEleJs(btn_search);
                driverobj.WaitForElement(lnk_elsearcheditem);
                driverobj.ClickEleJs(lnk_elsearcheditem);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_AdvSearch(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_advsearch);
             //   driverobj.GetElement(lnk_advsearch).ClickAnchor();
                driverobj.ClickEleJs(lnk_advsearch);
                Thread.Sleep(1000);
                driverobj.GetElement(txt_searchtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_EL["Title"]+browserstr);
                driverobj.GetElement(txt_searchdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_EL["Desc"]);
                driverobj.GetElement(txt_searchkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_EL["Desc"]);
                driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.WaitForElement(lnk_elsearcheditem);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Edit_EL()
        {
            bool actualresult = false;
            try
            {
                //driverobj.WaitForElement(txt_previewurl);

                //driverobj.GetElement(txt_previewurl).SendKeysWithSpace("www.google.com");
                driverobj.WaitForElement(btn_save);
                driverobj.ClickEleJs(btn_save);
                driverobj.WaitForElement(lbl_success);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        private By btn_createnewgoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_createtitle = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_EXT_TITLE");
        private By txt_createdesc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_EXT_DESCRIPTION");
        private By txt_createkeyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_EXT_KEYWORDS");
        private By cmb_createtype = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_EXT_LEARNING_TYPE_ID");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By lnk_elsearcheditem=By.XPath("//a[contains(@id,'TabMenu_ML_BASE_TAB_Search_ID1_CONTENT1_1_0_')]");

        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_searchtitle = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE");
        private By txt_searchdesc = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION");
        private By txt_searchkeyword = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");

        private By txt_previewurl = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
    }
}
