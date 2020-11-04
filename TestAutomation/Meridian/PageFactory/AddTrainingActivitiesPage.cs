using OpenQA.Selenium;
using Selenium2.Meridian.P1.MyResponsibilities.Training;
using System;

namespace Selenium2.Meridian.Suite
{
    public class AddTrainingActivitiesPage
    {
        public static DropdownToggleCommand DropdownToggle { get { return new DropdownToggleCommand(); } }

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
            Driver.existsElement(By.Id("MainContent_MainContent_UC1_ucContentSearch_txtSearchFor"));
            Driver.GetElement(By.Id("MainContent_MainContent_UC1_ucContentSearch_txtSearchFor")).SendKeysWithSpace(v);
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_ucContentSearch_btnSearch"));

        }

        public static void AddTraing()
        {
            if (Driver.existsElement(By.XPath("//tr[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00__0']/td/input"))) //for classroom
            {
                //Driver.clickEleJs(By.XPath("//tr[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00__0']/td/input"));
                Driver.clickEleJs(By.Id("ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl04_chkSelect"));
               // Driver.clickEleJs(By.XPath("//td[2]/table/tbody/tr/td/input"));
                Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnAddActivity"));
            }
            else
            {
                Driver.existsElement(By.XPath("//td[2]/input"));
                Driver.clickEleJs(By.XPath("//td[2]/input"));
                Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnAddActivity"));
            }
        }

        public static bool? verifyfeedbackmessage(string v)
        {
            Driver.existsElement(By.XPath("//div[@id='content']/div[2]/div"));
            return Driver.GetElement(By.XPath("//div[@id='content']/div[2]/div")).Text.Equals(v);
        }

        public static void ClickBreadcrumblink(string v)
        {
            Driver.clickEleJs(By.LinkText(v));
        }

        public static void Click_backbutton()
        {
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnCancel"));
        }

        public static void ClickCheckButton()
        {
            Driver.clickEleJs(By.XPath("//input[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00_ctl04_chkSelect']"));
        }

        public static void ClickAddButton()
        {
            Driver.clickEleJs(By.XPath("//tr[@id='ctl00_ctl00_MainContent_MainContent_UC1_rgBlockActivityContent_ctl00__0']/td[2]/input"));
            Driver.clickEleJs(By.Id("MainContent_MainContent_UC1_btnAddActivity"));
        }

        public static void ClickCheckInButton()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnStatus']"));
        }
    }

    public class DropdownToggleCommand
    {
        public void ViewAsLearner()
        {
            Driver.clickEleJs(By.XPath("//a[@id='MainContent_header_FormView1_btnViewCatalog']"));
        }
    }
}