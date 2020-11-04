using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
// using TestAutomation.Data;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Text.RegularExpressions;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class CurriculamUtil
    {
        private readonly IWebDriver driverobj;

        public CurriculamUtil(IWebDriver driver)
        {
            driverobj = driver;
        }

        public void CreateCriculam()
        {
            try
            {
                driverobj.GetElement(ObjectRepository.adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(ObjectRepository.adminwindowtitle);
                driverobj.GetElement(By.LinkText("Curriculums")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_TITLE"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_TITLE")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_TITLE")).SendKeys(ExtractDataExcel.MasterDic_curriculam["Title"]);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_NUMBER")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_NUMBER")).SendKeys("curri_" + ExtractDataExcel.token_for_reg);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_DESCRIPTION")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_DESCRIPTION")).SendKeys(ExtractDataExcel.MasterDic_curriculam["Desc"]);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_KEYWORDS")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_KEYWORDS")).SendKeys(ExtractDataExcel.MasterDic_curriculam["Desc"]);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_CSPACE_AVLBLE_1")).Click();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNTLCL_CONTACT_INFO")).SendKeys(ExtractDataExcel.MasterDic_curriculam["Desc"]);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CBP_CRLM_TYPE"), "VLC");
                driverobj.GetElement(By.Id("ML.BASE.BTN.Create")).Click();
                //driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingActivities_GoPageActionsMenu"));
                //driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingActivities_GoPageActionsMenu")).Click();
                //driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor"));
                ////driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
                ////driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeys(ObjectRepository.CourseTitle + 1);
                //driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();
                //driverobj.GetElement(By.XPath("//input[contains(@id, 'TabMenu_ML_BASE_TAB_Search_ContentReq_1_ACTIVITIES_1_0')]")).Click();
                //driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Add")).Click();

                driverobj.WaitForElement(ObjectRepository.checkin);

                driverobj.GetElement(ObjectRepository.checkin).Click();
                Thread.Sleep(3000);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
        }
        public int totalcricount = 0;
        public bool CheckCricullamCount()
        {
            bool actualresult = false;
            try
            {
                string completed = Regex.Replace(driverobj.GetElement(cricompleted).Text.Trim(), @"[^\d]", "");
                string started = Regex.Replace(driverobj.GetElement(cristarted).Text.Trim(), @"[^\d]", "");
                if (completed != string.Empty && started != string.Empty)
                {
                    actualresult = true;
                }
                totalcricount = Convert.ToInt32(completed) + Convert.ToInt32(started);
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool CricullamViewDetail()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(CurriculamSummaryLink);
                driverobj.ClickEleJs(CurriculamSummaryLink);
                driverobj.WaitForTitle(TranscriptPageTitle, new TimeSpan(0, 0, 60));//TranscriptPageTitle
             actualresult=   driverobj.existsElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails"));
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool clickonquicklink()
        {
            try
            {

                driverobj.GetElement(lnktranscript).Click();
                driverobj.WaitForElement(By.Id("MainContent_ucQLinks_lnkCurriculum"));
                driverobj.GetElement(By.Id("MainContent_ucQLinks_lnkCurriculum")).Click();
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails"));
                return true;
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }
        }

        public bool clickontitle()
        {
            bool actualresult = false;
            try
            {

                driverobj.GetElement(lnktranscript).Click();
                driverobj.WaitForElement(By.Id("MainContent_ucQLinks_lnkCurriculum"));
                driverobj.GetElement(By.Id("MainContent_ucQLinks_lnkCurriculum")).Click();
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails"));
                string elementtitle = driverobj.GetElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails")).Text;
                Thread.Sleep(2000);
                driverobj.GetElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails")).Click();
                driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 30));//elementtitle
                actualresult = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool printcurri()
        {
            bool actualresult = false;
            try
            {

                driverobj.GetElement(lnktranscript).Click();
                driverobj.WaitForElement(By.Id("MainContent_ucQLinks_lnkCurriculum"));
                driverobj.GetElement(By.Id("MainContent_ucQLinks_lnkCurriculum")).Click();
                driverobj.WaitForElement(btnprintcurriculam);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btnprintcurriculam).Click();
                Thread.Sleep(3000);
                driverobj.SwitchWindow("Curriculums");
                driverobj.WaitForElement(printwindowcurriculamtext);
                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);

                actualresult = true;

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
            return actualresult;

        }

        public bool savepdfcurri()
        {

            try
            {
                driverobj.GetElement(lnktranscript).Click();
                driverobj.WaitForElement(By.Id("MainContent_ucQLinks_lnkCurriculum"));
                driverobj.GetElement(By.Id("MainContent_ucQLinks_lnkCurriculum")).Click();
                driverobj.WaitForElement(btnsaveaspdfcurri);
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(btnsaveaspdfcurri).Click();
                Thread.Sleep(3000);
                driverobj.selectWindow("CurriculaPrint.aspx");
                Thread.Sleep(8000);

                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);


                return true;


            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                return false;
            }

        }


        public void addalternate()
        {
            try
            {

                driverobj.WaitForElement(By.XPath("//span[contains(.,'Alternate Options')]"));
                driverobj.GetElement(By.XPath("//span[contains(.,'Alternate Options')]")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_HEAD_EditAltOptions_GoPageActionsMenu"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_HEAD_EditAltOptions_GoPageActionsMenu")).Click();
                driverobj.WaitForElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_Search_CertContent_1_ADD_ALT_OPT_CONTENT_1_0_')]"));
                driverobj.GetElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_Search_CertContent_1_ADD_ALT_OPT_CONTENT_1_0_')]")).Click();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Add")).Click();
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
        }
        string format = "M/d/yyyy";
        public void addactivity()
        {
            try
            {

                driverobj.WaitForElement(By.XPath("//span[contains(.,'Activity')]"));
                driverobj.GetElement(By.XPath("//span[contains(.,'Activity')]")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_START_DATE||DATEPICKER_dateInput"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_END_DATE||DATEPICKER_dateInput")).SendKeys(DateTime.Now.AddDays(2).ToString(format));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_START_DATE||DATEPICKER_dateInput")).SendKeys(DateTime.Now.ToString(format));

                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_NO_START_DATE")).Click();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_NO_END_DATE")).Click();
                driverobj.GetElement(By.Id("ML.BASE.BTN.Save")).Click();
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
        }

        public void updatecurriculam()
        {
            try
            {
                driverobj.WaitForElement(CurriculamDesc);
                driverobj.GetElement(CurriculamDesc).Clear();
                driverobj.GetElement(CurriculamDesc).SendKeys(ExtractDataExcel.MasterDic_curriculam["Desc"]);
                driverobj.GetElement(By.Id("ML.BASE.BTN.Save")).Click();
                //driverobj.WaitForElement(By.XPath("//span[contains(.,'Objectives')]"));
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
        }
        //public void addcourseforcurriculam()
        //{
        //    try
        //    {

        //        driverobj.GetElement(By.XPath("//a[@id='ML.BASE.WF.EditCertification']/span")).Click();
        //        driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_HEAD_EditCertification_GoPageActionsMenu"));
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_HEAD_EditCertification_GoPageActionsMenu")).Click();
        //        driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor"));
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeys(ObjectRepository.CourseTitle + 1);
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();
        //        driverobj.WaitForElement(By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_CertContent_1_ADD_CERT_CONTENT')]"));
        //        driverobj.GetElement(By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_CertContent_1_ADD_CERT_CONTENT')]")).Click();
        //        //CertificationUtilDriver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CertContent_1_ADD_CERT_CONTENT_1_0_36C562BA7F7143FDBA917C91A75DBACE_P_")).Click();
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Add")).Click();
        //        driverobj.WaitForElement(checkin);

        //    }

        //    catch (Exception ex)
        //    {
        //        ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }

        //}

        public void addrequiredtraining()
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Required Training')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Required Training')]")).Click();
                //driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining']"));
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining"));
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining"), "Assign Training Without Deadline");
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole")).SendKeys("site");
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search")).Click();
                driverobj.WaitForElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0')]"));
                driverobj.GetElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0')]")).Click();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining")).Click();
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }

        public void addsurvey()
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Surveys')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Surveys')]")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Surveys_GoPageActionsMenu"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Surveys_GoPageActionsMenu")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_ML.BASE.BTN.Search"));

                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_ML.BASE.BTN.Search")).Click();
                driverobj.GetElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignSurvey_ContentSurveyListingDataGrid_ctl02_DataGridItem_CNT_CONTENT_ID')]")).Click();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_ML.BASE.BTN.Assign")).Click();
                driverobj.findandacceptalert();
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }

        public bool copycurriculam()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Copy')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Copy')]")).Click();
                driverobj.findandacceptalert();

                driverobj.WaitForElement(By.Id("CNT_TITLE"));
                string title = driverobj.GetElement(By.Id("CNT_TITLE")).Text;
                if (title == "Copy 1 of " + ExtractDataExcel.MasterDic_curriculam["Title"])
                {
                    actualresult = true;
                }


            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
            return actualresult;

        }


        public bool deletecurriculam()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
                driverobj.SwitchWindow("Delete Content");

                driverobj.WaitForElement(By.Id("0"));
                driverobj.GetElement(By.Id("0")).Click();
                actualresult = true;


            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
            return actualresult;

        }

        public bool Curriculamsearchadmin(string type)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(adminconsoleopenlink);
                driverobj.GetElement(adminconsoleopenlink).Click();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.WaitForElement(By.XPath(Curriculamlink));
                driverobj.GetElement(By.XPath(Curriculamlink)).Click();
                driverobj.WaitForElement(CurriculamSerachFor);
                if (type == "adv")
                {
                    driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced"));
                    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced")).ClickAnchor();
                    driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
                    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).Clear();
                    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).SendKeys(ExtractDataExcel.MasterDic_curriculam["Title"]);
                    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).Clear();
                    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).SendKeys(ExtractDataExcel.MasterDic_curriculam["Desc"]);
                    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).Clear();
                    driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).SendKeys(ExtractDataExcel.MasterDic_curriculam["Desc"]);
                }
                else
                {
                    driverobj.GetElement(CurriculamSerachFor).Clear();
                    driverobj.GetElement(CurriculamSerachFor).SendKeys(ExtractDataExcel.MasterDic_curriculam["Title"]);
                }
                driverobj.GetElement(searchbutton).Click();

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_curriculam["Title"] + "')]"));
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

        public void searchcurriculamgenral()
        {
            try
            {
                driverobj.WaitForElement(adminconsoleopenlink);
                driverobj.GetElement(adminconsoleopenlink).Click();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.WaitForElement(By.XPath(Curriculamlink));
                driverobj.GetElement(By.XPath(Curriculamlink)).Click();
                driverobj.WaitForElement(CurriculamSerachFor);
                driverobj.GetElement(CurriculamSerachFor).Clear();
                driverobj.GetElement(CurriculamSerachFor).SendKeys(ExtractDataExcel.MasterDic_curriculam["Title"]);
                driverobj.GetElement(searchbutton).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_curriculam["Title"] + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_curriculam["Title"] + "')]")).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
        }
        public bool managecurriculam(string type)
        {
            bool actualresult = false;
            try
            {
                searchcurriculamgenral();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
                driverobj.GetElement(By.XPath("//span[contains(.,'Check Out')]")).Click();

                if (type == "update")
                {
                    updatecurriculam();

                }
                else if (type == "alternate")
                {
                    addalternate();

                }
                else if (type == "activity")
                {
                    addcourseforcertification();

                }


                driverobj.WaitForElement(By.Id("ReturnFeedback"));
                driverobj.GetElement(checkin).Click();
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

        public bool assigntrainingtocurri()
        {
            bool actualresult = false;
            try
            {

                searchcurriculamgenral();
                addrequiredtraining();
                driverobj.WaitForElement(By.Id("ReturnFeedback"));

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

        public bool assignsurvey()
        {
            bool actualresult = false;
            try
            {
                searchcurriculamgenral();
                Thread.Sleep(3000);

                addsurvey();
                driverobj.WaitForElement(By.Id("ReturnFeedback"));

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


        public bool CopyCurriculamDetail()
        {
            bool actualresult = false;
            try
            {
                searchcurriculamgenral();

                bool title = copycurriculam();


                driverobj.WaitForElement(By.Id("ReturnFeedback"));

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

        public bool DeleteCurriculamDetail()
        {
            bool actualresult = false;
            try
            {
                searchcurriculamgenral();

                bool result = deletecurriculam();

                if (result == true)
                {
                    driverobj.WaitForElement(By.Id("ReturnFeedback"));

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

        public void addcourseforcertification()
        {
            try
            {

                driverobj.GetElement(By.XPath("//a[@id='ML.BASE.WF.Activities']/span")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingActivities_GoPageActionsMenu"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditTrainingActivities_GoPageActionsMenu")).Click();

                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();
                driverobj.WaitForElement(By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_ContentOpt_1_ACTIVITIES_1_0_')]"));
                driverobj.GetElement(By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_Search_ContentOpt_1_ACTIVITIES_1_0_')]")).Click();
                //CertificationUtilDriver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CertContent_1_ADD_CERT_CONTENT_1_0_36C562BA7F7143FDBA917C91A75DBACE_P_")).Click();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Add")).Click();
                driverobj.WaitForElement(checkin);

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }

        private string Curriculamlink = "//a[contains(text(),'Curriculums')]";
        private By lnktranscript = By.XPath("//div[@id='ctl00_SiteNavigationBar2_rdNavigationMenu']/ul/li[3]/a/span");
        private By TrainingHome = By.XPath("//a[contains(text(),'Training Home')]");
        private By cricompleted = By.XPath("//div[h2[contains(text(),'Curriculums')]]//div[contains(text(),'Completed:')]");
        private By cristarted = By.XPath("//div[h2[contains(text(),'Curriculums')]]//div[contains(text(),'Started:')]");
        private By CurriculamSummaryLink = By.Id("MainContent_ucCurriculaSummary_lnkCert");
        private string TranscriptPageTitle = "Transcript";

        private By btnprintcurriculam = By.Id("MainContent_UC1_MLinkButton1");
        private By printwindowcurriculamtext = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00__0");
        private By btnsaveaspdfcurri = By.Id("MainContent_UC1_SaveAsPDF");

        private By adminconsoleopenlink = By.Id("NavigationStrip1_lbAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By createbutton = By.Id("ML.BASE.BTN.Create");
        private By checkin = By.XPath("//a[@id='ML.BASE.WF.Checkin']/span");
        private By returnbutton = By.Id("Return");
        private By CurriculamObjective = By.Id("TabMenu_ML_BASE_HEAD_EditObjectives_COBJ_OBJECTIVE");
        private By CurriculamTitle = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_TITLE");
        private By CurriculamDesc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_DESCRIPTION");
        private By CurriculamKeyWord = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CRLM_KEYWORDS");
        private By CurriculamSerachFor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By searchbutton = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");

    }
}
