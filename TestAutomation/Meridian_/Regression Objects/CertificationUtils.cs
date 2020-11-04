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
    /// <summary>
    /// used as util class for Trainig Home ->Certification and Transcript->Certifation test class 
    /// </summary>
    class CertificationUtils
    {
        private readonly IWebDriver driverobj;

        public CertificationUtils(IWebDriver driver)
        {
            driverobj = driver;
        }

        int totalcertcount = 0;
        /// <summary>
        /// count number for stages of certification
        /// </summary>
        /// <returns></returns>
        public bool CheckCertificationCount()
        {
            bool actualresult = false;
            try
            {
                driverobj.HoverLinkClick(By.XPath("//a[contains(.,'Learn')]"), By.XPath(".//*[@id='learn_menu_group-dropdown']/li[1]/a"));
                string expired = Regex.Replace(driverobj.GetElement(CertificationExpiredCount).Text.Trim(), @"[^\d]", "");
                string progress = Regex.Replace(driverobj.GetElement(CertificationInProgressCount).Text.Trim(), @"[^\d]", "");
                string revoke = Regex.Replace(driverobj.GetElement(CertificationRevokeCount).Text.Trim(), @"[^\d]", "");
                string completed = Regex.Replace(driverobj.GetElement(CertificationCompletedCount).Text.Trim(), @"[^\d]", "");
                if (expired != string.Empty && progress != string.Empty && revoke != string.Empty && completed != string.Empty)
                {
                    actualresult = true;
                }
                totalcertcount = Convert.ToInt32(expired) + Convert.ToInt32(progress) + Convert.ToInt32(revoke) + Convert.ToInt32(completed);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool CertificationViewDetail(string type)
        {

            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(CertificationSummaryLink);
                driverobj.ClickEleJs(CertificationSummaryLink);
                driverobj.WaitForTitle(TranscriptPageTitle, new TimeSpan(0, 0, 60));
                driverobj.WaitForElement(By.Id("ctl00_MainContent_UC2_RadGrid1_ctl00_ctl04_lnkDetails"));
                string getcertcount = driverobj.GetElement(By.XPath("//h2[contains(.,'Certifications')]")).Text.Split(new char[]{'(', ')'})[1];
                CheckCertificationCount();
                if (totalcertcount == Convert.ToInt32(getcertcount))
                {
                    actualresult = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return actualresult;

        }






        ///// <summary>
        ///// used to create Certification
        ///// </summary>
        ///// <param name="certfor">suffix having information regarding to type of Certification as Certify, Revoke</param>
        ///// <returns></returns>
        ////public bool CreateCertification(string certfor)
        ////{
        ////    bool actualresult = false;
        ////    try
        ////    {
        ////        driverobj.GetElement(adminconsoleopenlink).Click();
        ////        driverobj.selectWindow(adminwindowtitle);
        ////        driverobj.GetElement(By.XPath(Certificationlink)).Click();
        ////        driverobj.GetElement(Certificationgobutton).Click();
        ////        driverobj.WaitForElement(CertificationTitle);
        ////        driverobj.GetElement(CertificationTitle).Clear();
        ////        driverobj.GetElement(CertificationTitle).SendKeys(ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + certfor);
        ////        driverobj.GetElement(CertificationDesc).Clear();
        ////        driverobj.GetElement(CertificationDesc).SendKeys(ExtractDataExcel.MasterDic_certification["Desc"]);
        ////        driverobj.GetElement(CertificationKeyWord).Clear();
        ////        driverobj.GetElement(CertificationKeyWord).SendKeys(ExtractDataExcel.MasterDic_certification["Desc"]);

        ////        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNTLCL_CONTACT_INFO")).SendKeys(ExtractDataExcel.MasterDic_certification["Desc"]);
        ////        driverobj.FindSelectElementnew(CertificationType, ExtractDataExcel.MasterDic_certification["Type"]);
        ////        //  driverobj.GetElement(CertificationCost).Click();//for external site
        ////        driverobj.GetElement(CertificationPeriod).Click();
        ////        driverobj.GetElement(CertificationPast).Click();

        ////        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_NUMBER")).Clear();
        ////        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_NUMBER")).SendKeys(certfor + ExtractDataExcel.token_for_reg);
        ////        driverobj.GetElement(createbutton).Click();
        ////        if (certfor != "Certifyadmin")
        ////        {
        ////            adddesctocertification();
        ////        }
        ////        if (certfor != "Revoke")
        ////        {
        ////            addcourseforcertification();
        ////        }
        ////        driverobj.WaitForElement(checkin);
        ////        driverobj.GetElement(checkin).Click();
        ////        Thread.Sleep(3000);
        ////        //driverobj.findandacceptalert();
        ////        driverobj.Close();
        ////        driverobj.SwitchTo().Window("");
        ////        Thread.Sleep(3000);
        ////        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        ////        actualresult = true;

        ////    }
        ////    catch (Exception ex)
        ////    {
        ////     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        ////    }
        ////    return actualresult;
        ////}

        //public void adddesctocertification()
        //{
        //    try
        //    {
        //        driverobj.WaitForElement(By.XPath("//span[contains(.,'Objectives')]"));
        //        driverobj.GetElement(By.XPath("//span[contains(.,'Objectives')]")).Click();
        //        driverobj.WaitForElement(CertificationObjective);
        //        driverobj.GetElement(CertificationObjective).Clear();
        //        driverobj.GetElement(CertificationObjective).SendKeys(ExtractDataExcel.MasterDic_certification["Desc"]);

        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_HEAD_EditObjectives_ML.BASE.BTN.Add")).Click();
        //        driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_HEAD_EditObjectives_ML.BASE.BTN.DeleteReqActivity"));
        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //}

        //public void addalternate()
        //{
        //    try
        //    {

        //        driverobj.WaitForElement(By.XPath("//span[contains(.,'Alternate Options')]"));
        //        driverobj.GetElement(By.XPath("//span[contains(.,'Alternate Options')]")).Click();
        //        driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_HEAD_EditAltOptions_GoPageActionsMenu"));
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_HEAD_EditAltOptions_GoPageActionsMenu")).Click();
        //        driverobj.WaitForElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_Search_CertContent_1_ADD_ALT_OPT_CONTENT_1_0_')]"));
        //        driverobj.GetElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_Search_CertContent_1_ADD_ALT_OPT_CONTENT_1_0_')]")).Click();
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Add")).Click();
        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //}
        //string format = "M/d/yyyy";
        //public void addactivity()
        //{
        //    try
        //    {

        //        driverobj.WaitForElement(By.XPath("//span[contains(.,'Activity')]"));
        //        driverobj.GetElement(By.XPath("//span[contains(.,'Activity')]")).Click();
        //        driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_START_DATE||DATEPICKER_dateInput"));
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_END_DATE||DATEPICKER_dateInput")).SendKeys(DateTime.Now.AddDays(2).ToString(format));
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_START_DATE||DATEPICKER_dateInput")).SendKeys(DateTime.Now.ToString(format));

        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_NO_START_DATE")).Click();
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditActivity_OBJ_ACTIVE_NO_END_DATE")).Click();
        //        driverobj.GetElement(By.Id("ML.BASE.BTN.Save")).Click();
        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //}

        //public void updatecertification()
        //{
        //    try
        //    {
        //        driverobj.WaitForElement(CertificationDesc);
        //        driverobj.GetElement(CertificationDesc).Clear();
        //        driverobj.GetElement(CertificationDesc).SendKeys(ExtractDataExcel.MasterDic_certification["Desc"]);
        //        driverobj.GetElement(By.Id("ML.BASE.BTN.Save")).Click();
        //        driverobj.WaitForElement(By.XPath("//span[contains(.,'Objectives')]"));
        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //}
        //public void addcourseforcertification()
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
        //        //driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CertContent_1_ADD_CERT_CONTENT_1_0_36C562BA7F7143FDBA917C91A75DBACE_P_")).Click();
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Add")).Click();
        //        driverobj.WaitForElement(checkin);

        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }

        //}

        //public void addrequiredtraining()
        //{
        //    try
        //    {
        //        driverobj.WaitForElement(By.XPath("//a[contains(.,'Required Training')]"));
        //        driverobj.GetElement(By.XPath("//a[contains(.,'Required Training')]")).Click();
        //        //driver.FindElement(By.XPath("//select[@id='TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining']"));
        //        driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining"));
        //        driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining"), "Assign Training Without Deadline");
        //        driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu"));
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu")).Click();
        //        driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole"));
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole")).Clear();
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole")).SendKeys("site");
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search")).Click();
        //        driverobj.WaitForElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0')]"));
        //        driverobj.GetElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0')]")).Click();
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining")).Click();
        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }

        //}

        //public void addsurvey()
        //{
        //    try
        //    {
        //        driverobj.WaitForElement(By.XPath("//a[contains(.,'Surveys')]"));
        //        driverobj.GetElement(By.XPath("//a[contains(.,'Surveys')]")).Click();
        //        driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Surveys_GoPageActionsMenu"));
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Surveys_GoPageActionsMenu")).Click();
        //        driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_ML.BASE.BTN.Search"));

        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_ML.BASE.BTN.Search")).Click();
        //        driverobj.GetElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignSurvey_ContentSurveyListingDataGrid_ctl02_DataGridItem_CNT_CONTENT_ID')]")).Click();
        //        driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_ML.BASE.BTN.Assign")).Click();
        //        driverobj.findandacceptalert();
        //    }

        //    catch (Exception ex)
        //    {
        //        if (driverobj.existsElement(By.XPath("//a[contains(.,'Administration Console')]")))
        //        {
        //            driverobj.Close();
        //            Thread.Sleep(2000);
        //            driverobj.SwitchTo().Window("");
        //            Thread.Sleep(2000);
        //        }
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }

        //}

        //public bool copycertificate(string certfor)
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        driverobj.WaitForElement(By.XPath("//a[contains(.,'Copy')]"));
        //        driverobj.GetElement(By.XPath("//a[contains(.,'Copy')]")).Click();
        //        driverobj.findandacceptalert();

        //        driverobj.WaitForElement(By.Id("CNT_TITLE"));
        //        string title = driverobj.GetElement(By.Id("CNT_TITLE")).Text;
        //        if (title == "Copy 1 of " + ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + certfor)
        //        {
        //            actualresult = true;
        //        }


        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

        //    }
        //    return actualresult;

        //}


        //public bool deletecertificate(string certfor)
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
        //        driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
        //        driverobj.SwitchWindow("Delete Content");

        //        driverobj.WaitForElement(By.Id("0"));
        //        driverobj.GetElement(By.Id("0")).Click();
        //        Thread.Sleep(5000);

        //        driverobj.WaitForElement(By.XPath("//span[@id='ReturnFeedback']"));
        //        actualresult = true;


        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

        //    }
        //    return actualresult;

        //}


        ////public bool Accesscertification(string certfor)
        ////{
        ////    bool actualresult = false;
        ////    try
        ////    {
        ////        driverobj.GetElement(traininghomesearchtext).Clear();
        ////        driverobj.GetElement(traininghomesearchtext).SendKeys(ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + certfor);
        ////        driverobj.FindSelectElementnew(traininghomeSearchType, filterdropdowntext);
        ////        driverobj.GetElement(traininghomeSearchButton).Click();
        ////        driverobj.GetElement(Certificationsearcheditem).Click();
        ////        driverobj.GetElement(CertificationOpenAccess).Click();
        ////        Thread.Sleep(3000);
        ////        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        ////        actualresult = true;

        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        ////    }
        ////    return actualresult;
        ////}

        ///// <summary>
        ///// to access certification by learner
        ///// </summary>
        ///// <param name="certfor">suffix having information regarding to type of Certification as Certify, Revoke</param>
        //public void CerificationActions(string certfor)
        //{
        //    try
        //    {
        //        driverobj.GetElement(adminconsoleopenlink).Click();
        //        driverobj.selectWindow(adminwindowtitle);
        //        driverobj.GetElement(By.XPath(CertificationConsolelink)).Click();
        //        // driverobj.FindSelectElementnew(CertificationType, "Linear");
        //        driverobj.GetElement(CertificationSerachFor).Clear();
        //        driverobj.GetElement(CertificationSerachFor).SendKeys(ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + certfor);
        //        driverobj.GetElement(searchbutton).Click();
        //        driverobj.GetElement(CertificationViewUserGoToButton).Click();
        //        driverobj.GetElement(CertificationViewUserSearchText).Clear();
        //        driverobj.GetElement(CertificationViewUserSearchText).SendKeys(ExtractDataExcel.MasterDic_userforreg["Lastname"]+browserstr + " " + ExtractDataExcel.MasterDic_userforreg["Firstname"]+browserstr);
        //        //driverobj.FindSelectElementnew(CertificationSearchType, filterdropdowntext);
        //        driverobj.GetElement(CertificationViewSearchUserButton).Click();
        //        driverobj.GetElement(CertificationViewHistoryButton).Click();
        //    }
        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }

        //}


        ///// <summary>
        ///// performing action on creted Certification
        ///// </summary>
        ///// <param name="type">suffix having information regarding to type of Certification as Certify, Revoke</param>
        ///// <returns></returns>
        //public bool PerformActionOnCertification(string type)
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        CerificationActions(type);
        //        if (type == "Certify")
        //        {
        //            driverobj.GetElement(CertificationCertifyRd).Click();
        //            driverobj.GetElement(CertificationHistoryChangeDate).SendKeys("2013-06-26");
        //            driverobj.GetElement(CertificationHistoryChangeReason).SendKeys(ExtractDataExcel.MasterDic_certification["Desc"]);


        //        }
        //        else if (type == "Suspend")
        //        {
        //            driverobj.GetElement(CertificationSuspendRd).Click();
        //            driverobj.GetElement(CertificationHistoryChangeDate).SendKeys("2013-06-26");
        //            driverobj.GetElement(CertificationHistoryChangeReason).SendKeys(ExtractDataExcel.MasterDic_certification["Desc"]);
        //        }
        //        else if (type == "Revoke")
        //        {
        //            driverobj.GetElement(CertificationCertifyRd).Click();
        //            driverobj.GetElement(CertificationHistoryChangeDate).SendKeys("2013-06-26");
        //            driverobj.GetElement(CertificationHistoryChangeReason).SendKeys(ExtractDataExcel.MasterDic_certification["Desc"]);
        //            driverobj.GetElement(CertificationTakeAction).Click();
        //            driverobj.findandacceptalert();
        //            Thread.Sleep(2000);
        //            driverobj.GetElement(CertificationRevokeRd).Click();
        //        }
        //        Thread.Sleep(3000);
        //        driverobj.GetElement(CertificationTakeAction).Click();
        //        driverobj.findandacceptalert();
        //        driverobj.Close();
        //        driverobj.SwitchTo().Window("");
        //        Thread.Sleep(3000);
        //        driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
        //        actualresult = true;

        //    }
        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //    return actualresult;
        //}

        ///// <summary>
        ///// check icon for stage of certification
        ///// </summary>
        ///// <param name="type">suffix having information regarding to type of Certification as Certify, Revoke</param>
        ///// <returns></returns>
        //public bool CheckIcon(string type)
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        driverobj.GetElement(TrainingHome).Click();

        //        if (type == "Revoke")
        //        {
        //            driverobj.WaitForElement(CertificationProbIcon);
        //            driverobj.GetElement(CertificationProbIcon);
        //        }
        //        else if (type == "Completed")
        //        {
        //            driverobj.WaitForElement(CertificationOkIcon);
        //            driverobj.GetElement(CertificationOkIcon);
        //        }
        //        actualresult = true;

        //    }
        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //    return actualresult;
        //}
      
        ///// <summary>
        ///// click on View Detail button of Certification Portlet to view detail of that certification
        ///// </summary>
        ///// <param name="type">suffix having information regarding to type of Certification as Certify, Revoke</param>
        ///// <returns></returns>
       
        ///// <summary>
        ///// to access certification by learner
        ///// </summary>
        ///// <param name="certfor">suffix having information regarding to type of Certification as Certify, Revoke</param>
        //public bool CertificationAccess(string type)
        //{

        //    bool actualresult = false;
        //    try
        //    {
        //        driverobj.GetElement(TrainingHome).Click();
        //        driverobj.WaitForElement(CourseName_Ed);
        //        driverobj.GetElement(CourseName_Ed).SendKeys(ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + type);//ExtractDataExcel.generalcourse("name"));
        //        driverobj.FindSelectElementnew(CourseName_Typ, filterdropdowntext);
        //        driverobj.GetElement(CourseSearch_Btn).Click();
        //        driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + type + "')]"));
        //        driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + type + "')]")).ClickAnchor();
        //        driverobj.GetElement(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag")).Click();
        //        driverobj.WaitForElement(By.Id("ctl00_MainContent_ucCertification_FormView1_mgCertification_ctl00_ctl04_lnkDetails"));
        //        driverobj.GetElement(TrainingHome).Click();
        //        if (type == "Revoke")
        //        {
        //            driverobj.WaitForElement(By.Id("MainContent_ucCertSummary_imgCertProb"));

        //        }
        //        else
        //        {
        //            driverobj.WaitForElement(By.Id("MainContent_ucCertSummary_imgCertOk"));
        //        }
        //        actualresult = true;
        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }

        //    return actualresult;
        //}

        ///// <summary>
        ///// click on My Own Learning -> Transcript -> Certification quicklink
        ///// </summary>
        //public void ClickTranscriptCertififationLink()
        //{


        //    try
        //    {
        //        driverobj.WaitForElement(TranscriptHome);
        //        driverobj.GetElement(TranscriptHome).Click();
        //        driverobj.WaitForElement(TranscriptCertificationLink);
        //        driverobj.GetElement(TranscriptCertificationLink).Click();


        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //        //Assert.Fail(ex.Message);
        //    }

        //}

        ///// <summary>
        ///// check for created certification exists in My Own Learning -> Transcript -> Certification section
        ///// </summary>
        ///// <returns></returns>
        //public bool ClickCertificationQuickLink()
        //{
        //    bool actualresult = false;
        //    string format = "M/dd/yyyy";
        //    try
        //    {
        //        ClickTranscriptCertififationLink();

        //        //driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_certification["Title"]+browserstr + "')]"));
        //        driverobj.WaitForElement(CertificationLinkonTranscript);
        //        actualresult = true;
        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //        //Assert.Fail(ex.Message);
        //    }
        //    return actualresult;
        //}

        ///// <summary>
        ///// click on an certification item in My Own Learning -> Transcript -> Certification
        ///// </summary>
        ///// <returns></returns>
        //public bool ClickCertificationItem()
        //{
        //    bool actualresult = false;

        //    try
        //    {
        //        ClickTranscriptCertififationLink();

        //        driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails"));
        //        string certtext = driverobj.GetElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails")).Text;/*XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_certification["Title"]+browserstr + "')]"));*/
        //        driverobj.GetElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails")).Click();/*By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_certification["Title"]+browserstr + "')]")).Click();*/
        //        Thread.Sleep(4000);

        //        driverobj.WaitForTitle("Details", new TimeSpan(0, 0, 30));//certtext
        //        //driverobj.WaitForTitle(ExtractDataExcel.MasterDic_certification["Title"]+browserstr, new TimeSpan(0, 0, 30));
        //        actualresult = true;
        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //        //Assert.Fail(ex.Message);
        //    }
        //    return actualresult;
        //}

        ///// <summary>
        ///// click on print button in My Own Learning -> Transcript -> Certification
        ///// </summary>
        ///// <returns></returns>
        //public bool ClickCertificationPrintBtn()
        //{
        //    bool actualresult = false;

        //    try
        //    {
        //        ClickTranscriptCertififationLink();
        //        string originalHandle = driverobj.CurrentWindowHandle;
        //        driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_certification["Title"]+browserstr + "')]"));
        //        driverobj.GetElement(CertTranscriptprintbtn).Click();

        //        Thread.Sleep(3000);
        //        driverobj.SwitchWindow(CertTranscriptprintpagetitle);
        //        driverobj.WaitForElement(CertTranscriptprintpagelink);
        //        driverobj.Close();
        //        Thread.Sleep(3000);
        //        driverobj.SwitchTo().Window(originalHandle);
        //        actualresult = true;

        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //        //Assert.Fail(ex.Message);
        //    }
        //    return actualresult;
        //}

        ///// <summary>
        ///// click on PDF button on My Own Learning -> Transcript -> Certification
        ///// </summary>
        ///// <returns></returns>
        //public bool ClickCertificationPDFBtn()
        //{
        //    bool actualresult = false;

        //    try
        //    {
        //        ClickTranscriptCertififationLink();
        //        string originalHandle = driverobj.CurrentWindowHandle;
        //        driverobj.WaitForElement(By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkDetails"));
        //        driverobj.GetElement(CertTranscriptsaveaspdfbtn).Click();
        //        Thread.Sleep(3000);
        //        driverobj.selectWindow(CertTranscriptpdfpagetitle);
        //        Thread.Sleep(8000);
        //        driverobj.Close();
        //        Thread.Sleep(3000);
        //        driverobj.SwitchTo().Window(originalHandle);
        //        actualresult = true;

        //    }

        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //        //Assert.Fail(ex.Message);
        //    }
        //    return actualresult;
        //}

        //public bool Cerificationsearchadmin(string certfor, string type)
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        driverobj.WaitForElement(adminconsoleopenlink);
        //        driverobj.GetElement(adminconsoleopenlink).Click();
        //        driverobj.selectWindow(adminwindowtitle);
        //        driverobj.WaitForElement(By.XPath(Certificationlink));
        //        driverobj.GetElement(By.XPath(Certificationlink)).Click();
        //        if (type == "adv")
        //        {
        //            driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced"));
        //            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced")).ClickAnchor();
        //            driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
        //            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).Clear();
        //            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).SendKeys(ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + certfor);
        //            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).Clear();
        //            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).SendKeys(ExtractDataExcel.MasterDic_certification["Desc"]);
        //            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).Clear();
        //            driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).SendKeys(ExtractDataExcel.MasterDic_certification["Desc"]);
        //        }
        //        else
        //        {
        //            driverobj.GetElement(CertificationSerachFor).Clear();
        //            driverobj.GetElement(CertificationSerachFor).SendKeys(ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + certfor);
        //        }
        //        driverobj.GetElement(searchbutton).Click();

        //        driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + certfor + "')]"));
        //        driverobj.Close();
        //        driverobj.SwitchTo().Window("");
        //        Thread.Sleep(3000);
        //        actualresult = true;
        //    }
        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //    return actualresult;
        //}

        //public void searchcertifationgenral(string certfor)
        //{
        //    try
        //    {
        //        driverobj.WaitForElement(adminconsoleopenlink);
        //        driverobj.GetElement(adminconsoleopenlink).Click();
        //        driverobj.selectWindow(adminwindowtitle);
        //        driverobj.WaitForElement(By.XPath(Certificationlink));
        //        driverobj.GetElement(By.XPath(Certificationlink)).Click();
        //        driverobj.WaitForElement(CertificationSerachFor);
        //        driverobj.GetElement(CertificationSerachFor).Clear();
        //        driverobj.GetElement(CertificationSerachFor).SendKeys(ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + certfor);
        //        driverobj.GetElement(searchbutton).Click();
        //        driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + certfor + "')]"));
        //        driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_certification["Title"]+browserstr + " " + certfor + "')]")).Click();
        //    }
        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //}
        ////public bool managecertification(string certfor, string type)
        ////{
        ////    bool actualresult = false;
        ////    try
        ////    {
        ////        searchcertifationgenral(certfor);
        ////        driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
        ////        driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
        ////        driverobj.WaitForElement(By.XPath("//span[contains(.,'Check Out')]"));
        ////        driverobj.GetElement(By.XPath("//span[contains(.,'Check Out')]")).Click();
        ////        if (type == "addobj")
        ////        {
        ////            adddesctocertification();
        ////        }
        ////        else if (type == "update")
        ////        {
        ////            updatecertification();

        ////        }
        ////        else if (type == "alternate")
        ////        {
        ////            addalternate();

        ////        }
        ////        else if (type == "activity")
        ////        {
        ////            addactivity();

        ////        }


        ////        driverobj.WaitForElement(By.Id("ReturnFeedback"));
        ////        driverobj.GetElement(checkin).Click();
        ////        driverobj.Close();
        ////        driverobj.SwitchTo().Window("");
        ////        Thread.Sleep(3000);
        ////        actualresult = true;
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        ////    }
        ////    return actualresult;
        ////}

        //public bool assigntrainingtocert(string certfor)
        //{
        //    bool actualresult = false;
        //    try
        //    {

        //        searchcertifationgenral(certfor);
        //        addrequiredtraining();
        //        driverobj.WaitForElement(By.Id("ReturnFeedback"));

        //        driverobj.Close();
        //        driverobj.SwitchTo().Window("");
        //        Thread.Sleep(3000);
        //        actualresult = true;
        //    }
        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //    return actualresult;
        //}

        //public bool assignsurvey(string certfor)
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        searchcertifationgenral(certfor);
        //        Thread.Sleep(3000);

        //        addsurvey();
        //        driverobj.WaitForElement(By.Id("ReturnFeedback"));

        //        driverobj.Close();
        //        driverobj.SwitchTo().Window("");
        //        Thread.Sleep(3000);
        //        actualresult = true;
        //    }
        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //    return actualresult;
        //}


        //public bool CopyCertificationDetail(string certfor)
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        searchcertifationgenral(certfor);

        //        bool title = copycertificate(certfor);


        //        driverobj.WaitForElement(By.Id("ReturnFeedback"));

        //        driverobj.Close();
        //        driverobj.SwitchTo().Window("");
        //        Thread.Sleep(3000);
        //        actualresult = true;
        //    }
        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //    return actualresult;
        //}

        //public bool DeleteCertificationDetail(string certfor)
        //{
        //    bool actualresult = false;
        //    try
        //    {
        //        searchcertifationgenral(certfor);

        //        bool result = deletecertificate(certfor);

        //        if (result == true)
        //        {
        //            driverobj.Close();
        //            driverobj.SwitchTo().Window("");
        //            Thread.Sleep(3000);
        //            actualresult = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //     ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
        //    }
        //    return actualresult;
        //}


        private By adminconsoleopenlink = By.Id("NavigationStrip1_lbAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By createbutton = By.Id("ML.BASE.BTN.Create");
        private By checkin = By.XPath("//a[@id='ML.BASE.WF.Checkin']/span");
        private By returnbutton = By.Id("Return");
        private string filterdropdowntext = "All words";
        private string filterdropdownexact = "Exact phrase";
        private By TranscriptHome = By.XPath("//a[contains(text(),'Transcript')]");
        private By TrainingHome = By.XPath("//a[contains(text(),'Training Home')]");
        private By CourseName_Ed = By.Id("MainContent_ucQuickSearch_txtSearch");
        private By CourseName_Typ = By.Id("ddlSearchType");
        private By CourseSearch_Btn = By.Id("btnSearch");
        private string TranscriptPageTitle = "Transcript";
        private string CourseTitle = string.Empty;
        private By searchbutton = By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search");
        private string Certificationlink = "//a[contains(text(),'Certifications')]";
        private string CertificationConsolelink = "//a[contains(text(),'Certification Console')]";
        private By Certificationgobutton = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By CertificationTitle = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_TITLE");
        private By CertificationDesc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_DESCRIPTION");
        private By CertificationKeyWord = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_KEYWORDS");
        private By CertificationType = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_CERTTYPE_ID");
        private By CertificationCost = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_COST_TYPE_ID_1");
        private By CertificationPeriod = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_PRD_FLAG_1");
        private By CertificationPast = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CERT_INCL_PAST_COMPLETION_1");
        private By CertificationObjective = By.Id("TabMenu_ML_BASE_HEAD_EditObjectives_COBJ_OBJECTIVE");
        private By Certificationsearcheditem = By.Id("ctl00_MainContent_ucSearch_rlvSearchResults_ctrl0_lnkDetails");
        private By CertificationOpenAccess = By.Id("MainContent_ucPrimaryActions_FormView1_EnrollCertButtonFlag");
        private By CertificationSerachFor = By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor");
        private By CertificationSearchType = By.Id("ddlSearchType");
        private By CertificationViewUserGoToButton = By.Id("TabMenu_ML_BASE_TAB_Search_CONTENT_SEARCH_GoButton_1");
        private By CertificationViewUserSearchText = By.Id("TabMenu_ML_BASE_ACT_ViewUsers_SearchFor");
        private By CertificationViewSearchUserButton = By.Id("TabMenu_ML_BASE_ACT_ViewUsers_ML.BASE.BTN.Search");
        private By CertificationViewHistoryButton = By.Id("TabMenu_ML_BASE_ACT_ViewUsers_LMS_USER_GoButton_1");
        private By CertificationCertifyRd = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_CH_STATUS_ID_0");
        private By CertificationSuspendRd = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_CH_STATUS_ID_1");
        private By CertificationRevokeRd = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_CH_STATUS_ID_2");
        private By CertificationTakeAction = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_ML.BASE.BTN.TakeAction");
        private By CertificationProbIcon = By.Id("MainContent_ucCertSummary_imgCertProb");
        private By CertificationOkIcon = By.Id("MainContent_ucCertSummary_imgCertOk");
        private By CertificationExpiredCount = By.Id("MainContent_ucCertSummary_pnlExpired");
        private By CertificationInProgressCount = By.Id("MainContent_ucCertSummary_pnlStarted");
        private By CertificationCompletedCount = By.Id("MainContent_ucCertSummary_pnlCompleted");
        private By CertificationRevokeCount = By.Id("MainContent_ucCertSummary_pnlRevoked");
        private By CertificationHistoryChangeDate = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_PRG_COMPLETE_DATE||DATEPICKER_dateInput");
        private By CertificationHistoryChangeReason = By.Id("TabMenu_ML_BASE_LBL_CertificationHistory_CH_REASON");
        private By CertificationSummaryLink = By.Id("MainContent_ucCertSummary_lnkCert");
        private By TranscriptCertificationLink = By.Id("MainContent_ucQLinks_lnkCert");
        private By CertificationLinkonTranscript = By.Id("ctl00_MainContent_UC2_RadGrid1_ctl00_ctl04_lnkDetails");
        private By CertTranscriptsearchforbtn = By.Id("MainContent_UC1_txtSearchFor");

        private By CertTranscriptprintbtn = By.XPath("//a[contains(.,'Print')]"); //By.Id("MainContent_UC1_MLinkButton1");// not using id bcoz differs on ff and ie
        private By CertTranscriptprintpagelink = By.Id("ctl00_MainContent_UC2_RadGrid1_ctl00_ctl04_lnkDetails");

        private string CertTranscriptprintpagetitle = "Certifications";
        private By CertTranscriptsaveaspdfbtn = By.XPath("//a[contains(.,'Save as PDF')]");//By.Id("MainContent_UC1_SaveAsPDF");// not using id bcoz differs on ff and ie
        private string CertTranscriptpdfpagetitle = "MyCertificationsPrint.aspx";
    }
}
