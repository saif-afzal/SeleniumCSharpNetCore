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
    class EditUserGroup
    {
        private readonly IWebDriver driverobj;
        public EditUserGroup(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_DiscontCodeTypeItem()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_usergroupgoto);
                driverobj.GetElement(btn_usergroupgoto).ClickWithSpace();

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_SearchUser()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_username_search);
                driverobj.GetElement(txt_username_search).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Firstname"]);
                driverobj.GetElement(btn_searchuser).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_AddUser()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_adduser);
               // driverobj.GetElement(chk_adduser).Click();
                driverobj.ClickEleJs(chk_adduser);
                driverobj.GetElement(btn_adduser).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        private By btn_usergroupgoto = By.Id("TabMenu_ML_BASE_TAB_EditUsersOrUserGroup_GoPageActionsMenu");
        private By txt_username_search = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_SearchRole");
        private By btn_searchuser = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_ML.BASE.BTN.Search");
        private By chk_adduser = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_ENTITY_ID_1_ENTITY_LIST_1_0_')]");
        private By btn_adduser = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_AssignTraining");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
    }
}
