using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestAutomation.helper
{
    
    public class WebElement_Locators
    {
        // Format is tree view structure just like psudo codes standard.

        #region 19.1 Compliance Dashboard Element Ids
        public static By lable_ComplianceDashbord_ReportsPage = By.XPath("//td[contains(text(),'Training Assignment Dashboard')]");
        public static By button_Open_ComplianceDashboard = By.XPath("//*[@id='ctl00_MainContent_MyReports_rgDashboards_ctl00_ctl10_lnkOpen']");
        public static By lable_ComplianceDashboard_ComplianceDashboardPage = By.XPath("//h1[contains(text(),'Training Assignment Dashboard')]");
        public static By button_Go_Transcript_ComplianceDashboard = By.XPath("//a[@class='btn btn-touch dropdown-toggle']");
        public static By lable_Transcript_ComplianceDashboard_TranscriptPage = By.XPath("//div[@webix_l_id='2']");

        public static By ComplianceDashboardPage_selectAll_Checkbox = By.XPath("//div[@class='webix_hcell']//input[@type='checkbox']");
        public static By ComplianceDashboardPage_Email_Link = By.XPath("//button[@id='Email']");
        public static By ComplianceDashboardPage_EmailManager_Link = By.XPath("//button[@id='EmailManager']");
        public static By ComplianceDashboardPage_EmailPopup_PopupTitle_Header = By.XPath("//h4[contains(text(),'Send Email')]");
        public static By ComplianceDashboardPage_EmailPopup_FromEmail_TextBox = By.XPath("//div[contains(text(),'sshukla@meridianksi.net')]");
        public static By ComplianceDashboardPage_EmailPopup_Subject_TextBox = By.XPath("//input[@id='emailSubject']");
        public static By ComplianceDashboardPage_EmailPopup_Message_RichTextBox = By.XPath("//div[@class='fr-element fr-view']//p");
        public static By ComplianceDashboardPage_EmailPopup_SendEmail_Button = By.XPath("//button[contains(text(),'Send')]");
        public static By ComplianceDashboardPage_EmailPopup_Cancel_Button = By.XPath("//button[contains(text(),'Cancel')]");
        #endregion

        #region 19.1 Career Path
        #endregion

        #region 19.1 Survey Page Ids
        public static By SurveysPage_AssignSurveys_btn = By.XPath("//a[@id='btnAssignSurvey']");
        public static By SurveysPage_AddSurveysModal_Searchlenc_Btn= By.XPath("//a[@id='btnSearchAvailableSurveys']/span");
        internal static By SurveysPage_AddSurveysModal_Search_InputTextbox= By.Id("survey_assign_searchfor");
        internal static By SurveysPage_AddSurveysModal_ResultGrid= By.XPath("//table[@id='tableAssignSurveys']/tbody/tr/td");
        internal static By SurveysPage_AddSurveysModal_ResultGrid_firstrestltselect_checkbox=By.XPath("//table[@id='tableAssignSurveys']/tbody/tr/td/input");
        internal static By SurveysPage_AddSurveysModal_Add_Btn=By.Id("btnAddSurveys");
        internal static By SurveysPage_Resultgrid_FirstSurveyTitle=By.XPath("//table[@id='tableSurveys']/tbody/tr/td[2]");
        #endregion

        #region 19.1 Create Training Assignment Page Ids

        public static By CreateTrainingAssignmentPage_TitleBox = By.XPath("//a[@id='assignment-title-edit-link']/em");
        public static By CreateTrainingAssignmentPage_TitleInputTextBox = By.Id("assignment-title-edit");
        public static By CreateTrainingAssignmentPage_SaveTitleBtn = By.XPath("//button[@id='btn-update-title']/span");
        public static By CreateTrainingAssignmentPage_ContentTab_AddContentModal_SearchContentTextBox = By.Id("searchFor");
        public static By CreateTrainingAssignmentPage_ContentTab_AddContentModal_Searchbtn = By.XPath("//a[@id='btn-content-search']/span");
        public static By CreateTrainingAssignmentPage_ContentTab_AddContentModal_FirstSearchedresultListcheckBox = By.XPath("//table[@id='find-content-table']/tbody/tr/td/input");
        public static By CreateTrainingAssignmentPage_ContentTab_AddContentModal_AddBtn = By.Id("btn-add");
        public static By CreateTrainingAssignmentPage_AssigneesTab_AddassigneesModal_SearchContentTextBox = By.XPath("//input[@id='SearchFor']");
        public static By CreateTrainingAssignmentPage_AssigneesTab_AddassigneesModal_Searchbtn = By.XPath("//button[@id='btn-search']/span");
        public static By CreateTrainingAssignmentPage_AssigneesTab_AddassigneesModal_FirstSearchedresultListcheckBox = By.XPath("//table[@id='find-assignees-table']/tbody/tr/td/input");
        public static By CreateTrainingAssignmentPage_AssigneesTab_AddassigneesModal_AddBtn = By.Id("btn-add-assignees");


        #endregion




    }

}
        
    

