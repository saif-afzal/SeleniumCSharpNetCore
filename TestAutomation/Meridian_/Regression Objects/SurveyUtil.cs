using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework;
using Selenium2.Meridian;
using System.Reflection;

namespace TestAutomation.Meridian.Regression_Objects
{
    class SurveyUtil
    {

        private readonly IWebDriver driverobj;
        public SurveyUtil(IWebDriver driver)
        {
            driverobj = driver;
        }



        public bool CreateSurvey(string browserstr)
        {

            bool actualresults = false;
            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.WaitForElement(adminSurvey);
                driverobj.GetElement(adminSurvey).Click();
                driverobj.GetElement(GoBtn).Click();
                driverobj.WaitForElement(Title);
                driverobj.GetElement(Title).Clear();
                driverobj.GetElement(Title).SendKeys(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr);
                driverobj.GetElement(Desc).Clear();
                driverobj.GetElement(Desc).SendKeys(ExtractDataExcel.MasterDic_Survey["Desc"]);
                driverobj.GetElement(Keywords).Clear();
                driverobj.GetElement(Keywords).SendKeys(ExtractDataExcel.MasterDic_Survey["Desc"]);
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_SRVY_SURVEY_TYPE_ID"), "Site Survey");
                driverobj.GetElement(btn_create).Click();


                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(4000);
                driverobj.LogoutUser(ObjectRepository.LogoutHoverLink, ObjectRepository.HoverMainLink);
                actualresults = true;

            }

            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
            return actualresults;

        }





