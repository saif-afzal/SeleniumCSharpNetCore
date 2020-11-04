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

namespace Selenium2.Meridian
{
    class CollabarationSpaces
    {
        private readonly IWebDriver driverobj;
        public CollabarationSpaces(IWebDriver driver)
        {
            driverobj = driver;
        }


        public bool Click_GoToButton()
        {

            bool actualresults = false;
            try
            {
                driverobj.WaitForElement(btn_go_search_colspace);
                driverobj.GetElement(btn_go_search_colspace).ClickWithSpace();
               actualresults = driverobj.existsElement(txt_create_title);
                

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }
        public bool Populate_Collabaration(string browserstr)
        {

            bool actualresults = false;
            try
            {
                driverobj.WaitForElement(txt_create_title);
                driverobj.GetElement(txt_create_title).Clear();
                driverobj.GetElement(txt_create_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_CSpace["Title"] + browserstr.ToString());
                driverobj.GetElement(txt_create_desc).Clear();
                driverobj.GetElement(txt_create_desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_CSpace["Title"] + browserstr.ToString());
                driverobj.GetElement(txt_create_keyword).Clear();
                driverobj.GetElement(txt_create_keyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_CSpace["Title"] + browserstr.ToString());
                driverobj.FindSelectElementnew(cmb_create_content_type, ExtractDataExcel.MasterDic_CSpace["Type"].ToString());
                if (driverobj.existsElement(cmb_homepagetext))
                {
                    driverobj.getcomboitemselected(cmb_homepagetext, 1);
                }
                if (driverobj.existsElement(rb_autosearch))
                {
                    //driverobj.GetElement(rb_autosearch).ClickWithSpace();
                    driverobj.ClickEleJs(rb_autosearch);
                }
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.GetElement(btn_save).ClickWithSpace();
                actualresults = driverobj.existsElement(lbl_Create_Msg);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresults;
        }

        public bool Click_lnkadvancesearch()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(lnk_advance_search);
              //  driverobj.GetElement(lnk_advance_search).ClickWithSpace();
                driverobj.ClickEleJs(lnk_advance_search);
               actualresult = driverobj.existsElement(txt_search_title);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Populate_advancesearch(string colspacefor, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_search_title);
                driverobj.GetElement(txt_search_title).Clear();
                driverobj.GetElement(txt_search_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor);
                driverobj.GetElement(txt_search_desc).Clear();
                driverobj.GetElement(txt_search_desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor);
                driverobj.GetElement(txt_search_keyword).Clear();
                driverobj.GetElement(txt_search_keyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor);
                driverobj.FindSelectElementnew(cmb_search_col_space_type, ExtractDataExcel.MasterDic_CSpace["Type"]);
                driverobj.GetElement(btn_admin_search_col_space).ClickWithSpace();

              actualresult =  driverobj.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor + "')]"));
                //driverobj.Close();
             
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Click_Search(string colspacefor, string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(txt_search_for);

                driverobj.GetElement(btn_admin_search_col_space).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor + "')]"));
             //   driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor + "')]")).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_CSpace["Title"] + browserstr + colspacefor + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool Populate_Search(string colspacefor, string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(txt_search_for);
                driverobj.GetElement(txt_search_for).Clear();
                driverobj.GetElement(txt_search_for).SendKeysWithSpace(ExtractDataExcel.MasterDic_CSpace["Title"]+browserstr + colspacefor);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }


        public bool Click_Manage()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(lnk_Manage);
                driverobj.GetElement(lnk_Manage).ClickWithSpace();

               actualresult = driverobj.existsElement(txt_preview_url);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

    
        public bool Click_save()
        {
            bool actualresult = false;
            try
            {


                driverobj.WaitForElement(txt_preview_url);
                driverobj.GetElement(txt_preview_url).SendKeysWithSpace("www.google.com");
                driverobj.GetElement(btn_save).ClickWithSpace();
               actualresult = driverobj.existsElement(lbl_return_feedback);

                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        RelativeDirectory rd = new RelativeDirectory();
        public bool editcolspacelogo()
        {
            bool actualresult = false;
            string path = rd.Up(2) + "\\Data\\test_image.jpg";
            try
            {
               
                driverobj.WaitForElement(tab_edit_logo);
                driverobj.GetElement(tab_edit_logo).ClickWithSpace();
                IAllowsFileDetection allowsDetection = (IAllowsFileDetection)driverobj;
                if (allowsDetection != null)
                {
                    allowsDetection.FileDetector = new LocalFileDetector();

                }
                Thread.Sleep(4000);
                driverobj.WaitForElement(ful_logo);
                driverobj.GetElement(ful_logo).SendKeys(path);
                Thread.Sleep(6000);
                driverobj.GetElement(btn_save).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.WaitForElement(lbl_logo_text);
               actualresult = driverobj.existsElement(lnk_view_logo);

                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool colspacerole()
        {
            bool actualresult = false;
            try
            {
              
                driverobj.WaitForElement(tab_role);
                driverobj.GetElement(tab_role).ClickWithSpace();
                driverobj.WaitForElement(btn_role_go_contributor);
                driverobj.GetElement(btn_role_go_contributor).ClickWithSpace();
                driverobj.WaitForElement(btn_role_go_adduser);
                driverobj.GetElement(btn_role_go_adduser).ClickWithSpace();
                driverobj.WaitForElement(txt_role_adduser_firstname);
                driverobj.GetElement(txt_role_adduser_firstname).Clear();
                driverobj.GetElement(txt_role_adduser_firstname).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Firstname"]);
                driverobj.GetElement(btn_role_adduser_search).ClickWithSpace();
                driverobj.WaitForElement(chk_role_adduser_fromlist);
                driverobj.GetElement(chk_role_adduser_fromlist).ClickWithSpace();
                driverobj.GetElement(btn_role_adduser).ClickWithSpace();
                Thread.Sleep(3000);
               actualresult = driverobj.existsElement(lbl_return_feedback);
               
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool Collabarationspace_req_training()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_required_training);
                driverobj.GetElement(lnk_required_training).ClickAnchor();

                driverobj.WaitForElement(btn_required_training_go);
                driverobj.FindSelectElementnew(cmb_AssignTraining, "Assign Training Without Deadline");
                driverobj.GetElement(btn_required_training_go).ClickWithSpace();
                driverobj.WaitForElement(txt_AssignTraining_SearchRole);
                driverobj.GetElement(txt_AssignTraining_SearchRole).Clear();
                driverobj.GetElement(txt_AssignTraining_SearchRole).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Id"]);
                driverobj.GetElement(btn_AssignTraining_Search).ClickWithSpace();
                driverobj.WaitForElement(chk_AssignTraining_adduser_fromlist);
                driverobj.GetElement(chk_AssignTraining_adduser_fromlist).ClickWithSpace();
                driverobj.GetElement(btn_AssignTraining).ClickWithSpace();
                Thread.Sleep(3000);
               actualresult = driverobj.existsElement(lbl_return_feedback);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
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
             //   driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Delete Content')]"));
                driverobj.WaitForElement(btn_delete_content);
             //   driverobj.GetElement(btn_delete_content).ClickAnchor();
                driverobj.ClickEleJs(btn_delete_content);
                actualresult = driverobj.existsElement(By.XPath("//span[@id='ReturnFeedback']"));

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
        }
        internal void CreateCollaborationSpaceForRegression(string browserstr)
        {
            TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
            AdminstrationConsole AdminstrationConsoleobj = new AdminstrationConsole(driverobj);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.ClickOnCollaborationSpace_AdminConsole();
            driverobj.selectWindow();
            Click_GoToButton();
            Populate_Collabaration(browserstr);
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
        private By lnk_mol_col_space = By.XPath("//span[contains(text(),'Collaboration Spaces')]");//can change by text change :(
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
         private By cmb_homepagetext = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CS_HOMEPAGE_TEXT_OPTION");
         private By rb_autosearch = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CS_HOMEPAGE_AUTO_SEARCH_1");


    }
}
