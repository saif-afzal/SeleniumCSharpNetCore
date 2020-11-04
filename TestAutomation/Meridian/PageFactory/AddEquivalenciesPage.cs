using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class AddEquivalenciesPage
    {
        public static string GetSuccessMessage()
        {
            throw new NotImplementedException();
        }

        public static void ClickSeaMoreSearchCriteria()
        {
            throw new NotImplementedException();
        }

        public static void VerifySearchButton()
        {
            throw new NotImplementedException();
        }

        public static void VerifyBackButton()
        {
            throw new NotImplementedException();
        }

        public static void VerifyAddButton()
        {
            throw new NotImplementedException();
        }

        public static void Search(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='MainContent_MainContent_UC1_txtSearchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_btnSearch']"));
        }

        public static void SelectRecord()
        {
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgEquivalencies_ctl00_ctl04_chkSelect']"));
        }

        public static void ClickAddButton()
        {
            Driver.clickEleJs(By.XPath("//input[@id='MainContent_MainContent_UC1_Add']"));

        }

        public static bool? IsSearchfieldsDisplayed()
        {
            bool result = false;
            try
            {
                //Driver.Instance.waitforframe(By.CssSelector("iframe[class='k-content-frame']"));
                Driver.Instance.IsElementVisible(By.Id("searchFor"));
                Driver.Instance.IsElementVisible(By.Id("showInActiveContent"));
                //Driver.Instance.IsElementVisible(By.Id("MainContent_MainContent_UC1_lblContentType"));
                Driver.Instance.IsElementVisible(By.XPath("//*[@id='btn-content-search']/span"));
                result = true;
            }
            catch { }
            return result;
        }

        public static SearchForCommand SearchFor(string v)
        {
            return new SearchForCommand(v);
        }

        public static void ClickBackButton()
        {
            Driver.Instance.Navigate().Back();
            //Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
        }

        
    }

    public class SearchForCommand
    {
        private string v;

        public SearchForCommand(string v)
        {
            this.v = v;
        }

        public void ClickAddbutton()
        {
            Driver.GetElement(By.XPath("//input[@id='searchFor']")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.XPath("//a[@id='btn-content-search']//span[@class='fa fa-search']"));
            Driver.clickEleJs(By.XPath("//tr[1]//td[1]//input[1]"));

            // Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect"));
            Driver.clickEleJs(By.XPath("//button[@id='equiv-modal-add']"));


            //Driver.GetElement(By.Id("MainContent_MainContent_UC1_txtSearchFor")).SendKeysWithSpace(v);
            //Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnSearch"));
            //Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgEquivalencies_ctl00_ctl04_chkSelect"));
            //// Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect"));
            //Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_Add"));
        }
    }
}