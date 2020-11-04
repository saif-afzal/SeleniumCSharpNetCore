using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    internal class ContentTagPage
    {
        public static bool? ListofTagsDisplay { get { return Driver.GetElement(By.XPath("//table[@id='table-tags']/tbody/tr/td[2]/a")).Displayed; } }

        public ContentTagPage(IWebDriver Driver)
        {
           
        }
        internal static void ClickButton_CreateTag()
        {
            if (Driver.Instance.IsElementVisible(By.XPath("//div[@id='panel-empty']/a")))
            {
                Driver.clickEleJs(By.XPath("//div[@id='panel-empty']/a"));
            }
            else
            {
                Driver.clickEleJs(By.XPath("//div[@class='row']/div[2]/a"));
            }
            

        }

        internal static void ClickCheckbox_CreateTag()
        {
          Driver.clickEleJs(By.XPath("//input[@data-index='0']"));
        }

        internal static void ClickButton_Remove()
        {
            Driver.clickEleJs(By.XPath("//button[@class='btn btn-danger']"));
            Driver.clickEleJs(By.XPath("//button[contains(.,'OK')]"));
            
        }

        internal static void EnterTagToSearch(string v)
        {
            Driver.Instance.FindElement(By.XPath("//input[@id='txtTagSearch']")).SendKeysWithSpace(v);
        }

        internal static void ClickButton_Search(string s)
        {
            Driver.clickEleJs(By.XPath("//button[@id='btnTagSearch']"));
            Driver.Instance.WaitForElement(By.XPath("//a[contains(.,'" + s + "')]"));
        }

        internal static void ClickLink_SearchedTag(string s)
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'"+ s +"')]"));
        }

        internal static void ClickCheckbox_AssociatedContent()
        {
            throw new NotImplementedException();
        }

        internal static void ClickButton_Search_AfterDelete()
        {
            Driver.clickEleJs(By.XPath("//button[@id='btnTagSearch']"));
        }

        internal static void DeleteTags(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal static bool? ListofTags(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal static void SearchTags(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal static bool? SearchDeletedTags(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal static void SelectSearchtag()
        {
            Thread.Sleep(2000);
            Driver.clickEleJs(By.XPath("//table[@id='table-tags']/tbody/tr/td/input"));
        }

        internal static void ClickButtonRemove()
        {
            Driver.clickEleJs(By.XPath("//button[@class='btn btn-danger']"));
        }

        internal static string GetRemoveConfimationMessage()
        {
            Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
            return Driver.GetElement(By.CssSelector("div.bootbox-body")).Text;
        }

        internal static void ClickOKinDeleteConfirmationModal()
        {
            Driver.clickEleJs(By.XPath("//button[contains(.,'OK')]"));
        }

        internal static string GetSuccessMessage()
        {
            return Driver.getSuccessMessage();
        }
    }
}