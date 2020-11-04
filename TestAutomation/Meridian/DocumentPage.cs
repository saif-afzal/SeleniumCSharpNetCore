using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;
using System.Threading;

namespace Selenium2.Meridian.Suite.Administration.AdministrationConsole
{
    public class DocumentPage
    {
        public static DisplayFormatCommand DisplayFormatDropdown { get { return new DisplayFormatCommand(); } }

        public static AvailableinCatalogCommand AvailableinCatalog { get { return new AvailableinCatalogCommand(); } }

        public static void Populate_DocumentData(string documentitle, string url = "")
        {
            Driver.Instance.FindElement(By.XPath("//input[@id='CNTLCL_TITLE']")).SendKeys(documentitle);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_EXTERNALFILE_URL']"));
            Driver.Instance.FindElement(By.XPath("//input[@id='MainContent_UC1_DOCUMENT_URL']")).SendKeys("www.google.com");
        }

        public static void ClickButton_Create()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_UC1_Save']"));
        }

        public static void ClickButton_CheckIn()
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'Check-in')]"));
        }

        public static void ClickButton_CheckOut()
        {
            Driver.clickEleJs(By.XPath("//a[contains(.,'Checkout')]"));
        }

        public static void click_publish()
        {

            Driver.Instance.FindElement(By.XPath("")).Click();
        }

        public static void SearchTagForNewContent(string tagname)
        {
            Driver.clickEleJs(By.Id("ContentTags"));
            Thread.Sleep(2000);
            Driver.GetElement(By.XPath("//input[@autocapitalize='off']")).SendKeysWithSpace(tagname);
            Thread.Sleep(1000);
            IWebElement webElement = Driver.Instance.FindElement(By.XPath("//input[@autocapitalize='off']"));
            webElement.SendKeys(Keys.Tab);
            Thread.Sleep(1000);
            Driver.clickEleJs(By.XPath("//div[@id='container-tags']/div/span/div/form/div/div/div[2]/button/i"));
            Thread.Sleep(1000);
        }

        public static void CreateDocument(string v)
        {
            Driver.existsElement(By.Id("CNTLCL_TITLE"));
            Driver.Instance.FindElement(By.Id("CNTLCL_TITLE")).SendKeys(v);
            Driver.Instance.FindElement(By.Id("MainContent_UC1_FormView1_CNTLCL_KEYWORDS")).SendKeys("Test");
            Driver.clickEleJs(By.Id("MainContent_UC1_EXTERNALFILE_URL"));
            Driver.GetElement(By.Id("MainContent_UC1_DOCUMENT_URL")).SendKeys("www.google.com");
            Driver.clickEleJs(By.Id("MainContent_UC1_Save"));
        }
    }
}