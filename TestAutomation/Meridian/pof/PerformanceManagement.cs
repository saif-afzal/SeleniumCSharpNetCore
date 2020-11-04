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
    class PerformanceManagement
    {
        //Filling Competency form
        public bool FillCompetencyPage(IWebDriver driver, string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_Create_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Title_TextBox).SendKeys(Variables.CompetencyTitle+browserstr);
                driver.SwitchTo().Frame(driver.FindElement(Locator_PerformanceManagement.PerformanceManagement_Description_TextBox));
                IWebElement a = driver.FindElement(By.CssSelector("body"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].innerHTML = 'TestDesc'", a);
                driver.SwitchTo().DefaultContent();
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Keywords_TextBox).SendKeys("TestKeywords");
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Create_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool AddKSA_Click(IWebDriver driver, string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_AddExistingKSA_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_AddExistingKSA_Button).ClickWithSpace();
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_AddExistingKSA_Frame);
                driver.SwitchTo().Frame(driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_AddExistingKSA_Frame));
                
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_Search_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SearchFor_Textbox).Clear();
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SearchFor_Textbox).SendKeys(Variables.KSATitle+browserstr);
                driver.select(Locator_PerformanceManagement.PerformanceManagement_SearchType_Dropdown, "Exact phrase");
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Search_Button).ClickWithSpace();

                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_Add_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_KSATitle_Checkbox).ClickWithSpace();
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Add_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }


        public bool AssignUserToGoalPlanTemplate(IWebDriver driver, string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_Search_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_FirstName_Textbox).SendKeys(ExtractDataExcel.MasterDic_admin["Firstname"]);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Search_Button).ClickWithSpace();

                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_Username_OptionButton);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Username_OptionButton).ClickWithSpace();
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Select_Button).ClickWithSpace();

                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_SearchFor_Textbox);
                Thread.Sleep(3000);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SearchFor_Textbox).SendKeys(Variables.goalPlanTemplateTitle+browserstr);
                driver.select(Locator_PerformanceManagement.PerformanceManagement_SearchType_Dropdown, "Exact phrase");
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Search_Button).ClickWithSpace();

                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_Assign_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_TemplateName_Optionbutton).ClickWithSpace();
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Assign_Button).ClickWithSpace();
                driver.SwitchTo().Alert().Accept();
                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        // Search Item associated with Recommendation Item on My Responsibilty - Performance Tab
        public bool SearchKSAAndAddToClassroomCourse(IWebDriver driver, string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_SearchItem_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SearchForItem_Textbox).SendKeys(Variables.KSATitle+browserstr);
                driver.select(Locator_PerformanceManagement.PerformanceManagement_SearchTypeItem_Dropdown, "Starts with");
                driver.select(Locator_PerformanceManagement.PerformanceManagement_TypeItem_Dropdown, "KSA");
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SearchItem_Button).ClickWithSpace();
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_ItemName_OptionButton);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_ItemName_OptionButton).ClickWithSpace();
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SelectItem_Button).ClickWithSpace();

                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_SearchRecommendationItem_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SearchForRecommendationItem_Textbox).SendKeys(Variables.classroomCourseTitle+browserstr);
                driver.select(Locator_PerformanceManagement.PerformanceManagement_SearchTypeRecommendationItem_Dropdown, "Starts with");
                driver.select(Locator_PerformanceManagement.PerformanceManagement_TypeRecommendationItem_Dropdown, "Classroom");
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SearchRecommendationItem_Button).ClickWithSpace();
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_SaveRecommendationItem_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_RecommendationItemName_Checkbox).ClickWithSpace();
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SaveRecommendationItem_Button).ClickWithSpace();      
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public string SuccessMsgDisplayed(IWebDriver driver) // For adding/deleting recommendation
        {
            try
            {
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_SuccessMsg_Link);
                return driver.gettextofelement(Locator_PerformanceManagement.PerformanceManagement_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return "";
            }
        }

        public bool SearchRecommendation(IWebDriver driver, string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_SearchRecommendation_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SearchForRecommendation_Textbox).Clear();
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SearchForRecommendation_Textbox).SendKeys(Variables.KSATitle+browserstr);
                driver.select(Locator_PerformanceManagement.PerformanceManagement_SearchTypeRecommendation_Dropdown, "Exact phrase");
                driver.select(Locator_PerformanceManagement.PerformanceManagement_TypeRecommendation_Dropdown, "KSA");
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_SearchRecommendation_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool ViewRecommendation(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_RecommendationTitle_Link);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_RecommendationTitle_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool CreateRecommendation(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_CreateRecommendation_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_CreateRecommendation_Button).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public bool DeleteRecommendation(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_PerformanceManagement.PerformanceManagement_Delete_Button);
                driver.GetElement(Locator_PerformanceManagement.PerformanceManagement_Delete_Button).Click();
                driver.SwitchTo().Alert().Accept();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }
    }
    public class Locator_PerformanceManagement
    {
        public static By PerformanceManagement_Title_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        public static By PerformanceManagement_Description_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        public static By PerformanceManagement_Keywords_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
        public static By PerformanceManagement_Create_Button = By.Id("MainContent_UC1_Save");
        public static By PerformanceManagement_AddExistingKSA_Button = By.Id("MainContent_MainContent_UC1_lnkbtnAddKSA");
        public static By PerformanceManagement_AddExistingKSA_Frame = By.ClassName("k-content-frame");
        public static By PerformanceManagement_SearchFor_Textbox = By.Id("MainContent_UC1_SearchFor");
        public static By PerformanceManagement_SearchType_Dropdown = By.Id("MainContent_UC1_SearchType");
        public static By PerformanceManagement_Search_Button = By.Id("MainContent_UC1_btnSearch");
        public static By PerformanceManagement_KSATitle_Checkbox = By.Id("ctl00_MainContent_UC1_rgLearning_ctl00_ctl04_chkSelect");
        public static By PerformanceManagement_Add_Button = By.Id("MainContent_UC1_FormView1_Select");
        public static By PerformanceManagement_FirstName_Textbox = By.Id("MainContent_UC1_USR_FIRST_NAME");
        public static By PerformanceManagement_Username_OptionButton = By.Id("ctl00_MainContent_UC1_rgUserSearch_ctl00_ctl04_rbSelect");
        public static By PerformanceManagement_Select_Button = By.Id("MainContent_UC1_FormView1_Select");
        public static By PerformanceManagement_TemplateName_Optionbutton = By.Id("ctl00_MainContent_UC1_rgTemplateSearch_ctl00_ctl04_rbSelect");
        public static By PerformanceManagement_Assign_Button = By.Id("MainContent_UC1_FormView1_btnAssign");

        public static By PerformanceManagement_SearchForItem_Textbox = By.Id("MainContent_UC4_Search");
        public static By PerformanceManagement_SearchTypeItem_Dropdown = By.Id("MainContent_UC4_SearchType");
        public static By PerformanceManagement_TypeItem_Dropdown = By.Id("MainContent_UC4_SearchFor");
        public static By PerformanceManagement_SearchItem_Button = By.Id("MainContent_UC4_btnSearch");
        public static By PerformanceManagement_ItemName_OptionButton = By.Id("ctl00_MainContent_UC4_rgPrimaryItem_ctl00_ctl04_rbSelect");
        public static By PerformanceManagement_SelectItem_Button = By.Id("MainContent_UC4_btnSelect");

        public static By PerformanceManagement_SearchForRecommendationItem_Textbox = By.Id("MainContent_UC3_Search");
        public static By PerformanceManagement_SearchTypeRecommendationItem_Dropdown = By.Id("MainContent_UC3_SearchType");
        public static By PerformanceManagement_TypeRecommendationItem_Dropdown = By.Id("MainContent_UC3_SearchFor");
        public static By PerformanceManagement_SearchRecommendationItem_Button = By.Id("MainContent_UC3_btnSearch");
        public static By PerformanceManagement_RecommendationItemName_Checkbox = By.Id("ctl00_MainContent_UC3_rgLearning_ctl00_ctl04_chkSelect");
        public static By PerformanceManagement_SaveRecommendationItem_Button = By.Id("MainContent_UC3_Save");

        public static By PerformanceManagement_SuccessMsg_Link = By.XPath("//div[@class='alert alert-success']");
        public static By PerformanceManagement_SearchForRecommendation_Textbox = By.Id("MainContent_UC1_txtSearch");
        public static By PerformanceManagement_SearchTypeRecommendation_Dropdown = By.Id("MainContent_UC1_ddlSearchType");
        public static By PerformanceManagement_TypeRecommendation_Dropdown = By.Id("MainContent_UC1_ddlSearchFor");
        public static By PerformanceManagement_SearchRecommendation_Button = By.Id("MainContent_UC1_btnSearch");

        public static By PerformanceManagement_RecommendationTitle_Link = By.XPath("//tr[@id='ctl00_MainContent_UC4_rgRecentRecommendations_ctl00__0']/td[2]");
        public static By PerformanceManagement_CreateRecommendation_Button = By.Id("MainContent_UC1_MlbViewAll");
        public static By PerformanceManagement_Delete_Button = By.Id("ctl00_MainContent_UC4_rgRecentRecommendations_ctl00_ctl04_MImgDeleteItem");
    }

}
