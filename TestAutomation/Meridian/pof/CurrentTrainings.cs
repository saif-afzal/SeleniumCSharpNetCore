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
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Selenium2.Meridian.P1.MyResponsibilities.Training;

namespace Selenium2.Meridian
{
    public class CurrentTrainings
    {
        private readonly IWebDriver driverobj;

        public CurrentTrainings(IWebDriver driver)
        {
            driverobj = driver;
        }

        public bool iscurrenttraining()
        {
            bool result = false;

            try
            {

                result = driverobj.existsElement(lbl_currenttraining);

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_blogType(string browserstr)
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(By.CssSelector("button[title='All content types']"));
                driverobj.GetElement(By.CssSelector("button[title='All content types']")).ClickWithSpace();
                //driverobj.WaitForElement(chk_allcontent);
                driverobj.WaitForElement(chk_blog);
                CheckReleventCheckBoxForTraning("Blog");
                clikonFilterbutton();
                result = driverobj.ElementNotPresent(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "ct1" + "')]"));
                if (result == false)
                {
                    return false;
                }
                result = driverobj.existsElement(By.XPath("//a[contains(.,'" + "testblog_" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_onlineType(string browserstr, bool enableBlogClick)
        {
            bool result = false;

            try
            {

                clikonResetbutton();
                driverobj.WaitForElement(By.CssSelector("button[title='All content types']"));
                driverobj.GetElement(By.CssSelector("button[title='All content types']")).ClickWithSpace();
                CheckReleventCheckBoxForTraning("Online");
                clikonFilterbutton();
                result = driverobj.ElementNotPresent(By.XPath("//a[contains(.,'" + "testblog_" + "ctblogs" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
                if (result == false)
                {

                    return false;
                }

                result = driverobj.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "ct1" + "')]"));


            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_AllType(string browserstr)
        {
            bool result = false;
            try
            {
                clikonResetbutton();
                bool blog_Result = driverobj.existsElement(By.XPath("//a[contains(.,'" + "testblog_" + ExtractDataExcel.token_for_reg + browserstr + "')]"));
                bool GC_Result = driverobj.existsElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr + "ct1" + "')]"));
                if (blog_Result && GC_Result) { result = true; }

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_started_begin()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_start_begins);
                driverobj.GetElement(lnk_start_begins).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_firstsectionstart);
                if (driverobj.GetElement(lbl_firstsectionstart).Text.Trim() == "Not Started" || driverobj.GetElement(lbl_lastsectionstart).Text.Trim() == "Started")
                {
                    result = true;
                }
                else
                {
                    return false;
                }
                driverobj.WaitForElement(lnk_start_begins);
                driverobj.GetElement(lnk_start_begins).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_firstsectionstart);
                if (driverobj.GetElement(lbl_firstsectionstart).Text.Trim() == "Started" || driverobj.GetElement(lbl_lastsectionstart).Text.Trim() == "Not Started")
                {
                    result = true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Click_due_end()
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(lnk_due_end);
                driverobj.GetElement(lnk_due_end).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_firstsectionend);
                if (driverobj.GetElement(lbl_firstsectionend).Text.Trim().Contains("Due Soon") || driverobj.GetElement(lbl_lastsectionend).Text.Trim().Contains("No Due Date"))
                {
                    result = true;
                }
                else
                {
                    return false;
                }
                driverobj.WaitForElement(lnk_due_end);
                driverobj.GetElement(lnk_due_end).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_firstsectionend);
                if (driverobj.GetElement(lbl_firstsectionend).Text.Trim().Contains("Started") || driverobj.GetElement(lbl_lastsectionend).Text.Trim().Contains("No Due Date"))
                {
                    result = true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool click_all()
        {
            try
            {
                driverobj.WaitForElement(allstatuses_dropdown);
                driverobj.GetElement(allstatuses_dropdown).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool onlinecourses()
        {
            try
            {
                driverobj.WaitForElement(allcontenttype_dropdown);
                driverobj.GetElement(allcontenttype_dropdown).ClickWithSpace();

                driverobj.WaitForElement(online_checkbox);
                driverobj.GetElement(online_checkbox).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool course_dropdown()
        {
            try
            {
                driverobj.WaitForElement(gen_dropdown);
                driverobj.GetElement(gen_dropdown).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool hidebtn_click()
        {
            try
            {
                driverobj.WaitForElement(By.Id("btnHide"));
                driverobj.GetElement(By.Id("btnHide")).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool gencourse_exists()
        {
            try
            {
                driverobj.WaitForElement(gencourse);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        public bool emptyspace_click()
        {
            try
            {
                driverobj.WaitForElement(emptyspace);
                driverobj.GetElement(emptyspace).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }
        public void CheckReleventCheckBoxForTraning(string type)
        {
            try
            {
                List<IWebElement> allCheckBoxes = driverobj.FindElements(By.CssSelector("label[class='checkbox']")).ToList();
                foreach (var item in allCheckBoxes)
                {
                    if (item.Text.ToLower().Contains(type.ToLower()))
                    { item.Click(); Thread.Sleep(1000); }
                }
            }
            catch (Exception)
            {

            }
        }
        public bool ValidateAllPossibleActionforAICCTraningType(string browserstr, string courseType)
        {
            try
            {
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                #endregion
                ValidateEnrollAction_Any_Course(browserstr, courseType);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                ValidateCancellEnrollAction_Any_Course(browserstr, courseType);
                ValidateOpenAction_Any_Course(browserstr, courseType);
                ValidateResumeAction_Any_Course(browserstr, courseType);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        public bool ValidateAllPossibleActionforSCORM_ClassRoom_TraningType(string browserstr, string courseType)
        {
            try
            {
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                #endregion
                if (courseType.Equals("ClassRoom Course"))
                {
                    driverobj.IsCorrectButtonDisplayed_AfterAcction("View", By.LinkText("View"), browserstr, courseType);
                    driverobj.ClickOn_TraningType(By.LinkText("View"), browserstr, courseType);
                    if (driverobj.existsElement(By.XPath("//h1[contains(.,'" + ExtractDataExcel.MasterDic_classrommcourse["Title"] + browserstr + "')]")))
                    {
                        if (driverobj.existsElement(By.CssSelector("input[name*='btnEnroll']")))
                        {
                            driverobj.GetElement(By.CssSelector("input[name*='btnEnroll']")).Click();
                            Thread.Sleep(3000);
                            if (driverobj.existsElement(sucessMessage) && driverobj.existsElement(By.LinkText("Cancel Enrollment")))
                            { return true; }
                            else return false;
                        }
                        else return false;

                    }
                    else { return false; }
                }
                else
                {
                    ValidateEnrollAction_Any_Course(browserstr, courseType);
                    ValidateCancellEnrollAction_Any_Course(browserstr, courseType);
                    ValidateOpenAction_Any_Course(browserstr, courseType);
                    ValidateResumeAction_Any_Course(browserstr, courseType);
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal bool ValidateAllPossibleActionforClassRoomTraningType(string browserstr, string courseType)
        {
            try
            {
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                #endregion
                ValidateEnrollAction_Any_Course(browserstr, courseType);
                ValidateCancellEnrollAction_Any_Course(browserstr, courseType);
                ValidateOpenAction_Any_Course(browserstr, courseType);
                ValidateResumeAction_Any_Course(browserstr, courseType);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal bool ValidateAllPossibleActionforCurriculumTraningType(string browserstr, string courseType)
        {
            try
            {
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                #endregion

                driverobj.IsCorrectButtonDisplayed_AfterAcction("View", By.LinkText("View"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.XPath("(//a[contains(text(),'View')])[2]"), browserstr, courseType);//View Button for Curriculum

                ValidateEnrollAfterViewAndClick(browserstr, courseType);
                if (!driverobj.existsElement(sucessMessage))
                { return false; }
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();

                ValidateCancellEnrollAction_Any_Course(browserstr, courseType);
                driverobj.WaitForElement(sucessMessage);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();

                driverobj.IsCorrectButtonDisplayed_AfterAcction("View", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.XPath("(//a[contains(text(),'View')])[2]"), browserstr, courseType);
                if (driverobj.existsElement(By.XPath("//h1[contains(.,'" + Variables.curriculumTitle + browserstr + "')]")))
                { return true; }
                else { return false; }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal bool ValidateAllPossibleActionforOJTTraningType(string browserstr, string courseType)
        {
            try
            {
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                #endregion
                driverobj.IsCorrectButtonDisplayed_AfterAcction("View", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.XPath("(//a[contains(text(),'View')])[2]"), browserstr, courseType);//View Button for Curriculum
                ValidateEnrollAfterViewAndClickOJT(browserstr, courseType);
                if (!driverobj.existsElement(sucessMessage))
                { return false; }
                ValidateAccessAfterViewAndClickOJT(browserstr, courseType);
                driverobj.WaitForElement(alertForAccess);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal bool ValidateAllPossibleActionforDocumentTraningType(string browserstr, string courseType)
        {
            try
            {
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                #endregion
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Open Item", By.LinkText("Open Item"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.LinkText("Open Item"), browserstr, courseType);//Open Item Button for Docuemnt
                
                driverobj.WaitForElement(By.XPath("//h1[contains(.,'" + ExtractDataExcel.MasterDic_document["Title"] + browserstr + "')]"));
                driverobj.ClickEleJs(By.CssSelector("input[id*='_LaunchAttemptFirst']"));
                Thread.Sleep(5000);
                driverobj.SelectWindowClose2("Google", "Details");

                if (!driverobj.existsElement(alertForAccess)) { return false; }
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                ValidateCancellEnrollAction_Any_Course(browserstr, courseType);// It verify Mark Complete Button 
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal bool ValidateAllPossibleActionforBlog(string browserstr, string courseType)
        {
            try
            {
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                driverobj.FindElement(By.XPath("//button[@title='All content types']")).Click();
                CheckReleventCheckBoxForTraning("Blog");
                driverobj.FindElement(By.XPath("//input[@id='MainContent_UC3_btnFilter']")).Click();
                #endregion
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Open Item", By.CssSelector("a[id*='DefaultComboBtn']"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.LinkText("Open Item"), browserstr, courseType);
                string originalHandle = driverobj.CurrentWindowHandle;
                Thread.Sleep(2000);
                driverobj.SelectWindowClose2("Blogs", "Details");
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                ValidateCancellEnrollAction_Any_Course(browserstr, courseType);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal bool ValidateAllPossibleActionforFAQ(string browserstr, string courseType)
        {
            try
            {
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                #endregion
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Open Item", By.LinkText("Open Item"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_FAQ["Question"]+browserstr+"adminfaq1"+"')]/../../../td[4]/div/a"), browserstr, courseType);
                driverobj.SelectWindowClose2("FAQs", "Current Training");
                driverobj.WaitForElement(ObjectRepository.TranscriptHome);
                driverobj.GetElement(ObjectRepository.TranscriptHome).Click();
                List<IWebElement> ele = driverobj.FindElements(allTranings_Transcrit).ToList();
                foreach (var item in ele)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_FAQ["Question"] + browserstr + "adminfaq1")) { return true; }
                }
                return false;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal bool ValidateAllPossibleActionforCollaborationSpace(string browserstr, string courseType)
        {
            try
            {
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                #endregion
                #region Join Button
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Join", By.LinkText("Join"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.LinkText("Join"), browserstr, courseType);//Join Button Click
                if (!driverobj.existsElement(sucessMessage)) { throw new Exception("Sucess messgae is not coming after Join the space" + courseType); }
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Access Space", By.LinkText("Access Space"), browserstr, courseType);
                #endregion
                #region Leave Space
                driverobj.ClickOn_TraningType(By.LinkText("Access Space"), browserstr, courseType);
                driverobj.GetElement(By.Id("btnJoin")).ClickWithSpace();
                if (!driverobj.existsElement(sucessMessage)) { throw new Exception("Sucess messgae is not coming after Leace the space" + courseType); }
                #endregion
                #region Access Space
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Join", enrollButton, browserstr, courseType);
                driverobj.ClickOn_TraningType(enrollButton, browserstr, courseType);
                driverobj.ClickOn_TraningType(openItemButton, browserstr, courseType);
                Thread.Sleep(10000);
                driverobj.waitforframe(By.Id("CFFrame"));
                driverobj.WaitForElement(By.CssSelector("div[class*='axero-space-mobile-navigation']"));
                if (!driverobj.existsElement(By.CssSelector("div[class*='axero-space-mobile-navigation']"))) { throw new Exception("Collaboration Space is not redirecting to Collaboration Space Launch page after Access Item."); }
                #endregion
                #region Mark Complete
                driverobj.SwitchTo().DefaultContent();
                TrainingHomeobj.Click_MyOwnLearning();
                Thread.Sleep(2000);
                TrainingHomeobj.lnk_CurrentTraining_click();
                driverobj.ClickOn_TraningType(dropDown_CourseAccess, browserstr, courseType);
                driverobj.GetElement(By.Id("btnMarkComplete")).Click();
                Thread.Sleep(2000);
                driverobj.waitforframe(switchToFrame);
                driverobj.GetElement(markCompleteButton_Frame).Click();
                Thread.Sleep(2000);
                if (!driverobj.existsElement(sucessMessage)) { throw new Exception("Mark complete messgae is not coming after doing compelte the traning for " + courseType); }
                #endregion
                #region Verify in Transcript
                driverobj.WaitForElement(ObjectRepository.TranscriptHome);
                driverobj.GetElement(ObjectRepository.TranscriptHome).Click();
                Thread.Sleep(5000);
                List<IWebElement> ele = driverobj.FindElements(allTranings_Transcrit).ToList();
                foreach (var item in ele)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_CSpace["Title"] + browserstr)) { return true; }
                }
                #endregion
                return false;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal bool ValidateAllPossibleActionforSiteSurvey(string browserstr, string courseType)
        {
            try
            {
                #region Before Search select online tranings
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                #endregion
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Open Item", openItemButton, browserstr, courseType);
                driverobj.ClickOn_TraningType(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"] + browserstr + "')]/../../../td[4]/div/a"), browserstr, courseType);
                //string originalHandle = driverobj.CurrentWindowHandle;
                //Thread.Sleep(2000);
                driverobj.SwitchWindow("Take Survey");
               
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_DisplaySurvey_SURVEY_ELEMENT_0")).SendKeys("Test");
                Thread.Sleep(2000);
                driverobj.GetElement(By.Id("SubmitButton")).Click();
                //driverobj.Close();
                Thread.Sleep(3000);
                //driverobj.SwitchTo().Window(originalHandle);
                Thread.Sleep(2000);
                driverobj.SelectWindowClose2("Take Survey", "Current Training");
                driverobj.WaitForElement(ObjectRepository.TranscriptHome);
                driverobj.GetElement(ObjectRepository.TranscriptHome).Click();
                List<IWebElement> ele = driverobj.FindElements(allTranings_Transcrit).ToList();
                foreach (var item in ele)
                {
                    if (item.Text.Contains(ExtractDataExcel.MasterDic_Survey["Title"] + browserstr) && item.Text.ToLower().Contains("completed"))
                    {

                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        internal void ValidateEnrollAfterViewAndClick(string browserstr, string courseType)
        {
            if (driverobj.existsElement(enrollCurriculum))
            {
                driverobj.GetElement(enrollCurriculum).Click();
                Thread.Sleep(2000);
            }
            else
                throw new Exception("Enroll button is not comming after click on view button for " + courseType + " course type.");
        }
        internal void ValidateEnrollAfterViewAndClickOJT(string browserstr, string courseType)
        {
            if (driverobj.existsElement(enrollOJT))
            {
                driverobj.ClickEleJs(enrollOJT);
                Thread.Sleep(2000);
            }
            else
                throw new Exception("Enroll button is not comming after click on view button for " + courseType + " course type.");
        }
        internal void ValidateAccessAfterViewAndClickOJT(string browserstr, string courseType)
        {
            if (driverobj.existsElement(launchOJT_AccessItem))
            {
                driverobj.ClickEleJs(launchOJT_AccessItem);
                Thread.Sleep(2000);
            }
            else
                throw new Exception("Access Item button is not comming after click on Enroll button for " + courseType + " course type.");
        }
        internal void SearchTraningAndOpneItem(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_aicc["Title"] + browserstr + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_aicc["Title"] + browserstr + "')]")).ClickWithSpace();
                Thread.Sleep(2000);
                driverobj.WaitForElement(enrollButton);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void ValidateEnrollAction_Any_Course(string browserstr, string courseType)
        {
            try
            {
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Enroll", By.LinkText("Enroll"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.LinkText("Enroll"), browserstr, courseType);
                if (courseType.Equals("SCORM"))
                {
                    Thread.Sleep(2000);
                    driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    Thread.Sleep(1000);
                    driverobj.GetElement(By.Id("MainContent_UC1_btnCourseEnroll")).ClickWithSpace();
                    driverobj.WaitForElement(sucessMessage);
                }
                //else
                //{
                //    driverobj.WaitForElement(By.CssSelector("span[class='multiselect-selected-text']"));
                //}
                if (courseType.Equals("AICC"))
                {
                    driverobj.IsCorrectButtonDisplayed_AfterAcction("Enroll", By.XPath("//a[contains(.,'Enroll')]"), browserstr, courseType);
                }
                else
                {
                    driverobj.IsCorrectButtonDisplayed_AfterAcction("Open Item", By.XPath("//a[contains(.,'Open Item')]"), browserstr, courseType);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal void ValidateCancellEnrollAction_Any_Course(string browserstr, string courseType)
        {
            try
            {
                driverobj.ClickOn_TraningType(By.LinkText("Toggle Dropdown"), browserstr, courseType);
                if (courseType.Equals("Document"))
                {
                    //  driverobj.ClickEleJs(By.XPath("//a[contains(.,'ojt_" + ExtractDataExcel.token_for_reg + browserstr + "')]/../../../td[4]/div/a[2]"));

                    driverobj.ClickEleJs(By.XPath("//a[contains(text(),'Mark Complete')]"));
                    driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    driverobj.WaitForElement(markCompleteCTPopup_Frame);
                    driverobj.GetElement(markCompleteCTPopup_Frame).ClickWithSpace();
                }
                else if(courseType.Equals("Blog")) 
           
                {
                                        
                   // driverobj.ClickEleJs(By.XPath("//a[contains(.,'testblog_"+ExtractDataExcel.token_for_reg + browserstr+ "')]/../../../td[4]/div/a[2]/span"));
                    driverobj.GetElement(By.LinkText("Mark Complete")).ClickWithSpace();
                    driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    driverobj.WaitForElement(markCompleteCTPopup_Frame);
                    driverobj.GetElement(markCompleteCTPopup_Frame).ClickWithSpace();
                }
                    else if(courseType.Equals("AICC"))
                {
                    driverobj.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton"));
                    TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                        TrainingHomeobj.Click_MyOwnLearning();
                    TrainingHomeobj.lnk_CurrentTraining_click();
                    driverobj.ClickEleJs(By.XPath("//a[contains(.,'AICC_" + ExtractDataExcel.token_for_reg + browserstr + "')]/../../../td[4]/div/a[2]/span"));
                        driverobj.ClickEleJs(By.LinkText("Cancel Enrollment"));

                    }
                else { driverobj.ClickEleJs(By.LinkText("Cancel Enrollment")); }
                Thread.Sleep(3000);
                if (!driverobj.existsElement(sucessMessage)) { throw new Exception("Sucess messgae is not coming after access the itme for course" + courseType); }
                if (courseType.Equals("Curriculum"))
                { driverobj.IsCorrectButtonDisplayed_AfterAcction("View", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType); }
                else if (courseType.Equals("Document") || courseType.Equals("Blog"))
                { //Blank -beacuse after complete this document- It is not displaying in the current traning section 
                }
                else
                { driverobj.IsCorrectButtonDisplayed_AfterAcction("Enroll", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType); }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal void SwitchToNewWindow(string cousetype)
        {
            driverobj.WaitForElement(By.CssSelector("input[id*='_LaunchAttemptFirst']"));
            driverobj.GetElement(By.CssSelector("input[id*='_LaunchAttemptFirst']")).Click();
            Thread.Sleep(3000);
            //string originalHandle = driverobj.CurrentWindowHandle;
            Thread.Sleep(2000);
            if (cousetype.Equals("Blog")) { driverobj.SwitchWindow("Blogs"); }
            else { driverobj.SelectWindowClose2("Take Survey", "Details"); }
            //driverobj.Close();
            Thread.Sleep(3000);
            //driverobj.SwitchTo().Window(originalHandle);
        }
        public bool select_OverdueTraining()
        {
            try
            {
                driverobj.WaitForElement(allStatus);
                driverobj.GetElement(allStatus).ClickWithSpace();
                driverobj.WaitForElement(dropdown_OverDue);
                driverobj.GetElement(dropdown_OverDue).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                throw;
                return false;
            }
            return true;
        }
        internal bool select_Training_DropDown(string TraningType)
        {
            try
            {
                if (TraningType.Equals("RequiredTraning"))
                { select_RequiredTraining_DropDown(); }
                else if (TraningType.Equals("ExtendedTraning"))
                { select_Extended_DropDown(); }
                else if (TraningType.Equals("DueSoonTraning"))
                { select_DueSoonTraining(); }
                else if (TraningType.Equals("OverDueTraning"))
                { select_OverdueTraining(); }
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }
        internal bool select_RequiredTraining_DropDown()
        {
            try
            {
                driverobj.WaitForElement(allStatus);
                driverobj.GetElement(allStatus).ClickWithSpace();
                driverobj.WaitForElement(dropdown_RequiredTraning);
                driverobj.GetElement(dropdown_RequiredTraning).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                throw;
                return false;
            }
            return true;
        }
        internal bool select_Extended_DropDown()
        {
            try
            {
                driverobj.WaitForElement(allStatus);
                driverobj.GetElement(allStatus).ClickWithSpace();
                driverobj.WaitForElement(dropdown_ExtendedTraning);
                driverobj.GetElement(dropdown_ExtendedTraning).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                throw;
                return false;
            }
            return true;
        }
        public bool select_DueSoonTraining()
        {
            try
            {
                driverobj.WaitForElement(allStatus);
                driverobj.GetElement(allStatus).ClickWithSpace();
                driverobj.WaitForElement(dropdown_DueSoon);
                driverobj.GetElement(dropdown_DueSoon).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                throw;
                return false;
            }
            return true;
        }
        //Select Extended checkbox from All Statuses dropdown list:
        public bool select_Extendedtraining()
        {
            try
            {
                driverobj.WaitForElement(allStatus);
                driverobj.GetElement(allStatus).ClickWithSpace();
                driverobj.WaitForElement(extended_checkbox);
                driverobj.GetElement(extended_checkbox).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }

        //Click on Filter button to filter:
        public bool clikonFilterbutton()
        {
            try
            {
                driverobj.WaitForElement(filter_button);
                driverobj.GetElement(filter_button).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }
        public bool clikonResetbutton()
        {
            try
            {
                driverobj.WaitForElement(reset_button);
                driverobj.GetElement(reset_button).ClickWithSpace();

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }
        internal bool VerifyRequiredTraningFilter_CurrentTraning(string browserstr, string TraningType)
        {
            TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
            TrainingHomeobj.lnk_CurrentTraining_click();
            if (!select_Training_DropDown(TraningType)) { return false; }
            Thread.Sleep(1000);
            clikonFilterbutton();
            Thread.Sleep(3000);
            int cnt = driverobj.countelements(By.XPath("//strong[contains(.,'Due Soon')]"));
            int cnt1 = driverobj.countelements(By.XPath("//span[contains(@id,'lblReqTrainingIcon')]"));
            int cnt2 = driverobj.countelements(By.XPath("//strong[contains(.,'Overdue')]"));
            int cnt3 = driverobj.countelements(By.XPath("//span[@class='fa fa-asterisk text-danger']"));
            if (cnt == cnt1)
            {
                return true;
            }
            else if(cnt2==cnt1)
            {
                return true;
            }
            else if(cnt3==cnt1)
            {
                return true;
            }
            else if(driverobj.existsElement(By.XPath("//strong[contains(.,'Extended')]")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        internal void VerifyTraningonFirst_LastPage(string browserstr, string TraningType)
        {
            try
            {
                VerifyTraning_AllSections(TraningType);
                if (driverobj.existsElement(click_NavigateLastPageResults))
                {
                    driverobj.GetElement(click_NavigateLastPageResults).Click();
                    Thread.Sleep(3000);
                    VerifyTraning_AllSections(TraningType);
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
        }
        internal void VerifyTraning_AllSections(string TraningType)
        {
            List<IWebElement> allSectionsListing = new List<IWebElement>();
            if (TraningType.Equals("RequiredTraning"))
            {
                allSectionsListing = driverobj.FindElements(requiredTraningLable).ToList();
                foreach (var item in allSectionsListing)
                {
                    if (!(item.Text.Contains("Required"))) { throw new Exception(TraningType + "Traning is not coming after applying filter in Current tranings."); }
                }
            }
            else if (TraningType.Equals("ExtendedTraning"))
            {
                allSectionsListing = driverobj.FindElements(extendedTraningLabel).ToList();
                foreach (var item in allSectionsListing)
                {
                    if (!(item.Text.Contains("Extended"))) { throw new Exception(TraningType + "Traning is not coming after applying filter in Current tranings."); }
                }
            }
            else if (TraningType.Equals("DueSoonTraning"))
            {
                allSectionsListing = driverobj.FindElements(extendedTraningLabel).ToList();
                foreach (var item in allSectionsListing)
                {
                    if (!(item.Text.Contains("Due Soon"))) { throw new Exception(TraningType + "Traning is not coming after applying filter in Current tranings."); }
                }
            }
            else if (TraningType.Equals("OverDueTraning"))
            {
                allSectionsListing = driverobj.FindElements(extendedTraningLabel).ToList();
                foreach (var item in allSectionsListing)
                {
                    if (!(item.Text.Contains("Overdue"))) { throw new Exception(TraningType + "Traning is not coming after applying filter in Current tranings."); }
                }
            }
        }
        internal bool LoadingIconAfterApplyFilters_CT()
        {
            try
            {
                //Need to put the login here to move next statement like threading
                clikonFilterbutton();
                return driverobj.existsElement(By.Id("spinner"));
                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
        }
        /*public bool Validateprogressbarforanycourse(string browserstr, string courseTypeforprogressbar)

               {
                   try
                   {
                
                       TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                       TrainingHomeobj.Click_MyOwnLearning();
                       TrainingHomeobj.lnk_CurrentTraining_click();
                       //driverobj.WaitForElement(progressbar_for_Course);
                       //driverobj.GetElement(progressbar_for_Course)

               
                       //ValidateProgressbarfor_Curriculum_Course(browserstr, courseTypeforprogressbar);
                
                       return true;
                   }
                   catch (Exception ex)
                   {
                       ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                       return false;
                   }

               }*/
        internal bool ValidateHide_Course_Transcript_forBlog(string browserstr, string courseType)
        {
            try
            {
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                ClickOn_Hide(browserstr);
                Thread.Sleep(2000);
                driverobj.GetElement(By.CssSelector("button[data-bb-handler='confirm']")).Click();
                Thread.Sleep(2000);
                List<IWebElement> allTranings = driverobj.FindElements(By.CssSelector("tr[id*='ctl00_MainContent_UC3_RadGrid1_']")).ToList();
                foreach (var item in allTranings)
                {
                    if (driverobj.IsCourseDisplayed_CurrentTranings(item, browserstr, courseType))
                    {
                        throw new Exception("After hiding the traning from Current tranings>> It is still showing in Current traning");
                    }
                }
                Resume_TraningFromTranscript(browserstr, courseType);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
           
        }
        internal void Resume_TraningFromTranscript(string browserstr, string courseType)
        {
            bool traningPresentCT = false;
            TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
            TrainingHomeobj.Click_TranscriptLink();
            driverobj.GetElement(By.CssSelector("a[id*='_lnkDetails']")).Click();
            SwitchToNewWindow("Blog");
            TrainingHomeobj.lnk_CurrentTraining_click();
            List<IWebElement> allTranings = driverobj.FindElements(By.CssSelector("tr[id*='ctl00_MainContent_UC3_RadGrid1_']")).ToList();
            foreach (var item in allTranings)
            {
                if (driverobj.IsCourseDisplayed_CurrentTranings(item, browserstr, courseType))
                {
                    traningPresentCT = true;
                    
                }
            }
            if (!(traningPresentCT))
            { throw new Exception("After Resume the traning from Transcript >> Traning is not shwoing in Current Tranings."); }
        }
        internal void ClickOn_Hide(string browserstr)
        {
            try
            {
                driverobj.ClickOn_HideButton(By.CssSelector("a[id*='DropDownBtn']"), browserstr, "Blog", By.Id("btnHide"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private By extended_checkbox = By.XPath("//input[@value='ML.BASE.Extended']");
        private By filter_button = By.XPath("//input[@id='MainContent_UC3_btnFilter']");
        private By reset_button = By.CssSelector("input[id*='_btnReset']");
        private By overdue_checkbox = By.XPath(".//*[@id='MainContent_UC3_pnlFilter']/div/div[1]/span/div/ul/li[9]/a/label/input");
        internal void ValidateOpenAction_Any_Course(string browserstr, string courseType)
        {
            try
            {
                driverobj.ClickOn_TraningType(By.LinkText("Enroll"), browserstr, courseType);
                Thread.Sleep(2000);
                if (courseType.Equals("SCORM"))
                {
                    driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                    driverobj.GetElement(By.Id("MainContent_UC1_btnCourseEnroll")).ClickWithSpace();
                }
                if (courseType.Equals("AICC"))
                {
                    driverobj.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_EnrollButton"));
                    driverobj.ClickEleJs(By.Id("MainContent_ucPrimaryActions_FormView1_LaunchAttemptFirst"));
                    driverobj.SelectWindowClose2("meridianows.skillwsa.com", "Current Training");
                    driverobj.IsCorrectButtonDisplayed_AfterAcction("Resume", resumeButton, browserstr, courseType);
                }
                else
                {
                    driverobj.WaitForElement(sucessMessage);
                    driverobj.IsCorrectButtonDisplayed_AfterAcction("Open Item", By.CssSelector("a[id*='DefaultComboBtn']"), browserstr, courseType);
                    driverobj.ClickOn_TraningType(By.LinkText("Open Item"), browserstr, courseType);
                    if (courseType.Equals("SCORM"))
                    {
                        Thread.Sleep(5000);
                        driverobj.SelectWindowClose2("Meridian Global - Core Domain", "Current Training");
                    }
                    else if (courseType.Equals("AICC"))
                    {
                        driverobj.SelectWindowClose2("meridianows.skillwsa.com", "Current Training");
                    }
                    //  string originalHandle = driverobj.CurrentWindowHandle;
                    Thread.Sleep(2000);

                    driverobj.IsCorrectButtonDisplayed_AfterAcction("Resume", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal void ValidateResumeAction_Any_Course(string browserstr, string courseType)
        {
            try
            {
                TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
                //string originalHandle = driverobj.CurrentWindowHandle;
                TrainingHomeobj.Click_MyOwnLearning();
                TrainingHomeobj.lnk_CurrentTraining_click();
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Resume", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType);
                driverobj.ClickOn_TraningType(By.LinkText("Resume"), browserstr, courseType);
                Thread.Sleep(4000);
                if (courseType.Equals("SCORM"))
                { driverobj.SelectWindowClose2("Meridian Global - Core Domain", "Current Training"); }
                else if(courseType.Equals("AICC"))
                {
                    driverobj.SelectWindowClose2("meridianows.skillwsa.com", "Current Training");
                }
                //driverobj.Close();
                //driverobj.SwitchTo().Window(originalHandle);
                Thread.Sleep(3000);
                driverobj.IsCorrectButtonDisplayed_AfterAcction("Resume", By.CssSelector("a[id*='DefaultBtn']"), browserstr, courseType);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal bool VerifyAccessKeyCourse_InCurrentTraning(string browserstr)
        {
            try
            {
                List<IWebElement> allSectionsListing = driverobj.FindElements(allTranings).ToList();
                foreach (var item in allSectionsListing)
                {
                    if ((item.Text.Contains(ExtractDataExcel.MasterDic_genralcourse["Title"] + browserstr)))
                    {
                        if (!item.Text.Contains("Access expires"))
                        {
                            throw new Exception("Access Expire indicator text is not comming under title name of the course.");
                        }
                        if (!item.FindElement(By.CssSelector("span[id*='_lblAccessKeyIcon']")).Displayed)
                        {
                            throw new Exception("Access Expire indicator Icon is not comming under title name of the course.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
                return false;
            }
            return true;
        }
        private By accessKeyIcon = By.CssSelector("span[id*='_lblAccessKeyIcon']");
        private By lbl_currenttraining = By.XPath("//h2[contains(.,'Current Training')]");
        private By btn_creategoto = By.Id("TabMenu_ML_BASE_WF_Skins_GoPageActionsMenu");
        private By btn_allcontenttype = By.XPath(".//*[@id='MainContent_UC3_pnlHeader']/div[1]/span[2]/div/button");
        private By chk_allcontent = By.XPath(".//*[@id='MainContent_UC3_pnlHeader']/div[1]/span[2]/div/ul/li[1]/a/label/input");
        private By chk_blog = By.XPath(".//*[@id='MainContent_UC3_pnlHeader']/div[1]/span[2]/div/ul/li[2]/a/label/input");
        private By chk_online = By.XPath(".//*[@id='MainContent_UC3_pnlHeader']/div[1]/span[2]/div/ul/li[3]/a/label/input");
        private By lnk_beginstart = By.XPath("//a[contains(.,'Started/Begins')]");

        private By lbl_firstsectionstart = By.XPath(".//*[@id='ctl00_MainContent_UC3_RadGrid1_ctl00_ctl04_phStartDate']/strong");
        private By lbl_lastsectionstart = By.XPath(".//*[@id='ctl00_MainContent_UC3_RadGrid1_ctl00_ctl06_phStartDate']/strong");
        private By allcontenttype_dropdown = By.XPath("//div[@id='MainContent_UC3_pnlHeader']/div/span[2]/div/button");
        private By allstatuses_dropdown = By.XPath(".//*[@id='MainContent_UC3_pnlHeader']/div[1]/span[1]/div/button");
        private By online_checkbox = By.XPath("//div[@id='MainContent_UC3_pnlHeader']/div/span[2]/div/button");
        private By gen_dropdown = By.XPath(".//*[@id='DropDownBtn']");
        private By hide_btn = By.XPath(".//*[@id='ctl00_MainContent_UC3_RadGrid1_ctl00_ctl04_pnlActionComboBtn']/ul/li/a");
        private By gencourse = By.XPath("ctl00_MainContent_UC3_RadGrid1_ctl00_ctl04_lnkDetails");
        private By emptyspace = By.XPath(".//*[@id='ctl00_ctl00_MainContent_UC3Panel']/div");

        private By lnk_due_end = By.XPath("//a[contains(.,'Due/Ends')]");
        private By lnk_start_begins = By.XPath("//a[contains(.,'Started/Begins')]");
        private By lbl_firstsectionend = By.XPath(".//*[@id='ctl00_MainContent_UC3_RadGrid1_ctl00_ctl04_pnlDueDate']/strong");
        private By lbl_lastsectionend = By.XPath(".//*[@id='ctl00_MainContent_UC3_RadGrid1_ctl00_ctl06_pnlDueDate']/strong");
        private By multiSelectClick = By.CssSelector("button[class*='multiselect']");
        private By enrollButton = By.CssSelector("a[id='DefaultBtn']");
        private By openItemButton = By.CssSelector("a[id='DefaultComboBtn']");
        private By cancellEnrollButton = By.CssSelector("a[id='btnCancelEnroll']");
        private By sucessMessage = By.XPath("//div[@class='alert alert-success']");
        private By alertForAccess = By.XPath("//div[@class='alert alert-info']");
        private By resumeButton = By.CssSelector("a[id='DefaultBtn']");
        private By allTranings = By.CssSelector("tr[id*='ctl00_MainContent_UC3_RadGrid1_']");
        private By launchOJT_AccessItem = By.CssSelector("input[name*='OJTLaunchAttempt']");
        private By enrollOJT = By.CssSelector("input[name*='EnrollOJT']");
        private By enrollCurriculum = By.CssSelector("input[id*='_EnrollCurriculumButtonFlag']");
        private By markCompleteCT = By.Id("btnMarkComplete");
        private By markCompleteCTPopup_Frame = By.Id("MainContent_UC1_btnMarkComplete");
        private By allTranings_Transcrit = By.CssSelector("tr[id*='MainContent_UC1_RadGrid']");
        private By switchToFrame = By.CssSelector("iframe[class='k-content-frame']");
        private By markCompleteButton_Frame = By.Id("MainContent_UC1_btnMarkComplete");
        private By dropDown_CourseAccess = By.CssSelector("a[id='DropDownBtn']");
        private By dropdown_DueSoon = By.CssSelector("input[value='ML.BASE.DueSoon']");
        private By dropdown_RequiredTraning = By.CssSelector("input[value='ML.BASE.ReqTraining");
        private By dropdown_ExtendedTraning = By.CssSelector("input[value='ML.BASE.Extended");
        private By allStatus = By.CssSelector("button[title='All Statuses']");
        private By dropdown_OverDue = By.CssSelector("input[value='ML.BASE.Overdue']");
        private By click_NavigateLastPageResults = By.CssSelector("a[title='Last']");
        private By extendedTraningLabel = By.CssSelector("div[id*='_pnlDueDate']");
        private By requiredTraningLable = By.CssSelector("ul[class='list-inline']");

        internal static bool? GetCurrentEnrolledTraining(string classroomcoursetitle)
        {
            Thread.Sleep(2000);
            return Driver.GetElement(By.LinkText(classroomcoursetitle)).Text.Contains(classroomcoursetitle);
        }

        internal static void ClickAction()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//a[@id='DefaultComboBtn_BB395ED4BFA148A8A2900EA7406A46DD']"));
            
        }
        public static string GetActionStatus()
        {
            
           return Driver.GetElement(By.LinkText("Cancel Enrollment")).Text;

        }

        public static object GetActionStatusForCancelEnrollment()
        {
            if (Driver.existsElement(By.LinkText("Cancel Enrollment")))
            {
                return true;
            }
            else
            {
                return "Cancle Enrollment not display";
            }
                
        }
        //private By progressbar_for_Course = By.Id("ctl00_MainContent_UC3_RadGrid1_ctl00_ctl04_pnlProgress");
        //private By progressbar_for_Course = By.ClassName("progress-bar progress-bar-none");
    }
}
