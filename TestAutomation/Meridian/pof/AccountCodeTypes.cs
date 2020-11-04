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
    class AccountCodeTypes
    {
        private readonly IWebDriver driverobj;
        public AccountCodeTypes(IWebDriver driver)
        {
            driverobj = driver;
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

        public bool Populate_AccountCodeType(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createtitle);
                driverobj.GetElement(txt_createtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCodeType["Name"]+browserstr);
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCodeType["Desc"]);
              
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
              
                driverobj.WaitForElement(btn_save);
                driverobj.GetElement(btn_save).ClickWithSpace();
             actualresult =   driverobj.existsElement(lbl_success);
                
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
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCodeType["Name"]+browserstr);
           //     driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.ClickEleJs(btn_search);
               actualresult = driverobj.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_AccountCodeType["Name"]+browserstr + "')]"));
                
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
            //    driverobj.GetElement(lnk_advsearch).ClickAnchor();
                driverobj.ClickEleJs(lnk_advsearch);
                driverobj.WaitForElement(txt_searchtitle);
                driverobj.GetElement(txt_searchtitle).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCodeType["Name"]+browserstr);
                driverobj.GetElement(txt_searchdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCodeType["Desc"]);
              
           //     driverobj.GetElement(btn_search).ClickWithSpace();
                driverobj.ClickEleJs(btn_search);
               actualresult = driverobj.existsElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_AccountCodeType["Name"]+browserstr + "')]"));

                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }
            return actualresult;
        }

        public bool Edit_AccountCodeType()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_createdesc);
                driverobj.GetElement(txt_createdesc).Clear();
                driverobj.GetElement(txt_createdesc).SendKeysWithSpace(ExtractDataExcel.MasterDic_AccountCodeType["Desc"]);
                driverobj.ClickEleJs(btn_save);
              actualresult =  driverobj.existsElement(lbl_success);

               
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
               actualresult = driverobj.existsElement(txt_createdesc);
               
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
              
             //   driverobj.GetElement(img_infoicon).Click();
                driverobj.ClickEleJs(img_infoicon);
                driverobj.selectWindow("Account Code Types");
                Thread.Sleep(4000);
                driverobj.WaitForElement(By.XPath("//td[@id='TabMenu_ML_BASE_TAB_Summary_FIELD:ACTL_ACCT_TYPE_TITLE']"));
                if (driverobj.GetElement(By.XPath("//td[@id='TabMenu_ML_BASE_TAB_Summary_FIELD:ACTL_ACCT_TYPE_TITLE']")).Text.Contains(ExtractDataExcel.MasterDic_AccountCodeType["Name"]+browserstr))
                {
                    result = true;
                }

                //  SurveyUtilDriver.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure" + "')]"));
                driverobj.SelectWindowClose2("Account Code Types", Meridian_Common.parentwdw);


                result = true;
            }
            catch(Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }


            return result;
        }




        private By btn_createnewgoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By txt_createtitle = By.Id("TabMenu_ML_BASE_HEAD_EditAccountCodeType_ACTL_ACCT_TYPE_TITLE");
        private By txt_createdesc = By.Id("TabMenu_ML_BASE_HEAD_EditAccountCodeType_ACTL_ACCT_TYPE_DESC");
        private By btn_create = By.Id("ML.BASE.BTN.Create");

        private By btn_save = By.Id("ML.BASE.BTN.Save");

        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By btn_manageitem = By.Id("TabMenu_ML_BASE_TAB_Search_AccountCodeType_GoButton_1");

        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_searchtitle = By.Id("TabMenu_ML_BASE_TAB_Search_ACTL_ACCT_TYPE_TITLE");
        private By txt_searchdesc = By.Id("TabMenu_ML_BASE_TAB_Search_ACTL_ACCT_TYPE_DESC");
        private By btn_search = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");

        private By txt_contactinfo = By.Id("TabMenu_ML_BASE_TAB_EditAccountCode_AC_ACCT_CONTACT");

        private By img_infoicon = By.XPath("//img[@ src='/Skins/BaseTopMenu/Icons/en-US/ViewInfoIcon.png']");
        //private By img_infoicon = By.XPath("//img[contains(@id,'_1_AccountCodeType_1_InfoIcon')]");
        private By lbl_mainheading = By.Id("MainHeading");

    }
}
