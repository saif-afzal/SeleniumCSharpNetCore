using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;
using TestAutomation.helper;

namespace Selenium2.Meridian.Suite
{
    public class SurveysPage
    {
        

        public static AddSurveyModalCommand AddSurveyModal { get { return new AddSurveyModalCommand(); } }

        public static resultgridCommand resultgrid { get { return new resultgridCommand(); } }

        public static SurveyResultsCommand SurveyResults { get { return new SurveyResultsCommand(); } }

        public static QuestionTabCommand QuestionTab { get { return new QuestionTabCommand(); } }

        public static bool? isSurveysPresent()
        {
            return Driver.existsElement(By.XPath("//table[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00']/tbody/tr/td/span"));
        }

        public static void ClickAssignSurveys()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnAssignSurveys"));
        }

        public static bool? isSurveysAdded()
        {
            return Driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"));
        }

        public static void Click_backbutton()
        {
          
                Driver.Instance.Navigate().Back();
            
        }

        public static void RemoveSurveys()
        {
            //Driver.existsElement(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"));
            //Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgSurveys_ctl00_ctl04_chkSelect"));
            //Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnRemove"));
            //Driver.Instance.SwitchTo().Alert().Accept();
            //Thread.Sleep(2000);
            Driver.existsElement(By.XPath("//table[@id='tableSurveys']/tbody/tr/td/input"));
            Driver.clickEleJs(By.XPath("//table[@id='tableSurveys']/tbody/tr/td/input"));
            Driver.clickEleJs(By.Id("surveys-btn-remove"));
            Thread.Sleep(2000);



        }


