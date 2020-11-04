using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class AddPrerequisitesPage
    {
        public static string GetSuccessMessage()
        {
            throw new NotImplementedException();
        }

        public static void SelectRecord()
        {
            Driver.existsElement(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect']"));
            Driver.GetElement(By.XPath("//tr[1]//td[1]//input[1]")).ClickChkBox();
        }

        public static void ClickAddButton()
        {
            Driver.clickEleJs(By.Id("prereq-modal-add"));
        }

        public static void ClickBackButton()
        {
            Driver.clickEleJs(By.XPath("//div[@id='content']/div/ol/li[3]/a"));
           // Driver.clickEleJs(By.LinkText("//a[contains(text(), '" +  + "')]"));
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

        public static void SearchFor(string v)
        {
            Driver.GetElement(By.XPath("//input[@id='searchFor']")).SendKeysWithSpace(v);
            Driver.existsElement(By.XPath("//a[@id='btn-content-search']//span[@class='fa fa-search']"));
            Driver.clickEleJs(By.XPath("//a[@id='btn-content-search']//span[@class='fa fa-search']"));
            Driver.existsElement(By.XPath("//a[@id='btn-content-search']//span[@class='fa fa-search']"));
            Driver.GetElement(By.XPath("//tr[1]//td[1]//input[1]")).ClickWithSpace();

           // Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgPrerequisites_ctl00_ctl04_chkSelect"));
            Driver.clickEleJs(By.XPath("//button[@id='prereq-modal-add']"));
        }

        public static bool? IsSearchfieldsDisplayed()
        {
            bool result = false;
            try
            {
                Driver.existsElement(By.XPath("//a[@id='btn-content-search']//span[@class='fa fa-search']"));
                Driver.existsElement(By.XPath("//div[@class='modal-dialog modal-lg']//button[@class='btn btn-default pull-left'][contains(text(),'Cancel')]"));
                Driver.existsElement(By.XPath("//a[@class='th-inner sortable both'][contains(text(),'Type')]"));
                //Driver.existsElement(By.Id("MainContent_MainContent_UC1_btnSearch"));
                Driver.existsElement(By.XPath("//input[@id='searchFor']"));
                result = true;
            }
            catch { }
            return result;
        }
    }
}