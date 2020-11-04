using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class ContentSettingsPage
    {
        //this is required file
        public static bool? isExternalLearningcontenttobesubmittedforapproval(string v)
        {
            Driver.existsElement(By.XPath("//input[@id='TabMenu_ML_BASE_WF_ContentSettings_SelfAddExternalLearningItem_1']"));
            if (v == "False")
            {
                return Driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_WF_ContentSettings_SelfAddExternalLearningItem_1']")).Selected;
            }
            if (v == "True")
            {
                return Driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_WF_ContentSettings_SelfAddExternalLearningItem_0']")).Selected;
            }
            else return false;
        }

        public static bool? isAutoapproveExternalLearningsubmissionsisNonedititable()
        {
            
            return Driver.GetElement(By.Id("TabMenu_ML_BASE_WF_ContentSettings_AutoApproveExternalLearningItem_0")).Enabled;
        }

        public static void SetExternalLearningcontenttobesubmittedforapproval(string v)
        {
            if(v=="True")
            {
                Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_WF_ContentSettings_SelfAddExternalLearningItem_0']"));
            }
            if (v == "False")
            {
                Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_WF_ContentSettings_SelfAddExternalLearningItem_1']"));
            }
        }

        public static bool? isAutoapproveExternalLearningsubmissions(string v)
        {
            return Driver.GetElement(By.XPath("//input[@id='TabMenu_ML_BASE_WF_ContentSettings_AutoApproveExternalLearningItem_1']")).Selected;
        }

        public static void SetAutoapproveExternalLearningsubmissions(string v)
        {
            if (v == "True")
            {
                Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_WF_ContentSettings_AutoApproveExternalLearningItem_0']"));
            }
            if (v == "False")
            {
                Driver.clickEleJs(By.XPath("//input[@id='TabMenu_ML_BASE_WF_ContentSettings_AutoApproveExternalLearningItem_1']"));
            }
        }

        public static void ClickSave()
        {
            Driver.clickEleJs(By.XPath("//input[@id='ML.BASE.BTN.Save']"));
        }
    }
}