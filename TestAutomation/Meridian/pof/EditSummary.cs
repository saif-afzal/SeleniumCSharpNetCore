using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian
{
    class EditSummary
    {
        private readonly IWebDriver driverobj;

        public EditSummary(IWebDriver driver)
        {
            driverobj = driver;
        }
        public bool Membership_Click()
        {
            try
            {
                driverobj.WaitForElement(EditSummary_Membership_Tab);
                driverobj.GetElement(EditSummary_Membership_Tab).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool Options_Click()
        {
            try
            {
                driverobj.WaitForElement(EditSummary_Options_Tab);
                driverobj.GetElement(EditSummary_Options_Tab).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }

        public bool toggle_EnableProfessionalDevelopment_No()
        {
            try
            {
                driverobj.WaitForElement(rd_EnableProfessionalDevelopment_No);
                driverobj.GetElement(rd_EnableProfessionalDevelopment_No).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }

        public bool toggle_EnableProfessionalDevelopment_Yes()
        {
            try
            {
                driverobj.WaitForElement(rd_EnableProfessionalDevelopment_Yes);
                driverobj.GetElement(rd_EnableProfessionalDevelopment_Yes).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }

        public bool Save_Click()
        {
            try
            {
                driverobj.WaitForElement(btn_Save);
                driverobj.GetElement(btn_Save).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return true;
        }

        #region test

        public bool Populate_TestForPublish()
        {
            bool result = false;

            try
            {
                driverobj.GetElement(txt_mastryscore).Clear();
                driverobj.GetElement(txt_mastryscore).SendKeysWithSpace("100");
                driverobj.GetElement(txt_questionperpage).Clear();
                driverobj.GetElement(txt_questionperpage).SendKeysWithSpace("1");
                driverobj.GetElement(txt_maxtimeallowed).Clear();
                driverobj.GetElement(txt_maxtimeallowed).SendKeysWithSpace("1");
                driverobj.GetElement(txt_maxattempts).Clear();
                driverobj.GetElement(txt_maxattempts).SendKeysWithSpace("2");
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                driverobj.WaitForElement(tab_checkin);
              //  driverobj.GetElement(tab_checkin).ClickWithSpace();
                driverobj.ClickEleJs(tab_checkin);
                Thread.Sleep(3000);
                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Populate_TestForPublish_Question_HideTestResult()
        {
            bool result = false;
            try
            {
                driverobj.GetElement(txt_mastryscore).Clear();
                driverobj.GetElement(txt_mastryscore).SendKeysWithSpace("100");
                driverobj.GetElement(txt_questionperpage).Clear();
                driverobj.GetElement(txt_questionperpage).SendKeysWithSpace("1");
                driverobj.GetElement(txt_maxattempts).Clear();
                driverobj.GetElement(txt_maxattempts).SendKeysWithSpace("2");
                driverobj.GetElement(hideQuestionResults).ClickWithSpace();
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_success);
                driverobj.WaitForElement(tab_checkin);
                driverobj.GetElement(tab_checkin).ClickWithSpace();
                Thread.Sleep(3000);
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_CourseSettingTab()
        {
            bool result = false;

            try
            {

            }
            catch
            {


            }

            return result;
        }
        #endregion

        private By btn_Save = By.Id("ML.BASE.BTN.Save");
        private By rd_EnableProfessionalDevelopment_Yes = By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_Enable_ProfessionalDevelopment_0");
        private By rd_EnableProfessionalDevelopment_No = By.Id("TabMenu_ML_BASE_TAB_EditConfigOptions_Enable_ProfessionalDevelopment_1");
        private By EditSummary_Membership_Tab = By.XPath("//span[contains(.,'Membership')]");
        private By EditSummary_Options_Tab = By.XPath("//span[contains(.,'Options')]");

        //  private By chk_islearning = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_IS_LEARNING_EVALUATION");
        //  private By txt_contactinfo = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNTLCL_CONTACT_INFO");
        private By txt_mastryscore = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MASTERY_SCORE");
        private By txt_questionperpage = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_QSTNS_PER_PAGE");
        //private By txt_uniqueid = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_NUMBER");
        private By txt_maxtimeallowed = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MAX_TIME_ALLOWED");
        private By txt_maxattempts = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MAX_ATTEMPTS");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By lbl_success = By.XPath("//span[@id='ReturnFeedback']");
        private By tab_checkin = By.XPath("//span[contains(.,'Check In')]");
        private By hideQuestionResults = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRSW_HIDE_QUESTION_RESULTS");
    }


}
