using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using TestAutomation.helper;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class ReportsConsolePage:ObjectInit
    {
        private IWebDriver objDriver;
        public ReportsConsolePage(IWebDriver objDriver):base(objDriver)
        {
            this.objDriver = objDriver;

        }
        public  int DisplayResult
        {
            get
            {
                System.Threading.Thread.Sleep(10000);
                objDriver.WaitForElement(By.Id("TabMenu_ML_BASE_TAB_Search_FeedbackReportsSearch"));
                return objDriver.getIntegerFromString(objDriver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_FeedbackReportsSearch")).Text);
            }
        }

        public  void SearchText(string v)
        {
           // objDriver..selectWindow("Reports Console");
            objDriver.GetElement(By.Id("TabMenu_ML_BASE_TAB_Search_SearchFor")).SendKeysWithSpace(v);
            objDriver.ClickEleJs(By.Id("TabMenu_ML_BASE_TAB_Search_ML.BASE.BTN.Search"));

        }

        public  void ClickMyTrainingProgress()
        {
            if (!objDriver.existsElement(By.XPath("//a[contains(.,'My Training Progress')]")))
                {
                objDriver.ClickEleJs(By.XPath(".//*[@id='ctl00_MainContent_MyReports_rgReports_ctl00']/thead/tr[1]/td/div/div[2]/nav/ol/li[4]/a"));
            }
            objDriver.ClickEleJs(By.XPath("//a[contains(.,'My Training Progress')]"));
        }

        public  void ClickManagersReportProficiencyRatings()
        {
            objDriver.ClickEleJs(By.LinkText("Manager's Report - Proficiency Ratings"));
        }

        public  void ClickDisplayResult()
        {
            
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Classroom Course Enrollment Summary')]"));

        }

        public  void ClickAllQuestionAllSurveysTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'All Questions, All Surveys.')]"));

        }

        public  void ClickContentUsageTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Content Usage')]"));
        }

        public  void ClickFitJobTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Job Fit')]"));
        }

        public  void ClickCompetencyProgressReportTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Competency Progress')]"));
        }

        public  void ClickManagersReportContentAccessReportTitle()
        {
            objDriver.ClickEleJs(By.LinkText("Manager's Report - Content Access"));
        }

        public  void ClickSF182RequestsTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'SF-182 Requests')]"));
        }

        public  void ClickOrganizationReport_ExternalLearningTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Organization Report - External Learning')]"));
        }

        public  void ClickDomainReport_ExternalLearningTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Domain Report - External Learning')]"));
        }

        public  void ClickRecentUserAccessTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Recent User Access')]"));
        }

        public  void ClickRepeatUserAccessTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Repeat User Access')]"));
        }

        public  void ClickManagersReport_ExternalLearningTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Manager's Report - External Learning')]"));
        }

        public  void ClickOrgReportContentAccessReportTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Organization Report - Content Access')]"));
        }

        public  void ClickTestItemAnalysisResponseSummaryTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Test Item Analysis Response Summary')]"));
        }

        public  void ClickTestItemAnalysisResponseDetailsTitle()
        {
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'Test Item Analysis Response Details')]"));
        }

        public  void ClickSearchReportTitle(string v)
        {
            objDriver.existsElement(By.XPath("//a[contains(text(),'"+v+"')]"));
            objDriver.ClickEleJs(By.XPath("//a[contains(text(),'" + v + "')]"));
        }

        public  void ClickManagersReportExternalLearningTitle()
        {
            objDriver.existsElement(By.LinkText("Manager's Report - External Learning"));
            objDriver.ClickEleJs(By.LinkText("Manager's Report - External Learning"));
        }

        public  void ClickManagersReportTrainingAssignmentTitle()
        {
            objDriver.existsElement(By.LinkText("Manager's Report - Training Assignments"));
            objDriver.ClickEleJs(By.LinkText("Manager's Report - Training Assignments"));
        }

        public  void ClickManagersReportTrainingAssignmentExemptionsTitle()
        {
            objDriver.existsElement(By.LinkText("Manager's Report - Training Assignment Exemptions"));
            objDriver.ClickEleJs(By.LinkText("Manager's Report - Training Assignment Exemptions"));
        }
    }
}