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
   public class Role
    {
        private readonly IWebDriver driverobj;

        public Role(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_Search(string searchtext)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(searchtext);
                driverobj.GetElement(btn_search).ClickWithSpace();

                
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool count_Record(string searchtext)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(tbl_roles);
                int noofrecords = driverobj.FindElements(tr_roles).Count;
              for (int i = 2; i <= noofrecords; i++)
              {
                  string test = driverobj.GetElement(By.XPath("//table[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch']/tbody/tr[" + i + "]/td[3]")).Text;
                  if (driverobj.GetElement(By.XPath("//table[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch']/tbody/tr[" + i + "]/td[3]")).Text.Contains(searchtext))
                  {
                      return true;
                  }
              }
              driverobj.GetElement(lbl_recordfound).Text.Contains("Records found:" + Convert.ToString( noofrecords - 1) + "");
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_EditUserGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_editusergoto);
                driverobj.GetElement(btn_editusergoto).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        public bool SelectAction(string sel)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_ActionsMenu"));
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_ActionsMenu"), "Edit Permissions");
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_AddUserGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_addusergoto);
                driverobj.GetElement(btn_addusergoto).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        public bool Click_SearchUserToAdd(string firstname)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_adduserfirstname);
                driverobj.GetElement(txt_adduserfirstname).SendKeysWithSpace(firstname);
                driverobj.GetElement(btn_searchusertoadd).ClickWithSpace();

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        
        public bool Click_AddUser()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(chk_adduser);
               // driverobj.GetElement(chk_adduser).ClickWithSpace();
             //   driverobj.ClickRB(chk_adduser);
                driverobj.ClickEleJs(chk_adduser);
                driverobj.WaitForElement(btn_adduser);
                driverobj.GetElement(btn_adduser).ClickWithSpace();
                driverobj.WaitForElement(lbl_sucess);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_AddUsertoorganization()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(chk_addusertoorg);
               // driverobj.GetElement(chk_addusertoorg).ClickWithSpace();
            //    driverobj.ClickRB(chk_addusertoorg);
                driverobj.ClickEleJs(chk_addusertoorg);
                driverobj.WaitForElement(btn_adduser);
                driverobj.GetElement(btn_adduser).ClickWithSpace();
                driverobj.WaitForElement(lbl_sucess);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_CreateNewRoleGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_createnewrolegoto);
           //     driverobj.GetElement(btn_createnewrolegoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_createnewrolegoto);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Click_CreateNewRole()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_createrolename);
                driverobj.GetElement(txt_createrolename).SendKeysWithSpace("role" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(txt_createroledesc).SendKeysWithSpace("role" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(btn_create_role).ClickWithSpace();
                driverobj.WaitForElement(lbl_sucess);
                driverobj.GetElement(btn_return).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }
        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By tbl_roles = By.Id("TabMenu_ML_BASE_TAB_Search_RoleSearch");
        private By tr_roles = By.XPath("//table[@id='TabMenu_ML_BASE_TAB_Search_RoleSearch']/tbody/tr");
        private By lbl_recordfound = By.Id("TabMenu_ML_BASE_TAB_Search_FeedbackRoleSearch");
        private By btn_editusergoto = By.Id("TabMenu_ML_BASE_TAB_Search_RoleSearch_ctl02_GoButton");
        private By btn_addusergoto = By.Id("TabMenu_ML_BASE_TAB_EditRole_GoPageActionsMenu");
        private By txt_adduserfirstname = By.Id("TabMenu_ML_BASE_TAB_AddUsers_USR_FIRST_NAME");
        private By btn_searchusertoadd = By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnSearch");
        private By chk_adduser = By.Id("TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl02_DataGridItem_PRM_ENTITY_NAME");
        private By chk_addusertoorg = By.Id("TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl03_DataGridItem_PRM_ENTITY_NAME");
        private By btn_adduser = By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnAdd");
        private By lbl_sucess = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_createnewrolegoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_createrolename = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_NAME");
        private By txt_createroledesc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_RLNMLCL_ROLE_DESCRIPTION");
        private By btn_create_role = By.Id("ML.BASE.BTN.Create");
        private By btn_return = By.Id("Return");
    }
}
