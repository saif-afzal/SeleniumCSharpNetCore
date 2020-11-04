using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace TestAutomation.Suite.Responsibilities.ProfessionalDevelopment
{
    public class AddLocalizationModal
    {
        public static LocalizedIndropdownCommand LocalizedIndropdown
        {
            get { return new LocalizedIndropdownCommand(); }
        }

        public static void EnterForm(string v1, string v2, string v3)
        {
            Driver.Instance.FindElement(By.Id("add-title-link")).Click();
            Driver.Instance.FindElement(By.XPath("//div[@id='titleToLocalize']/span/div/form/div/div/div/input")).Clear();
            Driver.Instance.FindElement(By.XPath("//div[@id='titleToLocalize']/span/div/form/div/div/div/input")).SendKeys(v1);
            Driver.clickEleJs(By.XPath("//div[2]/div/button/span"));

            Driver.clickEleJs(By.Id("add-description-link"));
            Driver.Instance.FindElement(By.XPath("//textarea")).Clear();
            Driver.Instance.FindElement(By.XPath("//textarea")).SendKeys(v2);
            Driver.Instance.FindElement(By.XPath("//div[2]/div/button/span")).Click();

            Driver.Instance.FindElement(By.Id("add-keywords-link")).Click();
            Driver.Instance.FindElement(By.XPath("(//input[@type='text'])[8]")).Clear();
            Driver.Instance.FindElement(By.XPath("(//input[@type='text'])[8]")).SendKeys(v3);
            Driver.Instance.FindElement(By.XPath("//div[2]/div/button/span")).Click();

        }

        public static void ClickLocalize()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btn-add-locale']"));
        }
    }
}