using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ChecklistsPage
    {
        public static CreateAndManageCheckListTabOrder CreateAndManageCheckListTab { get { return new CreateAndManageCheckListTabOrder(); } }

        public static EditSectionCommand EditSection { get { return new EditSectionCommand(); } }

        public static void AddANewSection(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lbAddSection']"));
            Driver.waitforframe();
            Driver.GetElement(By.XPath("//input[@id='MainContent_UC1_CSL_CHECKLIST_SECTION_TITLE']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSave']"));
            Driver.Instance.SwitchtoDefaultContent();

        }

        public static void Publish()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnPublish']"));
            Driver.Instance.findandacceptalert();
        }

        public static void ClickBreadcrumb_Ckecklists()
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[4]/a"));
        }

        public static void SelectAndSubmitEvaluator()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_ucChecklistDetails_FormView1_SelectAndSubmitEvalRequest']"));
            Driver.waitforframe();
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_MainContent_UC1_rgLocation_ctl00_ctl04_rbSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_FormView1_Save']"));
            Driver.Instance.SwitchtoDefaultContent();

        }

        public static void Click_ViewChecklist()
        {
            Driver.clickEleJs(By.XPath("//a[@id='ctl00_MainContent_ucChecklistDetails_FormView2_rgEvaluations_ctl00_ctl04_lnkViewChecklist']"));
        }
    }

    public class EditSectionCommand
    {
        public void CreateQuestion(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='ctl00_ctl00_MainContent_MainContent_UC1_rlvSections_ctrl0_rlvQuestions_lbAddQuestion']"));
            Driver.waitforframe();
            Driver.Instance.select(By.XPath("//select[@id='MainContent_UC1_fvQuestion_CQ_CHECKLIST_QUESTION_TYPE_ID']"),v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_fvQuestion_btnGo']"));
            Driver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_fvQuestion_CQL_QUESTION_TITLE']")).SendKeysWithSpace("Earth is round?");


            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_fvQuestion_CSQ_REQUIRED_FLAG']"));

            Driver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_fvQuestion_txtAnswerChoices']")).SendKeysWithSpace("True");
            Driver.GetElement(By.XPath("//textarea[@id='MainContent_UC1_fvQuestion_txtAnswerChoices']")).SendKeysWithSpace("False");
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_btnSave']"));

            Driver.Instance.SwitchtoDefaultContent();




        }
    }

    public class CreateAndManageCheckListTabOrder
    {
        public void CreateNewCheckListInAnyOrder()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_ucTopBar_lnkCreateChecklistAnyOrder']"));
        }

        public void ManageEvaluator(string v)
        {
            Driver.clickEleJs(By.XPath("//a[@id='ctl00_ctl00_MainContent_MainContent_ucTopBar_rgChecklists_ctl00_ctl04_MHyperLink2']"));
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_MainContent_UC1_lnkEvaluatorsAdd']"));
            Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEntities_ctl00_ctl04_chkSelect']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']"));

            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnCancel']"));


        }
    }
}