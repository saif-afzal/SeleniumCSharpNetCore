using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;
using Selenium2.Meridian;
using relativepath;
using System.Reflection;
using OpenQA.Selenium.Remote;

namespace TestAutomation.Meridian.Regression_Objects
{
    class CollabarationSpaceUtil
    {
        private readonly IWebDriver driverobj;
        public CollabarationSpaceUtil(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool CreateCollabarationSpace(string coltype,string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(adminconsoleopenlink).Click();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.WaitForElement(lnk_admin_col_space);
                driverobj.GetElement(lnk_admin_col_space).Click();
                driverobj.WaitForElement(btn_go_search_colspace);
                driverobj.GetElement(btn_go_search_colspace).Click();
                driverobj.WaitForElement(txt_create_title);
                driverobj.GetElement(txt_create_title).Clear();
                driverobj.GetElement(txt_create_title).SendKeys(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr.ToString() + coltype);
                driverobj.GetElement(txt_create_desc).Clear();
                driverobj.GetElement(txt_create_desc).SendKeys(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr.ToString() + coltype);
                driverobj.GetElement(txt_create_keyword).Clear();
                driverobj.GetElement(txt_create_keyword).SendKeys(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr.ToString() + coltype);
                driverobj.FindSelectElementnew(cmb_create_content_type, ExtractDataExcel.MasterDic_CSpace["Type"].ToString());
                driverobj.GetElement(btn_create).Click();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.GetElement(btn_save).Click();
                driverobj.WaitForElement(lbl_Create_Msg);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public void searchCollabarationSpace(string coltype, string browserstr)
        {
            try
            {
                Thread.Sleep(2000);
                driverobj.WaitForElement(txt_Searchtxt);
                driverobj.GetElement(txt_Searchtxt).Clear();
                driverobj.GetElement(txt_Searchtxt).SendKeys(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr.ToString() + coltype);
                driverobj.FindSelectElementnew(cmb_search, "Exact phrase");

                driverobj.GetElement(btn_search).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_CSpace["Title"] + browserstr.ToString() + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_CSpace["Title"] + browserstr.ToString() + "')]")).ClickAnchor();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
        }


        public bool JoinCollabarationSpace(string browserstr)
        {
            try
            {
                searchCollabarationSpace("mol", browserstr);
                driverobj.WaitForElement(btn_join_col_space);
                driverobj.GetElement(btn_join_col_space).Click();
                driverobj.WaitForElement(btn_openItem);
                //return driverobj.GetElement(ColSpaceSucessMsgDiv).Text;
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }
        }

        public bool ViewCollabarationSpaceDetailPage()
        {
            try
            {

                driverobj.GetElement(lnk_mol_col_space).Click();
                driverobj.WaitForElement(lnk_first_col_space_link);
                string CollabarationText = driverobj.GetElement(lnk_first_col_space_link).Text;
                driverobj.GetElement(lnk_first_col_space_link).Click();
                driverobj.WaitForElement(By.XPath("//h2[contains(text(),'" + CollabarationText + "')]"));

                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }
        }

        public string LeaveCollabarationSpace(string browserstr)
        {
            try
            {
                searchCollabarationSpace("mol", browserstr);
                driverobj.WaitForElement(btn_leave_col_space);
                driverobj.GetElement(btn_leave_col_space).Click();
                driverobj.WaitForElement(btn_join_col_space);
                driverobj.WaitForElement(lbl_sucess_msg);
                return driverobj.GetElement(lbl_sucess_msg).Text;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return "";
            }
        }

        public bool AccessCollabarationSpace()
        {
            try
            {

                driverobj.GetElement(lnk_mol_col_space).Click();
                driverobj.WaitForElement(lnk_first_col_space_link);
                string CollabarationText = driverobj.GetElement(lnk_first_col_space_link).Text;
                driverobj.GetElement(lnk_first_col_space_link).Click();
                driverobj.WaitForElement(By.XPath("//h2[contains(.,'" + CollabarationText + "')]"));

                return true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }
        }

        public bool colspaceAdvSearch(string colspacefor, string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_admin_col_space).Click();

                driverobj.GetElement(lnk_advance_search).ClickWithSpace();
                driverobj.WaitForElement(txt_search_title);
                driverobj.GetElement(txt_search_title).Clear();
                driverobj.GetElement(txt_search_title).SendKeys(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor);
                driverobj.GetElement(txt_search_desc).Clear();
                driverobj.GetElement(txt_search_desc).SendKeys(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor);
                driverobj.GetElement(txt_search_keyword).Clear();
                driverobj.GetElement(txt_search_keyword).SendKeys(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor);
                driverobj.FindSelectElementnew(cmb_search_col_space_type, ExtractDataExcel.MasterDic_CSpace["Type"]);
                driverobj.GetElement(btn_admin_search_col_space).Click();

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor + "')]"));
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public void colspacesearch(string colspacefor, string browserstr)
        {

            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_admin_col_space).Click();
                driverobj.WaitForElement(txt_search_for);
                driverobj.GetElement(txt_search_for).Clear();
                driverobj.GetElement(txt_search_for).SendKeys(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor);

