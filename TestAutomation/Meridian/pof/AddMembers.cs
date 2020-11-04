using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;

namespace Selenium2.Meridian
{
    class AddMembers
    {
        // Search Instructor and add to the domain
        public bool SearchInstructor(IWebDriver driver,string browserstr)
        {
            bool actualresult = false;
            try
            {
                driver.WaitForElement(Locator_AddMembers.AddMembers_Search_Button);
                driver.GetElement(Locator_AddMembers.AddMembers_SearchText_Textbox).SendKeysWithSpace(ExtractDataExcel.MasterDic_instructor["Firstname"]+browserstr);
                driver.select(Locator_AddMembers.AddMembers_SearchType_Dropdown,"Ends with");
                driver.GetElement(Locator_AddMembers.AddMembers_Search_Button).ClickWithSpace();

                driver.WaitForElement(Locator_AddMembers.AddMembers_Add_Button);
                driver.GetElement(Locator_AddMembers.AddMembers_InstructorsName_Checkbox).ClickWithSpace();
                driver.GetElement(Locator_AddMembers.AddMembers_Add_Button).ClickWithSpace();
                driver.findandacceptalert();
               actualresult = driver.existsElement(Locator_AddMembers.AddMembers_Feedback_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                
            }
            return actualresult;
        }
    }

    class Locator_AddMembers
    {
        public static By AddMembers_SearchText_Textbox = By.Id("TabMenu_ML_BASE_TAB_AddMembers_SearchFor");
        public static By AddMembers_SearchType_Dropdown = By.Id("TabMenu_ML_BASE_TAB_AddMembers_SearchType");
        public static By AddMembers_Search_Button = By.Id("TabMenu_ML_BASE_TAB_AddMembers_ML.BASE.BTN.Search");
        public static By AddMembers_InstructorsName_Checkbox = By.XPath("//input[contains(@id,'TabMenu_ML_BASE_TAB_AddMembers_ENTITY_ID_1_DomainNewMembers_1_0_')]");
        public static By AddMembers_Add_Button = By.Id("TabMenu_ML_BASE_TAB_AddMembers_AddDomainMembership");
        public static By AddMembers_Feedback_Link = By.Id("ReturnFeedback");
    }
}