        public static bool? GetFeedbackmessage(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='content']/div[2]/div"));
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text.Equals(v);
        }

        public static bool? IsSurveyPageCompenetsarepresent(string v1, string v2)
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.Id("btnAssignSurvey"));
                Driver.existsElement(By.XPath("//td[contains(text(),'No matching records found')]"));
                result = true;
            }
            catch
            { }
            return result;
        }

        public static void ClickAssignSurveysnew()
        {
            if (Driver.GetElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']")).Text.Equals("Checkout"))
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
            }
            Driver.existsElement(WebElement_Locators.SurveysPage_AssignSurveys_btn);
            Driver.clickEleJs(WebElement_Locators.SurveysPage_AssignSurveys_btn);
            Thread.Sleep(5000);
        }

        public static string AddedSurveysTtile()
        {
            Driver.existsElement(WebElement_Locators.SurveysPage_Resultgrid_FirstSurveyTitle);
            return Driver.GetElement(WebElement_Locators.SurveysPage_Resultgrid_FirstSurveyTitle).Text;
        }

        public static void CreateNewSurvey(string p,string addtocontainer="")
        {
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.GetElement(By.Id("CNTLCL_TITLE")).SendKeysWithSpace(p);
            if(addtocontainer!=null)
            {
                Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_SRVY_INDEPENDENT_CONTENT']"));
            }
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }

        public static void SearchSurvey(string v)
        {
            Driver.GetElement(By.Id("SurveySearchFor")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//button[@id='btnSearchSurveys']/span"));
        }

        public static void CheckIn()
        {
            Driver.existsElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }

        public static string SurveysTitle(string v)
        {
            return Driver.GetElement(By.XPath("//td[contains(text(),"+v+")]")).Text;
        }

        public static void Click_QuestionTab()
        {
            Driver.clickEleJs(By.XPath("//ul[@id='surveyConsoleTabs']/li[2]/a"));
        }

        public static void Click_SurveyTitleFromtheList(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'"+v+"')]"));
        }

        public static bool? isAddSurveyandEvaluationsModalDisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='surveys-add']/div/div/div/h4"));
        }

        public static void RedirectToStructureTab(string v)
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_hlSurveyStructure']"));
        }

        public static void clickSurveyTab()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_hlSurvey']"));
        }
    }

    public class QuestionTabCommand
    {
        public bool? VerifyQuestionTypeInQuestionBank(string v)
        {
            return Driver.existsElement(By.XPath("//td[contains(text(),'"+v+"')]"));
        }

        public void SearchForQuestionInQuestionBank(string question)
        {
            Driver.GetElement(By.XPath("//input[@id='QuestionsSearchFor']")).SendKeysWithSpace(question);
            Driver.clickEleJs(By.XPath("//button[@id='btnSearchQuestions']"));
        }

        public bool? VerifyQuestionInQuestionBank(string question)
        {
            return Driver.GetElement(By.XPath("//table[@id='tableSurveyQuestions']/tbody/tr/td[2]/a")).Text.Equals(question);
        }
    }

    public class SurveyResultsCommand
    {
        public SurveyResultsCommand()
        {
        }

        public bool? isCourselableSurveysDisplay()
        {
            return Driver.existsElement(By.XPath("//strong[@class='badge bg-wrn-lighter text-wrn-darker ml-1']"));
        }

        public bool? isCourselableSurveysarenoneditable()
        {
            return Driver.GetElement(By.XPath("//tr[@data-index='0']//td[4]")).Enabled;
        }

        public void ClickReportDropdown()
        {
            Driver.clickEleJs(By.XPath("//i[@class='fa fa-bar-chart']"));
            Thread.Sleep(2000);
        }

        public void SelectExportbleReport()
        {
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Exportable Report')]"));
        }

        public void ClickSearchedSurveyTilte(string v)
        {
            Driver.existsElement(By.XPath("//a[contains(text(),'" + v + "')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'" + v + "')]"));
        }
    }

    public class resultgridCommand
    {
        public void RequiredforFirstSurvey(string v)
        {
            Driver.existsElement(By.XPath("//a[@class='xeditable xeditable-click']"));
            Driver.clickEleJs(By.XPath("//a[@class='xeditable xeditable-click']"));
            //Driver.GetElement(By.XPath("//table[@id='tableSurveys']/tbody/tr/td[3]/span/div/form/div/div/div/select")).SendKeys("N");
            Thread.Sleep(5000);
            Driver.Instance.select(By.XPath("//table[@id='tableSurveys']/tbody/tr/td[3]/span/div/form/div/div/div/select"), v);
        }

        public bool? SetandVerifyAvailable(string v)
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.XPath("//table[@id='tableSurveys']/tbody/tr/td[4]/a"));
                Driver.clickEleJs(By.XPath("//table[@id='tableSurveys']/tbody/tr/td[4]/a"));
                Thread.Sleep(2000);
                Driver.Instance.select(By.XPath("//table[@id='tableSurveys']/tbody/tr/td[4]/span/div/form/div/div/div"), v);
                Actions action = new Actions(Driver.Instance);
                action.SendKeys(OpenQA.Selenium.Keys.Escape);
                if (Driver.GetElement(By.XPath("//table[@id='tableSurveys']/tbody/tr/td[4]/a")).Text.Equals(v))
                {
                    result = true;
                }
                else
                {
                    result= false;
                }

            }
            catch
            {

            }
            return result;
        }

        public void SetRequiredforFirstSurvey(string v)
        {
            throw new NotImplementedException();
        }

        public bool isrequiredisdisabled()
        {
            Driver.existsElement(By.XPath("//a[@class='xeditable xeditable-click']"));
            return Driver.Instance.FindElement(By.XPath("//a[@class='xeditable xeditable-click']")).Enabled;
        }

        public bool? isRequiredforSurveyDisabled()
        {
           return Driver.GetElement(By.XPath("//a[@class='xeditable xeditable-click']")).Enabled;
        }
    }

    public class AddSurveyModalCommand
    {
        public AllTypedropdownCommand AllTypedropdown { get { return new AllTypedropdownCommand(); } }

        public ResultGridCommand ResultGrid { get { return new ResultGridCommand(); } }

        public AddSurveyModalCommand()
        {
        }

        public bool? IsSearchfieldsDisplayed()
        {
            bool result = false;
            try
            {
                Driver.existsElement(WebElement_Locators.SurveysPage_AddSurveysModal_Search_InputTextbox);
                Driver.existsElement(WebElement_Locators.SurveysPage_AddSurveysModal_Searchlenc_Btn);
                Driver.existsElement(WebElement_Locators.SurveysPage_AddSurveysModal_ResultGrid);
                result = true;
            }
            catch
            { }
            return result;
        }

        public void AddSurveystoContent(string v="")
        {
            if (v == "")
            {
                Driver.existsElement(By.XPath("//input[@id='survey_assign_searchfor']"));
                Driver.clickEleJs(WebElement_Locators.SurveysPage_AddSurveysModal_Searchlenc_Btn);

                Driver.existsElement(WebElement_Locators.SurveysPage_AddSurveysModal_ResultGrid_firstrestltselect_checkbox);
                Driver.clickEleJs(WebElement_Locators.SurveysPage_AddSurveysModal_ResultGrid_firstrestltselect_checkbox);
                Driver.existsElement(WebElement_Locators.SurveysPage_AddSurveysModal_Add_Btn);
                Driver.clickEleJs(WebElement_Locators.SurveysPage_AddSurveysModal_Add_Btn);
            }
            else
            {
                Driver.existsElement(By.XPath("//input[@id='survey_assign_searchfor']"));
                Driver.GetElement(By.XPath("//input[@id='survey_assign_searchfor']")).SendKeysWithSpace(v);
                Driver.clickEleJs(WebElement_Locators.SurveysPage_AddSurveysModal_Searchlenc_Btn);

                Driver.existsElement(WebElement_Locators.SurveysPage_AddSurveysModal_ResultGrid_firstrestltselect_checkbox);
                Driver.clickEleJs(WebElement_Locators.SurveysPage_AddSurveysModal_ResultGrid_firstrestltselect_checkbox);
                Driver.existsElement(WebElement_Locators.SurveysPage_AddSurveysModal_Add_Btn);
                Driver.clickEleJs(WebElement_Locators.SurveysPage_AddSurveysModal_Add_Btn);
            }
        }

        public string AddSurveystoContentWithAvailabilityas(string v)
        {
            string surveyTilte = null;
            try
            {
                Driver.clickEleJs(By.XPath("//div[@id='surveys-add']/div/div/div[2]/div/div/button/span"));
                Thread.Sleep(3000);
                Driver.clickEleJs(By.LinkText("Surveys"));

                Driver.clickEleJs(By.XPath("//a[@id='btnSearchAvailableSurveys']/span"));
                Thread.Sleep(3000);
                Driver.clickEleJs(By.XPath("//table[@id='tableAssignSurveys']/tbody/tr/td/input"));
                surveyTilte = Driver.GetElement(By.XPath("//table[@id='tableAssignSurveys']/tbody/tr/td[2]")).Text;
                Driver.clickEleJs(By.LinkText("When content started"));
               
                Driver.Instance.select(By.XPath("//table[@id='tableAssignSurveys']/tbody/tr/td[4]/span/div/form/div/div/div/select"), v);
                Thread.Sleep(5000);
                Driver.clickEleJs(By.Id("btnAddSurveys"));


            }
            catch { }
            return surveyTilte;
            
        }

        public void ClickAllTypedropdown()
        {
            Driver.clickEleJs(By.XPath("//div[@id='surveys-add']/div/div/div[2]/div/div/button/span"));
        }

        public void clickSearchicon()
        {
            Driver.clickEleJs(By.XPath("//a[@id='btnSearchAvailableSurveys']/span"));
        }
    }

    public class ResultGridCommand
    {
        public ResultGridCommand()
        {
        }

        public bool? isAvailableChangeble()
        {
            return Driver.GetElement(By.XPath("//table[@id='tableAssignSurveys']/tbody/tr/td[4]/a")).Enabled;
        }

        public bool? isEvaluationsDisplay()
        {
            Driver.existsElement(By.XPath("//table[@id='tableAssignSurveys']/tbody/tr/td[2]/small"));
            return Driver.GetElement(By.XPath("//table[@id='tableAssignSurveys']/tbody/tr/td[2]/small")).Text.Equals("Evaluation");
        }

        public bool? isRequiredChangeble()
        {
            return Driver.GetElement(By.LinkText("No")).Enabled;
        }
    }

    public class AllTypedropdownCommand
    {
        public AllTypedropdownCommand()
        {
        }

        public void ClickEvaluations()
        {
            Driver.clickEleJs(By.LinkText("Evaluations"));
        }

        public bool? isEvaluationdisplay()
        {
            return Driver.existsElement(By.LinkText("Evaluations"));
        }
    }
}