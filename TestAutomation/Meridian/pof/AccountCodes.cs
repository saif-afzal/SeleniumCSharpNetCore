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
    class AccountCodes
    {
        private readonly IWebDriver driverobj;
        public AccountCodes(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_CreateNewGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_createnewgoto);
             //   driverobj.GetElement(btn_createnewgoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_createnewgoto);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Create on Button GoTo for Creating new Account Codes", driverobj);
            }
            return actualresult;
        }

        public bool Populate_AccountCode(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createtitle);
                driverobj.GetElement(txt_createtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCode["Name"]+browserstr);
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCode["Desc"] );
                driverobj.GetElement(txt_createkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCode["Desc"] );
                driverobj.GetElement(txt_createaccno).SendKeysWithSpace(ExtractDataExcel.token_for_reg+browserstr );
                driverobj.FindSelectElementnew(cmb_createacctype, "Credit");
                driverobj.FindSelectElementnew(cmb_createacccodetype, "Department");
               // driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.ClickEleJs(btn_create);
                driverobj.WaitForElement(lbl_success);
                driverobj.WaitForElement(txt_acclimit);
                driverobj.GetElement(txt_acclimit).Clear();
                driverobj.GetElement(txt_acclimit).SendKeysWithSpace("100");
                driverobj.GetElement(txt_purchaselimit).Clear();
                driverobj.GetElement(txt_purchaselimit).SendKeysWithSpace("50");
                driverobj.GetElement(txt_comment).SendKeysWithSpace("test");
                driverobj.WaitForElement(btn_fundsave);
               // driverobj.GetElement(btn_fundsave).ClickWithSpace();
                driverobj.ClickEleJs(btn_fundsave);
               actualresult = driverobj.existsElement(lbl_success);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Populate Account Codes Deatail while Creating", driverobj);
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
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCode["Name"]+browserstr);
                //driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.ClickEleJs(btn_search);
               actualresult = driverobj.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_AccountCode["Name"]+browserstr + "')]"));
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to General Search for Account Codes", driverobj);
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
                driverobj.WaitForElement(txt_searchtitle);
                driverobj.GetElement(txt_searchtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCode["Name"]+browserstr);
                driverobj.GetElement(txt_searchdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCode["Desc"]);
                driverobj.GetElement(txt_searchkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCode["Desc"]);
              //  driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.ClickEleJs(btn_search);
               actualresult = driverobj.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_AccountCode["Name"]+browserstr + "')]"));

                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to do Advance Search for Account Codes", driverobj);
            }
            return actualresult;
        }

        public bool Edit_AccountCodes()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createdesc);

                driverobj.GetElement(txt_contactinfo).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCode["Desc"]);
                driverobj.GetElement(btn_save).ClickWithSpace();
               actualresult = driverobj.existsElement(lbl_success);

                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Edit Desc Field of Account Codes", driverobj);
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
              actualresult =  driverobj.existsElement(txt_createdesc);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button for GoTo Manage for Account Codes", driverobj);
            }
            return actualresult;
        }

        public bool Click_InformationIcon(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(img_infoicon);
                
           //     string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.ClickEleJs(img_infoicon);
                
                driverobj.selectWindow("Account Codes");
                Thread.Sleep(4000);
                driverobj.WaitForElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Summary_FIELD:AC_ACCT_CODE_TITLE']"));
                if (!driverobj.GetElement(By.XPath(".//*[@id='TabMenu_ML_BASE_TAB_Summary_FIELD:AC_ACCT_CODE_TITLE']")).Text.Contains(ExtractDataExcel.MasterDic_AccountCode["Name"]+browserstr))
                {
                    result = true;
                }

                //  SurveyUtilDriver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure" + "')]"));
                Thread.Sleep(3000);
                driverobj.SelectWindowClose2("Account Codes", Meridian_Common.parentwdw);

                Thread.Sleep(3000);
             


                result = true;
            }
            catch(Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Information Icon for Account Codes", driverobj);
            }


            return result;
        }
        public bool Click_ContentTab()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(tab_content);
              //  driverobj.GetElement(tab_content).ClickWithSpace();
                driverobj.ClickEleJs(tab_content);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Content Tab for Account Codes", driverobj);
            }
            return actualresult;
        }
        public bool Click_AddContentGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_addcontentGoTo);
                driverobj.GetElement(btn_addcontentGoTo).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button Add Content on Account Codes", driverobj);
            }
            return actualresult;
        }
        public bool Click_SearchContent()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_addcontentsearch);
                driverobj.GetElement(btn_addcontentsearch).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Search Content to be added to Account Codes", driverobj);
            }
            return actualresult;
        }

        public bool Click_SelectAccountCodetoAddContent()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_addcontent);
               // driverobj.GetElement(chk_addcontent).ClickWithSpace();
                driverobj.ClickEleJs(chk_addcontent);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "No Content found to be added to Account Codes", driverobj);
            }
            return actualresult;
        }
        public bool Click_AddContent()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_addcontent);
                driverobj.GetElement(btn_addcontent).ClickWithSpace();
                driverobj.findandacceptalert();
               actualresult = driverobj.existsElement(lbl_success);
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "No Content found for adding in Account Codes", driverobj);
            }
            return actualresult;
        }

      

        private By btn_createnewgoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_createtitle = By.Id("TabMenu_ML_BASE_TAB_EditAccountCode_AC_ACCT_CODE_TITLE");
        private By txt_createdesc = By.Id("TabMenu_ML_BASE_TAB_EditAccountCode_AC_ACCT_CODE_DESC");
        private By txt_createkeyword = By.Id("TabMenu_ML_BASE_TAB_EditAccountCode_AC_ACCT_CODE_KEYWORDS");
        private By txt_createaccno = By.Id("TabMenu_ML_BASE_TAB_EditAccountCode_AC_ACCT_NUMBER");
        private By cmb_createacctype = By.Id("TabMenu_ML_BASE_TAB_EditAccountCode_AC_ACCT_TYPE");
        private By cmb_createacccodetype = By.Id("TabMenu_ML_BASE_TAB_EditAccountCode_AC_ACCT_CODE_TYPE_ID");
        private By btn_create = By.Id("ML.BASE.BTN.Create");

        private By txt_acclimit = By.Id("TabMenu_ML_BASE_TAB_Funds_AC_ACCT_CREDIT_LIMIT");
        private By txt_purchaselimit = By.Id("TabMenu_ML_BASE_TAB_Funds_AC_ACCT_PURCH_LIMIT");
        private By txt_comment = By.Id("TabMenu_ML_BASE_TAB_Funds_AddFundsComment");
        private By btn_fundsave = By.Id("TabMenu_ML_BASE_TAB_Funds_ML.BASE.BTN.Save");

        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_manageitem = By.Id("TabMenu_ML_BASE_TAB_Search_ACCT_CODE_GoButton_1");

        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_searchtitle = By.Id("TabMenu_ML_BASE_TAB_Search_CS_TITLE");
        private By txt_searchdesc = By.Id("TabMenu_ML_BASE_TAB_Search_CS_DESCRIPTION");
        private By txt_searchkeyword = By.Id("TabMenu_ML_BASE_TAB_Search_CS_KEYWORDS");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");

        private By txt_contactinfo = By.Id("TabMenu_ML_BASE_TAB_EditAccountCode_AC_ACCT_CONTACT");
        private By btn_save = By.Id("ML.BASE.BTN.Save");

        private By img_infoicon = By.XPath("//img[@ src='/Skins/BaseTopMenu/Icons/en-US/ViewInfoIcon.png']");
            //By.XPath("//img[contains(@id,'_1_ACCT_CODE_1_InfoIcon')]");
        private By lbl_mainheading = By.Id("MainHeading");


         private By tab_content = By.XPath("//span[contains(.,'Content')]");
         private By btn_addcontentGoTo = By.Id("TabMenu_ML_BASE_TAB_EditContent_GoPageActionsMenu");
         private By txt_addcontentsearch = By.Id("TabMenu_ML_BASE_TAB_AddContent_SearchFor");
         private By btn_addcontentsearch = By.Id("TabMenu_ML_BASE_TAB_AddContent_ML.BASE.BTN.Search");
         private By chk_addcontent = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_AddContent_AddContent_1_ACCT_CODE_ADD_CONTENT_1_0_')]");
         private By btn_addcontent = By.Id("TabMenu_ML_BASE_TAB_AddContent_AssignContent");

    }
}
