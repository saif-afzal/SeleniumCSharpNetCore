using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
//using Meridian.Utility;

namespace Selenium2.Meridian
{
    class Objective
    {
        public bool AddObjective(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Objective.Objective_Add_Button);
                driver.GetElement(Locator_Objective.Objective_Objective_Textbox).SendKeysWithSpace("TestObjective");
                driver.ScrollToCoordinated("500", "500");
                driver.WaitForElement(Locator_Objective.Objective_Add_Button);
                driver.GetElement(Locator_Objective.Objective_Add_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Populate and Add Objectives", driver);
                return false;
            }
            return true;
        }

        public string SuccessMsg_Objective(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_Objective.Objective_SuccessMsg_Link);
                return driver.gettextofelement(Locator_Objective.Objective_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return "";
            }
        }
    }

    public class Locator_Objective
    {
        public static By Objective_Objective_Textbox = By.Id("MainContent_MainContent_UC1_txtObjective");
        public static By Objective_Add_Button = By.Id("MainContent_MainContent_UC1_btnAdd");
        public static By Objective_SuccessMsg_Link = By.XPath("//div[@class='alert alert-success']");
    }
}
