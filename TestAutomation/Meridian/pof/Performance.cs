using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;
using System.Threading;

namespace Selenium2.Meridian
{
    class Performance
    {        
        public bool CreateKSA_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_CreateNewKSA_Link);
                driver.GetElement(Locator_Performance.Performance_CreateNewKSA_Link).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Click on Link to Create KSA", driver);
                return false;
            }
            return true;
        }

        public bool CreateCompetency_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_CreateNewCompetency_Link);
                driver.GetElement(Locator_Performance.Performance_CreateNewCompetency_Link).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool CreateIDPTemplate_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_CreateNewIDPTemplate_Link);
                driver.GetElement(Locator_Performance.Performance_CreateNewIDPTemplate_Link).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool CreateGoal_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_CreateNewGoal_Link);
                driver.GetElement(Locator_Performance.Performance_CreateNewGoal_Link).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool CreateGoalPlanTemplate_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_CreateNewGoalPlanTemplate_Link);
                driver.GetElement(Locator_Performance.Performance_CreateNewGoalPlanTemplate_Link).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool AssignGoalPlanTemplate_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_AssignGoalPlanTemplate_Link);
                driver.GetElement(Locator_Performance.Performance_AssignGoalPlanTemplate_Link).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public string SuccessMsgDisplayed(IWebDriver driver) // For assigning user to goal plan template
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_SuccessMsg_Link);
                return driver.gettextofelement(Locator_Performance.Performance_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return "";
            }
        }

        public bool SearchPerformanceMgmtItem(IWebDriver driver, string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_Search_Button);
                driver.GetElement(Locator_Performance.Performance_SearchFor_Textbox).Clear();
                driver.GetElement(Locator_Performance.Performance_SearchFor_Textbox).SendKeys(Variables.GoalTitle+browserstr);
                driver.select(Locator_Performance.Performance_SearchType_Dropdown,"Exact phrase");
                driver.GetElement(Locator_Performance.Performance_Search_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        //On My Responsibility - Performance Tab
        public bool AddNewRecommendation_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_AddNew_Button);                
                driver.GetElement(Locator_Performance.Performance_AddNew_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        //On My Responsibility - Performance Tab
        public string RecommendationInfoIcon_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_RecommendationTitle_Link);
                string recommendationTitle = driver.gettextofelement(Locator_Performance.Performance_RecommendationTitle_Link);
                driver.WaitForElement(Locator_Performance.Performance_Info_Button);
                driver.GetElement(Locator_Performance.Performance_Info_Button).ClickWithSpace();
                return recommendationTitle;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return "";
            }            
        }

        
        public string ViewAllRecommendationInfoIcon_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_ViewAllRecommendationTitle_Link);
                string recommendationTitle = driver.gettextofelement(Locator_Performance.Performance_ViewAllRecommendationTitle_Link);
                driver.WaitForElement(Locator_Performance.Performance_Info_Button);
                driver.GetElement(Locator_Performance.Performance_Info_Button).ClickWithSpace();
                return recommendationTitle;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return "";
            }
        }

        public string ViewRecommendationInfo(IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().Frame(driver.FindElement(Locator_Performance.Performance_RecommendationInfo_Frame));
               // driver.SelectFrame(Locator_Performance.Performance_RecommendationInfo_Frame);
                driver.WaitForElement(Locator_Performance.Performance_RecommendationTitleFrame_Link);
                string recommendationTitleFrame = driver.gettextofelement(Locator_Performance.Performance_RecommendationTitleFrame_Link);
                driver.SwitchTo().DefaultContent();
                driver.WaitForElement(Locator_Performance.Performance_CloseFrame_Button);
                driver.GetElement(Locator_Performance.Performance_CloseFrame_Button).ClickWithSpace();
                return recommendationTitleFrame;
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return "";
            }
        }

        //On My Responsibility - Performance Tab
        public bool ViewAllRecommendation_Click(IWebDriver driver)
        {
            try
            {
                Thread.Sleep(2000);
                driver.ScrollToCoordinated("500", "500");
                driver.WaitForElement(Locator_Performance.Performance_ViewAllRecommendation_Button);
                driver.GetElement(Locator_Performance.Performance_ViewAllRecommendation_Button).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool ViewSections_DevPlans_GoalPlans(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_UserDevPlan_Link);
                driver.GetElement(Locator_Performance.Performance_UserDevPlan_Link);
                driver.GetElement(Locator_Performance.Performance_PendingIDPs_Link);
                driver.GetElement(Locator_Performance.Performance_GoalPlanning_Link);
                driver.GetElement(Locator_Performance.Performance_PendingGoalPlans_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool ViewRejectedIDPs_Click(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Performance.Performance_ViewRejectedIDPs_Button);
                driver.GetElement(Locator_Performance.Performance_ViewRejectedIDPs_Button).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }
    }

    public class Locator_Performance
    {
        public static By Performance_CreateNewKSA_Link = By.XPath("//a[contains(.,'Create New KSA')]");
        public static By Performance_CreateNewCompetency_Link = By.XPath("//a[contains(.,'Create New Competency')]");
        public static By Performance_CreateNewIDPTemplate_Link = By.XPath("//a[contains(.,'Create New IDP Template')]");
        public static By Performance_CreateNewGoal_Link = By.XPath("//a[@href='../PM/Goal/CreateGoal.aspx']"); //By.XPath("//a[contains(.,'Create New Goal')]");
        public static By Performance_CreateNewGoalPlanTemplate_Link = By.XPath("//a[contains(.,'Create New Goal Plan Template')]");
        public static By Performance_AssignGoalPlanTemplate_Link = By.XPath("//a[contains(.,'Assign Goal Plan Template')]");
        public static By Performance_SuccessMsg_Link = By.XPath("//div[@class='alert alert-success']");
        public static By Performance_SearchFor_Textbox = By.Id("MainContent_ucSearch_FormView1_SearchFor");
        public static By Performance_SearchType_Dropdown = By.Id("MainContent_ucSearch_FormView1_SearchType");
        public static By Performance_Search_Button = By.Id("btnSearchCourses");
        public static By Performance_AddNew_Button = By.Id("MainContent_ucRecentRecommendations_btnAddNew");
        public static By Performance_Info_Button = By.Id("ctl00_MainContent_UC4_rgRecentRecommendations_ctl00_ctl04_MImageButton1");
        public static By Performance_RecommendationTitle_Link = By.XPath("//tr[@id='ctl00_MainContent_ucRecentRecommendations_ucRecomendationGrid_rgRecentRecommendations_ctl00__0']/td[2]");
        public static By Performance_ViewAllRecommendationTitle_Link = By.XPath("//tr[@id='ctl00_MainContent_UC4_rgRecentRecommendations_ctl00__0']/td[2]");
        public static By Performance_RecommendationTitleFrame_Link = By.CssSelector("h6"); //By.XPath("//div[@id='pnlContent']/div/div[3]/div/h6");        
        public static By Performance_RecommendationInfo_Frame = By.ClassName("k-content-frame");
        public static By Performance_ViewAllRecommendation_Button = By.XPath("//a[contains(.,'View All Recommendations')]");// By.Id("MainContent_ucRecentRecommendations_MlbViewAll");
        public static By Performance_CloseFrame_Button = By.XPath("//span[@class='k-icon k-i-close']");

        public static By Performance_UserDevPlan_Link = By.XPath("//h2[contains(.,'Individual Development Plan (IDP)')]");
        public static By Performance_PendingIDPs_Link = By.Id("MainContent_ucApprovalLinksIDP_lblInstruction");
        public static By Performance_GoalPlanning_Link = By.XPath("//h2[contains(.,'Goal Planning')]");
        public static By Performance_PendingGoalPlans_Link = By.Id("MainContent_ucApprovalLinksGOAL_lblInstruction");
        public static By Performance_ViewRejectedIDPs_Button = By.Id("MainContent_ucApprovalLinksIDP_hlRejectedIDP");
        
    }
}
