using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;

namespace Selenium2.Meridian
{
    class Instructorspof
    {
        public bool CreateInstructor_Click(IWebDriver driver, string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_Instructors.Instructors_Go_Button);
                driver.GetElement(Locator_Instructors.Instructors_Go_Button).ClickWithSpace();

                driver.WaitForElement(Locator_Instructors.Instructors_Search_Button);
                driver.GetElement(Locator_Instructors.Instructors_LastName_Textbox).Clear();
                driver.GetElement(Locator_Instructors.Instructors_LastName_Textbox).SendKeysWithSpace(ExtractDataExcel.MasterDic_instructor["Lastname"]+browserstr);
                driver.GetElement(Locator_Instructors.Instructors_FirstName_Textbox).SendKeysWithSpace(ExtractDataExcel.MasterDic_instructor["Firstname"]+browserstr);
                driver.GetElement(Locator_Instructors.Instructors_Search_Button).ClickWithSpace();

                driver.WaitForElement(Locator_Instructors.Instructors_AddSelected_Button);
                driver.GetElement(Locator_Instructors.Instructors_username_Checkbox).ClickWithSpace();
                driver.GetElement(Locator_Instructors.Instructors_AddSelected_Button).ClickWithSpace();
                driver.WaitForElement(Locator_Instructors.Instructors_Feedback_Link);
                
                //driver.GetElement(Locator_Instructors.Instructors_AdminConsole_Link).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }
    }

    class Locator_Instructors
    {
        public static By Instructors_Go_Button = By.Id("TabMenu_ML_BASE_TAB_Search_GoPageActionsMenu");
        public static By Instructors_LastName_Textbox = By.Id("TabMenu_ML_BASE_TAB_AddUsers_USR_LAST_NAME");
        public static By Instructors_FirstName_Textbox = By.Id("TabMenu_ML_BASE_TAB_AddUsers_USR_FIRST_NAME");
        
        public static By Instructors_Search_Button = By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnSearch");
        public static By Instructors_username_Checkbox = By.Id("TabMenu_ML_BASE_TAB_AddUsers_ContentUsers_ctl02_DataGridItem_PRM_ENTITY_NAME");
        public static By Instructors_AddSelected_Button = By.Id("TabMenu_ML_BASE_TAB_AddUsers_btnAdd");
        public static By Instructors_Feedback_Link = By.Id("ReturnFeedback");
        public static By Instructors_AdminConsole_Link = By.XPath("//a[contains(.,'Administration Console')]");
    }
}
