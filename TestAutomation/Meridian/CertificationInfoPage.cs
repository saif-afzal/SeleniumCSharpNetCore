using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class CertificationInfoPage
    {
        public static CompletionCriteriaTabCommand CompletionCriteriaTab
        {
            get { return new CompletionCriteriaTabCommand(); }
        }

        public static ReCertificationCriteriaTabCommand ReCertificationCriteriaTab
        {
            get { return new ReCertificationCriteriaTabCommand(); }
        }

        public static void SelectCompletionCriteriaTab()
        {
            Driver.clickEleJs(By.Id("TabMenutd1"));
        }

        public static void SelectReCertificationCriteriaTab()
        {
            Driver.clickEleJs(By.Id("TabMenutd2"));
        }
    }

    public class ReCertificationCriteriaTabCommand
    {
        public bool? isTextWithNumberOfCreditsAndCreditTypesDisplayed(string v)
        {
            return Driver.existsElement(By.XPath("//b[contains(text(),'" + v + "')]"));

        }
    }

    public class CompletionCriteriaTabCommand
    {
        public bool? isTextWithNumberOfCreditsAndCreditTypesDisplayed(string v)
        {
            return Driver.existsElement(By.XPath("//b[contains(text(),'"+v+"')]"));
        }
    }
}