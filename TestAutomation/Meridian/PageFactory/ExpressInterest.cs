using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite
{
    public class ExpressInterest
    {
        public static bool? isTopicOfInterestDisplayed()
        {
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));

            return Driver.existsElement(By.Id("MainContent_UC1_UI_TOPIC_OF_INTEREST"));
        }

        public static bool? isContentTypeDisplayed()
        {
            return Driver.existsElement(By.Id("MainContent_UC1_UI_CONTENT_TYPE_ID"));
        }

        public static bool? isReasonDisplayed()
        {
            return Driver.existsElement(By.Id("MainContent_UC1_UI_REASON"));
        }

        public static bool? isISeekTrainingAfterDisplayed()
        {
            return Driver.existsElement(By.Id("ctl00_MainContent_UC1_UI_AFTER_DATE_dateInput"));

        }

        public static bool? isISeekTrainingBeforeDisplayed()
        {
            return Driver.existsElement(By.Id("ctl00_MainContent_UC1_UI_BEFORE_DATE_dateInput"));
        }

        public static bool? isIPreferToTrainDisplayed()
        {
            return Driver.existsElement(By.Id("MainContent_UC1_UI_DATETIME_PREFERENCE"));
        }

        public static bool? isLocationDisplayed()
        {
            return Driver.existsElement(By.Id("MainContent_UC1_UI_LOCATION"));
        }

        public static bool? isAdditionalInformationDisplayed()
        {
            return Driver.existsElement(By.Id("MainContent_UC1_UI_ADDITIONAL_INFO"));

        }

        public static bool? isCancelButtonDisplayed()
        {
            return Driver.existsElement(By.Id("MainContent_UC1_btnCancel"));
        }

        public static bool? isSubmitButtonDisplayed()
        {
            return Driver.existsElement(By.Id("MainContent_UC1_btnSubmit"));
        }

        public  static void SubmitWith(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8)
        {
            Driver.GetElement(By.Id("MainContent_UC1_UI_TOPIC_OF_INTEREST")).SendKeysWithSpace(v1);

            Driver.select(By.Id("MainContent_UC1_UI_CONTENT_TYPE_ID"),v2);
          
            Driver.select(By.Id("MainContent_UC1_UI_REASON"),v3);
            Driver.GetElement(By.Id("ctl00_MainContent_UC1_UI_AFTER_DATE_dateInput")).SendKeys(v4);
            Driver.GetElement(By.Id("ctl00_MainContent_UC1_UI_BEFORE_DATE_dateInput")).SendKeys(v5);
            Driver.select(By.Id("MainContent_UC1_UI_DATETIME_PREFERENCE"),v6);
            Driver.GetElement(By.Id("MainContent_UC1_UI_LOCATION")).SendKeys(v7);
            Driver.GetElement(By.Id("MainContent_UC1_UI_ADDITIONAL_INFO")).SendKeysWithSpace(v8);
            Driver.clickEleJs(By.Id("MainContent_UC1_btnSubmit"));

            Driver.Instance.SwitchTo().DefaultContent();
        }
    }
}