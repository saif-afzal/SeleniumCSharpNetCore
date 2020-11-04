using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;

namespace Selenium2.Meridian
{
    class KSA
    {
        //Filling KSA form
        public bool FillKSAPage(IWebDriver driver, string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_KSA.KSA_Create_Button);
                driver.GetElement(Locator_KSA.KSA_Title_TextBox).Clear();
                driver.GetElement(Locator_KSA.KSA_Title_TextBox).SendKeys(Variables.KSATitle+browserstr);
                driver.SwitchTo().Frame(driver.FindElement(Locator_KSA.KSA_Description_TextBox));
                IWebElement a = driver.FindElement(By.CssSelector("body"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].innerHTML = 'TestDesc'", a);
                driver.SwitchTo().DefaultContent();
                driver.GetElement(Locator_KSA.KSA_Keywords_TextBox).SendKeys("TestKeywords");
                driver.GetElement(Locator_KSA.KSA_Create_Button).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }
    }
        public class Locator_KSA
        {
            public static By KSA_Title_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
            public static By KSA_Description_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
            public static By KSA_Keywords_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
            public static By KSA_Create_Button = By.Id("MainContent_UC1_Save");
        }

}
