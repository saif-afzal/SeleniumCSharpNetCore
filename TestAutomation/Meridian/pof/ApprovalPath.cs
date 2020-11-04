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
    class ApprovalPath
    {
        private readonly IWebDriver driverobj;
        public ApprovalPath(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_CreateNewGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_creategoto);
                driverobj.WaitForElement(cmb_create);
                driverobj.ClickEleJs(btn_creategoto);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
               
            }
            return actualresult;
        }
        public bool Select_Administrators(int i = 0)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_item);
                if (i != 0)
                {
                    driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl02_DataGridItem_Id"));
                    driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl03_DataGridItem_Id"));
                    driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl08_DataGridItem_Id"));
                }
                else
                {
                    driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl03_DataGridItem_Id"));
                }
                //  driverobj.GetElement(chk_item).ClickWithSpace();
                driverobj.ClickEleJs(btn_addselected);
                driverobj.WaitForElement(By.XPath("//td[contains(.,'Administrators')]"));
                actualresult = true;
            }
            catch (Exception e)
            {
                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
              
            }
            return actualresult;
        }
        public bool Populate_AdministrativeApproval(string title)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createtitle);
                driverobj.GetElement(txt_createtitle).SendKeysWithSpace(title);
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_approver["Desc"]);

                driverobj.WaitForElement(btn_create);
                driverobj.ClickEleJs(btn_create);
                driverobj.WaitForElement(lbl_success);
                actualresult = true;
            }
            catch (Exception e)
            {
                driverobj.CaptureScreenshotandLog(this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name, e.Message, e.StackTrace);
              
            }
            return actualresult;
        }
        public bool Click_Create(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_title).Clear();
                driverobj.GetElement(txt_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_approver["Title"]+browserstr + type);
                driverobj.WaitForElement(txt_desc);
                driverobj.GetElement(txt_desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_approver["Desc"] + type);
                driverobj.WaitForElement(cmb_type);
                driverobj.ClickEleJs(btn_create);
               actualresult = driverobj.existsElement(lbl_success);

                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }
            return actualresult;
        }
        public bool Click_AddApproval()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_approval);
               // driverobj.GetElement(chk_approval).ClickWithSpace();
                driverobj.ClickEleJs(chk_approval);
                driverobj.ClickEleJs(btn_addselected);
               actualresult = driverobj.existsElement(lbl_success);

              
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }
            return actualresult;
        }
        public bool Click_Search(string type, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_approver["Title"]+browserstr + type);
                
             //   driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.ClickEleJs(btn_search);
               actualresult = driverobj.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_approver["Title"]+browserstr + type + "')]"));
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }
            return actualresult;
        }
        public bool Click_ManageGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_creategoto);
                //driverobj.FindElement(btn_creategoto).SendKeys("");
                driverobj.WaitForElement(btn_managegoto);
                driverobj.ClickEleJs(btn_managegoto);
             //if(driverobj.existsElement(btn_managegoto))
             //{
             //    driverobj.ClickEleJs(btn_managegoto);
             //}
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);

            }
            return actualresult;
        }

        public bool Click_Approvertab()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(tab_approvalstage);
              //  driverobj.GetElement(tab_approvalstage).ClickWithSpace();
                driverobj.ClickEleJs(tab_approvalstage);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        private By chk_item = By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl03_DataGridItem_Id");
        private By cmb_create = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.TAB.AccesApprovalPathSimpleSearch");
        private By btn_creategoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_title = By.Id("TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_TITLE");
        private By txt_desc = By.Id("TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_DESCRIPTION");
        private By cmb_type = By.Id("TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_PATH_TYPE_ID");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By chk_approval = By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_AvailableApproversList_ctl02_DataGridItem_Id");
        private By btn_addselected = By.Id("TabMenu_ML_BASE_TAB_EditApproversStages_ML.BASE.BTN.AddSelected");
        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By cmb_searchtype = By.Id("TabMenu_ML_BASE_TAB_Search_SearchType");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By btn_managegoto = By.Id("TabMenu_ML_BASE_TAB_Search_ApprovalPathSearch_ctl02_GoButton");
        public static By tab_approvalstage = By.Id("ML.BASE.WF.EditStage");
        private By txt_createtitle = By.Id("TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_TITLE");
        private By txt_createdesc = By.Id("TabMenu_ML_BASE_TAB_EditAccessApprovalPath_APP_DESCRIPTION");
        
    }
}
