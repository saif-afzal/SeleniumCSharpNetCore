using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;
using NUnit.Framework;
using System.Threading;

namespace Selenium2.Meridian
{
    class ManageGradebook
    {
        public bool GradebookConsoleTab_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(GradebookConsoleTab);
                driver.GetElement(GradebookConsoleTab).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"", driver);

            }
            return true;
        }
        public bool Populate_SearchText(IWebDriver driverobj, string searchtext)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(Search_TextBox);
                driverobj.GetElement(Search_TextBox).Clear();
                driverobj.GetElement(Search_TextBox).SendKeysWithSpace(searchtext);

                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }
        public bool Click_Search(IWebDriver driverobj)
        {
            bool result = false;

            try
            {

                driverobj.WaitForElement(Search_button);
                driverobj.GetElement(Search_button).ClickWithSpace();

                driverobj.WaitForElement(SearchResult_WaitElement);

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }

            return result;
        }

        public bool Create_Gradebook(IWebDriver driver,string browserstr)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(By.XPath("//a[contains(text(),'" + Variables.classroomCourseTitle + browserstr + "')]"));
                driver.WaitForElement(By.XPath("//a[contains(text(),'" + Variables.sectionTitle + browserstr + "')]"));
                driver.WaitForElement(By.XPath("//td[contains(text(),'" + Variables.sectionTitle + browserstr + "')]/following-sibling::td/input"));
                driver.GetElement(By.XPath("//td[contains(text(),'" + Variables.sectionTitle + browserstr + "')]/following-sibling::td/input")).ClickWithSpace();
                Thread.Sleep(3000);
                //driver.SelectFrame();
                driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driver.WaitForElement(Create_Button);
                driver.GetElement(Create_Button).ClickWithSpace();
                driver.SwitchTo().DefaultContent();
                Thread.Sleep(2000);
                Assert.IsTrue(driver.existsElement(Success_Message));

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool Add_Assigment(IWebDriver driver, string Title, string desc, string ItemWeight)
        {
            bool result = false;
            string format = "yyyy/M/d";

            try
            {
                driver.WaitForElement(AddAssignment_Button);
                driver.GetElement(AddAssignment_Button).ClickWithSpace();
                driver.WaitForElement(SaveExit_Button);
                driver.GetElement(Assgnmnt_Title).SendKeysWithSpace(Title);
                driver.GetElement(Assgnmnt_Desc).SendKeysWithSpace(desc);
                driver.GetElement(Assgnmnt_ItemWeight).SendKeysWithSpace(ItemWeight);
                driver.GetElement(dtp_duedate).SendKeysWithSpace(DateTime.Now.AddMonths(1).ToString(format));
                driver.GetElement(SaveExit_Button).ClickWithSpace();
                Thread.Sleep(3000);
                Assert.IsTrue(driver.existsElement(Success_Message));

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool Edit_Assigment(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.FindSelectElementnew(SecondAssignment_Order, "1");
                driver.GetElement(By.Id("MainContent_UC1_ctl00_btnSave")).ClickWithSpace();
                driver.WaitForElement(Error_Message);
                driver.FindSelectElementnew(SecondAssignment_Order, "2");
                driver.GetElement(By.Id("MainContent_UC1_ctl00_btnSave")).ClickWithSpace();
                Thread.Sleep(3000);
                Assert.IsTrue(driver.existsElement(Success_Message));

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool Remove_Assigment(IWebDriver driver)
        {
            bool result = false;

            try
            {
               // driver.GetElement(SecondAssignment_ChkBox).ClickWithSpace();
                driver.ClickEleJs(SecondAssignment_ChkBox);
                driver.GetElement(AssignmntRemove_Button).ClickWithSpace();
                driver.findandacceptalert();
                Thread.Sleep(3000);
                Assert.IsTrue(driver.existsElement(Success_Message));

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool Manage_Gradebook(IWebDriver driver, string browserstr)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(By.XPath("//td[contains(text(),'" + Variables.sectionTitle+browserstr + "')]/following-sibling::td[1]/a")); //Managegradebook
                driver.GetElement(By.XPath("//td[contains(text(),'" + Variables.sectionTitle+browserstr + "')]/following-sibling::td[1]/a")).ClickWithSpace();
                
                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool Show_Gradebook(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(ShowGradebook_button);
                driver.GetElement(ShowGradebook_button).ClickWithSpace();
                driver.WaitForElement(Success_Message);
                driver.WaitForElement(HideGradebook_button);

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool Hide_Gradebook(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(HideGradebook_button);
                driver.GetElement(HideGradebook_button).ClickWithSpace();
                driver.findandacceptalert();
                driver.WaitForElement(Success_Message);
                driver.WaitForElement(ShowGradebook_button);

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool click_EnterGrades(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_EnterGrades);
                driver.GetElement(btn_EnterGrades).ClickWithSpace();
                driver.WaitForElement(btn_SaveGrades);

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public string verify_enrolleduser(IWebDriver driver)
        {
            string actualresult = string.Empty;

            try
            {
                driver.WaitForElement(lbl_enrolledusername);
                actualresult = driver.GetElement(lbl_enrolledusername).Text;

                
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return actualresult;
        }

        public bool click_returnOnEnterGradesPage(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_returnEnterGradesPage);
                driver.GetElement(btn_returnEnterGradesPage).ClickWithSpace();
                driver.WaitForElement(ShowGradebook_button);

                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool click_assignmentTitle(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(lnk_assignmentTitle);
                driver.GetElement(lnk_assignmentTitle).ClickWithSpace();
                Thread.Sleep(2000);
                //driver.SelectFrame();
                driver.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driver.WaitForElement(SaveExit_Button);
                


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool click_allowOnlineSubmission(IWebDriver driver)
        {
            bool result = false;

            try
            {

                
                driver.WaitForElement(chk_allowOnlineSubmission);
             //   driver.GetElement(chk_allowOnlineSubmission).ClickWithSpace();
                driver.ClickEleJs(chk_allowOnlineSubmission);
                driver.GetElement(SaveExit_Button).ClickWithSpace();
                driver.SwitchTo().DefaultContent();
                driver.WaitForElement(Success_Message);


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool click_viewFinalScores(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_ViewFinalScores);
                driver.GetElement(btn_ViewFinalScores).ClickWithSpace();
                driver.WaitForElement(btn_recordAttendance);


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public List<string> verify_recordAttendancePageElements(IWebDriver driver)
        {
            List<string> actualresult = new List<string>(2);

            try
            {
                driver.WaitForElement(By.XPath("//th[contains(.,'Assignment1 (100.00)')]"));
                actualresult.Add(driver.GetElement(By.XPath("//th[contains(.,'Assignment1 (100.00)')]")).Text);
                actualresult.Add(driver.GetElement(lbl_enrolledusernameAttendancePage).Text);
                driver.WaitForElement(btn_recordAttendance);
                driver.WaitForElement(btn_searchAttendancePage);
                driver.WaitForElement(btn_printAttendancePage);
                driver.WaitForElement(img_mailIconAttendancePage);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return actualresult;
        }

        public bool click_recordAttendance(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_recordAttendance);
                driver.GetElement(btn_recordAttendance).ClickWithSpace();
                driver.WaitForElement(btn_SaveRecordAttendancePage);


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool provide_attendance_status(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(chk_Attended);
             //   driver.GetElement(chk_Attended).ClickWithSpace();
                driver.ClickEleJs(chk_Attended);
                driver.FindSelectElementnew(ddl_progressStatus, "Completed");
                driver.GetElement(btn_SaveRecordAttendancePage).ClickWithSpace();
                driver.findandacceptalert();
                driver.WaitForElement(Success_Message);


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool click_returnRecordAttendancePage(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_returnRecordAttendancePage);
                driver.GetElement(btn_returnRecordAttendancePage).ClickWithSpace();
                driver.WaitForElement(btn_exportToExcel);


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public List<string> verify_attendanceStatusScores(IWebDriver driver)
        {
            List<string> actualresult = new List<string>(2);

            try
            {
                driver.WaitForElement(img_attended);
                actualresult.Add(driver.GetElement(img_attended).GetAttribute("title"));
                actualresult.Add(driver.GetElement(lbl_status).Text);

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return actualresult;
        }

        public List<string> verify_assignmentDetailsOnManageGradebookPage(IWebDriver driver)
        {
            List<string> actualresult = new List<string>(4);

            try
            {
                driver.WaitForElement(HideGradebook_button);
                actualresult.Add(driver.GetElement(lnk_assignmentTitle).Text);
                actualresult.Add(driver.GetElement(txt_itemWeight).GetAttribute("value"));
                actualresult.Add(driver.GetElement(By.XPath("//td[contains(.,'Pass/Fail')]")).Text);
                actualresult.Add(driver.GetElement(txt_dueDate).GetAttribute("value"));

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return actualresult;
        }

        public bool click_viewSubmissions(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_viewSubmissions);
                driver.GetElement(btn_viewSubmissions).ClickWithSpace();
                
                driver.WaitForElement(btn_SaveAssignmentResponsePage);



                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public List<string> verify_assignmentResponse(IWebDriver driver)
        {
            List<string> actualresult = new List<string>(3);
            string format = "M/d/yyyy";
            try
            {
                driver.WaitForElement(btn_SaveAssignmentResponsePage);
                actualresult.Add(driver.GetElement(By.XPath("//strong[contains(.,'Test Response')]")).Text);
                actualresult.Add(driver.GetElement(By.XPath("//strong[contains(.,'Test Comments')]")).Text);
                actualresult.Add(driver.GetElement(By.XPath("//strong[contains(.,'"+DateTime.Now.ToString(format)+"')]")).Text);
                

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return actualresult;
        }

        public bool click_returnViewSubmissionPage(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_returnViewSubmissionPage);
                driver.GetElement(btn_returnViewSubmissionPage).ClickWithSpace();
                driver.WaitForElement(btn_viewSubmissions);


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool enterGradesPassFail(IWebDriver driver, String grade)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(ddl_enterGrade);
                driver.FindSelectElementnew(ddl_enterGrade, grade);
                driver.GetElement(btn_SaveGrades).ClickWithSpace();
                driver.WaitForElement(Success_Message);


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        public bool click_returnEnterGradesPage(IWebDriver driver)
        {
            bool result = false;

            try
            {
                driver.WaitForElement(btn_returnEnterGradesPage);
                driver.GetElement(btn_returnEnterGradesPage).ClickWithSpace();
                driver.WaitForElement(btn_EnterGrades);


                result = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
            }

            return result;
        }

        private By ddl_enterGrade = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_GRADE_PASS_FAIL");
        private By btn_returnViewSubmissionPage = By.Id("MainContent_ucTabs_btnCancel1");
        private By lbl_assignmentSubmittedDate = By.Id("MainContent_ucTabs_ftInfo_MLabel5");
        private By lbl_assignmentComments = By.Id("MainContent_ucTabs_FormView1_lblCGAS_USER_COMMENT");
        private By lbl_assigmentResponse = By.Id("MainContent_ucTabs_FormView1_lblCGAS_USER_FEEDBACK");
        private By btn_SaveAssignmentResponsePage = By.Id("MainContent_ucTabs_btnSubmitAssignment");
        private By btn_viewSubmissions = By.Id("ctl00_MainContent_UC1_RadGrid1_ctl00_ctl04_lnkViewSubmissions");
        private By txt_dueDate = By.Id("ctl00_MainContent_UC1_ctl00_RadGrid1_ctl00_ctl04_rdpDueDate_dateInput");
        private By lbl_gradingScale = By.Id("ctl00_MainContent_UC1_ctl00_RadGrid1_ctl00_ctl04_lblScale");
        private By txt_itemWeight = By.Id("ctl00_MainContent_UC1_ctl00_RadGrid1_ctl00_ctl04_ASN_ITEM_WEIGHT");
        private By lbl_status = By.XPath("//tr[@id='ctl00_MainContent_UC2_rgEnrolled_ctl00__0']/td[3]");
        private By img_attended = By.Id("ctl00_MainContent_UC2_rgEnrolled_ctl00_ctl04_imgAttendance");
        private By btn_exportToExcel = By.Id("MainContent_UC2_btnExport");
        private By btn_returnRecordAttendancePage = By.Id("MainContent_UC1_Cancel");
        private By ddl_progressStatus = By.Id("ctl00_MainContent_UC1_rgEnrolled_ctl00_ctl04_ddlProgress");
        private By chk_Attended = By.Id("ctl00_MainContent_UC1_rgEnrolled_ctl00_ctl04_chkAttendance");

        private By btn_SaveRecordAttendancePage = By.Id("MainContent_UC1_Save");
        private By img_mailIconAttendancePage = By.Id("ctl00_MainContent_UC1_ctl00_ctl00_ctl00_ctl04_imgENRL_LMS_USER_ID");
        private By btn_printAttendancePage = By.Id("MainContent_UC1_ctl00_PrintButton");
        private By btn_searchAttendancePage = By.Id("MainContent_UC1_ctl00_btnSearch");
        private By lbl_enrolledusernameAttendancePage = By.Id("ctl00_MainContent_UC1_ctl00_ctl00_ctl00_ctl04_lcUSER_LAST_FIRST_NAME");
        private By lbl_possiblePoints = By.Id("lblPossiblePointsValue");
        private By btn_recordAttendance = By.Id("MainContent_UC1_FormView1_btnAttendance");
        private By btn_ViewFinalScores = By.Id("MainContent_UC1_FormView1_btnEditScore");
        private By dtp_duedate = By.Id("ctl00_MainContent_ucTabs_FormView1_ASN_DUE_DATE_dateInput");
        private By chk_allowOnlineSubmission = By.Id("MainContent_ucTabs_FormView1_ASN_VISIBLE");
        private By lnk_assignmentTitle = By.Id("ctl00_MainContent_UC1_ctl00_RadGrid1_ctl00_ctl04_lnkDetails");
        private By btn_returnEnterGradesPage = By.Id("MainContent_UC1_btnCancel");
        private By lbl_enrolledusername = By.XPath("//tr[@id='ctl00_MainContent_UC1_RadGrid1_ctl00__0']/td[1]");
        private By btn_SaveGrades = By.Id("MainContent_UC1_btnSave");
        private By btn_EnterGrades = By.Id("ctl00_MainContent_UC1_ctl00_RadGrid1_ctl00_ctl04_lnkGrade");
        private By GradebookConsoleTab = By.Id("MainContent_ucTabs_lbGBConsole");
        private By Search_TextBox = By.Id("MainContent_ucGBConsole_txtSearchFor");
        private By Search_button = By.Id("MainContent_ucGBConsole_btnSearch");
       //private By ClassroomCourse_Title_SearchResult = By.XPath("//a[contains(text(),'" + Variables.classroomCourseTitle+browserstr + "')]");
        //private By Section_Title_SearchResult = By.XPath("//a[contains(text(),'" + Variables.sectionTitle+browserstr + "')]");
       // private By CreateGradebook_button = By.XPath("//td[contains(text(),'" + Variables.sectionTitle+browserstr + "')]/following-sibling::td/input");
        private By Create_Button = By.Id("MainContent_UC1_btnCreate");
        private By Success_Message = By.XPath("//div[@class='alert alert-success']");
        private By FramePath = By.XPath("//div[@id='KendoUIMGDialog']/iframe");
        //private By AddAssignment_Button = By.Id("MainContent_UC1_ctl00_btnAddNew");
        private By AddAssignment_Button = By.XPath("//a[@id='MainContent_UC1_ctl00_btnAddNew']"); ////h2[contains(text(),'Assignments')]/a
        private By SaveExit_Button = By.Id("MainContent_ucTabs_btnSave");
        private By Assgnmnt_Title = By.Id("MainContent_ucTabs_FormView1_CNTLCL_TITLE");
        private By Assgnmnt_Desc = By.Id("MainContent_ucTabs_FormView1_CNTLCL_DESCRIPTION");
        private By Assgnmnt_ItemWeight = By.Id("MainContent_ucTabs_FormView1_ASN_ITEM_WEIGHT");
        private By SecondAssignment_Order = By.Id("ctl00_MainContent_UC1_ctl00_RadGrid1_ctl00_ctl06_ddlOrder");
        private By EditAssgnmnt_SaveButton = By.Id("MainContent_UC1_ctl00_FormView1_btnSave");
        private By Error_Message = By.ClassName("forms-msg-error");
        private By SecondAssignment_ChkBox = By.Id("ctl00_MainContent_UC1_ctl00_RadGrid1_ctl00_ctl06_chkSelect");
        private By AssignmntRemove_Button = By.Id("MainContent_UC1_ctl00_btnRemove");
        private By SearchResult_WaitElement = By.ClassName("rgHeader");
        private By ShowGradebook_button = By.Id("MainContent_UC1_ctl00_FormView1_btnActivate");
        private By HideGradebook_button = By.Id("MainContent_UC1_ctl00_FormView1_btnDeActivate");
       // private By ManageGradebook_button = By.XPath("//td[contains(text(),'"+ Variables.sectionTitle+browserstr +"')]]/following-sibling::td/a");
        //td[span[contains(text(),'NewTestSection3012165816')]]/following-sibling::td/a

    }


}
