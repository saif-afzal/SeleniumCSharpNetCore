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
    class MergeUsers
    {
        private readonly IWebDriver driverobj;

        public MergeUsers(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Populate_primaryusers(string firstname,string lastname,string userid)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txtprimaryfirstname);
                driverobj.GetElement(txtprimaryfirstname).Clear();
                driverobj.GetElement(txtprimaryfirstname).SendKeysWithSpace(firstname);
                driverobj.GetElement(txtprimarylastname).Clear();
                driverobj.GetElement(txtprimarylastname).SendKeysWithSpace(lastname);
                driverobj.GetElement(txtprimaryuserid).Clear();
                driverobj.GetElement(txtprimaryuserid).SendKeysWithSpace(userid);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Populate_secondryusers(string firstname, string lastname, string userid)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txtsecondryfirstname);
                driverobj.GetElement(txtsecondryfirstname).Clear();
                driverobj.GetElement(txtsecondryfirstname).SendKeysWithSpace(firstname);
                driverobj.GetElement(txtsecondrylastname).Clear();
                driverobj.GetElement(txtsecondrylastname).SendKeysWithSpace(lastname);
                driverobj.GetElement(txtsecondryuserid).Clear();
                driverobj.GetElement(txtsecondryuserid).SendKeysWithSpace(userid);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_SearchPrimaryUser()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_search_primary);
                driverobj.GetElement(btn_search_primary).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_Searchsecondryuser()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_search_secondry);
                driverobj.GetElement(btn_search_secondry).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_PrimaryUser()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(rb_primaryuser);
               // driverobj.GetElement(rb_primaryuser).ClickWithSpace();
                driverobj.ClickEleJs(rb_primaryuser);
                driverobj.GetElement(btn_selectprimaryuser).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_secondryUser()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(rb_secondryuser);
              //  driverobj.GetElement(rb_secondryuser).ClickWithSpace();
                driverobj.ClickEleJs(rb_secondryuser);
                driverobj.GetElement(btn_selectsecondryuser).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_MergeUser()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_reason);
                driverobj.GetElement(txt_reason).Clear();
                driverobj.GetElement(txt_reason).SendKeysWithSpace("test");
                driverobj.GetElement(btn_mergeuser).ClickWithSpace();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_success);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
       
        private By txtprimarylastname = By.Id("TabMenu_ML_BASE_TAB_MergeUsers_USR_LAST_NAME");
        private By txtprimaryfirstname = By.Id("TabMenu_ML_BASE_TAB_MergeUsers_USR_FIRST_NAME");
        private By txtprimaryuserid = By.Id("TabMenu_ML_BASE_TAB_MergeUsers_USR_LOGIN_ID");
        private By btn_search_primary = By.Id("TabMenu_ML_BASE_TAB_MergeUsers_ML.BASE.BTN.Search");
        private By rb_primaryuser = By.XPath(".//*[starts-with(@id,'TabMenu_ML_BASE_TAB_MergeUsers_PRIMARY_USER_1_MERGE_USERS_PRIMARY_1_0_')]");
        private By btn_selectprimaryuser = By.Id("TabMenu_ML_BASE_TAB_MergeUsers_ML.BASE.BTN.SelectPrimaryAccount");
        private By txtsecondrylastname = By.Id("TabMenu_ML_BASE_TAB_SelectSecondaryAccount_USR_LAST_NAME");
        private By txtsecondryfirstname = By.Id("TabMenu_ML_BASE_TAB_SelectSecondaryAccount_USR_FIRST_NAME");
        private By txtsecondryuserid = By.Id("TabMenu_ML_BASE_TAB_SelectSecondaryAccount_USR_LOGIN_ID");
        private By btn_search_secondry = By.Id("TabMenu_ML_BASE_TAB_SelectSecondaryAccount_ML.BASE.BTN.Search");
        private By rb_secondryuser = By.XPath(".//*[starts-with(@id,'TabMenu_ML_BASE_TAB_SelectSecondaryAccount_SECONDARY_USER_1_MERGE_USERS_SECONDARY_1_0_')]");
        private By btn_selectsecondryuser = By.Id("TabMenu_ML_BASE_TAB_SelectSecondaryAccount_ML.BASE.BTN.SelectSecondaryAccount");
        private By txt_reason = By.Id("TabMenu_ML_BASE_TAB_ReviewAccountMerge_MERGE_USER_REASON");
        private By btn_mergeuser = By.Id("TabMenu_ML_BASE_TAB_ReviewAccountMerge_SubmitMergeUser");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
    }
}
