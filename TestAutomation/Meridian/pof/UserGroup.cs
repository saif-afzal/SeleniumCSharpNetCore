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
    class UserGroup
    {
        private readonly IWebDriver driverobj;

        public UserGroup(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_GoToCreateGroup()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_GoToCreateGroup);
            //    driverobj.GetElement(btn_GoToCreateGroup).ClickWithSpace();
                driverobj.ClickEleJs(btn_GoToCreateGroup);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create User Group", driverobj);
            }

            return result;
        }

        public bool Populate_UserGroup()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_title).Clear();
                driverobj.GetElement(txt_title).SendKeysWithSpace("usergroup_" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(txt_desc).Clear();
                driverobj.GetElement(txt_desc).SendKeysWithSpace("usergroup_" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(txt_keyword).Clear();
                driverobj.GetElement(txt_keyword).SendKeysWithSpace("usergroup_" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }


        public bool Click_SearchUserGroup()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_search_for);
                driverobj.GetElement(txt_search_for).Clear();
                driverobj.GetElement(txt_search_for).SendKeysWithSpace("usergroup_" + ExtractDataExcel.token_for_reg);
                driverobj.ClickEleJs(btn_search);
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + "usergroup_" + ExtractDataExcel.token_for_reg + "')]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_AdvSearchUserGroup()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lnk_advsearch);
             //   driverobj.GetElement(lnk_advsearch).ClickAnchor();
                driverobj.ClickEleJs(lnk_advsearch);
                driverobj.WaitForElement(txt_search_title);
                driverobj.GetElement(txt_search_title).Clear();
                driverobj.GetElement(txt_search_title).SendKeysWithSpace("usergroup_" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(txt_search_desc).Clear();
                driverobj.GetElement(txt_search_desc).SendKeysWithSpace("usergroup_" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(txt_search_keyword).Clear();
                driverobj.GetElement(txt_search_keyword).SendKeysWithSpace("usergroup_" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(btn_search).ClickWithSpace();

                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + "usergroup_" + ExtractDataExcel.token_for_reg + "')]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_GoToManage()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_GoToManage);
                driverobj.ClickEleJs(btn_GoToManage);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_CriteriaTab()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(tab_criteria);
                driverobj.ClickEleJs(tab_criteria);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_AddCriteriaSet()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addcriteriaset);
                driverobj.GetElement(btn_addcriteriaset).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_SetCriteria()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_criteriatitle);
                driverobj.GetElement(txt_criteriatitle).SendKeysWithSpace("reg_criteria_"+ExtractDataExcel.token_for_reg);
                driverobj.GetElement(lnk_employinfo).ClickWithSpace();
                driverobj.WaitForElement(chk_empfirst);
             //   driverobj.GetElement(chk_empfirst).ClickWithSpace() ;
                driverobj.ClickEleJs(chk_empfirst);
                driverobj.GetElement(lnk_professionalinfo).ClickWithSpace();
                driverobj.WaitForElement(chk_employinfomanager);
              //  driverobj.GetElement(chk_employinfomanager).ClickWithSpace();
                driverobj.ClickEleJs(chk_employinfomanager);
                //driverobj.GetElement(lnk_customfield).ClickWithSpace();
                //driverobj.WaitForElement(chk_customfieldfirst);
                //driverobj.GetElement(chk_customfieldfirst).ClickWithSpace();
               // driverobj.GetElement(rb_allcriteria).ClickWithSpace();
                driverobj.ClickEleJs(rb_allcriteria);
                driverobj.GetElement(btn_addremovecriteria).ClickWithSpace();
                driverobj.WaitForElement(txt_criteriafirstname);
                driverobj.GetElement(txt_criteriafirstname).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Id"]);
                driverobj.FindSelectElementnew(cmb_ismanager, "No");
                //driverobj.FindSelectElementnew(cmb_customfieldfirst, "Is Empty");
                //driverobj.GetElement(txt_customfieldfirst).SendKeysWithSpace("No");
                driverobj.GetElement(btn_savecriteria).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_TabAssignUser()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(tab_assigneduser);
             //   driverobj.GetElement(tab_assigneduser).ClickWithSpace();
                driverobj.ClickEleJs(tab_assigneduser);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Verify_nouser()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(lbl_nouser);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        string originalHandle = string.Empty;
        public bool Click_PreviewUser()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_previewusers);
                originalHandle = driverobj.CurrentWindowHandle;
                driverobj.ClickEleJs(btn_previewusers);
                Thread.Sleep(5000);
                driverobj.selectWindow("Preview Users");
                Thread.Sleep(4000);
              
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool GetUserInPreview()
        {
            bool result = false;

            try
            {

                Thread.Sleep(2000);
                driverobj.WaitForElement(lbl_username);

                driverobj.SelectWindowClose2("Preview Users", "User Groups");

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_AssignUserToGroup()
        {
            bool result = false;

            try
            {

                Thread.Sleep(2000);
                driverobj.WaitForElement(btn_assignusertogroup);
            //    driverobj.GetElement(btn_assignusertogroup).ClickWithSpace();
                driverobj.ClickEleJs(btn_assignusertogroup);
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_success);
                driverobj.ClickEleJs(btn_previewclose);
                Thread.Sleep(5000);
                driverobj.SwitchTo().Window(originalHandle);
            result = driverobj.existsElement(lbl_username);
           
               
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_EditCriteria()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_editcriteria);
                driverobj.GetElement(btn_editcriteria).ClickWithSpace();
                //driverobj.findandacceptalert();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }


        public bool Click_AddRemoveCriteria()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addremovecriteria);
                driverobj.GetElement(lnk_employinfo).ClickWithSpace();
                driverobj.WaitForElement(chk_empfirst);
               // driverobj.GetElement(chk_empfirst).ClickWithSpace();
                driverobj.ClickEleJs(chk_empfirst);
                driverobj.GetElement(lnk_professionalinfo).ClickWithSpace();
                driverobj.WaitForElement(chk_employinfomanager);
               // driverobj.GetElement(chk_employinfomanager).ClickWithSpace();
                driverobj.ClickEleJs(chk_employinfomanager);
                //driverobj.GetElement(lnk_customfield).ClickWithSpace();
                //driverobj.WaitForElement(chk_customfieldfirst);
                //driverobj.GetElement(chk_customfieldfirst).ClickWithSpace();
               // driverobj.GetElement(rb_allcriteria).ClickWithSpace();
                driverobj.ClickEleJs(rb_allcriteria);
                driverobj.GetElement(btn_addremovecriteria).ClickWithSpace();
                driverobj.GetElement(btn_savecriteria).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool GetUserInCriteria()
        {
            bool result = false;

            try
            {


                driverobj.WaitForElement(lbl_username);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        private By btn_GoToCreateGroup = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_title = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNTLCL_TITLE");
        private By txt_desc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNTLCL_DESCRIPTION");
        private By txt_keyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNTLCL_KEYWORDS");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");


        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_search_title = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE");
        private By txt_search_desc = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION");
        private By txt_search_keyword = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");

        private By txt_search_for = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");

        private By btn_GoToManage = By.Id("TabMenu_ML_BASE_TAB_Search_CONTENT1_GoButton_1");
        private By tab_criteria = By.XPath("//span[contains(.,'Criteria')]");
        private By btn_addcriteriaset = By.Id("TabMenu_ML_BASE_LBL_EditCriteria_btnAddCriteriaSet");

        private By lnk_employinfo = By.XPath("//span[contains(.,'Employee Information')]");
        private By lnk_professionalinfo = By.XPath("//span[contains(.,'Professional Information')]");
        //private By lnk_customfield = By.XPath("//span[contains(.,'Custom Fields')]");
        private By chk_empfirst = By.Id("TabMenu_ML_BASE_LBL_EditCriteriaSet_FormElementList_i0_i0_DynamicFormElement_ML.BASE.ELEMENTTEMPLATE.UserFirstName");
        private By chk_employinfomanager = By.Id("TabMenu_ML_BASE_LBL_EditCriteriaSet_FormElementList_i1_i0_DynamicFormElement_ML.BASE.ELEMENTTEMPLATE.IsManagerEntity");
       // private By chk_customfieldfirst = By.XPath(".//*[starts-with(@id,'TabMenu_ML_BASE_LBL_EditCriteriaSet_FormElementList_i3_i0_DynamicFormElement_ML.BASE.ELMTPLT.')]");
        private By txt_criteriatitle = By.Id("TabMenu_ML_BASE_LBL_EditCriteriaSet_UGCG_GROUP_TITLE");
        private By rb_allcriteria = By.Id("TabMenu_ML_BASE_LBL_EditCriteriaSet_UGCG_OPERATOR_0");
        private By btn_savecriteria = By.Id("TabMenu_ML_BASE_LBL_EditCriteriaSet_SaveUserGroupParamters");
        private By btn_addremovecriteria = By.Id("TabMenu_ML_BASE_LBL_EditCriteriaSet_ApplyAddFormElementButton1");
        private By txt_criteriafirstname = By.Id("TabMenu_ML_BASE_LBL_EditCriteriaSet_USR_FIRST_NAME");
        private By cmb_ismanager = By.Id("TabMenu_ML_BASE_LBL_EditCriteriaSet_USR_IS_MANAGER");
      //  private By cmb_customfieldfirst = By.XPath(".//*[starts-with(@id,'TabMenu_ML_BASE_LBL_EditCriteriaSet_USRX_')]");
        //private By txt_customfieldfirst = By.XPath(".//*[starts-with(@id,'TabMenu_ML_BASE_LBL_EditCriteriaSet_USRX_')]");

        private By tab_assigneduser = By.XPath("//span[contains(.,'Assigned Users')]");
        private By lbl_nouser = By.XPath("//span[contains(.,'There are no assigned users because there are no users who match the current criteria.')]");
        private By btn_previewusers = By.Id("TabMenu_ML_BASE_LBL_CurrentAssignedUsers_ML.BASE.BTN.Preview");
        private By lbl_username = By.XPath("//td[contains(.,'regadmin')]");
        private By btn_assignusertogroup = By.Id("TabMenu_ML_BASE_LBL_PreviewUsers_btnAssignUsers");
        private By btn_previewclose = By.Id("TabMenu_ML_BASE_LBL_PreviewUsers_btnClose");
        private By btn_editcriteria =By.XPath("//img[@src='/Skins/Graphics/task_status_edit.png']");
        



    }
}
