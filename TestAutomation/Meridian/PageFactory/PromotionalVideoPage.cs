using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class PromotionalVideoPage
    {
        public static bool? VerifyCompenets(string v1, string v2, string v3)
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.Id("cd-video-url"));  //URl
                Driver.existsElement(By.Id("cd-video-add"));  // Add button
                Driver.GetElement(By.XPath("//div[@id='loading-area']/div[2]/div/p")).Text.Contains("No Video Added");  // preview
                Driver.existsElement(By.Id("MainContent_MainContent_UC1_Save"));
                result = true;
            }
            catch { }
            return result;
        }

        public static void AddNewURL(string promoURL)
        {
            if (Driver.GetElement(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']")).Text.Equals("Checkout"))
            {
                Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
            }
            Driver.existsElement(By.Id("cd-video-url"));
            Driver.GetElement(By.Id("cd-video-url")).Clear();
            Driver.GetElement(By.Id("cd-video-url")).SendKeysWithSpace(promoURL);
            Actions action = new Actions(Driver.Instance);
            action.SendKeys(Keys.Escape);
            Driver.clickEleJs(By.Id("cd-video-add"));
            Driver.GetElement(By.Id("cd-video-add")).ClickWithSpace();
        }

        public static bool? isVideoPreviewDisplay()
        {
            return Driver.existsElement(By.XPath("//div[@id='loading-area']"));
        }

        public static void Click_SaveButton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Save"));
        }

        public static string getSuccessfulmessage()
        {
            return Driver.getSuccessMessage();
        }

        public static void Click_BackButton()
        {
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_btnCancel"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
        }
    }
}