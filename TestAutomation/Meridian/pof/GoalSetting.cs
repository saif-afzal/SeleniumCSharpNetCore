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
    class GoalSetting
    {
        //Filling Goal form
        public bool FillGoalPage(IWebDriver driver, string title)
        {
            try
            {
                driver.WaitForElement(Locator_GoalSetting.GoalSetting_Create_Button);
                Thread.Sleep(3000);
                driver.GetElement(Locator_GoalSetting.GoalSetting_Title_TextBox).SendKeys(title);
                driver.SwitchTo().Frame(driver.FindElement(Locator_GoalSetting.GoalSetting_Description_TextBox));
                IWebElement a = driver.FindElement(By.CssSelector("body"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].innerHTML = 'TestDesc'", a);
                driver.SwitchTo().DefaultContent();
                driver.GetElement(Locator_GoalSetting.GoalSetting_Keywords_TextBox).SendKeys("TestKeywords");
                driver.GetElement(Locator_GoalSetting.GoalSetting_Create_Button).ClickWithSpace();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }
    }
    public class Locator_GoalSetting
    {
        public static By GoalSetting_Title_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        public static By GoalSetting_Description_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        public static By GoalSetting_Keywords_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
        public static By GoalSetting_Create_Button = By.Id("MainContent_UC1_Save");
    }
}
