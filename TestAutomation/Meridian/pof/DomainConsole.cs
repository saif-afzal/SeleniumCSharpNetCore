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
    class DomainConsole
    {
        private readonly IWebDriver driverobj;

        public DomainConsole(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_CreateGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_creategoto);
                driverobj.GetElement(btn_creategoto).ClickWithSpace();
                driverobj.WaitForElement(rb_parentdomain);

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_ParentDomain()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(rb_parentdomain);
              //  driverobj.GetElement(rb_parentdomain).ClickWithSpace();
                driverobj.ClickEleJs(rb_parentdomain);
                driverobj.WaitForElement(btn_next);

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_next()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_next);
                driverobj.GetElement(btn_next).ClickWithSpace();
                driverobj.WaitForElement(txt_domaintitle);

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Populate_domain(string browserstr,string type)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_domaintitle);
                driverobj.GetElement(txt_domaintitle).SendKeysWithSpace("testdomain" + ExtractDataExcel.token_for_reg + browserstr+type);
                driverobj.WaitForElement(txt_domaindesc);
                driverobj.GetElement(txt_domaindesc).SendKeysWithSpace("testdomain" + ExtractDataExcel.token_for_reg + browserstr + type);
                driverobj.FindSelectElementnew(cmb_selecturl, "http://testurl" + ExtractDataExcel.token_for_reg + browserstr + "/");
                
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(lnk_selectadmin);
                driverobj.GetElement(lnk_selectadmin).ClickAnchor();
                
                driverobj.SwitchWindow("Select Administrator");

                driverobj.WaitForElement(txt_searchfirstname);
                driverobj.GetElement(txt_searchfirstname).SendKeysWithSpace(ExtractDataExcel.MasterDic_admin1["Firstname"]);
                driverobj.GetElement(btn_searchtoselectadmin).ClickWithSpace();
                driverobj.WaitForElement(rb_selectadmin);
              //  driverobj.GetElement(rb_selectadmin).ClickWithSpace();
                driverobj.ClickEleJs(rb_selectadmin);
                driverobj.GetElement(btn_selectadmin).ClickWithSpace();
              
                driverobj.SwitchTo().Window(originalHandle);
              
                driverobj.WaitForElement(txt_domaintitle);
            //    driverobj.GetElement(txt_welcome).Click();
                driverobj.ClickEleJs(txt_welcome);
                driverobj.GetElement(txt_welcome).SendKeysWithSpace("Testing Welcome data");

                ((IJavaScriptExecutor)driverobj).ExecuteScript(" $('[id^=TabMenu_ML_BASE_TAB_EditSummary_DL_WELCOME_PAGE_TEXT]').find('p').last().text('test_welcome');");
                driverobj.GetElement(txt_helpdesc).SendKeysWithSpace("testdomain" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.GetElement(btn_create).ClickWithSpace();
                result = driverobj.existsElement(lbl_success);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_selectDomain(string browserstr, string type)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.XPath("//span[contains(.,'" + "testdomain" + ExtractDataExcel.token_for_reg + browserstr +type+ "')]"));
                driverobj.GetElement(By.XPath("//span[contains(.,'" + "testdomain" + ExtractDataExcel.token_for_reg + browserstr +type+ "')]")).Click();
                if(driverobj.selectWindow("Domains"))
                {
                   // driverobj.Close();
               //     driverobj.SelectWindowClose1();
                    driverobj.selectWindow("Domain Console");
                    driverobj.SelectWindowClose2("Domains", "Domain Console");
                    driverobj.GetElement(By.XPath("//span[contains(.,'" + "testdomain" + ExtractDataExcel.token_for_reg + browserstr + type + "')]")).Click();
                   // driverobj.SwitchTo().DefaultContent();
                }
                result = driverobj.existsElement(lnk_membership);
              
                string title = driverobj.Title;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_Membership()
        {
            bool result = false;

            try
            {
                string title = driverobj.Title;
                driverobj.WaitForElement(lnk_membership);
                driverobj.GetElement(lnk_membership).ClickWithSpace();
                driverobj.WaitForElement(txt_searchfor);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_search()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_searchtoremove);
                driverobj.GetElement(btn_searchtoremove).ClickAnchor();
                driverobj.WaitForElement(chk_selecttoremove);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_remove()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(chk_selecttoremove);
                   //  driverobj.GetElement(rb_selecttoremove).ClickAnchor();
                driverobj.ClickEleJs(rb_selecttoremove);
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CancelDomainMembership"));//btn_searchtoremove);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CancelDomainMembership")).ClickWithSpace();
                driverobj.findandacceptalert();
                result = driverobj.existsElement(lbl_success);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }


        public bool Click_summary()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_summary);
                driverobj.GetElement(lnk_summary).ClickWithSpace();
                driverobj.WaitForElement(txt_domaintitle);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_DeleteDomain()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_delete);
                driverobj.GetElement(btn_delete).ClickWithSpace();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_success);
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return driverobj.existsElement(lbl_success);
        }

        public bool Click_Skin(string browserstr)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_skin);
                driverobj.GetElement(lnk_skin).ClickWithSpace();
            result=driverobj.existsElement(By.XPath("//td[contains(text(),'" + "testskin" + ExtractDataExcel.token_for_reg + browserstr + "')]/preceding-sibling::td[2]/span/input[@class='rtChk']"));
               
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_Menu(string browserstr)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_menu);
            //    driverobj.GetElement(lnk_menu).ClickWithSpace();
                driverobj.ClickEleJs(lnk_menu);
                driverobj.WaitForElement(txt_customhome);
                driverobj.GetElement(txt_customhome).Clear();
                driverobj.GetElement(txt_customhome).SendKeysWithSpace("Home" + ExtractDataExcel.token_for_reg + browserstr);
                driverobj.GetElement(By.Name("SaveHierachyChanges")).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
              result= driverobj.existsElement(By.XPath("//input[contains(@value,'" + "Home" + ExtractDataExcel.token_for_reg + browserstr + "')]"));

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_Option()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_option);
            //    driverobj.GetElement(lnk_option).ClickWithSpace();
                driverobj.ClickEleJs(lnk_option);
                driverobj.WaitForElement(cmb_recordperpage);
                driverobj.FindSelectElementnew(cmb_recordperpage,"20");
                driverobj.GetElement(btn_save).ClickWithSpace();
              result= driverobj.existsElement(lbl_success);
               

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_Certificatetab()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_certificate);
              //  driverobj.GetElement(lnk_certificate).ClickWithSpace();
                driverobj.ClickEleJs(lnk_certificate);
              
                result = driverobj.existsElement(btn_searchcertificate);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_SearchCertificate()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_searchcertificate);
                driverobj.GetElement(btn_searchcertificate).ClickWithSpace();

                result = driverobj.existsElement(rb_selectcertificate);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_SelectCertificate()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_BTN_SelectCertificate_CertificateSearch_ctl02_ML.BASE.CERTIFICATE.Id.DefaultCertificate"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_BTN_SelectCertificate_CertificateSearch_ctl02_ML.BASE.CERTIFICATE.Id.DefaultCertificate")).Click();

                driverobj.WaitForElement(btn_selectcertificate);
                driverobj.GetElement(btn_selectcertificate).ClickWithSpace();
                driverobj.findandacceptalert();
             result=   driverobj.existsElement(lbl_success);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_homepagefeedtab()
        {
            bool result = false;

            try
            {
               
                driverobj.WaitForElement(lnk_homepagefeed);
                driverobj.GetElement(lnk_homepagefeed).ClickWithSpace();

                result = driverobj.existsElement(btn_searchfeed);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_Searchhomepagefeed()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_searchfeed);
                driverobj.GetElement(btn_searchfeed).ClickWithSpace();

                result = driverobj.existsElement(chk_selectfeed);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_Selecthomepagefeed()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(chk_selectfeed);
               // driverobj.GetElement(chk_selectfeed).Click();
                driverobj.ClickEleJs(chk_selectfeed);

                driverobj.WaitForElement(btn_selectfeed);
                driverobj.GetElement(btn_selectfeed).ClickWithSpace();
                result = driverobj.existsElement(lbl_success);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_activitytab()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_activity);
                driverobj.GetElement(lnk_activity).ClickWithSpace();

                result = driverobj.existsElement(rb_active);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_Selectactivity()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(rb_inactive);
                driverobj.GetElement(rb_inactive).ClickWithSpace();
                driverobj.GetElement(btn_saveactivity).ClickWithSpace();
                result = driverobj.existsElement(lbl_success);
                driverobj.WaitForElement(rb_active);
                driverobj.GetElement(rb_active).ClickWithSpace();
                driverobj.GetElement(btn_saveactivity).ClickWithSpace();
                result = driverobj.existsElement(lbl_success);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_AddMembergoto()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_addmembergoto);
                driverobj.GetElement(btn_addmembergoto).ClickWithSpace();

                result = driverobj.existsElement(btn_seachaddmember);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_searchmembertoadd()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(btn_seachaddmember);
                driverobj.GetElement(btn_seachaddmember).ClickWithSpace();

                result = driverobj.existsElement(chk_selectmember);


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_AddMember()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(chk_selectmember);
                driverobj.GetElement(chk_selectmember).ClickChkBox();

                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_AddMembers_AddDomainMembership"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AddMembers_AddDomainMembership")).ClickWithSpace();
                driverobj.findandacceptalert();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        private By btn_creategoto = By.Id("TabMenu_ML_BASE_TAB_Domains_GoPageActionsMenu");
        private By rb_parentdomain = By.XPath("//input[@name='DomainSelectParent']");
        private By btn_next = By.Id("ML.BASE.BTN.Next");
        private By txt_domaintitle = By.Id("TabMenu_ML_BASE_TAB_EditSummary_DL_DOMAIN_TITLE");
        private By txt_domaindesc = By.Id("TabMenu_ML_BASE_TAB_EditSummary_DL_DOMAIN_DESCRIPTION");
        private By cmb_selecturl = By.Id("TabMenu_ML_BASE_TAB_EditSummary_DM_DOMAIN_URL");
        private By lnk_selectadmin = By.XPath("//a[@onclick='DomainSelectAdmin()']");
        private By txt_searchfirstname = By.Id("TabMenu_ML_BASE_TAB_Search_USR_FIRST_NAME");
        private By rb_selectadmin = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_AdminUser_1_USERS_1_0_')]");
        private By btn_selectadmin = By.Id("TabMenu_ML_BASE_TAB_Search_Select");
        private By txt_welcome = By.Id("TabMenu_ML_BASE_TAB_EditSummary_DL_WELCOME_PAGE_TEXT");
        private By txt_helpdesc = By.Id("TabMenu_ML_BASE_TAB_EditSummary_DL_HELP_DESK_TEXT");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lnk_membership = By.XPath("//span[contains(.,'Membership')]");
        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_searchtoremove = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By chk_selecttoremove = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_ENTITY_ID_1_DomainMembership_1_0_')]");
        private By lnk_summary = By.XPath("//span[contains(.,'Summary')]");
        private By btn_delete = By.Id("ML.BASE.BTN.Delete");
        private By lnk_skin = By.XPath("//span[contains(.,'Skins')]");
        private By lnk_menu = By.XPath("//span[contains(.,'Menu')]");
        private By txt_customhome = By.XPath("//input[contains(@value,'Home')]");
        private By btn_savemenuchanges = By.Id("SaveHierachyChanges");
        private By lnk_option = By.XPath(".//*[@id='ML.BASE.WF.EditOptions']/span");
        private By cmb_recordperpage = By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_DefaultPageSize");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By lnk_certificate = By.XPath("//span[contains(.,'Certificate')]");
        private By btn_searchcertificate = By.Id("TabMenu_ML_BASE_BTN_SelectCertificate_ML.BASE.BTN.Search");
        private By rb_selectcertificate = By.Id("TabMenu_ML_BASE_BTN_SelectCertificate_CertificateSearch_ctl03_ML.BASE.CERTIFICATE.Id.DefaultCertificate");
        private By btn_selectcertificate = By.Id("TabMenu_ML_BASE_BTN_SelectCertificate_ML.BASE.BTN.SelectCertificate");
        private By lnk_homepagefeed = By.XPath("//span[contains(.,'Homepage Feed')]");
        private By btn_searchfeed = By.Id("TabMenu_ML_BASE_TAB_SelectHomepageFeed_SearchFeeds");
        private By chk_selectfeed = By.Id("TabMenu_ML_BASE_TAB_SelectHomepageFeed_HomepageFeeds_ctl03_DataGridItem_HMFD_FILE_ID");
        private By btn_selectfeed = By.Id("TabMenu_ML_BASE_TAB_SelectHomepageFeed_ML.BASE.BTN.SelectFeed");
        private By lnk_activity =By.XPath("//span[contains(.,'Activity')]");
        private By rb_inactive = By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_IS_ACTIVE_0");
        private By rb_active = By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_IS_ACTIVE_1");
        private By btn_saveactivity = By.Id("ML.BASE.BTN.Save");
        private By btn_addmembergoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By btn_seachaddmember = By.Id("TabMenu_ML_BASE_TAB_AddMembers_ML.BASE.BTN.Search");
        private By chk_selectmember = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_AddMembers_ENTITY_ID_1_DomainNewMembers_1_0_')]");
        private By rb_selecttoremove = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_ENTITY_ID_1_DomainMembership_1_0_')]");
        private By btn_addmember = By.XPath("TabMenu_ML_BASE_TAB_AddMembers_AddDomainMembership");
        private By btn_searchtoselectadmin = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
    }
}
