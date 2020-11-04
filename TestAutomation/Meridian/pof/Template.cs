using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Reflection;
using Selenium2.Meridian;

namespace Selenium2.Meridian
{
    class Template
    {
        //Filling IDP Template form
        public bool FillIDPTemplatePage(IWebDriver driver, string browserstr)
        {
            try
            {
                driver.WaitForElement(Locator_IDPTemplate.IDPTemplate_Create_Button);
                driver.GetElement(Locator_IDPTemplate.IDPTemplate_Title_TextBox).SendKeys(Variables.IDPTemplateTitle+browserstr);
                driver.SwitchTo().Frame(driver.FindElement(Locator_IDPTemplate.IDPTemplate_Description_TextBox));
                IWebElement a = driver.FindElement(By.CssSelector("body"));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].innerHTML = 'TestDesc'", a);
                driver.SwitchTo().DefaultContent();
                driver.GetElement(Locator_IDPTemplate.IDPTemplate_Keywords_TextBox).SendKeys("TestKeywords");
                driver.GetElement(Locator_IDPTemplate.IDPTemplate_Create_Button).Click();
            }
            catch (Exception ex)
            {
                ExceptionandLogging.ExceptionLogging(ex, Meridian_Common.CurrentTestName, this.GetType().Name, MethodBase.GetCurrentMethod().Name,"",driver);
                return false;
            }
            return true;
        }
    }
    public class Locator_IDPTemplate
    {
        public static By IDPTemplate_Title_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_TITLE");
        public static By IDPTemplate_Description_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_DESCRIPTION");
        public static By IDPTemplate_Keywords_TextBox = By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS");
        public static By IDPTemplate_Create_Button = By.Id("MainContent_UC1_Save");
    }
}