                driverobj.GetElement(btn_admin_search_col_space).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor + "')]")).Click();


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }


        public bool colspacesimplesearch(string colspacefor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                colspacesearch(colspacefor, browserstr);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }


        public bool managecolspace(string colspacefor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                colspacesearch(colspacefor, browserstr);
                driverobj.WaitForElement(lnk_Manage);
                driverobj.GetElement(lnk_Manage).Click();

                driverobj.WaitForElement(txt_preview_url);
                driverobj.GetElement(txt_preview_url).SendKeys("www.google.com");
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        RelativeDirectory rd = new RelativeDirectory();
        public bool editcolspacelogo(string colspacefor, string browserstr)
        {
            bool actualresult = false;
            string path = rd.Up(2) + "\\Data\\test_image.jpg";
            try
            {
                colspacesearch(colspacefor, browserstr);
                driverobj.WaitForElement(lnk_Manage);
                driverobj.GetElement(lnk_Manage).Click();
                driverobj.WaitForElement(tab_edit_logo);
                driverobj.GetElement(tab_edit_logo).Click();
                Thread.Sleep(4000);
                driverobj.WaitForElement(ful_logo);
                IAllowsFileDetection allowsDetection = (IAllowsFileDetection)driverobj;
                if (allowsDetection != null)
                {
                    allowsDetection.FileDetector = new LocalFileDetector();

                }
                driverobj.GetElement(ful_logo).SendKeys(path);
                Thread.Sleep(6000);
                driverobj.GetElement(btn_save).Click();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.WaitForElement(lbl_logo_text);
                driverobj.WaitForElement(lnk_view_logo);

                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool colspacerole(string colspacefor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                colspacesearch(colspacefor, browserstr);
                driverobj.WaitForElement(lnk_Manage);
                driverobj.GetElement(lnk_Manage).Click();
                driverobj.WaitForElement(tab_role);
                driverobj.GetElement(tab_role).Click();
                driverobj.WaitForElement(btn_role_go_contributor);
                driverobj.GetElement(btn_role_go_contributor).Click();
                driverobj.WaitForElement(btn_role_go_adduser);
                driverobj.GetElement(btn_role_go_adduser).Click();
                driverobj.WaitForElement(txt_role_adduser_firstname);
                driverobj.GetElement(txt_role_adduser_firstname).Clear();
                driverobj.GetElement(txt_role_adduser_firstname).SendKeys(ExtractDataExcel.MasterDic_admin1["Id"]);
                driverobj.GetElement(btn_role_adduser_search).Click();
                driverobj.WaitForElement(chk_role_adduser_fromlist);
                driverobj.GetElement(chk_role_adduser_fromlist).Click();
                driverobj.GetElement(btn_role_adduser).Click();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public bool colspace_req_training(string colspacefor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                colspacesearch(colspacefor, browserstr);
                driverobj.WaitForElement(lnk_required_training);
                driverobj.GetElement(lnk_required_training).ClickAnchor();

                driverobj.WaitForElement(btn_required_training_go);
                driverobj.FindSelectElementnew(cmb_AssignTraining, "Assign Training Without Deadline");
                driverobj.GetElement(btn_required_training_go).Click();
                driverobj.WaitForElement(txt_AssignTraining_SearchRole);
                driverobj.GetElement(txt_AssignTraining_SearchRole).Clear();
                driverobj.GetElement(txt_AssignTraining_SearchRole).SendKeys(ExtractDataExcel.MasterDic_admin1["Id"]);
                driverobj.GetElement(btn_AssignTraining_Search).Click();

                driverobj.GetElement(chk_AssignTraining_adduser_fromlist).Click();
                driverobj.GetElement(btn_AssignTraining).Click();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool colspace_delete(string colspacefor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                colspacesearch(colspacefor, browserstr);

                actualresult = Click_Delete();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public bool Click_Delete()
        {
            bool actualresult = false;
            try
            {

                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
                driverobj.WaitForElement(btn_delete_content);
                driverobj.GetElement(btn_delete_content).ClickAnchor();
                actualresult = driverobj.existsElement(By.XPath("//span[@id='ReturnFeedback']"));

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
        }
        private By adminconsoleopenlink = By.Id("NavigationStrip1_lnkAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By lnk_admin_col_space = By.LinkText("Collaboration Spaces");
        private By btn_go_search_colspace = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_create_title = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CS_TITLE");
        private By txt_create_desc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CS_DESCRIPTION");
        private By txt_create_keyword = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CS_KEYWORDS");
        private By cmb_create_content_type = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CS_CONTENT_TYPE_ID");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_return_feedback = By.Id("ReturnFeedback");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By lbl_Create_Msg = By.XPath("//td[contains(.,'Collaboration spaces are typically used to share information among a particular group of users. There are three types of collaboration spaces: private, public and moderated.')]");
        private By txt_Searchtxt = By.Id("MainContent_ucQuickSearch_txtSearch");
        private By cmb_search = By.Id("ddlSearchType");
        private By btn_search = By.Id("btnSearch");
        private By lnk_col_space_title = By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_CSpace["Title"]/*+browserstr*/.ToString() + "')]");
        private By btn_join_col_space = By.Id("MainContent_ucPrimaryActions_FormView1_JoinCSBlockFlag");
        private By lbl_sucess_msg = By.XPath("//div[@class='alert alert-success']");
        private By lnk_mol_col_space = By.XPath("//a[contains(text(),'Collaboration Spaces')]");//can change by text change :(
        private By btn_openItem = By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst");
        private By lnk_first_col_space_link = By.XPath("//a[@id='ctl00_MainContent_UC1_rgCspace_ctl00_ctl04_lnkDetails']");
        private By btn_leave_col_space = By.Id("MainContent_ucPrimaryActions_FormView1_LeaveCS");
        //admin section
        private By lnk_advance_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_search_title = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE");
        private By txt_search_desc = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION");
        private By txt_search_keyword = By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS");
        private By cmb_search_col_space_type = By.Id("TabMenu_ML_BASE_TAB_Search_CTYP_CONTENT_TYPE_ID");
        private By btn_admin_search_col_space = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By txt_search_for = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_Manage = By.XPath("//a[contains(.,'Manage')]");
        private By tab_edit_logo = By.XPath("//span[contains(.,'Edit Logo')]");
        private By txt_preview_url = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL");
        private By ful_logo = By.Id("TabMenu_ML_BASE_WF_UploadLogo_CS_HOMEPAGE_UPLOAD_LOGO");
        private By lbl_logo_text = By.Id("TabMenu_ML_BASE_WF_UploadLogo_CS_HOMEPAGE_LOGO_URL");
        private By lnk_view_logo = By.Id("TabMenu_ML_BASE_WF_UploadLogo_VIEW_LOGO_URL");
        private By tab_role = By.XPath("//a[@id='ML.BASE.WF.EditPermissions']/span");
        private By btn_role_go_contributor = By.Id("TabMenu_ML_BASE_TAB_EditPermissions_Space_CSEditPermDataGrid_ctl02_GoButton");
        private By btn_role_go_adduser = By.Id("TabMenu_ML_BASE_TAB_EditPermissions_Users_GoPageActionsMenu");
        private By txt_role_adduser_firstname = By.Id("TabMenu_ML_BASE_TAB_AddUsers_USR_FIRST_NAME");
        private By btn_role_adduser_search = By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnSearch");
        private By chk_role_adduser_fromlist = By.Id("TabMenu_ML_BASE_TAB_AddUsers_CSUsers_ctl02_DataGridItem_USER_LAST_FIRST_NAME");
        private By btn_role_adduser = By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnAdd");
        private By lnk_required_training = By.XPath("//a[contains(.,'Required Training')]");
        private By btn_required_training_go = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu");
        private By cmb_AssignTraining = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining");
        private By txt_AssignTraining_SearchRole = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole");
        private By btn_AssignTraining_Search = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search");
        private By chk_AssignTraining_adduser_fromlist = By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0_')]");
        private By btn_AssignTraining = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining");
        private By lnk_delete_content = By.XPath("//a[contains(.,'Delete Content')]");
         private By btn_delete_content = By.XPath("html/body/div[1]/div[2]/div/div[3]/button[2]");


    }
}
