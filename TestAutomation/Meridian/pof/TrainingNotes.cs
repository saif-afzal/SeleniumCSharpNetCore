using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;

namespace Selenium2.Meridian
{
    class TrainingNotes
    {
        public bool AddNotes(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_TrainingNotes.TrainingNotes_AddNote_Button);
                driver.GetElement(Locator_TrainingNotes.TrainingNotes_AddNote_Button).Click();
                driver.WaitForElement(Locator_TrainingNotes.TrainingNotes_AddNote_Frame);
                driver.SwitchTo().Frame(driver.GetElement(Locator_TrainingNotes.TrainingNotes_AddNote_Frame));
                driver.GetElement(Locator_TrainingNotes.TrainingNotes_Note_Textbox).SendKeys("TestNote");
                driver.GetElement(Locator_TrainingNotes.TrainingNotes_Add_Button).Click();
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name, "Unable to Add Notes for Learner", driver);
                return false;
            }
            return true;
        }

        public string SuccessMsgDisplayed(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_ManageStudents.ManageStudents_SuccessMsg_Link);
                return driver.gettextofelement(Locator_ManageStudents.ManageStudents_SuccessMsg_Link);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return "";
            }
        }

        public bool NoteAddedToTranscript(IWebDriver driver)
        {
            try
            {
                driver.WaitForElement(Locator_TrainingNotes.TrainingNotes_Transcript_Label);
                driver.GetElement(Locator_TrainingNotes.TrainingNotes_Transcript_Label);
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }
    }

    class Locator_TrainingNotes
    {
        public static By TrainingNotes_AddNote_Button = By.Id("MainContent_ucViewTranscriptNotes_btnAddNote");
        public static By TrainingNotes_AddNote_Frame = By.ClassName("k-content-frame");
        public static By TrainingNotes_Note_Textbox = By.Id("MainContent_UC1_txtNote");
        public static By TrainingNotes_Add_Button = By.Id("MainContent_UC1_btnSave");
        public static By TrainingNotes_SuccessMsg_Link = By.XPath("//div[@class='alert alert-success']");
        public static By TrainingNotes_Transcript_Label = By.XPath("//td[contains(.,'TestNote')]");
    }
}
