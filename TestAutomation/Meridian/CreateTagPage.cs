using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using OpenQA.Selenium;
using System.Threading;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    internal class CreateTagPage
    {
        internal static void ClickCheckbox_AssociatedContent()
        {
            Driver.clickEleJs(By.XPath("//input[@data-index='0']"));

        }

        internal static void ClickButton_Remove()
        {
            Driver.clickEleJs(By.XPath("//button[@class='btn btn-danger']"));
            Driver.clickEleJs(By.XPath("//button[contains(.,'OK')]"));
            Thread.Sleep(4000);
        }

        internal static void EnterTagTitle(string v)
        {
            Driver.Instance.FindElement(By.XPath("//input[@class='form-control xeditable-100']")).Clear();
            Driver.Instance.FindElement(By.XPath("//input[@class='form-control xeditable-100']")).SendKeysWithSpace(v);
        }

        internal static void ClickButton_SaveTagTitle(string s)
        {
            Driver.clickEleJs(By.XPath("//button[@type='submit']"));
            Driver.Instance.WaitForElement(By.XPath("//a[contains(.,'" +s+ "')]"));
        }

        internal static void ClickButton_AccociateContent()
        {
            Driver.clickEleJs(By.XPath("//input[@value='Associate Content']"));
        }

        internal static void EnterSearchContent()
        {
            Driver.Instance.SwitchWindow("");
            Driver.Instance.FindElement(By.XPath("//input[@id='contentSearch']")).SendKeysWithSpace(""); 

        }

        internal static void ClickButton_Search()
        {
            Driver.clickEleJs(By.XPath("//span[@aria-title='Search']")); 
        }

        public static string SelectCheckboxForContent()
        {
            string s;
            Driver.clickEleJs(By.XPath("//input[@data-index='0']"));
            s = Driver.Instance.FindElement(By.XPath("//tr[@data-index='0']/td[2]")).Text;
            return s;
        }

        internal static void ClickButton_Add()
        {
            Driver.clickEleJs(By.XPath("//button[@class='btn btn-primary']")); 
            Driver.Instance.SwitchTo().DefaultContent();
            Thread.Sleep(3000);
        }
    }
}