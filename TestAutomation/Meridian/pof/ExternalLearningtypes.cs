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
    class ExternalLearningtypes
    {
        private readonly IWebDriver driverobj;
        public ExternalLearningtypes(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_CreateNewGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_createnewgoto);
            //    driverobj.GetElement(btn_createnewgoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_createnewgoto);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Populate_ExternalLearning(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createtitle);
                driverobj.GetElement(txt_createtitle).Clear();
                driverobj.GetElement(txt_createtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_ELType["Title"]+browserstr);
                driverobj.GetElement(txt_createdesc).Clear();
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_ELType["Desc"]);

                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                driverobj.WaitForElement(btn_save);
                driverobj.GetElement(btn_save).ClickWithSpace();
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
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_ELType["Title"]+browserstr);
                driverobj.ClickEleJs(btn_search);
                Thread.Sleep(2000);
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_ELType["Title"]+browserstr + "')]"));
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
                Thread.Sleep(3000);
                driverobj.GetElement(txt_searchtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_ELType["Title"]+browserstr);
                driverobj.GetElement(txt_searchdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_ELType["Desc"]);
                driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_ELType["Title"]+browserstr + "')]"));

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Edit_ELType()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createdesc);

                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_ELType["Desc"]+"Edit");
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_ManageItem()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_manageitem);
                driverobj.ClickEleJs(btn_manageitem);
                driverobj.WaitForElement(txt_createdesc);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_SelectELType()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_itemtodelete);
                //driverobj.GetElement(chk_itemtodelete).ClickWithSpace();
                driverobj.ClickEleJs(chk_itemtodelete);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_DeleteELType()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_delete);
                driverobj.ClickEleJs(btn_delete);
                driverobj.findandacceptalert();
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
        private By txt_createtitle = By.Id("TabMenu_ML_BASE_TAB_EditExternalLearningType_ELTL_TYPE_TITLE");
        private By txt_createdesc = By.Id("TabMenu_ML_BASE_TAB_EditExternalLearningType_ELTL_TYPE_DESC");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_manageitem = By.Id("TabMenu_ML_BASE_TAB_Search_ExternalLearningType_GoButton_1");

        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_searchtitle = By.Id("TabMenu_ML_BASE_TAB_Search_CS_TITLE");
        private By txt_searchdesc = By.Id("TabMenu_ML_BASE_TAB_Search_CS_DESCRIPTION");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");

        private By txt_previewurl = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL");
        private By btn_save = By.Id("ML.BASE.BTN.Save");

        private By chk_itemtodelete = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_DeleteExternalLearningType_1_ExternalLearningType_1_0_')]");
        private By btn_delete = By.Id("TabMenu_ML_BASE_TAB_Search_Delete");
    }
}
