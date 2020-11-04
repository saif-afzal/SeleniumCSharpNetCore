using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class TestwizardPage
    {
        public static void CreateNewTest(string testTitle)
        {
            Driver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_TITLE']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_TITLE']")).SendKeysWithSpace(testTitle);
            Driver.Instance.GetElement(By.XPath(" //textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_DESCRIPTION']")).SendKeysWithSpace("test");
            Driver.Instance.GetElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditMetadata_TST_KEYWORDS']")).SendKeys("test");
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Create']"));
            Driver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_GoPageActionsMenu']"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_GoPageActionsMenu']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_TITLE']")).SendKeysWithSpace("test");
            Driver.Instance.GetElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_DESCRIPTION']")).SendKeysWithSpace("test");
            Driver.Instance.GetElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_KEYWORDS']")).SendKeysWithSpace("test");
            Driver.Instance.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestionGroup_QGRP_NUM_QUESTIONS']")).SendKeysWithSpace("1");
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Create']"));
            Driver.existsElement(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//input[@id='Return']"));
            Thread.Sleep(5000);
            Driver.select(By.XPath("//select[starts-with(@id,'TabMenu_ML_BASE_TAB_EditStructure_ActionsMenu_1_TestQuestionGroups')]"), "New True/False");
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditStructure_TestQuestionGroups_GoButton_1']"));
            Thread.Sleep(5000);
            Driver.Instance.GetElement(By.XPath("//textarea[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TITLE']")).SendKeysWithSpace("Are you Human?");
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditQuestion_QSTN_TYPE_TRUEFALSE_VALUE_0']"));
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Create']"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//input[@id='Return']"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//input[@id='Return']"));
            Driver.Instance.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_SearchFor']")).SendKeysWithSpace(testTitle);
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search']"));
            Driver.clickEleJs(By.XPath("//a[contains(.,'" + testTitle + "')]"));
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Lock Test')]"));
            Thread.Sleep(5000);
            Driver.clickEleJs(By.XPath("//a[contains(text(),'Publish')]")); //Publish SCORM 1.2
            Thread.Sleep(5000);
            Driver.Instance.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MASTERY_SCORE']")).SendKeysWithSpace("100");
            Driver.Instance.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_QSTNS_PER_PAGE']")).SendKeysWithSpace("1");
            Driver.Instance.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_EditMetadata_CRSW_MAX_ATTEMPTS']")).SendKeysWithSpace("2");

            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Create']"));
            Driver.clickEleJs(By.XPath("//div[@id='TabMenuMLBASETABEditLocationContentLocation_1']//input[@type='checkbox']"));
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
        }

        public static void setApprovalPath()
        {
            Driver.existsElement(By.XPath("//span[contains(text(),'Access Approval')]"));
            Driver.clickEleJs(By.XPath("//span[contains(text(),'Access Approval')]"));
            Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_AssignAccessApproval_ACCESS_APPROVAL_REQUIRED_0"));
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignAccessApproval_ACCESS_APPROVAL_REQUIRED_0")).Click();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignAccessApproval_SearchFor")).Click();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignAccessApproval_SearchFor")).Clear();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignAccessApproval_SearchFor")).SendKeys("admin");
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignAccessApproval_ML.BASE.BTN.Search")).Click();
            Driver.Instance.FindElement(By.XPath("//span/input")).Click();
            Driver.Instance.FindElement(By.Id("ML.BASE.BTN.Save")).Click();
        }

        public static void addPrerequisitetotest(string v="")
        {
            if (v == null)
            {
                Driver.clickEleJs(By.XPath("//a[@id='ML.BASE.WF.EditPrerequisites']/span"));

                Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditPrerequisites_GoPageActionsMenu")).Click();
                Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_AddPrerequisites_SearchFor"));

                Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AddPrerequisites_SearchFor")).Clear();
                Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AddPrerequisites_SearchFor")).SendKeys("general");
                Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AddPrerequisites_ML.BASE.BTN.Search")).Click();
                Thread.Sleep(5000);
                Driver.Instance.FindElement(By.XPath("//span/input")).Click();
                Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AddPrerequisites_AssignPrerequisite")).Click();
                Driver.Instance.FindElement(By.Id("Return")).Click();
            }
            else
            {
                Driver.clickEleJs(By.XPath("//a[@id='ML.BASE.WF.EditPrerequisites']/span"));

                Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditPrerequisites_GoPageActionsMenu")).Click();
                Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_AddPrerequisites_SearchFor"));

                Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AddPrerequisites_SearchFor")).Clear();
                Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AddPrerequisites_SearchFor")).SendKeys(v);
                Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AddPrerequisites_ML.BASE.BTN.Search")).Click();
                Thread.Sleep(5000);
                Driver.Instance.FindElement(By.XPath("//span/input")).Click();
                Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AddPrerequisites_AssignPrerequisite")).Click();
                Driver.Instance.FindElement(By.Id("Return")).Click();
            }
        }

        public static void checkin()
        {
            Driver.clickEleJs(By.XPath(" //span[contains(text(),'Check In')]"));
        }

        public static void addCosttoTest(string v)
        {
            Driver.existsElement(By.XPath("//a[@id='ML.BASE.WF.EditCost']/span"));
            Driver.Instance.FindElement(By.XPath("//a[@id='ML.BASE.WF.EditCost']/span")).Click();
            Driver.Instance.FindElement(By.XPath("//div[@id='TabMenu_div0']/table[2]/tbody/tr/td/table/tbody/tr[2]")).Click();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditCost_CCT_COST")).Clear();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditCost_CCT_COST")).SendKeys("5");
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_EditCost_SaveDefaultCost")).Click();
        }

        public static void AddSurvettoTest(string survey, string test)
        {
            //Driver.existsElement(By.LinkText(test));
            //Driver.clickEleJs(By.LinkText(test));
            Driver.existsElement(By.LinkText("Surveys"));
            Driver.clickEleJs(By.LinkText("Surveys"));
            Driver.existsElement(By.Id("TabMenu_ML_BASE_TAB_Surveys_GoPageActionsMenu"));
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_Surveys_GoPageActionsMenu")).Click();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_SearchFor")).Click();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_SearchFor")).Clear();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_SearchFor")).SendKeys("Before Course Start");
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_ML.BASE.BTN.Search")).Click();
            Driver.Instance.FindElement(By.XPath("//span/input")).Click();
            Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_ML.BASE.BTN.Assign")).Click();
            Thread.Sleep(2000);
            Driver.Instance.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);
            //Driver.Instance.FindElement(By.Id("TabMenu_ML_BASE_TAB_AssignSurvey_ML.BASE.BTN.Assign")).Click();
           
        }

        public static void UploadImagetoTest()
        {
            Driver.existsElement(By.XPath("//a[@id='ML.BASE.WF.AssociatedGraphic']/span"));
            Driver.clickEleJs(By.XPath("//a[@id='ML.BASE.WF.AssociatedGraphic']/span"));
            Driver.existsElement(By.Id("TabMenu_ML_BASE_AssociatedGraphic_UploadFile"));
            Driver.Instance.navigateAICCfile("Data\\test_image.jpg", By.Id("TabMenu_ML_BASE_AssociatedGraphic_UploadFile"));
            Thread.Sleep(3000);
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_AssociatedGraphic_ML.BASE.FORM.EXTERNALFILE_URL"));
            Thread.Sleep(3000);
        }

        public static void PublishtoPublishcatalog()
        {
            Driver.existsElement(By.XPath("//span[@id='ML.BASE.WF.DomainContentSharing']"));
            Driver.clickEleJs(By.XPath("//span[@id='ML.BASE.WF.DomainContentSharing']"));
            Driver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_DomainContentSharing_CNT_IS_PUBLIC']"));
            Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_TAB_DomainContentSharing_CNT_IS_PUBLIC']"));
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
        }

        public static void setPermissionforonlyAdmin()
        {
            Driver.existsElement(By.XPath("//a[@id='ML.BASE.WF.EditUserPermissions']/span"));
            Driver.clickEleJs(By.XPath("//tr[3]/td[4]/span/input"));
            Driver.clickEleJs(By.Id("TabMenu_ML_BASE_TAB_EditPermissions_ML.BASE.BTN.Save"));
        }

    }
}