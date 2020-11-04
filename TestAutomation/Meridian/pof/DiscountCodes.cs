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
    class DiscountCodes
    {
        private readonly IWebDriver driverobj;
        public DiscountCodes(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Click_DiscontCodeTypeItem()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(cmb_discountcodetype);
                driverobj.FindSelectElementnew(cmb_discountcodetype, "Create Item Discount Code");

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_DiscontCodeTypeOrder()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(cmb_discountcodetype);
                driverobj.FindSelectElementnew(cmb_discountcodetype, "Create Order Discount Code");
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
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
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Populate_DiscountCode_item(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createtitle);
                driverobj.GetElement(txt_createtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Name"]+browserstr+"_item");
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Desc"]);
                driverobj.GetElement(txt_createkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Desc"]);
                driverobj.GetElement(txt_creatediscountno).SendKeysWithSpace(ExtractDataExcel.token_for_reg+"i");
                driverobj.GetElement(txt_creatediscountno).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Name"]+browserstr);
                driverobj.GetElement(txt_creatediscountamount).SendKeysWithSpace("100");
                driverobj.GetElement(By.XPath("//span[contains(.,'Item ')]"));
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Populate_DiscountCode_order(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createtitle);
                driverobj.GetElement(txt_createtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Name"]+browserstr);
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Desc"]);
                driverobj.GetElement(txt_createkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Desc"]);
                driverobj.GetElement(txt_creatediscountno).SendKeysWithSpace(ExtractDataExcel.token_for_reg);
                driverobj.GetElement(txt_creatediscountno).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Name"]+browserstr);
                driverobj.GetElement(txt_creatediscountamount).SendKeysWithSpace("100");
                driverobj.GetElement(By.XPath("//span[contains(.,'Order ')]"));
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Name"]+browserstr + "_item");
                driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_DiscountCode["Name"]+browserstr + "_item" + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_AdvSearch(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(lnk_advsearch);
           //     driverobj.GetElement(lnk_advsearch).ClickAnchor();
                driverobj.ClickEleJs(lnk_advsearch);
                driverobj.GetElement(txt_searchtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Name"]+browserstr);
                driverobj.GetElement(txt_searchdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Desc"]);
                driverobj.GetElement(txt_searchkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Desc"]);
                driverobj.GetElement(txt_searchdiscountcode).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Name"]+browserstr);
                driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_DiscountCode["Name"]+browserstr + "')]"));

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Edit_DiscountCodes()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createkeyword);

                driverobj.GetElement(txt_createkeyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_DiscountCode["Desc"]);
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);

                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
                driverobj.WaitForElement(txt_createdesc);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_InformationIcon(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(img_infoicon);
              
              //  driverobj.GetElement(img_infoicon).ClickWithSpace();
                driverobj.ClickEleJs(img_infoicon);
                driverobj.selectWindow("Discount Codes");
                Thread.Sleep(4000);
                driverobj.WaitForElement(By.XPath("//td[@id='TabMenu_ML_BASE_TAB_Summary_FIELD:DSCLCL_TITLE'])"));
                if (driverobj.GetElement(By.XPath("//td[@id='TabMenu_ML_BASE_TAB_Summary_FIELD:DSCLCL_TITLE'])")).Text.Contains(ExtractDataExcel.MasterDic_DiscountCode["Name"]+browserstr))
                {
                    result = true;
                }

                driverobj.SelectWindowClose2("Discount Codes", Meridian_Common.parentwdw);


                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_SearchContent()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_addcontentsearch);
                driverobj.WaitForElement(btn_addcontentsearch);
                driverobj.GetElement(btn_addcontentsearch).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Click_SelectDiscountCodetoAddContent()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_addcontent);
              //  driverobj.GetElement(chk_addcontent).ClickWithSpace();
                driverobj.ClickEleJs(chk_addcontent);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
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
                driverobj.WaitForElement(lbl_success);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }
        public bool Click_userTab()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(tab_user);
              //  driverobj.GetElement(tab_user).ClickWithSpace();
                driverobj.ClickEleJs(tab_user);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_AddUserGoTo()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_aduserGoTo);
                driverobj.GetElement(btn_aduserGoTo).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool Click_SearchUser()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_addusersearch);
                driverobj.GetElement(btn_addusersearch).ClickWithSpace();
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_SelectDiscountCodetoAddUser()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(chk_adduser);
              //  driverobj.GetElement(chk_adduser).ClickWithSpace();
                driverobj.ClickEleJs(chk_adduser);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool Click_AddUser()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_adduser);
                driverobj.GetElement(btn_adduser).ClickWithSpace();
                driverobj.findandacceptalert();
                actualresult=driverobj.existsElement(lbl_success);
              
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }



        private By btn_createnewgoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By cmb_discountcodetype = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.TAB.DiscountCode.SimpleSearch");
        private By txt_createtitle = By.Id("TabMenu_ML_BASE_TAB_EditDiscountCode_DSCLCL_TITLE");
        private By txt_createdesc = By.Id("TabMenu_ML_BASE_TAB_EditDiscountCode_DSCLCL_DESCRIPTION");
        private By txt_createkeyword = By.Id("TabMenu_ML_BASE_TAB_EditDiscountCode_DSCLCL_KEYWORDS");
        private By txt_creatediscountno = By.Id("TabMenu_ML_BASE_TAB_EditDiscountCode_DSC_CODE");
        private By txt_creatediscountamount = By.Id("TabMenu_ML_BASE_TAB_EditDiscountCode_DSC_TYPE_VAL");
        private By btn_create = By.Id("ML.BASE.BTN.Create");

      

        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_manageitem = By.Id("TabMenu_ML_BASE_TAB_Search_DISCOUNT_CODE_GoButton_1");

        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_searchtitle = By.Id("TabMenu_ML_BASE_TAB_Search_DSCLCL_TITLE");
        private By txt_searchdesc = By.Id("TabMenu_ML_BASE_TAB_Search_DSCLCL_DESCRIPTION");
        private By txt_searchkeyword = By.Id("TabMenu_ML_BASE_TAB_Search_DSCLCL_KEYWORDS");
        private By txt_searchdiscountcode = By.Id("TabMenu_ML_BASE_TAB_Search_DSC_CODE");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
       // private By txt_contactinfo = By.Id("TabMenu_ML_BASE_TAB_EditAccountCode_AC_ACCT_CONTACT");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By img_infoicon = By.XPath("//img[@ src='/Skins/BaseTopMenu/Icons/en-US/ViewInfoIcon.png']");
       // private By img_infoicon = By.XPath("//img[contains(@id,'_1_DISCOUNT_CODE_1_InfoIcon')]");
        private By lbl_mainheading = By.Id("MainHeading");


        private By tab_content = By.XPath("//span[contains(.,'Edit Content')]");
        private By btn_addcontentGoTo = By.Id("TabMenu_ML_BASE_HEAD_EditContent_GoPageActionsMenu");
        private By txt_addcontentsearch = By.Id("TabMenu_ML_BASE_HEAD_AddContent_SearchFor");
        private By btn_addcontentsearch = By.Id("TabMenu_ML_BASE_HEAD_AddContent_ML.BASE.BTN.Search");
        private By chk_addcontent = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_HEAD_AddContent_DContent_1_DISC_CODE_ADD_CONTENT_1_0_')]");
        private By btn_addcontent = By.Id("TabMenu_ML_BASE_HEAD_AddContent_AssignTraining");

        private By tab_user = By.XPath("//span[contains(.,'Users/Groups')]");
        private By btn_aduserGoTo = By.Id("TabMenu_ML_BASE_TAB_EditUsersOrUserGroup_GoPageActionsMenu");
        private By txt_addusersearch = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_SearchRole");
        private By btn_addusersearch = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_ML.BASE.BTN.Search");
        private By chk_adduser = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_ENTITY_ID_1_ENTITY_LIST_1_0_')]");
        private By btn_adduser = By.Id("TabMenu_ML_BASE_TAB_AddUsersOrUserGroup_AssignTraining");

    }
}
