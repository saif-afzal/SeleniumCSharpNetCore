using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;

namespace Selenium2.Meridian
{
    class EditStructure
    {
        // Add existing goals to Goal plan template
        public bool AddExistingGoals(IWebDriver driver, string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_EditStructure.EditStructure_AddExistingGoals_Link);
                driver.GetElement(Locator_EditStructure.EditStructure_AddExistingGoals_Link).ClickWithSpace();
                
                driver.SwitchTo().Frame(driver.GetElement(Locator_EditStructure.EditStructure_AddExistingGoals_Frame));
                driver.GetElement(Locator_EditStructure.EditStructure_SearchFor_Textbox).Clear();
                driver.GetElement(Locator_EditStructure.EditStructure_SearchFor_Textbox).SendKeys(Variables.GoalTitle+browserstr);
                driver.select(Locator_EditStructure.EditStructure_SearchType_Dropdown, "Exact phrase");
                driver.GetElement(Locator_EditStructure.EditStructure_Search_Button).ClickWithSpace();

                driver.WaitForElement(Locator_EditStructure.EditStructure_Add_Button);
                driver.GetElement(Locator_EditStructure.EditStructure_GoalName_Checkbox).ClickWithSpace();
                driver.GetElement(Locator_EditStructure.EditStructure_Add_Button).ClickWithSpace();
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }

        public string SuccessMsgDisplayed(IWebDriver driver) // For adding existing goal to goal plan template 
        {
            try
            {
                driver.WaitForElement(Locator_EditStructure.EditStructure_SuccessMsg_Link);
                return driver.gettextofelement(Locator_EditStructure.EditStructure_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return "";
            }
        }
    }

    public class Locator_EditStructure
    {
        public static By EditStructure_AddExistingGoals_Link = By.Id("MainContent_MainContent_UC1_lbAddExistingGoal");
        public static By EditStructure_AddExistingGoals_Frame = By.ClassName("k-content-frame");
        public static By EditStructure_SearchFor_Textbox = By.Id("MainContent_UC1_SearchFor");
        public static By EditStructure_SearchType_Dropdown = By.Id("MainContent_UC1_SearchType");
        public static By EditStructure_Search_Button = By.Id("MainContent_UC1_btnSearch");
        public static By EditStructure_GoalName_Checkbox = By.Id("ctl00_MainContent_UC1_rgLearning_ctl00_ctl04_chkSelect");
        public static By EditStructure_Add_Button = By.Id("MainContent_UC1_FormView1_Select");
        public static By EditStructure_SuccessMsg_Link = By.ClassName("forms-msg-success");
    }
}
