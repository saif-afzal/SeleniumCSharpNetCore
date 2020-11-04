using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;

namespace Selenium2.Meridian
{
    class AdminConsole_Surveys
    {

        public bool CreateSurveys(IWebDriver driver, string browserstr)
        {
            bool actualresult = false;
            try
            {
                driver.WaitForElement(Locator_AdminSurveys.Surveys_Go_Button);
                driver.FindElement(Locator_AdminSurveys.Surveys_Go_Button).ClickWithSpace();

                driver.WaitForElement(Locator_AdminSurveys.Surveys_Create_Button);
                driver.GetElement(Locator_AdminSurveys.Surveys_Title_Textbox).SendKeysWithSpace(Variables.surveyTitle+browserstr);
                driver.GetElement(Locator_AdminSurveys.Surveys_Description_Textbox).SendKeysWithSpace("SurveyDesc");
                driver.GetElement(Locator_AdminSurveys.Surveys_Keywords_Textbox).SendKeysWithSpace("SurveyKeywords");
                driver.GetElement(Locator_AdminSurveys.Surveys_Create_Button).ClickWithSpace();

                driver.WaitForElement(Locator_AdminSurveys.Surveys_GoSection_Button);
                driver.GetElement(Locator_AdminSurveys.Surveys_GoSection_Button).ClickWithSpace();

                driver.WaitForElement(Locator_AdminSurveys.Surveys_Create_Button);
                driver.GetElement(Locator_AdminSurveys.Surveys_TitleSection_Textbox).SendKeysWithSpace(Variables.sectionTitle+browserstr);
                driver.GetElement(Locator_AdminSurveys.Surveys_DescriptionSection_Textbox).SendKeysWithSpace("desc");
                driver.GetElement(Locator_AdminSurveys.Surveys_KeywordsSection_Textbox).SendKeysWithSpace("keywords");
                driver.GetElement(Locator_AdminSurveys.Surveys_Create_Button).ClickWithSpace();
             //   driver.WaitForElement(By.Id("ML.BASE.BTN.Create"));
            //    driver.GetElement(By.Id("ML.BASE.BTN.Create")).ClickWithSpace();
                driver.WaitForElement(Locator_AdminSurveys.Surveys_AddQuestion_Dropdown);
                SelectElement selector = new SelectElement(driver.FindElement(Locator_AdminSurveys.Surveys_AddQuestion_Dropdown));
                selector.SelectByValue("ML.BASE.ACT.ManageQuestions");
                driver.GetElement(Locator_AdminSurveys.Surveys_GoAddQuestion_Button).ClickWithSpace();

                driver.WaitForElement(Locator_AdminSurveys.Surveys_GoCreateQuestion_Button);
                driver.GetElement(Locator_AdminSurveys.Surveys_GoCreateQuestion_Button).ClickWithSpace();

                driver.WaitForElement(Locator_AdminSurveys.Surveys_Create_Button);
                driver.GetElement(Locator_AdminSurveys.Surveys_Question_Textbox).SendKeysWithSpace(Variables.question+browserstr);
                SelectElement selectQues = new SelectElement(driver.FindElement(Locator_AdminSurveys.Surveys_Type_Dropdown));
                selectQues.SelectByValue("ML.BASE.SRQT_SURVEY_QUESTION_TYPE.ShortAnswer");
                driver.GetElement(Locator_AdminSurveys.Surveys_Create_Button).ClickWithSpace();

                driver.WaitForElement(Locator_AdminSurveys.Surveys_Return_Button);
                driver.GetElement(Locator_AdminSurveys.Surveys_Return_Button).ClickWithSpace();

                driver.WaitForElement(Locator_AdminSurveys.Surveys_Publish_Button);
                driver.GetElement(Locator_AdminSurveys.Surveys_Publish_Button).ClickWithSpace();
                driver.SwitchTo().Alert().Accept();
              actualresult =  driver.existsElement(Locator_AdminSurveys.Surveys_SuccessMsg_Link);
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                
            }
            return actualresult;
        }
    }

    public class Locator_AdminSurveys
    {
        public static By Surveys_Go_Button = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public static By Surveys_Title_Textbox = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_SRVY_TITLE");
        public static By Surveys_Description_Textbox = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_SRVY_DESCRIPTION");
        public static By Surveys_Keywords_Textbox = By.Id("TabMenu_ML_BASE_TAB_EditMetadata_SRVY_KEYWORDS");
        public static By Surveys_Create_Button = By.Id("ML.BASE.BTN.Create");
        public static By Surveys_GoSection_Button = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_GoPageActionsMenu");
        public static By Surveys_TitleSection_Textbox = By.Id("TabMenu_ML_BASE_TAB_SurveyNewSection_SSECLCL_TITLE");
        public static By Surveys_DescriptionSection_Textbox = By.Id("TabMenu_ML_BASE_TAB_SurveyNewSection_SSECLCL_DESCRIPTION");
        public static By Surveys_KeywordsSection_Textbox = By.Id("TabMenu_ML_BASE_TAB_SurveyNewSection_SSECLCL_KEYWORDS");
        public static By Surveys_AddQuestion_Dropdown = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_ActionsMenu");
        public static By Surveys_GoAddQuestion_Button = By.Id("TabMenu_ML_BASE_TAB_DefineSurveyStructure_SurveySectionListingDataGrid_ctl02_GoButton");
        public static By Surveys_GoCreateQuestion_Button = By.Id("TabMenu_ML_BASE_TAB_SurveySectionQuestions_GoPageActionsMenu");
        public static By Surveys_Question_Textbox = By.Id("TabMenu_ML_BASE_TAB_SurveyNewQuestion_SQSTLCL_TITLE");
        public static By Surveys_Type_Dropdown = By.Id("TabMenu_ML_BASE_TAB_SurveyNewQuestion_SQST_SURVEY_QUESTION_TYPE");
        public static By Surveys_Return_Button = By.Id("Return");
        public static By Surveys_Publish_Button = By.Id("ML.BASE.BTN.Publish");
        public static By Surveys_SuccessMsg_Link = By.Id("ReturnFeedback");
    }
}
