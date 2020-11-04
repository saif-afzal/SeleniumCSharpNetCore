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
    class ExternalLearningConsoles
    {
        private readonly IWebDriver driverobj;
        TrainingHomes TrainingHomeobj;
        AdminstrationConsole AdminstrationConsoleobj;
        ExternalLearnings ExternalLearningsobj;
        public ExternalLearningConsoles(IWebDriver driver)
        {
            driverobj = driver;
            TrainingHomeobj = new TrainingHomes(driverobj);
            AdminstrationConsoleobj = new AdminstrationConsole(driverobj);
            ExternalLearningsobj = new ExternalLearnings(driverobj);
        }
        public bool Click_SearchUser(string browserstr,string searchType)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txtlastname);
                if (searchType.ToLower().Equals("search user"))
                {
                    driverobj.GetElement(txtlastname).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Lastname"] + browserstr);
                    driverobj.GetElement(txtfirstname).SendKeysWithSpace(ExtractDataExcel.MasterDic_userforreg["Firstname"] + browserstr);
                    driverobj.FindSelectElementnew(cmbaction, "Pending");
                    driverobj.FindSelectElementnew(cmbrequest, "All Requests");
                 //   driverobj.GetElement(btnsearch).ClickWithSpace();
                    driverobj.ClickEleJs(btnsearch);
                    driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_userforreg["Lastname"] + browserstr + "', '" + ExtractDataExcel.MasterDic_userforreg["Firstname"] + browserstr + "')]"));
                    string text = driverobj.FindElement(resultsSearchUser).Text;
                    if (text.Contains(ExtractDataExcel.MasterDic_userforreg["Lastname"] + browserstr + ", " + ExtractDataExcel.MasterDic_userforreg["Firstname"] + browserstr))
                    { actualresult = true; }
                }
                else
                {
                  //  driverobj.FindElement(searchContentLink).ClickWithSpace();
                    driverobj.ClickEleJs(searchContentLink);
                    Thread.Sleep(1000);
                    driverobj.WaitForElement(searchContent_SearchTestBox);
                    driverobj.GetElement(searchContent_SearchTestBox).SendKeysWithSpace(ExtractDataExcel.MasterDic_EL["Title"] + browserstr + "ELC");
                    driverobj.FindSelectElementnew(cmbaction, "Pending");
                    driverobj.FindSelectElementnew(cmbrequest, "All Requests");
                    driverobj.ClickEleJs(btnsearch_Content);
                    driverobj.WaitForElement(By.XPath("//td[contains(.,'" + ExtractDataExcel.MasterDic_EL["Title"] + browserstr + "ELC" + "')]"));
                    string text = driverobj.FindElement(resultsSearchContent).Text;
                    if (text.Contains(ExtractDataExcel.MasterDic_EL["Title"] + browserstr + "ELC"))
                    { actualresult = true; }
                }

            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Search a user to add for External Learning", driverobj);
            }
            return actualresult;
        }
        public bool CreateExternalLearning_AssingtoNewUser(string browser)
        {
            try
            {
                driverobj.UserLogin("admin1", browser);
                //TrainingHomeobj.isTrainingHome();
                //TrainingHomeobj.lnk_SystemOptions_click();
                TrainingHomeobj.lnk_TrainingManagement_click(By.XPath("//a[contains(.,'Administer')]"), By.XPath("//a[contains(.,'Content Management')]"));
                AdminstrationConsoleobj.Click_OpenItemLink("External Learning");
                ExternalLearningsobj.Click_CreateNewGoTo();
                ExternalLearningsobj.Populate_ExternalLearning("ELC", browser);
                //--Manage-- Checkin--
                driverobj.WaitForElement(checkin);
                driverobj.GetElement(checkin).ClickWithSpace();
                Thread.Sleep(2000);
                driverobj.Navigate_to_TrainingHome();
                AssignUser_ExternalLearningConsole(ExtractDataExcel.MasterDic_EL["Title"] + browser + "ELC", browser);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Search a user to add for External Learning", driverobj);
                return false;
            }
        }

        public void AssignUser_ExternalLearningConsole(string title,string browser)
        {
            try
            {
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                driverobj.UserLogin("userforregression", browser);
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Transcript')]"));
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_ucQLinks_lnkEL']"));
                driverobj.GetElement(By.XPath("//a[@id='MainContent_ucQLinks_lnkEL']")).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[@id='MainContent_UC2_MLinkButton1']"));
                driverobj.GetElement(By.XPath("//a[@id='MainContent_UC2_MLinkButton1']")).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//input[@id='MainContent_UC1_txtSearchFor']"));
                driverobj.GetElement(By.XPath("//input[@id='MainContent_UC1_txtSearchFor']")).SendKeysWithSpace(title);

                driverobj.WaitForElement(By.Id("MainContent_UC1_btnSearch"));

                driverobj.GetElement(By.Id("MainContent_UC1_btnSearch")).ClickWithSpace();
                //driverobj.GetElement(QuickSearch).SendKeysWithSpace(ExtractDataExcel.MasterDic_EL["Title"] + browser + "ELC");
                //driverobj.GetElement(searchButton).ClickWithSpace();
                //Thread.Sleep(2000);
                driverobj.WaitForElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_EL["Title"] + browser + "ELC" + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(text(),'" + ExtractDataExcel.MasterDic_EL["Title"] + browser + "ELC" + "')]")).ClickWithSpace();
                Thread.Sleep(1000);
                driverobj.WaitForElement(submitRequest);

                driverobj.GetElement(submitRequest).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                driverobj.WaitForElement(By.Id("MainContent_UC1_fvSubmitRequest_ELR_REASON"));
                driverobj.GetElement(By.Id("MainContent_UC1_fvSubmitRequest_ELR_REASON")).SendKeysWithSpace("Test_ExternalLearningConsole");
                string newreporttitle = "test_" + DateTime.Now.ToString();
                driverobj.GetElement(By.CssSelector("input[id*='SubmitRequest_ELR_OBTAINED_DATE_dateInput']")).SendKeysWithSpace(newreporttitle);
                driverobj.GetElement(submitRequest_Main).ClickWithSpace();
                Thread.Sleep(3000);
                TrainingHomeobj.isTrainingHome();
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Search a user to add for External Learning", driverobj);
            }
        }
        public bool VerfyAccept_DenayUserRequest(string browser, string action)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(takeActionGoButton);
                driverobj.ClickEleJs(takeActionGoButton);
                Thread.Sleep(3000);
                if (action.ToLower().Contains("approveuser"))
                {
                    driverobj.WaitForElement(checkbox_Approve);
                //    driverobj.GetElement(checkbox_Approve).ClickWithSpace();
                    driverobj.ClickEleJs(checkbox_Approve);
                    Thread.Sleep(1000);
                    string newreporttitle = "test_" + DateTime.Now.ToString();
                    string newreporttitle1 = "test_" + DateTime.Now.AddDays(2).ToString();
                    driverobj.GetElement(exp_DateCal).ClickWithSpace();
                    driverobj.GetElement(exp_DateCal).Clear();
                    driverobj.GetElement(exp_DateCal).SendKeysWithSpace(DateTime.Now.AddDays(2).ToString("MM/dd/yyyy"));
                    driverobj.GetElement(By.Id("TabMenu_ML_BASE_ACT_TakeAction_ELR_EXP_DATE||DATEPICKER_dateInput")).ClickWithSpace();
                    driverobj.GetElement(By.Id("TabMenu_ML_BASE_ACT_TakeAction_ELR_EXP_DATE||DATEPICKER_dateInput")).Clear();
                    driverobj.GetElement(By.Id("TabMenu_ML_BASE_ACT_TakeAction_ELR_EXP_DATE||DATEPICKER_dateInput")).SendKeysWithSpace(newreporttitle1);

                }
                else
                {
                    driverobj.WaitForElement(checkbox_Deny);
                 //   driverobj.GetElement(checkbox_Deny).ClickWithSpace();
                    driverobj.ClickEleJs(checkbox_Deny);
                }
                Thread.Sleep(2000);
                driverobj.GetElement(reason_Filed).SendKeysWithSpace("Test");
                Thread.Sleep(2000);
                driverobj.WaitForElement(takeActionButton);
                driverobj.GetElement(takeActionButton).ClickWithSpace();
                Thread.Sleep(2000);
                //Verify Sucesss Message here 
                actualresult = driverobj.existsElement(By.CssSelector("span[id='ReturnFeedback']"));
                return actualresult;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Search a user to add for External Learning", driverobj);
                return false;
            }
            
        
        }
        public bool VerifyItemHistory(string browserstr)
        {
            try
            {
                driverobj.WaitForElement(takeActionGoButton);
                driverobj.GetElement(By.CssSelector("select[id^='TabMenu_ML_BASE_LBL_SearchUsers_ActionsMenu_2_LMS_USER_']")).ClickWithSpace();
                driverobj.GetElement(dropdownValue_ViewHistory).ClickWithSpace();
                driverobj.GetElement(takeActionGoButton).ClickWithSpace();
                Thread.Sleep(3000);
                bool title_ViewHistory = driverobj.GetElement(viewHistoryPageTitle).Text.Contains(ExtractDataExcel.MasterDic_EL["Title"] + browserstr + "ELC");
                string text = driverobj.gettextofelement(By.CssSelector("span[id^='TabMenu_ML_BASE_ACT_CourseHistory_Feedback_']"));
                string count_HistoryRows = text.Split(':')[1];
                if (!(title_ViewHistory && !count_HistoryRows.Equals("0")))
                { return false; }
                else
                {
                    int count = driverobj.FindElements(By.CssSelector("tr[id*='TabMenu_ML_BASE_ACT_CourseHistory_EXTERNAL_LEARNING_HISTORY_ELH_HISTORY_ID']")).ToList().Count();
                    if (!count_HistoryRows.Trim().Equals(Convert.ToString(count))) { return false; }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Click_InformationIcon(string browserstr,string informationIcon="")
        {
            bool result = false;

            try
            {
                driverobj.WaitForElement(informationIconImage);
                string originalHandle = driverobj.CurrentWindowHandle;
            //    driverobj.GetElement(informationIconImage).ClickWithSpace();
                driverobj.ClickEleJs(informationIconImage);
                Thread.Sleep(5000);
                if (informationIcon.Equals("InformationIcon_SearchContent"))
                { driverobj.selectWindow("External Learning"); }
                else
                { driverobj.selectWindow("User Information"); }
                Thread.Sleep(2000);
                driverobj.WaitForElement(iconPopupHeading);
                if (informationIcon.Equals("InformationIcon_SearchContent"))
                {
                    if (driverobj.GetElement(iconPopupHeading).Text.Contains(ExtractDataExcel.MasterDic_EL["Title"] + browserstr + "ELC"))
                    {
                        result = true;
                    }
                }
                else
                {
                    if (driverobj.GetElement(iconPopupHeading).Text.Contains(ExtractDataExcel.MasterDic_userforreg["Firstname"] + browserstr))
                    {
                        result = true;
                    }
                }
                Thread.Sleep(3000);
                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);


                result = true;
            }
            catch (Exception ex)
            {

                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }


            return result;
        }
        private By txtlastname = By.Id("TabMenu_ML_BASE_LBL_SearchUsers_USR_LAST_NAME");
        private By txtfirstname = By.Id("TabMenu_ML_BASE_LBL_SearchUsers_USR_FIRST_NAME");
        private By cmbaction = By.Id("//select[@id='TabMenu_ML_BASE_LBL_SearchUsers_ELR_STATUS_ID']");
        private By cmbrequest = By.Id("//select[@id='TabMenu_ML_BASE_LBL_SearchUsers_REQUEST_TYPE']");
        private By btnsearch = By.Id("TabMenu_ML_BASE_LBL_SearchUsers_ML.BASE.BTN.Search");
        private By btnsearch_Content = By.Id("TabMenu_ML_BASE_TAB_SearchCourseContent_ML.BASE.BTN.Search");
        private By checkin = By.XPath("//span[contains(.,'Check In')]");
        private By resultsSearchUser = By.CssSelector("tr[id^='TabMenu_ML_BASE_LBL_SearchUsers_LMS_USER_']");
        private By resultsSearchContent = By.CssSelector("tr[id^='TabMenu_ML_BASE_TAB_SearchCourseContent_CONTENT_']");
        private By searchContentLink = By.Id("TabMenu_ML_BASE_LBL_SearchUsers_ML.BASE.CMD.SearchContent");
        private By searchContent_SearchTestBox = By.Id("TabMenu_ML_BASE_TAB_SearchCourseContent_SearchFor");
        private By QuickSearch = By.Id("MainContent_ucQuickSearch_txtSearch");
        private By searchButton = By.Id("btnSearch");
        private By submitRequest = By.CssSelector("input[name*='SubmitRequestBlock']");
        private By submitRequest_Main = By.CssSelector("input[id='MainContent_UC1_SubmitRequest']");
        private By informationIconImage = By.XPath("//img[@ src='/Skins/BaseTopMenu/Icons/en-US/ViewInfoIcon.png']");
        private By iconPopupHeading = By.Id("MainHeading");
        private By takeActionGoButton = By.Id("TabMenu_ML_BASE_LBL_SearchUsers_CONTENT_ITEM_GoButton_1");
        private By checkbox_Approve = By.Id("TabMenu_ML_BASE_ACT_TakeAction_ELH_STATUS_ID_0");
        private By checkbox_Deny = By.Id("TabMenu_ML_BASE_ACT_TakeAction_ELH_STATUS_ID_1");
        private By exp_DateCal = By.Id("TabMenu_ML_BASE_ACT_TakeAction_ELR_EXP_DATE||DATEPICKER_dateInput");
        private By reason_Filed = By.Id("TabMenu_ML_BASE_ACT_TakeAction_ELH_REASON");
        private By takeActionButton = By.Id("TabMenu_ML_BASE_ACT_TakeAction_ML.BASE.BTN.TakeAction");
        private By takeActionTextBox = By.CssSelector("select[id$='TabMenu_ML_BASE_LBL_SearchUsers_ActionsMenu_2_LMS_USER_']");
        private By dropdownValue_ViewHistory = By.CssSelector("option[value='ML.BASE.ACT.ViewHistory']");
        private By viewHistoryPageTitle = By.Id("TabMenu_ML_BASE_ACT_CourseHistory_TDElementEXT_TITLE");
    }
}
