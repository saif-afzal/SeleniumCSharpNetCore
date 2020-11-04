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

namespace TestAutomation.Meridian.Regression_Objects
{
    class SurveyScales
    {
        private readonly IWebDriver driverobj;

        public SurveyScales(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool Click_GoToButton()
        {

            bool actualresults = false;
            try
            {
                driverobj.WaitForElement(btn_go);
                driverobj.GetElement(btn_go).ClickWithSpace();
                driverobj.WaitForElement(txt_create_title);
                actualresults = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }
        public bool Populate_SurveyScale()
        {

            bool actualresults = false;
            try
            {

                driverobj.WaitForElement(txt_create_title);
                driverobj.GetElement(txt_create_title).Clear();
                driverobj.GetElement(txt_create_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Scale"]);
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
                actualresults = true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }


        public bool Click_Search(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_search);
                driverobj.ClickEleJs(btn_search);
                Thread.Sleep(2000);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Scale"] + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool Populate_Search()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Scale"]);
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
                driverobj.WaitForElement(btn_manage);
              //  driverobj.FindElement(btn_manage).ClickWithSpace();
                driverobj.ClickEleJs(btn_manage);
                driverobj.WaitForElement(txt_create_title);
                actualresult = true;
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
                driverobj.WaitForElement(txt_create_title);
                driverobj.GetElement(txt_create_title).Clear();
                driverobj.GetElement(txt_create_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Scale"] + 1);
                driverobj.GetElement(btn_save).ClickWithSpace();

                driverobj.WaitForElement(lbl_return_feedback);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool Click_AddOption()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(tab_option);
                driverobj.ClickEleJs(tab_option);
                driverobj.WaitForElement(txt_addoption);
                driverobj.GetElement(txt_addoption).Clear();
                driverobj.GetElement(txt_addoption).SendKeysWithSpace("test_option");
                driverobj.ClickEleJs(btn_addoption);
                driverobj.WaitForElement(txt_option1);

                driverobj.WaitForElement(lbl_return_feedback);
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }


        public bool Click_Delete()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//*[contains(@id,'_DataGridItem_SSCL_SURVEY_SCALE_ID')]"));
              //  driverobj.GetElement(By.XPath("//*[contains(@id,'_DataGridItem_SSCL_SURVEY_SCALE_ID')]")).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("//*[contains(@id,'_DataGridItem_SSCL_SURVEY_SCALE_ID')]"));

                driverobj.GetElement(By.Id("TabMenu_ML_BASE_HEAD_SurveyScale_ML.BASE.BTN.Delete")).ClickWithSpace();
                Thread.Sleep(2000);
                driverobj.findandacceptalert();

                driverobj.WaitForElement(lbl_return_feedback);
                actualresult = true;
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
        private By lnk_Survey_Scales = By.LinkText("Survey Scales");
        private By myOwnlearning = By.Id("NavigationStrip1_lbUserView");
        private By btn_go = By.Id("TabMenu_ML_BASE_HEAD_SurveyScale_GoPageActionsMenu");
        private By txt_create_title = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyScale_SSCLLCL_SCALE_NAME");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_return_feedback = By.Id("ReturnFeedback");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        private By btn_search = By.Id("TabMenu_ML_BASE_HEAD_SurveyScale_ML.BASE.BTN.Search");
        private By txt_searchfor = By.Id("TabMenu_ML_BASE_HEAD_SurveyScale_SearchFor");
        private By btn_manage = By.Id("TabMenu_ML_BASE_HEAD_SurveyScale_SurveyScaleListingDataGrid_ctl02_GoButton");
        private By tab_option = By.Id("ML.BASE.WF.EditOptions");
        private By btn_addoption = By.Id("TabMenu_ML_BASE_TAB_SurveyOptions_ML.BASE.BTN.AddOption");
        private By txt_addoption = By.Id("TabMenu_ML_BASE_TAB_SurveyOptions_SRVCSLCL_SCALE_VALUE");
        private By txt_option1 = By.Id("TabMenu_ML_BASE_TAB_SurveyOptions_SurveyScaleOptions_ctl02_Tempname");
        private By txt_option2 = By.Id("TabMenu_ML_BASE_TAB_SurveyOptions_SurveyScaleOptions_ctl03_Tempname");
        private By lnk_delete_content = By.XPath("//a[contains(.,'Delete Content')]");
         private By btn_delete_content = By.XPath("html/body/div[1]/div[2]/div/div[3]/button[2]");

    }
}
