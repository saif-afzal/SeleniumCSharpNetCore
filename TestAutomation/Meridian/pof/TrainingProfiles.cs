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

namespace Selenium2.Meridian
{
    class TrainingProfiles
    {
         private readonly IWebDriver driverobj;

         public TrainingProfiles(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_DynamicTrainingProfileCreateGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(cmb_createtrainingprofile);
                driverobj.FindSelectElementnew(cmb_createtrainingprofile, "Create New Dynamic Profile");
            //    driverobj.GetElement(btn_createtrainingprofilegoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_createtrainingprofilegoto);
                driverobj.WaitForElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditTrainingProfiles_RTPL_TITLE']"));

                result = true;
            }
            catch(Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Button GoTo to Create Dynamic Training Profile", driverobj);
            }


            return result;
        }
        public bool Click_FixedTrainingProfileCreateGoTo()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(cmb_createtrainingprofile);
                driverobj.FindSelectElementnew(cmb_createtrainingprofile, "Create New Fixed Date Profile");
           //     driverobj.GetElement(btn_createtrainingprofilegoto).ClickWithSpace();
                driverobj.ClickEleJs(btn_createtrainingprofilegoto);
                driverobj.WaitForElement(txt_title);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }


        public bool Click_searchTrainingProfile(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Title"]+browserstr);
            //    driverobj.GetElement(btn_searchfor).ClickWithSpace();
                driverobj.ClickEleJs(btn_searchfor);
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_TrainingProfile["Title"]+browserstr + "')]"));
                result = true;
                
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }


            return result;
        }

        public bool Click_AdvsearchTrainingProfile(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(txt_searchfor);
             //   driverobj.GetElement(lnk_advsearch).ClickAnchor();
                driverobj.ClickEleJs(lnk_advsearch);
                driverobj.WaitForElement(txt_title);
                driverobj.GetElement(txt_title).Clear();
                driverobj.GetElement(txt_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Title"]+browserstr);
                driverobj.GetElement(txt_desc).Clear();
                driverobj.GetElement(txt_desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Desc"]);
                driverobj.GetElement(txt_keyword).Clear();
                driverobj.GetElement(txt_keyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_TrainingProfile["Desc"]);
            //    driverobj.GetElement(btn_searchfor).ClickWithSpace();
                driverobj.ClickEleJs(btn_searchfor);
                driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_TrainingProfile["Title"]+browserstr + "')]"));
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }


            return result;
        }

        public bool Click_ManageTrainingProfile()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_manage);
                driverobj.GetElement(btn_manage).ClickWithSpace();
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }

            return result;
        }

        public bool Check_ProfileToDelete()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(chk_deleteprofile);
              //  driverobj.GetElement(chk_deleteprofile).Click();
                driverobj.ClickEleJs(chk_deleteprofile);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driverobj);
            }


            return result;
        }

        public bool Click_ProfileToDelete()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_deleteprofile);
            //    driverobj.GetElement(btn_deleteprofile).ClickWithSpace();
                driverobj.ClickEleJs(btn_deleteprofile);
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

        public bool Click_infoIcon()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(img_infoIcon);
                driverobj.GetElement(img_infoIcon).ClickWithSpace();
                
                result = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public bool verify_DomainSharingTabPresent()
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(btn_DomainSharingTab);
                driverobj.GetElement(img_infoIcon).ClickWithSpace();

                result = true;

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }

        public By cmb_createtrainingprofile = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.TAB.RequiredTrainingSimpleSearch");
        public By btn_createtrainingprofilegoto = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public By img_infoIcon = By.Id("TabMenu_ML_BASE_TAB_Search_TrainingProfileSearch_ctl02_ML.BASE.DG.Info");
        public By btn_DomainSharingTab = By.Id("TabMenutd2");
        private By txt_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By btn_searchfor = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private By lnk_advsearch = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced");
        private By txt_title = By.Id("TabMenu_ML_BASE_TAB_Search_RTPL_TITLE");
        private By txt_desc = By.Id("TabMenu_ML_BASE_TAB_Search_RTPL_DESCRIPTION");
        private By txt_keyword = By.Id("TabMenu_ML_BASE_TAB_Search_RTPL_KEYWORDS");

        private By btn_manage = By.Id("TabMenu_ML_BASE_TAB_Search_TrainingProfileSearch_ctl02_GoButton");
        private By chk_deleteprofile = By.Id("TabMenu_ML_BASE_TAB_Search_TrainingProfileSearch_ctl02_DataGridItem_DeleteTrainingProfile");
        private By btn_deleteprofile = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Delete");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
    }
}
