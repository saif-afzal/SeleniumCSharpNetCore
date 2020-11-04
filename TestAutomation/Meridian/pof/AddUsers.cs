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
    class AddUsers
    {
        private readonly IWebDriver driverobj;
        public AddUsers(IWebDriver driver)
        {
            driverobj = driver;
        }



        public bool Click_SearchUser()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_addusersearch);
                driverobj.GetElement(txt_addusersearch).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Firstname"]);
                driverobj.ClickEleJs(btn_addusersearch);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool Click_SelectUserToAdd()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_adduser);
               // driverobj.GetElement(chk_adduser).Click();
                driverobj.ClickEleJs(chk_adduser);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public bool Click_AddUser()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_adduser);
                driverobj.ClickEleJs(btn_adduser);
               actualresult = driverobj.existsElement(lbl_success);
               
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        private By txt_addusersearch = By.Id("TabMenu_ML_BASE_HEAD_AddUsers_SearchRole");
        private By btn_addusersearch = By.Id("TabMenu_ML_BASE_HEAD_AddUsers_ML.BASE.BTN.Search");
        private By chk_adduser = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_HEAD_AddUsers_ENTITY_ID_1_ENTITY_LIST_1_0_')]");
        private By btn_adduser = By.Id("TabMenu_ML_BASE_HEAD_AddUsers_AssignTraining");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
      
    }
}
