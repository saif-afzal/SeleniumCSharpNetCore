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
    class SurveyScaleUtil
    {
        private readonly IWebDriver driverobj;

        public SurveyScaleUtil(IWebDriver driver)
        {
            driverobj = driver;
        }

        public string createscale()
        {
            string actualresult = string.Empty;
            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_Survey_Scales).Click();
               
                    driverobj.WaitForElement(btn_go);
                    driverobj.GetElement(btn_go).Click();
                    driverobj.WaitForElement(txt_create_title);
                    driverobj.GetElement(txt_create_title).Clear();
                    driverobj.GetElement(txt_create_title).SendKeys(ExtractDataExcel.MasterDic_Survey["Scale"]);
                    driverobj.GetElement(btn_create).Click();
                    driverobj.WaitForElement(lbl_return_feedback);
                    actualresult = driverobj.GetElement(lbl_return_feedback).Text;
                Thread.Sleep(3000);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;

        }

        public void scalesearch()
        {

            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.GetElement(lnk_Survey_Scales).Click();
                driverobj.WaitForElement(txt_searchfor);
                driverobj.GetElement(txt_searchfor).Clear();
                driverobj.GetElement(txt_searchfor).SendKeys(ExtractDataExcel.MasterDic_Survey["Scale"]);
                driverobj.GetElement(btn_search).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Scale"] + "')]"));
              

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }

        public bool scalesimplesearch()
        {
            bool actualresult = false;
            try
            {
                scalesearch();
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


        public bool add_option()
        {
            bool actualresult = false;
            try
            {
                scalesearch();
                driverobj.WaitForElement(btn_manage);
                driverobj.GetElement(btn_manage).Click();
                driverobj.WaitForElement(tab_option);
                driverobj.GetElement(tab_option).Click();
                driverobj.WaitForElement(txt_addoption);
                driverobj.GetElement(txt_addoption).Clear();
                driverobj.GetElement(txt_addoption).SendKeys("test_option");
                driverobj.GetElement(btn_addoption).Click();
                driverobj.WaitForElement(txt_option1);
                
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

        public bool manage_scale()
        {
            bool actualresult = false;
            try
            {
                scalesearch();
                driverobj.WaitForElement(btn_manage);
                driverobj.GetElement(btn_manage).Click();
                driverobj.WaitForElement(txt_create_title);
                driverobj.GetElement(txt_create_title).Clear();
                driverobj.GetElement(txt_create_title).SendKeys(ExtractDataExcel.MasterDic_Survey["Scale"]+1);
                driverobj.GetElement(btn_save).ClickWithSpace();

                driverobj.WaitForElement(lbl_return_feedback);
               // actualresult = driverobj.GetElement(lbl_return_feedback).Text;
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
        public bool deletescale()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.XPath("//*[contains(@id,'_DataGridItem_SSCL_SURVEY_SCALE_ID')]"));
                driverobj.GetElement(By.XPath("//*[contains(@id,'_DataGridItem_SSCL_SURVEY_SCALE_ID')]")).Click();

                driverobj.GetElement(By.Id("TabMenu_ML_BASE_HEAD_SurveyScale_ML.BASE.BTN.Delete")).ClickWithSpace() ;
                Thread.Sleep(2000);
                driverobj.findandacceptalert();

                driverobj.WaitForElement(lbl_return_feedback);
                actualresult = true;


            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
            return actualresult;

        }

        public bool DeletescaleDetail()
        {
            bool actualresult = false;
            try
            {
                scalesearch();

                bool result = deletescale();
                if (result == true)
                {
                    driverobj.Close();
                    driverobj.SwitchTo().Window("");
                    Thread.Sleep(3000);
                    actualresult = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
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
        private By tab_option = By.XPath("//span[contains(.,'Options')]");
        private By btn_addoption = By.Id("TabMenu_ML_BASE_TAB_SurveyOptions_ML.BASE.BTN.AddOption");
        private By txt_addoption = By.Id("TabMenu_ML_BASE_TAB_SurveyOptions_SRVCSLCL_SCALE_VALUE");
        private By txt_option1 = By.Id("TabMenu_ML_BASE_TAB_SurveyOptions_SurveyScaleOptions_ctl02_Tempname");
        private By txt_option2 = By.Id("TabMenu_ML_BASE_TAB_SurveyOptions_SurveyScaleOptions_ctl03_Tempname");
        private By lnk_delete_content = By.XPath("//a[contains(.,'Delete Content')]");
         private By btn_delete_content = By.XPath("html/body/div[1]/div[2]/div/div[3]/button[2]");

    }
}