        public bool SurveyAdvSearch(string browserstr)
        {
            bool actualresult = false;
            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.WaitForElement(adminSurvey);
                driverobj.GetElement(adminSurvey).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.CMD.Advanced")).ClickAnchor();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_TITLE")).SendKeys(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_DESCRIPTION")).SendKeys(ExtractDataExcel.MasterDic_Survey["Desc"]);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_CNT_KEYWORDS")).SendKeys(ExtractDataExcel.MasterDic_Survey["Desc"]);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();

                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "')]"));
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }
        public void Surveysearch(string browserstr)
        {

            try
            {
                driverobj.GetElement(adminconsoleopenlink).ClickAnchor();
                driverobj.selectWindow(adminwindowtitle);
                driverobj.WaitForElement(adminSurvey);
                driverobj.GetElement(adminSurvey).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).Clear();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeys(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search")).Click();
                driverobj.WaitForElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'" + ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "')]")).Click();

            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }

        }

        public bool Surveysimplesearch(string browserstr)
        {
            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }


        public bool manageSurvey(string browserstr)
        {
            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_EditMetadata_CNT_PREVIEW_URL")).SendKeys("www.google.com");
                driverobj.GetElement(btn_save).Click();
                driverobj.WaitForElement(By.Id("ReturnFeedback"));
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public void newsection(string browserstr)
        {
            for (int i = 0; i <= 2; i++)
            {
                driverobj.WaitForElement(btn_structure_go);
                driverobj.GetElement(btn_structure_go).Click();
                driverobj.WaitForElement(txt_new_section_title);
                driverobj.GetElement(txt_new_section_title).Clear();
                driverobj.GetElement(txt_new_section_title).SendKeys(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure"+i);
                driverobj.GetElement(txt_new_section_desc).Clear();
                driverobj.GetElement(txt_new_section_desc).SendKeys(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure" + i);
                driverobj.GetElement(txt_new_section_keyword).Clear();
                driverobj.GetElement(txt_new_section_keyword).SendKeys(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "structure" + i);
                driverobj.GetElement(btn_create).Click();
                driverobj.WaitForElement(lbl_return_feedback);
            
            }
        }
        public bool Survey_new_section(string browserstr)
        {
            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(tab_structure);
                driverobj.GetElement(tab_structure).Click();
                newsection(browserstr);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool Survey_link_section(string browserstr)
        {
            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(tab_structure);
                driverobj.GetElement(tab_structure).Click();
                driverobj.WaitForElement(btn_structure_go);
                driverobj.FindSelectElementnew(cmb_editstructure, "Link Existing Section");
                driverobj.GetElement(btn_structure_go).Click();
                driverobj.WaitForElement(txt_search_section);
                driverobj.GetElement(txt_search_section).Clear();
                driverobj.GetElement(txt_search_section).SendKeys("");
                driverobj.GetElement(btn_search_section).Click();
                driverobj.WaitForElement(chk_section);
                driverobj.GetElement(chk_section).Click();
                driverobj.GetElement(btn_select).Click();
                Thread.Sleep(3000);
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool createquestion(string browserstr)
        {

            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(tab_structure);
                driverobj.GetElement(tab_structure).Click();
                driverobj.WaitForElement(btn_edit_section_action1);
                driverobj.FindSelectElementnew(cmb_edit_section_action1, "Manage Questions");
                driverobj.GetElement(btn_edit_section_action1).Click();
                driverobj.WaitForElement(btn_create_link_question);
                driverobj.GetElement(btn_create_link_question).Click();
                driverobj.WaitForElement(txt_create_question);
                driverobj.GetElement(txt_create_question).Clear();
                driverobj.GetElement(txt_create_question).SendKeys(ExtractDataExcel.MasterDic_Survey["Title"]+browserstr + "question" + 1);
                driverobj.FindSelectElementnew(cmb_question_type, "Short Answer");
                driverobj.GetElement(btn_create).Click();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool linkquestion(string browserstr)
        {

            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(tab_structure);
                driverobj.GetElement(tab_structure).Click();
                driverobj.WaitForElement(btn_edit_section_action2);
                driverobj.FindSelectElementnew(cmb_edit_section_action2, "Manage Questions");
                driverobj.GetElement(btn_edit_section_action2).Click();
                driverobj.WaitForElement(cmb_link_question);
                driverobj.FindSelectElementnew(cmb_link_question,"Link Existing Questions");
                driverobj.WaitForElement(btn_create_link_question);
                driverobj.GetElement(btn_create_link_question).Click();
                driverobj.WaitForElement(btn_search_question);
                driverobj.GetElement(btn_search_question).Click();
                driverobj.WaitForElement(chk_link_question);
                driverobj.GetElement(chk_link_question).Click();
                driverobj.GetElement(btn_select_link_question).Click();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool Reorderscetion(string browserstr)
        {

            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(tab_structure);
                driverobj.GetElement(tab_structure).Click();
               driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_ReOrderMenu"));
               driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_ReOrderMenu"),"2");
               driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl03_ReOrderMenu"), "1");
               driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_ML.BASE.BTN.Reorder")).Click();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool deletesurveysection(string browserstr)
        {

            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(tab_structure);
                driverobj.GetElement(tab_structure).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_DataGridItem_SSEC_SECTION_ID"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_DataGridItem_SSEC_SECTION_ID")).Click();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_ML.BASE.BTN.Delete")).Click();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool previewsurvey(string browserstr)
        {

            bool actualresult = false;
         
                try
                {
                    Surveysearch(browserstr);
                    driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                    driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                    driverobj.WaitForElement(tab_structure);
                    driverobj.GetElement(tab_structure).Click();
                    driverobj.WaitForElement(By.Id("Preview"));
                    string originalHandle = driverobj.CurrentWindowHandle;
                    driverobj.GetElement(By.Id("Preview")).Click();
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
                    driverobj.Close();
                   driverobj.SwitchTo().Window("");
                    Thread.Sleep(3000);
                    actualresult = true;
                }
                catch (Exception ex)
                {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
                }
                return actualresult;
          
        }
        public bool publishsurvey(string browserstr)
        {

            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Manage')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Manage')]")).ClickAnchor();
                driverobj.WaitForElement(tab_structure);
                driverobj.GetElement(tab_structure).Click();
                driverobj.WaitForElement(By.Id("ML.BASE.BTN.Publish"));
                driverobj.GetElement(By.Id("ML.BASE.BTN.Publish")).Click();
                driverobj.findandacceptalert();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
        }

        public bool requiredtraining(string browserstr)
        {
            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Required Training')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Required Training')]")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining"));
                driverobj.FindSelectElementnew(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_ML.BASE.TAB.RequiredTraining"), "Assign Training Without Deadline");
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_RequiredTraining_GoPageActionsMenu")).Click();
                driverobj.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole"));
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_SearchRole")).SendKeys(ExtractDataExcel.MasterDic_admin1["Id"]);
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_ML.BASE.BTN.Search")).Click();
                driverobj.WaitForElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0_')]"));
                driverobj.GetElement(By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_AssignTraining_ENTITY_ID_1_ENTITY_LIST_1_0_')]")).Click();
                driverobj.GetElement(By.Id("TabMenu_ML_BASE_TAB_AssignTraining_AssignTraining")).Click();
                driverobj.WaitForElement(lbl_return_feedback);
                driverobj.Close();
                driverobj.SwitchTo().Window("");
                Thread.Sleep(3000);
                actualresult = true;
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
           
        }
        public bool deleteSurvey()
        {
            bool actualresult = false;
            try
            {
                string originalHandle = driverobj.CurrentWindowHandle;
                driverobj.WaitForElement(By.XPath("//a[contains(.,'Delete Content')]"));
                driverobj.GetElement(By.XPath("//a[contains(.,'Delete Content')]")).ClickAnchor();
                driverobj.SwitchWindow("Delete Content");

                driverobj.WaitForElement(By.Id("0"));
                driverobj.GetElement(By.Id("0")).Click();
                Thread.Sleep(5000);
                driverobj.SwitchTo().Window(originalHandle);
                Thread.Sleep(5000);

                driverobj.WaitForElement(By.XPath("//span[@id='ReturnFeedback']"));
                actualresult = true;


            }

            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);

            }
            return actualresult;

        }

        public bool DeleteSurvey(string browserstr)
        {
            bool actualresult = false;
            try
            {
                Surveysearch(browserstr);

                bool result = deleteSurvey();

                if (result == true)
                {
                    driverobj.Close();
                    driverobj.SwitchTo().Window("");
                    Thread.Sleep(3000);
                    actualresult = true;
                }
            }
            catch (Exception ex)
            {ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "",driverobj);
            }
            return actualresult;
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

        private By cmb_edit_section_action1=By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_ActionsMenu");
        private By btn_edit_section_action1 = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_GoButton");
        private By cmb_edit_section_action2 = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl04_ActionsMenu");
        private By btn_edit_section_action2 = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl04_GoButton");
        private By btn_create_link_question = By.Id("TabMenu_ML_BASE_TAB_SurveySectionQuestions_GoPageActionsMenu");
        private By txt_create_question = By.Id("TabMenu_ML_BASE_TAB_SurveyNewQuestion_SQSTLCL_TITLE");
        private By cmb_question_type = By.Id("TabMenu_ML_BASE_TAB_SurveyNewQuestion_SQST_SURVEY_QUESTION_TYPE");
        private By btn_return = By.Id("Return");
        private By cmb_link_question = By.Id("TabMenu_ML_BASE_TAB_SurveySectionQuestions_ML.BASE.TAB.SURVEY.SurveySectionQuestions");
        private By btn_search_question =By.Id("TabMenu_ML_BASE_TAB_SurveySearchQuestion_ML.BASE.BTN.Search");
        private By chk_link_question = By.XPath("//*[contains(@id,'TabMenu_ML_BASE_TAB_SurveySearchQuestion_SurveyListingDataGrid_')]");
        private By btn_select_link_question = By.Id("TabMenu_ML_BASE_TAB_SurveySearchQuestion_ML.BASE.BTN.Select");




    }
}
