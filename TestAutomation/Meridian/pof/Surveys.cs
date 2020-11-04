using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using System.Reflection;

namespace Selenium2.Meridian
{
    class Surveys
    {
          private readonly IWebDriver driverobj;
          public Surveys(IWebDriver driver)
        {
            driverobj = driver;
        }


        public bool AssigningSurveys(IWebDriver driver,string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_Survey.Surveys_AssignSurveys_Button);
                driver.GetElement(Locator_Survey.Surveys_AssignSurveys_Button).ClickWithSpace();
                driver.WaitForElement(Locator_Survey.Survey_SearchFor_Textbox);
                //driver.WaitForElement(Locator_Survey.Survey_Surveys_Frame);
                //driver.SwitchTo().Frame(driver.GetElement(Locator_Survey.Survey_Surveys_Frame));
                driver.Checkout();
                //driver.GetElement(Locator_Survey.Survey_SearchFor_Textbox).SendKeysWithSpace(Variables.surveyTitle + browserstr);
                driver.select(Locator_Survey.Survey_SearchType_Dropdown, "Exact phrase");
                driver.GetElement(Locator_Survey.Survey_Search_Button).ClickWithSpace();
                driver.WaitForElement(Locator_Survey.Survey_SurveyName_Link);
                driver.ClickEleJs(Locator_Survey.Survey_SurveyName_Link);
                driver.ClickEleJs(Locator_Survey.Survey_Save_Button);
              //  driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
                return false;
            }
            return true;
        }

        public string SuccessMsg_Survey(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Survey.Survey_SuccessMsg_Link);
                return driver.gettextofelement(Locator_Survey.Survey_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driver);
                return "";
            }
        }

        public bool Click_GoToButton()
        {

            bool actualresults = false;
            try
            {

                driverobj.WaitForElement(GoBtn);
                driverobj.GetElement(GoBtn).ClickWithSpace();
                driverobj.WaitForElement(Title);
                actualresults = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }
        public bool Populate_Survey(string browserstr)
        {

            bool actualresults = false;
            try
            {

                driverobj.WaitForElement(Title);
                driverobj.GetElement(Title).Clear();
                driverobj.GetElement(Title).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr);
                driverobj.GetElement(Desc).Clear();
                driverobj.GetElement(Desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Desc"]);
                driverobj.GetElement(Keywords).Clear();
                driverobj.GetElement(Keywords).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Desc"]);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_SRVY_SURVEY_TYPE_ID"), "Site Survey");
                driverobj.GetElement(btn_create).ClickWithSpace();
                actualresults = driverobj.existsElement(lbl_return_feedback);
            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);


            }
            return actualresults;

        }

        public bool Click_lnkadvancesearch()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced"));
                //driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced")).ClickAnchor();
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced"));
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Populate_advancesearch(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Desc"]);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Desc"]);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }

        public bool Click_Search(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "')]"));
             //   driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "')]")).ClickWithSpace();
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"] + browserstr + "')]"));
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

            }
            return actualresult;
        }
        public bool Populate_Search(string browserstr)
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr);
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

              //  driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.WaitForElement(By.XPath("//div[3]/div/a"));
              //  driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.ClickEleJs((By.XPath("//div[3]/div/a")));
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL"));
              
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_Save()
        {
            bool actualresult = false;
            try
            {
                //driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL"));
                //driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL")).SendKeysWithSpace("www.google.com");
                driverobj.GetElement(btn_save).ClickWithSpace();
                driverobj.WaitForElement(By.Id("ReturnFeedback"));
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_Structure_Go()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(btn_structure_go);
             //   driverobj.GetElement(btn_structure_go).ClickWithSpace();
                driverobj.ClickEleJs(btn_structure_go);
                driverobj.WaitForElement(txt_new_section_title);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Populate_Structure(int i, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(txt_new_section_title);
                driverobj.GetElement(txt_new_section_title).Clear();
                driverobj.GetElement(txt_new_section_title).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure" + i);
                driverobj.GetElement(txt_new_section_desc).Clear();
                driverobj.GetElement(txt_new_section_desc).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure" + i);
                driverobj.GetElement(txt_new_section_keyword).Clear();
                driverobj.GetElement(txt_new_section_keyword).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure" + i);
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
   
        public bool Click_SurveyStructureTab()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(tab_structure);
             //   driverobj.GetElement(tab_structure).ClickWithSpace();
                driverobj.ClickEleJs(tab_structure);
                driverobj.WaitForElement(btn_structure_go);
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Select_Link_Existing_Section()
        {
            bool actualresult = false;
            try
            {
                driverobj.FindSelectElementnew(cmb_editstructure, "Link Existing Section");
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }
        public bool Click_link_section()
        {
            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(txt_search_section);
                driverobj.GetElement(txt_search_section).Clear();
                driverobj.GetElement(txt_search_section).SendKeysWithSpace("");
                driverobj.GetElement(btn_search_section).ClickWithSpace();
                driverobj.WaitForElement(chk_section);
              //  driverobj.GetElement(chk_section).ClickWithSpace();
                driverobj.ClickEleJs(chk_section);
                driverobj.GetElement(btn_select).ClickWithSpace();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_return_feedback);
              
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_Populate_Create_Question(string browserstr)
        {

            bool actualresult = false;
            try
            {
               
              
                driverobj.WaitForElement(btn_edit_section_action1);
                driverobj.FindSelectElementnew(cmb_edit_section_action1, "Manage Questions");
                driverobj.GetElement(btn_edit_section_action1).ClickWithSpace();
                driverobj.WaitForElement(btn_create_link_question);
                driverobj.GetElement(btn_create_link_question).ClickWithSpace();
                driverobj.WaitForElement(txt_create_question);
                driverobj.GetElement(txt_create_question).Clear();
                driverobj.GetElement(txt_create_question).SendKeysWithSpace(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "question" + 1);
                driverobj.FindSelectElementnew(cmb_question_type, "Short Answer");
                driverobj.GetElement(btn_create).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
              
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_Link_Question()
        {

            bool actualresult = false;
            try
            {
              
               
                driverobj.WaitForElement(btn_edit_section_action2);
                driverobj.FindSelectElementnew(cmb_edit_section_action2, "Manage Questions");
                driverobj.GetElement(btn_edit_section_action2).ClickWithSpace();
                driverobj.WaitForElement(cmb_link_question);
                driverobj.FindSelectElementnew(cmb_link_question, "Link Existing Questions");
                driverobj.WaitForElement(btn_create_link_question);
                driverobj.GetElement(btn_create_link_question).ClickWithSpace();
                driverobj.WaitForElement(btn_search_question);
                driverobj.GetElement(btn_search_question).ClickWithSpace();
                driverobj.WaitForElement(chk_link_question);
               // driverobj.GetElement(chk_link_question).ClickWithSpace();
                driverobj.ClickEleJs(chk_link_question);
                driverobj.GetElement(btn_select_link_question).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
              
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_Reorderscetion()
        {

            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_ReOrderMenu"));
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_ReOrderMenu"), "2");
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl03_ReOrderMenu"), "1");
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_ML.BASE.BTN.Reorder")).ClickWithSpace();
                driverobj.WaitForElement(lbl_return_feedback);
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_DeleteSurveySection()
        {

            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_DataGridItem_SSEC_SECTION_ID"));
           //     driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_DataGridItem_SSEC_SECTION_ID")).ClickWithSpace();
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_DataGridItem_SSEC_SECTION_ID"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_ML.BASE.BTN.Delete")).ClickWithSpace();
               
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_return_feedback);
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_PreviewSection(string browserstr)
        {

            bool actualresult = false;

            try
            {

                driverobj.WaitForElement(By.Id("Preview"));
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.GetElement(By.Id("Preview")).ClickWithSpace();
                driverobj.selectWindow("Take Survey");
                Thread.Sleep(4000);
                driverobj.WaitForElement(By.Id("MainHeading"));
                if (!driverobj.GetElement(By.Id("MainHeading")).Text.Contains(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr))
                {
                    actualresult = false;
                    return actualresult;
                }

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure" + "')]"));
                Thread.Sleep(3000);
                driverobj.Close();
                Thread.Sleep(3000);
                driverobj.SwitchTo().Window(originalHandle);
                Thread.Sleep(5000);
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;

        }
        public bool Click_PublishSurvey()
        {

            bool actualresult = false;
            try
            {

                driverobj.WaitForElement(By.Id("ML.BASE.BTN.Publish"));
                driverobj.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_DataGridItem_SSEC_SECTION_ID"));
                driverobj.GetElement(By.Id("ML.BASE.BTN.Publish")).ClickWithSpace();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_return_feedback);
               
                actualresult = true;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);
            }
            return actualresult;
        }

        public bool Click_RequiredTraining()
        {
            bool actualresult = false;
            try
            {
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Required Training')]"));
              //  driverobj.GetElement(By.XPath("//a[contains(.,'Required Training')]")).Click();
                driverobj.ClickEleJs(By.XPath("//a[contains(.,'Required Training')]"));
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining"));
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining"), "Assign Training Without Deadline");
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu")).ClickWithSpace();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole")).SendKeys(ExtractDataExcel.MasterDic_admin1["Id"]);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search")).ClickWithSpace();
                driverobj.WaitForElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0_')]"));
             //   driverobj.GetElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0_')]")).Click();
                driverobj.ClickEleJs(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0_')]"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining")).ClickWithSpace();
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

                string originalHandle = driverobj.CurrentWindowHandle;
              //  driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')"));
                driverobj.WaitForElement(By.XPath("//a[3]"));
                driverobj.GetElement(By.XPath("//a[3]")).ClickAnchor();
                driverobj.WaitForElement(btn_delete_content);
                driverobj.GetElement(btn_delete_content).ClickAnchor();
                driverobj.WaitForElement(By.XPath("//span[@id='ReturnFeedback']"));
                actualresult = true;

            }

            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "", driverobj);

                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);

            }
            return actualresult;
        }
        internal void CreateNewSurveyForRegression(string browserstr)
        {
            TrainingHomes TrainingHomeobj = new TrainingHomes(driverobj);
            AdminstrationConsole AdminstrationConsoleobj = new AdminstrationConsole(driverobj);
            TrainingHomeobj.isTrainingHome();
            TrainingHomeobj.lnk_SystemOptions_click();
            TrainingHomeobj.lnk_ContentManagement_click();
            AdminstrationConsoleobj.Click_OpenItemLink("Surveys");
            Click_GoToButton();
            Populate_Survey(browserstr);
        }
    
        private By adminconsoleopenlink = By.Id("NavigationStrip1_lnkAdminConsole");
        private string adminwindowtitle = "Administration Console";
        private By adminSurvey = By.LinkText("Surveys");
        private By GoBtn = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        private By Title = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_SRVY_TITLE");
        private By Desc = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_SRVY_DESCRIPTION");
        private By Keywords = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_SRVY_KEYWORDS");
        private By btn_create = By.Id("ML.BASE.BTN.Create");
        private By checkin = By.XPath("//span[contains(.,'Check In')]");
        private By lbl_return_feedback = By.Id("ReturnFeedback");
        private By btn_save = By.Id("ML.BASE.BTN.Save");
        //reg training
        private By lnk_required_training = By.XPath("//a[contains(.,'Required Training')]");
        private By btn_required_training_go = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu");
        private By cmb_AssignTraining = By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining");
        private By txt_AssignTraining_SearchRole = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole");
        private By btn_AssignTraining_Search = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search");
        private By chk_AssignTraining_adduser_fromlist = By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0_')]");
        private By btn_AssignTraining = By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining");

        private By tab_structure = By.XPath("//span[contains(.,'Structure')]");
        private By btn_structure_go = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_GoPageActionsMenu");
        private By txt_new_section_title = By.Id("TabMenu_ML_BASE_TAB_SurveyNewSection_SSECLCL_TITLE");
        private By txt_new_section_desc = By.Id("TabMenu_ML_BASE_TAB_SurveyNewSection_SSECLCL_DESCRIPTION");
        private By txt_new_section_keyword = By.Id("TabMenu_ML_BASE_TAB_SurveyNewSection_SSECLCL_KEYWORDS");
        private By cmb_editstructure = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_ML.BASE.TAB.SURVEY.SurveyEditStructure");
        private By txt_search_section = By.Id("TabMenu_ML_BASE_TAB_SurveySearchSection_SearchFor");
        private By btn_search_section = By.Id("TabMenu_ML_BASE_TAB_SurveySearchSection_ML.BASE.BTN.Search");

        private By chk_section = By.XPath("//*[contains(@id,'_DataGridItem_SSTR_SECTION_ID')]");
        private By btn_select = By.Id("TabMenu_ML_BASE_TAB_SurveySearchSection_ML.BASE.BTN.Select");

        private By cmb_edit_section_action1 = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_ActionsMenu");
        private By btn_edit_section_action1 = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_GoButton");
        private By cmb_edit_section_action2 = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl04_ActionsMenu");
        private By btn_edit_section_action2 = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl04_GoButton");
        private By btn_create_link_question = By.Id("TabMenu_ML_BASE_TAB_SurveySectionQuestions_GoPageActionsMenu");
        private By txt_create_question = By.Id("TabMenu_ML_BASE_TAB_SurveyNewQuestion_SQSTLCL_TITLE");
        private By cmb_question_type = By.Id("TabMenu_ML_BASE_TAB_SurveyNewQuestion_SQST_SURVEY_QUESTION_TYPE");
        private By btn_return = By.Id("Return");
        private By cmb_link_question = By.Id("TabMenu_ML_BASE_TAB_SurveySectionQuestions_ML.BASE.TAB.SURVEY.SurveySectionQuestions");
        private By btn_search_question = By.Id("TabMenu_ML_BASE_TAB_SurveySearchQuestion_ML.BASE.BTN.Search");
        private By chk_link_question = By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_SurveySearchQuestion_SurveyListingDataGrid_')]");
        private By btn_select_link_question = By.Id("TabMenu_ML_BASE_TAB_SurveySearchQuestion_ML.BASE.BTN.Select");
        private By btn_delete_content = By.XPath("html/body/div[1]/div[2]/div/div[3]/button[2]");

        internal void AssigningSurveys(IWebDriver driver)
        {
            throw new NotImplementedException();
        }
    }
    public class Locator_Survey
    {
        public static By Surveys_AssignSurveys_Button = By.Id("MainContent_MainContent_UC1_btnAssignSurveys");
        public static By Survey_Surveys_Frame = By.ClassName("k-content-frame");
        public static By Survey_SearchFor_Textbox = By.Id("MainContent_MainContent_UC1_txtSearchFor");
        public static By Survey_Search_Button = By.Id("MainContent_MainContent_UC1_btnSearch");
        public static By Survey_SurveyName_Link = By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect']");
        public static By Survey_Save_Button = By.Id("MainContent_MainContent_UC1_Save");
        public static By Survey_SuccessMsg_Link = By.XPath("//div[@class='alert alert-success']");
        public static By Survey_SearchType_Dropdown = By.Id("MainContent_MainContent_UC1_ddlSearchType");
    }
}
